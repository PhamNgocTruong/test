using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class ChiTietDatHangNhaCc
    {
        public string MaDatHang { get; set; }
        public string MaSp { get; set; }
        public int? Sldat { get; set; }
        public int? SldatCon { get; set; }
        public decimal? GiaDat { get; set; }

        public virtual DatHangNhaCc MaDatHangNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
