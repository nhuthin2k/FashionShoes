using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class DoAnContext : DbContext
    {
        public DoAnContext() : base("connectionString")
        {

        }

        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<TinTuc> TinTucs { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }

        public System.Data.Entity.DbSet<DoAnCoThanh.Models.image> images { get; set; }

        
    }
}