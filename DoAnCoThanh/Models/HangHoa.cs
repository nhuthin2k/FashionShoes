using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class HangHoa
    {
        [DisplayName("Tên sản phẩm")]
        public string TenSp { get; set; }
        [Key] 
        [DisplayName("Mã sản phẩm")]
        public int MaSp { get; set; }
        [StringLength(20)]
        [DisplayName("mã nhà cung cấp")]
        public string NhaCungCap { get; set; }
        [DisplayName("Giá ")]
        public int Gia { get; set; }
        [DisplayName("Chất liệu")]
        public string ChatLieu { get; set; }
        [DisplayName("Số lượng")]
        public string SoLuong { get; set; }
        
    }
}