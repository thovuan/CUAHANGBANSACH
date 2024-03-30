using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.Combined_Model
{
    public partial class NHANVIEN_DANHSACHCHUCVU_MODEL
    {
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual List<CHUCVU> CHUCVU { get; set;}
    }
}