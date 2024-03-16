using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class QLSACHController : Controller
    {
        DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities();
        // GET: QLSACH
        public ActionResult Index()
        {
            return View(SACH_DAO.All_List());
        }

        
        public ActionResult Details(string Ma_Sach)
        {
            return View(SACH_DAO.GetById(Ma_Sach));
        }

        
        

        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (SACH model)
        {
            var idsach = SACH_DAO.GetById(model.masach);
            if (idsach!= null)
            {
                ModelState.AddModelError("error", "Mã sách đã tồn tại trong danh sách");
                return View(model);
            } else
            {
                SACH sach = new SACH()
                {
                    masach = model.masach,
                    tensach = model.tensach,
                    soluonghienco = model.soluonghienco,
                    dacdiem = model.dacdiem,
                    DVT = model.DVT,
                    dongia = model.dongia,
                    matheloai = model.matheloai,
                    manhanvien = model.manhanvien,
                    manxb = model.manxb,
                };
                try
                {
                    SACH_DAO.Add(sach);
                    return RedirectToAction("Index");

                } catch (Exception ex)
                {
                    ModelState.AddModelError("error", "Lỗi thêm sách");
                    return View(model);
                }
            }
        }
        public ActionResult Edit(string Ma_Sach)
        {
            return View(SACH_DAO.GetById(Ma_Sach));
            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SACH model)
        {
            //DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities();
            var idsach = SACH_DAO.GetById(model.masach);
            //ViewData.Model = idsach;
            idsach.tensach = model.tensach;
            idsach.soluonghienco = model.soluonghienco;
            idsach.dacdiem = model.dacdiem;
            idsach.DVT = model.DVT;
            idsach.dongia = model.dongia;
            idsach.matheloai = model.matheloai;
            idsach.manhanvien = model.manhanvien;
            idsach.manxb = model.manxb;
            //db.Entry(idsach).State = System.Data.Entity.EntityState.Modified;
            try
            {
                SACH_DAO.Update(model);
                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                ModelState.AddModelError("error", "Lỗi cập nhật thông tin");
                return View(model);
            }
            //return View();
        }

        public ActionResult Delete(string Ma_Sach) { 
            return View(SACH_DAO.GetById(Ma_Sach));
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
                return RedirectToAction("Index");

            } catch (Exception ex) { }
            {
                ModelState.AddModelError("error", "Lỗi xóa sách");
                return View(model);
            }
        }
    }
}