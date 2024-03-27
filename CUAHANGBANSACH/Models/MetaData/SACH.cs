using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(SACH.MetaData))]
    public partial class SACH
    {
        public string tentheloai;
        public string tennxb;
        public string tennhanvien;
        
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã sách không được để trống")]
            public string masach { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tên sách không được để trống")]
            public string tensach { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin số lượng hiện có không được để trống")]
            public int soluonghienco { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin SLmua không được để trống")]

            public int soluongmua { get; set; }
            public string dacdiem { get; set; }
            public string anhsanpham { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin DVT không được để trống")]
            public string DVT { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin Đơn giá không được để trống")]
            public decimal dongia { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã thể loại không được để trống")]
            public string matheloai { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã nhân viên không được để trống")]
            public string manhanvien { get; set; }
        }
    }
}