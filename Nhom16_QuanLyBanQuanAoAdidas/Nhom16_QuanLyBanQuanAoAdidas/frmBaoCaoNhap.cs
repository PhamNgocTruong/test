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
    public partial class frmBaoCaoNhap : Form
    {
        public frmBaoCaoNhap()
        {
            InitializeComponent();
        }

        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void frmBaoCaoNhap_Load(object sender, EventArgs e)
        {
            HienThiBaoCaoNhap();
        }
        private void HienThiBaoCaoNhap()
        {
            var query = from p in db.ChiTietPhieuNhaps join c in db.PhieuNhaps on p.MaPn equals c.MaPn
                        select new
                        {
                            p.MaPn,
                            p.MaSp,
                            p.GiaNhap,
                            p.Slnhap,
                            c.NgayLap,
                            c.NguoiGiaoHang,
                            c.NguoiLap,
                            c.MaDatHang,
                            c.MaNcc
                        };
            dgvBaoCao.DataSource = query.ToList();

            dgvBaoCao.Columns[0].Width = 100;
            dgvBaoCao.Columns[1].Width = 100;
            dgvBaoCao.Columns[2].Width = 100;
            dgvBaoCao.Columns[3].Width = 100;
            dgvBaoCao.Columns[4].Width = 100;
            dgvBaoCao.Columns[5].Width = 100;
            dgvBaoCao.Columns[6].Width = 100;
            dgvBaoCao.Columns[7].Width = 100;
            dgvBaoCao.Columns[8].Width = 100;


            dgvBaoCao.Columns[0].HeaderText = "Mã phiếu nhập";
            dgvBaoCao.Columns[1].HeaderText = "Mã sản phẩm";
            dgvBaoCao.Columns[2].HeaderText = "Đơn giá";
            dgvBaoCao.Columns[3].HeaderText = "Số lượng nhập";
            dgvBaoCao.Columns[4].HeaderText = "Ngày lập";
            dgvBaoCao.Columns[5].HeaderText = "Người giao hàng";
            dgvBaoCao.Columns[6].HeaderText = "Người lập";
            dgvBaoCao.Columns[7].HeaderText = "Mã đặt hàng";
            dgvBaoCao.Columns[8].HeaderText = "Mã NCC";
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                //get value form
                int month = Convert.ToInt32(cbxThang.SelectedItem.ToString());
                int year = Convert.ToInt32(cbxNam.SelectedItem.ToString());
                var x = db.ChiTietPhieuNhaps.Join(db.PhieuNhaps, ct => ct.MaPn, pn => pn.MaPn,
                        (ct, pn) => new
                        {
                            mapn = pn.MaPn,
                            masp = ct.MaSp,
                            gianhap = ct.GiaNhap,
                            slnhap = ct.Slnhap,
                            NgayLap = pn.NgayLap,
                            Nguoigiaohang = pn.NguoiGiaoHang,
                            Nguoilap = pn.NguoiLap,
                            madathang = pn.MaDatHang,
                        })
                    .Where(s => s.NgayLap.Value.Month == month && s.NgayLap.Value.Year == year).ToList();
                dgvBaoCao.DataSource = x.ToList();

                dgvBaoCao.Columns[0].Width = 100;
                dgvBaoCao.Columns[1].Width = 100;
                dgvBaoCao.Columns[2].Width = 100;
                dgvBaoCao.Columns[3].Width = 100;
                dgvBaoCao.Columns[4].Width = 100;
                dgvBaoCao.Columns[5].Width = 100;
                dgvBaoCao.Columns[6].Width = 100;
                dgvBaoCao.Columns[7].Width = 100;
                dgvBaoCao.Columns[8].Width = 100;


                dgvBaoCao.Columns[0].HeaderText = "Mã phiếu nhập";
                dgvBaoCao.Columns[1].HeaderText = "Mã sản phẩm";
                dgvBaoCao.Columns[2].HeaderText = "Đơn giá";
                dgvBaoCao.Columns[3].HeaderText = "Số lượng nhập";
                dgvBaoCao.Columns[4].HeaderText = "Ngày lập";
                dgvBaoCao.Columns[5].HeaderText = "Người giao hàng";
                dgvBaoCao.Columns[6].HeaderText = "Người lập";
                dgvBaoCao.Columns[7].HeaderText = "Mã đặt hàng";
                dgvBaoCao.Columns[8].HeaderText = "Mã NCC";
                txtTongTien.Text = TinhTongTien() + "VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có thông tin của tháng này!!");
            }
        }
        private bool check(DateTime? s, int month, int year)
        {
            if (s != null)
                return s.Value.Month == month && s.Value.Year == year;
            return false;
        }
        List<DSHangNhap> listDSHangNhap = new List<DSHangNhap>();
        private decimal TinhTongTien()
        {
            decimal tong = 0;
            foreach (var item in listDSHangNhap)
            {
                tong = tong + item.SoLuongNhap * item.DonGia;
            }
            return tong;
        }
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            HienThiBaoCaoNhap();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmTrangChu trangChu = new frmTrangChu();
            trangChu.Show();
            this.Hide();
        }
    }
}
