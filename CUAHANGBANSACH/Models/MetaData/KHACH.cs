using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(KHACH.MetaData))]
    public partial class KHACH
    {
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã khách không được để trống")]
            public string makhachhang { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tên khách không được để trống")]
            public string tenkhachhang { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin địa chỉ không được để trống")]
            public string diachi { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin số điện thoại không được để trống")]
            public string sdt { get; set; }
            public string avatar { get; set; }
            public string tendangnhap { get; set; }
            public string matkhau { get; set; }
        }
    }
}