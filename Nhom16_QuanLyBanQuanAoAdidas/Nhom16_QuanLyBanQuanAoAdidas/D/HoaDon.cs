using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            DoiTras = new HashSet<DoiTra>();
        }

        public int MaHd { get; set; }
        public string TenKh { get; set; }
        public string TenNguoiLap { get; set; }
        public DateTime? NgayLap { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual ICollection<DoiTra> DoiTras { get; set; }
    }
}
