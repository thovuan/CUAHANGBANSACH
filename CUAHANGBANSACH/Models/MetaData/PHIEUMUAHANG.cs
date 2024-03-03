using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(PHIEUMUAHANG.MetaData))]
    public partial class PHIEUMUAHANG
    {
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã phiếu mua hàng không được để trống")]

            public string maphieumuahang { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin ngày lập phiếu không được để trống")]

            public System.DateTime ngaylap { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tình trạng thanh toán không được để trống")]

            public string tinhtrangthanhtoan { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tình trạng không được để trống")]

            public string tinhtrang { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin Mã khách hàng không được để trống")]

            public string makhachhang { get; set; }
        }
    }
}