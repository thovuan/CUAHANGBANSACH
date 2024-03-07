using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class GUESTLOGINController : Controller
    {
        // GET: GUESTLOGIN
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult Redirect(string tendangnhap, string matkhau)
        {
            /*
             if (tendangnhap == "guest" && matkhau == "Thovuan@1234")
            {
                return Redirect("~/Home/Index");
            }
            return Redirect("~/GUESTLOGIN/Index");
             */
            if (KHACH_DAO.GetByTDN(tendangnhap, matkhau)!= null)
            {
                return Redirect("~/Home/Index");
            } 
            return Redirect("~/GUESTLOGIN/Index");
        }
    }
}