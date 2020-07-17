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
    public class DM_PhongController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: DM_Phong
        public ActionResult Index()
        {
            return View(db.DM_Phongs.ToList());
        }

        // GET: DM_Phong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_Phong dM_Phong = db.DM_Phongs.Find(id);
            if (dM_Phong == null)
            {
                return HttpNotFound();
            }
            return View(dM_Phong);
        }

        // GET: DM_Phong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DM_Phong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoaiPhongID,TenLoaiPhong,DonGia")] DM_Phong dM_Phong)
        {
            if (ModelState.IsValid)
            {
                db.DM_Phongs.Add(dM_Phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dM_Phong);
        }

        // GET: DM_Phong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_Phong dM_Phong = db.DM_Phongs.Find(id);
            if (dM_Phong == null)
            {
                return HttpNotFound();
            }
            return View(dM_Phong);
        }

        // POST: DM_Phong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoaiPhongID,TenLoaiPhong,DonGia")] DM_Phong dM_Phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dM_Phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dM_Phong);
        }

        // GET: DM_Phong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DM_Phong dM_Phong = db.DM_Phongs.Find(id);
            if (dM_Phong == null)
            {
                return HttpNotFound();
            }
            return View(dM_Phong);
        }

        // POST: DM_Phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DM_Phong dM_Phong = db.DM_Phongs.Find(id);
            db.DM_Phongs.Remove(dM_Phong);
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
