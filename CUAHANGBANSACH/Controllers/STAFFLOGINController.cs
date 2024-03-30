using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using Microsoft.Ajax.Utilities;
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
            //if (Session["NhanVien"]==null) return RedirectToAction("Index");
            Session["KHACH"] = null;
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(NHANVIEN model)
        {
            var tttk = NHANVIEN_DAO.GetByTDN(model.tendangnhap);
            
                if (tttk != null)
                {
                    if (tttk.matkhau != model.matkhau)
                    {
                        ModelState.AddModelError("matkhau", "Mật khẩu không đúng");
                        return View(model);
                    } else
                    {
                        Session["NhanVien"] = tttk;
                        
                        return RedirectToAction("Index", "NeoHome");
                    }
                    
                } else { ModelState.AddModelError("tendangnhap", "Tên đăng nhập không tìm thấy"); return View(model); }
            
            
            //return View(model);
            
             
        }

        public ActionResult Logout (){
            Session.Remove("NhanVien");
            return RedirectToAction("Index");
        }

        public ActionResult TTNV()
        {
            return View();
        }
    }
}