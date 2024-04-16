using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                
                foreach(SACH sach in sACHes)
                {
                    
                    sach.tentheloai = db.THELOAISACHes.Where(n => n.matheloai == sach.matheloai).Select(n => n.tentheloai).FirstOrDefault();
                    sach.tennxb = db.NXBs.Where(n => n.manxb == sach.manxb).Select(n => n.tennxb).FirstOrDefault();
                    sach.tennhanvien = db.NHANVIENs.Where(n => n.manhanvien == sach.manhanvien).Select(n => n.tennhanvien).FirstOrDefault();
                }
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

        public static List<SACH> GetByName(string name)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                List<SACH> sACH = db.SACHes.Where(n => n.tensach.Contains(name)).ToList();
                if (sACH.Count > 0) return sACH;
                return null;
            }
        }

        public static SACH GetById(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var sach = db.SACHes.Where(n => n.masach == id).FirstOrDefault();
                if (sach == null) return null;
                sach.tentheloai = db.THELOAISACHes.Where(n => n.matheloai == sach.matheloai).Select(n => n.tentheloai).FirstOrDefault();
                sach.tennxb = db.NXBs.Where(n => n.manxb == sach.manxb).Select(n=> n.tennxb).FirstOrDefault();
                sach.tennhanvien = db.NHANVIENs.Where(n=> n.manhanvien == sach.manhanvien).Select(n=>n.tennhanvien).FirstOrDefault();
                return sach;
            }
        }

        public static SACH Update (SACH model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return model;
            }
        }

        public static SACH Add(SACH model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.SACHes.Add(model);
                db.SaveChanges();
                return model;
            }
        }

        public static SACH Delete(SACH model)
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