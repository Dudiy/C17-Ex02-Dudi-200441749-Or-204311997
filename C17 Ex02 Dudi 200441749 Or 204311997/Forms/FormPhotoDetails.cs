/*
 * C17_Ex01: FormPhotoDetails.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    public partial class FormPhotoDetails : Form
    {
        private readonly Photo r_Photo;
        private Thread m_LikesCounterThread;
        private Thread m_CommentsCounterThread;

        public FormPhotoDetails(Photo i_Photo)
        {
            this.InitializeComponent();
            this.r_Photo = i_Photo;
            this.initDetailsPane();
            this.pictureBox.LoadAsync(this.r_Photo.PictureNormalURL);
        }

        protected override void OnShown(EventArgs i_Args)
        {
            base.OnShown(i_Args);
            this.m_LikesCounterThread = FacebookApplication.StartThread(this.initLikes);
            this.m_CommentsCounterThread = FacebookApplication.StartThread(this.initComments);
        }

        private void initDetailsPane()
        {
            this.labelName.Text = string.Format(
@"
Name: 
{0}",
this.r_Photo.Name ?? "No photo name");
            this.labelAlbum.Text = string.Format(
@"
Album: 
{0}",
this.r_Photo.Album != null ? this.r_Photo.Album.Name : "No Album Name");
            this.labelLikes.Text = string.Format(
@"
Likes ({0}):",
this.r_Photo.LikedBy.Count);
        }

        protected override void OnClosing(CancelEventArgs i_Args)
        {
            this.m_LikesCounterThread.Abort();
            this.m_CommentsCounterThread.Abort();
        }

        private void initLikes()
        {
            this.listBoxLikes.Invoke(
                new Action(() =>
                        {
                            this.listBoxLikes.DisplayMember = "Name";
                            foreach (User liker in this.r_Photo.LikedBy)
                            {
                                this.listBoxLikes.Items.Add(liker);
                            }
                        }));
        }

        private void initComments()
        {
            try
            {
                foreach (Comment comment in this.r_Photo.Comments)
                {
                    TreeNode node =
                        new TreeNode(comment.From.Name + ": " + comment.Message + " (" + comment.LikedBy.Count.ToString() + " Likes)")
                        {
                            Tag = comment
                        };

                    foreach (Comment innerComment in comment.Comments)
                    {
                        TreeNode child =
                            new TreeNode(innerComment.From.Name + ": " + innerComment.Message + " (" + innerComment.LikedBy.Count.ToString() + " Likes)")
                            {
                                Tag = innerComment
                            };
                        node.Nodes.Add(child);
                    }

                    this.addCommentToView(node);
                }
            }
            catch (Exception e)
            {
                if (!(e is WebExceptionWrapper || e is ThreadAbortException))
                {
                    MessageBox.Show(string.Format("Error while loading comments: {0}", e.Message));
                }
            }
        }

        private void addCommentToView(TreeNode i_Comment)
        {
            int totalComments = this.r_Photo.Comments.Count;
            int currentCounter = this.treeViewComments.Nodes.Count;

            if (!this.IsDisposed)
            {
                this.treeViewComments.Invoke(new Action(
                    () =>
                        {
                            this.treeViewComments.Nodes.Add(i_Comment);
                            this.toolStripLabelCommentsProgress.Text = totalComments == currentCounter ?
                                "All comments loaded" :
                                string.Format(
                                @"Loaded {0}/{1} comments",
                                this.treeViewComments.Nodes.Count,
                                this.r_Photo.Comments.Count);
                        }));
            }
        }

        private void listBoxLikes_MouseDoubleClick(object i_Sender, MouseEventArgs i_Args)
        {
            if (this.listBoxLikes.SelectedItem is User selectedUser)
            {
                FormPictureFrame profilePic = new FormPictureFrame(selectedUser.PictureLargeURL);
                profilePic.Show();
            }
        }
    }
}
