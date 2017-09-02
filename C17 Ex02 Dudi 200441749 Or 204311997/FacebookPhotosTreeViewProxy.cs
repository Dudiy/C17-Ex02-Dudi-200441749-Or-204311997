using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    using FacebookWrapper.ObjectModel;

    public class FacebookPhotosTreeViewProxy : TreeView
    {
        public enum eGroupBy
        {
            Uploader,
            Album
        }        

        public void SetValues(FacebookObjectCollection<Photo> i_Photos, eGroupBy i_GroupBy)
        {
            Nodes.Clear();

            switch (i_GroupBy)
            {
                case eGroupBy.Uploader:
                    groupPhotosByUser(i_Photos);
                    break;
                case eGroupBy.Album:
                    groupPhotosByAlbum(i_Photos);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i_GroupBy), i_GroupBy, null);
            }
        }

        private void groupPhotosByAlbum(FacebookObjectCollection<Photo> i_Photos)
        {
            foreach (Photo photo in i_Photos)
            {
                if (!Nodes.ContainsKey(photo.Album.Id))
                {
                    TreeNode userNode = Nodes.Add(photo.Album.Id, string.Format(photo.Album.Name));
                    userNode.Tag = photo.Album;
                }

                TreeNode photoNode = Nodes[photo.Album.Id].Nodes.Add(
                    string.Format(
                        @"{0} - {1}",
                        photo.CreatedTime.ToString(),
                        string.IsNullOrEmpty(photo.Name) ? "[No Name]" : photo.Name));
                photoNode.Tag = photo;
            }
        }

        private void groupPhotosByUser(FacebookObjectCollection<Photo> i_Photos)
        {
            foreach (Photo photo in i_Photos)
            {
                if (!Nodes.ContainsKey(photo.From.Id))
                {
                    TreeNode userNode = Nodes.Add(photo.From.Id, string.Format("Photos by {0}", photo.From.Name));
                    userNode.Tag = photo.From;
                }

                TreeNode photoNode = Nodes[photo.From.Id].Nodes.Add(
                    string.Format(
                        @"{0} - {1}",
                        photo.CreatedTime.ToString(),
                        string.IsNullOrEmpty(photo.Name) ? "[No Name]" : photo.Name));
                photoNode.Tag = photo;
            }
        }

        protected override void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is User selectedUser)
            {
                PictureFrame profile = new PictureFrame(selectedUser.PictureLargeURL, selectedUser.Name);
                profile.Show();
            }
            else if (e.Node.Tag is Photo selectedPhoto)
            {
                PhotoDetails photoDetails = new PhotoDetails(selectedPhoto);
                photoDetails.Show();
            }
        }
    }
}
