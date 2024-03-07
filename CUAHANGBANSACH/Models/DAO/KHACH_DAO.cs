using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.DAO
{
    public class KHACH_DAO
    {
        public static KHACH GetByTDN(string tendangnhap, string matkhau)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var tttk = db.KHACHes.Where(n => n.tendangnhap == tendangnhap).FirstOrDefault();
                if (tttk != null)
                {
                    if (matkhau.Equals(tttk.matkhau))
                    {
                        return tttk;
                    } return null;
                }
                return null;
            }
        }
        
    }
}