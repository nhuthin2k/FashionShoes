using DoAnCoThanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCoThanh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.HangHoa = new HangHoa();
          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}