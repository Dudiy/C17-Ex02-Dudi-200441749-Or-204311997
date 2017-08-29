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
            lock (m_PopulateRowsLock)
            {
                if (DataTable.Rows.Count == 0)
                {
                    //FacebookObjectCollection<Page> likedPages = new FacebookCollectionAdapter<Page>(Adapter.eFacebookCollectionType.LikedPages).FetchDataWithProgressBar();
                    new Thread(() => populateRows(i_Collection)).Start();
                }
            }
        }

        private void populateRows(FacebookObjectCollection<FacebookObject> likedPages)
        {
            TotalRows = FacebookApplication.LoggedInUser.LikedPages.Count;
            if (PopulateRowsStarting != null)
            {
                PopulateRowsStarting.Invoke();
            }

            lock (m_PopulateRowsLock)
            {
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
                        if (TenRowsInserted != null && DataTable.Rows.Count % 10 == 0)
                        {
                            TenRowsInserted.Invoke();
                        }
                    }
                }

                if (PopulateRowsCompleted != null)
                {
                    PopulateRowsCompleted.Invoke();
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
