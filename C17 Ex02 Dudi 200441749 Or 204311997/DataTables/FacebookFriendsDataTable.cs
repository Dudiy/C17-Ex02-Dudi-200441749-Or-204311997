﻿/*
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
using System.Threading;
using System.Data;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    public class FacebookFriendsDataTable : FacebookDataTable
    {
        internal FacebookFriendsDataTable()
            : base("Friends", typeof(User))
        {
        }

        public override void PopulateRows(FacebookObjectCollection<FacebookObject> i_Collection)
        {
            TotalRows = FacebookApplication.LoggedInUser.Friends.Count;
            if (PopulateRowsStarting != null)
            {
                PopulateRowsStarting.Invoke();
            }

            lock (m_PopulateRowsLock)
            {
                if (DataTable.Rows.Count == 0)
                {
                    //FacebookObjectCollection<User> friendsList = new FacebookCollectionAdapter<User>(Adapter.eFacebookCollectionType.Friends).FetchDataWithProgressBar();
                    new Thread(() => populateRows(i_Collection)).Start();
                }

                PopulateRowsCompleted?.Invoke();
            }
        }

        private void populateRows(FacebookObjectCollection<FacebookObject> friendsList)
        {
            foreach (FacebookObject facebookObject in friendsList)
            {
                if (facebookObject is User friend)
                {
                    DataTable.Rows.Add(
                        friend,
                        friend.FirstName,
                        friend.LastName,
                        friend.Gender != null ? friend.Gender.ToString() : string.Empty);
                    //getMostRecentPost(friend));

                    if (TenRowsInserted != null && DataTable.Rows.Count % 10 == 0)
                    {
                        TenRowsInserted.Invoke();
                    }
                }
            }
        }

        protected override void InitColumns()
        {
            DataTable.Columns.Add("First Name", typeof(string));
            DataTable.Columns.Add("Last Name", typeof(string));
            DataTable.Columns.Add("Gender", typeof(string));
            //DataTable.Columns.Add("Most Recent Post", typeof(string));
        }

        private string getMostRecentPost(User i_User)
        {
            StringBuilder mostRecentPostStr = new StringBuilder();

            if (i_User != null && i_User.Posts[0] != null)
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
