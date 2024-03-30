using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.Combined_Model;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class QLNVController : Controller
    {
        // GET: QLNV
        public bool KiemTraPhanQuyen(string cv)
        {
            NHANVIEN nv = (NHANVIEN)Session["NhanVien"];
            var check = NHANVIEN_DAO.KiemTraPhanQuyen(nv.manhanvien, cv);
            if (check != null) return true;
            return false;
        }
        public ActionResult Index()
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            ViewData.Model = NHANVIEN_DAO.GetAllList();
            return View();
        }

        public ActionResult Details(string MaNV)
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            return View(NHANVIEN_DAO.GetById(MaNV));
        }

        public ActionResult Create (NHANVIEN_DANHSACHCHUCVU_MODEL model)
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            var laychucvu = CHUCVU_DAO.GetAllList();
            model.CHUCVU = laychucvu;
            return View(model);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNV  (NHANVIEN_DANHSACHCHUCVU_MODEL model)
        {
            var ttnv = NHANVIEN_DAO.GetByTen(model.NHANVIEN.tennhanvien);
            DateTime dt = new DateTime();
            if (ttnv == null)
            {
                dt = DateTime.Now;
                NHANVIEN nv = new NHANVIEN()
                {
                    manhanvien = "NV" + dt.ToString("yyyyMMddHHmmss"),
                    tennhanvien = model.NHANVIEN.tennhanvien,
                    tendangnhap = model.NHANVIEN.tendangnhap,
                    matkhau = model.NHANVIEN.matkhau
                };
                try
                {
                    NHANVIEN_DAO.Create(nv);
                    return RedirectToAction("Index");

                } catch
                {
                    return View("Lỗi thêm nhân viên");
                }
            }
            ModelState.AddModelError("tennhanvien", "Tên nhân viên đã tồn tại trong CSDL");
            return View(model);
        }
        public ActionResult Update (string MaNV)
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            var ttnv = NHANVIEN_DAO.GetById(MaNV);
            NHANVIEN_DANHSACHCHUCVU_MODEL model = new NHANVIEN_DANHSACHCHUCVU_MODEL()
            {
                NHANVIEN = ttnv,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update (NHANVIEN_DANHSACHCHUCVU_MODEL model)
        {
            var ttnv = NHANVIEN_DAO.GetById(model.NHANVIEN.manhanvien);
            if (ttnv != null) {
                ttnv.tennhanvien = model.NHANVIEN.tennhanvien;
                ttnv.tendangnhap = model.NHANVIEN.tendangnhap;
                ttnv.matkhau = model.NHANVIEN.matkhau;

                try
                {
                    NHANVIEN_DAO.Update(ttnv);
                    return RedirectToAction("Index");

                } catch
                {
                    return View("Lỗi cập nhật thông tin");
                }
            }
            return View("Lỗi không tìm thấy nhân viên");
        }


    }
}