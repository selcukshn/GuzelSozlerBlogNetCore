using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Identity;
using web.Data.Abstract;
using web.EmailService;
using web.Identity;

namespace web.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GuzelSozContext _context;
        public UnitOfWork(GuzelSozContext context)
        {
            _context = context;
        }

        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;
        private PostRepository _postRepository;
        private ReplyRepository _replyRepository;


        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ?? new CommentRepository(_context);

        public IPostRepository Posts => _postRepository ?? new PostRepository(_context);

        public IReplyRepository Replies => _replyRepository ?? new ReplyRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}