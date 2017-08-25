/*
 * C17_Ex01: AlbumsSelector.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class AlbumsSelector : Form
    {
        private const DialogResult k_AlbumSelectionSuccessful = DialogResult.Yes;
        public List<Album> SelectedAlbums { get; private set; }
        private User m_AlbumsOwner;
        private bool m_IgnoreCheckChangeEvents = false;

        public AlbumsSelector(User i_User)
        {
            InitializeComponent();
            m_AlbumsOwner = i_User;
            initAlbumsList();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //every time the form is shown, clear the SelectedAlbums property
            SelectedAlbums = new List<Album>();
        }

        private void initAlbumsList()
        {
            listBoxAlbums.DisplayMember = "Name";
            foreach (Album album in m_AlbumsOwner.Albums)
            {
                listBoxAlbums.Items.Add(album);
            }
        }

        public Album[] GetAlbumsSelection()
        {
            this.ShowDialog();

            return SelectedAlbums.ToArray();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            SelectedAlbums = new List<Album>(listBoxAlbums.SelectedIndices.Count);
            foreach (Album selectedAlbum in listBoxAlbums.SelectedItems)
            {
                SelectedAlbums.Add(selectedAlbum);
            }

            DialogResult = k_AlbumSelectionSuccessful;
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_IgnoreCheckChangeEvents)
            {
                setSelectedValueForAllItems(checkBoxSelectAll.Checked);
            }
        }

        private void setSelectedValueForAllItems(bool i_Selected)
        {
            for (int i = 0; i < listBoxAlbums.Items.Count; i++)
            {
                listBoxAlbums.SetSelected(i, i_Selected);
            }
        }
        
        // when an item is selected, update the "check all" combobox accordingly
        private void listBoxAlbums_SelectedValueChanged(object sender, EventArgs e)
        {
            m_IgnoreCheckChangeEvents = true;
            if (listBoxAlbums.SelectedIndices.Count == listBoxAlbums.Items.Count)
            {
                checkBoxSelectAll.CheckState = CheckState.Checked;
            }
            else if (listBoxAlbums.SelectedIndices.Count == 0)
            {
                checkBoxSelectAll.CheckState = CheckState.Unchecked;
            }
            else
            {
                checkBoxSelectAll.CheckState = CheckState.Indeterminate;
            }

            m_IgnoreCheckChangeEvents = false;
        }
    }
}
