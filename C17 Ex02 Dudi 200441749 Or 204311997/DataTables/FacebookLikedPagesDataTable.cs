/*
 * C17_Ex01: FacebookLikedPagesDataTable.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using System.Threading;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    using System.Windows.Forms;

    using Timer = System.Threading.Timer;

    public class FacebookLikedPagesDataTable : FacebookDataTable
    {
        internal FacebookLikedPagesDataTable()
            : base("Liked Pages", typeof(Page))
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

        private void populateRows(FacebookObjectCollection<FacebookObject> likedPages)
        {
            try
            {
                TotalRows = FacebookApplication.LoggedInUser.LikedPages.Count;

                foreach (FacebookObject facebookObject in likedPages)
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

                if (this.r_NotifyAbstractParentPopulateRowsCompleted != null)
                {
                    this.r_NotifyAbstractParentPopulateRowsCompleted.Invoke();
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
