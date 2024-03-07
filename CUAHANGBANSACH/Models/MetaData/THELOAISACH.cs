using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(THELOAISACH.MetaData))]
    public partial class THELOAISACH
    {
        public int Count;
        sealed class MetaData
        {
            
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã thể loại này không được để trống")]
            public string matheloai { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tên thể loại không được để trống")]
            public string tentheloai { get; set; }
        }
    }
}