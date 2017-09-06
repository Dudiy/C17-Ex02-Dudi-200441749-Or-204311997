using System;
using System.Threading;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    internal class FacebookPostsDataTable : FacebookDataTable
    {
        public FacebookPostsDataTable()
            : base("Posts")
        {
        }

        protected override void PopulateRowsImplementation(FacebookObjectCollection<FacebookObject> i_Posts)
        {
            lock (r_PopulateRowsLock)
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
                                post.From.Name,
                                string.IsNullOrEmpty(post.Message) ? "[No Message]" : post.Message,
                                post.CreatedTime,
                                post.LikedBy.Count,
                                post.Comments.Count);
                        }

                        if (NotifyAbstractParentPopulateRowsCompleted != null)
                        {
                            NotifyAbstractParentPopulateRowsCompleted.Invoke();
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
            DataTable.Columns.Add("Uploaded by", typeof(string));
            DataTable.Columns.Add("Message", typeof(string));
            DataTable.Columns.Add("Time Updated", typeof(DateTime));
            DataTable.Columns.Add("Num Likes", typeof(int));
            DataTable.Columns.Add("Num Comments", typeof(int));
        }
    }
}
