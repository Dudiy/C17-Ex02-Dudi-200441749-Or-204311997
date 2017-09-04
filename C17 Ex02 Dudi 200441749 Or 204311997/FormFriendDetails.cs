/*
 * C17_Ex01: FormFriendDetails.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class FormFriendDetails : Form
    {
        private readonly User r_Friend;

        public FormFriendDetails(User i_Friend)
        {
            InitializeComponent();
            r_Friend = i_Friend;
            userBindingSource.DataSource = r_Friend;
        }

        protected override void OnLoad(EventArgs i_Args)
        {
            base.OnLoad(i_Args);
            labelLikedPage.Text = string.Format(
@"Pages that {0} liked",
r_Friend.FirstName);
            if (!string.IsNullOrEmpty(labelBirthday.Text))
            {
                labelBirthdayTitle.Visible = false;
                labelBirthday.Visible = false;
            }
        }

        private void listBoxLikedPage_SelectedIndexChanged(object i_Sender, EventArgs i_Args)
        {
            likedPagesBindingSource.DataSource = ((ListBox)i_Sender).SelectedItem as Page;
        }

        private void linkLabelLikedPageUrl_LinkClicked(object i_Sender, LinkLabelLinkClickedEventArgs i_Args)
        {
            // Specify that the link was visited.
            linkLabelLikedPageURL.LinkVisited = true;
            // Navigate to a URL.
            System.Diagnostics.Process.Start(linkLabelLikedPageURL.Text);
        }
    }
}
