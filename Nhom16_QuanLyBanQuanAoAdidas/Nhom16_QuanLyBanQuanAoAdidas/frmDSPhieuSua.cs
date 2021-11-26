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
    public partial class frmDSPhieuSua : Form
    {
        public frmDSPhieuSua()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();

        private void HienThiDuLieu()
        {
            //Lấy dữ liệu từ bảng Sửa Hàng
            var query = from p in db.SuaHangs
                        select new
                        {
                            p.MaSuaHang,
                            p.MaSp,
                            p.TenKh,
                            p.SoDt,
                            p.DiaChi,
                            p.NgayLap,
                            p.NgayTra,
                            p.TinhTrang

                        };
            //Hiển thị lên datagrid view


            dgvPhieuSua.DataSource = query.ToList();

            dgvPhieuSua.Columns[0].Width = 150;
            dgvPhieuSua.Columns[1].Width = 150;
            dgvPhieuSua.Columns[2].Width = 200;
            dgvPhieuSua.Columns[3].Width = 100;
            dgvPhieuSua.Columns[4].Width = 100;
            dgvPhieuSua.Columns[5].Width = 100;
            dgvPhieuSua.Columns[6].Width = 100;
            dgvPhieuSua.Columns[7].Width = 150;

            dgvPhieuSua.Columns[0].HeaderText = "Mã sửa hàng";
            dgvPhieuSua.Columns[1].HeaderText = "Mã Sản Phẩm";
            dgvPhieuSua.Columns[2].HeaderText = "Tên Khách Hàng";
            dgvPhieuSua.Columns[3].HeaderText = "SDT";
            dgvPhieuSua.Columns[4].HeaderText = "Địa Chỉ";
            dgvPhieuSua.Columns[5].HeaderText = "Ngày Lập";
            dgvPhieuSua.Columns[6].HeaderText = "Ngày Trả";
            dgvPhieuSua.Columns[7].HeaderText = "Tình Trạng";
        }

        private void frmDSPhieuSua_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var query = from sh in db.SuaHangs
                        where sh.MaSuaHang == txtMaSua.Text
                        select new
                        {
                            sh.MaSuaHang,
                            sh.MaSpNavigation.TenSp,
                            sh.TenKh,
                            sh.SoDt,
                            sh.DiaChi,
                            sh.TinhTrang,
                            sh.NgayLap,
                            sh.NgayTra
                            
                        };
            //Hiển thị lên datagrid view
            dgvPhieuSua.DataSource = query.ToList();
        }

        private void btnHienThiChiTietPhieu_Click(object sender, EventArgs e)
        {
            if (txtMaSua.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã sửa hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var query = (from p in db.SuaHangs
                         where p.MaSuaHang == txtMaSua.Text
                         select new
                         {
                             p.MaSuaHang,
                             p.MaSp,
                             p.TenKh,
                             p.SoDt,
                             p.DiaChi,
                             p.NgayLap,
                             p.NgayTra,
                             p.TinhTrang
                         }).FirstOrDefault();
            frmChiTietPhieuSua form = new frmChiTietPhieuSua();
            form.Tag = txtMaSua.Text;
            form.Show();
        }
    }
}
