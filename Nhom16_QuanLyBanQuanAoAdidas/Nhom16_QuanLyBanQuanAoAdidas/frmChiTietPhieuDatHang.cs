using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nhom16_QuanLyBanQuanAoAdidas.D;
using System.Linq;

namespace Nhom16_QuanLyBanQuanAoAdidas
{
    public partial class frmChiTietPhieuDatHang : Form
    {
        public frmChiTietPhieuDatHang()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void ChiTietPhieuDatHang_Load(object sender, EventArgs e)
        {
            string MaDH = (string)this.Tag;
            txtMaDH.Text = MaDH;
            DatHangNhaCc dh = db.DatHangNhaCcs.Where(p => p.MaDatHang == MaDH).SingleOrDefault();
            txtNguoiLap.Text = dh.NguoiLap;

            dtpNgaylap.Value = (DateTime)dh.NgayLap;

            var nhaCC = (from n in db.NhaCcs
                         where n.MaNcc == dh.MaNcc
                         select n).FirstOrDefault();
            cbNhaCC.Text = dh.MaNcc;

            DatHangNhaCc datHang = db.DatHangNhaCcs.Where(d => d.MaDatHang == dh.MaDatHang).Select(d => d).FirstOrDefault();

            dtpNgayGiao.Text = datHang.NgayGiao.ToString();

            var query = db.ChiTietDatHangNhaCcs.
                                        Join(db.SanPhams,
                                        c => c.MaSp,
                                        s => s.MaSp,
                                        (c, s) => new
                                        {
                                            c.MaDatHang,
                                            c.MaSp,
                                            s.TenSp,
                                            c.Sldat,
                                            c.GiaDat
                                        }).Where(p => p.MaDatHang == dh.MaDatHang).Select(c => new {
                                            c.MaSp,
                                            c.TenSp,
                                            c.Sldat,
                                            c.GiaDat
                                        }); 

            dgvDanhSachSP.DataSource = query.ToList();


            dgvDanhSachSP.Columns[0].HeaderText = "Mã sản phẩm";
            dgvDanhSachSP.Columns[1].HeaderText = "Tên sản phẩm";
            dgvDanhSachSP.Columns[2].HeaderText = "Số lượng nhập";
            dgvDanhSachSP.Columns[3].HeaderText = "Giá nhập";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmDanhSachPhieuDat phieudat = new frmDanhSachPhieuDat();
            phieudat.Show();
            this.Hide();
        }
    }
}
