using System;
using System.Collections.Generic;

#nullable disable

namespace Nhom16_QuanLyBanQuanAoAdidas.D
{
    public partial class NhaCc
    {
        public NhaCc()
        {
            DatHangNhaCcs = new HashSet<DatHangNhaCc>();
            PhieuNhaps = new HashSet<PhieuNhap>();
        }

        public string MaNcc { get; set; }
        public string TenNcc { get; set; }
        public string SoDt { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string NguoiLienHe { get; set; }

        public virtual ICollection<DatHangNhaCc> DatHangNhaCcs { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}
