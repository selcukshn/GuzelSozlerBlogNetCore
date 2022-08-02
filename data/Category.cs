using System;
using System.Collections.Generic;

#nullable disable

namespace data
{
    public partial class Category
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        public int CategoryId { get; set; }
        public string CategoryImg { get; set; }
        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }
        public int ClickCount { get; set; }
        public bool ShowHome { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
