/*
 * C17_Ex01: FacebookCollectionAdapter.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Adapter
{
    using C17_Ex01_Dudi_200441749_Or_204311997.Forms;

    internal class FacebookCollectionAdapter<T> : IFacebookCollection<T>
        where T : class
    {
        private readonly Func<FacebookObjectCollection<FacebookObject>> FetchDataDelegate;
        private FormProgressBar m_FormProgressBar;
        // according to stylecop we need a space here
        private event Action FetchFinished;

        private bool CancelDataFetching { get; set; }

        public Album[] AlbumsToLoad { get; set; }

        public FacebookCollectionAdapter(eFacebookCollectionType i_CollectionType)
        {
            switch (i_CollectionType)
            {
                case eFacebookCollectionType.Friends:
                    FetchDataDelegate = fetchFriends;
                    break;
                case eFacebookCollectionType.LikedPages:
                    FetchDataDelegate = fetchLikedPages;
                    break;
                case eFacebookCollectionType.AlbumPhotos:
                    FetchDataDelegate = fetchMyPhotos;
                    break;
                case eFacebookCollectionType.PhotosTaggedIn:
                    FetchDataDelegate = fetchPhotosTaggedIn;
                    break;
                case eFacebookCollectionType.Albums:
                    FetchDataDelegate = fetchAlbums;
                    break;
                case eFacebookCollectionType.MyPosts:
                    FetchDataDelegate = fetchMyPosts;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i_CollectionType), i_CollectionType, null);
            }
        }

        public FacebookObjectCollection<FacebookObject> FetchDataWithProgressBar()
        {
            CancelDataFetching = false;
            FacebookObjectCollection<FacebookObject> fetchedCollection = FetchDataDelegate.Invoke();

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

            m_FormProgressBar = new FormProgressBar(FacebookApplication.LoggedInUser.Friends.Count, "friends");
            m_FormProgressBar.Closing += (i_Sender, i_Args) => CancelDataFetching = true;
            m_FormProgressBar.Show();
            foreach (User friend in FacebookApplication.LoggedInUser.Friends)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                friendsList.Add(friend);
                m_FormProgressBar.ProgressValue++;
            }

            m_FormProgressBar.Close();

            return friendsList;
        }

        // =================================== Pages =====================================
        private FacebookObjectCollection<FacebookObject> fetchLikedPages()
        {
            FacebookObjectCollection<FacebookObject> likedPagesList = new FacebookObjectCollection<FacebookObject>();

            m_FormProgressBar = new FormProgressBar(FacebookApplication.LoggedInUser.LikedPages.Count, "liked pages");
            m_FormProgressBar.Show();
            foreach (Page page in FacebookApplication.LoggedInUser.LikedPages)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                likedPagesList.Add(page);
                m_FormProgressBar.ProgressValue++;
            }

            m_FormProgressBar.Close();

            return likedPagesList;
        }

        // =================================== Posts =====================================
        private FacebookObjectCollection<FacebookObject> fetchMyPosts()
        {
            FacebookObjectCollection<FacebookObject> myPostsList = new FacebookObjectCollection<FacebookObject>();

            m_FormProgressBar = new FormProgressBar(FacebookApplication.LoggedInUser.Posts.Count, "my posts");
            m_FormProgressBar.Show();
            m_FormProgressBar.Closing += (i_Sender, i_Args) => CancelDataFetching = true;
            foreach (Post post in FacebookApplication.LoggedInUser.Posts)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                myPostsList.Add(post);
                m_FormProgressBar.ProgressValue++;
            }

            m_FormProgressBar.Close();

            return myPostsList;
        }

        // =================================== Photos =====================================
        private FacebookObjectCollection<FacebookObject> fetchMyPhotos()
        {
            FacebookObjectCollection<FacebookObject> myPhotosList = new FacebookObjectCollection<FacebookObject>();

            m_FormProgressBar = new FormProgressBar("my photos");
            m_FormProgressBar.Closing += (i_Sender, i_Args) => CancelDataFetching = true;
            if (AlbumsToLoad == null)
            {
                AlbumsToLoad = FacebookApplication.LoggedInUser.Albums.ToArray();
            }

            foreach (Album album in AlbumsToLoad)
            {
                if (album.Count != null)
                {
                    m_FormProgressBar.MaxValue += Math.Min((int)album.Count, FacebookApplication.k_MaxPhotosInAlbum);
                }
            }

            m_FormProgressBar.Show();
            foreach (Album album in AlbumsToLoad)
            {
                foreach (Photo photo in album.Photos)
                {
                    if (CancelDataFetching)
                    {
                        break;
                    }

                    myPhotosList.Add(photo);
                    m_FormProgressBar.ProgressValue++;
                }
            }

            m_FormProgressBar.Close();

            return myPhotosList;
        }

        private FacebookObjectCollection<FacebookObject> fetchPhotosTaggedIn()
        {
            FacebookObjectCollection<FacebookObject> photosTaggedIn = new FacebookObjectCollection<FacebookObject>();

            m_FormProgressBar = new FormProgressBar(FacebookApplication.LoggedInUser.PhotosTaggedIn.Count, "Photos tagged in");
            m_FormProgressBar.Show();
            foreach (Photo photo in FacebookApplication.LoggedInUser.PhotosTaggedIn)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                photosTaggedIn.Add(photo);
                m_FormProgressBar.ProgressValue++;
            }

            m_FormProgressBar.Close();

            return photosTaggedIn;
        }

        private FacebookObjectCollection<FacebookObject> fetchAlbums()
        {
            FacebookObjectCollection<FacebookObject> myAlbumsList = new FacebookObjectCollection<FacebookObject>();

            m_FormProgressBar = new FormProgressBar("my photos");
            if (AlbumsToLoad == null)
            {
                AlbumsToLoad = FacebookApplication.LoggedInUser.Albums.ToArray();
            }

            foreach (Album album in AlbumsToLoad)
            {
                if (album.Count != null)
                {
                    m_FormProgressBar.MaxValue += Math.Min((int)album.Count, FacebookApplication.k_MaxPhotosInAlbum);
                }
            }

            m_FormProgressBar.Show();
            foreach (Album album in AlbumsToLoad)
            {
                foreach (Photo photo in album.Photos)
                {
                    if (CancelDataFetching)
                    {
                        break;
                    }

                    m_FormProgressBar.ProgressValue++;
                }

                myAlbumsList.Add(album);
            }

            m_FormProgressBar.Close();

            return myAlbumsList;
        }
    }
}