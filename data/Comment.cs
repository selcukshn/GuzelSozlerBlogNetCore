using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace data
{
    public class Comment
    {
        public Comment()
        {
            Replies = new HashSet<Reply>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Confirm { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}