using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Data.Abstract
{
    public interface IPostRepository : IRepository<Post>
    {
        Post GetPost(string PostUrl);
        Post GetPost(int PostId);
        List<Post> GetPostsByCategoryId(int CategoryId);
        List<Post> GetPostsByCategory(Category category);
        List<Post> LastAdded(int Count);
        List<Post> MostHaveComment(int Count);
        void PlusClickCount(int PostId);
        void PlusCommentCount(int PostId);
    }
}