namespace DataLibrary.Models.NewFolder1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=QLBiaDB")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<tbl_ChiTietDonDatHang> tbl_ChiTietDonDatHang { get; set; }
        public virtual DbSet<tbl_ChiTietGioHang> tbl_ChiTietGioHang { get; set; }
        public virtual DbSet<tbl_DiaChi> tbl_DiaChi { get; set; }
        public virtual DbSet<tbl_DiaChiNhanHang> tbl_DiaChiNhanHang { get; set; }
        public virtual DbSet<tbl_DonDatHang> tbl_DonDatHang { get; set; }
        public virtual DbSet<tbl_GioHang> tbl_GioHang { get; set; }
        public virtual DbSet<tbl_Images> tbl_Images { get; set; }
        public virtual DbSet<tbl_KhachHang> tbl_KhachHang { get; set; }
        public virtual DbSet<tbl_KhuyenMai> tbl_KhuyenMai { get; set; }
        public virtual DbSet<tbl_LienHe> tbl_LienHe { get; set; }
        public virtual DbSet<tbl_LoaiSP> tbl_LoaiSP { get; set; }
        public virtual DbSet<tbl_SanPham> tbl_SanPham { get; set; }
        public virtual DbSet<tbl_TinTuc> tbl_TinTuc { get; set; }
        public virtual DbSet<tbl_Users> tbl_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
