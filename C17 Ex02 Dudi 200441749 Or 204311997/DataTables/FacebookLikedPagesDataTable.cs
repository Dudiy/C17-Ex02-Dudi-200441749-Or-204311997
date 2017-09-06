/*
 * C17_Ex01: FacebookLikedPagesDataTable.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Threading;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    public class FacebookLikedPagesDataTable : FacebookDataTable
    {
        internal FacebookLikedPagesDataTable()
            : base("Liked Pages")
        {
        }

        protected override void PopulateRowsImplementation(FacebookObjectCollection<FacebookObject> i_LikedPages)
        {
            try
            {
                TotalRows = FacebookApplication.LoggedInUser.LikedPages.Count;

                foreach (FacebookObject facebookObject in i_LikedPages)
                {
                    if (facebookObject is Page page)
                    {
                        DataTable.Rows.Add(
                            page,
                            page.Name,
                            page.Phone,
                            page.Category,
                            page.Description,
                            page.Website);
                    }
                }

                if (NotifyAbstractParentPopulateRowsCompleted != null)
                {
                    NotifyAbstractParentPopulateRowsCompleted.Invoke();
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

        protected override void InitColumns()
        {
            DataTable.Columns.Add("Name", typeof(string));
            DataTable.Columns.Add("Phone Number", typeof(string));
            DataTable.Columns.Add("Category", typeof(string));
            DataTable.Columns.Add("Description", typeof(string));
            DataTable.Columns.Add("Website", typeof(string));
        }
    }
}
