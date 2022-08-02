using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web.Data.Abstract;
using web.Identity;
using web.Models;

namespace web.ViewComponents.CommentsViewComponent
{
    public class CommentsViewComponent : ViewComponent
    {
        private UserManager<User> _userManager;
        private IUnitOfWork _unitOfWork;
        public CommentsViewComponent(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.Users.FirstOrDefault(f => f.UserName == User.Identity.Name);
            var post = _unitOfWork.Posts.GetPost(RouteData.Values["posturl"].ToString());
            var comment = _unitOfWork.Comments.GetCommentsByPostId(post.PostId);

            ViewBag.Controller = post.Category.CategoryUrl;
            ViewBag.Action = post.PostUrl;
            if (user != null)
            {
                return View(new CommentsModel
                {
                    PostId = post.PostId,
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CommentViewModel = comment.Select(s => new CommentViewModel
                    {
                        User = _userManager.Users.FirstOrDefault(f => f.Id == s.UserId),
                        CommentId = s.Id,
                        Text = s.Text,
                        CommentDate = s.CommentDate,
                        ReplyViewModel = s.Replies.Select(ss => new ReplyViewModel
                        {
                            Replies = ss,
                            User = _userManager.Users.FirstOrDefault(f => f.Id == ss.UserId)

                        }).ToList()
                    }).ToList()

                });
            }
            return View(new CommentsModel() { });
        }
    }
}