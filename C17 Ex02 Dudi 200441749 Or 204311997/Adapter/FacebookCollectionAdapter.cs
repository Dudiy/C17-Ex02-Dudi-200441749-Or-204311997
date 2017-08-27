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
        private Func<FacebookObjectCollection<FacebookObject>> m_FetchDataDelegate;
        public Album[] AlbumsToLoad { get; set; }

        public FacebookCollectionAdapter(eFacebookCollectionType i_CollectionType)
        {
            switch (i_CollectionType)
            {
                case eFacebookCollectionType.Friends:
                    m_FetchDataDelegate = new Func<FacebookObjectCollection<FacebookObject>>(() => fetchFriends());
                    break;
                case eFacebookCollectionType.LikedPages:
                    m_FetchDataDelegate = new Func<FacebookObjectCollection<FacebookObject>>(() => fetchLikedPages());
                    break;
                case eFacebookCollectionType.MyPhotos:
                    m_FetchDataDelegate = new Func<FacebookObjectCollection<FacebookObject>>(() => fetchMyPhotos());
                    break;
                default:
                    break;
            }
        }

        public FacebookObjectCollection<FacebookObject> FetchDataWithProgressBar()
        {
            return m_FetchDataDelegate.Invoke();
        }

        public FacebookObjectCollection<T> unboxCollection(FacebookObjectCollection<FacebookObject> i_Collection)
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
        //public FacebookCollectionAdapter(FacebookObjectCollection<User> i_FriendsCollection)
        //{            
        //    m_FetchDataDelegate = new Func<FacebookObjectCollection<FacebookObject>>(() => fetchFriends());
        //}

        private FacebookObjectCollection<FacebookObject> fetchFriends()
        {
            FacebookObjectCollection<FacebookObject> friendsList = new FacebookObjectCollection<FacebookObject>();
            ProgressBarWindow progressBarWindow = new ProgressBarWindow("friends");

            progressBarWindow.MaxValue = FacebookApplication.LoggedInUser.Friends.Count;
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

        //public FacebookCollectionAdapter(FacebookObjectCollection<Page> i_LikedPages)
        //{
        //    m_FetchDataDelegate = new Func<FacebookObjectCollection<FacebookObject>>(() => fetchLikedPages());
        //}

        private FacebookObjectCollection<FacebookObject> fetchLikedPages()
        {
            FacebookObjectCollection<FacebookObject> likedPagesList = new FacebookObjectCollection<FacebookObject>();
            ProgressBarWindow progressBarWindow = new ProgressBarWindow("liked pages");

            progressBarWindow.MaxValue = FacebookApplication.LoggedInUser.LikedPages.Count;
            progressBarWindow.Show();
            foreach (Page page in FacebookApplication.LoggedInUser.LikedPages)
            {
                likedPagesList.Add(page);
                progressBarWindow.ProgressValue++;
            }

            progressBarWindow.Close();

            return likedPagesList;
        }

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
                progressBarWindow.MaxValue += (int)album.Count;
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
    }
}
