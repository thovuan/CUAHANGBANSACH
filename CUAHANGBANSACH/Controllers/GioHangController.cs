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
            if (TempData["Result"] != null)
            {
                if (TempData["Result"].ToString().Contains("Successful")) ViewBag.Success = TempData["Result"];
                else ViewBag.Failure = TempData["Result"];
            }

            if (Session["KHACH"] == null) return View();
            KHACH khach = (KHACH)Session["KHACH"];
            return View(PHIEUMUAHANG_DAO.GetByGuestID(khach.makhachhang));
        }

        public ActionResult MyCart ()
        {
            KHACH khach = (KHACH)Session["KHACH"];
            PHIEUMUAHANG checkpmh = (PHIEUMUAHANG)Session["Đơn Hàng"];
            if (khach == null || checkpmh == null) return View();
            return View(PHIEUMUAHANG_DAO.GetDHByID(khach.makhachhang, checkpmh.maphieumuahang));
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

        public ActionResult EditSLSach (string Ma_Sach)
        {
            PHIEUMUAHANG pmh = (PHIEUMUAHANG)Session["Đơn Hàng"];
            return View(CHITIETDATHANG_DAO.GetBySACHID(Ma_Sach, pmh.maphieumuahang));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSLSach (CHITIETDATHANG model)
        {
            var ttsach = SACH_DAO.GetById(model.masach);
            PHIEUMUAHANG pmh = (PHIEUMUAHANG)Session["Đơn Hàng"];
            if (ttsach != null)
            {
                if (pmh != null)
                {
                    //tim kiem sach trong gio hang
                    var ttsachtronggiohang = CHITIETDATHANG_DAO.GetBySACHID(model.masach, pmh.maphieumuahang);
                    //neu tim thay thi xoa
                    
                    if (model.soluongmua > ttsach.soluonghienco) { ModelState.AddModelError("soluongmua", "Số lượng mua vượt quá số lượng hiện có"); return View(model); }
                    //tien thanh them san pham vao gio hang
                    ttsachtronggiohang.soluongmua = model.soluongmua;
                    try
                    {
                        CHITIETDATHANG_DAO.Update(ttsachtronggiohang);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        return View("Có lỗi xảy ra trong khi thực thi chương trình");
                    }

                }
                TempData["ThemDonHang"] = "Buy";
                return RedirectToAction("Create", "GioHang");
                //return View(model);
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
            
            string selectedTL = Request.Form["PTTT"];
            model.PHIEUMUAHANG.tinhtrangthanhtoan = selectedTL;

            ttkh.tenkhachhang = model.KHACH.tenkhachhang;
            ttkh.sdt = model.KHACH.sdt;
            ttkh.diachi = model.KHACH.diachi;
            ttkh.avatar = model.KHACH.avatar;
            ttkh.email = model.KHACH.email;
            ttdonhang.tinhtrang = "Xác Nhận";
            ttdonhang.tinhtrangthanhtoan = model.PHIEUMUAHANG.tinhtrangthanhtoan;

            var the = THE_DAO.GetByIDG(model.KHACH.makhachhang);
            if (the != null)
            {
                decimal temp = ttdonhang.DHTotal * (1m/100m);
                the.diemthe += Convert.ToInt32(temp);
            } 
                

            foreach (SACH sach in ttdonhang.dsSach)
            {
                if (sach == null) return View("Error");
                sach.soluonghienco = sach.soluonghienco - sach.soluongmua;
                try
                {
                    SACH_DAO.Update(sach);
                } catch
                {
                    return View("Có lỗi xảy ra", "Index");
                }
            }
            try
            {
                KHACH_DAO.Update(ttkh);
                //khach = update;
                PHIEUMUAHANG_DAO.Update(ttdonhang);
                THE_DAO.Update(the);
                Session.Remove("Đơn Hàng");
                TempData["Result"] = "Confirm Cart Successful";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                return View("Có lỗi xảy ra", "Index");
            }
        }

        public ActionResult Delete (string Ma_DH)
        {
            return View(PHIEUMUAHANG_DAO.GetById(Ma_DH));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (PHIEUMUAHANG model)
        {
            var ttdonhang = PHIEUMUAHANG_DAO.GetById(model.maphieumuahang);
            
            if (ttdonhang == null || ttdonhang.tinhtrang == "Xác Nhận") return View("Error");
            if (ttdonhang.dsSach.Count >= 0)
            {
                foreach (SACH hon in  ttdonhang.dsSach)
                {
                    var ttsach = CHITIETDATHANG_DAO.GetBySACHID(hon.masach, ttdonhang.maphieumuahang);

                    try
                    {
                        CHITIETDATHANG_DAO.Delete(ttsach);
                    } catch
                    {
                        return View("Lỗi");
                    }
                }
            }
            try
            {
                PHIEUMUAHANG_DAO.Delete(ttdonhang);
                return View("Index");

            } catch
            {
                return View("Lỗi");
            }
        }
    }
}