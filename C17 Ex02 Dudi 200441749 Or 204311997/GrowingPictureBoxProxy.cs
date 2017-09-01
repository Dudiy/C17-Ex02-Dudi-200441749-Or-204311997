using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    using C17_Ex01_Dudi_200441749_Or_204311997.Properties;

    public class GrowingPictureBoxProxy : PictureBox
    {
        private const bool k_Grow = true;

        public Size PictureSize { get; set; }

        public int AmountToGrow { get; set; }

        public GrowingPictureBoxProxy()
        {
            Image = Resources.Picture_not_found;
            AmountToGrow = 20;
            PictureSize = new Size(90, 90);
            SizeMode = PictureBoxSizeMode.Zoom;
            Size = PictureSize;
        }

        public GrowingPictureBoxProxy(string i_ImageUrl, object i_Tag)
            : this()
        {
            Load(i_ImageUrl);
            Tag = i_Tag;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            resize(k_Grow);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            resize(!k_Grow);
        }

        private void resize(bool i_Grow)
        {
            int negator = i_Grow ? 1 : -1;
            Size = new Size(
                Size.Width + (negator * AmountToGrow),
                Size.Height + (negator * AmountToGrow));
        }

        public void Reset()
        {
            Image = Resources.Picture_not_found;
            Tag = null;
        }
    }
}
