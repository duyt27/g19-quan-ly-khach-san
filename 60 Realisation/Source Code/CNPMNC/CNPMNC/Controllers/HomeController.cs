using CNPMNC.Areas.Admin.Controllers;
using CNPMNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPMNC.Controllers
{
    public class HomeController : Controller
    {
        CSDLContext db = new CSDLContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rules()
        {
            return View();
        }


        
    }
}