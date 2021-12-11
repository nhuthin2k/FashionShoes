using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnCoThanh.Models
{
    [Table("tintuc")]
    public class TinTuc : BaseModel
    {
      
        [DisplayName("Mã tin tức")]
        public int MaTinTuc { get; set; }
        [DisplayName(" Tên tin tức")]
        public string TenTinTuc { get; set; }
        [DisplayName("Nội dung")]
        [AllowHtml]     
        public string NoiDung { get; set; }
        [DisplayName("Ngày đăng")]
        public DateTime NgayDang { get; set; }
        public string HinhAnh { get; set; }
        public string NguoiDang { get; set; }
        public string Content { get; set; }



    }
}