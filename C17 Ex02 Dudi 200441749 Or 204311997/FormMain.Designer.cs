namespace C17_Ex01_Dudi_200441749_Or_204311997
{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonFetchPhotosOfFriendIAmTaggedIn = new System.Windows.Forms.Button();
            this.buttonFetchTaggedTogether = new System.Windows.Forms.Button();
            this.buttonFetchMyPhotosFriendIsIn = new System.Windows.Forms.Button();
            this.pictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.pictureBoxMostRecentTaggedTogether = new System.Windows.Forms.PictureBox();
            this.pictureBoxCoverPhoto = new System.Windows.Forms.PictureBox();
            this.tabPageFriendshipAnalyzer = new System.Windows.Forms.TabPage();
            this.panelGeneralInfo = new System.Windows.Forms.Panel();
            this.buttonFetchGeneralData = new System.Windows.Forms.Button();
            this.labelNumComments = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelNumLikes = new System.Windows.Forms.Label();
            this.treeViewTaggedTogether = new System.Windows.Forms.TreeView();
            this.treeViewPhotosOfFriendInMyPhotos = new System.Windows.Forms.TreeView();
            this.treeViewPhotosOfFriendIAmTaggedIn = new System.Windows.Forms.TreeView();
            this.flowLayoutPanelFriendshipAnalyzer = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageDataTables = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonFetchData = new System.Windows.Forms.Button();
            this.comboBoxDataTableBindingSelection = new System.Windows.Forms.ComboBox();
            this.tabPageAboutMe = new System.Windows.Forms.TabPage();
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
            this.friendsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.linkLabelLikedPageURL = new System.Windows.Forms.LinkLabel();
            this.labelLikedPageName = new System.Windows.Forms.Label();
            this.buttonRefreshLikedPage = new System.Windows.Forms.Button();
            this.pictureBoxLikedPage = new System.Windows.Forms.PictureBox();
            this.panelPostStatus = new System.Windows.Forms.Panel();
            this.buttonRefreshTagFriends = new System.Windows.Forms.Button();
            this.buttonPostStatus = new System.Windows.Forms.Button();
            this.buttonClearPostTags = new System.Windows.Forms.Button();
            this.richTextBoxStatusPost = new System.Windows.Forms.RichTextBox();
            this.listBoxPostTags = new System.Windows.Forms.ListBox();
            this.labelTagFriends = new System.Windows.Forms.Label();
            this.labelPostStatus = new System.Windows.Forms.Label();
            this.labelFriendTitle = new System.Windows.Forms.Label();
            this.panelFriends = new System.Windows.Forms.Panel();
            this.buttonRefreshFriends = new System.Windows.Forms.Button();
            this.flowLayoutPanelAboutMeFriends = new System.Windows.Forms.FlowLayoutPanel();
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
            this.tabControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMostRecentTaggedTogether)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPhoto)).BeginInit();
            this.tabPageFriendshipAnalyzer.SuspendLayout();
            this.panelGeneralInfo.SuspendLayout();
            this.tabPageDataTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPageAboutMe.SuspendLayout();
            this.panelPostPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostPhoto)).BeginInit();
            this.panelLikedPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.likedPagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikedPage)).BeginInit();
            this.panelPostStatus.SuspendLayout();
            this.panelFriends.SuspendLayout();
            this.panelLastPost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLastPost)).BeginInit();
            this.tabControl.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Most recent photo tagged together";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogout.Location = new System.Drawing.Point(1035, 15);
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
            this.buttonExit.Location = new System.Drawing.Point(1107, 15);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(67, 26);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonFetchPhotosOfFriendIAmTaggedIn
            // 
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Location = new System.Drawing.Point(774, 4);
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Name = "buttonFetchPhotosOfFriendIAmTaggedIn";
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Size = new System.Drawing.Size(248, 30);
            this.buttonFetchPhotosOfFriendIAmTaggedIn.TabIndex = 10;
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Text = "Fetch Friend\'s Photos I am Tagged in";
            this.buttonFetchPhotosOfFriendIAmTaggedIn.UseVisualStyleBackColor = true;
            this.buttonFetchPhotosOfFriendIAmTaggedIn.Click += new System.EventHandler(this.buttonFetchPhotosOfFriendIAmTaggedIn_Click);
            // 
            // buttonFetchTaggedTogether
            // 
            this.buttonFetchTaggedTogether.Location = new System.Drawing.Point(520, 4);
            this.buttonFetchTaggedTogether.Name = "buttonFetchTaggedTogether";
            this.buttonFetchTaggedTogether.Size = new System.Drawing.Size(248, 30);
            this.buttonFetchTaggedTogether.TabIndex = 8;
            this.buttonFetchTaggedTogether.Text = "Fetch photos tagged together";
            this.buttonFetchTaggedTogether.UseVisualStyleBackColor = true;
            this.buttonFetchTaggedTogether.Click += new System.EventHandler(this.buttonFetchTaggedTogether_Click);
            // 
            // buttonFetchMyPhotosFriendIsIn
            // 
            this.buttonFetchMyPhotosFriendIsIn.Location = new System.Drawing.Point(266, 4);
            this.buttonFetchMyPhotosFriendIsIn.Name = "buttonFetchMyPhotosFriendIsIn";
            this.buttonFetchMyPhotosFriendIsIn.Size = new System.Drawing.Size(248, 30);
            this.buttonFetchMyPhotosFriendIsIn.TabIndex = 5;
            this.buttonFetchMyPhotosFriendIsIn.Text = "Fetch photos of mine {friend} is in";
            this.buttonFetchMyPhotosFriendIsIn.UseVisualStyleBackColor = true;
            this.buttonFetchMyPhotosFriendIsIn.Click += new System.EventHandler(this.buttonFetchMyPhotosFriendIsIn_Click);
            // 
            // pictureBoxProfilePicture
            // 
            this.pictureBoxProfilePicture.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxProfilePicture.Image")));
            this.pictureBoxProfilePicture.Location = new System.Drawing.Point(25, 84);
            this.pictureBoxProfilePicture.Name = "pictureBoxProfilePicture";
            this.pictureBoxProfilePicture.Padding = new System.Windows.Forms.Padding(1);
            this.pictureBoxProfilePicture.Size = new System.Drawing.Size(81, 79);
            this.pictureBoxProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfilePicture.TabIndex = 2;
            this.pictureBoxProfilePicture.TabStop = false;
            // 
            // pictureBoxMostRecentTaggedTogether
            // 
            this.pictureBoxMostRecentTaggedTogether.Location = new System.Drawing.Point(16, 293);
            this.pictureBoxMostRecentTaggedTogether.Name = "pictureBoxMostRecentTaggedTogether";
            this.pictureBoxMostRecentTaggedTogether.Size = new System.Drawing.Size(209, 135);
            this.pictureBoxMostRecentTaggedTogether.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMostRecentTaggedTogether.TabIndex = 9;
            this.pictureBoxMostRecentTaggedTogether.TabStop = false;
            this.pictureBoxMostRecentTaggedTogether.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMostRecentTaggedTogether_MouseClick);
            this.pictureBoxMostRecentTaggedTogether.MouseLeave += new System.EventHandler(this.pictureBoxMostRecentTaggedTogether_MouseLeave);
            this.pictureBoxMostRecentTaggedTogether.MouseHover += new System.EventHandler(this.pictureBoxMostRecentTaggedTogether_MouseHover);
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
            // tabPageFriendshipAnalyzer
            // 
            this.tabPageFriendshipAnalyzer.AutoScroll = true;
            this.tabPageFriendshipAnalyzer.Controls.Add(this.panelGeneralInfo);
            this.tabPageFriendshipAnalyzer.Controls.Add(this.flowLayoutPanelFriendshipAnalyzer);
            this.tabPageFriendshipAnalyzer.Location = new System.Drawing.Point(4, 29);
            this.tabPageFriendshipAnalyzer.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageFriendshipAnalyzer.Name = "tabPageFriendshipAnalyzer";
            this.tabPageFriendshipAnalyzer.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageFriendshipAnalyzer.Size = new System.Drawing.Size(1164, 549);
            this.tabPageFriendshipAnalyzer.TabIndex = 2;
            this.tabPageFriendshipAnalyzer.Text = "Friendship Analyzer";
            this.tabPageFriendshipAnalyzer.UseVisualStyleBackColor = true;
            // 
            // panelGeneralInfo
            // 
            this.panelGeneralInfo.Controls.Add(this.buttonFetchGeneralData);
            this.panelGeneralInfo.Controls.Add(this.labelNumComments);
            this.panelGeneralInfo.Controls.Add(this.pictureBoxMostRecentTaggedTogether);
            this.panelGeneralInfo.Controls.Add(this.labelLastName);
            this.panelGeneralInfo.Controls.Add(this.labelFirstName);
            this.panelGeneralInfo.Controls.Add(this.buttonFetchMyPhotosFriendIsIn);
            this.panelGeneralInfo.Controls.Add(this.buttonFetchTaggedTogether);
            this.panelGeneralInfo.Controls.Add(this.labelNumLikes);
            this.panelGeneralInfo.Controls.Add(this.label1);
            this.panelGeneralInfo.Controls.Add(this.buttonFetchPhotosOfFriendIAmTaggedIn);
            this.panelGeneralInfo.Controls.Add(this.treeViewTaggedTogether);
            this.panelGeneralInfo.Controls.Add(this.treeViewPhotosOfFriendInMyPhotos);
            this.panelGeneralInfo.Controls.Add(this.treeViewPhotosOfFriendIAmTaggedIn);
            this.panelGeneralInfo.Location = new System.Drawing.Point(135, 5);
            this.panelGeneralInfo.Name = "panelGeneralInfo";
            this.panelGeneralInfo.Size = new System.Drawing.Size(1026, 541);
            this.panelGeneralInfo.TabIndex = 1;
            this.panelGeneralInfo.Visible = false;
            // 
            // buttonFetchGeneralData
            // 
            this.buttonFetchGeneralData.Location = new System.Drawing.Point(16, 127);
            this.buttonFetchGeneralData.Name = "buttonFetchGeneralData";
            this.buttonFetchGeneralData.Size = new System.Drawing.Size(113, 23);
            this.buttonFetchGeneralData.TabIndex = 13;
            this.buttonFetchGeneralData.Text = "Fetch Statistics";
            this.buttonFetchGeneralData.UseVisualStyleBackColor = true;
            this.buttonFetchGeneralData.Click += new System.EventHandler(this.buttonFetchGeneralData_Click);
            // 
            // labelNumComments
            // 
            this.labelNumComments.Location = new System.Drawing.Point(13, 216);
            this.labelNumComments.Name = "labelNumComments";
            this.labelNumComments.Size = new System.Drawing.Size(247, 32);
            this.labelNumComments.TabIndex = 3;
            this.labelNumComments.Text = "Number of times {0} commented on my photos";
            this.labelNumComments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLastName
            // 
            this.labelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelLastName.Location = new System.Drawing.Point(11, 61);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(253, 35);
            this.labelLastName.TabIndex = 1;
            this.labelLastName.Text = "Last Name";
            // 
            // labelFirstName
            // 
            this.labelFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFirstName.Location = new System.Drawing.Point(11, 26);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(253, 35);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "First Name";
            // 
            // labelNumLikes
            // 
            this.labelNumLikes.Location = new System.Drawing.Point(13, 165);
            this.labelNumLikes.Name = "labelNumLikes";
            this.labelNumLikes.Size = new System.Drawing.Size(247, 32);
            this.labelNumLikes.TabIndex = 2;
            this.labelNumLikes.Text = "Number of times {0} liked my photos";
            this.labelNumLikes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeViewTaggedTogether
            // 
            this.treeViewTaggedTogether.Location = new System.Drawing.Point(520, 41);
            this.treeViewTaggedTogether.Name = "treeViewTaggedTogether";
            this.treeViewTaggedTogether.Size = new System.Drawing.Size(248, 499);
            this.treeViewTaggedTogether.TabIndex = 9;
            this.treeViewTaggedTogether.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewTaggedTogether_NodeMouseDoubleClick);
            // 
            // treeViewPhotosOfFriendInMyPhotos
            // 
            this.treeViewPhotosOfFriendInMyPhotos.Location = new System.Drawing.Point(266, 40);
            this.treeViewPhotosOfFriendInMyPhotos.Name = "treeViewPhotosOfFriendInMyPhotos";
            this.treeViewPhotosOfFriendInMyPhotos.Size = new System.Drawing.Size(248, 499);
            this.treeViewPhotosOfFriendInMyPhotos.TabIndex = 6;
            this.treeViewPhotosOfFriendInMyPhotos.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewPhotosOfFriendInMyPhotos_NodeMouseDoubleClick);
            // 
            // treeViewPhotosOfFriendIAmTaggedIn
            // 
            this.treeViewPhotosOfFriendIAmTaggedIn.Location = new System.Drawing.Point(774, 40);
            this.treeViewPhotosOfFriendIAmTaggedIn.Name = "treeViewPhotosOfFriendIAmTaggedIn";
            this.treeViewPhotosOfFriendIAmTaggedIn.Size = new System.Drawing.Size(248, 499);
            this.treeViewPhotosOfFriendIAmTaggedIn.TabIndex = 11;
            this.treeViewPhotosOfFriendIAmTaggedIn.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewPhotosOfFriendIAmTaggedIn_NodeMouseDoubleClick);
            // 
            // flowLayoutPanelFriendshipAnalyzer
            // 
            this.flowLayoutPanelFriendshipAnalyzer.AutoScroll = true;
            this.flowLayoutPanelFriendshipAnalyzer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelFriendshipAnalyzer.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelFriendshipAnalyzer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelFriendshipAnalyzer.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanelFriendshipAnalyzer.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelFriendshipAnalyzer.Name = "flowLayoutPanelFriendshipAnalyzer";
            this.flowLayoutPanelFriendshipAnalyzer.Size = new System.Drawing.Size(130, 545);
            this.flowLayoutPanelFriendshipAnalyzer.TabIndex = 0;
            // 
            // tabPageDataTables
            // 
            this.tabPageDataTables.Controls.Add(this.dataGridView);
            this.tabPageDataTables.Controls.Add(this.buttonFetchData);
            this.tabPageDataTables.Controls.Add(this.comboBoxDataTableBindingSelection);
            this.tabPageDataTables.Location = new System.Drawing.Point(4, 29);
            this.tabPageDataTables.Name = "tabPageDataTables";
            this.tabPageDataTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataTables.Size = new System.Drawing.Size(1164, 549);
            this.tabPageDataTables.TabIndex = 1;
            this.tabPageDataTables.Text = "Data Tables";
            this.tabPageDataTables.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 39);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(1158, 507);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
            // 
            // buttonFetchData
            // 
            this.buttonFetchData.Location = new System.Drawing.Point(159, 8);
            this.buttonFetchData.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFetchData.Name = "buttonFetchData";
            this.buttonFetchData.Size = new System.Drawing.Size(79, 28);
            this.buttonFetchData.TabIndex = 2;
            this.buttonFetchData.Text = "Fetch Data";
            this.buttonFetchData.UseVisualStyleBackColor = true;
            this.buttonFetchData.Click += new System.EventHandler(this.buttonFetchData_Click);
            // 
            // comboBoxDataTableBindingSelection
            // 
            this.comboBoxDataTableBindingSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataTableBindingSelection.FormattingEnabled = true;
            this.comboBoxDataTableBindingSelection.Location = new System.Drawing.Point(7, 12);
            this.comboBoxDataTableBindingSelection.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxDataTableBindingSelection.Name = "comboBoxDataTableBindingSelection";
            this.comboBoxDataTableBindingSelection.Size = new System.Drawing.Size(149, 21);
            this.comboBoxDataTableBindingSelection.TabIndex = 1;
            // 
            // tabPageAboutMe
            // 
            this.tabPageAboutMe.AutoScroll = true;
            this.tabPageAboutMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageAboutMe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageAboutMe.Controls.Add(this.panelPostPhoto);
            this.tabPageAboutMe.Controls.Add(this.labelPostPhoto);
            this.tabPageAboutMe.Controls.Add(this.panelLikedPage);
            this.tabPageAboutMe.Controls.Add(this.panelPostStatus);
            this.tabPageAboutMe.Controls.Add(this.labelPostStatus);
            this.tabPageAboutMe.Controls.Add(this.labelFriendTitle);
            this.tabPageAboutMe.Controls.Add(this.panelFriends);
            this.tabPageAboutMe.Controls.Add(this.panelLastPost);
            this.tabPageAboutMe.Controls.Add(this.label5);
            this.tabPageAboutMe.Controls.Add(this.labelMyLastPost);
            this.tabPageAboutMe.Location = new System.Drawing.Point(4, 29);
            this.tabPageAboutMe.Name = "tabPageAboutMe";
            this.tabPageAboutMe.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAboutMe.Size = new System.Drawing.Size(1164, 549);
            this.tabPageAboutMe.TabIndex = 0;
            this.tabPageAboutMe.Text = "About Me";
            this.tabPageAboutMe.UseVisualStyleBackColor = true;
            // 
            // panelPostPhoto
            // 
            this.panelPostPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPostPhoto.Controls.Add(this.labelPhotoPreview);
            this.panelPostPhoto.Controls.Add(this.pictureBoxPostPhoto);
            this.panelPostPhoto.Controls.Add(this.buttonPostPhoto);
            this.panelPostPhoto.Controls.Add(this.richTextBoxPostPhoto);
            this.panelPostPhoto.Controls.Add(this.buttonAddPicture);
            this.panelPostPhoto.Location = new System.Drawing.Point(622, 310);
            this.panelPostPhoto.Name = "panelPostPhoto";
            this.panelPostPhoto.Size = new System.Drawing.Size(465, 229);
            this.panelPostPhoto.TabIndex = 13;
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
            this.labelPostPhoto.Location = new System.Drawing.Point(646, 279);
            this.labelPostPhoto.Name = "labelPostPhoto";
            this.labelPostPhoto.Size = new System.Drawing.Size(177, 23);
            this.labelPostPhoto.TabIndex = 12;
            this.labelPostPhoto.Text = "Post A Photo";
            this.labelPostPhoto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelLikedPage
            // 
            this.panelLikedPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLikedPage.Controls.Add(this.listBoxLikedPage);
            this.panelLikedPage.Controls.Add(this.linkLabelLikedPageURL);
            this.panelLikedPage.Controls.Add(this.labelLikedPageName);
            this.panelLikedPage.Controls.Add(this.buttonRefreshLikedPage);
            this.panelLikedPage.Controls.Add(this.pictureBoxLikedPage);
            this.panelLikedPage.Location = new System.Drawing.Point(298, 41);
            this.panelLikedPage.Name = "panelLikedPage";
            this.panelLikedPage.Size = new System.Drawing.Size(287, 215);
            this.panelLikedPage.TabIndex = 19;
            // 
            // listBoxLikedPage
            // 
            this.listBoxLikedPage.DataSource = this.likedPagesBindingSource;
            this.listBoxLikedPage.DisplayMember = "Name";
            this.listBoxLikedPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxLikedPage.FormattingEnabled = true;
            this.listBoxLikedPage.Location = new System.Drawing.Point(0, 0);
            this.listBoxLikedPage.Name = "listBoxLikedPage";
            this.listBoxLikedPage.Size = new System.Drawing.Size(155, 211);
            this.listBoxLikedPage.TabIndex = 8;
            this.listBoxLikedPage.ValueMember = "AccessToken";
            // 
            // likedPagesBindingSource
            // 
            this.likedPagesBindingSource.DataMember = "LikedPages";
            this.likedPagesBindingSource.DataSource = this.friendsBindingSource;
            // 
            // friendsBindingSource
            // 
            this.friendsBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // linkLabelLikedPageURL
            // 
            this.linkLabelLikedPageURL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.likedPagesBindingSource, "URL", true));
            this.linkLabelLikedPageURL.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelLikedPageURL.Location = new System.Drawing.Point(174, 158);
            this.linkLabelLikedPageURL.Name = "linkLabelLikedPageURL";
            this.linkLabelLikedPageURL.Size = new System.Drawing.Size(100, 23);
            this.linkLabelLikedPageURL.TabIndex = 10;
            this.linkLabelLikedPageURL.TabStop = true;
            this.linkLabelLikedPageURL.Text = "linkLabel1";
            this.linkLabelLikedPageURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.URL_LinkLabel_LinkClicked);
            // 
            // labelLikedPageName
            // 
            this.labelLikedPageName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.likedPagesBindingSource, "Name", true));
            this.labelLikedPageName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLikedPageName.Location = new System.Drawing.Point(161, 0);
            this.labelLikedPageName.Name = "labelLikedPageName";
            this.labelLikedPageName.Size = new System.Drawing.Size(100, 47);
            this.labelLikedPageName.TabIndex = 10;
            this.labelLikedPageName.Text = "label1";
            // 
            // buttonRefreshLikedPage
            // 
            this.buttonRefreshLikedPage.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefreshLikedPage.Location = new System.Drawing.Point(220, 181);
            this.buttonRefreshLikedPage.Name = "buttonRefreshLikedPage";
            this.buttonRefreshLikedPage.Size = new System.Drawing.Size(60, 25);
            this.buttonRefreshLikedPage.TabIndex = 10;
            this.buttonRefreshLikedPage.Text = "Refresh";
            this.buttonRefreshLikedPage.UseVisualStyleBackColor = true;
            this.buttonRefreshLikedPage.Click += new System.EventHandler(this.buttonRefreshLikedPage_Click);
            // 
            // pictureBoxLikedPage
            // 
            this.pictureBoxLikedPage.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.likedPagesBindingSource, "ImageLarge", true));
            this.pictureBoxLikedPage.Location = new System.Drawing.Point(161, 77);
            this.pictureBoxLikedPage.Name = "pictureBoxLikedPage";
            this.pictureBoxLikedPage.Size = new System.Drawing.Size(100, 78);
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
            this.panelPostStatus.Location = new System.Drawing.Point(622, 41);
            this.panelPostStatus.Name = "panelPostStatus";
            this.panelPostStatus.Size = new System.Drawing.Size(465, 230);
            this.panelPostStatus.TabIndex = 11;
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
            this.labelPostStatus.Location = new System.Drawing.Point(646, 11);
            this.labelPostStatus.Name = "labelPostStatus";
            this.labelPostStatus.Size = new System.Drawing.Size(180, 23);
            this.labelPostStatus.TabIndex = 8;
            this.labelPostStatus.Text = "Post A Status";
            this.labelPostStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelFriendTitle
            // 
            this.labelFriendTitle.AutoSize = true;
            this.labelFriendTitle.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendTitle.Location = new System.Drawing.Point(78, 6);
            this.labelFriendTitle.Name = "labelFriendTitle";
            this.labelFriendTitle.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelFriendTitle.Size = new System.Drawing.Size(148, 28);
            this.labelFriendTitle.TabIndex = 7;
            this.labelFriendTitle.Text = "My Friends";
            this.labelFriendTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelFriends
            // 
            this.panelFriends.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFriends.Controls.Add(this.buttonRefreshFriends);
            this.panelFriends.Controls.Add(this.flowLayoutPanelAboutMeFriends);
            this.panelFriends.Location = new System.Drawing.Point(22, 39);
            this.panelFriends.Name = "panelFriends";
            this.panelFriends.Size = new System.Drawing.Size(261, 500);
            this.panelFriends.TabIndex = 9;
            // 
            // buttonRefreshFriends
            // 
            this.buttonRefreshFriends.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonRefreshFriends.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefreshFriends.Location = new System.Drawing.Point(0, 466);
            this.buttonRefreshFriends.Name = "buttonRefreshFriends";
            this.buttonRefreshFriends.Size = new System.Drawing.Size(257, 30);
            this.buttonRefreshFriends.TabIndex = 8;
            this.buttonRefreshFriends.Text = "Refresh";
            this.buttonRefreshFriends.UseVisualStyleBackColor = true;
            this.buttonRefreshFriends.Click += new System.EventHandler(this.buttonRefreshFriends_Click);
            // 
            // flowLayoutPanelAboutMeFriends
            // 
            this.flowLayoutPanelAboutMeFriends.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelAboutMeFriends.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelAboutMeFriends.Name = "flowLayoutPanelAboutMeFriends";
            this.flowLayoutPanelAboutMeFriends.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelAboutMeFriends.Size = new System.Drawing.Size(257, 463);
            this.flowLayoutPanelAboutMeFriends.TabIndex = 6;
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
            this.panelLastPost.Location = new System.Drawing.Point(298, 305);
            this.panelLastPost.Name = "panelLastPost";
            this.panelLastPost.Size = new System.Drawing.Size(287, 234);
            this.panelLastPost.TabIndex = 9;
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
            // 
            // listBoxPostLiked
            // 
            this.listBoxPostLiked.FormattingEnabled = true;
            this.listBoxPostLiked.Location = new System.Drawing.Point(7, 102);
            this.listBoxPostLiked.Name = "listBoxPostLiked";
            this.listBoxPostLiked.Size = new System.Drawing.Size(91, 95);
            this.listBoxPostLiked.TabIndex = 11;
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
            this.buttonRefreshLastPost.Text = "Refresh";
            this.buttonRefreshLastPost.UseVisualStyleBackColor = true;
            this.buttonRefreshLastPost.Click += new System.EventHandler(this.buttonRefreshLastPost_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(324, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pages liked";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelMyLastPost
            // 
            this.labelMyLastPost.AutoSize = true;
            this.labelMyLastPost.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold);
            this.labelMyLastPost.Location = new System.Drawing.Point(303, 279);
            this.labelMyLastPost.Name = "labelMyLastPost";
            this.labelMyLastPost.Size = new System.Drawing.Size(278, 23);
            this.labelMyLastPost.TabIndex = 18;
            this.labelMyLastPost.Text = "My most recent post";
            this.labelMyLastPost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.tabControl.Location = new System.Drawing.Point(9, 170);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1172, 582);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.Tag = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMostRecentTaggedTogether)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPhoto)).EndInit();
            this.tabPageFriendshipAnalyzer.ResumeLayout(false);
            this.panelGeneralInfo.ResumeLayout(false);
            this.panelGeneralInfo.PerformLayout();
            this.tabPageDataTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPageAboutMe.ResumeLayout(false);
            this.tabPageAboutMe.PerformLayout();
            this.panelPostPhoto.ResumeLayout(false);
            this.panelPostPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostPhoto)).EndInit();
            this.panelLikedPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.likedPagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikedPage)).EndInit();
            this.panelPostStatus.ResumeLayout(false);
            this.panelPostStatus.PerformLayout();
            this.panelFriends.ResumeLayout(false);
            this.panelLastPost.ResumeLayout(false);
            this.panelLastPost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLastPost)).EndInit();
            this.tabControl.ResumeLayout(false);
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
        private System.Windows.Forms.TreeView treeViewPhotosOfFriendInMyPhotos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFriendshipAnalyzer;
        private System.Windows.Forms.TreeView treeViewTaggedTogether;
        private System.Windows.Forms.TabPage tabPageDataTables;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonFetchData;
        private System.Windows.Forms.ComboBox comboBoxDataTableBindingSelection;
        private System.Windows.Forms.TabPage tabPageAboutMe;
        private System.Windows.Forms.Panel panelFriends;
        private System.Windows.Forms.Label labelFriendTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAboutMeFriends;
        private System.Windows.Forms.Panel panelLastPost;
        private System.Windows.Forms.Button buttonAddPicture;
        private System.Windows.Forms.Label labelPostStatus;
        private System.Windows.Forms.Label labelTagFriends;
        private System.Windows.Forms.RichTextBox richTextBoxStatusPost;
        private System.Windows.Forms.Button buttonPostStatus;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button buttonRefreshFriends;
        private System.Windows.Forms.Button buttonRefreshLastPost;
        private System.Windows.Forms.Panel panelLikedPage;
        private System.Windows.Forms.Button buttonRefreshLikedPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMyLastPost;
        private System.Windows.Forms.TextBox textBoxLastPostMessage;
        private System.Windows.Forms.Button buttonClearPostTags;
        private System.Windows.Forms.ListBox listBoxPostTags;
        private System.Windows.Forms.BindingSource friendsBindingSource;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelNumComments;
        private System.Windows.Forms.Label labelNumLikes;
        private System.Windows.Forms.PictureBox pictureBoxMostRecentTaggedTogether;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFetchPhotosOfFriendIAmTaggedIn;
        private System.Windows.Forms.TreeView treeViewPhotosOfFriendIAmTaggedIn;
        private System.Windows.Forms.Button buttonFetchMyPhotosFriendIsIn;
        private System.Windows.Forms.Button buttonFetchTaggedTogether;
        private System.Windows.Forms.Panel panelGeneralInfo;
        private System.Windows.Forms.Panel panelPostStatus;
        private System.Windows.Forms.Panel panelPostPhoto;
        private System.Windows.Forms.Button buttonPostPhoto;
        private System.Windows.Forms.RichTextBox richTextBoxPostPhoto;
        private System.Windows.Forms.Label labelPostPhoto;
        private System.Windows.Forms.PictureBox pictureBoxPostPhoto;
        private System.Windows.Forms.ListBox listBoxLikedPage;
        private System.Windows.Forms.BindingSource likedPagesBindingSource;
        private System.Windows.Forms.LinkLabel linkLabelLikedPageURL;
        private System.Windows.Forms.Label labelLikedPageName;
        private System.Windows.Forms.PictureBox pictureBoxLikedPage;
        private System.Windows.Forms.Button buttonRefreshTagFriends;
        private System.Windows.Forms.PictureBox pictureBoxLastPost;
        private System.Windows.Forms.ListBox listBoxPostComment;
        private System.Windows.Forms.ListBox listBoxPostLiked;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelPhotoPreview;
        private System.Windows.Forms.Button buttonFetchGeneralData;
    }
}