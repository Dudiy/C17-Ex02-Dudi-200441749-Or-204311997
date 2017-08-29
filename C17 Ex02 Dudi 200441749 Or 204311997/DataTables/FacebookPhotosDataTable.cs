/*
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
using System.Threading;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    public class FacebookPhotosDataTable : FacebookDataTable
    {
        private Thread populateRowsThread;

        private bool abortRunningThread;
        public Album[] AlbumsToLoad { get; set; }
        internal FacebookPhotosDataTable()
            : base("Photos", typeof(Photo))
        {
        }

        private void getTotalPhotos()
        {
            lock (m_PopulateRowsLock)
            {
                TotalRows = 0;

                foreach (Album album in FacebookApplication.LoggedInUser.Albums)
                {
                    TotalRows += Math.Min((int)album.Count, FacebookApplication.k_MaxPhotosInAlbum);
                }
            }
        }

        public override void PopulateRows(FacebookObjectCollection<FacebookObject> i_Collection)
        {
            this.abortRunningThread = populateRowsThread != null && populateRowsThread.IsAlive;
            DataTable.Rows.Clear();
            TotalRows = i_Collection.Count;

            if (PopulateRowsStarting != null)
            {
                PopulateRowsStarting.Invoke();
            }


            populateRowsThread = new Thread(() => populateRows(i_Collection));
            populateRowsThread.Start();
        }

        private void populateRows(FacebookObjectCollection<FacebookObject> myPhotos)
        {
            lock (m_PopulateRowsLock)
            {
                foreach (FacebookObject facebookObject in myPhotos)
                {
                    if (facebookObject is Photo photo)
                    {
                        string photoTags = buildTagsString(photo);

                        DataTable.Rows.Add(
                            photo,
                            photo.Album.Name,
                            photo.CreatedTime,
                            photo.LikedBy?.Count ?? 0,
                            photo.Comments?.Count ?? 0,
                            photoTags);
                    }

                    if (this.abortRunningThread)
                    {
                        this.abortRunningThread = false;
                        break;
                    }
                }

                if (PopulateRowsCompleted != null)
                {
                    PopulateRowsCompleted.Invoke();
                }
            }
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
