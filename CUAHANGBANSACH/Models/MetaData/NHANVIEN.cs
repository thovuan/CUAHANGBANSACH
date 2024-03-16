using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(NHANVIEN.MetaData))]
    public partial class NHANVIEN
    {
        
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin nhân viên không được để trống")]

            public string manhanvien { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tên đăng nhập không được để trống")]

            public string tendangnhap { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tên nhân viên không được để trống")]

            public string tennhanvien { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mật khẩu không được để trống")]

            public string matkhau { get; set; }
        }
    }
}