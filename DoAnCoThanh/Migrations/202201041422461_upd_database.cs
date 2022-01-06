namespace DoAnCoThanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd_database : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GioHangs", "MaGiohang", "dbo.ChiTietGioHangs");
            DropForeignKey("dbo.KhachHangs", "GioHang_MaSp", "dbo.GioHangs");
            DropForeignKey("dbo.KhachHangs", "ChiTietGioHang_MaGioHang", "dbo.ChiTietGioHangs");
            DropIndex("dbo.GioHangs", new[] { "MaGiohang" });
            DropIndex("dbo.KhachHangs", new[] { "GioHang_MaSp" });
            DropIndex("dbo.KhachHangs", new[] { "ChiTietGioHang_MaGioHang" });
            CreateTable(
                "dbo.ChiTietDonHangs",
                c => new
                    {
                        MaChiTiet = c.String(nullable: false, maxLength: 128),
                        quantity = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        DonHang_MaHoaDon = c.Int(),
                        HangHoa_MaSp = c.Int(),
                    })
                .PrimaryKey(t => t.MaChiTiet)
                .ForeignKey("dbo.DonHang", t => t.DonHang_MaHoaDon)
                .ForeignKey("dbo.HangHoas", t => t.HangHoa_MaSp)
                .Index(t => t.DonHang_MaHoaDon)
                .Index(t => t.HangHoa_MaSp);
            
            CreateTable(
                "dbo.DonHang",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        DiaChi = c.String(),
                        SDT = c.Int(nullable: false),
                        NgayGiaoDich = c.DateTime(nullable: false),
                        PhuongThucTT = c.Boolean(nullable: false),
                        TrangThai = c.String(),
                        TongTien = c.Int(nullable: false),
                        khachHangs_MaKH = c.Int(),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.KhachHangs", t => t.khachHangs_MaKH)
                .Index(t => t.khachHangs_MaKH);
            
            DropColumn("dbo.KhachHangs", "GioHang_MaSp");
            DropColumn("dbo.KhachHangs", "ChiTietGioHang_MaGioHang");
            DropTable("dbo.ChiTietHoaDons");
            DropTable("dbo.GioHangs");
            DropTable("dbo.ChiTietGioHangs");
            DropTable("dbo.HoaDons");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        MaKH = c.Int(nullable: false),
                        TenKhachHang = c.String(),
                        DiaChi = c.String(),
                        SDT = c.Int(nullable: false),
                        NgayGiaoDich = c.DateTime(nullable: false),
                        PhuongThucTT = c.Boolean(nullable: false),
                        TrangThai = c.String(),
                        TongTien = c.Int(nullable: false),
                        NhanVienTuVan = c.String(),
                    })
                .PrimaryKey(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.ChiTietGioHangs",
                c => new
                    {
                        MaGioHang = c.Int(nullable: false, identity: true),
                        MaKH = c.Int(nullable: false),
                        HinhAnh = c.String(),
                        DiaChi = c.String(),
                        email = c.String(),
                        SDT = c.String(maxLength: 11),
                        TrangThai = c.String(),
                        MoTa = c.String(),
                        NgayTao = c.DateTime(nullable: false),
                        NgayCapNhat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaGioHang);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        MaSp = c.Int(nullable: false, identity: true),
                        MaGiohang = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        Gia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSp);
            
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        MaSanPham = c.String(),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Double(nullable: false),
                        NhanVienTuVan = c.String(),
                    })
                .PrimaryKey(t => t.MaHoaDon);
            
            AddColumn("dbo.KhachHangs", "ChiTietGioHang_MaGioHang", c => c.Int());
            AddColumn("dbo.KhachHangs", "GioHang_MaSp", c => c.Int());
            DropForeignKey("dbo.ChiTietDonHangs", "HangHoa_MaSp", "dbo.HangHoas");
            DropForeignKey("dbo.ChiTietDonHangs", "DonHang_MaHoaDon", "dbo.DonHang");
            DropForeignKey("dbo.DonHang", "khachHangs_MaKH", "dbo.KhachHangs");
            DropIndex("dbo.DonHang", new[] { "khachHangs_MaKH" });
            DropIndex("dbo.ChiTietDonHangs", new[] { "HangHoa_MaSp" });
            DropIndex("dbo.ChiTietDonHangs", new[] { "DonHang_MaHoaDon" });
            DropTable("dbo.DonHang");
            DropTable("dbo.ChiTietDonHangs");
            CreateIndex("dbo.KhachHangs", "ChiTietGioHang_MaGioHang");
            CreateIndex("dbo.KhachHangs", "GioHang_MaSp");
            CreateIndex("dbo.GioHangs", "MaGiohang");
            AddForeignKey("dbo.KhachHangs", "ChiTietGioHang_MaGioHang", "dbo.ChiTietGioHangs", "MaGioHang");
            AddForeignKey("dbo.KhachHangs", "GioHang_MaSp", "dbo.GioHangs", "MaSp");
            AddForeignKey("dbo.GioHangs", "MaGiohang", "dbo.ChiTietGioHangs", "MaGioHang", cascadeDelete: true);
        }
    }
}
