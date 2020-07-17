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
    public class CT_Hoa_DonController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: CT_Hoa_Don
        public ActionResult Index()
        {
            var cT_Hoa_Dons = db.CT_Hoa_Dons.Include(c => c.Hoa_Don).Include(c => c.Phong);
            return View(cT_Hoa_Dons.ToList());
        }

        // GET: CT_Hoa_Don/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Hoa_Don cT_Hoa_Don = db.CT_Hoa_Dons.Find(id);
            if (cT_Hoa_Don == null)
            {
                return HttpNotFound();
            }
            return View(cT_Hoa_Don);
        }

        // GET: CT_Hoa_Don/Create
        public ActionResult Create()
        {
            ViewBag.HoaDonID = new SelectList(db.Hoa_Dons, "HoaDonID", "HoaDonID");
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong");
            return View();
        }

        // POST: CT_Hoa_Don/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CTHD_ID,SoNgayThue,ThanhTien,HoaDonID,PhongID")] CT_Hoa_Don cT_Hoa_Don)
        {
            if (ModelState.IsValid)
            {
                db.CT_Hoa_Dons.Add(cT_Hoa_Don);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HoaDonID = new SelectList(db.Hoa_Dons, "HoaDonID", "HoaDonID", cT_Hoa_Don.HoaDonID);
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong", cT_Hoa_Don.PhongID);
            return View(cT_Hoa_Don);
        }

        // GET: CT_Hoa_Don/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Hoa_Don cT_Hoa_Don = db.CT_Hoa_Dons.Find(id);
            if (cT_Hoa_Don == null)
            {
                return HttpNotFound();
            }
            ViewBag.HoaDonID = new SelectList(db.Hoa_Dons, "HoaDonID", "HoaDonID", cT_Hoa_Don.HoaDonID);
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong", cT_Hoa_Don.PhongID);
            return View(cT_Hoa_Don);
        }

        // POST: CT_Hoa_Don/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CTHD_ID,SoNgayThue,ThanhTien,HoaDonID,PhongID")] CT_Hoa_Don cT_Hoa_Don)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_Hoa_Don).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HoaDonID = new SelectList(db.Hoa_Dons, "HoaDonID", "HoaDonID", cT_Hoa_Don.HoaDonID);
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong", cT_Hoa_Don.PhongID);
            return View(cT_Hoa_Don);
        }

        // GET: CT_Hoa_Don/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Hoa_Don cT_Hoa_Don = db.CT_Hoa_Dons.Find(id);
            if (cT_Hoa_Don == null)
            {
                return HttpNotFound();
            }
            return View(cT_Hoa_Don);
        }

        // POST: CT_Hoa_Don/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_Hoa_Don cT_Hoa_Don = db.CT_Hoa_Dons.Find(id);
            db.CT_Hoa_Dons.Remove(cT_Hoa_Don);
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
