namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    partial class FormPostDetails
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
            System.Windows.Forms.Label createdTimeLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label messageLabel;
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.postsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelName = new System.Windows.Forms.Label();
            this.labelCreatedTime = new System.Windows.Forms.Label();
            this.listBoxLikes = new System.Windows.Forms.ListBox();
            this.likedByBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxComments = new System.Windows.Forms.ListBox();
            this.labelLikes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.commentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            createdTimeLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            messageLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.likedByBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // createdTimeLabel
            // 
            createdTimeLabel.AutoSize = true;
            createdTimeLabel.Location = new System.Drawing.Point(3, 20);
            createdTimeLabel.Name = "createdTimeLabel";
            createdTimeLabel.Size = new System.Drawing.Size(73, 13);
            createdTimeLabel.TabIndex = 4;
            createdTimeLabel.Text = "Created Time:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(3, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(71, 13);
            nameLabel.TabIndex = 5;
            nameLabel.Text = "Uploaded By:";
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Location = new System.Drawing.Point(3, 40);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new System.Drawing.Size(53, 13);
            messageLabel.TabIndex = 6;
            messageLabel.Text = "Message:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(messageLabel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelMessage, 1, 9);
            this.tableLayoutPanel1.Controls.Add(nameLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 1, 7);
            this.tableLayoutPanel1.Controls.Add(createdTimeLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelCreatedTime, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.listBoxLikes, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.listBoxComments, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.labelLikes, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 11);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(458, 358);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.postsBindingSource, "Message", true));
            this.labelMessage.Location = new System.Drawing.Point(82, 40);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(72, 13);
            this.labelMessage.TabIndex = 7;
            this.labelMessage.Text = "labelMessage";
            // 
            // postsBindingSource
            // 
            this.postsBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Post);
            // 
            // labelName
            // 
            this.labelName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.postsBindingSource, "From.Name", true));
            this.labelName.Location = new System.Drawing.Point(82, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(100, 20);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "name";
            // 
            // labelCreatedTime
            // 
            this.labelCreatedTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.postsBindingSource, "CreatedTime", true));
            this.labelCreatedTime.Location = new System.Drawing.Point(82, 20);
            this.labelCreatedTime.Name = "labelCreatedTime";
            this.labelCreatedTime.Size = new System.Drawing.Size(100, 20);
            this.labelCreatedTime.TabIndex = 5;
            this.labelCreatedTime.Text = "created time";
            // 
            // listBoxLikes
            // 
            this.listBoxLikes.DataSource = this.likedByBindingSource;
            this.listBoxLikes.DisplayMember = "Name";
            this.listBoxLikes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLikes.FormattingEnabled = true;
            this.listBoxLikes.Location = new System.Drawing.Point(82, 56);
            this.listBoxLikes.Name = "listBoxLikes";
            this.listBoxLikes.Size = new System.Drawing.Size(373, 105);
            this.listBoxLikes.TabIndex = 7;
            this.listBoxLikes.ValueMember = "Albums";
            // 
            // likedByBindingSource
            // 
            this.likedByBindingSource.DataMember = "LikedBy";
            this.likedByBindingSource.DataSource = this.postsBindingSource;
            // 
            // listBoxComments
            // 
            this.listBoxComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxComments.FormattingEnabled = true;
            this.listBoxComments.Location = new System.Drawing.Point(82, 167);
            this.listBoxComments.Name = "listBoxComments";
            this.listBoxComments.Size = new System.Drawing.Size(373, 188);
            this.listBoxComments.TabIndex = 8;
            // 
            // labelLikes
            // 
            this.labelLikes.AutoSize = true;
            this.labelLikes.Location = new System.Drawing.Point(3, 53);
            this.labelLikes.Name = "labelLikes";
            this.labelLikes.Size = new System.Drawing.Size(32, 13);
            this.labelLikes.TabIndex = 9;
            this.labelLikes.Text = "Likes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Comments";
            // 
            // commentsBindingSource
            // 
            this.commentsBindingSource.DataMember = "Comments";
            this.commentsBindingSource.DataSource = this.postsBindingSource;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxPhoto);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(458, 552);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 1;
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPhoto.ErrorImage = null;
            this.pictureBoxPhoto.Image = global::C17_Ex01_Dudi_200441749_Or_204311997.Properties.Resources.Picture_not_found;
            this.pictureBoxPhoto.InitialImage = global::C17_Ex01_Dudi_200441749_Or_204311997.Properties.Resources.Picture_not_found;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(458, 190);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 0;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // FormPostDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 552);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormPostDetails";
            this.Text = "FormPostDetails";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.likedByBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentsBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelCreatedTime;
        private System.Windows.Forms.BindingSource postsBindingSource;
        private System.Windows.Forms.BindingSource commentsBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ListBox listBoxLikes;
        private System.Windows.Forms.BindingSource likedByBindingSource;
        private System.Windows.Forms.ListBox listBoxComments;
        private System.Windows.Forms.Label labelLikes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
    }
}