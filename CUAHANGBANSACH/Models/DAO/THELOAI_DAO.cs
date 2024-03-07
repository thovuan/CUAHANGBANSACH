using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CUAHANGBANSACH.Models.DAO
{
    public class THELOAI_DAO
    {
        public static List<THELOAISACH> Read()
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                List<THELOAISACH> ketqua = db.THELOAISACHes.ToList();
                foreach (THELOAISACH tls in ketqua) { tls.Count = db.SACHes.Count(n => n.matheloai == tls.matheloai); }
                return ketqua;
            }
 
        }
    }
}