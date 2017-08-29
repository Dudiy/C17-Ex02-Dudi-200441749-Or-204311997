/*
 * C17_Ex01: FriendshipAnalyzer.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Linq;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public class FriendshipAnalyzer
    {
        private User m_LoggedInUser = FacebookApplication.LoggedInUser;
        public User Friend { get; set; }

        public List<Photo> PhotosTaggedTogether(FacebookObjectCollection<Photo> i_PhotosTaggedIn)
        {
            List<Photo> photosTaggedTogether = new List<Photo>();

            foreach (Photo photo in photosTaggedTogether)
            {
                if (photo.Tags != null)
                {
                    foreach (PhotoTag tag in photo.Tags)
                    {
                        if (tag.User.Id == Friend.Id)
                        {
                            photosTaggedTogether.Add(photo);
                            break;
                        }
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

        public Photo GetMostRecentPhotoTaggedTogether(List<Photo> i_PhotosTaggedTogether)
        {
            return i_PhotosTaggedTogether.Count > 0 ? i_PhotosTaggedTogether[0] : null;
        }

        public int GetNumberOfPhotosFriendLiked(FacebookObjectCollection<Photo> i_Photos)
        {
            int numLikes = 0;

            foreach (Photo photo in i_Photos)
            {
                foreach (User user in photo.LikedBy)
                {
                    if (user.Id == Friend.Id)
                    {
                        numLikes++;
                        break;
                    }
                }
            }

            return numLikes;
        }

        public int GetNumberOfPhotosFriendCommented(FacebookObjectCollection<Photo> i_Photos)
        {
            int numComments = 0;

            foreach (Photo photo in i_Photos)
            {
                foreach (Comment comment in photo.Comments)
                {
                    if (comment.From.Id == Friend.Id)
                    {
                        numComments++;
                        break;
                    }
                }
            }

            return numComments;
        }

        public static Dictionary<Album, List<Photo>> GetPhotosByOwnerAndTags(User i_User, User i_Tagged, FacebookObjectCollection<Album> i_Albums)
        {
            Dictionary<Album, List<Photo>> photos = new Dictionary<Album, List<Photo>>();

            if (i_Albums.Count > 0)
            {
                foreach (Album album in i_Albums)
                {
                    List<Photo> photosInAlbum = new List<Photo>();
                    foreach (Photo photo in album.Photos)
                    {
                        if (photo.Tags != null)
                        {
                            foreach (PhotoTag tag in photo.Tags)
                            {
                                if (tag.User.Id == i_Tagged.Id)
                                {
                                    photosInAlbum.Add(photo);
                                    break;
                                }
                            }
                        }
                    }

                    if (photosInAlbum.Count > 0)
                    {
                        photos.Add(album, photosInAlbum);
                    }
                }
            }

            return photos;
        }
    }
}