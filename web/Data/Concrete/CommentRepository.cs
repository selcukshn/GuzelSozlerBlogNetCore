using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.EntityFrameworkCore;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(GuzelSozContext context) : base(context)
        {

        }
        private GuzelSozContext GuzelSozContext { get { return _context as GuzelSozContext; } }
        public List<Comment> GetCommentsByPostId(int PostId)
        {
            return GuzelSozContext.Comments
            .Include(i => i.Replies)
            .Where(w => w.PostId == PostId)
            .ToList();
        }

        public DateTime GetLastCommentTimeByUserId(string UserId)
        {
            return GuzelSozContext.Comments
            .Where(w => w.UserId == UserId)
            .OrderByDescending(o => o.CommentDate)
            .Select(s => s.CommentDate)
            .FirstOrDefault();
        }
    }
}