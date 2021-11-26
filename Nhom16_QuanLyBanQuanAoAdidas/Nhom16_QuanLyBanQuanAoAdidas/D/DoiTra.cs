using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class DoiTra
    {
        public string MaDoiTra { get; set; }
        public int? MaHd { get; set; }
        public string MaSp { get; set; }
        public DateTime? NgayDoiHang { get; set; }

        public virtual ChiTietHoaDon Ma { get; set; }
        public virtual HoaDon MaHdNavigation { get; set; }
    }
}
