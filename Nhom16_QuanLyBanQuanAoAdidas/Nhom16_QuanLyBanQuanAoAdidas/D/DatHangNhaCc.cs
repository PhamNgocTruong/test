using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class DatHangNhaCc
    {
        public DatHangNhaCc()
        {
            ChiTietDatHangNhaCcs = new HashSet<ChiTietDatHangNhaCc>();
            PhieuNhaps = new HashSet<PhieuNhap>();
        }

        public string MaDatHang { get; set; }
        public string MaNcc { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayGiao { get; set; }
        public string NguoiLap { get; set; }
        public decimal? TongTien { get; set; }

        public virtual NhaCc MaNccNavigation { get; set; }
        public virtual ICollection<ChiTietDatHangNhaCc> ChiTietDatHangNhaCcs { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}
