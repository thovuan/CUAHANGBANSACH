using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.DAO
{
    public class NXB_DAO
    {
        public static List<NXB> Read()
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                List<NXB> ketqua = db.NXBs.ToList();
                foreach (NXB nxb in ketqua)
                {
                    nxb.Count = db.SACHes.Count(n => n.manxb == nxb.manxb);
                }
                return ketqua;
            }
        }

        public static List<NXB> GetList()
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                List<NXB> ketqua = db.NXBs.ToList();
                
                return ketqua;
            }
        }



        public static NXB GetById(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var manxb = db.NXBs.Where(n => n.manxb == id).FirstOrDefault();
                if (manxb != null) return manxb;
                return null;
            }
        }

        public static List<NXB> GetByName(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var manxb = db.NXBs.Where(n => n.tennxb.Contains(id)).ToList();
                if (manxb != null) return manxb;
                return null;
            }
        }

        public static NXB Create(NXB model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.NXBs.Add(model);
                db.SaveChanges();
                return model;
            }
        }

        public static NXB Update(NXB model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return model;
            }
        }

        public static NXB Delete (NXB model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return model;
            }
        }
    }
}