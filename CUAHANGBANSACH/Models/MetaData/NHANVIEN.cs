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
        public List<CHUCVU> chucvu;
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin nhân viên không được để trống")]

            public string manhanvien { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tên đăng nhập không được để trống")]

            public string tendangnhap { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tên nhân viên không được để trống")]

            public string tennhanvien { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mật khẩu không được để trống")]
            [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$",
            ErrorMessage = "Mật khẩu phải chứa từ 8 đến 20 ký tự, ít nhất một chữ hoa, một chữ thường, một ký tự đặc biệt và một chữ số.")]
            public string matkhau { get; set; }
        }
    }
}