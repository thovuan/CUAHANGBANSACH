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

        public ActionResult UpdateMK()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMK(KHACH model, string confirmPassword)
        {
            var Update = KHACH_DAO.GetByTDN(model.tendangnhap);
            if (Update != null)
            {
                if (model.matkhau != confirmPassword)
                {
                    ModelState.AddModelError("confirmPassword", "Mật khẩu nhập lại không trùng khớp");
                    return View(model);
                }
                Update.matkhau = model.matkhau;
                try
                {
                    KHACH_DAO.UpdateMK(Update);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("tendangnhap", ex.Message);
                    return View(model);
                }
            }
            else if (model.matkhau == null || confirmPassword == null)
            {
                ModelState.AddModelError("matkhau", "Mật khẩu không được trống");
                return View(model);
            }
            ModelState.AddModelError("tendangnhap", "Lỗi không tìm thấy");
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KHACH model)
        {
            var create = KHACH_DAO.GetById(model.makhachhang);
            if (create == null)
            {
                KHACH khach = new KHACH()
                {
                    makhachhang = model.makhachhang,
                    tenkhachhang = model.tenkhachhang,
                    diachi = model.diachi,
                    sdt = model.sdt,
                    avatar = model.avatar,
                    tendangnhap = model.tendangnhap,
                    matkhau = model.matkhau,
                };
                try
                {
                    KHACH_DAO.Create(khach);
                    return RedirectToAction("Index", "Home");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("makhachhang", "Lỗi không tạo được");
                    return View(model);
                }

            }
            ModelState.AddModelError("makhachhang", "Tài khoản đã tồn tại!");
            return View(model);
        }

        public ActionResult TTKH()
        {
            return View();
        }

        
    }

}