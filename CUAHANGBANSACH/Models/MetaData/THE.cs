using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(THE.MetaData))]
    public partial class THE
    {
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã thẻ không được để trống")]
            public string mathe { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin điểm thẻ không được để trống")]
            public int diemthe { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã khách hàng không được để trống")]
            public string makhachhang { get; set; }
        }
    }
}