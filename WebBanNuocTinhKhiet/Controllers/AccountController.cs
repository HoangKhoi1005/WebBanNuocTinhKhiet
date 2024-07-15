using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanNuocTinhKhiet.ViewModel;
using WebBanNuocTinhKhiet.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebBanNuocTinhKhiet.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register(RegisterVM rvm)
        {
            if(ModelState.IsValid)
            {
                var appDbContext = new AppDBContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passwdHash = Crypto.HashPassword(rvm.Password);
                var user = new AppUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.UserName,
                    PasswordHash = passwdHash,
                    PhoneNumber = rvm.Mobile
                };
                IdentityResult identityResult = userManager.Create(user);
                if(identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
            
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(LoginVM lvm)
        {
            var appDbContext = new AppDBContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(lvm.UserName, lvm.Password);
            if(user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);

                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ModelState.AddModelError("myError", "Không tìm thấy username hoặc password");
                return View();
            }
        }

        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}