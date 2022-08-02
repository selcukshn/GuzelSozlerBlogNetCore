using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.EntityFrameworkCore;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class ReplyRepository : GenericRepository<Reply>, IReplyRepository
    {
        public ReplyRepository(GuzelSozContext context) : base(context)
        {

        }
        private GuzelSozContext GuzelSozContext { get { return _context as GuzelSozContext; } }

        public DateTime GetLastReplyTimeByUserId(string UserId)
        {
            return GuzelSozContext.Replies
            .Where(w => w.UserId == UserId)
            .OrderByDescending(o => o.ReplyDate)
            .Select(s => s.ReplyDate)
            .FirstOrDefault();
        }

        public int GetReplyIdByReply(string reply, string UserId)
        {
            return GuzelSozContext.Replies
            .Where(w => w.UserId == UserId && w.Text == reply)
            .Select(s => s.Id)
            .FirstOrDefault();
        }
    }
}