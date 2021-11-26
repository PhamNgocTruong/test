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
    public partial class frmDanhSachPhieuDat : Form
    {
        public frmDanhSachPhieuDat()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void btnDong_Click(object sender, EventArgs e)
        {
            frmTrangChu trangchu = new frmTrangChu();
            trangchu.Show();
            this.Hide();
        }
        private void HienThiDuLieu()
        {
            //Lấy dữ liệu từ bảng Sản phẩm
            var query = from p in db.DatHangNhaCcs 
                        select new
                        {
                            p.MaDatHang,
                            p.NguoiLap,
                            p.NgayLap,
                            p.NgayGiao,
                            p.MaNccNavigation.TenNcc
                            
                        };
            //Hiển thị lên datagrid view


            dgvPhieuDat.DataSource = query.ToList();

            dgvPhieuDat.Columns[0].Width = 100;
            dgvPhieuDat.Columns[1].Width = 150;
            dgvPhieuDat.Columns[2].Width = 100;
            dgvPhieuDat.Columns[3].Width = 100;
            dgvPhieuDat.Columns[4].Width = 150;

            dgvPhieuDat.Columns[0].HeaderText = "Mã phiếu đặt";
            dgvPhieuDat.Columns[1].HeaderText = "Người lập";
            dgvPhieuDat.Columns[2].HeaderText = "Ngày lập";
            dgvPhieuDat.Columns[3].HeaderText = "Ngày giao";
            dgvPhieuDat.Columns[4].HeaderText = "Nhà CC";
        }

        private void frmDanhSachPhieuDat_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void btnHienThiChiTietPhieuDatHang_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã phiếu nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var query = (from p in db.DatHangNhaCcs
                         where p.MaDatHang == txtMaDH.Text
                         select new
                         {
                             p.MaDatHang,
                             p.NguoiLap,
                             p.NgayLap,
                             p.NgayGiao,
                             p.MaNccNavigation.TenNcc
                         }).FirstOrDefault();
            if (query.MaDatHang == "" || query.MaDatHang == null)
            {
                frmChiTietPhieuDatHang form2 = new frmChiTietPhieuDatHang();
                form2.Tag = txtMaDH.Text;
                form2.Show();
            }
            else
            {
                frmChiTietPhieuDatHang form = new frmChiTietPhieuDatHang();
                form.Tag = txtMaDH.Text;
                form.Show();
            }
        }

        private void dgvPhieuDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            txtMaDH.Text = dgvPhieuDat.Rows[index].Cells[0].Value.ToString();
        }
    }
}
