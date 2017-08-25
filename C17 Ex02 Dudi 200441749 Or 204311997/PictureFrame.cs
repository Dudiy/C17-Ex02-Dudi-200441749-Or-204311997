/*
 * C17_Ex01: PictureFrame.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public partial class PictureFrame : Form
    {
        public PictureFrame(string i_ImageUrl)
            : this(i_ImageUrl, string.Empty)
        {
        }

        public PictureFrame(string i_ImageUrl, string i_ImageTitle)
        {
            InitializeComponent();
            Text = i_ImageTitle;
            pictureBox.LoadAsync(i_ImageUrl);
        }
    }
}
