using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class FormPostDetails : Form
    {
        private readonly Post r_Post;
        private Thread m_InitNonBindedComponentsThread;

        public FormPostDetails()
        {
            InitializeComponent();
            postsBindingSource.DataSource = r_Post;
        }

        private void initNonBindedComponents()
        {
            try
            {
                if (!string.IsNullOrEmpty(r_Post.PictureURL))
                {
                    try
                    {
                        pictureBoxPhoto.Load(r_Post.PictureURL);
                    }
                    catch
                    {
                        Invoke(new Action(() => MessageBox.Show(ActiveForm, "The PictureURL of this post is not supported")));
                    }
                }

                foreach (Comment postComment in this.r_Post.Comments)
                {
                    listBoxComments.Invoke(new Action(() => listBoxComments.Items.Add(new FacebookCommentProxy() { Comment = postComment })));
                }

                labelLikes.Invoke(new Action(() => labelLikes.Text = string.Format("Likes ({0}): ", this.r_Post.LikedBy.Count)));
            }
            catch (Exception e)
            {
                if (!(e.InnerException is ThreadAbortException) && !(e is ThreadAbortException))
                {
                    MessageBox.Show(string.Format("Exception while loading comments: {0}", e.Message));
                }
            }
        }

        protected override void OnShown(EventArgs i_Args)
        {
            base.OnShown(i_Args);
            m_InitNonBindedComponentsThread = FacebookApplication.StartThread(initNonBindedComponents);
        }

        protected override void OnClosing(CancelEventArgs i_Args)
        {
            base.OnClosing(i_Args);
            if (m_InitNonBindedComponentsThread != null && m_InitNonBindedComponentsThread.IsAlive)
            {
                m_InitNonBindedComponentsThread.Abort();
            }
        }

        public FormPostDetails(Post i_Post)
        {
            InitializeComponent();
            r_Post = i_Post;
            postsBindingSource.DataSource = i_Post;
        }
    }
}
