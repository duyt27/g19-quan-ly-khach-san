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
    public class Hoa_DonController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: Hoa_Don
        public ActionResult Index()
        {
            var hoa_Dons = db.Hoa_Dons.Include(h => h.CT_Khach_Hang);
            return View(hoa_Dons.ToList());
        }

        // GET: Hoa_Don/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa_Don hoa_Don = db.Hoa_Dons.Find(id);
            if (hoa_Don == null)
            {
                return HttpNotFound();
            }
            return View(hoa_Don);
        }

        // GET: Hoa_Don/Create
        public ActionResult Create()
        {
            ViewBag.KhachID = new SelectList(db.CT_Khach_Hangs, "KhachID", "TenKhach");
            return View();
        }

        // POST: Hoa_Don/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoaDonID,TriGia,KhachID")] Hoa_Don hoa_Don)
        {
            if (ModelState.IsValid)
            {
                db.Hoa_Dons.Add(hoa_Don);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhachID = new SelectList(db.CT_Khach_Hangs, "KhachID", "TenKhach", hoa_Don.KhachID);
            return View(hoa_Don);
        }

        // GET: Hoa_Don/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa_Don hoa_Don = db.Hoa_Dons.Find(id);
            if (hoa_Don == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhachID = new SelectList(db.CT_Khach_Hangs, "KhachID", "TenKhach", hoa_Don.KhachID);
            return View(hoa_Don);
        }

        // POST: Hoa_Don/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HoaDonID,TriGia,KhachID")] Hoa_Don hoa_Don)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoa_Don).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhachID = new SelectList(db.CT_Khach_Hangs, "KhachID", "TenKhach", hoa_Don.KhachID);
            return View(hoa_Don);
        }

        // GET: Hoa_Don/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa_Don hoa_Don = db.Hoa_Dons.Find(id);
            if (hoa_Don == null)
            {
                return HttpNotFound();
            }
            return View(hoa_Don);
        }

        // POST: Hoa_Don/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoa_Don hoa_Don = db.Hoa_Dons.Find(id);
            db.Hoa_Dons.Remove(hoa_Don);
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
