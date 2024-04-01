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
        public string confirmPassword { get; set; }
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã khách không được để trống")]
            public string makhachhang { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tên khách không được để trống")]
            public string tenkhachhang { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin địa chỉ không được để trống")]
            public string diachi { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin số điện thoại không được để trống")]
            [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại phải chứa 10 đến 11 chữ số, và không chứa bất kỳ kí tự khác")]
            public string sdt { get; set; }
            [EmailAddress(ErrorMessage = "Phải đúng định dạng email")]
            public string email { get; set; }
            public string avatar { get; set; }
            public string tendangnhap { get; set; }
            [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$",
            ErrorMessage = "Mật khẩu phải chứa từ 8 đến 20 ký tự, ít nhất một chữ hoa, một chữ thường, một ký tự đặc biệt và một chữ số.")]
            public string matkhau { get; set; }
            [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$",
            ErrorMessage = "Mật khẩu phải chứa từ 8 đến 20 ký tự, ít nhất một chữ hoa, một chữ thường, một ký tự đặc biệt và một chữ số.")]
            public string confirmPassword { get; set; }
        }
    }
}