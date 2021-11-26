using Nhom16_QuanLyBanQuanAoAdidas.D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Nhom16_QuanLyBanQuanAoAdidas
{
    public partial class frmChiTietPhieuNhap : Form
    {
        public frmChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void frmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            string MaPN = (string)this.Tag;
            txtMaPN.Text = MaPN;
            PhieuNhap phieu = db.PhieuNhaps.Where(p => p.MaPn == MaPN).SingleOrDefault();
            txtNguoiGiao.Text = phieu.NguoiGiaoHang;
            txtNguoiLap.Text = phieu.NguoiLap;

            dateTimePicker1.Value = (DateTime)phieu.NgayLap;

            var nhaCC = (from n in db.NhaCcs
                             where n.MaNcc == phieu.MaNcc
                             select n).FirstOrDefault();
            lblNhaCC.Text = nhaCC.TenNcc;
            cbDatHang.Text = phieu.MaDatHang;

            txtDiaDiemNhap.Text = phieu.DiaDiemNhap;

            DatHangNhaCc datHang = db.DatHangNhaCcs.Where(d => d.MaDatHang == phieu.MaDatHang).Select(d => d).FirstOrDefault();

            lblNgayDat.Text = datHang.NgayGiao.ToString();

            var query = db.ChiTietPhieuNhaps.
                                        Join(db.SanPhams,
                                        c => c.MaSp,
                                        s => s.MaSp,
                                        (c,s) => new
                                        {
                                            c.MaPn,
                                            c.MaSp,
                                            s.TenSp,
                                            c.Slnhap,
                                            c.GiaNhap
                                        }).Where(p => p.MaPn == phieu.MaPn).Select(c => new {
                                            c.MaSp,
                                            c.TenSp,
                                            c.Slnhap,
                                            c.GiaNhap
                                        }); ;
            //var listChiTiet = (from c in db.ChiTietPhieuNhaps
            //                                      where c.MaPn == phieu.MaPn
            //                                      select new {
            //                                        c.MaSp,
            //                                        c.Slnhap,
            //                                        c.GiaNhap
            //                                      }).ToList();

            dataGridView1.DataSource = query.ToList();

            dataGridView1.Columns[1].Width = 300;

            dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Số lượng nhập";
            dataGridView1.Columns[3].HeaderText = "Giá nhập";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
