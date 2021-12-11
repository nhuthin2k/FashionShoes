using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class HoaDon
    {
        [Key]
        [DisplayName("Mã hóa đơn ")]
        public int MaHoaDon { get; set; }
        [DisplayName("Mã Khách Hàng")]
        public int MaKH { get; set; }
        [DisplayName("Tên khách hàng")]
        public string TenKhachHang { get; set; }
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Số điện thoại")]
        public int SDT { get; set; }
        [DisplayName("Ngày giao dịch")]
        public DateTime NgayGiaoDich { get; set; }
        [DisplayName("Phương thức thanh toán")]
        public bool PhuongThucTT { get; set; }
        [DisplayName("Trạng thái")]
        public string TrangThai { get; set; }
        [DisplayName("Tổng Tiền")]
        public int TongTien { get; set; }
        [DisplayName("Nhân viên tư vấn")]
        public string NhanVienTuVan { get; set; }
    }
}