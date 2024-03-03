using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUAHANGBANSACH.Models
{
    [MetadataType(typeof(CHUCVU.MetaData))]
    public partial class CHUCVU
    {
        sealed class MetaData
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin mã chức vụ không được để trống")]

            public string machucvu { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Trường thông tin tên chức vụ không được để trống")]

            public string tenchucvu { get; set; }
            public string tinhtrang { get; set; }
        }
    }
}