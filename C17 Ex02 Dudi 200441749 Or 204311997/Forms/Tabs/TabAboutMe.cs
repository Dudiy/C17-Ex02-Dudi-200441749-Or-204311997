using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using C17_Ex01_Dudi_200441749_Or_204311997.Adapter;
using C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms.Tabs
{
    using System.Diagnostics.CodeAnalysis;

    public partial class TabAboutMe : UserControl
    {
        private const bool k_UseCollectionAdapter = true;
        private readonly object r_UpdateLikedPagesLock = new object();
        private readonly object r_InitLastPostLock = new object();
        private string m_PostPicturePath;

        public TabAboutMe()
        {
            this.InitializeComponent();
        }

        public void InitializeTab()
        {
            // fetch and bind data from Facebook server
            try
            {
                this.flowLayoutPanelExtenderForFacebookFriends.Update(this.friendProfile_MouseClick);
                FacebookApplication.StartThread(() => this.updateLikedPages(!k_UseCollectionAdapter));
                FacebookApplication.StartThread(this.updateMostRecentPost);
                FacebookApplication.StartThread(this.initFriendsListForNewPostTags);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error while fetching data from the Facebook server: {0}", ex.Message));
            }
        }

        private void updateLikedPages(bool i_UseCollectionAdapter)
        {
            lock (this.r_UpdateLikedPagesLock)
            {
                try
                {
                    FacebookObjectCollection<Page> likedPages;

                    if (i_UseCollectionAdapter)
                    {
                        IFacebookCollection<Page> collection = new FacebookCollectionAdapter<Page>(eFacebookCollectionType.LikedPages);
                        FacebookObjectCollection<FacebookObject> likedPagesFromAdapter = collection.FetchDataWithProgressBar();
                        likedPages = collection.UnboxCollection(likedPagesFromAdapter);
                    }
                    else
                    {
                        likedPages = FacebookApplication.LoggedInUser.LikedPages;
                    }

                    this.listBoxLikedPage.Invoke(new Action(() =>
                    {
                        this.likedPagesBindingSource.DataSource = likedPages;
                        this.listBoxLikedPage.ClearSelected();
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
            lock (this.r_InitLastPostLock)
            {
                if (FacebookApplication.LoggedInUser != null)
                {
                    try
                    {
                        this.panelLastPost.Invoke(new Action(() => this.setLastPostControls(null)));
                        FacebookApplication.LoggedInUser.ReFetch("posts");
                        if (FacebookApplication.LoggedInUser.Posts.Count != 0)
                        {
                            this.panelLastPost.Invoke(new Action(() => this.setLastPostControls(FacebookApplication.LoggedInUser.Posts[0])));
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
                this.textBoxLastPostMessage.Text = i_Post.Message ?? "[No post message]";
                // posted photo
                if (!string.IsNullOrEmpty(i_Post.PictureURL))
                {
                    this.pictureBoxLastPost.LoadAsync(i_Post.PictureURL);
                }

                // people who liked the post
                this.listBoxPostLiked.DisplayMember = "Name";
                foreach (User friendWhoLiked in i_Post.LikedBy)
                {
                    this.listBoxPostLiked.Items.Add(friendWhoLiked);
                }

                // post comments
                foreach (Comment comment in i_Post.Comments)
                {
                    this.listBoxPostComment.Items.Add(new FacebookCommentProxy() { Comment = comment });
                }
            }
            else
            {
                this.clearLastPostControls();
            }
        }

        private void clearLastPostControls()
        {
            this.textBoxLastPostMessage.Text = "Fetching....";
            this.listBoxPostLiked.Items.Clear();
            this.listBoxPostComment.Items.Clear();
            this.pictureBoxLastPost.Image = null;
        }

        private void initFriendsListForNewPostTags()
        {
            FacebookObjectCollection<User> friends = FacebookApplication.LoggedInUser.Friends;

            this.listBoxPostTags.Invoke(new Action(() =>
            {
                this.friendsBindingSource.DataSource = friends;
                this.listBoxPostTags.ClearSelected();
            }));
        }

        private void friendProfile_MouseClick(object i_Sender, MouseEventArgs i_Args)
        {
            this.displayFriendDetailsInAboutMeTab(i_Sender as PictureBox);
        }

        private void displayFriendDetailsInAboutMeTab(PictureBox i_PictureBoxSelected)
        {
            if (i_PictureBoxSelected != null && i_PictureBoxSelected.Tag is User friendSelected)
            {
                new FormFriendDetails(friendSelected).ShowDialog();
            }
        }

        private void buttonRefreshFriends_Click(object i_Sender, EventArgs i_Args)
        {
            this.flowLayoutPanelExtenderForFacebookFriends.Update(this.friendProfile_MouseClick);
        }

        private void buttonRefreshLikedPage_Click(object i_Sender, EventArgs i_Args)
        {
            FacebookApplication.StartThread(() => this.updateLikedPages(k_UseCollectionAdapter));
        }

        private void buttonPost_Click(object i_Sender, EventArgs i_Args)
        {
            this.postStatus();
        }

        private void postStatus()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBoxStatusPost.Text))
                {
                    string friendId = this.createFriendsToTagStr();
                    Status postedStatus = FacebookApplication.LoggedInUser.PostStatus(this.richTextBoxStatusPost.Text, i_TaggedFriendIDs: friendId);
                    string successPostMessage = string.Format("The Status: \"{0}\" was succefully posted!", postedStatus.Message);
                    MessageBox.Show(successPostMessage);
                    this.richTextBoxStatusPost.Clear();
                    this.listBoxPostTags.ClearSelected();
                    FacebookApplication.StartThread(this.updateMostRecentPost);
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
            StringBuilder friendIdStringBuilder = new StringBuilder();

            foreach (User friend in this.listBoxPostTags.SelectedItems)
            {
                friendIdStringBuilder.Append(friend.Id + ",");
            }

            string friendId = friendIdStringBuilder.ToString();

            return !string.IsNullOrEmpty(friendId) ? friendId.Remove(friendId.Length - 1) : null;
        }

        // maybe we should delete this button, friends aren't added so frequently
        private void buttonRefreshTagFriends_Click(object i_Sender, EventArgs i_Args)
        {
            FacebookApplication.LoggedInUser.ReFetch("friends");
            this.friendsBindingSource.DataSource = FacebookApplication.LoggedInUser.Friends;
            this.listBoxPostTags.ClearSelected();
        }

        private void buttonClearPostTags_Click(object i_Sender, EventArgs i_Args)
        {
            this.listBoxPostTags.ClearSelected();
        }

        private void buttonAddPicture_Click(object i_Sender, EventArgs i_Args)
        {
            this.openPhotoForPost();
        }

        private void openPhotoForPost()
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();

                if (file.ShowDialog() == DialogResult.OK)
                {
                    this.m_PostPicturePath = Path.GetFullPath(file.FileName);
                    this.pictureBoxPostPhoto.Image = Image.FromFile(file.FileName);
                }
            }
            catch
            {
                MessageBox.Show("Error while trying to open file, try again");
            }
        }

        private void buttonPostPhoto_Click(object i_Sender, EventArgs i_Args)
        {
            this.postPhoto();
        }

        private void postPhoto()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.m_PostPicturePath))
                {
                    FacebookApplication.LoggedInUser.PostPhoto(this.m_PostPicturePath, i_Title: this.richTextBoxPostPhoto.Text);

                    // TODO do we need to check if postedItem != null?
                    MessageBox.Show("The photo was successfully posted!");
                    this.richTextBoxPostPhoto.Clear();
                    FacebookApplication.StartThread(this.updateMostRecentPost);
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

        private void buttonRefreshLastPost_Click(object i_Sender, EventArgs i_Args)
        {
            FacebookApplication.StartThread(this.updateMostRecentPost);
        }

        private void pictureBoxLastPost_MouseDoubleClick(object i_Sender, MouseEventArgs i_Args)
        {
            // TODO doesn't work because the tag is string, if we can pull the Photo from post update the tag and this will work
            if (((PictureBox)i_Sender).Tag is Photo photo)
            {
                FormPhotoDetails formPhotoDetails = new FormPhotoDetails(photo);
                formPhotoDetails.Show();
            }
        }
        
        private void linkLabelLikedPageURL_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_Args)
        {
            // Specify that the link was visited.
            this.linkLabelLikedPageURL.LinkVisited = true;
            // Navigate to a URL
            System.Diagnostics.Process.Start(this.linkLabelLikedPageURL.Tag.ToString());
        }

        private void listBoxPostComment_MouseDoubleClick(object i_Sender, MouseEventArgs i_Args)
        {
            if (((ListBox)i_Sender).SelectedItem is FacebookCommentProxy commentSelected)
            {
                MessageBox.Show(commentSelected.ToString());
            }
        }

        private void listBoxPostLiked_MouseDoubleClick(object i_Sender, MouseEventArgs i_Args)
        {
            if (((ListBox)i_Sender).SelectedItem is User friend)
            {
                MessageBox.Show(string.Format("{0} Liked your post!", friend.Name));
            }
        }
    }
}
