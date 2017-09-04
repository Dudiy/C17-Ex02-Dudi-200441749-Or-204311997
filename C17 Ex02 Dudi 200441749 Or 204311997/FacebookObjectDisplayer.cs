/*
 * C17_Ex01: FacebookObjectDisplayer.cs
 * 
 * Visitor class to enable displaying objects (connector between logic and UI)
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
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
                PhotoDetails photoDetails = new PhotoDetails(objectToDisplay as Photo);
                photoDetails.Show();
            }
            else if (objectToDisplay is User)
            {
                FormFriendDetails formFriendDetails = new FormFriendDetails(objectToDisplay as User);
                formFriendDetails.Show();
            }
            else if (objectToDisplay is Page)
            {
                PictureFrame pictureFrame = new PictureFrame(((Page)objectToDisplay).PictureLargeURL);
                pictureFrame.Show();
            }
            else if (objectToDisplay is Post)
            {
                //FormPostDetails formPostDetails = new FormPostDetails() { Post = objectToDisplay as Post };
                FormPostDetails formPostDetails = new FormPostDetails((Post)objectToDisplay);
                formPostDetails.Show();
            }
            else
            {
                MessageBox.Show(string.Format("Showing toString(): ", objectToDisplay.ToString()));
            }
        }
    }
}
