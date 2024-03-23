using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            KHACH khach = (KHACH)Session["KHACH"];
            if (khach == null)
            {
                Session["Đơn Hàng"] = null;
            }
            else
            {
                var ttdonhang = PHIEUMUAHANG_DAO.GetDHById(khach.makhachhang);
                if (ttdonhang == null)
                {
                    Session["Đơn Hàng"] = null;
                }
                else
                {
                    Session["Đơn Hàng"] = ttdonhang;
                }
               
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(CUAHANGBANSACH.Models.THE model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}