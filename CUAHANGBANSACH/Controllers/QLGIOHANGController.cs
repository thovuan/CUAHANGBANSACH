using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class QLGIOHANGController : Controller
    {
        // GET: PMH
        public bool KiemTraPhanQuyen(string cv)
        {
            NHANVIEN nv = (NHANVIEN)Session["NhanVien"];
            var check = NHANVIEN_DAO.KiemTraPhanQuyen(nv.manhanvien, cv);
            if (check != null) return true;
            return false;
        }
        public ActionResult Index(string Find)
        {
            if (!KiemTraPhanQuyen("CV03")) return View("Bạn không có quyền");
            if (Find!= null) return View( PHIEUMUAHANG_DAO.GetById2(Find));
            return View(PHIEUMUAHANG_DAO.GetAll());
        }

        public ActionResult Details(string Ma_DH)
        {
            if (!KiemTraPhanQuyen("CV03")) return View("Bạn không có quyền");
            var ttdh = PHIEUMUAHANG_DAO.GetById(Ma_DH);
            if (ttdh!= null) { return View(ttdh); }
            return HttpNotFound();
            
        }

        
    }
}