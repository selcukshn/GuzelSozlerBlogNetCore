using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string PostImg { get; set; }
        public string PostTitle { get; set; }
        public string PostSummary { get; set; }
        public string AddedBy { get; set; }
        public string PostUrl { get; set; }
        public Category Category { get; set; }

    }
}