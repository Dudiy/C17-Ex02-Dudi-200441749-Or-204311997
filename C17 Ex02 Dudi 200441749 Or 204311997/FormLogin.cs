/*
 * C17_Ex01: FormLogin.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;
using FacebookWrapper;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class FormLogin : Form
    {
        private const DialogResult k_LoginSuccesfull = DialogResult.Yes;
        public LoginResult LoginResult { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
            if (FacebookApplication.AppSettings != null)
            {
                checkBoxRememberMe.Checked = FacebookApplication.AppSettings.RememberUser;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                login();
                DialogResult = k_LoginSuccesfull;
            }
            catch
            {
                this.Show();
                MessageBox.Show("Error logging in, please check internet connection and try again");
            }
        }

        // TODO see which permission we need
        private void login()
        {
            LoginResult = FacebookService.Login(
                "197501144117907",
                "public_profile",
                "email",
                "user_birthday",
                "user_about_me",
                "user_friends",
                "publish_actions",
                "user_events",
                "user_hometown",
                "user_likes",
                "user_photos",
                "user_posts",
                "user_status",
                "user_website",
                "publish_actions");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            FacebookApplication.ExitSelected = true;
            //FacebookApplication.Logout();
            Close();
        }

        private void checkBoxRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (FacebookApplication.AppSettings != null)
            {
                FacebookApplication.AppSettings.RememberUser = checkBoxRememberMe.Checked;
            }
        }
    }
}
