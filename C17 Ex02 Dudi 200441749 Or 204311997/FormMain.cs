using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using C17_Ex01_Dudi_200441749_Or_204311997.DataTables;
using System.Threading;
using C17_Ex01_Dudi_200441749_Or_204311997.Adapter;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    using C17_Ex01_Dudi_200441749_Or_204311997.Properties;

    public partial class FormMain : Form
    {
        private const bool k_UseCollectionAdapter = true;
        private static readonly Size sr_MinimumWindowSize = new Size(AppSettings.k_DefaultMainFormWidth, AppSettings.k_DefaultMainFormHeight);
        private readonly object r_UpdateAboutMeFriendsLock = new object();
        private readonly object r_UpdateLikedPagesLock = new object();
        private readonly object r_InitLastPostLock = new object();
        private FacebookDataTableManager m_DataTableManager;
        private FacebookDataTable m_DataTableBindedToView;
        private FriendshipAnalyzer m_FriendshipAnalyzer;
        private string m_PostPicturePath;
        private bool m_LogoutClicked;



        public FormMain()
        {
            InitializeComponent();
        }

        // ================================================ general form methods ================================================
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            initMainForm();
        }

        private void initMainForm()
        {
            string userName = FacebookApplication.LoggedInUser.Name ?? string.Empty;
            Text = userName;
            labelUserName.Text = userName;
            MinimumSize = sr_MinimumWindowSize;
            FacebookApplication.StartThread(fetchProfileAndCoverPhotos);
            // lazy load the two tabs not visible
            tabControl.TabPages[1].HandleCreated += (i_Sender, i_Args) => initDataTablesTab();
            tabControl.TabPages[2].HandleCreated += (i_Sender, i_Args) => initFriendshipAnalyzerTab();
            initAboutMeTab();
        }

        private void fetchProfileAndCoverPhotos()
        {
            try
            {
                pictureBoxProfilePicture.LoadAsync(FacebookApplication.LoggedInUser.PictureNormalURL);
                pictureBoxCoverPhoto.LoadAsync(FacebookApplication.LoggedInUser.Cover.SourceURL);
            }
            catch
            {
                MessageBox.Show("Profile or cover photo missing, default photos were loaded");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            FacebookApplication.KillAllRunningThreads();

            if (!m_LogoutClicked)
            {
                // exitSelected is set here in case the user hits the X button or alt+F4
                FacebookApplication.ExitSelected = true;
                FacebookApplication.AppSettings.LastFormStartPosition = FormStartPosition.Manual;
                FacebookApplication.AppSettings.LastWindowLocation = Location;
                FacebookApplication.AppSettings.LastWindowsSize = Size;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            FacebookApplication.ExitSelected = true;
            Close();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            m_LogoutClicked = true;
            FacebookApplication.Logout();
        }

        // ================================================ About Me Tab ==============================================
        private void initAboutMeTab()
        {
            // fetch and bind data from Facebook server
            try
            {
                FacebookApplication.StartThread(() => UpdateFriendsLayoutPanel(flowLayoutPanelAboutMeFriends, FriendProfile_MouseClick));
                FacebookApplication.StartThread(() => updateLikedPages(!k_UseCollectionAdapter));
                FacebookApplication.StartThread(updateMostRecentPost);
                FacebookApplication.StartThread(initFriendsListForNewPostTags);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error while fetching data from the Facebook server: {0}", ex.Message));
            }
        }

        private void updateLikedPages(bool i_UseCollectionAdapter)
        {
            lock (r_UpdateLikedPagesLock)
            {
                try
                {
                    FacebookObjectCollection<Page> likedPages;

                    if (i_UseCollectionAdapter)
                    {
                        FacebookCollectionAdapter<Page> collectionAdapter = new FacebookCollectionAdapter<Page>(eFacebookCollectionType.LikedPages);
                        FacebookObjectCollection<FacebookObject> likedPagesFromAdapter = collectionAdapter.FetchDataWithProgressBar();
                        likedPages = collectionAdapter.UnboxCollection(likedPagesFromAdapter);
                    }
                    else
                    {
                        likedPages = FacebookApplication.LoggedInUser.LikedPages;
                    }

                    listBoxLikedPage.Invoke(new Action(() =>
                        {
                            likedPagesBindingSource.DataSource = likedPages;
                            listBoxLikedPage.ClearSelected();
                        }));
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error while getting most recent post: " + e.Message);
                }
            }
        }

        private void updateMostRecentPost()
        {
            lock (r_InitLastPostLock)
            {
                if (FacebookApplication.LoggedInUser != null)
                {
                    try
                    {
                        panelLastPost.Invoke(new Action(() => setLastPostControls(null)));
                        FacebookApplication.LoggedInUser.ReFetch("posts");
                        if (FacebookApplication.LoggedInUser.Posts.Count != 0)
                        {
                            panelLastPost.Invoke(new Action(() => setLastPostControls(FacebookApplication.LoggedInUser.Posts[0])));
                        }
                        else
                        {
                            MessageBox.Show("No available posts");
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error while getting most recent post: " + e.Message);
                    }
                }
            }
        }

        // updates all controls of the lastPost panel, null parameter to reset all
        private void setLastPostControls(Post i_Post)
        {
            if (i_Post != null)
            {
                // posted message
                textBoxLastPostMessage.Text = i_Post.Message ?? "[No post message]";
                // posted photo
                if (!string.IsNullOrEmpty(i_Post.PictureURL))
                {
                    pictureBoxLastPost.Load(i_Post.PictureURL);
                }

                // people who liked the post
                listBoxPostLiked.DisplayMember = "Name";
                foreach (User friendWhoLiked in i_Post.LikedBy)
                {
                    listBoxPostLiked.Items.Add(friendWhoLiked);
                }

                // post comments
                listBoxPostComment.DisplayMember = "Message";
                foreach (Comment comment in i_Post.Comments)
                {
                    listBoxPostComment.Items.Add(comment);
                }
            }
            else
            {
                clearLastPostControls();
            }
        }

        private void clearLastPostControls()
        {
            textBoxLastPostMessage.Text = "Fetching....";
            listBoxPostLiked.Items.Clear();
            listBoxPostComment.Items.Clear();
            pictureBoxLastPost.Image = null;
        }

        private void initFriendsListForNewPostTags()
        {
            FacebookObjectCollection<User> friends = FacebookApplication.LoggedInUser.Friends;

            listBoxPostTags.Invoke(new Action(() =>
            {
                friendsBindingSource.DataSource = friends;
                listBoxPostTags.ClearSelected();
            }));
        }

        private void ListBoxPostLiked_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (((ListBox)sender).SelectedItem is User friend)
            {
                MessageBox.Show(friend.Name + " Liked your post!");
            }
        }

        private void ListBoxPostComment_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showCommentAsMessageBox(((ListBox)sender).SelectedItem as Comment);
        }

        private void FriendProfile_MouseClick(object sender, MouseEventArgs e)
        {
            displayFriendDetailsInAboutMeTab(sender as PictureBox);
        }

        private void displayFriendDetailsInAboutMeTab(PictureBox i_PictureBoxSelected)
        {
            if (i_PictureBoxSelected != null && i_PictureBoxSelected.Tag is User friendSelected)
            {
                new FormFriendDetails(friendSelected).ShowDialog();
            }
        }

        private void buttonRefreshFriends_Click(object sender, EventArgs e)
        {
            FacebookApplication.StartThread(
                () => UpdateFriendsLayoutPanel(flowLayoutPanelAboutMeFriends, FriendProfile_MouseClick));
        }

        private void URL_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            linkLabelLikedPageURL.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start(linkLabelLikedPageURL.Text);
        }

        private void buttonRefreshLikedPage_Click(object sender, EventArgs e)
        {
            FacebookApplication.StartThread(() => updateLikedPages(k_UseCollectionAdapter));
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            postStatus();
        }

        private void postStatus()
        {
            try
            {
                if (!string.IsNullOrEmpty(richTextBoxStatusPost.Text))
                {
                    string friendID = createFriendsToTagStr();
                    Status postedStatus = FacebookApplication.LoggedInUser.PostStatus(richTextBoxStatusPost.Text, i_TaggedFriendIDs: friendID);
                    string successPostMessage = string.Format("The Status: \"{0}\" was succefully posted!", postedStatus.Message);
                    MessageBox.Show(successPostMessage);
                    richTextBoxStatusPost.Clear();
                    listBoxPostTags.ClearSelected();
                    FacebookApplication.StartThread(updateMostRecentPost);
                }
                else
                {
                    MessageBox.Show("Cannot post an empty status, please input some text and try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error while posting status: {0}", ex.Message));
            }
        }

        private string createFriendsToTagStr()
        {
            StringBuilder friendIDStringBuilder = new StringBuilder();

            foreach (User friend in listBoxPostTags.SelectedItems)
            {
                friendIDStringBuilder.Append(friend.Id + ",");
            }

            string friendID = friendIDStringBuilder.ToString();

            return !string.IsNullOrEmpty(friendID) ? friendID.Remove(friendID.Length - 1) : null;
        }

        // maybe we should delete this button, friends aren't added so frequently
        private void buttonRefreshTagFriends_Click(object sender, EventArgs e)
        {
            FacebookApplication.LoggedInUser.ReFetch("friends");
            friendsBindingSource.DataSource = FacebookApplication.LoggedInUser.Friends;
            listBoxPostTags.ClearSelected();
        }

        private void buttonClearPostTags_Click(object sender, EventArgs e)
        {
            listBoxPostTags.ClearSelected();
        }

        private void buttonAddPicture_Click(object sender, EventArgs e)
        {
            openPhotoForPost();
        }

        private void openPhotoForPost()
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();

                if (file.ShowDialog() == DialogResult.OK)
                {
                    m_PostPicturePath = Path.GetFullPath(file.FileName);
                    pictureBoxPostPhoto.Image = Image.FromFile(file.FileName);
                }
            }
            catch
            {
                MessageBox.Show("Error while trying to open file, try again");
            }
        }

        private void buttonPostPhoto_Click(object sender, EventArgs e)
        {
            postPhoto();
        }

        private void postPhoto()
        {
            try
            {
                if (!string.IsNullOrEmpty(m_PostPicturePath))
                {
                    Post postedItem = FacebookApplication.LoggedInUser.PostPhoto(m_PostPicturePath, i_Title: richTextBoxPostPhoto.Text);

                    // TODO do we need to check if postedItem != null?
                    MessageBox.Show("The photo was successfully posted!");
                    richTextBoxPostPhoto.Clear();
                    FacebookApplication.StartThread(updateMostRecentPost);
                }
                else
                {
                    MessageBox.Show("No photo added, please add a photo and try again");
                }
            }
            catch
            {
                MessageBox.Show("Error while trying to post the photo, try again");
            }
        }

        private void buttonRefreshLastPost_Click(object sender, EventArgs e)
        {
            FacebookApplication.StartThread(updateMostRecentPost);
        }

        private void pictureBoxLastPost_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // TODO doesn't work because the tag is string, if we can pull the Photo from post update the tag and this will work
            if (((PictureBox)sender).Tag is Photo photo)
            {
                PhotoDetails photoDetails = new PhotoDetails(photo);
                photoDetails.Show();
            }
        }

        // ================================================ DataTables Tab ==============================================
        private void initDataTablesTab()
        {
            m_DataTableManager = new FacebookDataTableManager();
            initComboBoxDataTableBindingSelection();
        }

        private void initComboBoxDataTableBindingSelection()
        {
            comboBoxDataTableBindingSelection.DisplayMember = "TableName";
            comboBoxDataTableBindingSelection.DataSource = m_DataTableManager.GetDataTables();
        }

        private void fetchDataForDataTablesTab()
        {
            if (comboBoxDataTableBindingSelection.SelectedItem != null)
            {
                dataGridView.DataSource = null;
                m_DataTableBindedToView = (FacebookDataTable)comboBoxDataTableBindingSelection.SelectedItem;
                if (m_DataTableBindedToView.DataTable.Rows.Count == 0 || m_DataTableBindedToView is FacebookPhotosDataTable)
                {
                    FacebookObjectCollection<FacebookObject> collection = fetchCollectionWithAdapter(m_DataTableBindedToView.GetType());
                    m_DataTableBindedToView.PopulateRows(collection);
                    timerDataTables.Start();
                }
                dataGridView.DataSource = m_DataTableBindedToView.DataTable;

                if (dataGridView.Columns["ObjectDisplayed"] != null)
                {
                    dataGridView.Columns["ObjectDisplayed"].Visible = false;
                }

                if (dataGridView.Columns.Count == 0)
                {
                    MessageBox.Show("The requested table could not be loaded, please try again");
                }
            }
        }

        private FacebookObjectCollection<FacebookObject> fetchCollectionWithAdapter(Type i_DataTableType)
        {
            FacebookObjectCollection<FacebookObject> collection;

            if (i_DataTableType.Name == typeof(FacebookPhotosDataTable).Name)
            {
                AlbumsSelector albumSelector = new AlbumsSelector(FacebookApplication.LoggedInUser);
                FacebookCollectionAdapter<Photo> myPhotosAdapter = new FacebookCollectionAdapter<Photo>(Adapter.eFacebookCollectionType.AlbumPhotos);
                myPhotosAdapter.AlbumsToLoad = albumSelector.GetAlbumsSelection();
                collection = myPhotosAdapter.FetchDataWithProgressBar();
            }
            else if (i_DataTableType.Name == typeof(FacebookLikedPagesDataTable).Name)
            {
                collection = new FacebookCollectionAdapter<Page>(Adapter.eFacebookCollectionType.LikedPages).FetchDataWithProgressBar();
            }
            else if (i_DataTableType.Name == typeof(FacebookFriendsDataTable).Name)
            {
                collection = new FacebookCollectionAdapter<User>(Adapter.eFacebookCollectionType.Friends).FetchDataWithProgressBar();
            }
            else
            {
                throw new NotImplementedException("The given data table type is not supported");
            }

            return collection;
        }

        private void displayDetailsForRowObject(DataGridViewRow i_RowSelected)
        {
            object selectedObject = i_RowSelected.Cells["ObjectDisplayed"].Value;
            m_DataTableBindedToView.ObjectToDisplay = selectedObject;
            m_DataTableBindedToView.DisplayObject();
        }

        private void refreshDataGridView()
        {
            toolStripStatusLabel.Visible = true;
            dataGridView.Refresh();
            int totalRows = m_DataTableBindedToView.TotalRows;
            int loadedRows = m_DataTableBindedToView.DataTable.Rows.Count;
            if (totalRows == loadedRows)
            {
                toolStripStatusLabel.Text = "All rows loaded";
                timerDataTables.Stop();
            }
            else
            {
                toolStripStatusLabel.Text = string.Format("loaded {0}/{1} rows", loadedRows, totalRows);
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).SelectedCells.Count > 0)
            {
                DataGridViewRow rowSelected = ((DataGridView)sender).SelectedCells[0].OwningRow;
                rowSelected.Selected = true;
                displayDetailsForRowObject(rowSelected);
            }
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (((DataGridView)sender).SelectedCells.Count > 0)
            {
                ((DataGridView)sender).SelectedCells[0].OwningRow.Selected = true;
            }
        }

        private void buttonFetchData_Click(object sender, EventArgs e)
        {
            fetchDataForDataTablesTab();
        }

        private void timerDataTables_Tick(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        // ================================================ Friendship analyzer Tab ==============================================
        private Action FriendSelectionChanged;

        private void initFriendshipAnalyzerTab()
        {
            FriendSelectionChanged += OnFriendSelectionChanged;
            setEventHandlers();
            m_FriendshipAnalyzer = new FriendshipAnalyzer();
            FacebookApplication.StartThread(
                () => UpdateFriendsLayoutPanel(
                    flowLayoutPanelFriendshipAnalyzer,
                    friendshipAnalyzerFriendsDockPhoto_MouseClick));
        }

        protected virtual void OnFriendSelectionChanged()
        {
            User selectedFriend = m_FriendshipAnalyzer.Friend;

            panelGeneralInfo.Visible = false;
            clearAllTreeViews();
            listBoxPhotosCommentedOn.Items.Clear();
            pictureBoxMostRecentTaggedTogether.Reset();
            labelFirstName.Text = selectedFriend.FirstName;
            labelLastName.Text = selectedFriend.LastName;
            labelNumLikes.Text = string.Format("Number of times {0} liked my photos: {1}", selectedFriend.FirstName, "[no data fetched]");
            labelNumComments.Text = string.Format("Number of times {0} commented on my photos: {1}", selectedFriend.FirstName, "[no data fetched]");
            buttonFetchMyPhotosFriendIsIn.Text = string.Format("Fetch photos of mine {0} is in", selectedFriend.FirstName);
            buttonFetchPhotosOfFriendIAmTaggedIn.Text = string.Format("Fetch {0}'s Photos I am Tagged in", selectedFriend.FirstName);
            panelGeneralInfo.Visible = true;
        }

        private void friendshipAnalyzerFetchGeneralData()
        {
            buttonFetchGeneralData.Enabled = false;
            ProgressBarWindow progressBar = new ProgressBarWindow(2 * m_FriendshipAnalyzer.AllPhotos.Count, "statistics");
            progressBar.CancelEnabled = true; // likes + comments
            progressBar.Show();
            getMostRecentPhotoTogether();
            Thread getLikesThread = FacebookApplication.StartThread(
                () => m_FriendshipAnalyzer.CountNumberOfPhotosFriendLiked(() => progressBar.ProgressValue++));
            Thread getCommentsThread = FacebookApplication.StartThread(
                () => m_FriendshipAnalyzer.CountNumberOfPhotosFriendCommented(() => progressBar.ProgressValue++));
            FriendSelectionChanged += () => progressBar.Close();
            progressBar.Closing += (sender, e) =>
                {
                    FriendSelectionChanged -= () => progressBar.Close();
                    if (progressBar.DialogResult == DialogResult.Cancel)
                    {
                        getCommentsThread.Abort();
                        getLikesThread.Abort();
                    }
                    buttonFetchGeneralData.Enabled = true;
                };
            m_FriendshipAnalyzer.FinishedFetchingLikesAndComments += () =>
                {
                    finishedFetchingLikesAndComments();
                    progressBar.Close();
                };
        }

        private void finishedFetchingLikesAndComments()
        {
            if (!IsDisposed)
            {
                panelGeneralInfo.Invoke(
                    new Action(() =>
                            {
                                labelNumLikes.Text = string.Format(
"Number of times {0} liked my photos: {1}",
m_FriendshipAnalyzer.Friend.FirstName,
m_FriendshipAnalyzer.PhotosFriendLiked.Count);
                                labelNumComments.Text = string.Format(
"Number of times {0} commented on my photos: {1}",
m_FriendshipAnalyzer.Friend.FirstName,
m_FriendshipAnalyzer.CommentsByFriend.Count);
                                updateCommentsListBox();
                            }));
            }

        }

        private void fetchPhotosTaggedTogether()
        {
            FacebookCollectionAdapter<Photo> photosTaggedInAdapter = new FacebookCollectionAdapter<Photo>(eFacebookCollectionType.PhotosTaggedIn);
            FacebookObjectCollection<FacebookObject> boxPhotosTaggedIn = photosTaggedInAdapter.FetchDataWithProgressBar();
            FacebookObjectCollection<Photo> photosTaggedIn = photosTaggedInAdapter.UnboxCollection(boxPhotosTaggedIn);
            FacebookObjectCollection<Photo> photosTaggedTogether = m_FriendshipAnalyzer.PhotosTaggedTogether(photosTaggedIn);
            treeViewTaggedTogether.SetValues(photosTaggedTogether, FacebookPhotosTreeViewProxy.eGroupBy.Uploader);
        }

        private void fetchPhotosOfFriendInMyPhotos()
        {
            FacebookObjectCollection<Album> albums = fetchAlbums(FacebookApplication.LoggedInUser);
            FacebookObjectCollection<Photo> photosOfFriend = m_FriendshipAnalyzer.GetPhotosFromAlbumsUserIsTaggedIn(m_FriendshipAnalyzer.Friend, albums);
            treeViewPhotosOfFriendInMyPhotos.SetValues(photosOfFriend, FacebookPhotosTreeViewProxy.eGroupBy.Album);
        }

        private FacebookObjectCollection<Album> fetchAlbums(User i_User)
        {
            AlbumsSelector albumSelector = new AlbumsSelector(i_User);
            Album[] selectedAlbums = albumSelector.GetAlbumsSelection();
            FacebookCollectionAdapter<Album> albumsAdapter = new FacebookCollectionAdapter<Album>(eFacebookCollectionType.Albums)
            {
                AlbumsToLoad = selectedAlbums
            };

            FacebookObjectCollection<FacebookObject> boxAlbumsTaggedIn = albumsAdapter.FetchDataWithProgressBar();
            FacebookObjectCollection<Album> albums = albumsAdapter.UnboxCollection(boxAlbumsTaggedIn);

            return albums;
        }

        private void fetchPhotosOfMeInFriendsPhotos()
        {
            FacebookObjectCollection<Album> albums = fetchAlbums(m_FriendshipAnalyzer.Friend);
            FacebookObjectCollection<Photo> photos = m_FriendshipAnalyzer.GetPhotosFromAlbumsUserIsTaggedIn(FacebookApplication.LoggedInUser, albums);
            treeViewPhotosOfFriendIAmTaggedIn.SetValues(photos, FacebookPhotosTreeViewProxy.eGroupBy.Album);
        }

        private void setEventHandlers()
        {
            treeViewPhotosOfFriendInMyPhotos.NodeMouseDoubleClick += (sender, e) => photoTreeViewDoubleClicked(e.Node);
            treeViewTaggedTogether.NodeMouseDoubleClick += (sender, e) => photoTreeViewDoubleClicked(e.Node);
            buttonFetchPhotosOfFriendIAmTaggedIn.Click += (sender, e) => fetchPhotosOfMeInFriendsPhotos();
            buttonFetchTaggedTogether.Click += (sender, e) => this.fetchPhotosTaggedTogether();

        }

        private void photoTreeViewDoubleClicked(TreeNode i_SelectedNode)
        {
            if (i_SelectedNode.Tag is User)
            {
                User selectedUser = i_SelectedNode.Tag as User;
                PictureFrame profile = new PictureFrame(selectedUser.PictureLargeURL, selectedUser.Name);
                profile.Show();
            }
            else if (i_SelectedNode.Tag is Photo)
            {
                Photo selectedPhoto = i_SelectedNode.Tag as Photo;
                PhotoDetails photoDetails = new PhotoDetails(selectedPhoto);
                photoDetails.Show();
            }
        }

        private void friendshipAnalyzerFriendsDockPhoto_MouseClick(object sender, MouseEventArgs e)
        {
            if (((PictureBox)sender).Tag is User friend)
            {
                m_FriendshipAnalyzer.Friend = friend;
                if (FriendSelectionChanged != null)
                {
                    FriendSelectionChanged.Invoke();
                }
            }
        }

        private void clearAllTreeViews()
        {
            treeViewPhotosOfFriendIAmTaggedIn.Nodes.Clear();
            treeViewPhotosOfFriendInMyPhotos.Nodes.Clear();
            treeViewTaggedTogether.Nodes.Clear();
        }

        private void buttonFetchMyPhotosFriendIsIn_Click(object sender, EventArgs e)
        {
            fetchPhotosOfFriendInMyPhotos();
        }

        private void buttonFetchGeneralData_Click(object sender, EventArgs e)
        {
            friendshipAnalyzerFetchGeneralData();
        }

        private void getMostRecentPhotoTogether()
        {
            FacebookCollectionAdapter<Photo> photosTaggedInAdapter = new FacebookCollectionAdapter<Photo>(eFacebookCollectionType.PhotosTaggedIn);
            FacebookObjectCollection<FacebookObject> boxPhotosTaggedIn = photosTaggedInAdapter.FetchDataWithProgressBar();
            FacebookObjectCollection<Photo> photosTaggedIn = photosTaggedInAdapter.UnboxCollection(boxPhotosTaggedIn);
            FacebookObjectCollection<Photo> photosTaggedTogether = m_FriendshipAnalyzer.PhotosTaggedTogether(photosTaggedIn);
            Photo mostRecentTaggedTogether = m_FriendshipAnalyzer.GetMostRecentPhotoTaggedTogether(photosTaggedTogether);

            if (mostRecentTaggedTogether != null)
            {
                pictureBoxMostRecentTaggedTogether.LoadAsync(mostRecentTaggedTogether.PictureNormalURL);
                pictureBoxMostRecentTaggedTogether.Tag = mostRecentTaggedTogether;
            }
        }
        private void pictureBoxMostRecentTaggedTogether_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Tag is Photo photo)
            {
                PhotoDetails photoDetails = new PhotoDetails(photo);

                photoDetails.Show();
            }
        }

        private void updateCommentsListBox()
        {
            listBoxPhotosCommentedOn.DisplayMember = "Message";
            listBoxPhotosCommentedOn.Items.Clear();
            foreach (Comment comment in m_FriendshipAnalyzer.CommentsByFriend.Keys)
            {
                listBoxPhotosCommentedOn.Items.Add(comment);
            }
        }

        private void listBoxPhotosCommentedOn_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (((ListBox)sender).SelectedItem is Comment selectedComment)
            {
                new PhotoDetails(m_FriendshipAnalyzer.CommentsByFriend[selectedComment]).Show();
            }
        }

        // ================================================ Other methods ==============================================
        private void UpdateFriendsLayoutPanel(FlowLayoutPanel i_FlowLayoutPanel, MouseEventHandler i_OnMouseEventHandlerouseClick)
        {
            try
            {
                lock (r_UpdateAboutMeFriendsLock)
                {
                    FacebookApplication.LoggedInUser.ReFetch("friends");
                    i_FlowLayoutPanel.Invoke(new Action(() => i_FlowLayoutPanel.Controls.Clear()));

                    foreach (User friend in FacebookApplication.LoggedInUser.Friends)
                    {
                        GrowingPictureBoxProxy friendsProfilePic = new GrowingPictureBoxProxy(friend.PictureLargeURL, friend);
                        friendsProfilePic.MouseClick += i_OnMouseEventHandlerouseClick;
                        i_FlowLayoutPanel.Invoke(new Action(() => i_FlowLayoutPanel.Controls.Add(friendsProfilePic)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error while loading user's friends. error message: {0}", ex.Message));
            }
        }

        private void showCommentAsMessageBox(Comment i_Comment)
        {
            if (i_Comment != null)
            {
                User friendWhoCommented = i_Comment.From;
                string message = string.Format(
@"{0} commented:
{1}",
friendWhoCommented.Name,
i_Comment.Message);
                MessageBox.Show(message);
            }
        }
    }
}