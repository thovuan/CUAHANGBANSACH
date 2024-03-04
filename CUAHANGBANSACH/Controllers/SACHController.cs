using CUAHANGBANSACH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class SACHController : Controller
    {
        // GET: SACH
        public ActionResult Index()
        {
            DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities();
            List<SACH> sach = db.SACHes.ToList();
            
            return View(sach);
        }
    }
}