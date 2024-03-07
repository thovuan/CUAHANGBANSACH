using CUAHANGBANSACH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class PMHController : Controller
    {
        // GET: PMH
        public ActionResult Index()
        {
            DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities();
            List<PHIEUMUAHANG> pmh = db.PHIEUMUAHANGs.ToList();
            return View(pmh);
        }
    }
}