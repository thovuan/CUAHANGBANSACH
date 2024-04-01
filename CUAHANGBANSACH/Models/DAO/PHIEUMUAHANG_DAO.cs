using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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
                var chitietpmh = db.PHIEUMUAHANGs.Where(n => n.maphieumuahang == id).FirstOrDefault();
                chitietpmh.dsSach = new List<SACH>();
                if (chitietpmh != null) { 
                    List<CHITIETDATHANG> ctdh = db.CHITIETDATHANGs.Where(n => n.maphieumuahang == chitietpmh.maphieumuahang).ToList();

                    foreach(CHITIETDATHANG ctdhs in ctdh)
                    {
                        
                        SACH hon = db.SACHes.Where(n => n.masach == ctdhs.masach).FirstOrDefault();
                        if (hon != null) {
                            hon.soluongmua = ctdhs.soluongmua;
                            hon.thanhtien = (int)(hon.dongia * ctdhs.soluongmua);
                            chitietpmh.DHTotal += hon.thanhtien;
                            chitietpmh.dsSach.Add(hon); }
                    }
                    return chitietpmh; }
                return null;
            }
        }

        public static PHIEUMUAHANG GetById2(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var ttdonhang = db.PHIEUMUAHANGs.Where(n => n.maphieumuahang == id).FirstOrDefault();
                if (ttdonhang != null) return ttdonhang;
                return null;
            }
        }

        public static PHIEUMUAHANG GetDHById(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var ttdonhang = db.PHIEUMUAHANGs.Where(n => n.makhachhang ==  id && n.tinhtrang == "Chưa Xác Nhận").FirstOrDefault();
                if (ttdonhang != null) return ttdonhang;
                return null;
            }
        }

        public static List<PHIEUMUAHANG> GetByGuestID (string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var PMH = db.PHIEUMUAHANGs.Where(n => n.makhachhang == id).ToList();
                if (PMH != null) { return PMH; }
                return null;
            }
        }

        public static PHIEUMUAHANG Create(PHIEUMUAHANG model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.PHIEUMUAHANGs.Add(model);
                db.SaveChanges();
                return model;
            }
        }

        public static PHIEUMUAHANG Update (PHIEUMUAHANG model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return model;
            }
        }

        public static PHIEUMUAHANG Delete(PHIEUMUAHANG model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.PHIEUMUAHANGs.Remove(model);
                db.SaveChanges();
                return model;
            }
        }
    }
}