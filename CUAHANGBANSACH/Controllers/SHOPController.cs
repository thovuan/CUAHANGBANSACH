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
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Index02(string chude) {
            
            /*DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities();
            List<SACH> list = SACH_DAO.ChuDe_List(chude);
            return View(list);*/

            ViewBag.Ma_TheLoai = chude;
            return View();
        }
    }
}