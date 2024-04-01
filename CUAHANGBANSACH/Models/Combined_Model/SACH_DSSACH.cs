using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models.Combined_Model
{
    public partial class SACH_DSSACH
    {
        public virtual SACH SACH { get; set; }
        public virtual List<SACH> SACHes { get; set; }
    }
}