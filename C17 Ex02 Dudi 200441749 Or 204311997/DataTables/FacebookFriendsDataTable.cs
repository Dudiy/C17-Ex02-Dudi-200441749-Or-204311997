/*
 * C17_Ex01: FacebookFriendsDataTable.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    public class FacebookFriendsDataTable : FacebookDataTable
    {
        public FacebookFriendsDataTable()
            : base("Friends", typeof(User))
        {
        }

        public override IEnumerable<Tuple<int, int, object>> FetchDataTableValues()
        {
            int currRow = 0;

            TotalRows = FacebookApplication.LoggedInUser.Friends.Count;
            //add rows
            foreach (User friend in FacebookApplication.LoggedInUser.Friends)
            {
                yield return Tuple.Create<int, int, object>(++currRow, TotalRows, null);

                DataTable.Rows.Add(
                    friend,
                    friend.FirstName,
                    friend.LastName,
                    friend.Gender != null ? friend.Gender.ToString() : string.Empty,
                    getMostRecentPost(friend));
            }

            // if the user has no friends :(
            yield return Tuple.Create<int, int, object>(1, 1, null);
        }

        protected override void InitColumns()
        {
            DataTable.Columns.Add("First Name", typeof(string));
            DataTable.Columns.Add("Last Name", typeof(string));
            DataTable.Columns.Add("Gender", typeof(string));
            DataTable.Columns.Add("Most Recent Post", typeof(string));
        }

        private string getMostRecentPost(User i_User)
        {
            StringBuilder mostRecentPostStr = new StringBuilder();

            if (i_User != null && i_User.Posts.Count > 0)
            {
                Post mostRecentPost = i_User.Posts[0];

                mostRecentPostStr.Append(mostRecentPost.CreatedTime);
                if (!string.IsNullOrEmpty(mostRecentPost.Message))
                {
                    mostRecentPostStr.Append(string.Format(" - {0}", mostRecentPost.Message));
                }
            }

            return mostRecentPostStr.ToString();
        }
    }
}
