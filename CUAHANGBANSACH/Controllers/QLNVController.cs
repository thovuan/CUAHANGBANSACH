using CUAHANGBANSACH.Models;
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

        public ActionResult Details(string MaNV)
        {
            return View(NHANVIEN_DAO.GetById(MaNV));
        }

        public ActionResult Create ()
        {
            var laychucvu = CHUCVU_DAO.GetAllList();
            ViewBag.CHUCVU = new SelectList(laychucvu, "machucvu", "tenchucvu");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create  (NHANVIEN model)
        {
            var ttnv = NHANVIEN_DAO.GetById(model.manhanvien);
            
            return View(model);
        }
    }
}