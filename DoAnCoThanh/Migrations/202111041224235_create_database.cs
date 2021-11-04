namespace DoAnCoThanh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_database : DbMigration
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
                "dbo.HangHoas",
                c => new
                    {
                        MaSp = c.Int(nullable: false, identity: true),
                        TenSp = c.String(),
                        NhaCungCap = c.String(maxLength: 20),
                        Gia = c.Int(nullable: false),
                        ChatLieu = c.String(),
                        SoLuong = c.String(),
                        MoTa = c.String(),
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
                        SoDT = c.Int(nullable: false),
                        NgayGiaoDich = c.DateTime(nullable: false),
                        PhuongThucTT = c.Boolean(nullable: false),
                        TrangThai = c.String(),
                        TongTien = c.Int(nullable: false),
                        NhanVienTuVan = c.String(),
                    })
                .PrimaryKey(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        TenKhachHang = c.String(),
                        DiaChi = c.String(),
                        TongTieuDung = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH);
            
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
            DropIndex("dbo.image", new[] { "HangHoa_MaSp" });
            DropTable("dbo.tintuc");
            DropTable("dbo.NhanVien");
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.HoaDons");
            DropTable("dbo.image");
            DropTable("dbo.HangHoas");
            DropTable("dbo.ChiTietHoaDons");
            DropTable("dbo.Accout");
        }
    }
}
