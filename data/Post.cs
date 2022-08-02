using System;
using System.Collections.Generic;

#nullable disable

namespace data
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        public virtual ICollection<Comment> Comments { get; set; }
        public int PostId { get; set; }
        public string PostImg { get; set; }
        public string PostTitle { get; set; }
        public string PostSummary { get; set; }
        public DateTime PostDate { get; set; }
        public int CategoryId { get; set; }
        public string AddedBy { get; set; }
        public string PostUrl { get; set; }
        public string PostContent { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int ClickCount { get; set; }
        public virtual Category Category { get; set; }
    }
}
