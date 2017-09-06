/*
 * C17_Ex01: FormPictureFrame.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System.Windows.Forms;

namespace C17_Ex01_Dudi_200441749_Or_204311997.Forms
{
    public partial class FormPictureFrame : Form
    {
        public FormPictureFrame(string i_ImageUrl)
            : this(i_ImageUrl, string.Empty)
        {
        }

        public FormPictureFrame(string i_ImageUrl, string i_ImageTitle)
        {
            this.InitializeComponent();
            this.Text = i_ImageTitle;
            this.pictureBox.LoadAsync(i_ImageUrl);
        }
    }
}
