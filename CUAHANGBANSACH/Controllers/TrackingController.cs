using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using CUAHANGBANSACH.Models.PHIEUMUAHANG_KHACH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class TrackingController : Controller
    {
        // GET: Tracking
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index (PHIEUMUAHANG_KHACH_MODEL model)
        {
            var trackingDH = PHIEUMUAHANG_DAO.GetById2(model.PHIEUMUAHANG.maphieumuahang);
            var checkemail = KHACH_DAO.GetByEmail(model.KHACH.email);
            if (trackingDH != null) { 
                if (checkemail != null)
                {
                    return RedirectToAction("KQTC", routeValues: new {@Ma_DH = trackingDH.maphieumuahang});
                }
                ModelState.AddModelError("KHACH.email", "Không tìm thấy Email");
                return View(model);
            }
            ModelState.AddModelError("PHIEUMUAHANG.maphieumuahang", "Không tìm thấy đơn hàng");
            return View(model);
        }

        public ActionResult KQTC (string Ma_DH)
        {
            var trackingDH = PHIEUMUAHANG_DAO.GetById(Ma_DH);
            if (trackingDH != null) return View(trackingDH);
            return View("Lỗi");
        }
        
    }
}