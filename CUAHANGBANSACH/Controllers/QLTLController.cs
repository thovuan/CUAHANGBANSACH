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
            if (TempData["Result"] != null)
            {
                if (TempData["Result"].ToString().Contains("Successful")) ViewBag.Success = TempData["Result"];
                else ViewBag.Failure = TempData["Result"];
            }

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

                TempData["Result"] = "Add CATEGORY Information Successful";
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
                getbyid.tentheloai = model.tentheloai;
                try
                {
                    THELOAI_DAO.update(getbyid);
                    TempData["Result"] = "Update CATEGORY Information Successful";
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

            var tttl = THELOAI_DAO.GetbyId(MaTL);
            if (tttl != null) return View(tttl);
            return View("Không có tìm thấy");
            
        
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(THELOAISACH model)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            var tttl = THELOAI_DAO.GetbyId(model.matheloai);
            if (tttl == null) return View("Không tìm thấy");
            
            List<SACH> sach = new List<SACH>();
            sach = SACH_DAO.GetByNXBId(model.matheloai);
            if (sach != null)
            {
                foreach (SACH hon in sach)
                {
                    hon.matheloai = "0";

                    try
                    {
                        SACH_DAO.Update(hon);
                    }
                    catch
                    {
                        return View("Error");
                    }
                }

            }
            try
            {
                THELOAI_DAO.delete(model);
                TempData["Result"] = "Delete CATEGORY Successful";
                return RedirectToAction("Index");

            }
            catch (Exception ex) { }
            {
                ModelState.AddModelError("error", "Lỗi xóa NXB");
                TempData["Result"] = "Delete NXB Failure";
                return View(model);
            }
            

        }

    }
}