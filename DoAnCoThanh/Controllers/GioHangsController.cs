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
    public class GioHangsController : Controller
    {
        private  const string GioHang = "GioHang";
        private DoAnContext db = new DoAnContext();

        // GET: GioHangs
        public ActionResult Index()
        {
            var Gio = Session[GioHang];
            var list = new List<GioHang>();
            if (Gio != null)
            {
                list =(List<GioHang>)Gio;
            }
            return View(db.GioHangs.ToList());
        }

        // GET: GioHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // GET: GioHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GioHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSp,SoLuong")] GioHang gioHang)
        {
            if (ModelState.IsValid)
            {
                db.GioHangs.Add(gioHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gioHang);
        }

        // GET: GioHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // POST: GioHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSp,SoLuong")] GioHang gioHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gioHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gioHang);
        }

        // GET: GioHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // POST: GioHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GioHang gioHang = db.GioHangs.Find(id);
            db.GioHangs.Remove(gioHang);
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
        public ActionResult AddItem ( int MaSp , int SoLuong)
        {
            var abc = new HangHoa().ViewDetails(MaSp);
            var Gio = Session[GioHang];
            if (Gio != null)
            {
                var list = (List<GioHang>)Gio;
                if (list.Exists(x=>x.MaSp==MaSp))
                {
                    foreach (var item in list)
                    {
                        if (item.MaSp == MaSp)
                        {
                            item.SoLuong += SoLuong;
                        }
                    }

                }
                else
                {
                    var item = new GioHang();
                    item.MaSp = MaSp;
                    item.SoLuong = SoLuong;
                    list.Add(item);
                }
                
            }
            else
            {
                // tạo mới cái giỏ
                var item = new GioHang();
                    item.MaSp = MaSp;
                item.SoLuong = SoLuong;
                var list =  new List<GioHang>();
                // gán vô session
                Session[GioHang] = list;
            };
                
        return RedirectToAction("Index");
        }
    }
}
