using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(CHITIETCHUCVU.MetaData))]
    public partial class CHITIETCHUCVU
    {
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin này không được để trống")]

            public string manhanvien { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin này không được để trống")]

            public string machucvu { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin TTHD không được để trống")]
            public System.DateTime thoihanhopdong { get; set; }
        }
    }
}