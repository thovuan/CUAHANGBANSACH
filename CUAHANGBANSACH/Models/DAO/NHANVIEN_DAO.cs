using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.DAO
{
    public class NHANVIEN_DAO
    {
        public static NHANVIEN GetByTDN (string tendangnhap, string matkhau)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities ())
            {
                var tttk = db.NHANVIENs.Where(n => n.tendangnhap == tendangnhap).FirstOrDefault();

                if (tttk != null)
                {
                    if (matkhau.Equals (tttk.matkhau))
                    {
                        return tttk;
                    }
                    return null;
                }
                return null;
            }
        }

        public static NHANVIEN GetById (string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var manv = db.NHANVIENs.Where(n => n.manhanvien == id).FirstOrDefault();
                if (manv != null) { return  manv; }
                return null;
            }
        }
    }
}