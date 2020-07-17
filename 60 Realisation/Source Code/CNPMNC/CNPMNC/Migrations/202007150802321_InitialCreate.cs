namespace CNPMNC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CT_DT_Thang",
                c => new
                    {
                        CT_DTT_ID = c.Int(nullable: false, identity: true),
                        DoanhThu = c.Double(nullable: false),
                        TyLe = c.Double(nullable: false),
                        ThangID = c.Int(),
                        PhongID = c.Int(),
                    })
                .PrimaryKey(t => t.CT_DTT_ID)
                .ForeignKey("dbo.Doanh_Thu_Thang", t => t.ThangID)
                .ForeignKey("dbo.Phongs", t => t.PhongID)
                .Index(t => t.ThangID)
                .Index(t => t.PhongID);
            
            CreateTable(
                "dbo.Doanh_Thu_Thang",
                c => new
                    {
                        ThangID = c.Int(nullable: false, identity: true),
                        Thang = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ThangID);
            
            CreateTable(
                "dbo.Phongs",
                c => new
                    {
                        PhongID = c.Int(nullable: false, identity: true),
                        TenPhong = c.String(nullable: false),
                        GhiChu = c.String(),
                        TinhTrang = c.String(nullable: false),
                        LoaiPhongID = c.Int(),
                    })
                .PrimaryKey(t => t.PhongID)
                .ForeignKey("dbo.DM_Phong", t => t.LoaiPhongID)
                .Index(t => t.LoaiPhongID);
            
            CreateTable(
                "dbo.CT_Hoa_Don",
                c => new
                    {
                        CTHD_ID = c.Int(nullable: false, identity: true),
                        SoNgayThue = c.Int(nullable: false),
                        ThanhTien = c.Double(nullable: false),
                        HoaDonID = c.Int(),
                        PhongID = c.Int(),
                    })
                .PrimaryKey(t => t.CTHD_ID)
                .ForeignKey("dbo.Hoa_Don", t => t.HoaDonID)
                .ForeignKey("dbo.Phongs", t => t.PhongID)
                .Index(t => t.HoaDonID)
                .Index(t => t.PhongID);
            
            CreateTable(
                "dbo.Hoa_Don",
                c => new
                    {
                        HoaDonID = c.Int(nullable: false, identity: true),
                        TriGia = c.Double(nullable: false),
                        KhachID = c.Int(),
                    })
                .PrimaryKey(t => t.HoaDonID)
                .ForeignKey("dbo.CT_Khach_Hang", t => t.KhachID)
                .Index(t => t.KhachID);
            
            CreateTable(
                "dbo.CT_Khach_Hang",
                c => new
                    {
                        KhachID = c.Int(nullable: false, identity: true),
                        TenKhach = c.String(nullable: false),
                        CMND = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        LoaiKhachID = c.Int(),
                    })
                .PrimaryKey(t => t.KhachID)
                .ForeignKey("dbo.Khach_hang", t => t.LoaiKhachID)
                .Index(t => t.LoaiKhachID);
            
            CreateTable(
                "dbo.Khach_hang",
                c => new
                    {
                        LoaiKhachID = c.Int(nullable: false, identity: true),
                        LoaiKhach = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LoaiKhachID);
            
            CreateTable(
                "dbo.CT_Thue_Phong",
                c => new
                    {
                        CT_TP_ID = c.Int(nullable: false, identity: true),
                        TP_ID = c.Int(),
                        KhachID = c.Int(),
                        Khach_Hang_LoaiKhachID = c.Int(),
                    })
                .PrimaryKey(t => t.CT_TP_ID)
                .ForeignKey("dbo.Khach_hang", t => t.Khach_Hang_LoaiKhachID)
                .ForeignKey("dbo.Thue_Phong", t => t.TP_ID)
                .Index(t => t.TP_ID)
                .Index(t => t.Khach_Hang_LoaiKhachID);
            
            CreateTable(
                "dbo.Thue_Phong",
                c => new
                    {
                        TP_ID = c.Int(nullable: false, identity: true),
                        NgayThue = c.DateTime(nullable: false),
                        PhongID = c.Int(),
                    })
                .PrimaryKey(t => t.TP_ID)
                .ForeignKey("dbo.Phongs", t => t.PhongID)
                .Index(t => t.PhongID);
            
            CreateTable(
                "dbo.DM_Phong",
                c => new
                    {
                        LoaiPhongID = c.Int(nullable: false, identity: true),
                        TenLoaiPhong = c.String(nullable: false),
                        DonGia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LoaiPhongID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Hoten = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phongs", "LoaiPhongID", "dbo.DM_Phong");
            DropForeignKey("dbo.CT_Hoa_Don", "PhongID", "dbo.Phongs");
            DropForeignKey("dbo.Thue_Phong", "PhongID", "dbo.Phongs");
            DropForeignKey("dbo.CT_Thue_Phong", "TP_ID", "dbo.Thue_Phong");
            DropForeignKey("dbo.CT_Thue_Phong", "Khach_Hang_LoaiKhachID", "dbo.Khach_hang");
            DropForeignKey("dbo.CT_Khach_Hang", "LoaiKhachID", "dbo.Khach_hang");
            DropForeignKey("dbo.Hoa_Don", "KhachID", "dbo.CT_Khach_Hang");
            DropForeignKey("dbo.CT_Hoa_Don", "HoaDonID", "dbo.Hoa_Don");
            DropForeignKey("dbo.CT_DT_Thang", "PhongID", "dbo.Phongs");
            DropForeignKey("dbo.CT_DT_Thang", "ThangID", "dbo.Doanh_Thu_Thang");
            DropIndex("dbo.Thue_Phong", new[] { "PhongID" });
            DropIndex("dbo.CT_Thue_Phong", new[] { "Khach_Hang_LoaiKhachID" });
            DropIndex("dbo.CT_Thue_Phong", new[] { "TP_ID" });
            DropIndex("dbo.CT_Khach_Hang", new[] { "LoaiKhachID" });
            DropIndex("dbo.Hoa_Don", new[] { "KhachID" });
            DropIndex("dbo.CT_Hoa_Don", new[] { "PhongID" });
            DropIndex("dbo.CT_Hoa_Don", new[] { "HoaDonID" });
            DropIndex("dbo.Phongs", new[] { "LoaiPhongID" });
            DropIndex("dbo.CT_DT_Thang", new[] { "PhongID" });
            DropIndex("dbo.CT_DT_Thang", new[] { "ThangID" });
            DropTable("dbo.Users");
            DropTable("dbo.DM_Phong");
            DropTable("dbo.Thue_Phong");
            DropTable("dbo.CT_Thue_Phong");
            DropTable("dbo.Khach_hang");
            DropTable("dbo.CT_Khach_Hang");
            DropTable("dbo.Hoa_Don");
            DropTable("dbo.CT_Hoa_Don");
            DropTable("dbo.Phongs");
            DropTable("dbo.Doanh_Thu_Thang");
            DropTable("dbo.CT_DT_Thang");
        }
    }
}
