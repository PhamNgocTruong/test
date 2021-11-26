using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietDatHangNhaCcs = new HashSet<ChiTietDatHangNhaCc>();
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
            ChiTietPhieuSuas = new HashSet<ChiTietPhieuSua>();
            SuaHangs = new HashSet<SuaHang>();
        }

        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public decimal? GiaBan { get; set; }
        public string Size { get; set; }
        public string Mau { get; set; }
        public int? Slcon { get; set; }
        public int? MaLoai { get; set; }

        public virtual LoaiSp MaLoaiNavigation { get; set; }
        public virtual ICollection<ChiTietDatHangNhaCc> ChiTietDatHangNhaCcs { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual ICollection<ChiTietPhieuSua> ChiTietPhieuSuas { get; set; }
        public virtual ICollection<SuaHang> SuaHangs { get; set; }
    }
}
