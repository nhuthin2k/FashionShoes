using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class ChiTietGioHang
    {
        [Key]
        public int MaGioHang { get; set; }
        public int MaKH { get; set; }
        public string HinhAnh { get; set; }

        public string   DiaChi { get; set; }
        public string   email { get; set; }
        [StringLength(11)]
        public string   SDT { get; set; }
        public string   TrangThai { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime  NgayCapNhat { get; set; }

        public ICollection<KhachHang> KhachHangs { get; set; }
        public ICollection<GioHang> GioHangs { get; set; }

    }
}