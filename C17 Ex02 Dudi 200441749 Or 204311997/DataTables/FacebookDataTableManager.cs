/*
 * C17_Ex01: FacebookDataTableManager.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System.Collections.Generic;
using C17_Ex01_Dudi_200441749_Or_204311997.DataTables;
using System;
using FacebookWrapper.ObjectModel;
using System.Threading;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public class FacebookDataTableManager
    {
        private List<FacebookDataTable> m_DataTables = new List<FacebookDataTable>();

        public FacebookDataTableManager()
        {
            foreach (eFacebookDataTableType tableType in Enum.GetValues(typeof(eFacebookDataTableType)))
            {
                m_DataTables.Add(FacebookDataTableFactory.CreateTable(tableType));
            }
        }

        public FacebookDataTable[] GetDataTables()
        {
            return m_DataTables.ToArray();
        }
    }
}
