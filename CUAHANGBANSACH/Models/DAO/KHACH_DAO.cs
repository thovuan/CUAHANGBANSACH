using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.DAO
{
    public class KHACH_DAO
    {
        public static List<KHACH> GetAllList ()
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                List<KHACH> tttk = db.KHACHes.ToList();

                return tttk;
            }
        }
        public static KHACH GetByTDN(string tendangnhap)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var tttk = db.KHACHes.Where(n => n.tendangnhap == tendangnhap).FirstOrDefault();
                
                return tttk;
            }
        }

        public static KHACH GetById (string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var makh = db.KHACHes.Where(n => n.makhachhang == id).FirstOrDefault();
                if (makh != null) { return makh; }
                return null;
            }
        }

        public static KHACH GetByEmail(string email)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var cemail = db.KHACHes.Where(n => n.email == email).FirstOrDefault();
                if (cemail != null) { return cemail; }
                return null;
            }
        }

        public static KHACH Update(KHACH model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return model;
            }
        }

        public static KHACH Create(KHACH model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                //db.Entry(model).State = System.Data.Entity.EntityState.Added;
                db.KHACHes.Add(model);
                db.SaveChanges();
                return model;
            }
        }

    }
}