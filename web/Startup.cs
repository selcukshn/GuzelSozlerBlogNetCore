using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using web.Data.Abstract;
using web.Data.Concrete;
using web.EmailService;
using web.Identity;

namespace web
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //* appsettings.json
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));
            services.AddDbContext<GuzelSozContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // password
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                // lockout
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".guzelsozler.cookie"
                };
            });

            // services.AddScoped<ICategoryRepository, CategoryRepository>();
            // services.AddScoped<IPostRepository, PostRepository>();
            // services.AddScoped<ICommentRepository, CommentRepository>();
            // services.AddScoped<IReplyRepository, ReplyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
            new SmtpEmailSender(
                _configuration["EmailSender:Host"],
                _configuration.GetValue<int>("EmailSender:Port"),
                _configuration.GetValue<bool>("EmailSender:EnableSsl"),
                _configuration["EmailSender:Username"],
                _configuration["EmailSender:Password"]
            ));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //************************** Account
                endpoints.MapControllerRoute(
                   name: "login",
                   pattern: "giris-yap",
                   defaults: new { controller = "account", action = "login" }
                );
                endpoints.MapControllerRoute(
                  name: "register",
                  pattern: "kayit-ol",
                  defaults: new { controller = "account", action = "register" }
                );
                endpoints.MapControllerRoute(
                   name: "logout",
                   pattern: "cikis-yap",
                   defaults: new { controller = "account", action = "logout" }
                );
                endpoints.MapControllerRoute(
                  name: "emailconfirm",
                  pattern: "e-posta-onay",
                  defaults: new { controller = "account", action = "emailconfirm" }
                );
                endpoints.MapControllerRoute(
                   name: "forgotpassword",
                   pattern: "sifremi-unuttum",
                   defaults: new { controller = "account", action = "forgotpassword" }
                );
                endpoints.MapControllerRoute(
                   name: "resetpassword",
                   pattern: "sifremi-sıfırla",
                   defaults: new { controller = "account", action = "resetpassword" }
                );
                endpoints.MapControllerRoute(
                    name: "accessdenied",
                    pattern: "account/accessdenied",
                    defaults: new { controller = "account", action = "accessdenied" }
                );
                endpoints.MapControllerRoute(
                    name: "loginwithreturnurl",
                    pattern: "account/login",
                    defaults: new { controller = "account", action = "login" }
                );
                //************************** Admin
                endpoints.MapControllerRoute(
                    name: "adminindex",
                    pattern: "admin",
                    defaults: new { controller = "admin", action = "index" }
                );
                //* Category
                endpoints.MapControllerRoute(
                    name: "admincategorylist",
                    pattern: "admin/categories",
                    defaults: new { controller = "admin", action = "categorylist" }
                );
                endpoints.MapControllerRoute(
                    name: "admincategorycreate",
                    pattern: "admin/categorycreate",
                    defaults: new { controller = "admin", action = "categorycreate" }
                );
                endpoints.MapControllerRoute(
                    name: "admincategoryedit",
                    pattern: "admin/category/{CategoryId?}",
                    defaults: new { controller = "admin", action = "categoryedit" }
                );
                endpoints.MapControllerRoute(
                    name: "admincategorydelete",
                    pattern: "admin/categorydelete",
                    defaults: new { controller = "admin", action = "categorydelete" }
                );
                //* Post
                endpoints.MapControllerRoute(
                    name: "adminpostlist",
                    pattern: "admin/posts",
                    defaults: new { controller = "admin", action = "postlist" }
                );
                endpoints.MapControllerRoute(
                    name: "adminpostcreate",
                    pattern: "admin/postcreate",
                    defaults: new { controller = "admin", action = "postcreate" }
                );
                endpoints.MapControllerRoute(
                    name: "adminpostedit",
                    pattern: "admin/post/{PostId?}",
                    defaults: new { controller = "admin", action = "postedit" }
                );
                endpoints.MapControllerRoute(
                    name: "adminpostdelete",
                    pattern: "admin/postdelete",
                    defaults: new { controller = "admin", action = "postdelete" }
                );
                //* Role
                endpoints.MapControllerRoute(
                    name: "adminrolelist",
                    pattern: "admin/roles",
                    defaults: new { controller = "admin", action = "rolelist" }
                );
                endpoints.MapControllerRoute(
                    name: "adminrolecreate",
                    pattern: "admin/rolecreate",
                    defaults: new { controller = "admin", action = "rolecreate" }
                );
                endpoints.MapControllerRoute(
                    name: "adminroledelete",
                    pattern: "admin/roledelete",
                    defaults: new { controller = "admin", action = "roledelete" }
                );
                endpoints.MapControllerRoute(
                    name: "adminroleedit",
                    pattern: "admin/role/{RoleId?}",
                    defaults: new { controller = "admin", action = "roleedit" }
                );
                //* User
                endpoints.MapControllerRoute(
                   name: "adminuserlist",
                   pattern: "admin/users",
                   defaults: new { controller = "admin", action = "userlist" }
                );
                endpoints.MapControllerRoute(
                  name: "adminuseredit",
                  pattern: "admin/user/{UserId?}",
                  defaults: new { controller = "admin", action = "useredit" }
                );
                //************************** Home
                endpoints.MapControllerRoute(
                    name: "category",
                    pattern: "kategoriler",
                    defaults: new { controller = "home", action = "category" }
                );
                endpoints.MapControllerRoute(
                   name: "lastadded",
                   pattern: "son-eklenenler",
                   defaults: new { controller = "home", action = "lastadded" }
               );
                endpoints.MapControllerRoute(
                   name: "popular",
                   pattern: "populer",
                   defaults: new { controller = "home", action = "popular" }
               );

                //************************** Post
                endpoints.MapControllerRoute(
                    name: "addcomment",
                    pattern: "post/addcomment",
                    defaults: new { controller = "post", action = "addcomment" }
                );
                endpoints.MapControllerRoute(
                    name: "addreply",
                    pattern: "post/addreply",
                    defaults: new { controller = "post", action = "addreply" }
                );
                endpoints.MapControllerRoute(
                    name: "postlist",
                    pattern: "{categoryurl}",
                    defaults: new { controller = "post", action = "postlist" }
                );
                endpoints.MapControllerRoute(
                   name: "postdetaild",
                   pattern: "{categoryurl}/{posturl?}",
                   defaults: new { controller = "post", action = "postdetail" }
                );

                //************************** Default
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
