using System.Text;
using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    public class FacebookCommentProxy
    {
        public Comment Comment { get; set; }

        public override string ToString()
        {
            StringBuilder commentStr = new StringBuilder(Comment.From.Name);
            commentStr.Append(": ");
            commentStr.Append(string.IsNullOrEmpty(Comment.Message) ? "[No Message]" : Comment.Message);
            return commentStr.ToString();
        }
    }
}
