using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using web.Identity;

namespace web.Models
{
    public class RoleModel
    {
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [Display(Name = "Rol", Prompt = "Rol girin")]

        public string Name { get; set; }
    }

    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }

    }
    public class RoleEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] AddRoleIds { get; set; }
        public string[] DeleteRoleIds { get; set; }
    }
}