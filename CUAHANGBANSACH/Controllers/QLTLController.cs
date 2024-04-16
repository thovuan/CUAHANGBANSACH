using CUAHANGBANSACH.Models.DAO;
using CUAHANGBANSACH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class QLTLController : Controller
    {
        // GET: QLTL
        public bool KiemTraPhanQuyen(string cv)
        {
            NHANVIEN nv = (NHANVIEN)Session["NhanVien"];
            var check = NHANVIEN_DAO.KiemTraPhanQuyen(nv.manhanvien, cv);
            if (check != null) return true;
            return false;
        }
        public ActionResult Index(string MaTL)
        {
            if (!KiemTraPhanQuyen("CV02"))
            return View("Bạn không có quyền truy cập vào page");
            //viet code lay danh sach o day (Tạo GetAllList ở THELOAI_DAO)
            return View();
        }

        public ActionResult Create(THELOAISACH model)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            //Code tim kiem the loai
            //Nếu mã thể loại tồn tại thì trả về tồn tại
            //Tạo thêm thể loại (nhớ tạo Create bên THELOAI_DAO)
            return View();
        }
        public ActionResult Details (string MaTL) 
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            //code lấy thông tin thể loại
            return View(); 
        }

        public ActionResult Update(string MaTL) 
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            //code lấy thông tin thể loại
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(THELOAISACH model)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            //update tên thể loại (Tạo Update tại DAO)
            return View();
        }

        public ActionResult Delete(string MaTL) 
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");
            return View(); 
        
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(THELOAISACH model)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");
            return View();

        }

    }
}