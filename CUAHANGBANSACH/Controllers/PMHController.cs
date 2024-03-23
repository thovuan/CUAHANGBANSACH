using CUAHANGBANSACH.Models;
using CUAHANGBANSACH.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class PMHController : Controller
    {
        // GET: PMH
        public ActionResult Index()
        {
            
            return View(PHIEUMUAHANG_DAO.GetAll());
        }

        
    }
}