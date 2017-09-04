/*
 * C17_Ex01: FormProgressBar.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;

namespace C17_Ex01_Dudi_200441749_Or_204311997
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
            InitializeComponent();
            this.m_CancleEnabled = false;
            progressBar.Minimum = 0;
            progressBar.Maximum = i_MaxValue;
            labelLoading.Text = string.Format("Loading {0}...", i_Description);
        }

        public bool CancelEnabled
        {
            get { return m_CancleEnabled; }
            set
            {
                m_CancleEnabled = value;
                buttonCancel.Visible = value;
            }
        }

        public int MaxValue
        {
            get { return progressBar.Maximum; }
            set { progressBar.Maximum = Math.Min(value, FacebookApplication.k_CollectionLimit); }
        }

        public int ProgressValue
        {
            get
            {
                lock (this.r_ProgressValueLock)
                {
                    return progressBar.Value;
                }
            }

            set
            {
                if (value <= progressBar.Maximum)
                {
                    try
                    {
                        Invoke(
                            new Action(
                                () =>
                                    {
                                        progressBar.Value = value;
                                        labelLoadedPercent.Text = string.Format(
                                            "{0:P0}",
                                            (float)value / progressBar.Maximum);
                                        Refresh();
                                    }));
                    }
                    catch (ObjectDisposedException e)
                    {
                        // Do nothing if the window is disposed
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(string.Format(
@"Valid values for this progress bar are {0}-{1}",
progressBar.Minimum,
progressBar.Maximum));
                }
            }
        }

        public new void Close()
        {
            if (!IsDisposed)
            {
                Invoke(new Action(() => base.Close()));
            }
        }

        private void buttonCancel_Click(object i_Sender, EventArgs i_Args)
        {
            Close();
        }
    }
}
