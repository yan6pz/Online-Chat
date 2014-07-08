using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineChat.Models;

namespace OnlineChat.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            if (form["username"] != null && form["password"] != null)
                if (UserRepository.CheckUserLogin(form["username"].ToString(), form["password"].ToString()))
                {
                    var cookie = FormsAuthentication.GetAuthCookie(form["username"].ToString(), true);
                    cookie.Expires = DateTime.Now.Add(new TimeSpan(14, 0, 0, 0));
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }

            ViewData.Add("Message", "FAIL!");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
