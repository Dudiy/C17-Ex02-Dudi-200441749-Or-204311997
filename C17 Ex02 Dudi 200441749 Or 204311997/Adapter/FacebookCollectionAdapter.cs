using C17_Ex01_Dudi_200441749_Or_204311997.Adapter;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    using System.Threading;

    class FacebookCollectionAdapter<T> : IFacebookCollection<T>
        where T : class
    {
        // TODO like event ? no m_ ?
        public Action FetchFinished;
        private Func<FacebookObjectCollection<FacebookObject>> m_FetchDataDelegate;
        private ProgressBarWindow progressBarWindow;
        public bool CancelDataFetching { get; set; }
        public Album[] AlbumsToLoad { get; set; }

        public FacebookCollectionAdapter()
        {

        }
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
            CancelDataFetching = false;
            FacebookObjectCollection<FacebookObject> fetchedCollection = null;
            fetchedCollection = this.m_FetchDataDelegate.Invoke();

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
            progressBarWindow = new ProgressBarWindow(FacebookApplication.LoggedInUser.Friends.Count, "friends");
            progressBarWindow.Closing += (sender, e) => CancelDataFetching = true;
            progressBarWindow.Show();
            foreach (User friend in FacebookApplication.LoggedInUser.Friends)
            {
                if (CancelDataFetching)
                {
                    break;
                }

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
            progressBarWindow = new ProgressBarWindow(FacebookApplication.LoggedInUser.LikedPages.Count, "liked pages");

            progressBarWindow.Show();
            foreach (Page page in FacebookApplication.LoggedInUser.LikedPages)
            {
                if (CancelDataFetching)
                {
                    break;
                }

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
            progressBarWindow = new ProgressBarWindow("my photos");
            progressBarWindow.Closing += (sender, e) => CancelDataFetching = true;
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
                    if (CancelDataFetching)
                    {
                        break;
                    }

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
            progressBarWindow = new ProgressBarWindow(FacebookApplication.LoggedInUser.PhotosTaggedIn.Count, "Photos tagged in");

            progressBarWindow.Show();
            foreach (Photo photo in FacebookApplication.LoggedInUser.PhotosTaggedIn)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                photosTaggedIn.Add(photo);
                progressBarWindow.ProgressValue++;
            }

            progressBarWindow.Close();

            return photosTaggedIn;
        }

        private FacebookObjectCollection<FacebookObject> fetchAlbums()
        {
            FacebookObjectCollection<FacebookObject> myAlbumsList = new FacebookObjectCollection<FacebookObject>();
            progressBarWindow = new ProgressBarWindow("my photos");

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
                    if (CancelDataFetching)
                    {
                        break;
                    }

                    progressBarWindow.ProgressValue++;
                }
                myAlbumsList.Add(album);
            }

            progressBarWindow.Close();

            return myAlbumsList;
        }
    }
}
