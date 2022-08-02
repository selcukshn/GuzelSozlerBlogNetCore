using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.EntityFrameworkCore;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GuzelSozContext context) : base(context)
        {

        }
        private GuzelSozContext GuzelSozContext { get { return _context as GuzelSozContext; } }
        // using (var db=new Context())
        // {
        //     ...
        // }
        public Category GetCategoryByPostUrl(string PostUrl)
        {
            return GuzelSozContext.Posts
            .Where(w => w.PostUrl == PostUrl)
            .Select(s => s.Category)
            .FirstOrDefault();
        }
        public Category GetCategory(string CategoryUrl)
        {
            return GuzelSozContext.Categories
            .Include(i => i.Posts)
            .FirstOrDefault(f => f.CategoryUrl == CategoryUrl);
        }
        public Category GetCategory(int CategoryId)
        {
            return GuzelSozContext.Categories
            .Include(i => i.Posts)
            .FirstOrDefault(f => f.CategoryId == CategoryId);
        }

        public void PlusClickCount(int CategoryId)
        {
            var category = GuzelSozContext.Categories
            .FirstOrDefault(w => w.CategoryId == CategoryId);

            category.ClickCount += 1;
            GuzelSozContext.SaveChanges();
        }

        public List<Category> PopularCategories(int Count)
        {
            return GuzelSozContext.Categories
            .OrderByDescending(o => o.ClickCount)
            .Take(Count)
            .ToList();
        }

        public List<Category> GetHomeCategories()
        {

            return GuzelSozContext.Categories
            .Include(i => i.Posts.Take(4))
            .Where(w => w.ShowHome)
            .ToList();
        }
    }
}