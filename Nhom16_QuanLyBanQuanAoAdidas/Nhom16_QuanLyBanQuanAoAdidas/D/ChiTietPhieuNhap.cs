using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class ChiTietPhieuNhap
    {
        public string MaPn { get; set; }
        public string MaSp { get; set; }
        public int? Slnhap { get; set; }
        public decimal? GiaNhap { get; set; }

        public virtual PhieuNhap MaPnNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
