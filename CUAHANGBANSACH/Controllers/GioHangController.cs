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
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            if (Session["KHACH"] == null) return View();
            KHACH khach = (KHACH)Session["KHACH"];
            return View(PHIEUMUAHANG_DAO.GetByGuestID(khach.makhachhang));
        }

        public ActionResult Details(string Ma_DH) { 
            var ttdh = PHIEUMUAHANG_DAO.GetById(Ma_DH);
            if (ttdh == null) return HttpNotFound();
            return View(ttdh);
        }



        public ActionResult Create()
        {
            DateTime dt = new DateTime();
            KHACH khach = (KHACH)Session["KHACH"];
            
            PHIEUMUAHANG checkpmh = (PHIEUMUAHANG)Session["Đơn Hàng"];
            if (checkpmh != null) return View("Không thể tạo được đơn hàng");
            try
            {
                dt = DateTime.Now;
                if (khach == null)
                {
                    KHACH guest = new KHACH()
                    {
                        makhachhang = "KH" + dt.ToString("yyyyMMddHHmmss"),
                        tenkhachhang = "Guest" + dt.ToString("yyyyMMddHHmmss"),
                        diachi = "Unk",
                        sdt = "0123456789"
                    };

                    try
                    {
                        KHACH_DAO.Create(guest);
                        Session["KHACH"] = guest;
                        khach = guest;
                    } catch
                    {
                        return View("Có lỗi xảy ra");
                    }
                }
                PHIEUMUAHANG pmh = new PHIEUMUAHANG()
                {
                    maphieumuahang = "DH" + dt.ToString("yyyyMMddHHmmss"),
                    ngaylap = dt,
                    tinhtrangthanhtoan = "Chưa thanh toán",
                    tinhtrang = "Chưa Xác Nhận",
                    makhachhang = khach.makhachhang,
                };
                PHIEUMUAHANG_DAO.Create(pmh);
                Session["Đơn Hàng"] = pmh;

                if (TempData.ContainsKey("ThemDonHang"))
                {
                    // Lấy tên của hành động trước đó từ TempData
                    string previousAction = TempData["ThemDonHang"].ToString();

                    // Xóa thông tin về hành động trước đó từ TempData
                    TempData.Remove("ThemDonHang");

                    // Kiểm tra xem hành động trước đó có tồn tại không
                    if (!string.IsNullOrEmpty(previousAction))
                    {
                        // Chuyển hướng trở lại hành động trước đó
                        return RedirectToAction(previousAction);
                    }
                }
                return RedirectToAction("Index");

            }
            catch
            {

                return View("Có lỗi xảy ra");
            }
        }

        public ActionResult Edit(string Ma_DH)
        {
            return View(PHIEUMUAHANG_DAO.GetById(Ma_DH));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PHIEUMUAHANG model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            } 
            return View(model);
        }

        public ActionResult DeleteSACH(string Ma_Sach) {
            PHIEUMUAHANG pmh = (PHIEUMUAHANG)Session["Đơn Hàng"];
            var ttsachtronggiohang = CHITIETDATHANG_DAO.GetBySACHID(Ma_Sach, pmh.maphieumuahang);
            if (ttsachtronggiohang == null)
            {
                return View("Can't find the book to delete");
            } else
            {
                try
                {
                    CHITIETDATHANG_DAO.Delete(ttsachtronggiohang);
                    /*if (TempData.ContainsKey("XKGH"))
                    {
                        // Lấy tên của hành động trước đó từ TempData
                        string previousAction = TempData["XKGH"].ToString();

                        // Xóa thông tin về hành động trước đó từ TempData
                        TempData.Remove("XKGH");

                        // Kiểm tra xem hành động trước đó có tồn tại không
                        if (!string.IsNullOrEmpty(previousAction))
                        {
                            // Chuyển hướng trở lại hành động trước đó
                            return RedirectToAction(previousAction);
                        }
                    }*/
                    return View("Index");
                } catch
                {
                    return View("Error");
                }
            }
        }

        public ActionResult Confirm (string Ma_DH)
        {
            KHACH khach = (KHACH)Session["KHACH"];
            var donhang = PHIEUMUAHANG_DAO.GetById(Ma_DH);
            var khachhang = KHACH_DAO.GetById(khach.makhachhang);
            if (donhang == null || khachhang == null) { return HttpNotFound(); }
            if (donhang.tinhtrang == "Xác Nhận") return View("Không thể xác nhận mua");

            PHIEUMUAHANG_KHACH_MODEL model = new PHIEUMUAHANG_KHACH_MODEL()
            {
                PHIEUMUAHANG = donhang,
                KHACH = khachhang
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm (PHIEUMUAHANG_KHACH_MODEL model)
        {
            var ttkh = KHACH_DAO.GetById(model.KHACH.makhachhang);
            var ttdonhang = PHIEUMUAHANG_DAO.GetById(model.PHIEUMUAHANG.maphieumuahang);
            if (ttkh == null || ttdonhang == null)
            {
                return HttpNotFound();
            }
            

            ttkh.tenkhachhang = model.KHACH.tenkhachhang;
            ttkh.sdt = model.KHACH.sdt;
            ttkh.diachi = model.KHACH.diachi;
            ttkh.avatar = model.KHACH.avatar;
            ttkh.email = model.KHACH.email;
            ttdonhang.tinhtrang = "Xác Nhận";
            ttdonhang.tinhtrangthanhtoan = "Thanh toán bằng tiền mặt";

            try
            {
                KHACH_DAO.Update(ttkh);
                //khach = update;
                PHIEUMUAHANG_DAO.Update(ttdonhang);
                Session.Remove("Đơn Hàng");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Có lỗi xảy ra", "Index");
            }
        }
        
    }
}