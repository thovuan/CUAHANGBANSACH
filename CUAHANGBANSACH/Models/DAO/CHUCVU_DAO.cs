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

        /*public static CHUCVU GetById (string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var cv = db.CHUCVUs.Where(n => n.machucvu == id).FirstOrDefault();
                if (cv != null)
                {
                    
                }
            }
        }*/
    }
}