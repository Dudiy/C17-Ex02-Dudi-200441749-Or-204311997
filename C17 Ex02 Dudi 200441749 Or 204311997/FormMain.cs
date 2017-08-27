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

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class FormMain : Form
    {
        private const byte k_PictureBoxIncreaseSizeOnMouseHover = 20;
        private static readonly Size sr_FriendProfilePicSize = new Size(90, 90);
        private static readonly Size sr_MinimumWindowSize = new Size(AppSettings.k_DefaultMainFormWidth, AppSettings.k_DefaultMainFormHeight);
        private FacebookDataTableManager m_DataTableManager;
        private FacebookDataTable m_DataTableBindedToView;
        private FriendshipAnalyzer m_FriendshipAnalyzer;
        private string m_PostPicturePath;
        private bool m_TabPageDataTablesInit = false;
        private bool m_TabPageFriendshipAnalyzer = false;
        private bool m_LogoutClicked = false;
        private object m_UpdateAboutMeFriendsLock = new object();
        private object m_InitLastPostLock = new object();

        public FormMain()
        {
            InitializeComponent();
        }

        // ================================================ general form methods ================================================
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            new Thread(initMainForm).Start();
        }

        private void initMainForm()
        {
            Invoke(new Action(() =>
            {
                Text = FacebookApplication.LoggedInUser.Name ?? string.Empty;
                labelUserName.Text = FacebookApplication.LoggedInUser.Name ?? string.Empty;
                MinimumSize = sr_MinimumWindowSize;
            }));
            fetchProfileAndCoverPhotos();
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
                updateAboutMeFriends();
                initLikedPages();
                initLastPost();
                // TODO doesn't work without thread
                //new Thread(initLastPost).Start();
                initPostTags();

            }
            catch
            {
                MessageBox.Show("Error while fetching data from the Facebook server");
            }

            listBoxPostLiked.MouseDoubleClick += ListBoxPostLiked_MouseDoubleClick;
            listBoxPostComment.MouseDoubleClick += ListBoxPostComment_MouseDoubleClick;
            listBoxPostTags.Invoke(new Action(() => listBoxPostTags.ClearSelected()));
        }

        private void initLikedPages()
        {
            FacebookObjectCollection<Page> likedPages = new FacebookCollectionAdapter<Page>(FacebookApplication.LoggedInUser.LikedPages).FetchDataWithProgressBar();
            listBoxLikedPage.Invoke(new Action(() => likedPagesBindingSource.DataSource = likedPages));
        }

        private void initPostTags()
        {
            FacebookObjectCollection<User> friends = FacebookApplication.LoggedInUser.Friends;

            listBoxPostTags.Invoke(new Action(() => friendsBindingSource.DataSource = friends));
        }

        private void updateAboutMeFriends()
        {
            try
            {
                lock (m_UpdateAboutMeFriendsLock)
                {
                    foreach (User friend in FacebookApplication.LoggedInUser.Friends)
                    {
                        PictureBox friendProfile = new PictureBox()
                        {
                            Image = friend.ImageLarge,
                            Size = sr_FriendProfilePicSize,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Tag = friend
                        };
                        //friendProfile.LoadAsync(friend.PictureLargeURL);

                        // TODO invoke ?
                        friendProfile.MouseEnter += FriendProfile_MouseEnter;
                        friendProfile.MouseLeave += FriendProfile_MouseLeave;
                        friendProfile.MouseClick += FriendProfile_MouseClick;
                        flowLayoutPanelAboutMeFriends.Invoke(new Action(() =>
                            flowLayoutPanelAboutMeFriends.Controls.Add(friendProfile)));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error while loading user's friend");
            }
        }

        private void initLastPost()
        {
            lock (m_InitLastPostLock)
            {
                if (FacebookApplication.LoggedInUser.Posts.Count != 0)
                {
                    clearLastPost();
                    getLastPost();
                }
                else
                {
                    MessageBox.Show("No available posts");
                }
            }
        }

        private void clearLastPost()
        {
            listBoxPostLiked.Invoke(new Action(() => listBoxPostLiked.Items.Clear()));
            listBoxPostComment.Invoke(new Action(() => listBoxPostComment.Items.Clear()));
            pictureBoxLastPost.Invoke(new Action(() => pictureBoxLastPost.Image = null));
        }

        private void getLastPost()
        {
            Post myLastPosts = FacebookApplication.LoggedInUser.Posts[0];

            textBoxLastPostMessage.Invoke(new Action(() =>
            {
                textBoxLastPostMessage.Text = (myLastPosts != null && myLastPosts.Message != null) ?
                    myLastPosts.Message : "[No post message]";
            }));
            if (myLastPosts != null && myLastPosts.PictureURL != null)
            {
                pictureBoxLastPost.Load(myLastPosts.PictureURL);
                listBoxPostLiked.DisplayMember = "Name";
                foreach (User friendWhoLiked in myLastPosts.LikedBy)
                {
                    listBoxPostLiked.Invoke(new Action(() => listBoxPostLiked.Items.Add(friendWhoLiked)));
                }

                listBoxPostComment.DisplayMember = "Message";
                foreach (Comment comment in myLastPosts.Comments)
                {
                    listBoxPostComment.Invoke(new Action(() => listBoxPostComment.Items.Add(comment)));
                }
            }
        }

        private void ListBoxPostLiked_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            User friend = ((ListBox)sender).SelectedItem as User;

            if (friend != null)
            {
                MessageBox.Show(friend.Name + " Liked your post!");
            }
        }

        private void ListBoxPostComment_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            expandPostComment(((ListBox)sender).SelectedItem as Comment);
        }

        private void expandPostComment(Comment i_Comment)
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

        private void FriendProfile_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBoxSelected = sender as PictureBox;

            if (pictureBoxSelected != null)
            {
                increasePictureBoxSize(pictureBoxSelected, k_PictureBoxIncreaseSizeOnMouseHover);
            }
        }

        private void FriendProfile_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBoxSelected = sender as PictureBox;

            if (pictureBoxSelected != null)
            {
                increasePictureBoxSize(pictureBoxSelected, -k_PictureBoxIncreaseSizeOnMouseHover);
            }
        }

        private void FriendProfile_MouseClick(object sender, MouseEventArgs e)
        {
            displayFriendDetailsInAboutMeTab(sender as PictureBox);
        }

        private void displayFriendDetailsInAboutMeTab(PictureBox i_PictureBoxSelected)
        {
            if (i_PictureBoxSelected != null)
            {
                User friendSelected = i_PictureBoxSelected.Tag as User;

                if (friendSelected != null)
                {
                    FriendDetails friendDetails = new FriendDetails(friendSelected);

                    friendDetails.ShowDialog();
                }
            }
        }

        private void buttonRefreshFriends_Click(object sender, EventArgs e)
        {
            FacebookApplication.LoggedInUser.ReFetch();
            flowLayoutPanelAboutMeFriends.Controls.Clear();
            updateAboutMeFriends();
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
            FacebookObjectCollection<Page> list = new FacebookCollectionAdapter<Page>(FacebookApplication.LoggedInUser.LikedPages)
                .FetchDataWithProgressBar();

            likedPagesBindingSource.DataSource = list;
            listBoxLikedPage.ClearSelected();
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
                    refreshLastPost();
                }
                else
                {
                    MessageBox.Show("You mush enter a status text");
                }
            }
            catch
            {
                MessageBox.Show("Error posting status");
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

        private void buttonRefreshTagFriends_Click(object sender, EventArgs e)
        {
            FacebookApplication.LoggedInUser.ReFetch();
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

                    MessageBox.Show("The photo was succesfully posted!");
                    richTextBoxPostPhoto.Clear();
                    refreshLastPost();
                }
                else
                {
                    MessageBox.Show("You mush add a photo");
                }
            }
            catch
            {
                MessageBox.Show("Error while trying to post the photo, try again");
            }
        }

        private void buttonRefreshLastPost_Click(object sender, EventArgs e)
        {
            refreshLastPost();
        }

        private void refreshLastPost()
        {
            FacebookApplication.LoggedInUser.ReFetch();
            initLastPost();
        }

        private void pictureBoxLastPost_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Photo photo = ((PictureBox)sender).Tag as Photo;

            if (photo != null)
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
                m_DataTableBindedToView.DataTable.Rows.Clear();
                if (m_DataTableBindedToView is FacebookPhotosDataTable)
                {
                    AlbumsSelector albumSelector = new AlbumsSelector(FacebookApplication.LoggedInUser);
                    Album[] albumsToLoad = albumSelector.GetAlbumsSelection();

                    ((FacebookPhotosDataTable)m_DataTableBindedToView).AlbumsToLoad = albumsToLoad;
                }

                FacebookDataFetcher.FetchDataWithProgressBar(m_DataTableBindedToView.FetchDataTableValues().GetEnumerator(), m_DataTableBindedToView.TableName);
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

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rowSelected = ((DataGridView)sender).SelectedCells[0].OwningRow;
            rowSelected.Selected = true;
            displayDetailsForRowObject(rowSelected);
        }

        private void displayDetailsForRowObject(DataGridViewRow i_RowSelected)
        {
            object selectedObject = i_RowSelected.Cells["ObjectDisplayed"].Value;
            m_DataTableBindedToView.ObjectToDisplay = selectedObject;
            m_DataTableBindedToView.DisplayObject();
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ((DataGridView)sender).SelectedCells[0].OwningRow.Selected = true;
        }

        private void buttonFetchData_Click(object sender, EventArgs e)
        {
            fetchDataForDataTablesTab();
        }

        // ================================================ Friendship analyzer Tab ==============================================
        private void initFriendshipAnalyzerTab()
        {
            m_FriendshipAnalyzer = new FriendshipAnalyzer();
            initFriendsPhotosBar();
        }

        private void initFriendsPhotosBar()
        {
            try
            {
                foreach (User friend in FacebookApplication.LoggedInUser.Friends)
                {
                    PictureBox friendshipAnalyzerFriendsDockPhoto = new PictureBox()
                    {
                        Image = friend.ImageLarge,
                        Size = sr_FriendProfilePicSize,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Tag = friend
                    };

                    friendshipAnalyzerFriendsDockPhoto.MouseEnter += friendshipAnalyzerFriendsDockPhoto_MouseEnter;
                    friendshipAnalyzerFriendsDockPhoto.MouseLeave += friendshipAnalyzerFriendsDockPhoto_MouseLeave;
                    friendshipAnalyzerFriendsDockPhoto.MouseClick += friendshipAnalyzerFriendsDockPhoto_MouseClick;
                    flowLayoutPanelFriendshipAnalyzer.Controls.Add(friendshipAnalyzerFriendsDockPhoto);
                }
            }
            catch
            {
                MessageBox.Show("Error getting list of friends");
            }
        }

        private void fetchPhotosTaggedTogether()
        {
            IEnumerator<Tuple<int, int, object>> i_ProgressOfFetchData = m_FriendshipAnalyzer.FetchPhotosTaggedTogether().GetEnumerator();
            List<Photo> taggedTogether = (List<Photo>)FacebookDataFetcher.FetchDataWithProgressBar(i_ProgressOfFetchData, "Photos tagged together");
            Dictionary<string, List<Photo>> photosGroupedByOwner = m_FriendshipAnalyzer.GroupPhotoListByOwner(taggedTogether);

            treeViewTaggedTogether.Nodes.Clear();
            foreach (KeyValuePair<string, List<Photo>> UserPhotos in photosGroupedByOwner)
            {
                TreeNode fromNode = new TreeNode(string.Format("Photos by {0}", UserPhotos.Value[0].From.Name));

                fromNode.Tag = UserPhotos.Value[0].From;
                foreach (Photo photo in UserPhotos.Value)
                {
                    TreeNode photoNode = new TreeNode(string.Format(
@"{0} - {1}",
photo.CreatedTime.ToString(),
string.IsNullOrEmpty(photo.Name) ? "[No Name]" : photo.Name));

                    photoNode.Tag = photo;
                    fromNode.Nodes.Add(photoNode);
                }

                treeViewTaggedTogether.Nodes.Add(fromNode);
            }
        }

        private void fetchPhotosOfFriendInMyPhotos()
        {
            AlbumsSelector albumSelector = new AlbumsSelector(FacebookApplication.LoggedInUser);
            Album[] selectedAlbums = albumSelector.GetAlbumsSelection();
            IEnumerator<Tuple<int, int, object>> progressOfFetchData = FacebookPhotoUtils.GetPhotosByOwnerAndTags(
                FacebookApplication.LoggedInUser, m_FriendshipAnalyzer.Friend, selectedAlbums).GetEnumerator();
            Dictionary<Album, List<Photo>> photos = (Dictionary<Album, List<Photo>>)
                FacebookDataFetcher.FetchDataWithProgressBar(progressOfFetchData, "photos");

            treeViewPhotosOfFriendInMyPhotos.Nodes.Clear();
            if (photos == null || photos.Count == 0)
            {
                MessageBox.Show("No photos found");
            }
            else
            {
                foreach (Album album in photos.Keys)
                {
                    TreeNode albumNode = new TreeNode(album.Name) { Tag = album };

                    foreach (Photo photo in photos[album])
                    {
                        string photoDescription = string.Format(
@"{0} - {1}",
photo.CreatedTime.ToString(),
string.IsNullOrEmpty(photo.Name) ? "[No Name]" : photo.Name);
                        TreeNode photoNode = new TreeNode(photoDescription) { Tag = photo };

                        albumNode.Nodes.Add(photoNode);
                    }

                    treeViewPhotosOfFriendInMyPhotos.Nodes.Add(albumNode);
                }
            }
        }

        private void fetchPhotosOfMeInFriendsPhotos()
        {
            AlbumsSelector albumSelector = new AlbumsSelector(m_FriendshipAnalyzer.Friend);
            Album[] selectedAlbums = albumSelector.GetAlbumsSelection();
            IEnumerator<Tuple<int, int, object>> progressOfFetchData = FacebookPhotoUtils.GetPhotosByOwnerAndTags(
                m_FriendshipAnalyzer.Friend, FacebookApplication.LoggedInUser, selectedAlbums).GetEnumerator();
            Dictionary<Album, List<Photo>> photos = (Dictionary<Album, List<Photo>>)
                FacebookDataFetcher.FetchDataWithProgressBar(progressOfFetchData, "photos by owner and tags");

            treeViewPhotosOfFriendIAmTaggedIn.Nodes.Clear();
            if (photos == null || photos.Count == 0)
            {
                MessageBox.Show("No photos found");
            }
            else
            {
                foreach (Album album in photos.Keys)
                {
                    TreeNode albumNode = new TreeNode(album.Name) { Tag = album };

                    foreach (Photo photo in photos[album])
                    {
                        string photoDescription = string.Format(
@"{0} - {1}",
photo.CreatedTime.ToString(),
string.IsNullOrEmpty(photo.Name) ? "[No Name]" : photo.Name);
                        TreeNode photoNode = new TreeNode(photoDescription) { Tag = photo };

                        albumNode.Nodes.Add(photoNode);
                    }

                    treeViewPhotosOfFriendIAmTaggedIn.Nodes.Add(albumNode);
                }
            }
        }

        private void treeViewPhotosOfFriendInMyPhotos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            photoTreeViewDoubleClicked(e.Node);
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

        private void treeViewTaggedTogether_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            photoTreeViewDoubleClicked(e.Node);
        }

        private void friendshipAnalyzerFriendsDockPhoto_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBoxSelected = sender as PictureBox;

            if (pictureBoxSelected != null)
            {
                increasePictureBoxSize(pictureBoxSelected, -k_PictureBoxIncreaseSizeOnMouseHover);
            }
        }

        private void friendshipAnalyzerFriendsDockPhoto_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBoxSelected = sender as PictureBox;

            if (pictureBoxSelected != null)
            {
                increasePictureBoxSize(pictureBoxSelected, k_PictureBoxIncreaseSizeOnMouseHover);
            }
        }

        private void friendshipAnalyzerFriendsDockPhoto_MouseClick(object sender, MouseEventArgs e)
        {
            User friend = ((PictureBox)sender).Tag as User;

            if (friend != null)
            {
                m_FriendshipAnalyzer.Friend = friend;
                friendSelectionChanged();
            }
        }

        private void friendSelectionChanged()
        {
            User selectedFriend = m_FriendshipAnalyzer.Friend;

            panelGeneralInfo.Visible = false;
            clearAllTreeViews();
            labelFirstName.Text = selectedFriend.FirstName;
            labelLastName.Text = selectedFriend.LastName;
            labelNumLikes.Text = string.Format("Number of times {0} liked my photos: {1}", selectedFriend.FirstName, "[no data fetched]");
            labelNumComments.Text = string.Format("Number of times {0} commented on my photos: {1}", selectedFriend.FirstName, "[no data fetched]");
            buttonFetchMyPhotosFriendIsIn.Text = string.Format("Fetch photos of mine {0} is in", selectedFriend.FirstName);
            buttonFetchPhotosOfFriendIAmTaggedIn.Text = string.Format("Fetch {0}'s Photos I am Tagged in", selectedFriend.FirstName);
            panelGeneralInfo.Visible = true;
        }

        private void clearAllTreeViews()
        {
            treeViewPhotosOfFriendIAmTaggedIn.Nodes.Clear();
            treeViewPhotosOfFriendInMyPhotos.Nodes.Clear();
            treeViewTaggedTogether.Nodes.Clear();
        }

        private void increasePictureBoxSize(PictureBox i_PictureBox, int i_Size)
        {
            int newWidth = i_PictureBox.Size.Width + i_Size;
            int newHeight = i_PictureBox.Size.Height + i_Size;

            i_PictureBox.Size = new Size(newWidth, newHeight);
        }

        private void buttonFetchPhotosOfFriendIAmTaggedIn_Click(object sender, EventArgs e)
        {
            fetchPhotosOfMeInFriendsPhotos();
        }

        private void buttonFetchTaggedTogether_Click(object sender, EventArgs e)
        {
            fetchPhotosTaggedTogether();
        }

        private void buttonFetchMyPhotosFriendIsIn_Click(object sender, EventArgs e)
        {
            fetchPhotosOfFriendInMyPhotos();
        }

        private void pictureBoxMostRecentTaggedTogether_MouseClick(object sender, MouseEventArgs e)
        {
            Photo photo = ((PictureBox)sender).Tag as Photo;

            if (photo != null)
            {
                PhotoDetails photoDetails = new PhotoDetails(photo);

                photoDetails.Show();
            }
        }

        private void treeViewPhotosOfFriendIAmTaggedIn_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            photoTreeViewDoubleClicked(e.Node);
        }

        private void pictureBoxMostRecentTaggedTogether_MouseHover(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                increasePictureBoxSize(sender as PictureBox, k_PictureBoxIncreaseSizeOnMouseHover);
            }
        }

        private void pictureBoxMostRecentTaggedTogether_MouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                increasePictureBoxSize(sender as PictureBox, -k_PictureBoxIncreaseSizeOnMouseHover);
            }
        }

        private void buttonFetchGeneralData_Click(object sender, EventArgs e)
        {
            friendshipAnalyzerFetchGeneralData();
        }

        private void friendshipAnalyzerFetchGeneralData()
        {
            IEnumerator<Tuple<int, int, object>> progressOfFetchData;
            int numPhotosFriendLiked, numOfPhotosFriendCommented;

            // count likes
            progressOfFetchData = m_FriendshipAnalyzer.GetNumberOfPhotosFriendLiked().GetEnumerator();
            numPhotosFriendLiked = (int)FacebookDataFetcher.FetchDataWithProgressBar(progressOfFetchData, "likes");
            labelNumLikes.Text = string.Format("Number of times {0} liked my photos: {1}", m_FriendshipAnalyzer.Friend.FirstName, numPhotosFriendLiked);
            // count comments
            progressOfFetchData = m_FriendshipAnalyzer.GetNumberOfPhotosFriendCommented().GetEnumerator();
            numOfPhotosFriendCommented = (int)FacebookDataFetcher.FetchDataWithProgressBar(progressOfFetchData, "comments");
            labelNumComments.Text = string.Format("Number of times {0} commented on my photos: {1}", m_FriendshipAnalyzer.Friend.FirstName, numOfPhotosFriendCommented);
            // get most recent tagged together
            progressOfFetchData = m_FriendshipAnalyzer.FetchPhotosTaggedTogether().GetEnumerator();
            List<Photo> taggedTogether = (List<Photo>)FacebookDataFetcher.FetchDataWithProgressBar(progressOfFetchData, "photos tagged together");
            Photo mostRecentTaggedTogether = m_FriendshipAnalyzer.GetMostRecentPhotoTaggedTogether(taggedTogether);
            if (mostRecentTaggedTogether != null)
            {
                pictureBoxMostRecentTaggedTogether.LoadAsync(mostRecentTaggedTogether.PictureNormalURL);
                pictureBoxMostRecentTaggedTogether.Tag = mostRecentTaggedTogether;
            }
        }

        // ================================================ Other methods ==============================================
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_TabPageDataTablesInit == false && tabControl.SelectedTab == tabPageDataTables)
            {
                initDataTablesTab();
                m_TabPageDataTablesInit = true;
                // TODO del
                MessageBox.Show("2");
            }
            else if (m_TabPageFriendshipAnalyzer == false && tabControl.SelectedTab == tabPageFriendshipAnalyzer)
            {
                initFriendshipAnalyzerTab();
                m_TabPageFriendshipAnalyzer = true;
                // TODO del
                MessageBox.Show("3");
            }
        }

        private void tabPageDataTables_Click(object sender, EventArgs e)
        {

        }
    }
}
