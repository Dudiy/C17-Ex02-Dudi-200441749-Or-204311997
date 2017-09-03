using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    internal static class FacebookDataTableFactory
    {
        public static FacebookDataTable CreateTable(eFacebookDataTableType tableType)
        {
            FacebookDataTable tableCreated = null;

            switch (tableType)
            {
                case eFacebookDataTableType.Friends:                    
                    tableCreated = new FacebookFriendsDataTable();
                    break;
                case eFacebookDataTableType.LikedPages:
                    tableCreated = new FacebookLikedPagesDataTable();
                    break;
                case eFacebookDataTableType.MyPhotos:
                    tableCreated = new FacebookPhotosDataTable();
                    break;
                case eFacebookDataTableType.MyPosts:
                    tableCreated = new FacebookPostsDataTable();
                    break;
                default:
                    break;
            }

            return tableCreated;
        }
    }
}
