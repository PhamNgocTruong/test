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
    public partial class frmDSPhieuNhap : Form
    {
        public frmDSPhieuNhap()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void frmDSPhieuNhap_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }
        private void HienThiDuLieu()
        {
            //Lấy dữ liệu từ bảng Sản phẩm
            var query = from p in db.PhieuNhaps
                        select new
                        {
                            p.MaPn,
                            p.MaDatHang,
                            p.MaNccNavigation.TenNcc,
                            p.NguoiLap,
                            p.NguoiGiaoHang,
                            p.NgayLap
                        };
            //Hiển thị lên datagrid view


            dgvPhieuNhap.DataSource = query.ToList();

            dgvPhieuNhap.Columns[0].Width = 100;
            dgvPhieuNhap.Columns[1].Width = 100;
            dgvPhieuNhap.Columns[2].Width = 200;
            dgvPhieuNhap.Columns[3].Width = 150;
            dgvPhieuNhap.Columns[4].Width = 150;
            dgvPhieuNhap.Columns[5].Width = 150;

            dgvPhieuNhap.Columns[0].HeaderText = "Mã phiếu nhập";
            dgvPhieuNhap.Columns[1].HeaderText = "Số đặt hàng";
            dgvPhieuNhap.Columns[2].HeaderText = "Tên NCC";
            dgvPhieuNhap.Columns[3].HeaderText = "Người lập";
            dgvPhieuNhap.Columns[4].HeaderText = "Ngày giao";
            dgvPhieuNhap.Columns[5].HeaderText = "Ngày lập";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            txtMaPN.Text = dgvPhieuNhap.Rows[index].Cells[0].Value.ToString();
        }

        private void btnHienThiChiTietPhieu_Click(object sender, EventArgs e)
        {
            if(txtMaPN.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã phiếu nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var query = (from p in db.PhieuNhaps
                        where p.MaPn == txtMaPN.Text
                        select new
                        {
                            p.MaPn,
                            p.MaDatHang,
                            p.MaNccNavigation.TenNcc,
                            p.NguoiLap,
                            p.NguoiGiaoHang,
                            p.NgayLap
                        }).FirstOrDefault();
            if (query.MaDatHang == "" || query.MaDatHang == null)
            {
                frmChiTietPhieuLap2 form2 = new frmChiTietPhieuLap2();
                form2.Tag = txtMaPN.Text;
                form2.Show();
            } else
            {
                frmChiTietPhieuNhap form = new frmChiTietPhieuNhap();
                form.Tag = txtMaPN.Text;
                form.Show();
            }
            
        }
    }
}
