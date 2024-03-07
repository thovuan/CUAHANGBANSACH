using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class STAFFLOGINController : Controller
    {
        // GET: STAFFLOGIN
        public ActionResult Index()
        {
            return View();
        }

        public RedirectResult Redirect(string tendangnhap, string matkhau)
        {
            if (NHANVIEN_DAO.GetByTDN(tendangnhap, matkhau)!=null) {
                return Redirect("~/NeoHome/Index");
            } 
            return Redirect("~/STAFFLOGIN/Index");   
        }
    }
}