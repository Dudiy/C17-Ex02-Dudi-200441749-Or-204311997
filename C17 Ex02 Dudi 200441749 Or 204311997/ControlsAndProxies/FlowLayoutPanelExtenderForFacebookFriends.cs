/*
 * C17_Ex01: FlowLayoutPanelExtenderForFacebookFriends.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies
{
    internal class FlowLayoutPanelExtenderForFacebookFriends : FlowLayoutPanel
    {
        private readonly object r_LayoutPanelUpdateLock = new object();

        public void Update(MouseEventHandler i_OnMouseEventHandlerMouseClick)
        {
            FacebookApplication.StartThread(() => this.updateImplementation(i_OnMouseEventHandlerMouseClick));
        }

        private void updateImplementation(MouseEventHandler i_OnMouseEventHandlerouseClick)
        {
            try
            {
                lock (this.r_LayoutPanelUpdateLock)
                {
                    if (FacebookApplication.LoggedInUser != null)
                    {
                        FacebookApplication.LoggedInUser.ReFetch("friends");
                        this.Invoke(new Action(() => this.Controls.Clear()));
                        foreach (User friend in FacebookApplication.LoggedInUser.Friends)
                        {
                            PictureBox friendsProfilePic = new GrowingPictureBoxProxy
                            {
                                ImageLocation = friend.PictureLargeURL,
                                Tag = friend
                            };
                            friendsProfilePic.MouseClick += i_OnMouseEventHandlerouseClick;
                            this.Invoke(new Action(() => this.Controls.Add(friendsProfilePic)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error while loading user's friends. error message: {0}", ex.Message));
            }
        }
    }
}
