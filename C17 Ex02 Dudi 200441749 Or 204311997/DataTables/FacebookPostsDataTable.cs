using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    using System.Windows.Forms;

    class FacebookPostsDataTable : FacebookDataTable
    {
        public FacebookPostsDataTable()
            : base("Posts", typeof(Post))
        {
        }

        public override void PopulateRows(FacebookObjectCollection<FacebookObject> i_Collection)
        {
            lock (this.r_PopulateRowsLock)
            {
                if (DataTable.Rows.Count == 0)
                {
                    FacebookApplication.StartThread(() => populateRows(i_Collection));
                }
            }
        }

        private void populateRows(FacebookObjectCollection<FacebookObject> i_Posts)
        {
            lock (this.r_PopulateRowsLock)
            {
                try
                {
                    TotalRows = FacebookApplication.LoggedInUser.Posts.Count;

                    foreach (FacebookObject facebookObject in i_Posts)
                    {
                        if (facebookObject is Post post)
                        {
                            DataTable.Rows.Add(
                                post,
                                string.IsNullOrEmpty(post.Message) ? "[No Message]" : post.Message,
                                post.CreatedTime,
                                post.LikedBy.Count,
                                post.Comments.Count);
                        }

                        if (this.r_NotifyAbstractParentPopulateRowsCompleted != null)
                        {
                            this.r_NotifyAbstractParentPopulateRowsCompleted.Invoke();
                        }
                    }
                }
                catch (Exception e)
                {
                    if (!(e.InnerException is ThreadAbortException) && !(e is ThreadAbortException))
                    {
                        throw new PopulateRowsException(this, e);
                    }
                }
            }
        }

        protected override void InitColumns()
        {
            DataTable.Columns.Add("Message", typeof(string));
            DataTable.Columns.Add("Time Updated", typeof(DateTime));
            DataTable.Columns.Add("Num Likes", typeof(int));
            DataTable.Columns.Add("Num Comments", typeof(int));
        }
    }
}
