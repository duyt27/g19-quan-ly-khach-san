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
    public class Doanh_Thu_ThangController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: Doanh_Thu_Thang
        public ActionResult Index()
        {
            return View(db.Doanh_Thu_Thangs.ToList());
        }

        // GET: Doanh_Thu_Thang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doanh_Thu_Thang doanh_Thu_Thang = db.Doanh_Thu_Thangs.Find(id);
            if (doanh_Thu_Thang == null)
            {
                return HttpNotFound();
            }
            return View(doanh_Thu_Thang);
        }

        // GET: Doanh_Thu_Thang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doanh_Thu_Thang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ThangID,Thang")] Doanh_Thu_Thang doanh_Thu_Thang)
        {
            if (ModelState.IsValid)
            {
                db.Doanh_Thu_Thangs.Add(doanh_Thu_Thang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doanh_Thu_Thang);
        }

        // GET: Doanh_Thu_Thang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doanh_Thu_Thang doanh_Thu_Thang = db.Doanh_Thu_Thangs.Find(id);
            if (doanh_Thu_Thang == null)
            {
                return HttpNotFound();
            }
            return View(doanh_Thu_Thang);
        }

        // POST: Doanh_Thu_Thang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThangID,Thang")] Doanh_Thu_Thang doanh_Thu_Thang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doanh_Thu_Thang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doanh_Thu_Thang);
        }

        // GET: Doanh_Thu_Thang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doanh_Thu_Thang doanh_Thu_Thang = db.Doanh_Thu_Thangs.Find(id);
            if (doanh_Thu_Thang == null)
            {
                return HttpNotFound();
            }
            return View(doanh_Thu_Thang);
        }

        // POST: Doanh_Thu_Thang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doanh_Thu_Thang doanh_Thu_Thang = db.Doanh_Thu_Thangs.Find(id);
            db.Doanh_Thu_Thangs.Remove(doanh_Thu_Thang);
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
