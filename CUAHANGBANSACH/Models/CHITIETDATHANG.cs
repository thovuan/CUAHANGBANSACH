//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CUAHANGBANSACH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHITIETDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHITIETDATHANG()
        {
            this.PHIEUGIAOs = new HashSet<PHIEUGIAO>();
        }
    
        public string maphieumuahang { get; set; }
        public string masach { get; set; }
        public int soluongmua { get; set; }
        public string tinhtranggiao { get; set; }
    
        public virtual PHIEUMUAHANG PHIEUMUAHANG { get; set; }
        public virtual SACH SACH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUGIAO> PHIEUGIAOs { get; set; }
    }
}