using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNPMNC.Areas.Admin.Controllers;
using CNPMNC.Models;

namespace CNPMNC.Controllers
{
    public class Thue_PhongController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: Thue_Phong
        public ActionResult Index()
        {
            var thue_Phongs = db.Thue_Phongs.Include(t => t.Phong);
            return View(thue_Phongs.ToList());
        }

        // GET: Thue_Phong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thue_Phong thue_Phong = db.Thue_Phongs.Find(id);
            if (thue_Phong == null)
            {
                return HttpNotFound();
            }
            return View(thue_Phong);
        }

        // GET: Thue_Phong/Create
        public ActionResult Create()
        {
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong");
            return View();
        }

        // POST: Thue_Phong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TP_ID,NgayThue,PhongID")] Thue_Phong thue_Phong)
        {
            if (ModelState.IsValid)
            {
                db.Thue_Phongs.Add(thue_Phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong", thue_Phong.PhongID);
            return View(thue_Phong);
        }

        // GET: Thue_Phong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thue_Phong thue_Phong = db.Thue_Phongs.Find(id);
            if (thue_Phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong", thue_Phong.PhongID);
            return View(thue_Phong);
        }

        // POST: Thue_Phong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TP_ID,NgayThue,PhongID")] Thue_Phong thue_Phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thue_Phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong", thue_Phong.PhongID);
            return View(thue_Phong);
        }

        // GET: Thue_Phong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thue_Phong thue_Phong = db.Thue_Phongs.Find(id);
            if (thue_Phong == null)
            {
                return HttpNotFound();
            }
            return View(thue_Phong);
        }

        // POST: Thue_Phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thue_Phong thue_Phong = db.Thue_Phongs.Find(id);
            db.Thue_Phongs.Remove(thue_Phong);
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
