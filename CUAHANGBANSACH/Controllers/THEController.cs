using CUAHANGBANSACH.Models.DAO;
using CUAHANGBANSACH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class THEController : Controller
    {
        // GET: THE
        public ActionResult Index(string Ma_KH)
        {

            var the = THE_DAO.GetByIDG(Ma_KH);
            if (the == null)
            { return View(the); }
            return View(the);
        }
        public ActionResult Create()
        {
            //goi datetime, sau do lay thoi gian thuc va gan voi THEyyyymmdd
            KHACH kHACH = (KHACH)Session["KHACH"];
            DateTime dateTime = DateTime.Now;
            THE the = new THE()
            {
                mathe = "THE" + dateTime.ToString("yyyyMMddHHmmss"),
                diemthe = 1000,
                makhachhang = kHACH.makhachhang,
            };
            try
            {
                THE_DAO.Create(the);
                return RedirectToAction("TTKH", "GUESTLOGIN");
            }
            catch (Exception ex)
            {
                return View("Có lỗi xảy ra");
            }
        }
        public ActionResult Delete(string mathe)
        {
            var the = THE_DAO.GetByID(mathe);
            if (the == null)
            { return HttpNotFound(); }

            return View(the);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(THE model)
        {
            var the = THE_DAO.GetByID(model.mathe);
            if (the == null)
            { return HttpNotFound(); }
            try
            {
                THE_DAO.Delete(the);
                return RedirectToAction("TTKH", "GUESTLOGIN");
            }
            catch (Exception ex) { return View("Deleted Faiure!!!"); }
        }
    }
}