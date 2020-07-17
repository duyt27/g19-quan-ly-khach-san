using CNPMNC.Common;
using CNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CNPMNC.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new Users();

            var model = dao.ListAllPagin(page, pageSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new Users();

                var encryptedMD5Pass = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMD5Pass;
                int id = dao.Insert(user);
                if (id > 0)
                {
                    //SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var user = new Users().ViewDetails(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new Users();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMD5Pass = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMD5Pass;
                }

                
                var result = dao.Update(user);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Update user thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            new Users().Delete(id);

            return RedirectToAction("Index");
        }
    }
}