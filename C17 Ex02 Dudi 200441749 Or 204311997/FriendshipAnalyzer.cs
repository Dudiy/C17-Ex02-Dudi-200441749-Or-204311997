/*
 * C17_Ex01: FriendshipAnalyzer.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    using C17_Ex01_Dudi_200441749_Or_204311997.Adapter;
    public class FriendshipAnalyzer
    {
        private bool m_FinishedFetchingComments;
        private bool m_FinishedFetchingLikes;
        // TODO change to property
        public Dictionary<Comment, Photo> m_CommentsByFriend = new Dictionary<Comment, Photo>();
        private FacebookObjectCollection<Photo> m_PhotosFriendLiked = new FacebookObjectCollection<Photo>();
        public User Friend { get; set; }

        public int NumPhotosFriendLiked { get; private set; }

        public int NumPhotosFriendCommented { get; private set; }

        public event Action FinishedFetchingLikesAndComments;

        public FriendshipAnalyzer()
        {
            NumPhotosFriendLiked = 0;
            NumPhotosFriendCommented = 0;
        }

        public FacebookObjectCollection<Photo> PhotosTaggedTogether(FacebookObjectCollection<Photo> i_PhotosTaggedIn)
        {
            FacebookObjectCollection<Photo> photosTaggedTogether = new FacebookObjectCollection<Photo>();

            foreach (Photo photo in i_PhotosTaggedIn)
            {
                if (photo.Tags != null)
                {
                    if (photo.Tags.Find(tag => tag.User.Id == Friend.Id) != null)
                    {
                        photosTaggedTogether.Add(photo);
                    }
                }
            }

            photosTaggedTogether.OrderBy(photo => photo.CreatedTime);

            return photosTaggedTogether;
        }

        public Dictionary<string, List<Photo>> GroupPhotoListByOwner(List<Photo> i_Photos)
        {
            Dictionary<string, List<Photo>> groupedPhotos = new Dictionary<string, List<Photo>>();

            foreach (Photo photo in i_Photos)
            {
                if (groupedPhotos.ContainsKey(photo.From.Id))
                {
                    groupedPhotos[photo.From.Id].Add(photo);
                }
                else
                {
                    List<Photo> photoList = new List<Photo>();
                    photoList.Add(photo);
                    groupedPhotos.Add(photo.From.Id, photoList);
                }
            }

            return groupedPhotos;
        }

        public Photo GetMostRecentPhotoTaggedTogether(FacebookObjectCollection<Photo> i_PhotosTaggedTogether)
        {
            return i_PhotosTaggedTogether.Count > 0 ? i_PhotosTaggedTogether[0] : null;
        }

        public void CountNumberOfPhotosFriendLiked(FacebookObjectCollection<Photo> i_Photos, Action i_PromoteProgressBar)
        {
            NumPhotosFriendLiked = 0;
            m_FinishedFetchingLikes = false;
            try
            {
                foreach (Photo photo in i_Photos)
                {
                    if (photo.LikedBy.Find(user => user.Id == Friend.Id) != null)
                    {
                        this.m_PhotosFriendLiked.Add(photo);
                        NumPhotosFriendLiked++;
                    }

                    i_PromoteProgressBar.Invoke();
                }
            }
            catch (Exception e)
            {
                if (!(e.InnerException is ThreadAbortException) && !(e is ThreadAbortException))
                {

                    string message = string.Format(
                        @"Error while counting likes:
{0}",
                        e.Message);
                    MessageBox.Show(message);
                }
            }
            finally
            {
                m_FinishedFetchingLikes = true;
                fetchComplete();
            }
        }

        private void fetchComplete()
        {
            if (m_FinishedFetchingComments && m_FinishedFetchingLikes)
            {
                if (FinishedFetchingLikesAndComments != null)
                {
                    FinishedFetchingLikesAndComments.Invoke();
                }
            }
        }

        public void CountNumberOfPhotosFriendCommented(Action i_PromoteProgressBar)
        {
            FacebookCollectionAdapter<Photo> allPhotosAdapter = new FacebookCollectionAdapter<Photo>(eFacebookCollectionType.AlbumPhotos);
            FacebookObjectCollection<FacebookObject> boxAllPhotosTaggedIn = allPhotosAdapter.FetchDataWithProgressBar();
            FacebookObjectCollection<Photo> allPhotos = allPhotosAdapter.UnboxCollection(boxAllPhotosTaggedIn);

            CountNumberOfPhotosFriendCommented(allPhotos, i_PromoteProgressBar);
        }

        public void CountNumberOfPhotosFriendCommented(FacebookObjectCollection<Photo> i_Photos, Action i_PromoteProgressBar)
        {
            NumPhotosFriendCommented = 0;
            m_FinishedFetchingComments = false;
            try
            {
                foreach (Photo photo in i_Photos)
                {
                    Comment commentByFriend = photo.Comments.Find(comment => comment.From.Id == Friend.Id);
                    if (commentByFriend != null)
                    {     
                        m_CommentsByFriend.Add(commentByFriend, photo);
                        NumPhotosFriendCommented++;
                    }

                    i_PromoteProgressBar.Invoke();
                }
            }
            catch (Exception e)
            {
                if (!(e.InnerException is ThreadAbortException) && !(e is ThreadAbortException))
                {
                    string message = string.Format(
                        @"Error while counting comments:
{0}",
                        e.Message);
                    MessageBox.Show(message);
                }
            }
            finally
            {
                this.m_FinishedFetchingComments = true;
                this.fetchComplete();
            }
        }

        public FacebookObjectCollection<Photo> GetPhotosFromAlbumsUserIsTaggedIn(User i_Tagged, FacebookObjectCollection<Album> i_Albums)
        {
            FacebookObjectCollection<Photo> photos = new FacebookObjectCollection<Photo>();

            if (i_Albums.Count > 0)
            {
                foreach (Album album in i_Albums)
                {
                    foreach (Photo photo in album.Photos)
                    {
                        if (photo.Tags != null)
                        {
                            if (photo.Tags.Find(tag => tag.User.Id == i_Tagged.Id) != null)
                            {
                                photos.Add(photo);
                            }
                        }
                    }
                }
            }

            return photos;
        }
    }
}