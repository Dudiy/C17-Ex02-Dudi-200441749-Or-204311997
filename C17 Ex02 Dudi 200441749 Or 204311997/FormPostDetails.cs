using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    using C17_Ex01_Dudi_200441749_Or_204311997.Properties;

    public partial class FormPostDetails : Form
    {
        private Thread m_InitNonBindedComponentsThread;
        public Post Post { get; set; }

        public FormPostDetails()
        {
            InitializeComponent();
            postsBindingSource.DataSource = Post;
        }

        private void initNonBindedComponents()
        {
            try
            {
                if (!string.IsNullOrEmpty(Post.PictureURL))
                {
                    try
                    {
                        pictureBoxPhoto.Load(Post.PictureURL);
                    }
                    catch (Exception e)
                    {
                        Invoke(new Action(() => MessageBox.Show(ActiveForm, "The PictureURL of this post is not supported")));
                    }
                }

                foreach (Comment postComment in Post.Comments)
                {
                    listBoxComments.Invoke(new Action(() => listBoxComments.Items.Add(new FacebookCommentProxy() { Comment = postComment })));
                }

                labelLikes.Invoke(new Action(() => labelLikes.Text = string.Format("Likes ({0}): ", Post.LikedBy.Count)));
            }
            catch (Exception e)
            {
                if (!(e.InnerException is ThreadAbortException) && !(e is ThreadAbortException))
                {
                    MessageBox.Show(string.Format("Exception while loading comments: {0}", e.Message));
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            FacebookApplication.StartThread(initNonBindedComponents);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (m_InitNonBindedComponentsThread != null && m_InitNonBindedComponentsThread.IsAlive)
            {
                m_InitNonBindedComponentsThread.Abort();
            }
        }

        public FormPostDetails(Post i_Post)
        {
            InitializeComponent();
            Post = i_Post;
            postsBindingSource.DataSource = i_Post;
        }
    }
}
