using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using web.EmailService;
using web.Identity;
using web.Models;

namespace web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel { ReturnUrl = ReturnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı bulunamadı");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Giriş yapabilmek için e-posta adresinizi onaylamalısınız");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                using (var context = new IdentityContext())
                {
                    context.Users.FirstOrDefault(f => f.Id == user.Id).LastLogin = DateTime.Now;
                    context.SaveChanges();
                }

                return Redirect(model.ReturnUrl ?? "~/");
            }
            ModelState.AddModelError("", "Parola yanlış");
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            // @@@@@ Google smtp kullanımını kapattığı için bu fonksiyon devre dışı bırakıldı @@@@@@@@@@

            // if (!ModelState.IsValid)
            // {
            //     return View(model);
            // }
            // // Username kontrolü
            // var checkUsername = await _userManager.FindByNameAsync(model.Username);
            // if (checkUsername != null)
            // {
            //     ModelState.AddModelError("", "Bu kullanıcı adı daha önce alınmış");
            //     return View(model);
            // }
            // // Email kontrolü
            // var checkEmail = await _userManager.FindByEmailAsync(model.Email);
            // if (checkEmail != null)
            // {
            //     ModelState.AddModelError("", "Bu e-posta adresi daha önce kullanılmış");
            //     return View(model);
            // }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Generate token
                var newToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                // var url = Url.Action("EmailConfirm", "Account", new
                // {
                //     userId = user.Id,
                //     token = newToken
                // });
                // await _emailSender.SendEmailAsync(model.Email, "Hesabınızı onaylayın", $"Hesabınızı onaylamak için <a href='https://localhost:5001{url}'>tıklayın</a>");

                // smtp sunucusu değiştirildikten sonra kaldırılacak {
                var checkUser = await _userManager.FindByIdAsync(user.Id);
                await _userManager.ConfirmEmailAsync(checkUser, newToken);
                // }


                CreateAlert("Hesabınız oluşturuldu", "Kaydınızın tamamlanması için gerenek bağlantı e-posta adresinize gönderildi. Spam kutusunu kontrol ediniz", "success");

                return RedirectToAction("Login", "Account");
            }

            CreateAlert("Hata", "Bilinmeyen bir hata oluştu tekrar deneyin", "danger");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        public async Task<IActionResult> EmailConfirm(string userId, string token)
        {
            if (userId == null || token == null)
            {
                CreateAlert("Hata", "Geçersiz istek", "danger");
                return RedirectToAction("login", "account");
            }
            // User kontrolü
            var checkUser = await _userManager.FindByIdAsync(userId);
            if (checkUser == null)
            {
                CreateAlert("Hata", "Geçersiz kullanıcı", "danger");
                return RedirectToAction("login", "account");
            }

            var result = await _userManager.ConfirmEmailAsync(checkUser, token);
            if (result.Succeeded)
            {
                CreateAlert("Hesabınız onaylandı", "Giriş yapabilirsiniz", "success");
                return RedirectToAction("login", "account");
            }
            CreateAlert("Hata", "Hesabınız onaylanamadı", "danger");
            return RedirectToAction("login", "account");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                CreateAlert("Uyarı", "E-posta adresinizi giriniz", "danger");
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                CreateAlert("Hata", "E-posta adresi bulunamadı", "danger");
                return View();
            }

            // Generate token
            var newToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = newToken
            });
            await _emailSender.SendEmailAsync(email, "Şifrenizi sıfırlayın", $"Şifrenizi sıfırlamak için <a href='https://localhost:5001{url}'>tıklayın</a>");

            CreateAlert("Başarılı", "Şifrenizi yenilemeniz için gereken bağlantı e-posta adresinize gönderildi. Spam kutusunu kontrol ediniz", "success");

            return View();
        }
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                CreateAlert("Hata", "Geçersiz istek", "danger");
                return RedirectToAction("login", "account");
            }
            var model = new ResetPasswordModel { Token = token };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                CreateAlert("Hata", "Geçersiz istek", "danger");
                return RedirectToAction("login", "account");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                CreateAlert("Şifreniz sıfırlandı", "Yeni şifreniz ile giriş yapabilirsiniz", "success");
                return RedirectToAction("login", "account");
            }
            else
            {
                string errors = "";
                foreach (var error in result.Errors)
                {
                    errors += error.ToString();
                }
                CreateAlert("Hata", errors, "danger");
                return RedirectToAction("login", "account");
            }
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
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