using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class ChiTietDonHang
    {
        [Key]
        [DisplayName("Chi Tiết")]
        public string MaChiTiet { get; set; }
        [DisplayName("Mã hóa đơn ")]
        public int quantity { get; set; }

        [DisplayName("GiaSP")]
        public int price { get; set; }

        public virtual HangHoa HangHoa { get; set; }
        public virtual DonHang DonHang { get; set; }

    }
}