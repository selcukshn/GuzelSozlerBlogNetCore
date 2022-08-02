using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string UserId { get; set; }

        [Display(Name = "E-posta adresiniz", Prompt = "E-posta adresiniz")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Doğru formatta giriniz")]
        public string Email { get; set; }

        [Display(Name = "Parolanız", Prompt = "Parolanız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 karaker olmalıdır")]
        public string Password { get; set; }

        [Display(Name = "Parolanız tekrar girin", Prompt = "Tekrar parolanız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [MinLength(6, ErrorMessage = "Minimum 6 karaker olmalıdır")]
        public string RePassword { get; set; }
    }
}