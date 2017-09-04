/*
 * C17_Ex01: FormPhotoDetails.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using Facebook;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class FormPhotoDetails : Form
    {
        private readonly Photo r_Photo;

        private Thread m_LikesCounterThread;

        private Thread m_CommentsCounterThread;

        public FormPhotoDetails(Photo i_Photo)
        {
            InitializeComponent();
            r_Photo = i_Photo;
            initDetailsPane();
            pictureBox.LoadAsync(r_Photo.PictureNormalURL);
        }

        protected override void OnShown(EventArgs i_Args)
        {
            base.OnShown(i_Args);
            m_LikesCounterThread = FacebookApplication.StartThread(initLikes);
            m_CommentsCounterThread = FacebookApplication.StartThread(initComments);
        }

        private void initDetailsPane()
        {
            labelName.Text = string.Format(
@"
Name: 
{0}",
this.r_Photo.Name ?? "No photo name");
            labelAlbum.Text = string.Format(
@"
Album: 
{0}",
this.r_Photo.Album != null ? this.r_Photo.Album.Name : "No Album Name");
            labelLikes.Text = string.Format(
@"
Likes ({0}):",
this.r_Photo.LikedBy.Count);
        }

        protected override void OnClosing(CancelEventArgs i_Args)
        {
            m_LikesCounterThread.Abort();
            m_CommentsCounterThread.Abort();
        }

        private void initLikes()
        {
            listBoxLikes.Invoke(
                new Action(() =>
                        {
                            listBoxLikes.DisplayMember = "Name";
                            foreach (User liker in this.r_Photo.LikedBy)
                            {
                                listBoxLikes.Items.Add(liker);
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

                    addCommentToView(node);
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
            int currentCounter = treeViewComments.Nodes.Count;

            if (!IsDisposed)
            {
                treeViewComments.Invoke(new Action(
                    () =>
                        {
                            treeViewComments.Nodes.Add(i_Comment);
                            toolStripLabelCommentsProgress.Text = totalComments == currentCounter ?
                                "All comments loaded" :
                                string.Format(
                                @"Loaded {0}/{1} comments",
                                treeViewComments.Nodes.Count,
                                this.r_Photo.Comments.Count);
                        }));
            }
        }

        private void listBoxLikes_MouseDoubleClick(object i_Sender, MouseEventArgs i_Args)
        {
            User selectedUser = listBoxLikes.SelectedItem as User;

            if (selectedUser != null)
            {
                FormPictureFrame profilePic = new FormPictureFrame(selectedUser.PictureLargeURL);
                profilePic.Show();
            }
        }
    }
}
