using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.PHIEUMUAHANG_KHACH
{
    public partial class PHIEUMUAHANG_KHACH_MODEL
    {
        public virtual PHIEUMUAHANG PHIEUMUAHANG {get; set;}
        public virtual KHACH KHACH { get; set;}


    }
}