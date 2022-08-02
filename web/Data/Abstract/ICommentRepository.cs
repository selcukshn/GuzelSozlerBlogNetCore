using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Data.Abstract
{
    public interface ICommentRepository : IRepository<Comment>
    {
        List<Comment> GetCommentsByPostId(int PostId);
        DateTime GetLastCommentTimeByUserId(string UserId);
    }
}