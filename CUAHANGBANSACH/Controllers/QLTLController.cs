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
        public ActionResult Index(string Find)
        {
            if (!KiemTraPhanQuyen("CV02"))
            return View("Bạn không có quyền truy cập vào page");
            //viet code lay danh sach o day (Tạo GetAllList ở THELOAI_DAO)
            if (Find != null)
            {
                return View(THELOAI_DAO.GetName(Find));
            }
            return View(THELOAI_DAO.GetList());
        }

        public ActionResult Create()
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(THELOAISACH model)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            var getbyid = THELOAI_DAO.GetbyId(model.matheloai);
            if (getbyid != null)
            {
                return View("Không thêm được!!!");
            }
            try
            {
                THELOAISACH tls = new THELOAISACH() { matheloai = model.matheloai, tentheloai = model.tentheloai };
                THELOAI_DAO.create(tls);
                return RedirectToAction("index");
            }
            catch (Exception ex) { return View(); }

            //Code tim kiem the loai
            //Nếu mã thể loại tồn tại thì trả về tồn tại
            //Tạo thêm thể loại (nhớ tạo Create bên THELOAI_DAO)
            

            
        }
        public ActionResult Details (string MaTL) 
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            //code lấy thông tin thể loại
            var tttl = THELOAI_DAO.GetbyId(MaTL);
            if (tttl != null) return View(tttl);
            return View("Không có tìm thấy"); 
        }

        public ActionResult Update(string MaTL) 
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");
            var tttl = THELOAI_DAO.GetbyId(MaTL);
            if (tttl != null) return View(tttl);
            return View("Không có tìm thấy");
            //code lấy thông tin thể loại
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(THELOAISACH model)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");
            var getbyid = THELOAI_DAO.GetbyId(model.matheloai);
            if (getbyid != null)
            {
                getbyid.tentheloai = model.matheloai;
                try
                {
                    THELOAI_DAO.update(getbyid);
                    return RedirectToAction("index");
                }
                catch (Exception ex) { return View("Error"); }
            } return View("Error");

            //update tên thể loại (Tạo Update tại DAO)
            
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