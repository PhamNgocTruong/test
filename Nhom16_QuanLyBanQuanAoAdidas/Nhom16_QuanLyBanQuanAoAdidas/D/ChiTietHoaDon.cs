using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class ChiTietHoaDon
    {
        public ChiTietHoaDon()
        {
            DoiTras = new HashSet<DoiTra>();
        }

        public int MaHd { get; set; }
        public string MaSp { get; set; }
        public int? Slmua { get; set; }
        public decimal? Gia { get; set; }

        public virtual HoaDon MaHdNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
        public virtual ICollection<DoiTra> DoiTras { get; set; }
    }
}
