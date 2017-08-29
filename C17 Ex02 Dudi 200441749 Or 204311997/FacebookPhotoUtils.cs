///*
// * C17_Ex01: FacebookPhotoUtils.cs
// * 
// * Written by:
// * 204311997 - Or Mantzur
// * 200441749 - Dudi Yecheskel 
//*/
//using System;
//using System.Windows.Forms;
//using System.Collections.Generic;
//using FacebookWrapper.ObjectModel;

//namespace C17_Ex01_Dudi_200441749_Or_204311997
//{
//    public static class FacebookPhotoUtils
//    {
//        public static Album[] GetAllUserAlbumsAsArray()
//        {
//            List<Album> albums = new List<Album>();

//            foreach (Album album in FacebookApplication.LoggedInUser.Albums)
//            {
//                albums.Add(album);
//            }

//            return albums.ToArray();
//        }
//    }
//}
//        //public static List<Photo> GetAllUserPhotos(User i_User, ref int i_ProgressValue)
//        //{
//        //    List<Photo> photos = new List<Photo>(GetTotalPhotosUploadedByUser(i_User));

//        //    i_ProgressValue = 0;
//        //    foreach (Album album in i_User.Albums)
//        //    {
//        //        photos.AddRange(album.Photos);
//        //        i_ProgressValue += (int)(album.Count ?? 0);
//        //    }

//        //    return photos;
//        //}

//        //public static int GetTotalPhotosUploadedByUser(User i_User)
//        //{
//        //    List<Album> albums = new List<Album>(i_User.Albums.Count);
//        //    int totalPhotos = 0;

//        //    if (i_User.Albums.Count > 0)
//        //    {
//        //        albums.AddRange(i_User.Albums);
//        //        totalPhotos = GetTotalPhotosInAlbumArray(albums.ToArray());
//        //    }

//        //    return totalPhotos;
//        //    //int photoCounter = 0;

//        //    //foreach (Album album in i_User.Albums)
//        //    //{
//        //    //    //cast to int - very unlikely that a user has that many albums
//        //    //    photoCounter += Math.Min((int)(album.Count ?? 0), FacebookApplication.k_MaxPhotosInAlbum);
//        //    //}

//        //    //return photoCounter;
//        //}
//        //public static int GetTotalPhotosInAlbumArray(Album[] i_Albums)
//        //{
//        //    int photoCounter = 0;

//        //    foreach (Album album in i_Albums)
//        //    {
//        //        //cast to int - very unlikely that a user has that many albums
//        //        photoCounter += Math.Min((int)(album.Count ?? 0), FacebookApplication.k_MaxPhotosInAlbum);
//        //    }

//        //    return photoCounter;
//        //}
