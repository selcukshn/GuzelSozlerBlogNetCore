using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;

namespace web.Data.Abstract
{
    public interface IReplyRepository : IRepository<Reply>
    {
        int GetReplyIdByReply(string reply, string UserId);
        DateTime GetLastReplyTimeByUserId(string UserId);
    }
}