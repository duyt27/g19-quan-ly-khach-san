using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CNPMNC.Models
{
    public class CSDLContext : DbContext
    {
        public CSDLContext()
        {
            SqlConnectionStringBuilder sqlb = new SqlConnectionStringBuilder();
            sqlb.DataSource = "DESKTOP-CJAIL8S\\SQLEXPRESS";
            sqlb.InitialCatalog = "CNPMNC02";
            sqlb.IntegratedSecurity = true;
            this.Database.Connection.ConnectionString = sqlb.ConnectionString;
        }
        public virtual DbSet<DM_Phong> DM_Phongs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<Thue_Phong> Thue_Phongs { get; set; }
        public virtual DbSet<CT_Thue_Phong> CT_Thue_Phongs { get; set; }
        public virtual DbSet<Khach_hang> Khach_Hangs { get; set; }
        public virtual DbSet<CT_Khach_Hang> CT_Khach_Hangs { get; set; }
        public virtual DbSet<Hoa_Don> Hoa_Dons { get; set; }
        public virtual DbSet<CT_Hoa_Don> CT_Hoa_Dons { get; set; }
        public virtual DbSet<Doanh_Thu_Thang> Doanh_Thu_Thangs { get; set; }
        public virtual DbSet<CT_DT_Thang> CT_DT_Thangs { get; set; }

        public System.Data.Entity.DbSet<CNPMNC.Models.User> Users { get; set; }
    }

    public class DM_Phong
    {
        [Key]
        public int LoaiPhongID { get; set; }

        [DisplayName("Loại phòng")]
        [Required(ErrorMessage = "Không được để trống")]
        public string TenLoaiPhong { get; set; }

        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Không được để trống")]
        public double DonGia { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }
    public class Phong
    {
        [Key]
        public int PhongID { get; set; }

        [DisplayName("Tên phòng")]
        [Required(ErrorMessage = "Không được để trống")]
        public string TenPhong { get; set; }

        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [DisplayName("Tình trạng")]
        public string TinhTrang { get; set; }

        

        public Nullable<int> LoaiPhongID { get; set; }
        public virtual DM_Phong DM_Phong { get; set; }

        public virtual ICollection<Thue_Phong> Thue_Phongs { get; set; }
        public virtual ICollection<CT_Hoa_Don> CT_Hoa_Dons { get; set; }
        public virtual ICollection<CT_DT_Thang> CT_DT_Thangs { get; set; }
    }
    public class Thue_Phong
    {
        [Key]
        public int TP_ID { get; set; }

        [DisplayName("Ngày thuê")]
        public DateTime NgayThue { get; set; }
        public Nullable<int> PhongID { get; set; }
        public virtual Phong Phong { get; set; }

        public virtual ICollection<CT_Thue_Phong> CT_Thue_Phongs { get; set; }
    }
    public class CT_Thue_Phong
    {
        [Key]
        public int CT_TP_ID { get; set; }
        public Nullable<int> TP_ID { get; set; }
        public virtual Thue_Phong Thue_Phong { get; set; }
        public Nullable<int> KhachID { get; set; }
        public virtual Khach_hang Khach_Hang { get; set; }
    }
    public class Khach_hang
    {
        [Key]
        public int LoaiKhachID { get; set; }

        [DisplayName("Loại khách")]
        [Required(ErrorMessage = "Không được để trống")]
        public string LoaiKhach { get; set; }

        public virtual ICollection<CT_Thue_Phong> CT_Thue_Phongs { get; set; }
        public virtual ICollection<CT_Khach_Hang> CT_Khach_Hangs { get; set; }
    }
    public class CT_Khach_Hang
    {
        [Key]
        public int KhachID { get; set; }

        [DisplayName("Tên khách")]
        [Required(ErrorMessage = "Không được để trống")]
        public string TenKhach { get; set; }

        [DisplayName("CMND")]
        [Required(ErrorMessage = "Không được để trống")]
        public string CMND { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Không được để trống")]
        public string DiaChi { get; set; }
        public Nullable<int> LoaiKhachID { get; set; }
        public virtual Khach_hang Khach_Hang { get; set; }

        public virtual ICollection<Hoa_Don> Hoa_Dons { get; set; }
    }
    public class Hoa_Don
    {
        [Key]
        public int HoaDonID{ get; set; }

        [DisplayName("Trị giá")]
        [Required(ErrorMessage = "Không được để trống")]
        public double TriGia { get; set; }
        public Nullable<int> KhachID { get; set; }
        public virtual CT_Khach_Hang CT_Khach_Hang { get; set; }

        public virtual ICollection<CT_Hoa_Don> CT_Hoa_Dons { get; set; }
    }
    public class CT_Hoa_Don
    {
        [Key]
        public int CTHD_ID { get; set; }

        [DisplayName("Số ngày thuê")]
        [Required(ErrorMessage = "Không được để trống")]
        public int SoNgayThue { get; set; }

        [DisplayName("Thành tiền")]
        [Required(ErrorMessage = "Không được để trống")]
        public double ThanhTien { get; set; }
        public Nullable<int> HoaDonID { get; set; }
        public virtual Hoa_Don Hoa_Don { get; set; }
        public Nullable<int> PhongID { get; set; }
        public virtual Phong Phong { get; set; }
    }
    public class Doanh_Thu_Thang
    {
        [Key]
        public int ThangID { get; set; }

        [DisplayName("Tháng")]
        [Required(ErrorMessage = "Không được để trống")]
        public string Thang { get; set; }

        public virtual ICollection<CT_DT_Thang> CT_DT_Thangs { get; set; }
    }
    public class CT_DT_Thang
    {
        [Key]
        public int CT_DTT_ID { get; set; }

        [DisplayName("Doanh thu")]
        [Required(ErrorMessage = "Không được để trống")]
        public double DoanhThu { get; set; }

        [DisplayName("Tỷ lệ")]
        [Required(ErrorMessage = "Không được để trống")]
        public double TyLe { get; set; }
        public Nullable<int> ThangID { get; set; }
        public virtual Doanh_Thu_Thang Doanh_Thu_Thang { get; set; }
        public Nullable<int> PhongID { get; set; }
        public virtual Phong Phong { get; set; }
    }
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Không được để trống")]
        public string Username { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Không được để trống")]
        public string Password { get; set; }

        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Không được để trống")]
        public string Hoten { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng định dạng email")]
        public string Email { get; set; }
    }
}