namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class ProgressBarWindow
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelLoading = new System.Windows.Forms.Label();
            this.labelLoadedPercent = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 37);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(248, 30);
            this.progressBar.TabIndex = 0;
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Location = new System.Drawing.Point(12, 9);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(78, 20);
            this.labelLoading.TabIndex = 1;
            this.labelLoading.Text = "Loading...";
            // 
            // labelLoadedPercent
            // 
            this.labelLoadedPercent.AutoSize = true;
            this.labelLoadedPercent.BackColor = System.Drawing.Color.Transparent;
            this.labelLoadedPercent.Location = new System.Drawing.Point(120, 42);
            this.labelLoadedPercent.Name = "labelLoadedPercent";
            this.labelLoadedPercent.Size = new System.Drawing.Size(32, 20);
            this.labelLoadedPercent.TabIndex = 3;
            this.labelLoadedPercent.Text = "0%";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(179, 78);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 30);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ProgressBarWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(272, 77);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelLoadedPercent);
            this.Controls.Add(this.labelLoading);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProgressBarWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.Label labelLoadedPercent;
        private System.Windows.Forms.Button buttonCancel;
    }
}