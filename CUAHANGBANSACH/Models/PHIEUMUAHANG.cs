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
    
    public partial class PHIEUMUAHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUAHANG()
        {
            this.CHITIETDATHANGs = new HashSet<CHITIETDATHANG>();
        }
    
        public string maphieumuahang { get; set; }
        public System.DateTime ngaylap { get; set; }
        public string tinhtrangthanhtoan { get; set; }
        public string tinhtrang { get; set; }
        public string makhachhang { get; set; }
    
        public virtual KHACH KHACH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDATHANG> CHITIETDATHANGs { get; set; }
    }
}
