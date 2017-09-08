/*
 * C17_Ex01: FormPostDetails.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    public partial class FormPostDetails : Form
    {
        private readonly Post r_Post;
        private Thread m_InitNonBindedComponentsThread;

        public FormPostDetails(Post i_Post)
        {
            this.InitializeComponent();
            this.r_Post = i_Post;
            this.postsBindingSource.DataSource = i_Post;
        }

        private void initNonBindedComponents()
        {
            try
            {   
                if (!string.IsNullOrEmpty(this.r_Post.PictureURL))
                {
                    try
                    {
                        this.pictureBoxPhoto.Load(this.r_Post.PictureURL);
                    }
                    catch
                    {
                        this.Invoke(new Action(() => MessageBox.Show(ActiveForm, "The PictureURL of this post is not supported")));
                    }
                }

                foreach (Comment postComment in this.r_Post.Comments)
                {
                    this.listBoxComments.Invoke(new Action(() => this.listBoxComments.Items.Add(new FacebookCommentProxy() { Comment = postComment })));
                }

                this.labelLikes.Invoke(new Action(() => this.labelLikes.Text = string.Format("Likes ({0}): ", this.r_Post.LikedBy.Count)));
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
            this.m_InitNonBindedComponentsThread = FacebookApplication.StartThread(this.initNonBindedComponents);
        }

        protected override void OnClosing(CancelEventArgs i_Args)
        {
            base.OnClosing(i_Args);
            if (this.m_InitNonBindedComponentsThread != null && this.m_InitNonBindedComponentsThread.IsAlive)
            {
                this.m_InitNonBindedComponentsThread.Abort();
            }
        }
    }
}
