using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DoAnCoThanh.Models;

namespace DoAnCoThanh.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string pass)
        {
            if (string.IsNullOrEmpty(username))
            {
                ViewBag.usernameError = " nhập username đi";
            }
            else if (string.IsNullOrEmpty(pass))
            {
                ViewBag.passwordError = " nhập Password đi";
            }
            else
            {
                if (username.Equals("username") && pass.Equals("abc123"))
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    return RedirectToAction("Index", "HangHoa");
                }
                else
                {
                    ViewBag.invalidData = "Nhập username = username và pass = abc123 đi";
                }
            }
            ViewBag.username = username;
            return View();
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "HangHoa");
        }
    }
}
