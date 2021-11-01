using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        [DisplayName("Mã hóa đơn ")]
        public int MaHoaDon { get; set; }
        [DisplayName("Mã sản phẩm")]
        public string MaSanPham { get; set; }
        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }
        [DisplayName("Đơn giá ")]
        public double DonGia { get; set; }
        [DisplayName("tổng tiền")]

        public double TongTien { get => DonGia * SoLuong; }

        [DisplayName("Nhân viên tư vấn")]
        public string NhanVienTuVan { get; set; }

    }
}