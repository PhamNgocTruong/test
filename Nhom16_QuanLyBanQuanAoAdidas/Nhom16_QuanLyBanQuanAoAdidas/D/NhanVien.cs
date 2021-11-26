using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class NhanVien
    {
        public int MaNv { get; set; }
        public string TenNv { get; set; }
        public string SoDt { get; set; }
        public string DiaChi { get; set; }
        public decimal? LuongCb { get; set; }
        public string SoCmt { get; set; }
        public string ChucVu { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
