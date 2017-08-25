namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class PhotoDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoDetails));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxLikes = new System.Windows.Forms.ListBox();
            this.labelLikes = new System.Windows.Forms.Label();
            this.labelAlbum = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.treeViewComments = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBoxLikes);
            this.splitContainer1.Panel1.Controls.Add(this.labelLikes);
            this.splitContainer1.Panel1.Controls.Add(this.labelAlbum);
            this.splitContainer1.Panel1.Controls.Add(this.labelName);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeViewComments);
            this.splitContainer1.Size = new System.Drawing.Size(445, 391);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // listBoxLikes
            // 
            this.listBoxLikes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxLikes.FormattingEnabled = true;
            this.listBoxLikes.Location = new System.Drawing.Point(0, 257);
            this.listBoxLikes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxLikes.Name = "listBoxLikes";
            this.listBoxLikes.Size = new System.Drawing.Size(217, 134);
            this.listBoxLikes.TabIndex = 3;
            this.listBoxLikes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxLikes_MouseDoubleClick);
            // 
            // labelLikes
            // 
            this.labelLikes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLikes.AutoSize = true;
            this.labelLikes.Location = new System.Drawing.Point(8, 233);
            this.labelLikes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLikes.Name = "labelLikes";
            this.labelLikes.Size = new System.Drawing.Size(38, 13);
            this.labelLikes.TabIndex = 1;
            this.labelLikes.Text = "Likes: ";
            // 
            // labelAlbum
            // 
            this.labelAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAlbum.AutoSize = true;
            this.labelAlbum.Location = new System.Drawing.Point(8, 215);
            this.labelAlbum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAlbum.Name = "labelAlbum";
            this.labelAlbum.Size = new System.Drawing.Size(42, 13);
            this.labelAlbum.TabIndex = 1;
            this.labelAlbum.Text = "Album: ";
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 197);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name: ";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(217, 192);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // treeViewComments
            // 
            this.treeViewComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewComments.Location = new System.Drawing.Point(0, 0);
            this.treeViewComments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeViewComments.Name = "treeViewComments";
            this.treeViewComments.Size = new System.Drawing.Size(225, 391);
            this.treeViewComments.TabIndex = 0;
            // 
            // PhotoDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 391);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PhotoDetails";
            this.Text = "PhotoDetails";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelLikes;
        private System.Windows.Forms.Label labelAlbum;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TreeView treeViewComments;
        private System.Windows.Forms.ListBox listBoxLikes;
    }
}