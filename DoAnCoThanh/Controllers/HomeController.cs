﻿using DoAnCoThanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCoThanh.Controllers
{
    public class HomeController : Controller
    {
        /*
        trang chủ trang ng dùng
        
         */
        DoAnContext db = new DoAnContext();
        public ActionResult Index()
        {
            
            ViewBag.ListHangHoa = db.HangHoas.Where(HangHoa=>HangHoa.LoaiGiay == "giày thể thao\r\n").ToList<HangHoa>();
            ViewBag.ListHangHoa1 = db.HangHoas.Where(HangHoa=>HangHoa.LoaiGiay == "giày cao gót").ToList<HangHoa>();
            var ListHangHoa = db.HangHoas.ToList();
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