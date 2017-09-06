using System;
using System.Threading;
using System.Windows.Forms;
using C17_Ex01_Dudi_200441749_Or_204311997.Adapter;
using C17_Ex01_Dudi_200441749_Or_204311997.Properties;
using C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms.Tabs
{
    public partial class TabFriendshipAnalyzer : UserControl
    {
        private FriendshipAnalyzer m_FriendshipAnalyzer;

        private Action FriendSelectionChanged;

        public TabFriendshipAnalyzer()
        {
            this.InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs i_Args)
        {
            base.OnHandleCreated(i_Args);
            this.initializeTab();
        }

        private void initializeTab()
        {
            this.FriendSelectionChanged += this.OnFriendSelectionChanged;
            this.setEventHandlers();
            this.m_FriendshipAnalyzer = new FriendshipAnalyzer();
            this.flowLayoutPanelExtenderForFacebookFriends.Update(this.friendshipAnalyzerFriendsDockPhoto_MouseClick);
        }

        protected virtual void OnFriendSelectionChanged()
        {
            User selectedFriend = this.m_FriendshipAnalyzer.Friend;

            panelGeneralInfo.Visible = false;
            clearAllTreeViews();
            listBoxPhotosCommentedOn.Items.Clear();
            pictureBoxMostRecentTaggedTogether.Image = Resources.Picture_not_found;
            pictureBoxMostRecentTaggedTogether.Tag = null;
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
            this.buttonFetchGeneralData.Enabled = false;
            FormProgressBar formProgressBar =
                new FormProgressBar(2 * this.m_FriendshipAnalyzer.AllPhotos.Count, "statistics") { CancelEnabled = true };

            formProgressBar.Show();
            this.getMostRecentPhotoTogether();
            Thread getLikesThread = FacebookApplication.StartThread(
                () => this.m_FriendshipAnalyzer.CountNumberOfPhotosFriendLiked(() => formProgressBar.ProgressValue++));
            Thread getCommentsThread = FacebookApplication.StartThread(
                () => this.m_FriendshipAnalyzer.CountNumberOfPhotosFriendCommented(() => formProgressBar.ProgressValue++));
            this.FriendSelectionChanged += () => formProgressBar.Close();
            formProgressBar.Closing += (i_Sender, i_Args) =>
            {
                this.FriendSelectionChanged -= () => formProgressBar.Close();
                if (formProgressBar.DialogResult == DialogResult.Cancel)
                {
                    getCommentsThread.Abort();
                    getLikesThread.Abort();
                }

                this.buttonFetchGeneralData.Enabled = true;
            };
            this.m_FriendshipAnalyzer.FinishedFetchingLikesAndComments += () =>
            {
                this.finishedFetchingLikesAndComments();
                formProgressBar.Close();
            };
        }

        private void finishedFetchingLikesAndComments()
        {
            if (!this.IsDisposed)
            {
                this.panelGeneralInfo.Invoke(
                    new Action(() =>
                    {
                        this.labelNumLikes.Text = string.Format(
"Number of times {0} liked my photos: {1}",
this.m_FriendshipAnalyzer.Friend.FirstName,
this.m_FriendshipAnalyzer.PhotosFriendLiked.Count);
                        this.labelNumComments.Text = string.Format(
"Number of times {0} commented on my photos: {1}",
this.m_FriendshipAnalyzer.Friend.FirstName,
this.m_FriendshipAnalyzer.CommentsByFriend.Count);
                        this.updateCommentsListBox();
                    }));
            }
        }

        private void fetchPhotosTaggedTogether()
        {
            IFacebookCollection<Photo> photosTaggedInAdapter = new FacebookCollectionAdapter<Photo>(eFacebookCollectionType.PhotosTaggedIn);
            FacebookObjectCollection<FacebookObject> boxPhotosTaggedIn = photosTaggedInAdapter.FetchDataWithProgressBar();
            FacebookObjectCollection<Photo> photosTaggedIn = photosTaggedInAdapter.UnboxCollection(boxPhotosTaggedIn);
            FacebookObjectCollection<Photo> photosTaggedTogether = this.m_FriendshipAnalyzer.PhotosTaggedTogether(photosTaggedIn);

            this.treeViewTaggedTogether.SetValues(photosTaggedTogether, TreeViewExtenderForFacebookPhotos.eGroupBy.Uploader);
        }

        private void fetchPhotosOfFriendInMyPhotos()
        {
            FacebookObjectCollection<Album> albums = this.fetchAlbums(FacebookApplication.LoggedInUser);
            FacebookObjectCollection<Photo> photosOfFriend = this.m_FriendshipAnalyzer.GetPhotosFromAlbumsUserIsTaggedIn(this.m_FriendshipAnalyzer.Friend, albums);

            this.treeViewPhotosOfFriendInMyPhotos.SetValues(photosOfFriend, TreeViewExtenderForFacebookPhotos.eGroupBy.Album);
        }

        private FacebookObjectCollection<Album> fetchAlbums(User i_User)
        {
            FormAlbumsSelector formAlbumSelector = new FormAlbumsSelector(i_User);
            Album[] selectedAlbums = formAlbumSelector.GetAlbumsSelection();
            IFacebookCollection<Album> albumsAdapter = new FacebookCollectionAdapter<Album>(eFacebookCollectionType.Albums)
            {
                AlbumsToLoad = selectedAlbums
            };
            FacebookObjectCollection<FacebookObject> boxAlbumsTaggedIn = albumsAdapter.FetchDataWithProgressBar();
            FacebookObjectCollection<Album> albums = albumsAdapter.UnboxCollection(boxAlbumsTaggedIn);

            return albums;
        }

        private void fetchPhotosOfMeInFriendsPhotos()
        {
            FacebookObjectCollection<Album> albums = this.fetchAlbums(this.m_FriendshipAnalyzer.Friend);
            FacebookObjectCollection<Photo> photos = this.m_FriendshipAnalyzer.GetPhotosFromAlbumsUserIsTaggedIn(FacebookApplication.LoggedInUser, albums);

            this.treeViewPhotosOfFriendIAmTaggedIn.SetValues(photos, TreeViewExtenderForFacebookPhotos.eGroupBy.Album);
        }

        private void setEventHandlers()
        {
            this.treeViewPhotosOfFriendInMyPhotos.NodeMouseDoubleClick += (i_Sender, i_Args) => this.photoTreeViewDoubleClicked(i_Args.Node);
            this.treeViewTaggedTogether.NodeMouseDoubleClick += (i_Sender, i_Args) => this.photoTreeViewDoubleClicked(i_Args.Node);
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Click += (i_Sender, i_Args) => this.fetchPhotosOfMeInFriendsPhotos();
            this.buttonFetchTaggedTogether.Click += (i_Sender, i_Args) => this.fetchPhotosTaggedTogether();
        }

        private void photoTreeViewDoubleClicked(TreeNode i_SelectedNode)
        {
            if (i_SelectedNode.Tag is User)
            {
                User selectedUser = i_SelectedNode.Tag as User;
                FormPictureFrame profile = new FormPictureFrame(selectedUser.PictureLargeURL, selectedUser.Name);
                profile.Show();
            }
            else if (i_SelectedNode.Tag is Photo)
            {
                Photo selectedPhoto = i_SelectedNode.Tag as Photo;
                FormPhotoDetails formPhotoDetails = new FormPhotoDetails(selectedPhoto);
                formPhotoDetails.Show();
            }
        }

        private void friendshipAnalyzerFriendsDockPhoto_MouseClick(object i_Sender, MouseEventArgs i_Args)
        {
            if (((PictureBox)i_Sender).Tag is User friend)
            {
                this.m_FriendshipAnalyzer.Friend = friend;
                if (this.FriendSelectionChanged != null)
                {
                    this.FriendSelectionChanged.Invoke();
                }
            }
        }

        private void clearAllTreeViews()
        {
            this.treeViewPhotosOfFriendIAmTaggedIn.Nodes.Clear();
            this.treeViewPhotosOfFriendInMyPhotos.Nodes.Clear();
            this.treeViewTaggedTogether.Nodes.Clear();
        }

        private void buttonFetchMyPhotosFriendIsIn_Click(object i_Sender, EventArgs i_Args)
        {
            this.fetchPhotosOfFriendInMyPhotos();
        }

        private void buttonFetchGeneralData_Click(object i_Sender, EventArgs i_Args)
        {
            this.friendshipAnalyzerFetchGeneralData();
        }

        private void getMostRecentPhotoTogether()
        {
            IFacebookCollection<Photo> photosTaggedInAdapter = new FacebookCollectionAdapter<Photo>(eFacebookCollectionType.PhotosTaggedIn);
            FacebookObjectCollection<FacebookObject> boxPhotosTaggedIn = photosTaggedInAdapter.FetchDataWithProgressBar();
            FacebookObjectCollection<Photo> photosTaggedIn = photosTaggedInAdapter.UnboxCollection(boxPhotosTaggedIn);
            FacebookObjectCollection<Photo> photosTaggedTogether = this.m_FriendshipAnalyzer.PhotosTaggedTogether(photosTaggedIn);
            Photo mostRecentTaggedTogether = this.m_FriendshipAnalyzer.GetMostRecentPhotoTaggedTogether(photosTaggedTogether);

            if (mostRecentTaggedTogether != null)
            {
                this.pictureBoxMostRecentTaggedTogether.LoadAsync(mostRecentTaggedTogether.PictureNormalURL);
                this.pictureBoxMostRecentTaggedTogether.Tag = mostRecentTaggedTogether;
            }
        }

        private void pictureBoxMostRecentTaggedTogether_Click(object i_Sender, EventArgs i_Args)
        {
            if (((PictureBox)i_Sender).Tag is Photo photo)
            {
                FormPhotoDetails formPhotoDetails = new FormPhotoDetails(photo);
                formPhotoDetails.Show();
            }
        }

        private void updateCommentsListBox()
        {
            this.listBoxPhotosCommentedOn.DisplayMember = "Message";
            this.listBoxPhotosCommentedOn.Items.Clear();
            foreach (Comment comment in this.m_FriendshipAnalyzer.CommentsByFriend.Keys)
            {
                this.listBoxPhotosCommentedOn.Items.Add(new FacebookCommentProxy() { Comment = comment });
            }
        }

        private void listBoxPhotosCommentedOn_MouseDoubleClick(object i_Sender, MouseEventArgs i_Args)
        {
            if (((ListBox)i_Sender).SelectedItem is FacebookCommentProxy selectedComment)
            {
                new FormPhotoDetails(this.m_FriendshipAnalyzer.CommentsByFriend[selectedComment.Comment]).Show();
            }
        }
    }
}
