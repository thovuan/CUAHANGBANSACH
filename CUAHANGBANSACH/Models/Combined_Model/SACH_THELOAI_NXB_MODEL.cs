using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.Combined_Model
{
    public partial class SACH_THELOAI_NXB_MODEL
    {
        public virtual SACH SACH { get; set; }
        public virtual List<THELOAISACH> THELOAISACH { get; set; }
        public virtual List<NXB> NXB { get; set; }
    }
}