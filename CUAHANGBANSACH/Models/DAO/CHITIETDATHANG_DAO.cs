using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.DAO
{
    public class CHITIETDATHANG_DAO
    {
        public static CHITIETDATHANG GetBySACHID(string SACHid, string PMHid)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var ttsach = db.CHITIETDATHANGs.Where(n => n.maphieumuahang == PMHid && n.masach == SACHid).FirstOrDefault();
                if (ttsach != null) { return ttsach; }
                return null;
            }
        }
        public static List<CHITIETDATHANG> GetById(string PMHid)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var ttdh = db.CHITIETDATHANGs.Where(n => n.masach == PMHid).ToList();
                if (ttdh != null) { return ttdh; }
                return null;
            }
        }

        public static CHITIETDATHANG Delete(CHITIETDATHANG model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return model; 
            }
        }

        public static CHITIETDATHANG Add (CHITIETDATHANG model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return model;
            }
        }

        public static CHITIETDATHANG Update (CHITIETDATHANG model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return model;
            }
        }

        
    }
}