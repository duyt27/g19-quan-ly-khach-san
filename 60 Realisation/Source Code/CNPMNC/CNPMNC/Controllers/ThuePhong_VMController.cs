using CNPMNC.Areas.Admin.Controllers;
using CNPMNC.Models;
using CNPMNC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CNPMNC.Controllers
{
    public class ThuePhong_VMController : BaseController
    {
        CSDLContext db = new CSDLContext();
        // GET: ThuePhong_VM
        public ActionResult Index()
        {
            List<Phong> phong = db.Phongs.ToList();
            List<Thue_Phong> thuephong = db.Thue_Phongs.ToList();
            List<CT_Thue_Phong> ctThuephong = db.CT_Thue_Phongs.ToList();
            List<Khach_hang> khach = db.Khach_Hangs.ToList();
            List<CT_Khach_Hang> ctKhach = db.CT_Khach_Hangs.ToList();

            var dsThue = from p in phong
                         join t in thuephong on p.PhongID equals t.PhongID into table1
                         from t in table1.DefaultIfEmpty()
                         join ct in ctThuephong on t.TP_ID equals ct.TP_ID into table2
                         from ct in table2.DefaultIfEmpty()
                         join ck in ctKhach on ct.KhachID equals ck.KhachID into table3
                         from ck in table3.DefaultIfEmpty()
                         join k in khach on ck.LoaiKhachID equals k.LoaiKhachID into table4
                         from k in table4.DefaultIfEmpty()
                         select new ThuePhongList
                         {
                             phongdetails = p,
                             thuePhongdetails = t,
                             ctThuephongdetails = ct,
                             khachhangdetails = k,
                             ctKhachhangdetails = ck
                         };

            return View(dsThue);
        }
        //[HttpGet]
        public ActionResult Create()
        {
            ViewBag.LoaiKhachID = new SelectList(db.Khach_Hangs, "LoaiKhachID", "LoaiKhach");
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong");

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "PhongID,NgayThue,TenKhach,LoaiKhachID,CMND,DiaChi")] ThuePhongVM vm)
        {
            ViewBag.LoaiKhachID = new SelectList(db.Khach_Hangs, "LoaiKhachID", "LoaiKhach", vm.LoaiKhachID);
            ViewBag.PhongID = new SelectList(db.Phongs, "PhongID", "TenPhong", vm.PhongID);

            Phong phong = new Phong();
            Khach_hang khach = new Khach_hang();
            khach.LoaiKhach = khach.LoaiKhach;
            //phong.TenPhong = vm.TenPhong;

            //db.Phongs.Add(phong);
            //db.SaveChanges();

            Thue_Phong thue = new Thue_Phong();
            thue.NgayThue = vm.NgayThue;
            //thue.PhongID = phong.PhongID;
            db.Thue_Phongs.Add(thue);
            db.SaveChanges();

            CT_Khach_Hang kh = new CT_Khach_Hang();
            kh.TenKhach = vm.TenKhach;
            kh.CMND = vm.CMND;
            kh.DiaChi = vm.DiaChi;
            //kh.LoaiKhachID = khach.LoaiKhachID;
            db.CT_Khach_Hangs.Add(kh);
            db.SaveChanges();

            CT_Thue_Phong cttp = new CT_Thue_Phong();
            cttp.TP_ID = thue.TP_ID;
            cttp.KhachID = kh.KhachID;
            //cttp.Khach_Hang.LoaiKhachID = khach.LoaiKhachID;
            db.CT_Thue_Phongs.Add(cttp);
            db.SaveChanges();

            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        Phong phong = new Phong();
            //        Thue_Phong thue = new Thue_Phong();
            //        CT_Khach_Hang kh = new CT_Khach_Hang();
            //        CT_Thue_Phong cttp = new CT_Thue_Phong();
            //        db.Phongs.Add(phong);
            //        db.Thue_Phongs.Add(thue);
            //        db.CT_Khach_Hangs.Add(kh);
            //        db.CT_Thue_Phongs.Add(cttp);
            //        db.SaveChanges();
            //        return RedirectToAction("ListPhong", "ThuePhong_VM");

            //    }

            //}
            //catch (DbEntityValidationException eve)
            //{
            //    foreach (var ve in eve.EntityValidationErrors)
            //    {
            //        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
            //    ve.PropertyName,
            //    eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
            //    ve.ErrorMessage);
            //    }
            //    throw;
            //}



            SetAlert("Thêm phiếu thành công", "success");
            return RedirectToAction("ListPhong", "ThuePhong_VM");
        }

        public ActionResult ListPhong()
        {
            var listp = from a in db.DM_Phongs
                        join p in db.Phongs on a.LoaiPhongID equals p.LoaiPhongID
                        select new ListPhongVM()
                        {
                            TenPhong = p.TenPhong,
                            TenLoaiPhong = p.DM_Phong.TenLoaiPhong,
                            DonGia = p.DM_Phong.DonGia,
                            TinhTrang = p.TinhTrang,
                            GhiChu = p.GhiChu
                        };

            ViewData["listp"] = listp;
            //ViewBag.ds = listp;
            
            return View();
        }

        public ActionResult TimPhong(string tenphong)
        {
            var tenp = db.Phongs.Where(s => s.TenPhong.Contains(tenphong)).ToList();
            ViewData["tenp"] = tenp;
            return View();
        }
    }
}