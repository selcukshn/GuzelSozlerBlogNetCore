using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Models
{
    public class PostDetailViewModel
    {
        public Post Post { get; set; }
        public Category Category { get; set; }
    }
}