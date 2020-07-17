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
    public class CT_Thue_PhongController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: CT_Thue_Phong
        public ActionResult Index()
        {
            var cT_Thue_Phongs = db.CT_Thue_Phongs.Include(c => c.Thue_Phong);
            return View(cT_Thue_Phongs.ToList());
        }

        // GET: CT_Thue_Phong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Thue_Phong cT_Thue_Phong = db.CT_Thue_Phongs.Find(id);
            if (cT_Thue_Phong == null)
            {
                return HttpNotFound();
            }
            return View(cT_Thue_Phong);
        }

        // GET: CT_Thue_Phong/Create
        public ActionResult Create()
        {
            ViewBag.TP_ID = new SelectList(db.Thue_Phongs, "TP_ID", "TP_ID");
            return View();
        }

        // POST: CT_Thue_Phong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CT_TP_ID,TP_ID,KhachID")] CT_Thue_Phong cT_Thue_Phong)
        {
            if (ModelState.IsValid)
            {
                db.CT_Thue_Phongs.Add(cT_Thue_Phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TP_ID = new SelectList(db.Thue_Phongs, "TP_ID", "TP_ID", cT_Thue_Phong.TP_ID);
            return View(cT_Thue_Phong);
        }

        // GET: CT_Thue_Phong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Thue_Phong cT_Thue_Phong = db.CT_Thue_Phongs.Find(id);
            if (cT_Thue_Phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.TP_ID = new SelectList(db.Thue_Phongs, "TP_ID", "TP_ID", cT_Thue_Phong.TP_ID);
            return View(cT_Thue_Phong);
        }

        // POST: CT_Thue_Phong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CT_TP_ID,TP_ID,KhachID")] CT_Thue_Phong cT_Thue_Phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_Thue_Phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TP_ID = new SelectList(db.Thue_Phongs, "TP_ID", "TP_ID", cT_Thue_Phong.TP_ID);
            return View(cT_Thue_Phong);
        }

        // GET: CT_Thue_Phong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Thue_Phong cT_Thue_Phong = db.CT_Thue_Phongs.Find(id);
            if (cT_Thue_Phong == null)
            {
                return HttpNotFound();
            }
            return View(cT_Thue_Phong);
        }

        // POST: CT_Thue_Phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_Thue_Phong cT_Thue_Phong = db.CT_Thue_Phongs.Find(id);
            db.CT_Thue_Phongs.Remove(cT_Thue_Phong);
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
