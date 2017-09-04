/*
 * C17_Ex01: FacebookFriendsDataTable.cs
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
    public class FacebookFriendsDataTable : FacebookDataTable
    {
        internal FacebookFriendsDataTable()
            : base("Friends")
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

        private void populateRows(FacebookObjectCollection<FacebookObject> i_FriendsList)
        {
            try
            {
                TotalRows = FacebookApplication.LoggedInUser.Friends.Count;

                foreach (FacebookObject facebookObject in i_FriendsList)
                {
                    if (facebookObject is User friend)
                    {
                        DataTable.Rows.Add(
                            friend,
                            friend.FirstName,
                            friend.LastName,
                            friend.Gender != null ? friend.Gender.ToString() : string.Empty);
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

        protected override void InitColumns()
        {
            DataTable.Columns.Add("First Name", typeof(string));
            DataTable.Columns.Add("Last Name", typeof(string));
            DataTable.Columns.Add("Gender", typeof(string));
        }
    }
}