using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class TaiKhoan
    {
        public int MaNv { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string LoaiTaiKhoan { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
    }
}
