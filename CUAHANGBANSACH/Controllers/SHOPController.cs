using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.Combined_Model;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class SHOPController : Controller
    {
        // GET: SHOP
        public ActionResult Index(string Ma_TheLoai, string Ma_NXB)
        {

            if (Ma_TheLoai != null && Ma_NXB == null) ViewData.Model = SACH_DAO.ChuDe_List(Ma_TheLoai);
            else if (Ma_TheLoai == null && Ma_NXB != null) ViewData.Model = SACH_DAO.NXB_List(Ma_NXB);
            else ViewData.Model = SACH_DAO.All_List();
            return View();
        }
        
        public ActionResult Index02(string Ma_TheLoai) {

            /*DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities();
            List<SACH> list = SACH_DAO.ChuDe_List(chude);
            return View(list);*/

            ViewData.Model = SACH_DAO.ChuDe_List(Ma_TheLoai);
            //ViewBag.Ma_TheLoai = chude;
            return View();
        }

        public ActionResult Index03(string Ma_NXB) {
            ViewData.Model = SACH_DAO.NXB_List(Ma_NXB);
            return View();
        }

        

        //[HttpPost]
        public ActionResult Detail(string MaSach) {
            ViewData.Model = SACH_DAO.GetById(MaSach);
            return View();
        }

        public ActionResult Buy (string MaSach)
        {
            return View(SACH_DAO.GetById(MaSach));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy (SACH model)
        {
            var ttsach = SACH_DAO.GetById(model.masach);
            PHIEUMUAHANG pmh = (PHIEUMUAHANG)Session["Đơn Hàng"];
            if (ttsach != null)
            {
                //kiem tra don hang hien tai
                //neu chua co don hang ma chua xac nhan mua thi them vao do
                //chú ý, kiểm tra xem trong giỏ hàng da co san pham tuong tu chua
                //neu có, thì cộng dồn (hoặc xóa sản phẩm hiện co trong gio hang va thay doi)
                //neu khong thi them vao (chu y so luong mua phai be hon hoac bang so luong hien co)
                if (pmh != null)
                {
                    //tim kiem sach trong gio hang
                    var ttsachtronggiohang = CHITIETDATHANG_DAO.GetBySACHID(model.masach, pmh.maphieumuahang);
                    //neu tim thay thi xoa
                    if (ttsachtronggiohang != null)
                    {
                        
                        try
                        {
                            CHITIETDATHANG_DAO.Delete(ttsachtronggiohang);

                        } catch (Exception ex)
                        {
                            ViewBag.Error = "Có lỗi xảy ra khi xóa";
                            return View("Có lỗi xảy ra trong khi thực thi");
                        }
                    }
                    if (model.soluongmua > ttsach.soluonghienco) { ModelState.AddModelError("soluongmua", "Số lượng mua vượt quá số lượng hiện có"); return View(model); }
                    //tien thanh them san pham vao gio hang
                    CHITIETDATHANG ctdh = new CHITIETDATHANG()
                    {
                        maphieumuahang = pmh.maphieumuahang,
                        masach = model.masach,
                        soluongmua = model.soluongmua,
                        tinhtranggiao = "Chưa giao"
                    };

                    try
                    {
                        CHITIETDATHANG_DAO.Add(ctdh);
                        return RedirectToAction("Index");
                    } catch (Exception ex)
                    {
                        return View("Có lỗi xảy ra trong khi thực thi chương trình");
                    }

                }
                TempData["ThemDonHang"] = "Buy";
                return RedirectToAction("Create", "GioHang");
                //return View(model);
            } return View(model);
        }

        
    }
}