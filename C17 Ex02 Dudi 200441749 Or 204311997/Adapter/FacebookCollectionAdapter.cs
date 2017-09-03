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
        private event Action FetchFinished;
        private Func<FacebookObjectCollection<FacebookObject>> m_FetchDataDelegate;
        private ProgressBarWindow m_ProgressBarWindow;
        public bool CancelDataFetching { get; set; }
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
                case eFacebookCollectionType.MyPosts:
                    this.m_FetchDataDelegate = fetchMyPosts;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i_CollectionType), i_CollectionType, null);
            }
        }

        public FacebookObjectCollection<FacebookObject> FetchDataWithProgressBar()
        {
            CancelDataFetching = false;
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

            m_ProgressBarWindow = new ProgressBarWindow(FacebookApplication.LoggedInUser.Friends.Count, "friends");
            m_ProgressBarWindow.Closing += (sender, e) => CancelDataFetching = true;
            m_ProgressBarWindow.Show();
            foreach (User friend in FacebookApplication.LoggedInUser.Friends)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                friendsList.Add(friend);
                m_ProgressBarWindow.ProgressValue++;
            }

            m_ProgressBarWindow.Close();

            return friendsList;
        }

        // =================================== Pages =====================================

        private FacebookObjectCollection<FacebookObject> fetchLikedPages()
        {
            FacebookObjectCollection<FacebookObject> likedPagesList = new FacebookObjectCollection<FacebookObject>();

            m_ProgressBarWindow = new ProgressBarWindow(FacebookApplication.LoggedInUser.LikedPages.Count, "liked pages");
            m_ProgressBarWindow.Show();
            foreach (Page page in FacebookApplication.LoggedInUser.LikedPages)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                likedPagesList.Add(page);
                m_ProgressBarWindow.ProgressValue++;
            }

            m_ProgressBarWindow.Close();

            return likedPagesList;
        }

        // =================================== Posts =====================================
        private FacebookObjectCollection<FacebookObject> fetchMyPosts()
        {
            FacebookObjectCollection<FacebookObject> myPostsList = new FacebookObjectCollection<FacebookObject>();
            m_ProgressBarWindow = new ProgressBarWindow(FacebookApplication.LoggedInUser.Posts.Count, "my posts");
            m_ProgressBarWindow.Show();
            m_ProgressBarWindow.Closing += (sender, e) => CancelDataFetching = true;
            foreach (Post post in FacebookApplication.LoggedInUser.Posts)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                myPostsList.Add(post);
                m_ProgressBarWindow.ProgressValue++;
            }

            this.m_ProgressBarWindow.Close();

            return myPostsList;
        }

        // =================================== Photos =====================================
        private FacebookObjectCollection<FacebookObject> fetchMyPhotos()
        {
            FacebookObjectCollection<FacebookObject> myPhotosList = new FacebookObjectCollection<FacebookObject>();

            m_ProgressBarWindow = new ProgressBarWindow("my photos");
            m_ProgressBarWindow.Closing += (sender, e) => CancelDataFetching = true;
            if (AlbumsToLoad == null)
            {
                AlbumsToLoad = FacebookApplication.LoggedInUser.Albums.ToArray();
            }

            foreach (Album album in AlbumsToLoad)
            {
                m_ProgressBarWindow.MaxValue += Math.Min((int)album.Count, FacebookApplication.k_MaxPhotosInAlbum);
            }

            m_ProgressBarWindow.Show();
            foreach (Album album in AlbumsToLoad)
            {
                foreach (Photo photo in album.Photos)
                {
                    if (CancelDataFetching)
                    {
                        break;
                    }

                    myPhotosList.Add(photo);
                    m_ProgressBarWindow.ProgressValue++;
                }
            }

            m_ProgressBarWindow.Close();

            return myPhotosList;
        }

        private FacebookObjectCollection<FacebookObject> fetchPhotosTaggedIn()
        {
            FacebookObjectCollection<FacebookObject> photosTaggedIn = new FacebookObjectCollection<FacebookObject>();

            m_ProgressBarWindow = new ProgressBarWindow(FacebookApplication.LoggedInUser.PhotosTaggedIn.Count, "Photos tagged in");
            m_ProgressBarWindow.Show();
            foreach (Photo photo in FacebookApplication.LoggedInUser.PhotosTaggedIn)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                photosTaggedIn.Add(photo);
                m_ProgressBarWindow.ProgressValue++;
            }

            m_ProgressBarWindow.Close();

            return photosTaggedIn;
        }

        private FacebookObjectCollection<FacebookObject> fetchAlbums()
        {
            FacebookObjectCollection<FacebookObject> myAlbumsList = new FacebookObjectCollection<FacebookObject>();

            m_ProgressBarWindow = new ProgressBarWindow("my photos");
            if (AlbumsToLoad == null)
            {
                AlbumsToLoad = FacebookApplication.LoggedInUser.Albums.ToArray();
            }

            foreach (Album album in AlbumsToLoad)
            {
                m_ProgressBarWindow.MaxValue += Math.Min((int)album.Count, FacebookApplication.k_MaxPhotosInAlbum);
            }

            m_ProgressBarWindow.Show();
            foreach (Album album in AlbumsToLoad)
            {
                foreach (Photo photo in album.Photos)
                {
                    if (CancelDataFetching)
                    {
                        break;
                    }

                    m_ProgressBarWindow.ProgressValue++;
                }
                myAlbumsList.Add(album);
            }

            m_ProgressBarWindow.Close();

            return myAlbumsList;
        }
    }
}