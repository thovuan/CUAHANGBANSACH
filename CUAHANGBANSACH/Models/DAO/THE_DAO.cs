using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.DAO
{
    public class THE_DAO
    {
        public static THE Create(THE model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.THEs.Add(model);
                db.SaveChanges();
                return model;
            }
        }
        public static THE Update(THE model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return model;
            }
        }
        public static THE Delete(THE model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                //db.SACHes.Remove(model);

                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return model;
            }
        }
        public static THE GetByID(string mathe)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var the = db.THEs.Where(m => m.mathe == mathe).FirstOrDefault();
                return the;
            }
        }
        public static THE GetByIDG(string makh)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var the = db.THEs.Where(m => m.makhachhang == makh).FirstOrDefault();
                return the;
            }
        }
    }
}