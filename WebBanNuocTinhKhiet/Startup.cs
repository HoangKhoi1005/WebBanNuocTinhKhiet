using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using WebBanNuocTinhKhiet.Identity;

[assembly: OwinStartup(typeof(WebBanNuocTinhKhiet.Startup))]

namespace WebBanNuocTinhKhiet
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            this.CreateRolesAndUser();
        }

        public void CreateRolesAndUser()
        {
            var roleManger = new RoleManager<IdentityRole>(new
                RoleStore<IdentityRole>(new AppDBContext()));
            var appDbContext = new AppDBContext();
            var appUserStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(appUserStore);

            if (!roleManger.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManger.Create(role);
            }

            if(userManager.FindByName("admin") == null)
            {
                var user = new AppUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPwd = "admin123";

                var chkUser = userManager.Create(user, userPwd);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManger.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManger.Create(role);
            }
        }
    }
}
