using CUAHANGBANSACH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    
    public class NeoHomeController : Controller
    {
        // GET: NeoHome
        public ActionResult Index()
        {
            NHANVIEN nv = (NHANVIEN)Session["NhanVien"];
            if (nv == null ) { return RedirectToAction("Index", "STAFFLOGIN"); }
            return View();
        }
    }
}