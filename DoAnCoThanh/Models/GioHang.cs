using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
  
    [Serializable]
    public class GioHang
    {
        [Key]
        public int MaSp { get; set; }
        public int MaGiohang { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public virtual ChiTietGioHang ChiTietGioHang { get; set; }
    }
}