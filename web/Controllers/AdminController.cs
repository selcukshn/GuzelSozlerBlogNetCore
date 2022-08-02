using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using web.Data.Concrete;
using data;
using web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using web.Identity;
using web.Data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitOfWork;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public AdminController(
                                ILogger<HomeController> logger,
                                IUnitOfWork unitOfWork,
                                UserManager<User> userManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //* Post
        public IActionResult PostList()
        {
            ViewBag.Action = RouteData.Values["action"];

            return View(_unitOfWork.Posts.GetAll());
        }

        public IActionResult PostCreate()
        {
            ViewBag.Action = RouteData.Values["action"];
            ViewBag.Categories = _unitOfWork.Categories.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostCreate(PostEditCreateModel model, IFormFile PostImg)
        {
            ViewBag.Action = RouteData.Values["action"];
            if (PostImg != null)
            {
                var extention = Path.GetExtension(PostImg.FileName);
                var imageName = string.Format($"{Guid.NewGuid()}{extention}");
                model.PostImg = imageName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\post", imageName);

                var newPost = new Post
                {
                    PostTitle = model.PostTitle,
                    PostImg = model.PostImg,
                    PostSummary = model.PostSummary,
                    PostUrl = model.PostUrl,
                    AddedBy = model.AddedBy,
                    PostContent = model.PostContent,
                    CategoryId = (int)model.CategoryId
                };

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await PostImg.CopyToAsync(stream);
                };

                _unitOfWork.Posts.Create(newPost);

                CreateAlert($"{model.PostTitle} eklendi", "success");

                ViewBag.Categories = _unitOfWork.Categories.GetAll();

                return RedirectToAction("postlist");
            }
            else
            {
                var alert = new AlertModel
                {
                    Message = $"{model.PostTitle} eklenemedi",
                    Type = "danger"
                };

                TempData["alert"] = JsonConvert.SerializeObject(alert);
                ViewBag.Categories = _unitOfWork.Categories.GetAll();

                return View();
            }
        }
        public IActionResult PostEdit(int PostId)
        {
            ViewBag.Action = RouteData.Values["action"];
            ViewBag.Categories = _unitOfWork.Categories.GetAll();

            var post = _unitOfWork.Posts.GetPost(PostId);

            return View(new PostEditCreateModel()
            {
                PostId = post.PostId,
                PostTitle = post.PostTitle,
                PostSummary = post.PostSummary,
                PostImg = post.PostImg,
                PostUrl = post.PostUrl,
                AddedBy = post.AddedBy,
                PostContent = post.PostContent,
                CategoryId = post.CategoryId
            });
        }
        [HttpPost]
        public async Task<IActionResult> PostEdit(PostEditCreateModel model, IFormFile file)
        {
            ViewBag.Action = RouteData.Values["action"];

            var post = _unitOfWork.Posts.GetById(model.PostId);
            post.PostTitle = model.PostTitle;
            post.PostSummary = model.PostSummary;
            post.PostUrl = model.PostUrl;
            post.AddedBy = model.AddedBy;
            post.PostContent = model.PostContent;
            post.CategoryId = (int)model.CategoryId;

            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var imageName = string.Format($"{Guid.NewGuid()}{extention}");
                model.PostImg = imageName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\post", imageName);

                post.PostImg = model.PostImg;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                };
            }

            CreateAlert($"{post.PostTitle} güncellendi", "warning");

            _unitOfWork.Posts.Update(post);
            return RedirectToAction("postlist");
        }
        [HttpPost]
        public IActionResult PostDelete(int PostId)
        {
            var post = _unitOfWork.Posts.GetById(PostId);
            _unitOfWork.Posts.Delete(post);

            CreateAlert($"{post.PostTitle} silindi", "danger");

            return RedirectToAction("postlist");

        }
        //* Category
        public IActionResult CategoryList()
        {
            ViewBag.Action = RouteData.Values["action"];

            return View(_unitOfWork.Categories.GetAll());
        }
        public IActionResult CategoryCreate()
        {
            ViewBag.Action = RouteData.Values["action"];

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CategoryEditCreateModel model, IFormFile CategoryImg)
        {
            ViewBag.Action = RouteData.Values["action"];

            if (CategoryImg != null)
            {
                var extention = Path.GetExtension(CategoryImg.FileName);
                var imageName = string.Format($"{Guid.NewGuid()}{extention}");
                model.CategoryImg = imageName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\category", imageName);

                var newCategory = new Category
                {
                    CategoryName = model.CategoryName,
                    CategoryImg = model.CategoryImg,
                    CategoryUrl = model.CategoryUrl,
                    ShowHome = model.ShowHome
                };

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await CategoryImg.CopyToAsync(stream);
                };

                _unitOfWork.Categories.Create(newCategory);

                CreateAlert($"{model.CategoryName} eklendi", "success");

                return RedirectToAction("categorylist");
            }
            else
            {
                var alert = new AlertModel
                {
                    Message = $"{model.CategoryName} eklenemedi",
                    Type = "danger"
                };

                TempData["alert"] = JsonConvert.SerializeObject(alert);
                return View();
            }
        }
        public IActionResult CategoryEdit(int CategoryId)
        {
            ViewBag.Action = RouteData.Values["action"];

            var category = _unitOfWork.Categories.GetCategory(CategoryId);
            return View(new CategoryEditCreateModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                CategoryUrl = category.CategoryUrl,
                CategoryImg = category.CategoryImg,
                ShowHome = category.ShowHome,
                Post = category.Posts.ToList()
            });
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryEditCreateModel model, IFormFile file)
        {
            ViewBag.Action = RouteData.Values["action"];

            var category = _unitOfWork.Categories.GetById(model.CategoryId);
            category.CategoryName = model.CategoryName;
            category.CategoryUrl = model.CategoryUrl;
            category.ShowHome = model.ShowHome;
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var imageName = string.Format($"{Guid.NewGuid()}{extention}");
                model.CategoryImg = imageName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\category", imageName);

                category.CategoryImg = model.CategoryImg;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                };
            }
            _unitOfWork.Categories.Update(category);

            CreateAlert($"{model.CategoryName} güncellendi", "warning");

            return RedirectToAction("categorylist");

        }
        [HttpPost]
        public IActionResult CategoryDelete(int CategoryId)
        {
            var category = _unitOfWork.Categories.GetById(CategoryId);
            _unitOfWork.Categories.Delete(category);


            CreateAlert($"{category.CategoryName} silindi", "danger");
            return RedirectToAction("categorylist");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //* Role
        public IActionResult RoleList()
        {
            ViewBag.Action = RouteData.Values["action"];

            return View(_roleManager.Roles);
        }
        public IActionResult RoleCreate()
        {
            ViewBag.Action = RouteData.Values["action"];

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            ViewBag.Action = RouteData.Values["action"];

            var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
            if (result.Succeeded)
            {
                CreateAlert($"{model.Name} eklendi", "success");
                return RedirectToAction("rolelist", "admin");
            }
            else
            {
                string errors = "";
                foreach (var error in result.Errors)
                {
                    errors += error;
                }
                CreateAlert(errors, "danger");
                return View(model);
            }
        }

        public async Task<IActionResult> RoleEdit(string RoleId)
        {
            ViewBag.Action = RouteData.Values["action"];

            var role = await _roleManager.FindByIdAsync(RoleId);
            if (role == null)
            {
                CreateAlert("Rol bulunamadı", "danger");
                return RedirectToAction("rolelist", "admin");
            }
            var users = _userManager.Users.ToList();

            var members = new List<User>();
            var nonmembers = new List<User>();
            foreach (var user in users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonmembers;
                list.Add(user);
            }
            var model = new RoleDetails
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            ViewBag.Action = RouteData.Values["action"];

            foreach (var userId in model.AddRoleIds ?? new string[] { })
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        string errors = "";
                        foreach (var error in result.Errors)
                        {
                            errors += error;
                        }
                        CreateAlert(errors, "danger");
                        return View(model);
                    }
                }
            }
            foreach (var userId in model.DeleteRoleIds ?? new string[] { })
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                    if (!result.Succeeded)
                    {
                        string errors = "";
                        foreach (var error in result.Errors)
                        {
                            errors += error;
                        }
                        CreateAlert(errors, "danger");
                        return View(model);
                    }
                }
            }
            CreateAlert("Roller güncellendi", "success");
            return Redirect("/admin/roleedit/" + model.RoleId);
        }
        //* User
        //  public async Task<IActionResult> UserList()
        public IActionResult UserList()
        {
            ViewBag.Action = RouteData.Values["action"];
            var users = _userManager.Users.ToList();
            var userList = new List<UserItemModel>() { };
            foreach (var user in users)
            {
                userList.Add(new UserItemModel
                {
                    User = user
                });
            }

            // var userList = new UserModel()
            // {
            //     Users = users.Select(async s => new UserItemModel
            //     {
            //         User = s,
            //         UserRoles = await _userManager.GetRolesAsync(s)
            //     }).ToList()
            // };

            return View(userList);
        }
        public async Task<IList<string>> GetUserRole(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<ActionResult> UserEdit(string UserId)
        {
            ViewBag.Action = RouteData.Values["action"];

            var user = await _userManager.FindByIdAsync(UserId);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(s => s.Name);
                ViewBag.Roles = roles;

                return View(new UserEditModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles = selectedRoles
                });
            }
            CreateAlert("Kullanıcı bulunamadı", "danger");
            return RedirectToAction("userlist", "admin");
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditModel model, string[] selectedRoles)
        {
            ViewBag.Action = RouteData.Values["action"];

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.EmailConfirmed = model.EmailConfirmed;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                    await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                    CreateAlert("Kullanıcı bilgileri güncellendi", "success");
                    return RedirectToAction("userlist", "admin");
                }
            }
            CreateAlert("Hatalı kullanıcı", "danger");
            return RedirectToAction("userlist", "admin");
        }



        public IActionResult Error()
        {
            return View("Error!");
        }
        public void CreateAlert(string message, string alertType)
        {
            var alert = new AlertModel
            {
                Message = message,
                Type = alertType
            };
            TempData["alert"] = JsonConvert.SerializeObject(alert);
        }
    }
}