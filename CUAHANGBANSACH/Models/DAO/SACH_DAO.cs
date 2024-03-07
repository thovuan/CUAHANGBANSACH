using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.DAO
{
    public class SACH_DAO
    {
        public static List<SACH> All_List()
        {
            using (DOANWEB_INITIALEntities db  = new DOANWEB_INITIALEntities())
            {
                List<SACH> sACHes = db.SACHes.ToList();
                return sACHes;
            }
        }

        public static List<SACH> ChuDe_List(string chude)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var sach = db.SACHes.Where(n =>  n.matheloai == chude).ToList();
                return sach;
            }
        }
    }
}