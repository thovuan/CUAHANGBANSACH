using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.DAO
{
    public class CHITIETCHUCVU_DAO
    {
        public static CHITIETCHUCVU FindCV (string mnv, string mcv)
        {
            using(DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var fcv = db.CHITIETCHUCVUs.Where(n=> n.manhanvien == mnv && (n.machucvu == mcv || n.machucvu == "CV01")).FirstOrDefault();
                return fcv;
            }
        }

        public static CHITIETCHUCVU Create(CHITIETCHUCVU model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.CHITIETCHUCVUs.Add(model);
                db.SaveChanges();
                return model;
            }
        }

        public static CHITIETCHUCVU Delete(CHITIETCHUCVU model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                //db.SACHes.Remove(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return model;
            }
        }
    }
}