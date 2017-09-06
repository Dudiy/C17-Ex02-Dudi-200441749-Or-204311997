/*
 * C17_Ex01: FormAlbumsSelector.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    public partial class FormAlbumsSelector : Form
    {
        private const DialogResult k_AlbumSelectionSuccessful = DialogResult.Yes;
        private readonly User r_AlbumsOwner;
        private bool m_IgnoreCheckChangeEvents;
        private List<Album> m_SelectedAlbums;

        public FormAlbumsSelector(User i_User)
        {
            this.InitializeComponent();
            this.r_AlbumsOwner = i_User;
            this.initAlbumsList();
        }

        protected override void OnShown(EventArgs i_Args)
        {
            base.OnShown(i_Args);
            // every time the form is shown, clear the m_SelectedAlbums property
            this.m_SelectedAlbums = new List<Album>();
        }

        private void initAlbumsList()
        {
            this.listBoxAlbums.DisplayMember = "Name";
            foreach (Album album in this.r_AlbumsOwner.Albums)
            {
                this.listBoxAlbums.Items.Add(album);
            }
        }

        public Album[] GetAlbumsSelection()
        {
            this.ShowDialog();

            return this.m_SelectedAlbums.ToArray();
        }

        private void buttonContinue_Click(object i_Sender, EventArgs i_Args)
        {
            this.m_SelectedAlbums = new List<Album>(this.listBoxAlbums.SelectedIndices.Count);
            foreach (Album selectedAlbum in this.listBoxAlbums.SelectedItems)
            {
                this.m_SelectedAlbums.Add(selectedAlbum);
            }

            this.DialogResult = k_AlbumSelectionSuccessful;
        }

        private void checkBoxSelectAll_CheckedChanged(object i_Sender, EventArgs i_Args)
        {
            if (!this.m_IgnoreCheckChangeEvents)
            {
                this.setSelectedValueForAllItems(this.checkBoxSelectAll.Checked);
            }
        }

        private void setSelectedValueForAllItems(bool i_Selected)
        {
            for (int i = 0; i < this.listBoxAlbums.Items.Count; i++)
            {
                this.listBoxAlbums.SetSelected(i, i_Selected);
            }
        }

        // when an item is selected, update the "check all" combobox accordingly
        private void listBoxAlbums_SelectedValueChanged(object i_Sender, EventArgs i_Args)
        {
            this.m_IgnoreCheckChangeEvents = true;
            if (this.listBoxAlbums.SelectedIndices.Count == this.listBoxAlbums.Items.Count)
            {
                this.checkBoxSelectAll.CheckState = CheckState.Checked;
            }
            else if (this.listBoxAlbums.SelectedIndices.Count == 0)
            {
                this.checkBoxSelectAll.CheckState = CheckState.Unchecked;
            }
            else
            {
                this.checkBoxSelectAll.CheckState = CheckState.Indeterminate;
            }

            this.m_IgnoreCheckChangeEvents = false;
        }
    }
}
