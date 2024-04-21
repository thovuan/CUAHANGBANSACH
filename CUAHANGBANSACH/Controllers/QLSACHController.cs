using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.Combined_Model;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    
    public class QLSACHController : Controller
    {
        public bool KiemTraPhanQuyen(string cv)
        {
            NHANVIEN nv = (NHANVIEN)Session["NhanVien"];
            var check = NHANVIEN_DAO.KiemTraPhanQuyen(nv.manhanvien, cv);
            if (check!=null) return true;
            return false;
        }
        
        // GET: QLSACH
        public ActionResult Index(string Find)
        {
            if (KiemTraPhanQuyen("CV02"))
            {
                
                if (Find != null)
                    return View(SACH_DAO.GetByName(Find));

                if (TempData["Result"] != null)
                {
                    if (TempData["Result"].ToString().Contains("Successful")) ViewBag.Success = TempData["Result"];
                    else ViewBag.Failure = TempData["Result"];
                }

                return View(SACH_DAO.All_List());
            }
                
            return View("Bạn không có quyền truy cập vào page");
        }

        
        public ActionResult Details(string Ma_Sach)
        {
            if (KiemTraPhanQuyen("CV02"))
                return View(SACH_DAO.GetById(Ma_Sach));
            return View("Bạn không có quyền truy cập vào page");
        }

        
        

        public ActionResult Create (SACH_THELOAI_NXB_MODEL model)
        {
            if (KiemTraPhanQuyen("CV02"))
            {
                var tl = THELOAI_DAO.Read();
                var nxb = NXB_DAO.Read();
                model.THELOAISACH = tl;
                model.NXB = nxb;
                return View(model);
            }
                
            return View("Bạn không có quyền truy cập");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (SACH_THELOAI_NXB_MODEL model, HttpPostedFileBase image)
        {
            //tim kiem thong tin sach
            var idsach = SACH_DAO.GetById(model.SACH.masach);
            //lay ma nhan vien
            NHANVIEN nv = (NHANVIEN)Session["NhanVien"];
            string fileName = "";

            //lay thong tin the loai
            string selectedTL = Request.Form["TheLoai"];
            model.SACH.matheloai = selectedTL;

            //lay thong tin nha xuat ban
            string selectedNXB = Request.Form["NXB"];
            model.SACH.manxb = selectedNXB;


            if (idsach!= null)
            {
                ModelState.AddModelError("error", "Mã sách đã tồn tại trong danh sách");
                return View(model);
            } else
            {
                if (image != null && image.ContentLength > 0)
                {
                    var uploadPath = Server.MapPath("~/Content/ANHSANPHAM/");
                    if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

                    fileName = Path.GetFileName(image.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Content/ANHSANPHAM/"), fileName);
                    if (System.IO.File.Exists(filePath)) {
                        System.IO.File.Delete(filePath);    
                    } 
                    
                    image.SaveAs(filePath);


                }
                SACH sach = new SACH()
                {
                    masach = model.SACH.masach,
                    tensach = model.SACH.tensach,
                    soluonghienco = model.SACH.soluonghienco,
                    dacdiem = model.SACH.dacdiem,
                    DVT = model.SACH.DVT,
                    dongia = model.SACH.dongia,
                    matheloai = model.SACH.matheloai,
                    manhanvien = nv.manhanvien,
                    manxb = model.SACH.manxb,
                    anhsanpham = "/Content/ANHSANPHAM/" + fileName
                };
                try
                {
                    SACH_DAO.Add(sach);
                    TempData["Result"] = "Add Book Information Successful";
                    return RedirectToAction("Index");

                } catch (Exception ex)
                {
                    ModelState.AddModelError("masach", "Lỗi thêm sách");
                    TempData["Result"] = "Add Book Information Failure";
                    return View(model);
                }
            }
        }
        public ActionResult Edit(string Ma_Sach)
        {
            if (KiemTraPhanQuyen("CV02"))
            {
                var sach = SACH_DAO.GetById(Ma_Sach);
                var tl = THELOAI_DAO.Read();
                var nxb = NXB_DAO.Read();
                SACH_THELOAI_NXB_MODEL stn = new SACH_THELOAI_NXB_MODEL()
                {
                    SACH = sach,
                    THELOAISACH = tl,
                    NXB = nxb
                };
                
                return View(stn);
            }
                
            return View("Bạn không có quyền truy cập");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SACH_THELOAI_NXB_MODEL model)
        {
            //tim kiem thong tin sach
            var idsach = SACH_DAO.GetById(model.SACH.masach);
            //lay ma nhan vien
            NHANVIEN nv = (NHANVIEN)Session["NhanVien"];
            string fileName = "";

            //lay thong tin the loai
            string selectedTL = Request.Form["TheLoai"];
            model.SACH.matheloai = selectedTL;

            //lay thong tin nha xuat ban
            string selectedNXB = Request.Form["NXB"];
            model.SACH.manxb = selectedNXB;


            if (idsach == null) return View("Lỗi");
                //idsach.masach = model.SACH.masach;
                idsach.tensach = model.SACH.tensach;
                idsach.soluonghienco = model.SACH.soluonghienco;
                idsach.dacdiem = model.SACH.dacdiem;
                idsach.DVT = model.SACH.DVT;
                idsach.dongia = model.SACH.dongia;
                idsach.matheloai = model.SACH.matheloai;
                idsach.manhanvien = nv.manhanvien;
                idsach.manxb = model.SACH.manxb;
                try
                {
                    SACH_DAO.Update(idsach);
                    TempData["Result"] = "Update Book Information Successful";
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("tensach", "Lỗi thêm sách");
                    TempData["Result"] = "Update Book Information Failure";
                    return View(model);
                }
            
        }

        public ActionResult UploadImage(string Ma_Sach)
        {
            if (KiemTraPhanQuyen("CV02"))
                return View(SACH_DAO.GetById(Ma_Sach));
            return View("Bạn không có quyền truy cập");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadImage(SACH model, HttpPostedFileBase image)
        {
            var idsach = SACH_DAO.GetById(model.masach);
            if (idsach == null) return View("Không tìm thấy");

            if (image != null && image.ContentLength > 0)
            {
                var uploadPath = Server.MapPath("~/Content/ANHSANPHAM/");
                if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

                string fileName = Path.GetFileName(image.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Content/ANHSANPHAM/"), fileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                image.SaveAs(filePath);
                //idsach.masach = model.masach;
                
                idsach.anhsanpham = "/Content/ANHSANPHAM/" + fileName;
            }
            try
            {
                SACH_DAO.Update(idsach);
                TempData["Result"] = "Update Book's Picture Successful";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("error", "Lỗi cập nhật thông tin");
                TempData["Result"] = "Update Book's Picture Successful";
                return View("Index");
            }

        }

        public ActionResult Delete(string Ma_Sach) {
            if (KiemTraPhanQuyen("CV02"))
                return View(SACH_DAO.GetById(Ma_Sach));
            return View("Bạn không có quyền truy cập");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (SACH model)
        {
            var idsach = SACH_DAO.GetById(model.masach);
            if (idsach == null)
            {
                ModelState.AddModelError("error", "Không tìm thấy thông tin cần xóa");
                return View(model);
            }
            try
            {
                SACH_DAO.Delete(model);
                TempData["Result"] = "Delete Book Successful";
                return RedirectToAction("Index");

            } catch (Exception ex) { }
            {
                ModelState.AddModelError("error", "Lỗi xóa sách");
                TempData["Result"] = "Delete Book Failure";
                return View(model);
            }
        }
    }
}