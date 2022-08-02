using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.EntityFrameworkCore;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(GuzelSozContext context) : base(context)
        {

        }
        private GuzelSozContext GuzelSozContext { get { return _context as GuzelSozContext; } }
        public Post GetPost(string PostUrl)
        {
            return GuzelSozContext.Posts
            .Include(i => i.Category)
            .FirstOrDefault(f => f.PostUrl == PostUrl);
        }
        public Post GetPost(int PostId)
        {
            return GuzelSozContext.Posts
            .Include(i => i.Category)
            .FirstOrDefault(f => f.PostId == PostId);
        }
        public List<Post> GetPostsByCategoryId(int CategoryId)
        {
            return GuzelSozContext.Posts.Where(w => w.CategoryId == CategoryId).ToList();
        }
        public List<Post> GetPostsByCategory(Category category)
        {
            return GuzelSozContext.Posts
            .Include(i => i.Category)
            .Where(w => w.CategoryId == category.CategoryId)
            .ToList();
        }
        public List<Post> LastAdded(int Count)
        {
            return GuzelSozContext.Posts
            .Include(i => i.Category)
            .OrderByDescending(o => o.PostDate)
            .Take(Count)
            .ToList();
        }
        public void PlusClickCount(int PostId)
        {
            var post = GuzelSozContext.Posts
            .FirstOrDefault(w => w.PostId == PostId);

            post.ClickCount += 1;
            GuzelSozContext.SaveChanges();
        }

        public void PlusCommentCount(int PostId)
        {
            var post = GuzelSozContext.Posts
            .FirstOrDefault(w => w.PostId == PostId);

            post.CommentCount += 1;
            GuzelSozContext.SaveChanges();
        }

        public List<Post> MostHaveComment(int Count)
        {
            return GuzelSozContext.Posts
            .Include(i => i.Category)
            .OrderByDescending(o => o.CommentCount)
            .Take(Count)
            .ToList();
        }
    }
}