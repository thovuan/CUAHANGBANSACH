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
    
    public partial class CHITIETCHUCVU
    {
        public string manhanvien { get; set; }
        public string machucvu { get; set; }
        public System.DateTime thoihanhopdong { get; set; }
    
        public virtual CHUCVU CHUCVU { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}