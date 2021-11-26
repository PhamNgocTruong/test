using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Nhom16_QuanLyBanQuanAoAdidas.D;

namespace Nhom16_QuanLyBanQuanAoAdidas
{
    public partial class frmChiTietPhieuSua : Form
    {
        public frmChiTietPhieuSua()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void frmChiTietPhieuSua_Load(object sender, EventArgs e)
        {
            string MaSuaHang = (string)this.Tag;
            txtMaSua.Text = MaSuaHang;
            SuaHang phieusua = db.SuaHangs.Where(p => p.MaSuaHang == MaSuaHang).SingleOrDefault();
            txtTenKH.Text = phieusua.TenKh;
            txtSDT.Text = phieusua.SoDt;
            txtDiaChi.Text = phieusua.DiaChi;
            dtpNgayNhan.Value = (DateTime)phieusua.NgayLap;
            dtpNgayTra.Value = (DateTime)phieusua.NgayTra;

            /*var query = db.Chi
                                        Join(db.SanPhams,
                                        c => c.MaSp,
                                        s => s.MaSp,
                                        (c, s) => new
                                        {
                                            c.MaPn,
                                            c.MaSp,
                                            s.TenSp,
                                            c.Slnhap,
                                            c.GiaNhap
                                        }).Where(p => p.MaPn == phieusua.MaSua).Select(c => new {
                                            c.MaSp,
                                            c.TenSp,
                                            c.Slnhap,
                                            c.GiaNhap
                                        }); ;
            

            dataGridView1.DataSource = query.ToList();

            dataGridView1.Columns[1].Width = 300;

            dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Số lượng nhập";
            dataGridView1.Columns[3].HeaderText = "Giá nhập";*/
        }

       
    }
}
