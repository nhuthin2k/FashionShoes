namespace DoAnCoThanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accout",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        PassWord = c.String(nullable: false, maxLength: 20),
                        RoleID = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
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
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        MaSp = c.Int(nullable: false, identity: true),
                        MaGiohang = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        Gia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSp)
                .ForeignKey("dbo.ChiTietGioHangs", t => t.MaGiohang, cascadeDelete: true)
                .Index(t => t.MaGiohang);
            
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
                "dbo.KhachHangs",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        TenKhachHang = c.String(),
                        DiaChi = c.String(),
                        TongTieuDung = c.Int(nullable: false),
                        GioHang_MaSp = c.Int(),
                        ChiTietGioHang_MaGioHang = c.Int(),
                    })
                .PrimaryKey(t => t.MaKH)
                .ForeignKey("dbo.GioHangs", t => t.GioHang_MaSp)
                .ForeignKey("dbo.ChiTietGioHangs", t => t.ChiTietGioHang_MaGioHang)
                .Index(t => t.GioHang_MaSp)
                .Index(t => t.ChiTietGioHang_MaGioHang);
            
            CreateTable(
                "dbo.HangHoas",
                c => new
                    {
                        MaSp = c.Int(nullable: false, identity: true),
                        TenSp = c.String(),
                        NhaCungCap = c.String(maxLength: 20),
                        Gia = c.Int(nullable: false),
                        GiaCu = c.Int(nullable: false),
                        KM = c.Single(nullable: false),
                        LoaiGiay = c.String(),
                        KieuDang = c.String(),
                        KieuLot = c.String(),
                        KieuDe = c.String(),
                        DoCao = c.String(),
                        CoGiay = c.String(),
                        ChatLieu = c.String(),
                        SoLuong = c.String(),
                        Size = c.String(),
                        HinhAnh = c.String(),
                    })
                .PrimaryKey(t => t.MaSp);
            
            CreateTable(
                "dbo.image",
                c => new
                    {
                        maSP = c.Int(nullable: false, identity: true),
                        TenAnh = c.String(),
                        HangHoa_MaSp = c.Int(),
                    })
                .PrimaryKey(t => t.maSP)
                .ForeignKey("dbo.HangHoas", t => t.HangHoa_MaSp)
                .Index(t => t.HangHoa_MaSp);
            
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
                "dbo.NhaCungCaps",
                c => new
                    {
                        MaNhaCungCap = c.Int(nullable: false, identity: true),
                        TenNhaCungCap = c.String(),
                        DiaChi = c.String(),
                        SoDT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNhaCungCap);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNhanVien = c.Int(nullable: false, identity: true),
                        TenNhanVien = c.String(),
                        GioiTinh = c.Boolean(nullable: false),
                        ChucVu = c.String(),
                        Tuoi = c.String(),
                        DiaChi = c.String(),
                        SoDT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.tintuc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaTinTuc = c.Int(nullable: false),
                        TenTinTuc = c.String(),
                        NoiDung = c.String(),
                        NgayDang = c.DateTime(nullable: false),
                        HinhAnh = c.String(),
                        NguoiDang = c.String(),
                        Content = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreationUser = c.Int(),
                        ModifierTime = c.DateTime(),
                        ModifierUser = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.image", "HangHoa_MaSp", "dbo.HangHoas");
            DropForeignKey("dbo.KhachHangs", "ChiTietGioHang_MaGioHang", "dbo.ChiTietGioHangs");
            DropForeignKey("dbo.KhachHangs", "GioHang_MaSp", "dbo.GioHangs");
            DropForeignKey("dbo.GioHangs", "MaGiohang", "dbo.ChiTietGioHangs");
            DropIndex("dbo.image", new[] { "HangHoa_MaSp" });
            DropIndex("dbo.KhachHangs", new[] { "ChiTietGioHang_MaGioHang" });
            DropIndex("dbo.KhachHangs", new[] { "GioHang_MaSp" });
            DropIndex("dbo.GioHangs", new[] { "MaGiohang" });
            DropTable("dbo.tintuc");
            DropTable("dbo.NhanVien");
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.HoaDons");
            DropTable("dbo.image");
            DropTable("dbo.HangHoas");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.ChiTietGioHangs");
            DropTable("dbo.GioHangs");
            DropTable("dbo.ChiTietHoaDons");
            DropTable("dbo.Accout");
        }
    }
}
