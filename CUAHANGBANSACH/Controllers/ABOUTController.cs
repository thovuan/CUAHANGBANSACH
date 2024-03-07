using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUAHANGBANSACH.Controllers
{
    public class ABOUTController : Controller
    {
        // GET: ABOUT
        public ActionResult Our_Story()
        {
            return View();
        }

        public ActionResult Blog ()
        {
            return View();
        }

        public ActionResult Contact ()
        {
            return View();
        }
    }
}