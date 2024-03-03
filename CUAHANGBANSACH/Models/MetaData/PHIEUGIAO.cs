using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(PHIEUGIAO.MetaData))]
    public partial class PHIEUGIAO
    {
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã phiếu giao không được để trống")]

            public string maphieugiao { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin ngày lập không được để trống")]

            public System.DateTime ngaylap { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin số lượng giao không được để trống")]

            public int soluonggiao { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin ngày giao dự kiến không được để trống")]

            public System.DateTime ngaygiaodukien { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tình trạng giao không được để trống")]

            public string tinhtranggiao { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin này không được để trống")]

            public string maphieumuahang { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin này không được để trống")]

            public string masach { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin này không được để trống")]

            public string manhanvien { get; set; }
        }
    }
}