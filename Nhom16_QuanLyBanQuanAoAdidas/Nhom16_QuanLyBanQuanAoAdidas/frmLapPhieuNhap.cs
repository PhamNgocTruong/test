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
    public partial class frmLapPhieuNhap : Form
    {
        public frmLapPhieuNhap()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void frmLapPhieuNhap_Load(object sender, EventArgs e)
        {
            var query = from d in db.DatHangNhaCcs
                        select d.MaDatHang;
            cbDatHang.DataSource = query.ToList();
            cbDatHang.Text = "";
        }
        List<DSHangNhap> listDSHangNhap = new List<DSHangNhap>();
        private void HienThiDuLieu()
        {
            dgvHangNhap.Columns[0].Width = 100;
            dgvHangNhap.Columns[1].Width = 200;
            dgvHangNhap.Columns[2].Width = 100;
            dgvHangNhap.Columns[3].Width = 100;
            dgvHangNhap.Columns[4].Width = 100;
            dgvHangNhap.Columns[5].Width = 100;

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
            listDSHangNhap = new List<DSHangNhap>();
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
            string TenNCC = db.NhaCcs.Where(n => n.MaNcc == MaNCC).Select(n => n.TenNcc).FirstOrDefault();
            lblNhaCC.Text = TenNCC;
            //MessageBox.Show("Count: " + dsHang.ToList().Count);
            string query = (from d in db.DatHangNhaCcs
                            where d.MaDatHang == cbDatHang.Text
                            select d.NgayLap).FirstOrDefault().ToString();

            lblNgayDat.Text = query;

           /* foreach (var item in dsHang)
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

                listDSHangNhap.Add(hang);
            }*/

            dgvHangNhap.DataSource = listDSHangNhap.Select(s => new {
                s.MaSP,
                s.TenSP,
                s.SoLuongTheoChungTu,
                s.SoLuongNhap,
                s.DonGia,
                s.ThanhTien
            }).ToList();
            HienThiDuLieu();
        }

        private void dgvHangNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            txtMaSp.Text = dgvHangNhap.Rows[index].Cells[0].Value.ToString();
            txtSoLuong.Text = dgvHangNhap.Rows[index].Cells[3].Value.ToString();
            txtGiaNhap.Text = dgvHangNhap.Rows[index].Cells[4].Value.ToString();
        }
        private int KiemTraTonTaiSanPham(string MaSP)
        {
            for (int i = 0; i < listDSHangNhap.Count; i++)
            {
                if (listDSHangNhap[i].MaSP == MaSP)
                {
                    return i;
                }
            }
            return -1;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int index = KiemTraTonTaiSanPham(txtMaSp.Text);
            listDSHangNhap[index].SoLuongNhap = Convert.ToInt32(txtSoLuong.Text);
            listDSHangNhap[index].DonGia = Convert.ToDecimal(txtGiaNhap.Text);
            listDSHangNhap[index].ThanhTien = Convert.ToInt32(txtSoLuong.Text)* Convert.ToDecimal(txtGiaNhap.Text);

            dgvHangNhap.DataSource = listDSHangNhap.Select(s => new {
                s.MaSP,
                s.TenSP,
                s.SoLuongTheoChungTu,
                s.SoLuongNhap,
                s.DonGia,
                s.ThanhTien
            }).ToList();
            HienThiDuLieu();
        }

        private void btnLapPhieuNhap_Click(object sender, EventArgs e)
        {
            // Kiem tra listHang > 0
            int dem = 0;
            foreach (var item in listDSHangNhap)
            {
                if(item.SoLuongNhap > 0)
                {
                    dem = 1;
                    break;
                }
            }
            if(dem == 0)
            {
                MessageBox.Show("Bạn chưa thiết lập số lượng nhập sản phẩm nào. Vui lòng nhập","Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tao doi tuong PhieuNhap
            PhieuNhap phieu = new PhieuNhap();
            phieu.MaPn = txtMaPN.Text;
            phieu.MaDatHang = cbDatHang.Text;
            phieu.NgayLap = dateTimePicker1.Value;
            phieu.NguoiLap = txtNguoiLap.Text;
            phieu.NguoiGiaoHang = txtNguoiGiao.Text;
            phieu.DiaDiemNhap = txtDiaDiemNhap.Text;

            string MaNCC = db.DatHangNhaCcs.Where(d => d.MaDatHang == cbDatHang.Text).Select(d => d.MaNcc).FirstOrDefault();
            phieu.MaNcc = MaNCC;

            // Luu PhieuNhap vao CSDL
            db.PhieuNhaps.Add(phieu);

            foreach (var item in listDSHangNhap)
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

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool ValidData1()
        {

            return true;
        }

    }
}
