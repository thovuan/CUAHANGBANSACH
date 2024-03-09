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

        

        public static NXB GetById(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var manxb = db.NXBs.Where(n => n.manxb == id).FirstOrDefault();
                if (manxb != null) return manxb;
                return null;
            }
        }
    }
}