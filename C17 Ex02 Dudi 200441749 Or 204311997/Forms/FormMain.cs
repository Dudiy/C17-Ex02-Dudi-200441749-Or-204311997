using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    public partial class FormMain : Form
    {
        private static readonly Size sr_MinimumWindowSize = new Size(AppSettings.k_DefaultMainFormWidth, AppSettings.k_DefaultMainFormHeight);
        private bool m_LogoutClicked;

        public FormMain()
        {
            InitializeComponent();
        }

        // ================================================ general form methods ================================================
        protected override void OnShown(EventArgs i_Args)
        {
            base.OnShown(i_Args);
            this.initMainForm();
        }

        private void initMainForm()
        {
            string userName = FacebookApplication.LoggedInUser.Name ?? string.Empty;

            this.Text = userName;
            this.labelUserName.Text = userName;
            this.MinimumSize = sr_MinimumWindowSize;
            FacebookApplication.StartThread(this.fetchProfileAndCoverPhotos);
            this.tabAboutMe.InitializeTab();
        }

        private void fetchProfileAndCoverPhotos()
        {
            try
            {
                this.pictureBoxProfilePicture.LoadAsync(FacebookApplication.LoggedInUser.PictureNormalURL);
                this.pictureBoxCoverPhoto.LoadAsync(FacebookApplication.LoggedInUser.Cover.SourceURL);
            }
            catch
            {
                MessageBox.Show("Profile or cover photo missing, default photos were loaded");
            }
        }

        protected override void OnClosing(CancelEventArgs i_Args)
        {
            base.OnClosing(i_Args);
            FacebookApplication.KillAllRunningThreads();

            if (!this.m_LogoutClicked)
            {
                // exitSelected is set here in case the user hits the X button or alt+F4
                FacebookApplication.ExitSelected = true;
                FacebookApplication.AppSettings.LastFormStartPosition = FormStartPosition.Manual;
                FacebookApplication.AppSettings.LastWindowLocation = this.Location;
                FacebookApplication.AppSettings.LastWindowsSize = this.Size;
            }
        }

        private void buttonExit_Click(object i_Sender, EventArgs i_Args)
        {
            FacebookApplication.ExitSelected = true;

            this.Close();
        }

        private void buttonLogout_Click(object i_Sender, EventArgs i_Args)
        {   
            this.m_LogoutClicked = true;
            FacebookApplication.Logout();
        }
        
    }
}