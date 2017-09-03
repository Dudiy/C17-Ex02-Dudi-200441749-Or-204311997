/*
 * C17_Ex01: FacebookDataTable.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Data;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    using System.Threading;

    public abstract class FacebookDataTable : IDisplayable
    {
        private event Action PopulateRowsCompleted;
        protected Action NotifyAbstractParent_PopulateRowsCompleted;
        protected object m_PopulateRowsLock = new object();
        protected Type m_ObjectTypeRepresentedByRow;
        public int TotalRows { get; protected set; }
        public DataTable DataTable { get; protected set; }
        public object ObjectToDisplay { get; set; }

        protected FacebookDataTable(string i_TableName, Type i_ObjectTypeRepresentedByRow)
        {
            m_ObjectTypeRepresentedByRow = i_ObjectTypeRepresentedByRow;
            DataTable = new DataTable(i_TableName);
            // all tables initially have a column that holds the current row object displayed
            DataTable.Columns.Add("ObjectDisplayed", typeof(object));
            // only the abstract parent can invoke an event
            NotifyAbstractParent_PopulateRowsCompleted += () =>
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
        public abstract void PopulateRows(FacebookObjectCollection<FacebookObject> i_Collection);

        protected abstract void InitColumns();
    }
}
