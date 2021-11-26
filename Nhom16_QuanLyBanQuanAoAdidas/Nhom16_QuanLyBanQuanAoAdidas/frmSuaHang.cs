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
    public partial class frmSuaHang : Form
    {
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        List<SanPhamSua> listSanPham = new List<SanPhamSua>();
        public frmSuaHang()
        {
            InitializeComponent();
            dtpNgayNhan.Format = DateTimePickerFormat.Custom;
            dtpNgayNhan.CustomFormat = "dd-MM-yyyy";
            dtpNgayTra.Format = DateTimePickerFormat.Custom;
            dtpNgayTra.CustomFormat = "dd-MM-yyyy";
        }
        #region Kiểm tra dữ liệu người dùng nhập
        private void txtMaSua_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMaSua, "");
        }
        private void txtMaSP_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMaSP, "");
        }
        private void txtTinhTrang_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTinhTrang, "");
        }
        private void txtTenKH_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTenKH, "");
        }
        private void txtSDT_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSDT, "");
        }
        private void txtDiaChi_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDiaChi, "");
        }
        private bool ValidData()
        {
            if (txtMaSua.Text == "")
            {
                errorProvider1.SetError(txtMaSua, "Bạn phải nhập mã sửa!");
                txtMaSua.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtMaSua, null);
            }
            if (txtMaSP.Text == "")
            {
                errorProvider1.SetError(txtMaSP, "Bạn phải nhập mã sản phẩm!");
                txtMaSP.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtMaSP, null);
            }
            if (txtTinhTrang.Text == "")
            {
                errorProvider1.SetError(txtTinhTrang, "Bạn phải nhập tình trạng!");
                txtTinhTrang.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtTinhTrang, null);
            }
            if (txtTenKH.Text == "")
            {
                errorProvider1.SetError(txtTenKH, "Bạn phải nhập tên khách hàng!");
                txtTenKH.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtTenKH, null);
            }
            if (txtSDT.Text == "")
            {
                errorProvider1.SetError(txtSDT, "Bạn phải nhập số điện thoại!");
                txtSDT.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtSDT, null);
            }
            if (txtDiaChi.Text == "")
            {
                errorProvider1.SetError(txtDiaChi, "Bạn phải nhập địa chỉ!");
                txtDiaChi.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtDiaChi, null);
            }
            return true;
        }
            #endregion
            private void frmSuaHang_Load(object sender, EventArgs e)
        {

        }

        private void btnAddSP_Click(object sender, EventArgs e)
        {
            //tạo sản phẩm muốn thêm
            SanPhamSua spSua = new SanPhamSua();
            spSua.MaSp = txtMaSP.Text;

            SanPham sp = db.SanPhams.Where(sp => sp.MaSp == txtMaSP.Text).SingleOrDefault();


            if (sp != null)
            {
                
                spSua.TinhTrang = txtTinhTrang.Text;
                int index = KiemTraTonTaiSanPham(spSua.MaSp);
                if (index == -1)
                {
                    listSanPham.Add(spSua);
                }
                else
                {
                    listSanPham[index] = spSua;
                }

                //MessageBox.Show("So luong: " + listSanPham.Count);

                dgvSanPham.DataSource = listSanPham.ToList();

                HienThi();

                

            }
            else
            {
                MessageBox.Show("Không có sản phẩm mã " + txtMaSP.Text, "Lập phiếu sửa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSP.Text = "";
                txtMaSP.Focus();
            }
        }

        private int KiemTraTonTaiSanPham(string maSp)
        {
            for (int i = 0; i < listSanPham.Count; i++)
            {
                if (listSanPham[i].MaSp == maSp)
                {
                    return i;
                }
            }
            return -1;
        }

        private void HienThi()
        {
            dgvSanPham.Columns[0].Width = 130;
            dgvSanPham.Columns[1].Width = 200;

            dgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns[1].HeaderText = "Tình Trạng";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            // Kiem tra listSP > 0
            int dem = 0;
            foreach (var item in listSanPham)
            {
                if (item.MaSp.Length > 0)
                {
                    dem = 1;
                    break;
                }
            }
            if (dem == 0)
            {
                MessageBox.Show("Bạn chưa thiết lập  sản phẩm nào. Vui lòng nhập", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tao doi tuong PhieuNhap
            SuaHang phieusua = new SuaHang();
            phieusua.MaSuaHang = txtMaSua.Text;
            phieusua.MaSp = txtMaSP.Text;
            phieusua.NgayLap = dtpNgayNhan.Value;
            phieusua.NgayTra = dtpNgayTra.Value;
            phieusua.TenKh = txtTenKH.Text;
            phieusua.SoDt = txtSDT.Text;
            phieusua.DiaChi = txtDiaChi.Text;
            phieusua.TinhTrang = txtTinhTrang.Text;

            // Luu  vao CSDL
            db.SuaHangs.Add(phieusua);

            /*foreach (var item in listSanPham)
            {

                // Tao ChiTietPhieuNhap
                ChiTietPhieuNhap chiTiet = new ChiTietPhieuNhap();
                chiTiet.MaPn = phieu.MaPn;
                chiTiet.MaSp = item.MaSP;
                chiTiet.Slnhap = item.SoLuongNhap;
                chiTiet.GiaNhap = item.DonGia;
                // Luu chi tiet phieu nhap vao CSDL
                db.ChiTietPhieuNhaps.Add(chiTiet);

                

            }*/
            // Luu vao CSDL
            db.SaveChanges();
            MessageBox.Show("Lưu phiếu sửa thành công", "Lập hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTenKH.Focus();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaSua.Clear();
            txtMaSP.Clear();
            txtTinhTrang.Clear();
        }
    }
}
