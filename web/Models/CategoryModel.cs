using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryImg { get; set; }
        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }
        public List<Post> Posts { get; set; }
    }
}