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
    public class GioHangsController : Controller//DonHangController
    {
        private  const string GioHang = "GioHang";
        private DoAnContext db = new DoAnContext();

        // GET: GioHangs
        public ActionResult Index()//hiển thị danh sách sp trong giỏ hàng- session
        {
            var Gio = Session["GioHang"];//lấy giỏ hàng trong session

            ViewBag.listGio = Gio;//convert sang list
           
            return View();//đẩy list sang view
        }

        // GET: GioHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang DonHang = db.DonHang.Find(id);
            if (DonHang == null)
            {
                return HttpNotFound();
            }
            return View(DonHang);
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
        public ActionResult Create([Bind(Include = "MaSp,SoLuong")] DonHang DonHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHang.Add(DonHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(DonHang);
        }

        // GET: GioHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang DonHang = db.DonHang.Find(id);
            if (DonHang == null)
            {
                return HttpNotFound();
            }
            return View(DonHang);
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
            DonHang DonHang = db.DonHang.Find(id);
            if (DonHang == null)
            {
                return HttpNotFound();
            }
            return View(DonHang);
        }

        // POST: GioHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang DonHang = db.DonHang.Find(id);
            db.DonHang.Remove(DonHang);
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
        public ActionResult AddItem (int MaSp , int SoLuong=1)
        {
            var itemSelected = db.HangHoas.Find(MaSp);
            var Gio = Session["GioHang"];
            if(itemSelected != null)
            {
                if (Gio != null)
                {
                    var list = (List<GioHang>)Gio;
                    if (list.Exists(x=>x.hangHoa.MaSp==MaSp))
                    {
                        foreach (var item in list)
                        {
                            if (item.hangHoa.MaSp == MaSp)
                            {
                                item.SoLuong += SoLuong;
                            }
                        }

                    }
                    else
                    {
                        var item = new GioHang();
                        item.hangHoa = itemSelected;
                        item.SoLuong = 1;
                        list.Add(item);
                    }
                    Session["GioHang"] = list;
                }
                else
                {
                    // tạo mới cái giỏ
                    var item = new GioHang();
                        item.hangHoa = itemSelected;
                    item.SoLuong = SoLuong;
                    var list =  new List<GioHang>();
                    list.Add(item);
                    // gán vô session
                    Session["GioHang"] = list;
                };
            }
            var Gio2 = Session["GioHang"];
            return RedirectToAction("Index");
        }
        [HttpPost]
        public  ActionResult updateSoLuong(int idProduct,int SoLuong)
        {
            var itemSelected = db.HangHoas.Find(idProduct);
            var Gio = Session["GioHang"];
            if (itemSelected != null)
            {
                if (Gio != null)
                {
                    var list = (List<GioHang>)Gio;
                    if (list.Exists(x => x.hangHoa.MaSp == idProduct))
                    {
                        foreach (var item in list)
                        {
                            if (item.hangHoa.MaSp == idProduct)
                            {
                                item.SoLuong = SoLuong;
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
