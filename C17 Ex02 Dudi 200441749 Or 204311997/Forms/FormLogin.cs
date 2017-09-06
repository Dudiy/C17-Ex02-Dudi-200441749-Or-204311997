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

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    public partial class FormLogin : Form
    {
        private const DialogResult k_LoginSuccesfull = DialogResult.Yes;

        public LoginResult LoginResult { get; private set; }

        public FormLogin()
        {
            this.InitializeComponent();
            if (FacebookApplication.AppSettings != null)
            {
                this.checkBoxRememberMe.Checked = FacebookApplication.AppSettings.RememberUser;
            }
        }

        private void buttonLogin_Click(object i_Sender, EventArgs i_Args)
        {
            try
            {
                this.login();
                this.DialogResult = k_LoginSuccesfull;
            }
            catch
            {
                this.Show();
                MessageBox.Show("Error logging in, please check internet connection and try again");
            }
        }

        private void login()
        {
            this.LoginResult = FacebookService.Login(
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

        private void buttonExit_Click(object i_Sender, EventArgs i_Args)
        {
            FacebookApplication.ExitSelected = true;

            this.Close();
        }

        private void checkBoxRememberMe_CheckedChanged(object i_Sender, EventArgs i_Args)
        {
            if (FacebookApplication.AppSettings != null)
            {
                FacebookApplication.AppSettings.RememberUser = this.checkBoxRememberMe.Checked;
            }
        }
    }
}
