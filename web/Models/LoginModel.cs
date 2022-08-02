using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class LoginModel
    {
        [Display(Name = "Kullanıcı adı", Prompt = "Kullanıcı adınızı girin")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        public string Username { get; set; }

        [Display(Name = "Parola", Prompt = "Parolanızı girin")]
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 karaker olmalıdır")]
        public string Password { get; set; }
        // public string Email { get; set; }
        public string ReturnUrl { get; set; }
    }
}