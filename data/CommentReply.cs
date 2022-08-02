using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace data
{
    public class CommentReply
    {
        public int CommentId { get; set; }
        public int ReplyId { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Reply Reply { get; set; }
    }
}