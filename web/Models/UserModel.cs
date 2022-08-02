using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using web.Identity;

namespace web.Models
{
    public class UserEditModel
    {
        public string UserId { get; set; }

        [Display(Name = "Kullanıcı adı")]
        [Required(ErrorMessage = "*Kullanıcı adı boş bırakılamaz")]
        public string UserName { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "*Ad boş bırakılamaz")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "*Soyad boş bırakılamaz")]
        public string LastName { get; set; }

        [Display(Name = "E-posta")]
        [Required(ErrorMessage = "*E-posta boş bırakılamaz")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        public IEnumerable<string> SelectedRoles { get; set; }
    }
    public class UserModel
    {
        public List<Task<UserItemModel>> Users { get; set; }
    }
    public class UserItemModel
    {
        public User User { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
    }

}