using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class KhachHang
    {
        [Key]
        [DisplayName("Mã khách  hàng")]
        public int MaKH { get; set; }
        [DisplayName("Tên khách hàng")]
        public string TenKhachHang { get; set; }
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Tổng tiêu dùng")]
        public int TongTieuDung { get; set; }
    }
}