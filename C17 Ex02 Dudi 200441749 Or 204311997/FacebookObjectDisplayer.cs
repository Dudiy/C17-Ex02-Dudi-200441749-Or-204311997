/*
 * C17_Ex01: FacebookObjectDisplayer.cs
 * 
 * Visitor class to enable displaying objects (connector between logic and UI)
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public static class FacebookObjectDisplayer
    {
        // Extension method
        public static void DisplayObject(this IDisplayable i_ObjectToDisplay)
        {
            object objectToDisplay = i_ObjectToDisplay.ObjectToDisplay;
            if (objectToDisplay is Photo)
            {
                FormPhotoDetails formPhotoDetails = new FormPhotoDetails(objectToDisplay as Photo);
                formPhotoDetails.Show();
            }
            else if (objectToDisplay is User)
            {
                FormFriendDetails formFriendDetails = new FormFriendDetails(objectToDisplay as User);
                formFriendDetails.Show();
            }
            else if (objectToDisplay is Page)
            {
                FormPictureFrame formPictureFrame = new FormPictureFrame(((Page)objectToDisplay).PictureLargeURL);
                formPictureFrame.Show();
            }
            else if (objectToDisplay is Post)
            {
                FormPostDetails formPostDetails = new FormPostDetails((Post)objectToDisplay);
                formPostDetails.Show();
            }
            else
            {
                MessageBox.Show(string.Format("Showing toString(): {0}", objectToDisplay.ToString()));
            }
        }
    }
}
