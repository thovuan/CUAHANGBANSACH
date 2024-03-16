using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Text;

namespace CUAHANGBANSACH.Controllers
{
    public class GUESTLOGINController : Controller
    {
        // GET: GUESTLOGIN
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(KHACH model)
        {
            
                KHACH kHACH = KHACH_DAO.GetByTDN(model.tendangnhap);
                if (kHACH == null)
                {
                    ModelState.AddModelError("tendangnhap", "Tên đăng nhập không tìm thấy");
                    return View(model);
                }
                if (kHACH.matkhau != model.matkhau)
                {
                    ModelState.AddModelError("matkhau", "Mật Khẩu không đúng");
                    return View(model);
                }
                Session["KHACH"] = kHACH;
                Session.Timeout = 240;
                return RedirectToAction("Index", "Home");
        }
            //else return View(model);
        
        public ActionResult Logout()
        {
            Session.Remove("KHACH");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult TTKH()
        {
            return View();
        }

    }

}