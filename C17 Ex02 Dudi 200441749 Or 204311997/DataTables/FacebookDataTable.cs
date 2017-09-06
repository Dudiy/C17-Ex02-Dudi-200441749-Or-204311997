/*
 * C17_Ex01: FacebookDataTable.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Data;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    public abstract class FacebookDataTable : IDisplayable
    {
        protected readonly object r_PopulateRowsLock = new object();

        private event Action PopulateRowsCompleted;

        protected readonly Action NotifyAbstractParentPopulateRowsCompleted;

        public int TotalRows { get; protected set; }

        public DataTable DataTable { get; }

        public object ObjectToDisplay { get; set; }

        protected FacebookDataTable(string i_TableName)
        {
            DataTable = new DataTable(i_TableName);
            // all tables initially have a column that holds the current row object displayed
            DataTable.Columns.Add("ObjectDisplayed", typeof(object));
            // only the abstract parent can invoke an event
            NotifyAbstractParentPopulateRowsCompleted += () =>
                {
                    if (PopulateRowsCompleted != null)
                    {
                        PopulateRowsCompleted.Invoke();
                    }
                };
            InitColumns();
        }

        public string TableName
        {
            get { return DataTable.TableName; }
        }

        // adds all FacebookObjects of the given collection that are of type T to the data table rows
        public virtual void PopulateRows(FacebookObjectCollection<FacebookObject> i_Collection)
        {
            lock (r_PopulateRowsLock)
            {
                if (DataTable.Rows.Count == 0)
                {
                    FacebookApplication.StartThread(() => PopulateRowsImplementation(i_Collection));
                }
            }
        }

        protected abstract void PopulateRowsImplementation(FacebookObjectCollection<FacebookObject> i_Collection);

        protected abstract void InitColumns();
    }
}
