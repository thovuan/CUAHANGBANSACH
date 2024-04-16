using CUAHANGBANSACH.Models;
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
        public bool KiemTraPhanQuyen(string cv)
        {
            NHANVIEN nv = (NHANVIEN)Session["NhanVien"];
            var check = NHANVIEN_DAO.KiemTraPhanQuyen(nv.manhanvien, cv);
            if (check != null) return true;
            return false;
        }
        
        public ActionResult Index(string Find)
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            if (Find!=null) return View (KHACH_DAO.GetByName(Find));
            return View(KHACH_DAO.GetAllList());
        }

        public ActionResult Details(string Ma_KH) {

            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            return View(KHACH_DAO.GetById(Ma_KH));
        }
    }
}