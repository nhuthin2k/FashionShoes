using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [DisplayName("Mã nhân viên")]
        public int MaNhanVien { get; set; }
        [DisplayName("Tên nhân viên ")]
        public string TenNhanVien { get; set; }
        [DisplayName("giới tính")]
        public bool GioiTinh { get; set; }
        [DisplayName("Chức Vụ")]
        public string ChucVu { get; set; }
        [DisplayName("Tuổi")]
        public string Tuoi { get; set; }
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Số điện thoại")]
        public int SoDT { get; set; }
    }
}