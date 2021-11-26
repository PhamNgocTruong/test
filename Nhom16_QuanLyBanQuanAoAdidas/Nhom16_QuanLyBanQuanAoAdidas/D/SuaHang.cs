using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class SuaHang
    {
        public SuaHang()
        {
            ChiTietPhieuSuas = new HashSet<ChiTietPhieuSua>();
        }

        public string MaSuaHang { get; set; }
        public string MaSp { get; set; }
        public string TenKh { get; set; }
        public string SoDt { get; set; }
        public string DiaChi { get; set; }
        public string TinhTrang { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayTra { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
        public virtual ICollection<ChiTietPhieuSua> ChiTietPhieuSuas { get; set; }
    }
}
