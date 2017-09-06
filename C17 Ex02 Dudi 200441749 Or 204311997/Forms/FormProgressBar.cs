/*
 * C17_Ex01: FormProgressBar.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    public partial class FormProgressBar : Form
    {
        private readonly object r_ProgressValueLock = new object();

        private bool m_CancleEnabled;

        public FormProgressBar(string i_Description)
            : this(0, i_Description)
        {
        }

        public FormProgressBar(int i_MaxValue, string i_Description)
        {
            this.InitializeComponent();
            this.m_CancleEnabled = false;
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = i_MaxValue;
            this.labelLoading.Text = string.Format("Loading {0}...", i_Description);
        }

        public bool CancelEnabled
        {
            get { return this.m_CancleEnabled; }
            set
            {
                this.m_CancleEnabled = value;
                this.buttonCancel.Visible = value;
            }
        }

        public int MaxValue
        {
            get { return this.progressBar.Maximum; }
            set { this.progressBar.Maximum = Math.Min(value, FacebookApplication.k_CollectionLimit); }
        }

        public int ProgressValue
        {
            get
            {
                lock (this.r_ProgressValueLock)
                {
                    return this.progressBar.Value;
                }
            }

            set
            {
                if (value <= this.progressBar.Maximum)
                {
                    try
                    {
                        this.Invoke(
                            new Action(
                                () =>
                                    {
                                        this.progressBar.Value = value;
                                        this.labelLoadedPercent.Text = string.Format(
                                            "{0:P0}",
                                            (float)value / this.progressBar.Maximum);
                                        this.Refresh();
                                    }));
                    }
                    catch (ObjectDisposedException e)
                    {
                        // Do nothing if the window is disposed
                    }
                }
                else
                {
//                    throw new ArgumentOutOfRangeException(string.Format(
//@"Valid values for this progress bar are {0}-{1}",
//this.progressBar.Minimum,
//this.progressBar.Maximum));
                }
            }
        }

        public new void Close()
        {
            if (!this.IsDisposed)
            {
                this.Invoke(new Action(() => base.Close()));
            }
        }

        private void buttonCancel_Click(object i_Sender, EventArgs i_Args)
        {
            this.Close();
        }
    }
}
