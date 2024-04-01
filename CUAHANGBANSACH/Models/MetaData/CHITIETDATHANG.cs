using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(CHITIETDATHANG.MetaData))]
    public partial class CHITIETDATHANG
    {
        
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin này không được để trống")]

            public string maphieumuahang { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin này không được để trống")]

            public string masach { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin SLmua không được để trống")]

            public int soluongmua { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tình trạng giao không được để trống")]

            public string tinhtranggiao { get; set; }
        }
    }
}