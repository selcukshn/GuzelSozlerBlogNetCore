using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Models
{
    public class PostListViewModel
    {
        public Category Category { get; set; }
        public List<Post> Posts { get; set; }
    }
}