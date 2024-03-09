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

        public static List<SACH> NXB_List(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                List<SACH> nXBs = db.SACHes.Where(n => n.manxb == id).ToList();
                if (nXBs.Count > 0) return nXBs;
                return null;
            }
        }

        public static SACH GetById(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var sach = db.SACHes.Where(n => n.masach == id).FirstOrDefault();
                if (sach == null) return null;
                return sach;
            }
        }
    }
}