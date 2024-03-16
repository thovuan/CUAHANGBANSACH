using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class SHOPController : Controller
    {
        // GET: SHOP
        public ActionResult Index(string Ma_TheLoai, string Ma_NXB)
        {
            
                
            if (Ma_TheLoai != null && Ma_NXB == null) ViewData.Model = SACH_DAO.ChuDe_List(Ma_TheLoai);
            else if (Ma_TheLoai == null && Ma_NXB != null) ViewData.Model = SACH_DAO.NXB_List(Ma_NXB);
            else ViewData.Model = SACH_DAO.All_List();
            return View();
        }
        
        public ActionResult Index02(string Ma_TheLoai) {

            /*DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities();
            List<SACH> list = SACH_DAO.ChuDe_List(chude);
            return View(list);*/

            ViewData.Model = SACH_DAO.ChuDe_List(Ma_TheLoai);
            //ViewBag.Ma_TheLoai = chude;
            return View();
        }

        public ActionResult Index03(string Ma_NXB) {
            ViewData.Model = SACH_DAO.NXB_List(Ma_NXB);
            return View();
        }

        

        //[HttpPost]
        public ActionResult Detail(string MaSach) {
            ViewData.Model = SACH_DAO.GetById(MaSach);
            return View();
        }
    }
}