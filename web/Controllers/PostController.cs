using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using web.Data.Abstract;
using web.Data.Concrete;
using web.Identity;
using web.Models;

namespace web.Controllers
{
    public class PostController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private UserManager<User> _userManager;
        public PostController(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public IActionResult PostList(string CategoryUrl)
        {
            var category = _unitOfWork.Categories.GetCategory(CategoryUrl);
            var categoryViewModel = new PostListViewModel
            {
                Posts = category.Posts.ToList(),
                Category = category
            };

            _unitOfWork.Categories.PlusClickCount(category.CategoryId);
            return View(categoryViewModel);
        }
        public IActionResult PostDetail(string PostUrl)
        {
            var related = _unitOfWork.Posts.GetPostsByCategory(_unitOfWork.Categories.GetCategoryByPostUrl(PostUrl));
            ViewBag.Related = related;

            var lastAdeed = _unitOfWork.Posts.LastAdded(8);
            ViewBag.Latest = lastAdeed;

            var popular = _unitOfWork.Categories.PopularCategories(8);
            ViewBag.Popular = popular;

            var post = _unitOfWork.Posts.GetPost(PostUrl);
            var postViewModel = new PostDetailViewModel
            {
                Post = post,
                Category = post.Category
            };

            _unitOfWork.Posts.PlusClickCount(post.PostId);
            return View(postViewModel);
        }
        [HttpPost]
        public async Task<CommentReturn> AddComment(int PostId, string UserId, string Comment)
        {
            var post = _unitOfWork.Posts.GetPost(PostId);
            if (post is null)
            {
                return new CommentReturn { Icon = "error", Title = "Hata", Text = "Bilinmeyen bir hata oluştu sayfayı yenileyip tekrar deneyiniz" };
            }

            var user = await _userManager.GetUserAsync(User);
            if (user is null || user.Id != UserId)
            {
                return new CommentReturn { Icon = "error", Title = "Hata", Text = "Hatalı kullanıcı bilgisi. Sayfayı yenileyip tektar deneyiniz" };
            }

            if (Comment is null)
            {
                return new CommentReturn { Icon = "error", Title = "Hata", Text = "Yorum alanı boş bırakılamaz" };
            }

            var lastCommentTime = _unitOfWork.Comments.GetLastCommentTimeByUserId(UserId);
            if ((DateTime.Now - lastCommentTime) < TimeSpan.FromMinutes(1))
            {
                return new CommentReturn { Icon = "info", Title = "Uyarı", Text = "Yeni yorum için 1 dakika beklemeniz gerekmektedir" };
            }
            var newComment = new Comment
            {
                UserId = UserId,
                PostId = PostId,
                Text = Comment
            };
            _unitOfWork.Comments.Create(newComment);
            _unitOfWork.Posts.PlusCommentCount(PostId);
            return new CommentReturn { Icon = "success", Title = "Başarılı", Text = "Yorumunuz onay aşamasından sonra gösterilecektir" };
        }
        [HttpPost]
        public CommentReturn AddReply(string UserId, int CommentId, string Reply)
        {
            if (Reply is null)
            {
                return new CommentReturn { Icon = "error", Title = "Hata", Text = "Cevap alanı boş bırakılamaz" };
            }

            var lastReplyTime = _unitOfWork.Replies.GetLastReplyTimeByUserId(UserId);
            if ((DateTime.Now - lastReplyTime) < TimeSpan.FromMinutes(1))
            {
                return new CommentReturn { Icon = "info", Title = "Uyarı", Text = "Yeni cevap için 1 dakika beklemeniz gerekmektedir" };
            }
            var newReply = new Reply
            {
                CommentId = CommentId,
                UserId = UserId,
                Text = Reply
            };
            _unitOfWork.Replies.Create(newReply);

            return new CommentReturn { Icon = "success", Title = "Başarılı", Text = "Cavabınız onay aşamasından sonra gösterilecektir" };
        }
        // public async Task<IActionResult> AddComment(CommentsModel model)
        // {
        //     var post = _unitOfWork.Posts.GetPost(model.PostId);
        //     if (post == null)
        //     {
        //         CreateAlert("Hata", "Bilinmeyen hata", "danger");
        //         return RedirectToAction("index", "home");
        //     }

        //     var user = await _userManager.GetUserAsync(User);
        //     if (user == null || user.Id != model.UserId || user.FirstName != model.FirstName || user.LastName != model.LastName || user.Email != model.Email || user.UserName != model.UserName)
        //     {
        //         CreateAlert("Hatalı kullanıcı bilgisi", "Kullanıcı bilgilerini manuel olarak değiştirmeyiniz.", "danger");
        //         return Redirect($"~/{post.Category.CategoryUrl}/{post.PostUrl}#commentarea");
        //     }

        //     var newComment = new Comment
        //     {
        //         UserId = model.UserId,
        //         PostId = model.PostId,
        //         Text = model.Comment
        //     };
        //     _unitOfWork.Comments.Create(newComment);
        //     _unitOfWork.Posts.PlusCommentCount(model.PostId);

        //     CreateAlert("Yorumunuz oluşturuldu", "Yorumunuz onay aşamasından sonra gösterilecektir.", "success");
        //     return Redirect($"~/{post.Category.CategoryUrl}/{post.PostUrl}#commentarea");
        // }

        // [HttpPost]
        // public IActionResult AddReply(CommentsModel model)
        // {
        //     var post = _unitOfWork.Posts.GetPost(model.PostId);
        //     var newReply = new Reply
        //     {
        //         CommentId = model.CommentId,
        //         UserId = model.UserId,
        //         Text = model.Reply
        //     };
        //     _unitOfWork.Replies.Create(newReply);

        //     CreateAlert("Cevabınız oluşturuldu", "Cevabınız onay aşamasından sonra gösterilecektir.", "success");
        //     return Redirect($"~/{post.Category.CategoryUrl}/{post.PostUrl}#commentarea");
        // }
        public void CreateAlert(string title, string message, string alertType)
        {
            var alert = new AlertModel
            {
                Title = title,
                Message = message,
                Type = alertType
            };

            TempData["alert"] = JsonConvert.SerializeObject(alert);
        }
    }
}