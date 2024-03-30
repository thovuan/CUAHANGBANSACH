using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
                //var ttdonhang = PHIEUMUAHANG_DAO.GetDHById(model.tendangnhap);
            /*if (ttdonhang == null)
            {
                Session["Đơn Hàng"] = null;
            } else
            {
                if (ttdonhang.tinhtrang == "Chưa Xác Nhận") Session["Đơn Hàng"] = ttdonhang;
                else Session["Đơn Hàng"] = null;
            }*/
                //Session["Đơn Hàng"] = "DH20240323180959";
                return RedirectToAction("Index", "Home");
        }
            //else return View(model);
        
        public ActionResult Logout()
        {
            Session.Remove("KHACH");
            Session.Remove("Đơn Hàng");
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
                    KHACH_DAO.Update(Update);
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
        public ActionResult Create(KHACH model, HttpPostedFileBase image)
        {
            DateTime dt = new DateTime();
            var create = KHACH_DAO.GetById(model.makhachhang);
            string fileName = "";
            if (create == null)
            {
                dt = DateTime.Now;
                if (image != null && image.ContentLength > 0)
                {
                    var uploadPath = Server.MapPath("~/Content/GuestAvatar/");
                    if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

                    fileName = Path.GetFileName(image.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Content/GuestAvatar/"), fileName);
                    image.SaveAs(filePath);

                }

                KHACH khach = new KHACH()
                {
                    makhachhang = "KH" + dt.ToString("yyyyMMddHHmmss"),
                    tenkhachhang = model.tenkhachhang,
                    diachi = model.diachi,
                    sdt = model.sdt,
                    email = model.email,
                    avatar = "/Content/GuestAvatar/" + fileName,
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
                    ModelState.AddModelError("tenkhachhang", "Lỗi không tạo được");
                    return View(model);
                }

            }
            ModelState.AddModelError("makhachhang", "Tài khoản đã tồn tại!");
            return View(model);
        }

        public ActionResult TTKH()
        {
            /*KHACH khach = (KHACH)Session["KHACH"];
            var tttk = KHACH_DAO.GetById(khach.makhachhang);
            if ( tttk != null)
            {
                khach = tttk;
            }*/
            return View();
        }

        public ActionResult UpdateTT(String Ma_KH)
        {
            return View(KHACH_DAO.GetById(Ma_KH));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTT(KHACH model)
        {
            //KHACH khach = (KHACH)Session["KHACH"];
            var update = KHACH_DAO.GetById(model.makhachhang);
            if (update == null)
            {
                return HttpNotFound();
            }

            update.tenkhachhang = model.tenkhachhang;
            update.sdt = model.sdt;
            update.diachi = model.diachi;
            update.avatar = model.avatar;
            update.email = model.email;


            try
            {
                KHACH_DAO.Update(update);
                //khach = update;
                return RedirectToAction("TTKH");
            }
            catch (Exception ex)
            {
                return View("Có lỗi xảy ra", "Index");
            }

        }

        public ActionResult UploadImage(string Ma_KH)
        {
            return View(KHACH_DAO.GetById(Ma_KH));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadImage(KHACH model, HttpPostedFileBase image)
        {
            var idmakh = KHACH_DAO.GetById(model.makhachhang);
            if (idmakh == null) return View("Không tìm thấy");

            if (image != null && image.ContentLength > 0)
            {
                var uploadPath = Server.MapPath("~/Content/GuestAvatar/");
                if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

                string fileName = Path.GetFileName(image.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Content/GuestAvatar/"), fileName);
                image.SaveAs(filePath);
                idmakh.avatar = "/Content/GuestAvatar/" + fileName;
            }
            try
            {
                KHACH_DAO.Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("error", "Lỗi cập nhật thông tin");
                return View("Lỗi cập nhật thông tin");
            }
        }

        public ActionResult Delete(String Ma_KH) {
            return View(KHACH_DAO.GetById(Ma_KH));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(KHACH model) {
            return View();
        }
    }

}