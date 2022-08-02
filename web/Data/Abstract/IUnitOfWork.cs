using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using web.EmailService;
using web.Identity;

namespace web.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IPostRepository Posts { get; }
        IReplyRepository Replies { get; }
        void Save();
    }
}