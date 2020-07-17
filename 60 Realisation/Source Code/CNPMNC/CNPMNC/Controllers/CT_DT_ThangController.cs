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
    public class CT_DT_ThangController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: CT_DT_Thang
        public ActionResult Index()
        {
            var cT_DT_Thangs = db.CT_DT_Thangs.Include(c => c.Doanh_Thu_Thang).Include(c => c.Phong);
            return View(cT_DT_Thangs.ToList());
        }

        // GET: CT_DT_Thang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DT_Thang cT_DT_Thang = db.CT_DT_Thangs.Find(id);
            if (cT_DT_Thang == null)
            {
                return HttpNotFound();
            }
            return View(cT_DT_Thang);
        }

        // GET: CT_DT_Thang/Create
        public ActionResult Create()
        {
            ViewBag.ThangID = new SelectList(db.Doanh_Thu_Thangs, "ThangID", "Thang");
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong");
            return View();
        }

        // POST: CT_DT_Thang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CT_DTT_ID,DoanhThu,TyLe,ThangID,PhongID")] CT_DT_Thang cT_DT_Thang)
        {
            if (ModelState.IsValid)
            {
                db.CT_DT_Thangs.Add(cT_DT_Thang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ThangID = new SelectList(db.Doanh_Thu_Thangs, "ThangID", "Thang", cT_DT_Thang.ThangID);
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong", cT_DT_Thang.PhongID);
            return View(cT_DT_Thang);
        }

        // GET: CT_DT_Thang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DT_Thang cT_DT_Thang = db.CT_DT_Thangs.Find(id);
            if (cT_DT_Thang == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThangID = new SelectList(db.Doanh_Thu_Thangs, "ThangID", "Thang", cT_DT_Thang.ThangID);
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong", cT_DT_Thang.PhongID);
            return View(cT_DT_Thang);
        }

        // POST: CT_DT_Thang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CT_DTT_ID,DoanhThu,TyLe,ThangID,PhongID")] CT_DT_Thang cT_DT_Thang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_DT_Thang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThangID = new SelectList(db.Doanh_Thu_Thangs, "ThangID", "Thang", cT_DT_Thang.ThangID);
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong", cT_DT_Thang.PhongID);
            return View(cT_DT_Thang);
        }

        // GET: CT_DT_Thang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DT_Thang cT_DT_Thang = db.CT_DT_Thangs.Find(id);
            if (cT_DT_Thang == null)
            {
                return HttpNotFound();
            }
            return View(cT_DT_Thang);
        }

        // POST: CT_DT_Thang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_DT_Thang cT_DT_Thang = db.CT_DT_Thangs.Find(id);
            db.CT_DT_Thangs.Remove(cT_DT_Thang);
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
