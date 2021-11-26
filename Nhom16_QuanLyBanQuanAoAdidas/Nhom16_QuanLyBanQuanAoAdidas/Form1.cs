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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)this.Tag;
            NhanVien nv = db.NhanViens.Where(n => n.MaNv == tk.MaNv).Select(n => n).FirstOrDefault();

            txtNguoiLap.Text = nv.TenNv;
            txtNguoiLap2.Text = nv.TenNv;

            var listNCC = db.NhaCcs.Select(n => n);
            cbNhaCC.DataSource = listNCC.ToList();
            cbNhaCC.DisplayMember = "TenNCC";
            cbNhaCC.ValueMember = "MaNCC";

            cbNhaCC.Text = "";

            var query = from d in db.DatHangNhaCcs
                        select d.MaDatHang;
            cbDatHang.DataSource = query.ToList();
            cbDatHang.Text = "";
        }
        List<DSHangNhap> listDSHangNhap1 = new List<DSHangNhap>();
        List<DSHangNhap> listDSHangNhap2 = new List<DSHangNhap>();
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)this.Tag;
            if (tabControl1.SelectedTab == tabPage2 && tk.LoaiTaiKhoan != "QuanLy")
            {
                tabControl1.SelectedIndex = 0;
                tabControl1.SelectedTab = tabPage1;
                MessageBox.Show("Tài khoản loại Quản lý mới có thể truy cập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void HienThiDuLieu2()
        {
            dgvHangNhap2.Columns[0].Width = 100;
            dgvHangNhap2.Columns[1].Width = 300;
            dgvHangNhap2.Columns[2].Width = 100;
            dgvHangNhap2.Columns[3].Width = 100;
            dgvHangNhap2.Columns[4].Width = 150;

            dgvHangNhap2.Columns[0].HeaderText = "Mã sản phẩm";
            dgvHangNhap2.Columns[1].HeaderText = "Tên sản phẩm";
            dgvHangNhap2.Columns[2].HeaderText = "Số lượng nhập";
            dgvHangNhap2.Columns[3].HeaderText = "Đơn giá";
            dgvHangNhap2.Columns[4].HeaderText = "Thành tiền";
        }
        private void btnThem2_Click(object sender, EventArgs e)
        {
            if (ValidateDataCapNhat2() == false)
            {
                return;
            }
            int index = KiemTraTonTaiSanPham2(txtMaSP2.Text);
            if(index == -1)
            {
                DSHangNhap hang = new DSHangNhap();
                hang.MaSP = txtMaSP2.Text;
                hang.TenSP = db.SanPhams.Where(s => s.MaSp == txtMaSP2.Text).Select(s => s.TenSp).FirstOrDefault();
                hang.SoLuongNhap = Convert.ToInt32(txtSLNhap2.Text);
                hang.DonGia = Convert.ToDecimal(txtGiaNhap2.Text);
                hang.ThanhTien = hang.SoLuongNhap * hang.DonGia;

                listDSHangNhap2.Add(hang);

                dgvHangNhap2.DataSource = listDSHangNhap2.Select(a => new
                {
                    a.MaSP,
                    a.TenSP,
                    a.SoLuongNhap,
                    a.DonGia,
                    a.ThanhTien
                }).ToList();

                HienThiDuLieu2();
                // Tinh Tong Tien
                lblTongTien2.Text = TinhTongTien2()+" VND";
            } else
            {
                MessageBox.Show("Sản phẩm này đã được thêm", "lỗi thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }
        private int KiemTraTonTaiSanPham2(string MaSP)
        {
            for (int i = 0; i < listDSHangNhap2.Count; i++)
            {
                if (listDSHangNhap2[i].MaSP == MaSP)
                {
                    return i;
                }
            }
            return -1;
        }
        private void btnCapNhat2_Click(object sender, EventArgs e)
        {
            if (ValidateDataCapNhat2() == false)
            {
                return;
            }
            int index = KiemTraTonTaiSanPham2(txtMaSP2.Text);
            if(index == -1)
            {
                MessageBox.Show("Sản phẩm này chưa được thêm", "Lỗi sửa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                //MessageBox.Show(index + "");
                listDSHangNhap2[index].SoLuongNhap = Convert.ToInt32(txtSLNhap2.Text);
                listDSHangNhap2[index].DonGia = Convert.ToDecimal(txtGiaNhap2.Text);
                listDSHangNhap2[index].ThanhTien = Convert.ToInt32(txtSLNhap2.Text) * Convert.ToDecimal(txtGiaNhap2.Text);

                dgvHangNhap2.DataSource = listDSHangNhap2.Select(a => new
                {
                    a.MaSP,
                    a.TenSP,
                    a.SoLuongNhap,
                    a.DonGia,
                    a.ThanhTien
                }).ToList();

                // Tinh Tong Tien
                lblTongTien2.Text = TinhTongTien2() + " VND";
            }
            
        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            int index = KiemTraTonTaiSanPham2(txtMaSP2.Text);
            if(index == -1)
            {
                MessageBox.Show("Không tìm thấy sản phẩm có mã " + txtMaSP2.Text, "Lỗi sửa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listDSHangNhap2.RemoveAt(index);

            dgvHangNhap2.DataSource = listDSHangNhap2.Select(a => new
            {
                a.MaSP,
                a.TenSP,
                a.SoLuongNhap,
                a.DonGia,
                a.ThanhTien
            }).ToList();

            // Tinh Tong Tien
            lblTongTien2.Text = TinhTongTien2() + " VND";
        }

        private void dgvHangNhap2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            txtMaSP2.Text = dgvHangNhap2.Rows[index].Cells[0].Value.ToString();
            txtSLNhap2.Text = dgvHangNhap2.Rows[index].Cells[2].Value.ToString();
            txtGiaNhap2.Text = dgvHangNhap2.Rows[index].Cells[3].Value.ToString();
        }

        private void btnLapPhieu2_Click(object sender, EventArgs e)
        {
            if (ValidateDataPhieu2()==false)
            {
                return;
            }
            // Kiem tra listHang > 0
            int dem = 0;
            foreach (var item in listDSHangNhap2)
            {
                if (item.SoLuongNhap > 0)
                {
                    dem = 1;
                    break;
                }
            }
            if (dem == 0)
            {
                MessageBox.Show("Bạn chưa nhập sản phẩm nào. Vui lòng nhập", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string MaPN = (from n in db.PhieuNhaps
                            orderby n.MaPn descending
                            select n.MaPn).FirstOrDefault();
            string PhanSo = MaPN.Substring(2);
            int so = int.Parse(PhanSo);
            if (so <= 8)
            {
                MaPN = "PN000" + (so + 1);
            }
            else if (so >= 9 && so <= 98)
            {
                MaPN = "PN00" + (so + 1);
            }
            else if (so >= 99 && so <= 998)
            {
                MaPN = "PN0" + (so + 1);
            }
            else if (so >= 999 && so <= 9998)
            {
                MaPN = "PN" + (so + 1);
            }

            // Tao doi tuong PhieuNhap
            PhieuNhap phieu = new PhieuNhap();
            phieu.MaPn = MaPN;
            phieu.MaDatHang = null;
            phieu.NgayLap = dateTimePicker2.Value;
            phieu.NguoiLap = txtNguoiLap2.Text;
            phieu.NguoiGiaoHang = txtNguoiGiaoHang2.Text;
            phieu.DiaDiemNhap = txtDiaDiem2.Text;

            phieu.MaNcc = cbNhaCC.SelectedValue.ToString();

            // Luu PhieuNhap vao CSDL
            db.PhieuNhaps.Add(phieu);
            foreach (var item in listDSHangNhap2)
            {

                // Tao ChiTietPhieuNhap
                ChiTietPhieuNhap chiTiet = new ChiTietPhieuNhap();
                chiTiet.MaPn = phieu.MaPn;
                chiTiet.MaSp = item.MaSP;
                chiTiet.Slnhap = item.SoLuongNhap;
                chiTiet.GiaNhap = item.DonGia;
                // Luu chi tiet phieu nhap vao CSDL
                db.ChiTietPhieuNhaps.Add(chiTiet);

                // Cap nhat lai SLCon cua SanPham
                SanPham sanPhamSua = db.SanPhams.SingleOrDefault(sp => sp.MaSp == chiTiet.MaSp);
                sanPhamSua.Slcon += chiTiet.Slnhap;

            }
            // Luu vao CSDL
            db.SaveChanges();
            MessageBox.Show("Lưu phiếu nhập thành công", "Lập hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            XoaTextBoxPhieu2();
        }

        private void btnDong2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MaNCC = cbNhaCC.SelectedValue.ToString();
            string NguoiGiao = db.NhaCcs.Where(n => n.MaNcc == MaNCC).Select(n => n.NguoiLienHe).FirstOrDefault();
            txtNguoiGiaoHang2.Text = NguoiGiao;
        }

        private void HienThiDuLieu()
        {
            dgvHangNhap.Columns[0].Width = 100;
            dgvHangNhap.Columns[1].Width = 300;
            dgvHangNhap.Columns[2].Width = 100;
            dgvHangNhap.Columns[3].Width = 100;
            dgvHangNhap.Columns[4].Width = 100;
            dgvHangNhap.Columns[5].Width = 150;

            dgvHangNhap.Columns[0].HeaderText = "Mã sản phẩm";
            dgvHangNhap.Columns[1].HeaderText = "Tên sản phẩm";
            dgvHangNhap.Columns[2].HeaderText = "Số lượng(Theo chứng từ)";
            dgvHangNhap.Columns[3].HeaderText = "Số lượng nhập";
            dgvHangNhap.Columns[4].HeaderText = "Đơn giá";
            dgvHangNhap.Columns[5].HeaderText = "Thành tiền";
        }
        private void cbDatHang_Validated(object sender, EventArgs e)
        {
            //var dsHang = from c in db.ChiTietDatHangNhaCcs
            //             where c.MaDatHang == cbDatHang.Text
            //             select c;
            listDSHangNhap1 = new List<DSHangNhap>();
            var dsHang = (db.ChiTietDatHangNhaCcs.Join(db.SanPhams,
                      c => c.MaSp,
                      s => s.MaSp,
                      (c, s) => new {
                          c.MaDatHang,
                          c.MaSp,
                          s.TenSp,
                          c.Sldat,
                          c.SldatCon,
                          c.GiaDat
                      })).Where(c => c.MaDatHang == cbDatHang.Text);
            string MaNCC = db.DatHangNhaCcs.Where(d => d.MaDatHang == cbDatHang.Text).Select(d => d.MaNcc).FirstOrDefault();
            var nhaCC = db.NhaCcs.Where(n => n.MaNcc == MaNCC).Select(n => new {
                n.TenNcc,
                n.NguoiLienHe
            }).FirstOrDefault();
            lblNhaCC.Text = nhaCC.TenNcc;
            //MessageBox.Show("Count: " + dsHang.ToList().Count);
            string query = (from d in db.DatHangNhaCcs
                            where d.MaDatHang == cbDatHang.Text
                            select d.NgayGiao).FirstOrDefault().ToString();

            // Ngay Dat
            lblNgayDat.Text = query;
            // Ten Nguoi lien he
            txtNguoiGiao.Text = nhaCC.NguoiLienHe;

            foreach (var item in dsHang)
            {
                DSHangNhap hang = new DSHangNhap();
                hang.MaSP = item.MaSp;
                //SanPham sp = db.SanPhams.Where(sp => sp.MaSp == item.MaSp).SingleOrDefault();
                //var TenSP = (from s in db.SanPhams
                //              where s.MaSp == item.MaSp
                //              select s.TenSp).FirstOrDefault();
                hang.TenSP = item.TenSp;
                hang.SoLuongTheoChungTu = item.Sldat;
                hang.SoluongConLai = item.SldatCon;
                hang.SoLuongNhap = 0;
                hang.DonGia = Convert.ToDecimal(item.GiaDat.ToString("#.##"));
                hang.ThanhTien = hang.SoLuongNhap * hang.DonGia;

                listDSHangNhap1.Add(hang);
            }

            dgvHangNhap.DataSource = listDSHangNhap1.Select(s => new {
                s.MaSP,
                s.TenSP,
                s.SoLuongTheoChungTu,
                s.SoLuongNhap,
                s.DonGia,
                s.ThanhTien
            }).ToList();
            HienThiDuLieu();
        }
        private int KiemTraTonTaiSanPham(string MaSP)
        {
            for (int i = 0; i < listDSHangNhap1.Count; i++)
            {
                if (listDSHangNhap1[i].MaSP == MaSP)
                {
                    return i;
                }
            }
            return -1;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (ValidDataCapNhat1()==false)
            {
                return;
            }
            int index = KiemTraTonTaiSanPham(txtMaSp.Text);
            listDSHangNhap1[index].SoLuongNhap = Convert.ToInt32(txtSoLuong.Text);
            listDSHangNhap1[index].DonGia = Convert.ToDecimal(txtGiaNhap.Text);
            listDSHangNhap1[index].ThanhTien = Convert.ToInt32(txtSoLuong.Text) * Convert.ToDecimal(txtGiaNhap.Text);

            dgvHangNhap.DataSource = listDSHangNhap1.Select(s => new {
                s.MaSP,
                s.TenSP,
                s.SoLuongTheoChungTu,
                s.SoLuongNhap,
                s.DonGia,
                s.ThanhTien
            }).ToList();
            HienThiDuLieu();

            // Tinh Tong Tien
            lblTongTien1.Text = TinhTongTien1() + " VND";
        }
        private void btnLapPhieuNhap_Click(object sender, EventArgs e)
        {
            if (ValidDataLapPhieu1() == false)
            {
                return;
            }
            // Kiem tra listHang > 0
            int dem = 0;
            foreach (var item in listDSHangNhap1)
            {
                if (item.SoLuongNhap > 0)
                {
                    dem = 1;
                    break;
                }
            }
            if (dem == 0)
            {
                MessageBox.Show("Bạn chưa thiết lập số lượng nhập sản phẩm nào. Vui lòng nhập", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string MaPN = (from n in db.PhieuNhaps
                           orderby n.MaPn descending
                           select n.MaPn).FirstOrDefault();
            string PhanSo = MaPN.Substring(2);
            int so = int.Parse(PhanSo);
            if (so <= 8)
            {
                MaPN = "PN000" + (so + 1);
            }
            else if (so >= 9 && so <= 98)
            {
                MaPN = "PN00" + (so + 1);
            }
            else if (so >= 99 && so <= 998)
            {
                MaPN = "PN0" + (so + 1);
            }
            else if (so >= 999 && so <= 9998)
            {
                MaPN = "PN" + (so + 1);
            }

            // Tao doi tuong PhieuNhap
            PhieuNhap phieu = new PhieuNhap();
            phieu.MaPn = MaPN;
            phieu.MaDatHang = cbDatHang.Text;
            phieu.NgayLap = dateTimePicker1.Value;
            phieu.NguoiLap = txtNguoiLap.Text;
            phieu.NguoiGiaoHang = txtNguoiGiao.Text;
            phieu.DiaDiemNhap = txtDiaDiemNhap.Text;

            string MaNCC = db.DatHangNhaCcs.Where(d => d.MaDatHang == cbDatHang.Text).Select(d => d.MaNcc).FirstOrDefault();
            phieu.MaNcc = MaNCC;

            // Luu PhieuNhap vao CSDL
            db.PhieuNhaps.Add(phieu);

            foreach (var item in listDSHangNhap1)
            {

                // Tao ChiTietPhieuNhap
                ChiTietPhieuNhap chiTiet = new ChiTietPhieuNhap();
                chiTiet.MaPn = phieu.MaPn;
                chiTiet.MaSp = item.MaSP;
                chiTiet.Slnhap = item.SoLuongNhap;
                chiTiet.GiaNhap = item.DonGia;
                // Luu chi tiet phieu nhap vao CSDL
                db.ChiTietPhieuNhaps.Add(chiTiet);

                // Cap nhat lai SLCon cua ChiTietDatHang
                ChiTietDatHangNhaCc ct = db.ChiTietDatHangNhaCcs.SingleOrDefault(c => c.MaDatHang == phieu.MaDatHang && c.MaSp == item.MaSP);
                ct.SldatCon = ct.SldatCon - item.SoLuongNhap;

                // Cap nhat lai SLCon cua SanPham
                SanPham sanPhamSua = db.SanPhams.SingleOrDefault(sp => sp.MaSp == chiTiet.MaSp);

                sanPhamSua.Slcon += chiTiet.Slnhap;

            }
            // Luu vao CSDL
            db.SaveChanges();
            MessageBox.Show("Lưu phiếu nhập thành công", "Lập hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            XoaTextBoxPhieu1();
        }

        private void dgvHangNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            txtMaSp.Text = dgvHangNhap.Rows[index].Cells[0].Value.ToString();
            txtSoLuong.Text = dgvHangNhap.Rows[index].Cells[3].Value.ToString();
            txtGiaNhap.Text = dgvHangNhap.Rows[index].Cells[4].Value.ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
        #region Validate Phieu1
        private void txtDiaDiemNhap_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDiaDiemNhap, "");
        }

        private void txtMaSp_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMaSp, "");
        }

        private void txtSoLuong_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSoLuong, "");
        }

        private void txtGiaNhap_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtGiaNhap, "");
        }
        private bool ValidDataCapNhat1()
        {
            if (txtMaSp.Text == "")
            {
                errorProvider1.SetError(txtMaSp, "Bạn phải nhập mã sản phẩm!");
                txtMaSp.Focus();
                return false;
            }
            else
            {
                if (txtMaSp.Text.Length > 6)
                {
                    errorProvider1.SetError(txtMaSp, "Mã sản phẩm không quá 100 ký tự!");
                    return false;
                }
                var sp = from s in db.ChiTietDatHangNhaCcs
                         where s.MaSp == txtMaSp.Text
                         select s;
                if (sp.ToList().Count < 1)
                {
                    errorProvider1.SetError(txtMaSp, "Không tồn tại sản phẩm có mã " + txtMaSp.Text + " thuộc đon hàng mã " + cbDatHang.SelectedValue.ToString());
                    return false;
                }

            }
            try
            {

                int SLNhap = int.Parse(txtSoLuong.Text);
                if (SLNhap < 0)
                {
                    errorProvider1.SetError(txtSoLuong, "Số lượng nhập cần >= 0");
                    txtSoLuong.Focus();
                    txtSoLuong.SelectAll();
                    return false;
                }
                int SoluongConLai = 0;
                foreach (var item in listDSHangNhap1)
                {
                    if(item.MaSP == txtMaSp.Text)
                    {
                        SoluongConLai = item.SoluongConLai;
                        break;
                    }
                }
                //MessageBox.Show(SLDat + " " + SLNhap);
                if (SLNhap > SoluongConLai)
                {
                    errorProvider1.SetError(txtSoLuong, "Số lượng còn lại của đơn đặt hàng là: " + SoluongConLai);
                    txtSoLuong.Focus();
                    return false;
                }
            }
            catch
            {
                errorProvider1.SetError(txtSoLuong, "Số lượng nhập cần là số nguyên dương!");
                txtSoLuong.Focus();
                txtSoLuong.SelectAll();
                return false;
            }

            if (txtGiaNhap.Text == "")
            {
                errorProvider1.SetError(txtGiaNhap, "Bạn phải nhập giá cho sản phẩm!");
                txtGiaNhap.Focus();
                return false;
            }
            else
            {
                try
                {
                    decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
                    if (giaNhap <= 0)
                    {
                        errorProvider1.SetError(txtGiaNhap, "Giá nhập cần > 0");
                        txtGiaNhap.Focus();
                        txtGiaNhap.SelectAll();
                        return false;
                    }
                }
                catch
                {
                    errorProvider1.SetError(txtGiaNhap, "Giá nhập cần là số nguyên!");
                    txtGiaNhap.Focus();
                    txtGiaNhap.SelectAll();
                    return false;
                }
            }

            return true;
        }
        private bool ValidDataLapPhieu1()
        {
            if (txtDiaDiemNhap.Text == "")
            {
                errorProvider1.SetError(txtDiaDiemNhap, "Bạn phải nhập tên địa điểm nhập!");
                txtDiaDiemNhap.Focus();
                return false;
            }
            else
            {
                if (txtDiaDiemNhap.Text.Length > 100)
                {
                    errorProvider1.SetError(txtDiaDiemNhap, "Địa điểm không quá 100 ký tự!");
                    return false;
                }
            }

            int dem = 0;
            foreach (var item in listDSHangNhap1)
            {
                if(item.SoLuongNhap > 0)
                {
                    dem++;
                    break;
                }
            }
            if(dem == 0)
            {
                MessageBox.Show("Bạn chưa nhập sản phẩm nào", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Validdate Phieu2

        #endregion

        private void txtDiaDiem2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDiaDiem2, "");
        }

        private void txtNguoiGiaoHang2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNguoiGiaoHang2, "");
        }

        private void txtMaSP2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMaSP2, "");
        }

        private void txtSLNhap2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSLNhap2, "");
        }

        private void txtGiaNhap2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtGiaNhap2, "");
        }
        private bool ValidateDataPhieu2()
        {
            if (txtDiaDiem2.Text == "")
            {
                errorProvider1.SetError(txtDiaDiem2, "Bạn phải nhập tên địa điểm nhập!");
                txtDiaDiem2.Focus();
                return false;
            }
            else
            {
                if (txtDiaDiem2.Text.Length > 100)
                {
                    errorProvider1.SetError(txtDiaDiem2, "Địa điểm không quá 100 ký tự!");
                    return false;
                }
            }
            if (txtNguoiGiaoHang2.Text == "")
            {
                errorProvider1.SetError(txtNguoiGiaoHang2, "Bạn phải nhập tên người giao hàng!");
                txtNguoiGiaoHang2.Focus();
                return false;
            }
            else
            {
                if (txtNguoiGiaoHang2.Text.Length > 100)
                {
                    errorProvider1.SetError(txtNguoiGiaoHang2, "Địa điểm không quá 100 ký tự!");
                    return false;
                }
            }
            if (listDSHangNhap2.Count < 1)
            {
                MessageBox.Show("Bạn chưa nhập sản phẩm nào", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ValidateDataCapNhat2()
        {
            if (txtMaSP2.Text == "")
            {
                errorProvider1.SetError(txtMaSP2, "Bạn phải nhập mã sản phẩm!");
                txtMaSP2.Focus();
                return false;
            }
            else
            {
                if (txtMaSP2.Text.Length > 6)
                {
                    errorProvider1.SetError(txtMaSP2, "Mã sản phẩm không quá 6 ký tự!");
                    return false;
                }
                var query = from s in db.SanPhams
                            where s.MaSp == txtMaSP2.Text
                            select s;
                if (query.ToList().Count < 1)
                {
                    errorProvider1.SetError(txtMaSP2, "Sản phẩm có mã " + txtMaSP2.Text + " không tồn tại");
                    return false;
                }
            }

            if (txtSLNhap2.Text == "")
            {
                errorProvider1.SetError(txtSLNhap2, "Bạn phải nhập số lượng!");
                txtSLNhap2.Focus();
                return false;
            }
            try
            {

                int SLNhap = int.Parse(txtSLNhap2.Text);
                if (SLNhap <= 0)
                {
                    errorProvider1.SetError(txtSLNhap2, "Số lượng nhập cần > 0");
                    txtSLNhap2.Focus();
                    txtSLNhap2.SelectAll();
                    return false;
                }
            }
            catch
            {
                errorProvider1.SetError(txtSoLuong, "Số lượng nhập cần là số nguyên dương!");
                txtSLNhap2.Focus();
                txtSLNhap2.SelectAll();
                return false;
            }

            if (txtGiaNhap2.Text == "")
            {
                errorProvider1.SetError(txtGiaNhap2, "Bạn phải nhập giá cho sản phẩm!");
                txtGiaNhap2.Focus();
                return false;
            }
            else
            {
                try
                {
                    decimal giaNhap = decimal.Parse(txtGiaNhap2.Text);
                    if (giaNhap <= 0)
                    {
                        errorProvider1.SetError(txtGiaNhap2, "Giá nhập cần > 0");
                        txtGiaNhap2.Focus();
                        txtGiaNhap2.SelectAll();
                        return false;
                    }
                }
                catch
                {
                    errorProvider1.SetError(txtGiaNhap2, "Giá nhập cần là số nguyên!");
                    txtGiaNhap2.Focus();
                    txtGiaNhap2.SelectAll();
                    return false;
                }
            }
            return true;
        }
        private decimal TinhTongTien1()
        {
            decimal tong = 0;
            foreach (var item in listDSHangNhap1)
            {
                tong = tong + item.SoLuongNhap * item.DonGia;
            }
            return tong;
        }
        private decimal TinhTongTien2()
        {
            decimal tong = 0;
            foreach (var item in listDSHangNhap2)
            {
                tong = tong + item.SoLuongNhap * item.DonGia;
            }
            return tong;
        }
        private void XoaTextBoxPhieu1()
        {
            txtDiaDiemNhap.Text = "";
            txtNguoiGiao.Text = "";
            cbDatHang.Text = "";
            lblNgayDat.Text = "";
            lblNhaCC.Text = "";
            lblTongTien1.Text = "";
            txtMaSp.Text = "";
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            listDSHangNhap1 = new List<DSHangNhap>();

            dgvHangNhap.DataSource = listDSHangNhap1;
        }
        private void XoaTextBoxPhieu2()
        {
            txtDiaDiem2.Text = "";
            txtNguoiGiaoHang2.Text = "";
            cbNhaCC.Text = "";
            lblNgayDat.Text = "";
            lblTongTien2.Text = "";
            txtMaSP2.Text = "";
            txtSLNhap2.Text = "";
            txtGiaNhap2.Text = "";
            listDSHangNhap2 = new List<DSHangNhap>();

            dgvHangNhap2.DataSource = listDSHangNhap2;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
