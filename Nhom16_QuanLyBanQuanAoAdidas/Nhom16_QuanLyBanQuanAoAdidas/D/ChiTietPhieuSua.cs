using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class ChiTietPhieuSua
    {
        public string MaSuaHang { get; set; }
        public string MaSp { get; set; }
        public string TinhTrang { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
        public virtual SuaHang MaSuaHangNavigation { get; set; }
    }
}
