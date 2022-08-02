using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace data
{
    public class Reply
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime ReplyDate { get; set; }
        public bool Confirm { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}