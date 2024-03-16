using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class QLCHUCVUController : Controller
    {
        // GET: QLCHUCVU
        public ActionResult Index()
        {
            return View(CHUCVU_DAO.GetAllList());
        }
    }
}