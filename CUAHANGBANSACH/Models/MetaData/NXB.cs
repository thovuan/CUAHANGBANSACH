using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(NXB.MetaData))]
    public  partial class NXB
    {
        public int Count;
        sealed class  MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã nhà xuất bản không được để trống")]
            public string manxb { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tên nhà xuất bản không được để trống")]
            public string tennxb { get; set; }
        }
    }
}