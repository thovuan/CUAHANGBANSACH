using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class QLSACHController : Controller
    {
        DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities();
        // GET: QLSACH
        public ActionResult Index()
        {
            return View(SACH_DAO.All_List());
        }
        
        public ActionResult Edit(string Ma_Sach)
        {
            ViewData.Model = SACH_DAO.GetById(Ma_Sach);
            return View();
        }

        public ActionResult Delete() { 
            return View();
        }
    }
}