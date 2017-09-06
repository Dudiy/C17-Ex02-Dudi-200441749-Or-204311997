namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    using C17_Ex01_Dudi_200441749_Or_204311997.Forms.Tabs;

    public partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.tabPageFriendshipAnalyzer = new System.Windows.Forms.TabPage();
            this.tabPageDataTables = new System.Windows.Forms.TabPage();
            this.tabPageAboutMe = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.pictureBoxCoverPhoto = new System.Windows.Forms.PictureBox();
            this.likedPagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.friendsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabAboutMe = new C17_Ex01_Dudi_200441749_Or_204311997.Forms.Tabs.TabAboutMe();
            this.tabDataTables = new C17_Ex01_Dudi_200441749_Or_204311997.Forms.Tabs.TabDataTables();
            this.tabFriendshipAnalyzer = new C17_Ex01_Dudi_200441749_Or_204311997.Forms.Tabs.TabFriendshipAnalyzer();
            this.tabPageFriendshipAnalyzer.SuspendLayout();
            this.tabPageDataTables.SuspendLayout();
            this.tabPageAboutMe.SuspendLayout();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.likedPagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.BackColor = System.Drawing.SystemColors.Control;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelUserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelUserName.Location = new System.Drawing.Point(117, 123);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(160, 31);
            this.labelUserName.TabIndex = 3;
            this.labelUserName.Text = "User Name";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogout.Location = new System.Drawing.Point(1135, 15);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(67, 26);
            this.buttonLogout.TabIndex = 7;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(1207, 15);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(67, 26);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // tabPageFriendshipAnalyzer
            // 
            this.tabPageFriendshipAnalyzer.AutoScroll = true;
            this.tabPageFriendshipAnalyzer.Controls.Add(this.tabFriendshipAnalyzer);
            this.tabPageFriendshipAnalyzer.Location = new System.Drawing.Point(4, 29);
            this.tabPageFriendshipAnalyzer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageFriendshipAnalyzer.Name = "tabPageFriendshipAnalyzer";
            this.tabPageFriendshipAnalyzer.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageFriendshipAnalyzer.Size = new System.Drawing.Size(971, 476);
            this.tabPageFriendshipAnalyzer.TabIndex = 2;
            this.tabPageFriendshipAnalyzer.Text = "Friendship Analyzer";
            this.tabPageFriendshipAnalyzer.UseVisualStyleBackColor = true;
            // 
            // tabPageDataTables
            // 
            this.tabPageDataTables.Controls.Add(this.tabDataTables);
            this.tabPageDataTables.Location = new System.Drawing.Point(4, 29);
            this.tabPageDataTables.Name = "tabPageDataTables";
            this.tabPageDataTables.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageDataTables.Size = new System.Drawing.Size(971, 476);
            this.tabPageDataTables.TabIndex = 1;
            this.tabPageDataTables.Text = "Data Tables";
            this.tabPageDataTables.UseVisualStyleBackColor = true;
            // 
            // tabPageAboutMe
            // 
            this.tabPageAboutMe.AutoScroll = true;
            this.tabPageAboutMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageAboutMe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageAboutMe.Controls.Add(this.tabAboutMe);
            this.tabPageAboutMe.Location = new System.Drawing.Point(4, 29);
            this.tabPageAboutMe.Name = "tabPageAboutMe";
            this.tabPageAboutMe.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageAboutMe.Size = new System.Drawing.Size(1164, 549);
            this.tabPageAboutMe.TabIndex = 0;
            this.tabPageAboutMe.Text = "About Me";
            this.tabPageAboutMe.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageAboutMe);
            this.tabControl.Controls.Add(this.tabPageDataTables);
            this.tabControl.Controls.Add(this.tabPageFriendshipAnalyzer);
            this.tabControl.ItemSize = new System.Drawing.Size(150, 25);
            this.tabControl.Location = new System.Drawing.Point(17, 180);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(979, 509);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.Tag = "";
            // 
            // pictureBoxProfilePicture
            // 
            this.pictureBoxProfilePicture.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxProfilePicture.Image")));
            this.pictureBoxProfilePicture.Location = new System.Drawing.Point(25, 84);
            this.pictureBoxProfilePicture.Name = "pictureBoxProfilePicture";
            this.pictureBoxProfilePicture.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pictureBoxProfilePicture.Size = new System.Drawing.Size(81, 79);
            this.pictureBoxProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfilePicture.TabIndex = 2;
            this.pictureBoxProfilePicture.TabStop = false;
            // 
            // pictureBoxCoverPhoto
            // 
            this.pictureBoxCoverPhoto.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCoverPhoto.Image")));
            this.pictureBoxCoverPhoto.Location = new System.Drawing.Point(17, 15);
            this.pictureBoxCoverPhoto.Name = "pictureBoxCoverPhoto";
            this.pictureBoxCoverPhoto.Size = new System.Drawing.Size(499, 126);
            this.pictureBoxCoverPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCoverPhoto.TabIndex = 4;
            this.pictureBoxCoverPhoto.TabStop = false;
            // 
            // likedPagesBindingSource
            // 
            this.likedPagesBindingSource.DataMember = "LikedPages";
            this.likedPagesBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // friendsBindingSource
            // 
            this.friendsBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // tabAboutMe
            // 
            this.tabAboutMe.AutoScroll = true;
            this.tabAboutMe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAboutMe.Location = new System.Drawing.Point(3, 3);
            this.tabAboutMe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabAboutMe.Name = "tabAboutMe";
            this.tabAboutMe.Size = new System.Drawing.Size(1154, 539);
            this.tabAboutMe.TabIndex = 0;
            // 
            // tabDataTables
            // 
            this.tabDataTables.AutoScroll = true;
            this.tabDataTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDataTables.Location = new System.Drawing.Point(3, 3);
            this.tabDataTables.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDataTables.Name = "tabDataTables";
            this.tabDataTables.Size = new System.Drawing.Size(965, 470);
            this.tabDataTables.TabIndex = 0;
            // 
            // tabFriendshipAnalyzer
            // 
            this.tabFriendshipAnalyzer.AutoScroll = true;
            this.tabFriendshipAnalyzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFriendshipAnalyzer.Location = new System.Drawing.Point(2, 2);
            this.tabFriendshipAnalyzer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFriendshipAnalyzer.Name = "tabFriendshipAnalyzer";
            this.tabFriendshipAnalyzer.Size = new System.Drawing.Size(967, 472);
            this.tabFriendshipAnalyzer.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 701);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.pictureBoxProfilePicture);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pictureBoxCoverPhoto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.tabPageFriendshipAnalyzer.ResumeLayout(false);
            this.tabPageDataTables.ResumeLayout(false);
            this.tabPageAboutMe.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.likedPagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxProfilePicture;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.PictureBox pictureBoxCoverPhoto;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TabPage tabPageFriendshipAnalyzer;
        private System.Windows.Forms.TabPage tabPageDataTables;
        private System.Windows.Forms.TabPage tabPageAboutMe;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.BindingSource friendsBindingSource;
        private System.Windows.Forms.BindingSource likedPagesBindingSource;
        private TabAboutMe tabAboutMe;
        private TabDataTables tabDataTables;
        private TabFriendshipAnalyzer tabFriendshipAnalyzer;
    }
}