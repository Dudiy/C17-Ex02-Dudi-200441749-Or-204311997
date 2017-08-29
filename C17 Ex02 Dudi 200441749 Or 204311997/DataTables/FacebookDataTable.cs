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
        public Action PopulateRowsStarting;
        public Action TenRowsInserted;
        public Action PopulateRowsCompleted;
        public int TotalRows { get; protected set; }
        public DataTable DataTable { get; protected set; }
        public object ObjectToDisplay { get; set; }
        protected Type m_ObjectTypeRepresentedByRow;
        protected object m_PopulateRowsLock = new object();

        protected FacebookDataTable(string i_TableName, Type i_ObjectTypeRepresentedByRow)
        {
            m_ObjectTypeRepresentedByRow = i_ObjectTypeRepresentedByRow;
            DataTable = new DataTable(i_TableName);
            // all tables initialy have a column that holds the current row object displayed
            DataTable.Columns.Add("ObjectDisplayed", typeof(object));
            InitColumns();
        }

        public string TableName
        {
            get { return DataTable.TableName; }
        }

        // using yield, the user of this method can know the fetch progression status (numbers of fetched item, total items, return value)
        //public abstract IEnumerable<Tuple<int, int, object>> FetchDataTableValues();

        // adds all FacebookObjects of the given collection that are of type T to the data table rows
        public abstract void PopulateRows(FacebookObjectCollection<FacebookObject> i_Collection);

        protected abstract void InitColumns();
    }
}
