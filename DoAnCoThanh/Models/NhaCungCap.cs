using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class NhaCungCap
    {
        [Key]
        [DisplayName("Mã nhà cung cấp")]
        public int MaNhaCungCap { get; set; }
        [DisplayName("nhà cung cấp")]
        public string TenNhaCungCap { get; set; }
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Số điện thoại")]
        public int SoDT { get; set; }
    }
}