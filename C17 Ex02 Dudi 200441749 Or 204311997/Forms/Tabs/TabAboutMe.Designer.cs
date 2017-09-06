namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms.Tabs
{
    using C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies;

    partial class TabAboutMe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelPostPhoto = new System.Windows.Forms.Panel();
            this.labelPhotoPreview = new System.Windows.Forms.Label();
            this.pictureBoxPostPhoto = new System.Windows.Forms.PictureBox();
            this.buttonPostPhoto = new System.Windows.Forms.Button();
            this.richTextBoxPostPhoto = new System.Windows.Forms.RichTextBox();
            this.buttonAddPicture = new System.Windows.Forms.Button();
            this.labelPostPhoto = new System.Windows.Forms.Label();
            this.panelLikedPage = new System.Windows.Forms.Panel();
            this.listBoxLikedPage = new System.Windows.Forms.ListBox();
            this.likedPagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.linkLabelLikedPageURL = new System.Windows.Forms.LinkLabel();
            this.buttonRefreshLikedPage = new System.Windows.Forms.Button();
            this.pictureBoxLikedPage = new System.Windows.Forms.PictureBox();
            this.panelPostStatus = new System.Windows.Forms.Panel();
            this.buttonRefreshTagFriends = new System.Windows.Forms.Button();
            this.buttonPostStatus = new System.Windows.Forms.Button();
            this.buttonClearPostTags = new System.Windows.Forms.Button();
            this.richTextBoxStatusPost = new System.Windows.Forms.RichTextBox();
            this.listBoxPostTags = new System.Windows.Forms.ListBox();
            this.friendsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelTagFriends = new System.Windows.Forms.Label();
            this.labelPostStatus = new System.Windows.Forms.Label();
            this.labelFriendTitle = new System.Windows.Forms.Label();
            this.panelFriends = new System.Windows.Forms.Panel();
            this.flowLayoutPanelExtenderForFacebookFriends = new C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies.FlowLayoutPanelExtenderForFacebookFriends();
            this.buttonRefreshFriends = new System.Windows.Forms.Button();
            this.panelLastPost = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxPostComment = new System.Windows.Forms.ListBox();
            this.listBoxPostLiked = new System.Windows.Forms.ListBox();
            this.pictureBoxLastPost = new System.Windows.Forms.PictureBox();
            this.textBoxLastPostMessage = new System.Windows.Forms.TextBox();
            this.buttonRefreshLastPost = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMyLastPost = new System.Windows.Forms.Label();
            this.panelPostPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostPhoto)).BeginInit();
            this.panelLikedPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.likedPagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikedPage)).BeginInit();
            this.panelPostStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendsBindingSource)).BeginInit();
            this.panelFriends.SuspendLayout();
            this.panelLastPost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLastPost)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPostPhoto
            // 
            this.panelPostPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPostPhoto.Controls.Add(this.labelPhotoPreview);
            this.panelPostPhoto.Controls.Add(this.pictureBoxPostPhoto);
            this.panelPostPhoto.Controls.Add(this.buttonPostPhoto);
            this.panelPostPhoto.Controls.Add(this.richTextBoxPostPhoto);
            this.panelPostPhoto.Controls.Add(this.buttonAddPicture);
            this.panelPostPhoto.Location = new System.Drawing.Point(605, 309);
            this.panelPostPhoto.Name = "panelPostPhoto";
            this.panelPostPhoto.Size = new System.Drawing.Size(465, 234);
            this.panelPostPhoto.TabIndex = 27;
            // 
            // labelPhotoPreview
            // 
            this.labelPhotoPreview.AutoSize = true;
            this.labelPhotoPreview.Location = new System.Drawing.Point(6, 106);
            this.labelPhotoPreview.Name = "labelPhotoPreview";
            this.labelPhotoPreview.Size = new System.Drawing.Size(78, 13);
            this.labelPhotoPreview.TabIndex = 15;
            this.labelPhotoPreview.Text = "Photo preview:";
            // 
            // pictureBoxPostPhoto
            // 
            this.pictureBoxPostPhoto.Location = new System.Drawing.Point(90, 105);
            this.pictureBoxPostPhoto.Name = "pictureBoxPostPhoto";
            this.pictureBoxPostPhoto.Size = new System.Drawing.Size(263, 117);
            this.pictureBoxPostPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPostPhoto.TabIndex = 14;
            this.pictureBoxPostPhoto.TabStop = false;
            // 
            // buttonPostPhoto
            // 
            this.buttonPostPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPostPhoto.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPostPhoto.Location = new System.Drawing.Point(359, 152);
            this.buttonPostPhoto.Name = "buttonPostPhoto";
            this.buttonPostPhoto.Size = new System.Drawing.Size(93, 70);
            this.buttonPostPhoto.TabIndex = 6;
            this.buttonPostPhoto.Text = "Post";
            this.buttonPostPhoto.UseVisualStyleBackColor = true;
            this.buttonPostPhoto.Click += new System.EventHandler(this.buttonPostPhoto_Click);
            // 
            // richTextBoxPostPhoto
            // 
            this.richTextBoxPostPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxPostPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxPostPhoto.Location = new System.Drawing.Point(6, 3);
            this.richTextBoxPostPhoto.Name = "richTextBoxPostPhoto";
            this.richTextBoxPostPhoto.Size = new System.Drawing.Size(351, 96);
            this.richTextBoxPostPhoto.TabIndex = 10;
            this.richTextBoxPostPhoto.Text = "";
            // 
            // buttonAddPicture
            // 
            this.buttonAddPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddPicture.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPicture.Location = new System.Drawing.Point(363, 3);
            this.buttonAddPicture.Name = "buttonAddPicture";
            this.buttonAddPicture.Size = new System.Drawing.Size(89, 31);
            this.buttonAddPicture.TabIndex = 13;
            this.buttonAddPicture.Text = "Import photo";
            this.buttonAddPicture.UseVisualStyleBackColor = true;
            this.buttonAddPicture.Click += new System.EventHandler(this.buttonAddPicture_Click);
            // 
            // labelPostPhoto
            // 
            this.labelPostPhoto.AutoSize = true;
            this.labelPostPhoto.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostPhoto.Location = new System.Drawing.Point(605, 281);
            this.labelPostPhoto.Name = "labelPostPhoto";
            this.labelPostPhoto.Size = new System.Drawing.Size(177, 23);
            this.labelPostPhoto.TabIndex = 26;
            this.labelPostPhoto.Text = "Post A Photo";
            this.labelPostPhoto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelLikedPage
            // 
            this.panelLikedPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLikedPage.Controls.Add(this.listBoxLikedPage);
            this.panelLikedPage.Controls.Add(this.linkLabelLikedPageURL);
            this.panelLikedPage.Controls.Add(this.buttonRefreshLikedPage);
            this.panelLikedPage.Controls.Add(this.pictureBoxLikedPage);
            this.panelLikedPage.Location = new System.Drawing.Point(281, 40);
            this.panelLikedPage.Name = "panelLikedPage";
            this.panelLikedPage.Size = new System.Drawing.Size(287, 230);
            this.panelLikedPage.TabIndex = 29;
            // 
            // listBoxLikedPage
            // 
            this.listBoxLikedPage.DataSource = this.likedPagesBindingSource;
            this.listBoxLikedPage.DisplayMember = "Name";
            this.listBoxLikedPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxLikedPage.FormattingEnabled = true;
            this.listBoxLikedPage.Location = new System.Drawing.Point(0, 0);
            this.listBoxLikedPage.Name = "listBoxLikedPage";
            this.listBoxLikedPage.Size = new System.Drawing.Size(155, 226);
            this.listBoxLikedPage.TabIndex = 8;
            this.listBoxLikedPage.ValueMember = "AccessToken";
            // 
            // likedPagesBindingSource
            // 
            this.likedPagesBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Page);
            // 
            // linkLabelLikedPageURL
            // 
            this.linkLabelLikedPageURL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.likedPagesBindingSource, "Name", true));
            this.linkLabelLikedPageURL.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.likedPagesBindingSource, "URL", true));
            this.linkLabelLikedPageURL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelLikedPageURL.Location = new System.Drawing.Point(161, 4);
            this.linkLabelLikedPageURL.Name = "linkLabelLikedPageURL";
            this.linkLabelLikedPageURL.Size = new System.Drawing.Size(119, 66);
            this.linkLabelLikedPageURL.TabIndex = 10;
            this.linkLabelLikedPageURL.TabStop = true;
            this.linkLabelLikedPageURL.Text = "Page name with link";
            this.linkLabelLikedPageURL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelLikedPageURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLikedPageURL_LinkClicked);
            // 
            // buttonRefreshLikedPage
            // 
            this.buttonRefreshLikedPage.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefreshLikedPage.Location = new System.Drawing.Point(161, 198);
            this.buttonRefreshLikedPage.Name = "buttonRefreshLikedPage";
            this.buttonRefreshLikedPage.Size = new System.Drawing.Size(119, 25);
            this.buttonRefreshLikedPage.TabIndex = 10;
            this.buttonRefreshLikedPage.Text = "Refresh Pages";
            this.buttonRefreshLikedPage.UseVisualStyleBackColor = true;
            this.buttonRefreshLikedPage.Click += new System.EventHandler(this.buttonRefreshLikedPage_Click);
            // 
            // pictureBoxLikedPage
            // 
            this.pictureBoxLikedPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLikedPage.DataBindings.Add(new System.Windows.Forms.Binding("ImageLocation", this.likedPagesBindingSource, "PictureSqaureURL", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.pictureBoxLikedPage.ErrorImage = global::C17_Ex01_Dudi_200441749_Or_204311997.Properties.Resources.Picture_not_found;
            this.pictureBoxLikedPage.InitialImage = global::C17_Ex01_Dudi_200441749_Or_204311997.Properties.Resources.LoadingPhoto;
            this.pictureBoxLikedPage.Location = new System.Drawing.Point(161, 73);
            this.pictureBoxLikedPage.Name = "pictureBoxLikedPage";
            this.pictureBoxLikedPage.Size = new System.Drawing.Size(119, 119);
            this.pictureBoxLikedPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLikedPage.TabIndex = 9;
            this.pictureBoxLikedPage.TabStop = false;
            // 
            // panelPostStatus
            // 
            this.panelPostStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPostStatus.Controls.Add(this.buttonRefreshTagFriends);
            this.panelPostStatus.Controls.Add(this.buttonPostStatus);
            this.panelPostStatus.Controls.Add(this.buttonClearPostTags);
            this.panelPostStatus.Controls.Add(this.richTextBoxStatusPost);
            this.panelPostStatus.Controls.Add(this.listBoxPostTags);
            this.panelPostStatus.Controls.Add(this.labelTagFriends);
            this.panelPostStatus.Location = new System.Drawing.Point(605, 40);
            this.panelPostStatus.Name = "panelPostStatus";
            this.panelPostStatus.Size = new System.Drawing.Size(465, 230);
            this.panelPostStatus.TabIndex = 25;
            // 
            // buttonRefreshTagFriends
            // 
            this.buttonRefreshTagFriends.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefreshTagFriends.Location = new System.Drawing.Point(134, 166);
            this.buttonRefreshTagFriends.Name = "buttonRefreshTagFriends";
            this.buttonRefreshTagFriends.Size = new System.Drawing.Size(102, 25);
            this.buttonRefreshTagFriends.TabIndex = 21;
            this.buttonRefreshTagFriends.Text = "Refresh Friends";
            this.buttonRefreshTagFriends.UseVisualStyleBackColor = true;
            this.buttonRefreshTagFriends.Click += new System.EventHandler(this.buttonRefreshTagFriends_Click);
            // 
            // buttonPostStatus
            // 
            this.buttonPostStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPostStatus.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPostStatus.Location = new System.Drawing.Point(365, 152);
            this.buttonPostStatus.Name = "buttonPostStatus";
            this.buttonPostStatus.Size = new System.Drawing.Size(93, 70);
            this.buttonPostStatus.TabIndex = 6;
            this.buttonPostStatus.Text = "Post";
            this.buttonPostStatus.UseVisualStyleBackColor = true;
            this.buttonPostStatus.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonClearPostTags
            // 
            this.buttonClearPostTags.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearPostTags.Location = new System.Drawing.Point(134, 197);
            this.buttonClearPostTags.Name = "buttonClearPostTags";
            this.buttonClearPostTags.Size = new System.Drawing.Size(102, 25);
            this.buttonClearPostTags.TabIndex = 20;
            this.buttonClearPostTags.Text = "Clear Tags";
            this.buttonClearPostTags.UseVisualStyleBackColor = true;
            this.buttonClearPostTags.Click += new System.EventHandler(this.buttonClearPostTags_Click);
            // 
            // richTextBoxStatusPost
            // 
            this.richTextBoxStatusPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxStatusPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxStatusPost.Location = new System.Drawing.Point(6, 6);
            this.richTextBoxStatusPost.Name = "richTextBoxStatusPost";
            this.richTextBoxStatusPost.Size = new System.Drawing.Size(452, 96);
            this.richTextBoxStatusPost.TabIndex = 10;
            this.richTextBoxStatusPost.Text = "";
            // 
            // listBoxPostTags
            // 
            this.listBoxPostTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxPostTags.DataSource = this.friendsBindingSource;
            this.listBoxPostTags.DisplayMember = "Name";
            this.listBoxPostTags.FormattingEnabled = true;
            this.listBoxPostTags.Location = new System.Drawing.Point(11, 128);
            this.listBoxPostTags.Name = "listBoxPostTags";
            this.listBoxPostTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxPostTags.Size = new System.Drawing.Size(117, 93);
            this.listBoxPostTags.TabIndex = 8;
            this.listBoxPostTags.ValueMember = "Albums";
            // 
            // friendsBindingSource
            // 
            this.friendsBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // labelTagFriends
            // 
            this.labelTagFriends.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTagFriends.AutoSize = true;
            this.labelTagFriends.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTagFriends.Location = new System.Drawing.Point(8, 111);
            this.labelTagFriends.Name = "labelTagFriends";
            this.labelTagFriends.Size = new System.Drawing.Size(72, 15);
            this.labelTagFriends.TabIndex = 12;
            this.labelTagFriends.Text = "Tag Friends";
            // 
            // labelPostStatus
            // 
            this.labelPostStatus.AutoSize = true;
            this.labelPostStatus.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostStatus.Location = new System.Drawing.Point(605, 10);
            this.labelPostStatus.Name = "labelPostStatus";
            this.labelPostStatus.Size = new System.Drawing.Size(180, 23);
            this.labelPostStatus.TabIndex = 21;
            this.labelPostStatus.Text = "Post A Status";
            this.labelPostStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelFriendTitle
            // 
            this.labelFriendTitle.AutoSize = true;
            this.labelFriendTitle.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendTitle.Location = new System.Drawing.Point(0, 5);
            this.labelFriendTitle.Name = "labelFriendTitle";
            this.labelFriendTitle.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelFriendTitle.Size = new System.Drawing.Size(148, 28);
            this.labelFriendTitle.TabIndex = 20;
            this.labelFriendTitle.Text = "My Friends";
            this.labelFriendTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelFriends
            // 
            this.panelFriends.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFriends.Controls.Add(this.flowLayoutPanelExtenderForFacebookFriends);
            this.panelFriends.Controls.Add(this.buttonRefreshFriends);
            this.panelFriends.Location = new System.Drawing.Point(5, 38);
            this.panelFriends.Name = "panelFriends";
            this.panelFriends.Size = new System.Drawing.Size(261, 505);
            this.panelFriends.TabIndex = 22;
            // 
            // flowLayoutPanelExtenderForFacebookFriends
            // 
            this.flowLayoutPanelExtenderForFacebookFriends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelExtenderForFacebookFriends.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelExtenderForFacebookFriends.Name = "flowLayoutPanelExtenderForFacebookFriends";
            this.flowLayoutPanelExtenderForFacebookFriends.Size = new System.Drawing.Size(257, 471);
            this.flowLayoutPanelExtenderForFacebookFriends.TabIndex = 9;
            // 
            // buttonRefreshFriends
            // 
            this.buttonRefreshFriends.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonRefreshFriends.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefreshFriends.Location = new System.Drawing.Point(0, 471);
            this.buttonRefreshFriends.Name = "buttonRefreshFriends";
            this.buttonRefreshFriends.Size = new System.Drawing.Size(257, 30);
            this.buttonRefreshFriends.TabIndex = 8;
            this.buttonRefreshFriends.Text = "Refresh Friends";
            this.buttonRefreshFriends.UseVisualStyleBackColor = true;
            this.buttonRefreshFriends.Click += new System.EventHandler(this.buttonRefreshFriends_Click);
            // 
            // panelLastPost
            // 
            this.panelLastPost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLastPost.Controls.Add(this.label4);
            this.panelLastPost.Controls.Add(this.label3);
            this.panelLastPost.Controls.Add(this.listBoxPostComment);
            this.panelLastPost.Controls.Add(this.listBoxPostLiked);
            this.panelLastPost.Controls.Add(this.pictureBoxLastPost);
            this.panelLastPost.Controls.Add(this.textBoxLastPostMessage);
            this.panelLastPost.Controls.Add(this.buttonRefreshLastPost);
            this.panelLastPost.Location = new System.Drawing.Point(281, 309);
            this.panelLastPost.Name = "panelLastPost";
            this.panelLastPost.Size = new System.Drawing.Size(287, 234);
            this.panelLastPost.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Comments:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Likes:";
            // 
            // listBoxPostComment
            // 
            this.listBoxPostComment.FormattingEnabled = true;
            this.listBoxPostComment.Location = new System.Drawing.Point(104, 102);
            this.listBoxPostComment.Name = "listBoxPostComment";
            this.listBoxPostComment.Size = new System.Drawing.Size(170, 95);
            this.listBoxPostComment.TabIndex = 20;
            this.listBoxPostComment.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPostComment_MouseDoubleClick);
            // 
            // listBoxPostLiked
            // 
            this.listBoxPostLiked.FormattingEnabled = true;
            this.listBoxPostLiked.Location = new System.Drawing.Point(7, 102);
            this.listBoxPostLiked.Name = "listBoxPostLiked";
            this.listBoxPostLiked.Size = new System.Drawing.Size(91, 95);
            this.listBoxPostLiked.TabIndex = 11;
            this.listBoxPostLiked.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPostLiked_MouseDoubleClick);
            // 
            // pictureBoxLastPost
            // 
            this.pictureBoxLastPost.Location = new System.Drawing.Point(7, 3);
            this.pictureBoxLastPost.Name = "pictureBoxLastPost";
            this.pictureBoxLastPost.Size = new System.Drawing.Size(137, 77);
            this.pictureBoxLastPost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLastPost.TabIndex = 9;
            this.pictureBoxLastPost.TabStop = false;
            this.pictureBoxLastPost.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLastPost_MouseDoubleClick);
            // 
            // textBoxLastPostMessage
            // 
            this.textBoxLastPostMessage.Location = new System.Drawing.Point(150, 3);
            this.textBoxLastPostMessage.Multiline = true;
            this.textBoxLastPostMessage.Name = "textBoxLastPostMessage";
            this.textBoxLastPostMessage.Size = new System.Drawing.Size(124, 77);
            this.textBoxLastPostMessage.TabIndex = 19;
            // 
            // buttonRefreshLastPost
            // 
            this.buttonRefreshLastPost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonRefreshLastPost.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefreshLastPost.Location = new System.Drawing.Point(0, 200);
            this.buttonRefreshLastPost.Name = "buttonRefreshLastPost";
            this.buttonRefreshLastPost.Size = new System.Drawing.Size(283, 30);
            this.buttonRefreshLastPost.TabIndex = 10;
            this.buttonRefreshLastPost.Text = "Refresh Post";
            this.buttonRefreshLastPost.UseVisualStyleBackColor = true;
            this.buttonRefreshLastPost.Click += new System.EventHandler(this.buttonRefreshLastPost_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(281, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 23);
            this.label5.TabIndex = 24;
            this.label5.Text = "Pages liked";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelMyLastPost
            // 
            this.labelMyLastPost.AutoSize = true;
            this.labelMyLastPost.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold);
            this.labelMyLastPost.Location = new System.Drawing.Point(281, 281);
            this.labelMyLastPost.Name = "labelMyLastPost";
            this.labelMyLastPost.Size = new System.Drawing.Size(278, 23);
            this.labelMyLastPost.TabIndex = 28;
            this.labelMyLastPost.Text = "My most recent post";
            this.labelMyLastPost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TabAboutMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panelPostPhoto);
            this.Controls.Add(this.labelPostPhoto);
            this.Controls.Add(this.panelLikedPage);
            this.Controls.Add(this.panelPostStatus);
            this.Controls.Add(this.labelPostStatus);
            this.Controls.Add(this.labelFriendTitle);
            this.Controls.Add(this.panelFriends);
            this.Controls.Add(this.panelLastPost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelMyLastPost);
            this.Name = "TabAboutMe";
            this.Size = new System.Drawing.Size(1075, 549);
            this.panelPostPhoto.ResumeLayout(false);
            this.panelPostPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostPhoto)).EndInit();
            this.panelLikedPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.likedPagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikedPage)).EndInit();
            this.panelPostStatus.ResumeLayout(false);
            this.panelPostStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.friendsBindingSource)).EndInit();
            this.panelFriends.ResumeLayout(false);
            this.panelLastPost.ResumeLayout(false);
            this.panelLastPost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLastPost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPostPhoto;
        private System.Windows.Forms.Label labelPhotoPreview;
        private System.Windows.Forms.PictureBox pictureBoxPostPhoto;
        private System.Windows.Forms.Button buttonPostPhoto;
        private System.Windows.Forms.RichTextBox richTextBoxPostPhoto;
        private System.Windows.Forms.Button buttonAddPicture;
        private System.Windows.Forms.Label labelPostPhoto;
        private System.Windows.Forms.Panel panelLikedPage;
        private System.Windows.Forms.LinkLabel linkLabelLikedPageURL;
        private System.Windows.Forms.Button buttonRefreshLikedPage;
        private System.Windows.Forms.PictureBox pictureBoxLikedPage;
        private System.Windows.Forms.Panel panelPostStatus;
        private System.Windows.Forms.Button buttonRefreshTagFriends;
        private System.Windows.Forms.Button buttonPostStatus;
        private System.Windows.Forms.Button buttonClearPostTags;
        private System.Windows.Forms.RichTextBox richTextBoxStatusPost;
        private System.Windows.Forms.ListBox listBoxPostTags;
        private System.Windows.Forms.Label labelTagFriends;
        private System.Windows.Forms.Label labelPostStatus;
        private System.Windows.Forms.Label labelFriendTitle;
        private System.Windows.Forms.Panel panelFriends;
        private System.Windows.Forms.Button buttonRefreshFriends;
        private System.Windows.Forms.Panel panelLastPost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxPostComment;
        private System.Windows.Forms.ListBox listBoxPostLiked;
        private System.Windows.Forms.PictureBox pictureBoxLastPost;
        private System.Windows.Forms.TextBox textBoxLastPostMessage;
        private System.Windows.Forms.Button buttonRefreshLastPost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMyLastPost;
        private System.Windows.Forms.ListBox listBoxLikedPage;
        private System.Windows.Forms.BindingSource likedPagesBindingSource;
        private System.Windows.Forms.BindingSource friendsBindingSource;
        private FlowLayoutPanelExtenderForFacebookFriends flowLayoutPanelExtenderForFacebookFriends;
    }
}
