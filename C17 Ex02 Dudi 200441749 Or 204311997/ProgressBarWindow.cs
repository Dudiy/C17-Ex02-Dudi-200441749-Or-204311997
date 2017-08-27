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
        public ProgressBarWindow(int i_MinValue, int i_MaxValue, string i_Description)
        {
            InitializeComponent();
            progressBar.Minimum = i_MinValue;
            progressBar.Maximum = i_MaxValue;
            labelLoading.Text = string.Format("Loading {0}...", i_Description);
        }

        public ProgressBarWindow(string i_Description)
            : this(0, 0, i_Description)
        {
        }

        public int MaxValue
        {
            get { return progressBar.Maximum; }
            set { progressBar.Maximum = Math.Min(value, FacebookApplication.k_CollectionLimit); }
        }

        public int ProgressValue
        {
            get { return progressBar.Value; }
            set
            {
                if (value <= progressBar.Maximum)
                {
                    progressBar.Value = value;
                    labelLoadedPercent.Text = string.Format("{0:P0}", (float)value / progressBar.Maximum);
                    Refresh();
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
    }
}
