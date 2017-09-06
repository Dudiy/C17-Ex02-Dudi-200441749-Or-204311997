namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    public partial class FormAlbumsSelector
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
            this.labelAlbumsSelect = new System.Windows.Forms.Label();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelAlbumsSelect
            // 
            this.labelAlbumsSelect.AutoSize = true;
            this.labelAlbumsSelect.Location = new System.Drawing.Point(12, 17);
            this.labelAlbumsSelect.Name = "labelAlbumsSelect";
            this.labelAlbumsSelect.Size = new System.Drawing.Size(162, 20);
            this.labelAlbumsSelect.TabIndex = 1;
            this.labelAlbumsSelect.Text = "Please select albums:";
            // 
            // buttonContinue
            // 
            this.buttonContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonContinue.Location = new System.Drawing.Point(173, 435);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(86, 31);
            this.buttonContinue.TabIndex = 2;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 20;
            this.listBoxAlbums.Location = new System.Drawing.Point(16, 80);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxAlbums.Size = new System.Drawing.Size(243, 344);
            this.listBoxAlbums.TabIndex = 3;
            this.listBoxAlbums.SelectedValueChanged += new System.EventHandler(this.listBoxAlbums_SelectedValueChanged);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(16, 50);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(92, 24);
            this.checkBoxSelectAll.TabIndex = 4;
            this.checkBoxSelectAll.Text = "Select all";
            this.checkBoxSelectAll.ThreeState = true;
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // FormAlbumsSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 478);
            this.Controls.Add(this.checkBoxSelectAll);
            this.Controls.Add(this.listBoxAlbums);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.labelAlbumsSelect);
            this.Name = "FormAlbumsSelector";
            this.Text = "FormAlbumsSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelAlbumsSelect;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
    }
}