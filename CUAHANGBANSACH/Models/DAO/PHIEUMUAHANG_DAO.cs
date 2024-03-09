using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.DAO
{
    public class PHIEUMUAHANG_DAO
    {
        public static List<PHIEUMUAHANG> GetAll()
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                List<PHIEUMUAHANG> pHIEUMUAHANGs = db.PHIEUMUAHANGs.ToList();
                if (pHIEUMUAHANGs!= null) return pHIEUMUAHANGs;
                return null;
            }
        }

        public static PHIEUMUAHANG GetById(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var manv = db.PHIEUMUAHANGs.Where(n => n.maphieumuahang == id).FirstOrDefault();
                if (manv != null) { return manv; }
                return null;
            }
        }
    }
}