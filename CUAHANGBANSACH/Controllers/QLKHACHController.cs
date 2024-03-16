using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class QLKHACHController : Controller
    {
        // GET: QLKHACH
        public ActionResult Index()
        {
            return View(KHACH_DAO.GetAllList());
        }

        public ActionResult Details(string Ma_KH) { 
            return View(KHACH_DAO.GetById(Ma_KH));
        }
    }
}