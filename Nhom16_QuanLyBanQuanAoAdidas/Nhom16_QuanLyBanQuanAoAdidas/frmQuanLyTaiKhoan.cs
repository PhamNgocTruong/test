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
    public partial class frmQuanLyTaiKhoan : Form
    {
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        #region Kiểm tra dữ liệu người dùng nhập
        private void txtTenTK_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTenTK, "");
        }
        private void txtPassword_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPassword, "");
        }
        private void grbLoaiTK_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(grbLoaiTK, "");
        }
        private void cbxTenNV_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbxTenNV, "");
        }

        private bool ValidData()
        {
            if (txtTenTK.Text == "")
            {
                errorProvider1.SetError(txtTenTK, "Bạn phải nhập tên tài khoản!");
                txtTenTK.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtTenTK, null);
            }
            if (txtPassword.Text == "")
            {
                errorProvider1.SetError(txtPassword, "Bạn phải nhập password cho tài khoản!");
                txtPassword.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }

            if (rabAdmin.Checked == false && rabNhanVien.Checked == false)
            {
                errorProvider1.SetError(grbLoaiTK, "Bạn phải nhập  loại sản phẩm!");
                grbLoaiTK.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(grbLoaiTK, null);
            }

            if (cbxTenNV.Text == "")
            {
                errorProvider1.SetError(cbxTenNV, "Bạn phải chọn tên nhân viên!");
                cbxTenNV.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(cbxTenNV, null);

            }


            return true;
        }
        #endregion

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            var comboQuery = from l in db.NhanViens
                             select l;
            cbxTenNV.DataSource = comboQuery.ToList();
            cbxTenNV.DisplayMember = "TenNV";
            cbxTenNV.ValueMember = "MaNV";
        }
        private void HienThi()
        {
            var query = from tk in db.TaiKhoans
                        select new
                        {
                            tk.TenTaiKhoan,
                            tk.MatKhau,
                            tk.LoaiTaiKhoan,
                            tk.MaNvNavigation.TenNv

                        };
            dgvQLTaiKhoan.DataSource = query.ToList();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var query = from n in db.TaiKhoans
                        where n.MaNv == int.Parse(cbxTenNV.SelectedValue.ToString())
                        select n;

            if (query.ToList().Count > 0)
            {
                MessageBox.Show("Nhân viên đã có tài khoản, Không thể thêm", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ValidData())
                {
                    TaiKhoan tkMoi = new TaiKhoan();
                    tkMoi.TenTaiKhoan = txtTenTK.Text;
                    tkMoi.MatKhau = txtPassword.Text;
                    if (rabAdmin.Checked)
                    {
                        tkMoi.LoaiTaiKhoan = "Admin";
                    }
                    else
                    {
                        tkMoi.LoaiTaiKhoan = "Nhân Viên";
                    }
                    tkMoi.MaNv = int.Parse(cbxTenNV.SelectedValue.ToString());
                    db.TaiKhoans.Add(tkMoi);

                    db.SaveChanges();

                    HienThi();
                    txtTenTK.Focus();
                    txtTenTK.Clear();
                    txtPassword.Clear();
                    
                }
            }
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Lấy ra Taikhoan muốn sửa
            TaiKhoan tkSua = db.TaiKhoans.SingleOrDefault(n => n.MaNv == int.Parse(cbxTenNV.SelectedValue.ToString()));
            if (ValidData())
            {
                //Sửa thông tin của Tài Khoản
                tkSua.MatKhau = txtPassword.Text;
                if (rabAdmin.Checked)
                {
                    tkSua.LoaiTaiKhoan = "Admin";
                }
                else
                {
                    tkSua.LoaiTaiKhoan = "Nhân Viên";
                }
                tkSua.MaNv = int.Parse(cbxTenNV.SelectedValue.ToString());
                //Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();
                //Hiển thị lại dữ liệu
                HienThi();
                txtTenTK.Focus();
                txtTenTK.Clear();
                txtPassword.Clear();
                
            }
            else
            {
                MessageBox.Show(" Tên tài khoản không tồn tại, Không thể sửa", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //lấy ra Tài khoản muốn xóa
            TaiKhoan tkXoa = (from n in db.TaiKhoans
                              where n.MaNv ==int.Parse(cbxTenNV.SelectedValue.ToString())
                              select n).FirstOrDefault();

            if (tkXoa == null)
            {
                MessageBox.Show("tài khoản không tồn tại, Không thể xóa", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult tl = MessageBox.Show("Bạn muốn xóa tài khoản  " + tkXoa.TenTaiKhoan, "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    //Xóa đối tượng khỏi tập hợp 
                    db.TaiKhoans.Remove(tkXoa);
                    //Cập nhật thay đổi vào csdl    
                    db.SaveChanges();
                    //Hiển thị lại dữ liệu
                    HienThi();
                }
            }
            txtTenTK.Focus();
            txtTenTK.Clear();
            txtPassword.Clear();
            
        }

        private void dgvQLTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            txtTenTK.Text = dgvQLTaiKhoan.Rows[index].Cells[0].Value.ToString();
            txtPassword.Text = dgvQLTaiKhoan.Rows[index].Cells[1].Value.ToString();
            NhanVien nv = db.NhanViens.Where(s => s.TenNv == dgvQLTaiKhoan.Rows[index].Cells[3].Value.ToString()).FirstOrDefault();
            cbxTenNV.Text = nv.TenNv;

            if (dgvQLTaiKhoan.Rows[index].Cells[2].Value.ToString().Equals("Admin"))
            {
                rabAdmin.Checked = true;
            }
            else
            {
                rabNhanVien.Checked = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Lấy dữ liệu từ bảng Tài khoản
            var query = from n in db.TaiKhoans
                        where n.MaNvNavigation.TenNv == txtTimKiem.Text
                        select new
                        {
                            n.TenTaiKhoan,
                            n.MatKhau,
                            n.LoaiTaiKhoan,
                            n.MaNvNavigation.TenNv
                        };
            //Hiển thị lên datagrid view
            dgvQLTaiKhoan.DataSource = query.ToList();
            txtTenTK.Focus();
            txtTenTK.Clear();
            txtPassword.Clear();
            
        }

        
    }
}
