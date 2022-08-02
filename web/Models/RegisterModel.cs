using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class RegisterModel
    {
        [Display(Name = "Adınız", Prompt = "Adınız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir")]
        public string FirstName { get; set; }

        [Display(Name = "Soyadınız", Prompt = "Soyadınız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir")]
        public string LastName { get; set; }

        [Display(Name = "Kullanıcı adınız", Prompt = "Kullanıcı adınız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [MinLength(5, ErrorMessage = "Minimum 5 karaker olmalıdır")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir")]
        public string Username { get; set; }

        [Display(Name = "E-posta adresiniz", Prompt = "E-posta adresiniz")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Doğru formatta giriniz")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir")]
        public string Email { get; set; }

        [Display(Name = "Parolanız", Prompt = "Parolanız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 karaker olmalıdır")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir")]
        public string Password { get; set; }

        [Display(Name = "Parolanız tekrar girin", Prompt = "Tekrar parolanız")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [MinLength(6, ErrorMessage = "Minimum 6 karaker olmalıdır")]
        [MaxLength(50, ErrorMessage = "Maksimum 50 karakter olabilir")]
        public string RePassword { get; set; }

    }
}