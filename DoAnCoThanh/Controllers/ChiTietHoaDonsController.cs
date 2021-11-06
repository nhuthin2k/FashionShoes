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
    
    public class ChiTietHoaDonsController : Controller
    {
        private DoAnContext db = new DoAnContext();

        // GET: ChiTietHoaDons1
        public ActionResult Index()
        {
            return View(db.ChiTietHoaDons.ToList());
        }

        // GET: ChiTietHoaDons1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiTietHoaDons1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,MaSanPham,SoLuong,DonGia,NhanVienTuVan")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoaDons.Add(chiTietHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDons1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,MaSanPham,SoLuong,DonGia,NhanVienTuVan")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDons1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            db.ChiTietHoaDons.Remove(chiTietHoaDon);
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
