using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{

    public class GrowingPictureBoxProxy : PictureBox
    {
        private const bool k_Grow = true;
        private static readonly Size sr_FriendProfilePicSize = new Size(90, 90);
        public int AmountToGrow { get; set; }

        public GrowingPictureBoxProxy()
        {
            AmountToGrow = 20;
        }

        public GrowingPictureBoxProxy(User i_User)
            : this()
        {
            Image = i_User.ImageLarge;
            Size = sr_FriendProfilePicSize;
            SizeMode = PictureBoxSizeMode.Zoom;
            Tag = i_User;
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
    }
}
