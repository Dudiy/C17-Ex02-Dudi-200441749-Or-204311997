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
        public FacebookObjectCollection<T> FetchDataWithProgressBar()
        {
            FacebookObjectCollection<T> returnedList = new FacebookObjectCollection<T>();
            FacebookObjectCollection<FacebookObject> facebookObjectList = m_FetchDataDelegate.Invoke();

            foreach (FacebookObject facebookObject in facebookObjectList)
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
        public FacebookCollectionAdapter(FacebookObjectCollection<User> i_FriendsCollection)
        {
            m_FetchDataDelegate = new Func<FacebookObjectCollection<FacebookObject>>(() => fetchFriends());
        }

        private FacebookObjectCollection<FacebookObject> fetchFriends()
        {
            FacebookObjectCollection<FacebookObject> friendsList = new FacebookObjectCollection<FacebookObject>();

            foreach (User friend in FacebookApplication.LoggedInUser.Friends)
            {
                friendsList.Add(friend);
            }

            return friendsList;
        }

        // =================================== Pages =====================================

        public FacebookCollectionAdapter(FacebookObjectCollection<Page> i_LikedPages)
        {
            m_FetchDataDelegate = new Func<FacebookObjectCollection<FacebookObject>>(() => fetchLikedPages());
        }

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


    }
}
