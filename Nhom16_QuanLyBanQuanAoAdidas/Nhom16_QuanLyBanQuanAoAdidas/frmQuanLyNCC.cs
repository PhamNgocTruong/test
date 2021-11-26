using Nhom16_QuanLyBanQuanAoAdidas.D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Nhom16_QuanLyBanQuanAoAdidas
{
    public partial class frmQuanLyNCC : Form
    {
        public frmQuanLyNCC()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void frmQuanLyNCC_Load(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)this.Tag;
            if (tk.LoaiTaiKhoan != "QuanLy")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }

            HienThiDuLieu();
        }
        private void HienThiDuLieu()
        {
            //Lấy dữ liệu từ bảng Sản phẩm
            var query = from ncc in db.NhaCcs
                        select new
                        {
                            ncc.MaNcc,
                            ncc.TenNcc,
                            ncc.NguoiLienHe,
                            ncc.SoDt,
                            ncc.Email,
                            ncc.DiaChi
                        };
            //Hiển thị lên datagrid view


            dgvNhaCC.DataSource = query.ToList();

            dgvNhaCC.Columns[0].Width = 75;
            dgvNhaCC.Columns[1].Width = 200;
            dgvNhaCC.Columns[2].Width = 150;
            dgvNhaCC.Columns[3].Width = 100;
            dgvNhaCC.Columns[4].Width = 150;
            dgvNhaCC.Columns[5].Width = 200;

            dgvNhaCC.Columns["MaNcc"].HeaderText = "Mã NCC";
            dgvNhaCC.Columns["TenNcc"].HeaderText = "Tên NCC";
            dgvNhaCC.Columns["NguoiLienHe"].HeaderText = "Người liên hệ";
            dgvNhaCC.Columns["Email"].HeaderText = "Email";
            dgvNhaCC.Columns["SoDt"].HeaderText = "Số ĐT";
            dgvNhaCC.Columns["DiaChi"].HeaderText = "Địa chỉ";
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidData() == false)
            {
                return;
            }
            int count = (from n in db.NhaCcs
                         select n).ToList().Count;
            if(count == 0)
            {
                // Chua co Nha CC nao gan ma = CC0001
            } else
            {
                // Sinh ma
                string MaNCC = (from n in db.NhaCcs
                                orderby n.MaNcc descending
                                select n.MaNcc).FirstOrDefault();
                string PhanSo = MaNCC.Substring(2);
                int so = int.Parse(PhanSo);
                if (so <= 8)
                {
                    MaNCC = "CC000" + (so + 1);
                }
                else if (so >= 9 && so <= 98)
                {
                    MaNCC = "CC00" + (so + 1);
                }
                else if (so >= 99 && so <= 998)
                {
                    MaNCC = "CC0" + (so + 1);
                }
                else if (so >= 999 && so <= 9998)
                {
                    MaNCC = "CC" + (so + 1);
                }
                txtMaNCC.Text = MaNCC;

                //Tạo đối tượng NhaCC muốn thêm
                NhaCc ncc = new NhaCc();
                //gán thuộc tính cho đối tượng NhaCC là dữ liệu user nhập vào
                ncc.MaNcc = MaNCC;
                ncc.TenNcc = txtTenNCC.Text;
                ncc.NguoiLienHe = txtNguoiLienHe.Text;
                ncc.SoDt = txtSoDT.Text;
                ncc.DiaChi = txtDiaChi.Text;
                ncc.Email = txtEmail.Text;
                //Thêm sản phẩm mới vào tập hợp NhaCC của context
                db.NhaCcs.Add(ncc);
                //Cập nhật lên csdl
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Hiển thị lại dữ liệu lên datagrid view
                HienThiDuLieu();
            }
            
        }

        private void dgvNhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            txtMaNCC.Text = dgvNhaCC.Rows[index].Cells[0].Value.ToString();
            txtTenNCC.Text = dgvNhaCC.Rows[index].Cells[1].Value.ToString();
            txtNguoiLienHe.Text = dgvNhaCC.Rows[index].Cells[2].Value.ToString();
            txtSoDT.Text = dgvNhaCC.Rows[index].Cells[3].Value.ToString(); 
            txtEmail.Text = dgvNhaCC.Rows[index].Cells[4].Value.ToString();
            txtDiaChi.Text = dgvNhaCC.Rows[index].Cells[5].Value.ToString();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidData() == false)
            {
                return;
            }
            //Lấy ra NhaCc muốn sửa
            NhaCc nccSua = db.NhaCcs.SingleOrDefault(n => n.MaNcc == txtMaNCC.Text);
            if (nccSua != null)
            {
                //Sửa thông tin của NhaCc
                nccSua.TenNcc = txtTenNCC.Text;
                nccSua.Email = txtEmail.Text;
                nccSua.NguoiLienHe = txtNguoiLienHe.Text;
                nccSua.SoDt = txtSoDT.Text;
                nccSua.DiaChi = txtDiaChi.Text;
                //Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();
                //Hiển thị lại dữ liệu
                HienThiDuLieu();
            }
            else
            {
                MessageBox.Show("Mã nhà cung cấp không tồn tại, Không thể sửa", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "" || txtMaNCC.Text == null)
            {
                errorProvider1.SetError(txtMaNCC, "Bạn cần nhập mã nhà cung cấp cần xóa");
                txtMaNCC.Focus();
                return;
            }
            //lấy ra NhaCc muốn xóa
            NhaCc nccXoa = (from n in db.NhaCcs
                            where n.MaNcc == txtMaNCC.Text
                            select n).FirstOrDefault();

            if (nccXoa == null)
            {
                MessageBox.Show("Mã nhà cung cấp không tồn tại, Không thể xóa", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var query2 = from n in db.DatHangNhaCcs
                             where n.MaNcc == txtMaNCC.Text
                             select n;
                if (query2.ToList().Count != 0)
                {
                    MessageBox.Show("Nhà cung cấp liên quan đến phiếu đặt, Không thể xóa", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                var query1 = from n in db.PhieuNhaps
                             where n.MaNcc == txtMaNCC.Text
                             select n;
                if (query1.ToList().Count != 0)
                {
                    MessageBox.Show("Nhà cung cấp liên quan đến phiếu nhập, Không thể xóa", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult tl = MessageBox.Show("Bạn muốn xóa nhà cung cấp mã " + nccXoa.MaNcc, "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    //Xóa đối tượng khỏi tập hợp 
                    db.NhaCcs.Remove(nccXoa);
                    //Cập nhật thay đổi vào csdl    
                    db.SaveChanges();
                    //Hiển thị lại dữ liệu
                    HienThiDuLieu();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên cần tìm kiếm", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var listNhaCC = from ncc in db.NhaCcs
                            where ncc.TenNcc.ToLower().Contains(txtTimKiem.Text.ToLower())
                            select new
                            {
                                ncc.MaNcc,
                                ncc.TenNcc,
                                ncc.NguoiLienHe,
                                ncc.SoDt,
                                ncc.Email,
                                ncc.DiaChi
                            };
            dgvNhaCC.DataSource = listNhaCC.ToList();

        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            var listNhaCC = from ncc in db.NhaCcs
                            select new
                            {
                                ncc.MaNcc,
                                ncc.TenNcc,
                                ncc.NguoiLienHe,
                                ncc.SoDt,
                                ncc.Email,
                                ncc.DiaChi
                            };
            dgvNhaCC.DataSource = listNhaCC.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaNCC.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtTenNCC.Text = "";
            txtNguoiLienHe.Text = "";
            txtSoDT.Text = "";
            txtTimKiem.Text = "";
        }

        private void txtTenNCC_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTenNCC, "");
        }

        private void txtNguoiLienHe_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNguoiLienHe, "");
        }

        private void txtSoDT_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSoDT, "");
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtEmail, "");
        }

        private void txtDiaChi_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtDiaChi, "");
        }
        private bool ValidData()
        {
            if (txtTenNCC.Text == "")
            {
                errorProvider1.SetError(txtTenNCC, "Bạn phải nhập tên nhà cung cấp!");
                txtTenNCC.Focus();
                return false;
            }
            else
            {
                if (txtTenNCC.Text.Length > 50)
                {
                    errorProvider1.SetError(txtTenNCC, "Mã nhà CC không quá 50 ký tự!");
                    return false;
                }
            }
            if (txtNguoiLienHe.Text == "")
            {
                errorProvider1.SetError(txtNguoiLienHe, "Bạn phải nhập tên người liên hệ!");
                txtNguoiLienHe.Focus();
                return false;
            }
            else
            {
                if (txtNguoiLienHe.Text.Length > 50)
                {
                    errorProvider1.SetError(txtNguoiLienHe, "tên người liên hệ không quá 50 ký tự!");
                    return false;
                }
            }


            if (txtSoDT.Text == "")
            {
                errorProvider1.SetError(txtSoDT, "Bạn phải nhập số điện thoại!");
                txtSoDT.Focus();
                return false;
            }
            else
            {
                Regex regex = new Regex(@"(84|0[3|5|7|8|9])+([0-9]{8})\b");
                Match match = regex.Match(txtSoDT.Text);
                if (match.Success == false)
                {

                    errorProvider1.SetError(txtSoDT, "Cú pháp không hợp lệ. Vui lòng nhập lại");
                    txtSoDT.Focus();
                    txtSoDT.SelectAll();
                    return false;
                }
            }
            //valid email
            if (txtEmail.Text == "")
            {
                errorProvider1.SetError(txtEmail, "Bạn phải nhập email!");
                txtEmail.Focus();
                return false;
            } else
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(txtEmail.Text);
                //var foo = new EmailAddressAttribute();
                //bool isValid = foo.IsValid(txtEmail.Text);
                if (match.Success==false)
                {
                    errorProvider1.SetError(txtEmail, "Cú pháp email không hợp lệ. VD: abc@gmail.com");
                    return false;
                }
                if (txtEmail.Text.Length > 40)
                {
                    errorProvider1.SetError(txtEmail, "Địa chỉ Email không quá 40 ký tự!");
                    return false;
                }
            }
            //valid DiaChi
            if (txtDiaChi.Text == "")
            {
                errorProvider1.SetError(txtDiaChi, "Bạn phải nhập địa chỉ!");
                txtDiaChi.Focus();
                return false;
            }
            else
            {
                if (txtDiaChi.Text.Length > 100)
                {
                    errorProvider1.SetError(txtDiaChi, "Địa chỉ không quá 100 ký tự!");
                    return false;
                }
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
