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
    public class ThongTinGiaysController : Controller
    {
        private BanGiayEntities1 db = new BanGiayEntities1();

        // GET: ThongTinGiays
        public ActionResult Index()
        {
            return View(db.ThongTinGiay.ToList());
        }

        // GET: ThongTinGiays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinGiay thongTinGiay = db.ThongTinGiay.Find(id);
            if (thongTinGiay == null)
            {
                return HttpNotFound();
            }
            return View(thongTinGiay);
        }

        // GET: ThongTinGiays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongTinGiays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TTGiay,Loai,ThongTin")] ThongTinGiay thongTinGiay)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinGiay.Add(thongTinGiay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongTinGiay);
        }

        // GET: ThongTinGiays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinGiay thongTinGiay = db.ThongTinGiay.Find(id);
            if (thongTinGiay == null)
            {
                return HttpNotFound();
            }
            return View(thongTinGiay);
        }

        // POST: ThongTinGiays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TTGiay,Loai,ThongTin")] ThongTinGiay thongTinGiay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinGiay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongTinGiay);
        }

        // GET: ThongTinGiays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinGiay thongTinGiay = db.ThongTinGiay.Find(id);
            if (thongTinGiay == null)
            {
                return HttpNotFound();
            }
            return View(thongTinGiay);
        }

        // POST: ThongTinGiays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTinGiay thongTinGiay = db.ThongTinGiay.Find(id);
            db.ThongTinGiay.Remove(thongTinGiay);
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
