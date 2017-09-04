/*
 * C17_Ex01: ProgressBarWindow.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class ProgressBarWindow : Form
    {
        private const int HEIGHT_WITH_CANCEL = 176;

        private const int HEIGHT_WITHOUT_CANCEL = 133;
        public object m_ProgressValueLock = new object();

        private bool CancleEnabled;

        public ProgressBarWindow(string i_Description)
            : this(0, i_Description)
        {
        }

        public ProgressBarWindow(int i_MaxValue, string i_Description)
        {
            InitializeComponent();
            CancleEnabled = false;
            progressBar.Minimum = 0;
            progressBar.Maximum = i_MaxValue;
            labelLoading.Text = string.Format("Loading {0}...", i_Description);
        }

        public bool CancelEnabled
        {
            get { return CancleEnabled; }
            set
            {
                CancleEnabled = value;
                buttonCancel.Visible = value;
                //Height = value ? HEIGHT_WITH_CANCEL : HEIGHT_WITHOUT_CANCEL;
            }
        }

        public int MaxValue
        {
            get { return progressBar.Maximum; }
            set { progressBar.Maximum = Math.Min(value, FacebookApplication.k_CollectionLimit); }
        }

        //public string Text
        //{
        //    set
        //    {
        //        labelLoading.Text = value;
        //    }
        //}

        public int ProgressValue
        {
            get
            {
                lock (m_ProgressValueLock)
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
