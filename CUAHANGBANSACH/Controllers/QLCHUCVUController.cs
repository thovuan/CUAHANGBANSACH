using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class QLCHUCVUController : Controller
    {
        // GET: QLCHUCVU
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
            return View(CHUCVU_DAO.GetAllList());
        }

        public ActionResult Details(string MaCV)
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            return View(CHUCVU_DAO.GetById(MaCV));
        }

        public ActionResult Create()
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CHUCVU model)
        {
            var ttcv = CHUCVU_DAO.GetById02(model.machucvu);
            if (ttcv != null)
            {
                ModelState.AddModelError("machucvu", "Mã chức vụ đã tồn tại trong CSDL");
                return View(model);
            } else
            {
                CHUCVU cv = new CHUCVU()
                {
                    machucvu = model.machucvu,
                    tenchucvu = model.tenchucvu,
                    tinhtrang = model.tinhtrang
                };
                try
                {
                    CHUCVU_DAO.Create(cv);
                    return RedirectToAction("Index");

                } catch (Exception ex)
                {
                    ModelState.AddModelError("machucvu", "Lỗi thêm thông tin chức vụ");
                    return View(model);
                }
            }
        }

        public ActionResult Edit(string MaCV)
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            return View(CHUCVU_DAO.GetById02(MaCV));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CHUCVU model)
        {
            var idchucvu = CHUCVU_DAO.GetById02(model.machucvu);
            if (idchucvu != null)
            {
                idchucvu.tenchucvu = model.tenchucvu;
                try
                {
                    CHUCVU_DAO.Edit(idchucvu);
                    return RedirectToAction("Index");
                } catch (Exception ex)
                {
                    ModelState.AddModelError("tenchucvu", "Lỗi cập nhật thông tin");
                    return View(model);
                }
            }
            return HttpNotFound();
        }

        public ActionResult Delete(string MaCV)
        {
            if (!KiemTraPhanQuyen("CV01")) return View("Bạn không có quyền vào đây");
            return View(CHUCVU_DAO.GetById02(MaCV));
        }

        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(CHUCVU model)
        {
            var ttcv = CHUCVU_DAO.GetById02(model.machucvu);
            if (ttcv  != null)
            {
                try
                {
                    CHUCVU_DAO.Delete(ttcv);
                    return RedirectToAction("Index");

                } catch (Exception ex)
                {
                    ModelState.AddModelError("machucvu", "Lỗi xóa thông tin");
                    return View(model);
                }
            } return View(model);
        }
    }
}