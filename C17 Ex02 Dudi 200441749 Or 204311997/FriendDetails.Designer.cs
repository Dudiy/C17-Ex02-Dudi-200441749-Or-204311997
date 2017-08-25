namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class FriendDetails
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.labelBirthdayTitle = new System.Windows.Forms.Label();
            this.largePictureBoxLikedPage = new System.Windows.Forms.PictureBox();
            this.likedPagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.linkLabelLikedPageURL = new System.Windows.Forms.LinkLabel();
            this.labelLikedPageName = new System.Windows.Forms.Label();
            this.listBoxLikedPage = new System.Windows.Forms.ListBox();
            this.labelLikedPage = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelBirthday = new System.Windows.Forms.Label();
            this.largePictureBoxFriend = new System.Windows.Forms.PictureBox();
            this.labelLastName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.largePictureBoxLikedPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.likedPagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.largePictureBoxFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBirthdayTitle
            // 
            this.labelBirthdayTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBirthdayTitle.AutoSize = true;
            this.labelBirthdayTitle.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBirthdayTitle.Location = new System.Drawing.Point(36, 303);
            this.labelBirthdayTitle.Name = "labelBirthdayTitle";
            this.labelBirthdayTitle.Size = new System.Drawing.Size(59, 15);
            this.labelBirthdayTitle.TabIndex = 26;
            this.labelBirthdayTitle.Text = "Birthday:";
            // 
            // largePictureBoxLikedPage
            // 
            this.largePictureBoxLikedPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.largePictureBoxLikedPage.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.likedPagesBindingSource, "ImageLarge", true));
            this.largePictureBoxLikedPage.Location = new System.Drawing.Point(226, 431);
            this.largePictureBoxLikedPage.Name = "largePictureBoxLikedPage";
            this.largePictureBoxLikedPage.Size = new System.Drawing.Size(124, 124);
            this.largePictureBoxLikedPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.largePictureBoxLikedPage.TabIndex = 25;
            this.largePictureBoxLikedPage.TabStop = false;
            // 
            // likedPagesBindingSource
            // 
            this.likedPagesBindingSource.DataMember = "LikedPages";
            this.likedPagesBindingSource.DataSource = this.userBindingSource;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // linkLabelLikedPageURL
            // 
            this.linkLabelLikedPageURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelLikedPageURL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.likedPagesBindingSource, "URL", true));
            this.linkLabelLikedPageURL.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelLikedPageURL.Location = new System.Drawing.Point(226, 558);
            this.linkLabelLikedPageURL.Name = "linkLabelLikedPageURL";
            this.linkLabelLikedPageURL.Size = new System.Drawing.Size(102, 59);
            this.linkLabelLikedPageURL.TabIndex = 24;
            this.linkLabelLikedPageURL.TabStop = true;
            this.linkLabelLikedPageURL.Text = "linkLabel1";
            this.linkLabelLikedPageURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLikedPageURL_LinkClicked);
            // 
            // labelLikedPageName
            // 
            this.labelLikedPageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLikedPageName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.likedPagesBindingSource, "Name", true));
            this.labelLikedPageName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLikedPageName.Location = new System.Drawing.Point(226, 377);
            this.labelLikedPageName.Name = "labelLikedPageName";
            this.labelLikedPageName.Size = new System.Drawing.Size(124, 51);
            this.labelLikedPageName.TabIndex = 23;
            this.labelLikedPageName.Text = "Name Of Page";
            // 
            // listBoxLikedPage
            // 
            this.listBoxLikedPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLikedPage.DataSource = this.likedPagesBindingSource;
            this.listBoxLikedPage.DisplayMember = "Name";
            this.listBoxLikedPage.FormattingEnabled = true;
            this.listBoxLikedPage.Location = new System.Drawing.Point(28, 377);
            this.listBoxLikedPage.Name = "listBoxLikedPage";
            this.listBoxLikedPage.Size = new System.Drawing.Size(170, 212);
            this.listBoxLikedPage.TabIndex = 22;
            this.listBoxLikedPage.ValueMember = "AccessToken";
            // 
            // labelLikedPage
            // 
            this.labelLikedPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLikedPage.Font = new System.Drawing.Font("Castellar", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLikedPage.Location = new System.Drawing.Point(2, 343);
            this.labelLikedPage.Name = "labelLikedPage";
            this.labelLikedPage.Size = new System.Drawing.Size(385, 31);
            this.labelLikedPage.TabIndex = 21;
            this.labelLikedPage.Text = "Pages that {name} liked";
            this.labelLikedPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFirstName
            // 
            this.labelFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "FirstName", true));
            this.labelFirstName.Font = new System.Drawing.Font("Castellar", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFirstName.Location = new System.Drawing.Point(2, 10);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(385, 23);
            this.labelFirstName.TabIndex = 14;
            this.labelFirstName.Text = "Friend First Name";
            this.labelFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBirthday
            // 
            this.labelBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBirthday.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "Birthday", true));
            this.labelBirthday.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBirthday.Location = new System.Drawing.Point(103, 303);
            this.labelBirthday.Name = "labelBirthday";
            this.labelBirthday.Size = new System.Drawing.Size(102, 23);
            this.labelBirthday.TabIndex = 1;
            this.labelBirthday.Text = "1/1/1970";
            // 
            // largePictureBoxFriend
            // 
            this.largePictureBoxFriend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.largePictureBoxFriend.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.userBindingSource, "ImageLarge", true));
            this.largePictureBoxFriend.Location = new System.Drawing.Point(81, 70);
            this.largePictureBoxFriend.Name = "largePictureBoxFriend";
            this.largePictureBoxFriend.Size = new System.Drawing.Size(220, 220);
            this.largePictureBoxFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.largePictureBoxFriend.TabIndex = 5;
            this.largePictureBoxFriend.TabStop = false;
            // 
            // labelLastName
            // 
            this.labelLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userBindingSource, "LastName", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "String.Empty"));
            this.labelLastName.Font = new System.Drawing.Font("Castellar", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastName.Location = new System.Drawing.Point(-2, 44);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(389, 23);
            this.labelLastName.TabIndex = 14;
            this.labelLastName.Text = "Friend Last Name";
            this.labelLastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FriendDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 625);
            this.Controls.Add(this.labelBirthdayTitle);
            this.Controls.Add(this.largePictureBoxLikedPage);
            this.Controls.Add(this.largePictureBoxFriend);
            this.Controls.Add(this.linkLabelLikedPageURL);
            this.Controls.Add(this.labelBirthday);
            this.Controls.Add(this.labelLikedPageName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.listBoxLikedPage);
            this.Controls.Add(this.labelLikedPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FriendDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "friendDetails";
            ((System.ComponentModel.ISupportInitialize)(this.largePictureBoxLikedPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.likedPagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.largePictureBoxFriend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.PictureBox largePictureBoxFriend;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLikedPage;
        private System.Windows.Forms.ListBox listBoxLikedPage;
        private System.Windows.Forms.BindingSource likedPagesBindingSource;
        private System.Windows.Forms.PictureBox largePictureBoxLikedPage;
        private System.Windows.Forms.LinkLabel linkLabelLikedPageURL;
        private System.Windows.Forms.Label labelLikedPageName;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.Label labelBirthdayTitle;
        private System.Windows.Forms.Label labelLastName;
    }
}