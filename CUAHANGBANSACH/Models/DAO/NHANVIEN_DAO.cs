using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CUAHANGBANSACH.Models.DAO
{
    public class NHANVIEN_DAO
    {
        public static NHANVIEN GetByTDN (string tendangnhap)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities ())
            {
                var tttk = db.NHANVIENs.Where(n => n.tendangnhap == tendangnhap).FirstOrDefault();

                return tttk;
            }
        }
        public static NHANVIEN GetByTen(string ten)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var tttk = db.NHANVIENs.Where(n => n.tennhanvien == ten).FirstOrDefault();

                return tttk;
            }
        }

        public static NHANVIEN GetById (string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var manv = db.NHANVIENs.Where(n => n.manhanvien == id).FirstOrDefault();
                manv.chucvu = new List<CHUCVU>();
                if (manv != null) {
                    List<CHITIETCHUCVU> ctchucvu = db.CHITIETCHUCVUs.Where(n => n.manhanvien == manv.manhanvien).ToList();
                    
                    foreach(CHITIETCHUCVU cv in ctchucvu)
                    {
                        CHUCVU CV = db.CHUCVUs.Where(n => n.machucvu == cv.machucvu).FirstOrDefault();
                        if (CV != null)
                            manv.chucvu.Add(CV);
                    }
                    return  manv; }
                return null;
            }
        }
        public static NHANVIEN GetById2(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var manv = db.NHANVIENs.Where(n => n.manhanvien == id).FirstOrDefault();
                return manv;
       
            }
        }

        public static List<NHANVIEN> GetByName(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var nv = db.NHANVIENs.Where(n => n.tennhanvien.Contains(id)).ToList();
                return nv;

            }
        }

        public static List<NHANVIEN> GetAllList()
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var ds = db.NHANVIENs.ToList();
                
                return ds;
            }
        }

        public static CHITIETCHUCVU KiemTraPhanQuyen(string id, string macv)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var check = db.CHITIETCHUCVUs.Where(n => n.manhanvien == id && (n.machucvu == "CV01" || n.machucvu == macv)).FirstOrDefault();
                if (check != null) return check;
                return null;
            }
        }

        public static NHANVIEN Create (NHANVIEN model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.NHANVIENs.Add(model);
                db.SaveChanges();
                return model;
            }
        }

        public static NHANVIEN Update (NHANVIEN model)
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