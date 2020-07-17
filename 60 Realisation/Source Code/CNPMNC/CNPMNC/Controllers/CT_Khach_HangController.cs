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
    public class CT_Khach_HangController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: CT_Khach_Hang
        public ActionResult Index()
        {
            var cT_Khach_Hangs = db.CT_Khach_Hangs.Include(c => c.Khach_Hang);
            return View(cT_Khach_Hangs.ToList());
        }

        // GET: CT_Khach_Hang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Khach_Hang cT_Khach_Hang = db.CT_Khach_Hangs.Find(id);
            if (cT_Khach_Hang == null)
            {
                return HttpNotFound();
            }
            return View(cT_Khach_Hang);
        }

        // GET: CT_Khach_Hang/Create
        public ActionResult Create()
        {
            ViewBag.LoaiKhachID = new SelectList(db.Khach_Hangs, "LoaiKhachID", "LoaiKhach");
            return View();
        }

        // POST: CT_Khach_Hang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KhachID,TenKhach,CMND,DiaChi,LoaiKhachID")] CT_Khach_Hang cT_Khach_Hang)
        {
            if (ModelState.IsValid)
            {
                db.CT_Khach_Hangs.Add(cT_Khach_Hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiKhachID = new SelectList(db.Khach_Hangs, "LoaiKhachID", "LoaiKhach", cT_Khach_Hang.LoaiKhachID);
            return View(cT_Khach_Hang);
        }

        // GET: CT_Khach_Hang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Khach_Hang cT_Khach_Hang = db.CT_Khach_Hangs.Find(id);
            if (cT_Khach_Hang == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiKhachID = new SelectList(db.Khach_Hangs, "LoaiKhachID", "LoaiKhach", cT_Khach_Hang.LoaiKhachID);
            return View(cT_Khach_Hang);
        }

        // POST: CT_Khach_Hang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KhachID,TenKhach,CMND,DiaChi,LoaiKhachID")] CT_Khach_Hang cT_Khach_Hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_Khach_Hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiKhachID = new SelectList(db.Khach_Hangs, "LoaiKhachID", "LoaiKhach", cT_Khach_Hang.LoaiKhachID);
            return View(cT_Khach_Hang);
        }

        // GET: CT_Khach_Hang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_Khach_Hang cT_Khach_Hang = db.CT_Khach_Hangs.Find(id);
            if (cT_Khach_Hang == null)
            {
                return HttpNotFound();
            }
            return View(cT_Khach_Hang);
        }

        // POST: CT_Khach_Hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_Khach_Hang cT_Khach_Hang = db.CT_Khach_Hangs.Find(id);
            db.CT_Khach_Hangs.Remove(cT_Khach_Hang);
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
