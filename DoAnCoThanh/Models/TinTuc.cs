using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    [Table("tintuc")]
    public class TinTuc : BaseModel
    {
        [DisplayName("Mã tin tức")]
        public string MaTinTuc { get; set; }
        [DisplayName(" Tên tin tức")]
        public string TenTinTuc { get; set; }
        [DisplayName("Nội dung")]
        public string NoiDung { get; set; }
        [DisplayName("Ngày đăng")]
        public DateTime NgayDang { get; set; }



    }
}