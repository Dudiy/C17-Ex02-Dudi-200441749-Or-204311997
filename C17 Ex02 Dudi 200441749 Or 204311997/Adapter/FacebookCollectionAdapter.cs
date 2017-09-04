using System;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Adapter
{
    internal class FacebookCollectionAdapter<T> : IFacebookCollection<T>
        where T : class
    {
        private readonly Func<FacebookObjectCollection<FacebookObject>> r_FetchDataDelegate;
        // TODO like event ? no m_ ?
        private FormProgressBar m_FormProgressBar;

        private event Action FetchFinished;

        private bool CancelDataFetching { get; set; }

        public Album[] AlbumsToLoad { get; set; }

        public FacebookCollectionAdapter(eFacebookCollectionType i_CollectionType)
        {
            switch (i_CollectionType)
            {
                case eFacebookCollectionType.Friends:
                    this.r_FetchDataDelegate = fetchFriends;
                    break;
                case eFacebookCollectionType.LikedPages:
                    this.r_FetchDataDelegate = fetchLikedPages;
                    break;
                case eFacebookCollectionType.AlbumPhotos:
                    this.r_FetchDataDelegate = fetchMyPhotos;
                    break;
                case eFacebookCollectionType.PhotosTaggedIn:
                    this.r_FetchDataDelegate = fetchPhotosTaggedIn;
                    break;
                case eFacebookCollectionType.Albums:
                    this.r_FetchDataDelegate = fetchAlbums;
                    break;
                case eFacebookCollectionType.MyPosts:
                    this.r_FetchDataDelegate = fetchMyPosts;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i_CollectionType), i_CollectionType, null);
            }
        }

        public FacebookObjectCollection<FacebookObject> FetchDataWithProgressBar()
        {
            CancelDataFetching = false;
            FacebookObjectCollection<FacebookObject> fetchedCollection = this.r_FetchDataDelegate.Invoke();

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

            this.m_FormProgressBar = new FormProgressBar(FacebookApplication.LoggedInUser.Friends.Count, "friends");
            this.m_FormProgressBar.Closing += (i_Sender, i_Args) => CancelDataFetching = true;
            this.m_FormProgressBar.Show();
            foreach (User friend in FacebookApplication.LoggedInUser.Friends)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                friendsList.Add(friend);
                this.m_FormProgressBar.ProgressValue++;
            }

            this.m_FormProgressBar.Close();

            return friendsList;
        }

        // =================================== Pages =====================================
        private FacebookObjectCollection<FacebookObject> fetchLikedPages()
        {
            FacebookObjectCollection<FacebookObject> likedPagesList = new FacebookObjectCollection<FacebookObject>();

            this.m_FormProgressBar = new FormProgressBar(FacebookApplication.LoggedInUser.LikedPages.Count, "liked pages");
            this.m_FormProgressBar.Show();
            foreach (Page page in FacebookApplication.LoggedInUser.LikedPages)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                likedPagesList.Add(page);
                this.m_FormProgressBar.ProgressValue++;
            }

            this.m_FormProgressBar.Close();

            return likedPagesList;
        }

        // =================================== Posts =====================================
        private FacebookObjectCollection<FacebookObject> fetchMyPosts()
        {
            FacebookObjectCollection<FacebookObject> myPostsList = new FacebookObjectCollection<FacebookObject>();
            this.m_FormProgressBar = new FormProgressBar(FacebookApplication.LoggedInUser.Posts.Count, "my posts");
            this.m_FormProgressBar.Show();
            this.m_FormProgressBar.Closing += (i_Sender, i_Args) => CancelDataFetching = true;
            foreach (Post post in FacebookApplication.LoggedInUser.Posts)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                myPostsList.Add(post);
                this.m_FormProgressBar.ProgressValue++;
            }

            this.m_FormProgressBar.Close();

            return myPostsList;
        }

        // =================================== Photos =====================================
        private FacebookObjectCollection<FacebookObject> fetchMyPhotos()
        {
            FacebookObjectCollection<FacebookObject> myPhotosList = new FacebookObjectCollection<FacebookObject>();

            this.m_FormProgressBar = new FormProgressBar("my photos");
            this.m_FormProgressBar.Closing += (i_Sender, i_Args) => CancelDataFetching = true;
            if (AlbumsToLoad == null)
            {
                AlbumsToLoad = FacebookApplication.LoggedInUser.Albums.ToArray();
            }

            foreach (Album album in AlbumsToLoad)
            {
                if (album.Count != null)
                {
                    this.m_FormProgressBar.MaxValue += Math.Min((int)album.Count, FacebookApplication.k_MaxPhotosInAlbum);
                }
            }

            this.m_FormProgressBar.Show();
            foreach (Album album in AlbumsToLoad)
            {
                foreach (Photo photo in album.Photos)
                {
                    if (CancelDataFetching)
                    {
                        break;
                    }

                    myPhotosList.Add(photo);
                    this.m_FormProgressBar.ProgressValue++;
                }
            }

            this.m_FormProgressBar.Close();

            return myPhotosList;
        }

        private FacebookObjectCollection<FacebookObject> fetchPhotosTaggedIn()
        {
            FacebookObjectCollection<FacebookObject> photosTaggedIn = new FacebookObjectCollection<FacebookObject>();

            this.m_FormProgressBar = new FormProgressBar(FacebookApplication.LoggedInUser.PhotosTaggedIn.Count, "Photos tagged in");
            this.m_FormProgressBar.Show();
            foreach (Photo photo in FacebookApplication.LoggedInUser.PhotosTaggedIn)
            {
                if (CancelDataFetching)
                {
                    break;
                }

                photosTaggedIn.Add(photo);
                this.m_FormProgressBar.ProgressValue++;
            }

            this.m_FormProgressBar.Close();

            return photosTaggedIn;
        }

        private FacebookObjectCollection<FacebookObject> fetchAlbums()
        {
            FacebookObjectCollection<FacebookObject> myAlbumsList = new FacebookObjectCollection<FacebookObject>();

            this.m_FormProgressBar = new FormProgressBar("my photos");
            if (AlbumsToLoad == null)
            {
                AlbumsToLoad = FacebookApplication.LoggedInUser.Albums.ToArray();
            }

            foreach (Album album in AlbumsToLoad)
            {
                if (album.Count != null)
                {
                    this.m_FormProgressBar.MaxValue += Math.Min((int)album.Count, FacebookApplication.k_MaxPhotosInAlbum);
                }
            }

            this.m_FormProgressBar.Show();
            foreach (Album album in AlbumsToLoad)
            {                
                foreach (Photo photo in album.Photos)
                {
                    if (CancelDataFetching)
                    {
                        break;
                    }

                    this.m_FormProgressBar.ProgressValue++;
                }

                myAlbumsList.Add(album);
            }

            this.m_FormProgressBar.Close();

            return myAlbumsList;
        }
    }
}