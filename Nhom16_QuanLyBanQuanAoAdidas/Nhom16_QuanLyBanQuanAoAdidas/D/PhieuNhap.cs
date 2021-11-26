using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class PhieuNhap
    {
        public PhieuNhap()
        {
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        public string MaPn { get; set; }
        public string MaDatHang { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public string NguoiGiaoHang { get; set; }
        public string DiaDiemNhap { get; set; }
        public string MaNcc { get; set; }

        public virtual DatHangNhaCc MaDatHangNavigation { get; set; }
        public virtual NhaCc MaNccNavigation { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
