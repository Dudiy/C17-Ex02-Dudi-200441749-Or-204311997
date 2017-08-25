﻿/*
 * C17_Ex01: FacebookPhotosDataTable.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Text;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    public class FacebookPhotosDataTable : FacebookDataTable
    {
        public Album[] AlbumsToLoad { get; set; }

        public FacebookPhotosDataTable()
            : base("Photos", typeof(Photo))
        {
        }

        public override IEnumerable<Tuple<int, int, object>> FetchDataTableValues()
        {
            int currRow = 0;

            DataTable.Clear();
            TotalRows = 0;
            //add rows
            if (AlbumsToLoad.Length > 0)
            {
                TotalRows = FacebookPhotoUtils.GetTotalPhotosInAlbumArray(AlbumsToLoad);

                foreach (Album album in AlbumsToLoad)
                {
                    foreach (Photo photo in album.Photos)
                    {
                        yield return Tuple.Create<int, int, object>(++currRow, TotalRows, null);

                        string photoTags = buildTagsString(photo);

                        DataTable.Rows.Add(
                            photo,
                            photo.Album.Name,
                            photo.CreatedTime,
                            photo.LikedBy != null ? photo.LikedBy.Count : 0,
                            photo.Comments != null ? photo.Comments.Count : 0,
                            buildTagsString(photo));
                    }
                }
            }

            // if the user has no albums
            yield return Tuple.Create<int, int, object>(1, 1, null);
        }

        protected override void InitColumns()
        {
            DataTable.Columns.Add("Album Name", typeof(string));
            DataTable.Columns.Add("Created Time", typeof(DateTime));
            DataTable.Columns.Add("Likes", typeof(int));
            DataTable.Columns.Add("Comments", typeof(int));
            DataTable.Columns.Add("Tags", typeof(string));
        }

        private static string buildTagsString(Photo i_Photo)
        {
            StringBuilder photoTags = new StringBuilder();

            if (i_Photo.Tags != null)
            {
                foreach (PhotoTag tag in i_Photo.Tags)
                {
                    photoTags.Append(tag.User.Name);
                    photoTags.Append(", ");
                }

                photoTags.Remove(photoTags.Length - 2, 2);
            }

            return photoTags.ToString();
        }
    }
}
