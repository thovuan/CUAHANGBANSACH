using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.Combined_Model;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public ActionResult Index(string Find)
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            if (Find != null) return View(NHANVIEN_DAO.GetByName(Find));
            return View (NHANVIEN_DAO.GetAllList());
            
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

        public ActionResult AddCV (string MaNV)
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            var ttnv = NHANVIEN_DAO.GetById2(MaNV);
            if (ttnv == null) return View("Lỗi không tìm thấy nhân viên");
            var dscv = CHUCVU_DAO.GetAllList();
            NHANVIEN_DANHSACHCHUCVU_MODEL model = new NHANVIEN_DANHSACHCHUCVU_MODEL()
            {
                NHANVIEN = ttnv,
                CHUCVU = dscv,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCV (NHANVIEN_DANHSACHCHUCVU_MODEL model)
        {
            string selectedCV = Request.Form["CHUCVU"];

            var ttnv = NHANVIEN_DAO.GetById2(model.NHANVIEN.manhanvien);
            if (ttnv == null) return View("Lỗi không tìm thấy nhân viên");

            var ktcv = CHITIETCHUCVU_DAO.FindCV(model.NHANVIEN.manhanvien, selectedCV);
            if (ktcv != null)
            {
                return View("Không thể thêm chức vụ");
            }
            DateTime dt = new DateTime();
            dt = DateTime.Now.AddYears(5);
            CHITIETCHUCVU ct = new CHITIETCHUCVU()
            {
                manhanvien = ttnv.manhanvien,
                machucvu = selectedCV,
                thoihanhopdong = dt,
            };

            try
            {
                CHITIETCHUCVU_DAO.Create(ct);
                return RedirectToAction("Index");
            } catch
            {
                return View("Có lỗi xảy ra");
            }
            //return View(model);
        }

        public ActionResult DeleteCV (string MaNV, string Ma_CV)
        {
            NHANVIEN login = (NHANVIEN)Session["NhanVien"];
            if (login.manhanvien == MaNV) return View("Không thể xóa chức vụ nhân viên đang đăng nhập");
            var ttnv = NHANVIEN_DAO.GetById2(MaNV);
            if (ttnv == null) return View("Lỗi không tìm thấy nhân viên");

            var ktcv = CHITIETCHUCVU_DAO.FindCV(MaNV, Ma_CV);
            if (ktcv == null)
            {
                return View("Không tìm thấy chức vụ");
            }

            try
            {
                CHITIETCHUCVU_DAO.Delete(ktcv); return RedirectToAction("Index");
            } catch
            {
                return View("Có lỗi xảy ra");
            }
        }

    }
}