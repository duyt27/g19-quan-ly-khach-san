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
    public class Khach_hangController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: Khach_hang
        public ActionResult Index()
        {
            return View(db.Khach_Hangs.ToList());
        }

        // GET: Khach_hang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khach_hang khach_hang = db.Khach_Hangs.Find(id);
            if (khach_hang == null)
            {
                return HttpNotFound();
            }
            return View(khach_hang);
        }

        // GET: Khach_hang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Khach_hang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoaiKhachID,LoaiKhach")] Khach_hang khach_hang)
        {
            if (ModelState.IsValid)
            {
                db.Khach_Hangs.Add(khach_hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khach_hang);
        }

        // GET: Khach_hang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khach_hang khach_hang = db.Khach_Hangs.Find(id);
            if (khach_hang == null)
            {
                return HttpNotFound();
            }
            return View(khach_hang);
        }

        // POST: Khach_hang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoaiKhachID,LoaiKhach")] Khach_hang khach_hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khach_hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khach_hang);
        }

        // GET: Khach_hang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khach_hang khach_hang = db.Khach_Hangs.Find(id);
            if (khach_hang == null)
            {
                return HttpNotFound();
            }
            return View(khach_hang);
        }

        // POST: Khach_hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Khach_hang khach_hang = db.Khach_Hangs.Find(id);
            db.Khach_Hangs.Remove(khach_hang);
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
