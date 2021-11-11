using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnCoThanh.Models;

namespace DoAnCoThanh.Controllers
{
    public class HangHoasController : Controller
    {
        private DoAnContext db = new DoAnContext();

        // GET: HangHoas
        public ActionResult Index()
        {
            return View(db.HangHoas.ToList());
        }

        // GET: HangHoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // GET: HangHoas/Create
     
        public ActionResult Create()
        {
            return View();
        }

        // POST: HangHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSp,TenSp,NhaCungCap,Gia,ChatLieu,SoLuong")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hangHoa);
        }

        // GET: HangHoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // POST: HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSp,TenSp,NhaCungCap,Gia,ChatLieu,SoLuong")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangHoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hangHoa);
        }

        // GET: HangHoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }
       
        public ActionResult ChiTietHangHoa(int id) {
            DoAnContext db = new DoAnContext();
            ViewBag.ChiTiet = db.HangHoas.FirstOrDefault(HangHoa => HangHoa.MaSp  == id );
           
            return View();
        }
        public ActionResult BTS()
        {
            DoAnContext db = new DoAnContext();
            ViewBag.MaryJane = db.HangHoas.Where(HangHoa => HangHoa.LoaiGiay == "GIÀY MARY JANE").ToList<HangHoa>();

            return View();
        }
        public ActionResult GiayBATA()
        { 
            DoAnContext db = new DoAnContext();
        ViewBag.GiayBT = db.HangHoas.Where(HangHoa => HangHoa.LoaiGiay == "giày BATA").ToList<HangHoa>();
            
            return View();
    }

        // POST: HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HangHoa hangHoa = db.HangHoas.Find(id);
            db.HangHoas.Remove(hangHoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
