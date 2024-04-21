using CUAHANGBANSACH.Models.DAO;
using CUAHANGBANSACH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CUAHANGBANSACH.Controllers
{
    public class QLNXBController : Controller
    {
        public bool KiemTraPhanQuyen(string cv)
        {
            NHANVIEN nv = (NHANVIEN)Session["NhanVien"];
            var check = NHANVIEN_DAO.KiemTraPhanQuyen(nv.manhanvien, cv);
            if (check != null) return true;
            return false;
        }
        // GET: QLNXB
        public ActionResult Index(string Find)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");
            if (TempData["Result"] != null)
            {
                if (TempData["Result"].ToString().Contains("Successful")) ViewBag.Success = TempData["Result"];
                else ViewBag.Failure = TempData["Result"];
            }
            
            if (Find != null) return PartialView(NXB_DAO.GetByName(Find));
            return View(NXB_DAO.GetList());
        }

        public ActionResult Detail(string MaNXB)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            var ttnxb = NXB_DAO.GetById(MaNXB);
            if (ttnxb != null) return View(ttnxb);
            return View("Can't Find");
        }
        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NXB model)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            var ttnxb = NXB_DAO.GetById(model.manxb);
            if (ttnxb != null)
            {
                ModelState.AddModelError("manxb", "Thông tin nxb có tồn tại trong CSDL");
                return View(model);
            }

            NXB nxb = new NXB()
            {
                manxb = model.manxb,
                tennxb = model.tennxb,
            };

            try
            {
                NXB_DAO.Create(nxb);
                TempData["Result"] = "Add Book Information Successful";
                return RedirectToAction("Index");

            } catch
            {
                return View("Có lỗi xảy ra khi thêm");
            }
            
        }

        public ActionResult Edit(string MaNXB)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            var ttnxb = NXB_DAO.GetById(MaNXB);
            if (ttnxb != null) return View(ttnxb);
            return View("Can't Find");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (NXB model)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");

            var ttnxb = NXB_DAO.GetById(model.manxb);
            if (ttnxb != null)
            {
                ttnxb.tennxb = model.tennxb;

                try
                {
                    NXB_DAO.Update(model);
                    TempData["Result"] = "Update NXB Information Successful";
                    return RedirectToAction("Index");


                } catch
                {
                    TempData["Result"] = "Update NXB Information Failure";
                    return View("Có lỗi xảy ra khi cập nhật");
                }
            }
            return View("Can't Find");
        }
        public ActionResult Delete(string MaNXB)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");
            var ttnxb = NXB_DAO.GetById(MaNXB);
            if (ttnxb != null) return View(ttnxb);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(NXB model)
        {
            if (!KiemTraPhanQuyen("CV02"))
                return View("Bạn không có quyền truy cập vào page");
            var ttnxb = NXB_DAO.GetById(model.manxb);
            if (ttnxb != null) return View(ttnxb);

            List<SACH> sach = new List<SACH>();
            sach = SACH_DAO.GetByNXBId(model.manxb);
            if (sach != null)
            {
                foreach (SACH hon in sach)
                {
                    hon.manxb = "0";

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
                NXB_DAO.Delete(model);
                TempData["Result"] = "Delete NXB Successful";
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