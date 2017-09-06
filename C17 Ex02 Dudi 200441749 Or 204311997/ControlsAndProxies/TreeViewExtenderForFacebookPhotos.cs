using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies
{
    using C17_Ex01_Dudi_200441749_Or_204311997.Forms;

    public class TreeViewExtenderForFacebookPhotos : TreeView
    {
        public enum eGroupBy
        {
            Uploader,
            Album
        }

        public void SetValues(FacebookObjectCollection<Photo> i_Photos, eGroupBy i_GroupBy)
        {
            this.Nodes.Clear();
            switch (i_GroupBy)
            {
                case eGroupBy.Uploader:
                    this.groupPhotosByUser(i_Photos);
                    break;
                case eGroupBy.Album:
                    this.groupPhotosByAlbum(i_Photos);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i_GroupBy), i_GroupBy, null);
            }
        }

        private void groupPhotosByAlbum(FacebookObjectCollection<Photo> i_Photos)
        {
            foreach (Photo photo in i_Photos)
            {
                if (!this.Nodes.ContainsKey(photo.Album.Id))
                {
                    TreeNode userNode = this.Nodes.Add(photo.Album.Id, string.Format(photo.Album.Name));
                    userNode.Tag = photo.Album;
                }

                TreeNode photoNode = this.Nodes[photo.Album.Id].Nodes.Add(
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
                if (!this.Nodes.ContainsKey(photo.From.Id))
                {
                    TreeNode userNode = this.Nodes.Add(photo.From.Id, string.Format("Photos by {0}", photo.From.Name));
                    userNode.Tag = photo.From;
                }

                TreeNode photoNode = this.Nodes[photo.From.Id].Nodes.Add(
                    string.Format(
                        @"{0} - {1}",
                        photo.CreatedTime.ToString(),
                        string.IsNullOrEmpty(photo.Name) ? "[No Name]" : photo.Name));
                photoNode.Tag = photo;
            }
        }

        protected override void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs i_Args)
        {
            if (i_Args.Node.Tag is User selectedUser)
            {
                FormPictureFrame profile = new FormPictureFrame(selectedUser.PictureLargeURL, selectedUser.Name);
                profile.Show();
            }
            else if (i_Args.Node.Tag is Photo selectedPhoto)
            {
                FormPhotoDetails formPhotoDetails = new FormPhotoDetails(selectedPhoto);
                formPhotoDetails.Show();
            }
        }
    }
}
