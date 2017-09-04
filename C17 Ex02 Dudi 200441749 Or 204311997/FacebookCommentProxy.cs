using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using FacebookWrapper.ObjectModel;

namespace C17_Ex01_Dudi_200441749_Or_204311997
{
    using System.Reflection;

    public class FacebookCommentProxy
    {
        public Comment Comment { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Comment.Message) ? "[No Message]" : Comment.Message;
        }
    }
}
