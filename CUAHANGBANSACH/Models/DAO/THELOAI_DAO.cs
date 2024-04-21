using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CUAHANGBANSACH.Models.DAO
{
    public class THELOAI_DAO
    {
        public static List<THELOAISACH> Read()
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                List<THELOAISACH> ketqua = db.THELOAISACHes.ToList();
                foreach (THELOAISACH tls in ketqua) { tls.Count = db.SACHes.Count(n => n.matheloai == tls.matheloai); }
                return ketqua;
            }
 
        }

        public static List<THELOAISACH> GetList()
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                List<THELOAISACH> list = db.THELOAISACHes.ToList();
                
                return list;
            }
        }
        public static THELOAISACH getNamebyId(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var takeid = db.THELOAISACHes.Where(n=> n.matheloai.Equals(id)).FirstOrDefault();
                if (takeid!=null)
                {
                    return takeid;
                }
                return null;
            }
        }

        public static THELOAISACH GetbyId (string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var takeid = db.THELOAISACHes.Where(n => n.matheloai.Equals(id)).FirstOrDefault();
                if (takeid != null)
                {
                    return takeid;
                }
                return null;
            }
        }

        public static List<THELOAISACH> GetName(string id)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                var takeid = db.THELOAISACHes.Where(n => n.tentheloai.Contains(id)).ToList();
                if (takeid != null)
                {
                    return takeid;
                }
                return null;
            }
        }

        public static THELOAISACH create(THELOAISACH model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.THELOAISACHes.Add(model);
                db.SaveChanges();
                return model;
            }
        }
        public static THELOAISACH update(THELOAISACH model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return model;
            }
        }
        public static THELOAISACH delete(THELOAISACH model)
        {
            using (DOANWEB_INITIALEntities db = new DOANWEB_INITIALEntities())
            {
                //db.NXB.Remove(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return model;
            }
        }
        
    }

}
