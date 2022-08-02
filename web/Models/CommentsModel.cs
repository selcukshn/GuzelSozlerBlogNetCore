using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using data;
using web.Identity;

namespace web.Models
{
    public class CommentsModel
    {
        [Required]
        public int CommentId { get; set; }
        [Required]
        public int PostId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Ad")]

        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Kullanıcı adı")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Yorum alanı boş bırakılamaz  ")]
        [MaxLength(500, ErrorMessage = "*Yorumunuz en fazla 500 karakter olabilir")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "*Cevap alanı boş bırakılamaz  ")]
        [MaxLength(500, ErrorMessage = "*Cevabınız en fazla 500 karakter olabilir")]
        public string Reply { get; set; }
        public List<CommentViewModel> CommentViewModel { get; set; }
    }
    public class CommentViewModel
    {
        public User User { get; set; }
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
        public List<ReplyViewModel> ReplyViewModel { get; set; }
    }
    public class ReplyViewModel
    {
        public Reply Replies { get; set; }
        public User User { get; set; }
    }

    public class CommentReturn
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }

}