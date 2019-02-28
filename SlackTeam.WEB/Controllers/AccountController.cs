using SlackTeam.LIB.Model;
using SlackTeam.LIB.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SlackTeam.WEB.Controllers
{
    public class AccountController : Controller
    {
        UserProvider _provider = new UserProvider();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public JsonResult Login(String Email, String Password, Boolean Remember = false, string ReturnUrl = null)
        {
            try
            {
                User user = _provider.GetByEmailAndPassword(Email, Password);
                if (user != null)
                {
                    if (user.IsActive == true)
                    {
                        base.ViewBag.ReturnUrl = ReturnUrl;
                        FormsAuthenticationTicket formsAuthenticationTicket = new FormsAuthenticationTicket(1, Email, DateTime.Now, DateTime.Now.AddMinutes((Remember) ? (2000.0) : (2000.0)), false, "");

                        string value = FormsAuthentication.Encrypt(formsAuthenticationTicket);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value)
                        {
                            Expires = formsAuthenticationTicket.Expiration,
                            Domain = FormsAuthentication.CookieDomain,
                            Path = FormsAuthentication.FormsCookiePath,
                            HttpOnly = true
                        };
                        base.Response.Cookies.Add(cookie);
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false, content = "Tài khoản chưa được kích hoạt" });
                    }

                }
                else
                {
                    return Json(new { success = false, content = "Email hoặc Mật Khẩu không đúng" });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, content = "Xảy ra sự cố xin vui lòng thử lại sau" });
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}