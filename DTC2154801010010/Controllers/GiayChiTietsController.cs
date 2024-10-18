using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DTC2154801010010.Models
{
    public class GiayChiTietsController : Controller
    {
        private BanGiayEntities1 db = new BanGiayEntities1();

        // GET: GiayChiTiets
        public ActionResult Index()
        {
            var giayChiTiet = db.GiayChiTiet.Include(g => g.ThongTinGiay);
            return View(giayChiTiet.ToList());
        }

        // GET: GiayChiTiets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiayChiTiet giayChiTiet = db.GiayChiTiet.Find(id);
            if (giayChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(giayChiTiet);
        }

        // GET: GiayChiTiets/Create
        public ActionResult Create()
        {
            ViewBag.TTGiay = new SelectList(db.ThongTinGiay, "TTGiay", "Loai");
            return View();
        }

        // POST: GiayChiTiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TenGiay,Mau,Soluong,Gia,TTGiay")] GiayChiTiet giayChiTiet)
        {
            // Kiểm tra tính hợp lệ của số lượng
            if (giayChiTiet.Soluong <= 0)
            {
                ModelState.AddModelError("Soluong", "Số lượng phải là số tự nhiên (nguyên dương).");
            }

            if (ModelState.IsValid)
            {
                db.GiayChiTiet.Add(giayChiTiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TTGiay = new SelectList(db.ThongTinGiay, "TTGiay", "Loai", giayChiTiet.TTGiay);
            return View(giayChiTiet);
        }

        // GET: GiayChiTiets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiayChiTiet giayChiTiet = db.GiayChiTiet.Find(id);
            if (giayChiTiet == null)
            {
                return HttpNotFound();
            }
            ViewBag.TTGiay = new SelectList(db.ThongTinGiay, "TTGiay", "Loai", giayChiTiet.TTGiay);
            return View(giayChiTiet);
        }

        // POST: GiayChiTiets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TenGiay,Mau,Soluong,Gia,TTGiay")] GiayChiTiet giayChiTiet)
        {
            // Kiểm tra tính hợp lệ của số lượng
            if (giayChiTiet.Soluong <= 0)
            {
                ModelState.AddModelError("Soluong", "Số lượng phải là số tự nhiên (nguyên dương).");
            }

            if (ModelState.IsValid)
            {
                db.Entry(giayChiTiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TTGiay = new SelectList(db.ThongTinGiay, "TTGiay", "Loai", giayChiTiet.TTGiay);
            return View(giayChiTiet);
        }    


        // GET: GiayChiTiets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiayChiTiet giayChiTiet = db.GiayChiTiet.Find(id);
            if (giayChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(giayChiTiet);
        }

        // POST: GiayChiTiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiayChiTiet giayChiTiet = db.GiayChiTiet.Find(id);
            db.GiayChiTiet.Remove(giayChiTiet);
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
        public ActionResult Search(string searchString)
        {
            var giayChiTiet = from g in db.GiayChiTiet
                              select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                giayChiTiet = giayChiTiet.Where(s => s.TenGiay.Contains(searchString));
            }

            return View("Index", giayChiTiet.ToList());
        }
    }
}
