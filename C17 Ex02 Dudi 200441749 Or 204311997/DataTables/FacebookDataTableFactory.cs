namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    using System;

    internal static class FacebookDataTableFactory
    {
        public static FacebookDataTable CreateTable(eFacebookDataTableType i_TableType)
        {
            FacebookDataTable tableCreated;

            switch (i_TableType)
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
                    throw new Exception("The given table type is not supported");
            }

            return tableCreated;
        }
    }
}
