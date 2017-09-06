using System;
using System.Drawing;
using System.Windows.Forms;
using C17_Ex01_Dudi_200441749_Or_204311997.Properties;

namespace C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies
{
    public class GrowingPictureBoxProxy : PictureBox
    {
        private const bool k_Grow = true;
        private const int k_DefaultWidthAndHeight = 90;
        private const int k_AmountToGrow = 20;

        public GrowingPictureBoxProxy()
        {
            this.Image = Resources.Picture_not_found;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Size = new Size(k_DefaultWidthAndHeight, k_DefaultWidthAndHeight);
        }

        public GrowingPictureBoxProxy(string i_ImageUrl, object i_Tag)
            : this()
        {
            this.Load(i_ImageUrl);
            this.Tag = i_Tag;
        }

        protected override void OnMouseEnter(EventArgs i_Args)
        {
            this.resize(k_Grow);
        }

        protected override void OnMouseLeave(EventArgs i_Args)
        {
            this.resize(!k_Grow);
        }

        private void resize(bool i_Grow)
        {
            int negator = i_Grow ? 1 : -1;

            this.Size = new Size(
                this.Size.Width + (negator * k_AmountToGrow),
                this.Size.Height + (negator * k_AmountToGrow));
        }

        public void Reset()
        {
            this.Image = Resources.Picture_not_found;
            this.Tag = null;
        }
    }
}
