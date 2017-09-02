/*
 * C17_Ex01: PhotoDetails.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    using System.ComponentModel;
    using System.Threading;

    using Facebook;

    public partial class PhotoDetails : Form
    {
        private const byte k_MinNumOfCommentsForProgressBar = 5;
        private Photo m_Photo;

        private Thread m_LikesCounterThread;

        private Thread m_CommentsCounterThread;

        public PhotoDetails(Photo i_Photo)
        {
            InitializeComponent();
            m_Photo = i_Photo;
            initDetailsPane();
            pictureBox.LoadAsync(m_Photo.PictureNormalURL);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            m_LikesCounterThread = FacebookApplication.StartThread(initLikes);
            m_CommentsCounterThread = FacebookApplication.StartThread(initComments);
        }

        private void initDetailsPane()
        {
            labelName.Text = string.Format(
@"
Name: 
{0}",
m_Photo.Name ?? "No photo name");
            labelAlbum.Text = string.Format(
@"
Album: 
{0}",
m_Photo.Album != null ? m_Photo.Album.Name : "No Album Name");
            labelLikes.Text = string.Format(
@"
Likes ({0}):",
m_Photo.LikedBy.Count);
        }

        protected override void OnClosing(CancelEventArgs e)
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
                            foreach (User liker in m_Photo.LikedBy)
                            {
                                listBoxLikes.Items.Add(liker);
                            }
                        }));
        }

        private void initComments()
        {
            try
            {
                foreach (Comment comment in m_Photo.Comments)
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
            int totalComments = m_Photo.Comments.Count;
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
                                m_Photo.Comments.Count);
                        }));
            }
        }

        private void listBoxLikes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            User selectedUser = listBoxLikes.SelectedItem as User;

            if (selectedUser != null)
            {
                PictureFrame profilePic = new PictureFrame(selectedUser.PictureLargeURL);
                profilePic.Show();
            }
        }
    }
}
