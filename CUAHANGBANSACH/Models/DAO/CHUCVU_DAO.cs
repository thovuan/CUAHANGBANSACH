using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.DAO
{
    public class CHUCVU_DAO
    {
        public static List<CHUCVU> GetAllList()
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                return db.CHUCVUs.ToList();
            }
        }

        public static CHUCVU GetById (string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var cv = db.CHUCVUs.Where(n => n.machucvu == id).FirstOrDefault();
                cv.nv = new List<NHANVIEN>();
                if (cv != null)
                {
                    List<CHITIETCHUCVU> nhanvien = db.CHITIETCHUCVUs.Where(n=> n.machucvu == cv.machucvu).ToList();
                    foreach(CHITIETCHUCVU nhanvien_ in nhanvien)
                    {
                        NHANVIEN nHANVIEN = db.NHANVIENs.Where(n=> n.manhanvien == nhanvien_.manhanvien).FirstOrDefault();
                        if (nHANVIEN != null) cv.nv.Add(nHANVIEN);
                    }
                    return cv;
                }
                return null;
            }
        }

        public static CHUCVU GetById02 (string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var cv = db.CHUCVUs.Where(n => n.machucvu == id).FirstOrDefault();
                if (cv != null)
                {
 
                    return cv;
                }
                return null;
            }
        }

        public static CHUCVU Create(CHUCVU model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.CHUCVUs.Add(model);
                db.SaveChanges();
                return model;
            }
        }

        public static CHUCVU Edit(CHUCVU model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return model;
            }
        }

        public static CHUCVU Delete(CHUCVU model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                bool ttcv = db.CHITIETCHUCVUs.Any(n => n.machucvu == model.machucvu);
                if (ttcv)
                {
                    return null;
                }
                else
                {
                        db.CHUCVUs.Remove(model);
                        db.SaveChanges();
                        return model;
                }
            }
        }
    }
}