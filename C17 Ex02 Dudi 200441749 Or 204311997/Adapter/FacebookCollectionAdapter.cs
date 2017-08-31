using C17_Ex01_Dudi_200441749_Or_204311997.Adapter;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    class FacebookCollectionAdapter<T> : IFacebookCollection<T>
        where T : class
    {
        // TODO like event ? no m_ ?
        public Action FetchFinished;
        private Func<FacebookObjectCollection<FacebookObject>> m_FetchDataDelegate;
        public Album[] AlbumsToLoad { get; set; }

        public FacebookCollectionAdapter(eFacebookCollectionType i_CollectionType)
        {
            switch (i_CollectionType)
            {
                case eFacebookCollectionType.Friends:
                    m_FetchDataDelegate = fetchFriends;
                    break;
                case eFacebookCollectionType.LikedPages:
                    m_FetchDataDelegate = fetchLikedPages;
                    break;
                case eFacebookCollectionType.AlbumPhotos:
                    m_FetchDataDelegate = fetchMyPhotos;
                    break;
                case eFacebookCollectionType.PhotosTaggedIn:
                    m_FetchDataDelegate = fetchPhotosTaggedIn;
                    break;
                case eFacebookCollectionType.Albums:
                    m_FetchDataDelegate = fetchAlbums;
                    break;
            }
        }

        public FacebookObjectCollection<FacebookObject> FetchDataWithProgressBar()
        {
            FacebookObjectCollection<FacebookObject> fetchedCollection = m_FetchDataDelegate.Invoke();

            if (FetchFinished != null)
            {
                FetchFinished.Invoke();
            }

            return fetchedCollection;
        }

        public FacebookObjectCollection<T> UnboxCollection(FacebookObjectCollection<FacebookObject> i_Collection)
        {
            FacebookObjectCollection<T> returnedList = new FacebookObjectCollection<T>();

            foreach (FacebookObject facebookObject in i_Collection)
            {
                T converted = facebookObject as T;

                if (converted != null)
                {
                    returnedList.Add(converted);
                }
            }

            return returnedList;
        }

        // =================================== Friends =====================================
        private FacebookObjectCollection<FacebookObject> fetchFriends()
        {
            FacebookObjectCollection<FacebookObject> friendsList = new FacebookObjectCollection<FacebookObject>();
            ProgressBarWindow progressBarWindow = new ProgressBarWindow(FacebookApplication.LoggedInUser.Friends.Count, "friends");
            progressBarWindow.Show();
            foreach (User friend in FacebookApplication.LoggedInUser.Friends)
            {
                friendsList.Add(friend);
                progressBarWindow.ProgressValue++;
            }

            progressBarWindow.Close();

            return friendsList;
        }

        // =================================== Pages =====================================

        private FacebookObjectCollection<FacebookObject> fetchLikedPages()
        {
            FacebookObjectCollection<FacebookObject> likedPagesList = new FacebookObjectCollection<FacebookObject>();
            ProgressBarWindow progressBarWindow = new ProgressBarWindow(FacebookApplication.LoggedInUser.LikedPages.Count, "liked pages");

            progressBarWindow.Show();
            foreach (Page page in FacebookApplication.LoggedInUser.LikedPages)
            {
                likedPagesList.Add(page);
                progressBarWindow.ProgressValue++;
            }

            progressBarWindow.Close();

            return likedPagesList;
        }

        // =================================== Photos =====================================
        private FacebookObjectCollection<FacebookObject> fetchMyPhotos()
        {
            FacebookObjectCollection<FacebookObject> myPhotosList = new FacebookObjectCollection<FacebookObject>();
            ProgressBarWindow progressBarWindow = new ProgressBarWindow("my photos");

            if (AlbumsToLoad == null)
            {
                AlbumsToLoad = FacebookApplication.LoggedInUser.Albums.ToArray();
            }

            foreach (Album album in AlbumsToLoad)
            {
                progressBarWindow.MaxValue += Math.Min((int)album.Count, FacebookApplication.k_MaxPhotosInAlbum);
            }

            progressBarWindow.Show();
            foreach (Album album in AlbumsToLoad)
            {
                foreach (Photo photo in album.Photos)
                {
                    myPhotosList.Add(photo);
                    progressBarWindow.ProgressValue++;
                }
            }

            progressBarWindow.Close();

            return myPhotosList;
        }

        private FacebookObjectCollection<FacebookObject> fetchPhotosTaggedIn()
        {
            FacebookObjectCollection<FacebookObject> photosTaggedIn = new FacebookObjectCollection<FacebookObject>();
            ProgressBarWindow progressBarWindow = new ProgressBarWindow(FacebookApplication.LoggedInUser.PhotosTaggedIn.Count, "Photos tagged in");

            progressBarWindow.Show();
            foreach (Photo photo in FacebookApplication.LoggedInUser.PhotosTaggedIn)
            {
                photosTaggedIn.Add(photo);
                progressBarWindow.ProgressValue++;
            }

            progressBarWindow.Close();

            return photosTaggedIn;
        }

        private FacebookObjectCollection<FacebookObject> fetchAlbums()
        {
            FacebookObjectCollection<FacebookObject> myAlbumsList = new FacebookObjectCollection<FacebookObject>();
            ProgressBarWindow progressBarWindow = new ProgressBarWindow("my photos");

            if (AlbumsToLoad == null)
            {
                AlbumsToLoad = FacebookApplication.LoggedInUser.Albums.ToArray();
            }

            foreach (Album album in AlbumsToLoad)
            {
                progressBarWindow.MaxValue += Math.Min((int)album.Count, FacebookApplication.k_MaxPhotosInAlbum);
            }

            progressBarWindow.Show();
            foreach (Album album in AlbumsToLoad)
            {
                foreach (Photo photo in album.Photos)
                {
                    progressBarWindow.ProgressValue++;
                }
                myAlbumsList.Add(album);
            }

            progressBarWindow.Close();

            return myAlbumsList;
        }
    }
}
