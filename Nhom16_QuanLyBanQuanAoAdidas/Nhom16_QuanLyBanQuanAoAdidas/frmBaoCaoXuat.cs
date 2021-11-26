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
    public partial class frmBaoCaoXuat : Form
    {
        public frmBaoCaoXuat()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void frmBaoCaoXuat_Load(object sender, EventArgs e)
        {
            HienThiBaoCaoXuat();
        }
        private void HienThiBaoCaoXuat()
        {
            var query = from p in db.ChiTietHoaDons
                        join c in db.HoaDons on p.MaHd equals c.MaHd
                        select new
                        {
                            p.MaHd,
                            p.MaSp,
                            p.Slmua,
                            p.Gia,
                            c.TenKh,
                            c.TenNguoiLap,
                            c.NgayLap,
                        };
            dgvBaoCaoXuat.DataSource = query.ToList();

            dgvBaoCaoXuat.Columns[0].Width = 100;
            dgvBaoCaoXuat.Columns[1].Width = 100;
            dgvBaoCaoXuat.Columns[2].Width = 100;
            dgvBaoCaoXuat.Columns[3].Width = 100;
            dgvBaoCaoXuat.Columns[4].Width = 100;
            dgvBaoCaoXuat.Columns[5].Width = 100;
            dgvBaoCaoXuat.Columns[6].Width = 100;


            dgvBaoCaoXuat.Columns[0].HeaderText = "Mã Hóa đơn";
            dgvBaoCaoXuat.Columns[1].HeaderText = "Mã sản phẩm";
            dgvBaoCaoXuat.Columns[2].HeaderText = "Số lượng mua";
            dgvBaoCaoXuat.Columns[3].HeaderText = "Giá";
            dgvBaoCaoXuat.Columns[4].HeaderText = "Tên Khách hàng";
            dgvBaoCaoXuat.Columns[5].HeaderText = "Tên người lập";
            dgvBaoCaoXuat.Columns[6].HeaderText = "Ngày lập";
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                //get value form
                int month = Convert.ToInt32(cbxThang.SelectedItem.ToString());
                int year = Convert.ToInt32(cbxNam.SelectedItem.ToString());
                var x = db.ChiTietHoaDons.Join(db.HoaDons, ct => ct.MaHd, pn => pn.MaHd,
                        (ct, pn) => new
                        {
                            mahd = pn.MaHd,
                            masp = ct.MaSp,
                            SLmua = ct.Slmua,
                            Gia = ct.Gia,
                            TenKH = pn.TenKh,
                            TenNL = pn.TenNguoiLap,
                            NgayLap = pn.NgayLap,
                        })
                    .Where(s => s.NgayLap.Value.Month == month && s.NgayLap.Value.Year == year).ToList();
                dgvBaoCaoXuat.DataSource = x.ToList();

                dgvBaoCaoXuat.Columns[0].Width = 100;
                dgvBaoCaoXuat.Columns[1].Width = 100;
                dgvBaoCaoXuat.Columns[2].Width = 100;
                dgvBaoCaoXuat.Columns[3].Width = 100;
                dgvBaoCaoXuat.Columns[4].Width = 100;
                dgvBaoCaoXuat.Columns[5].Width = 100;
                dgvBaoCaoXuat.Columns[6].Width = 100;


                dgvBaoCaoXuat.Columns[0].HeaderText = "Mã Hóa đơn";
                dgvBaoCaoXuat.Columns[1].HeaderText = "Mã sản phẩm";
                dgvBaoCaoXuat.Columns[2].HeaderText = "Số lượng mua";
                dgvBaoCaoXuat.Columns[3].HeaderText = "Giá";
                dgvBaoCaoXuat.Columns[4].HeaderText = "Tên Khách hàng";
                dgvBaoCaoXuat.Columns[5].HeaderText = "Tên người lập";
                dgvBaoCaoXuat.Columns[6].HeaderText = "Ngày lập";
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

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            HienThiBaoCaoXuat();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmTrangChu trangChu = new frmTrangChu();
            trangChu.Show();
            this.Hide();
        }
    }
}
