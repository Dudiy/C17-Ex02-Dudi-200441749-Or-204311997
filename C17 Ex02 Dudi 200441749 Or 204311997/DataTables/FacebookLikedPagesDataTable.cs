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

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    public class FacebookLikedPagesDataTable : FacebookDataTable
    {
        internal FacebookLikedPagesDataTable()
            : base("Liked Pages", typeof(Page))
        {
        }

        public override IEnumerable<Tuple<int, int, object>> FetchDataTableValues()
        {
            int currRow = 0;

            TotalRows = FacebookApplication.LoggedInUser.LikedPages.Count;
            //add rows
            foreach (Page page in FacebookApplication.LoggedInUser.LikedPages)
            {
                yield return Tuple.Create<int, int, object>(++currRow, TotalRows, null);

                DataTable.Rows.Add(
                    page,
                    page.Name,
                    page.Phone,
                    page.Category,
                    page.Description,
                    page.Website);
            }

            // if the user has no liked pages
            yield return Tuple.Create<int, int, object>(1, 1, null);
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
