using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
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

                PHIEUMUAHANG pmh = new PHIEUMUAHANG()
                {
                    maphieumuahang = "DH" + dt.ToString("yyyyMMddHHmmss"),
                    ngaylap = dt,
                    tinhtrangthanhtoan = "Chưa thanh toán",
                    tinhtrang = "Chưa Xác Nhận",
                    makhachhang = khach != null ? khach.makhachhang : "KH" + dt.ToString("yyyyMMddHHmmss"),
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
               
                return RedirectToAction("Index");
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

    }
}