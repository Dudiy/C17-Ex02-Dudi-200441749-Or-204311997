/*
 * C17_Ex01: FacebookCommentProxy.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System.Text;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997.ControlsAndProxies
{
    public class FacebookCommentProxy
    {
        public Comment Comment { get; set; }

        public override string ToString()
        {
            StringBuilder commentStr = new StringBuilder(this.Comment.From.Name);

            commentStr.Append(": ");
            commentStr.Append(string.IsNullOrEmpty(this.Comment.Message) ? "[No Message]" : this.Comment.Message);

            return commentStr.ToString();
        }
    }
}
