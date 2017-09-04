/*
 * C17_Ex01: FormAlbumsSelector.cs
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
    public partial class FormAlbumsSelector : Form
    {
        private const DialogResult k_AlbumSelectionSuccessful = DialogResult.Yes;
        private readonly User r_AlbumsOwner;
        private bool m_IgnoreCheckChangeEvents;
        private List<Album> m_SelectedAlbums;

        public FormAlbumsSelector(User i_User)
        {
            InitializeComponent();
            r_AlbumsOwner = i_User;
            initAlbumsList();
        }

        protected override void OnShown(EventArgs i_Args)
        {
            base.OnShown(i_Args);
            // every time the form is shown, clear the m_SelectedAlbums property
            m_SelectedAlbums = new List<Album>();
        }

        private void initAlbumsList()
        {
            listBoxAlbums.DisplayMember = "Name";
            foreach (Album album in this.r_AlbumsOwner.Albums)
            {
                listBoxAlbums.Items.Add(album);
            }
        }

        public Album[] GetAlbumsSelection()
        {
            ShowDialog();

            return m_SelectedAlbums.ToArray();
        }

        private void buttonContinue_Click(object i_Sender, EventArgs i_Args)
        {
            m_SelectedAlbums = new List<Album>(listBoxAlbums.SelectedIndices.Count);
            foreach (Album selectedAlbum in listBoxAlbums.SelectedItems)
            {
                m_SelectedAlbums.Add(selectedAlbum);
            }

            DialogResult = k_AlbumSelectionSuccessful;
        }

        private void checkBoxSelectAll_CheckedChanged(object i_Sender, EventArgs i_Args)
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
        private void listBoxAlbums_SelectedValueChanged(object i_Sender, EventArgs i_Args)
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
