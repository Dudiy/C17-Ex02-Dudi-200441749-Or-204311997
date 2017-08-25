/*
 * C17_Ex01: FacebookDataTableManager.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System.Collections.Generic;
using C17_Ex01_Dudi_200441749_Or_204311997.DataTables;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public class FacebookDataTableManager
    {
        private List<FacebookDataTable> m_DataTables = new List<FacebookDataTable>();

        public FacebookDataTableManager()
        {
            m_DataTables.Add(new FacebookFriendsDataTable());
            m_DataTables.Add(new FacebookLikedPagesDataTable());
            m_DataTables.Add(new FacebookPhotosDataTable());
        }

        public FacebookDataTable[] GetDataTables()
        {
            return m_DataTables.ToArray();
        }
    }
}
