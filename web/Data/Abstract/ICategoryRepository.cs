using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByPostUrl(string PostUrl);
        Category GetCategory(string CategoryUrl);
        Category GetCategory(int CategoryId);
        List<Category> PopularCategories(int Count);
        List<Category> GetHomeCategories();
        void PlusClickCount(int CategoryId);
    }
}