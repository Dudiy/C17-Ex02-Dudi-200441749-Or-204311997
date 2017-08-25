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

        public IEnumerable<Tuple<int, int, object>> FetchPhotosTaggedTogether()
        {
            List<Photo> photos = new List<Photo>();
            int currTag = 0;
            int totalTag = m_LoggedInUser.PhotosTaggedIn.Count;

            foreach (Photo photo in m_LoggedInUser.PhotosTaggedIn)
            {
                yield return Tuple.Create(++currTag, totalTag, (object)photos);

                if (photo.Tags != null)
                {
                    foreach (PhotoTag tag in photo.Tags)
                    {
                        if (tag.User.Id == Friend.Id)
                        {
                            photos.Add(photo);
                            break;
                        }
                    }
                }
            }

            photos.OrderBy(photo => photo.CreatedTime);
            yield return Tuple.Create(1, 1, (object)photos);
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

        public IEnumerable<Tuple<int, int, object>> GetNumberOfPhotosFriendLiked()
        {
            int numLikes = 0;
            int currPhoto = 0;
            Album[] allUserAlbums = FacebookPhotoUtils.GetAllUserAlbumsAsArray();
            int totalPhotos = FacebookPhotoUtils.GetTotalPhotosInAlbumArray(allUserAlbums);

            foreach (Album album in allUserAlbums)
            {
                foreach (Photo photo in album.Photos)
                {
                    yield return Tuple.Create(++currPhoto, totalPhotos, (object)numLikes);

                    foreach (User user in photo.LikedBy)
                    {
                        if (user.Id == Friend.Id)
                        {
                            numLikes++;
                            break;
                        }
                    }
                }
            }

            yield return Tuple.Create(1, 1, (object)numLikes);
        }

        public IEnumerable<Tuple<int, int, object>> GetNumberOfPhotosFriendCommented()
        {
            Album[] allUserAlbums = FacebookPhotoUtils.GetAllUserAlbumsAsArray();
            int totalPhotos = FacebookPhotoUtils.GetTotalPhotosInAlbumArray(allUserAlbums);
            int currPhoto = 0;
            int numComments = 0;

            foreach (Album album in m_LoggedInUser.Albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    foreach (Comment comment in photo.Comments)
                    {
                        yield return Tuple.Create(++currPhoto, totalPhotos, (object)numComments);

                        if (comment.From.Id == Friend.Id)
                        {
                            numComments++;
                            break;
                        }
                    }
                }
            }

            // if no comments are found
            yield return Tuple.Create(1, 1, (object)numComments);
        }
    }
}