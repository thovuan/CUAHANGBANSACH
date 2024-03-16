using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class QLNVController : Controller
    {
        // GET: QLNV
        public ActionResult Index()
        {
            ViewData.Model = NHANVIEN_DAO.GetAllList();
            return View();
        }
    }
}