/*
 * C17_Ex01: FacebookPhotosDataTable.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Text;
using System.Threading;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    public class FacebookPhotosDataTable : FacebookDataTable
    {
        private Thread m_PopulateRowsThread;
        private Action populateRowsThreadInterrupted;
        private bool m_AbortRunningThread;

        public Album[] AlbumsToLoad { get; set; }

        internal FacebookPhotosDataTable()
            : base("Photos")
        {
        }

        public override void PopulateRows(FacebookObjectCollection<FacebookObject> i_Collection)
        {
            m_AbortRunningThread = m_PopulateRowsThread != null && m_PopulateRowsThread.IsAlive;
            TotalRows = i_Collection.Count;

            // if abort running thread is true wait for the currently running thread to stop
            while (m_AbortRunningThread)
            {
                Thread.Sleep(100);
            }

            lock (r_PopulateRowsLock)
            {
                DataTable.Rows.Clear();
                m_PopulateRowsThread = FacebookApplication.StartThread(() => PopulateRowsImplementation(i_Collection));
            }
        }

        protected override void PopulateRowsImplementation(FacebookObjectCollection<FacebookObject> i_MyPhotos)
        {
            try
            {
                foreach (FacebookObject facebookObject in i_MyPhotos)
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

                    if (m_AbortRunningThread)
                    {
                        m_AbortRunningThread = false;
                        break;
                    }
                }

                if (NotifyAbstractParentPopulateRowsCompleted != null)
                {
                    NotifyAbstractParentPopulateRowsCompleted.Invoke();
                }
            }
            catch (Exception e)
            {
                if (!(e.InnerException is ThreadAbortException) && !(e is ThreadAbortException))
                {
                    throw new PopulateRowsException(this, e);
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

        private string buildTagsString(Photo i_Photo)
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
