using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Models
{
    public class HomeViewModel
    {
        public List<Category> HomeCategories { get; set; }
        public List<Post> MostHaveComment { get; set; }
    }
}