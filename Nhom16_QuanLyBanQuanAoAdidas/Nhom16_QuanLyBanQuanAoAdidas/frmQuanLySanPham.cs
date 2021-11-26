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

    public partial class frmQuanLySanPham : Form
    {
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        public frmQuanLySanPham()
        {

            InitializeComponent();
        }
        #region Kiểm tra dữ liệu người dùng nhập
        private void txtMaSP_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMaSP, "");
        }
        private void txtTenSP_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTenSP, "");
        }
        private void txtGiaBan_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtGiaBan, "");
        }
        private void grbSize_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(grbSize, "");
        }
        private void grbMau_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(grbMau, "");
        }
        private void txtSoLuongCon_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtSoLuong, "");
        }
        private void cbxTenLoai_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbxTenLoai, "");
        }
        private bool ValidData()
        {
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
            if (txtTenSP.Text == "")
            {
                errorProvider1.SetError(txtTenSP, "Bạn phải nhập tên sản phẩm!");
                txtTenSP.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(txtTenSP, null);
            }

            if (txtGiaBan.Text == "")
            {
                errorProvider1.SetError(txtGiaBan, "Bạn phải nhập  giá bán sản phẩm!");
                txtGiaBan.Focus();
                return false;
            }
            else
            {

                try
                {
                    double.Parse(txtGiaBan.Text);
                    if (double.Parse(txtGiaBan.Text) < 0)
                    {
                        errorProvider1.SetError(txtGiaBan, "Bạn phải nhập giá bán >0 !");
                        txtGiaBan.Focus();
                        txtGiaBan.SelectAll();
                        return false;
                    }
                }
                catch
                {
                    errorProvider1.SetError(txtGiaBan, "Bạn phải nhập giá bán là số !");
                    txtGiaBan.Focus();
                    txtGiaBan.SelectAll();
                    return false;
                }
                errorProvider1.SetError(txtGiaBan, null);

            }

            if (ckbM.Checked == false && ckbL.Checked == false && ckbXL.Checked == false && ckbXXL.Checked == false)
            {
                errorProvider1.SetError(grbSize, "Bạn phải chọn size!");
                grbSize.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(grbSize, null);

            }
            if (ckbDen.Checked == false && ckbDo.Checked == false && ckbTrang.Checked == false && ckbKhac.Checked == false)
            {
                errorProvider1.SetError(grbMau, "Bạn phải chọn màu!");
                grbMau.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(grbMau, null);

            }

            if (txtSoLuong.Text == "")
            {
                errorProvider1.SetError(txtSoLuong, "Bạn phải nhập số lượng sản phẩm!");
                txtSoLuong.Focus();
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtSoLuong.Text);
                    if (int.Parse(txtSoLuong.Text) < 0)
                    {
                        errorProvider1.SetError(txtSoLuong, "Bạn phải nhập số lượng >0 !");
                        txtSoLuong.Focus();
                        txtSoLuong.SelectAll();
                        return false;
                    }
                }
                catch
                {
                    errorProvider1.SetError(txtSoLuong, "Bạn phải nhập số lượng là số nguyên!");
                    txtSoLuong.Focus();
                    txtSoLuong.SelectAll();
                    return false;
                }
                errorProvider1.SetError(txtSoLuong, null);

            }
            if (cbxTenLoai.Text == "")
            {
                errorProvider1.SetError(cbxTenLoai, "Bạn phải nhập mã loại sản phẩm!");
                cbxTenLoai.Focus();
                return false;
            }
            else
            {
                errorProvider1.SetError(cbxTenLoai, null);

            }

            return true;
        }
        #endregion


        public void HienThi()
        {
            var query = from sp in db.SanPhams
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.GiaBan,
                            sp.Size,
                            sp.Mau,
                            sp.Slcon,
                            sp.MaLoaiNavigation.TenLoai
                        };

            dgvQLSanPham.DataSource = query.ToList();
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            var comboQuery = from l in db.LoaiSps
                             select l;
            cbxTenLoai.DataSource = comboQuery.ToList();
            cbxTenLoai.DisplayMember = "TenLoai";
            cbxTenLoai.ValueMember = "MaLoai";
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            HienThi();
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var query = from sp in db.SanPhams
                        where sp.MaSp == txtMaSP.Text
                        select sp;

            if (query.ToList().Count > 0)
            {
                MessageBox.Show("Trùng mã sản phẩm, Không thể thêm", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ValidData())
                {
                    //Tạo đối tượng SanPham muốn thêm
                    SanPham spmoi = new SanPham();
                    //gán thuộc tính cho đối tượng SanPham là dữ liệu user nhập vào
                    spmoi.MaSp = txtMaSP.Text;
                    spmoi.TenSp = txtTenSP.Text;
                    spmoi.GiaBan = int.Parse(txtGiaBan.Text);
                    if (ckbM.Checked )
                    {
                        spmoi.Size = "M";
                    }
                    else if (ckbL.Checked)
                    {
                        spmoi.Size = "L";
                    }
                    else if (ckbXL.Checked)
                    {
                        spmoi.Size = "XL";
                    }
                    else if (ckbXXL.Checked)
                    {
                        spmoi.Size = "XXL";
                    }
                    if (ckbM.Checked && ckbL.Checked)
                    {
                        spmoi.Size = "M , L";
                    }
                    if (ckbM.Checked && ckbXL.Checked)
                    {
                        spmoi.Size = "M ,XL";
                    }
                    else if (ckbM.Checked && ckbXXL.Checked)
                    {
                        spmoi.Size = "M,XXL";
                    }
                    else if (ckbL.Checked && ckbXL.Checked)
                    {
                        spmoi.Size = "L,XL";
                    }
                    else if (ckbL.Checked && ckbXXL.Checked)
                    {
                        spmoi.Size = "L,XXL";
                    }
                    else if (ckbXL.Checked && ckbXXL.Checked)
                    {
                        spmoi.Size = "XL,XXL";
                    }
                    else if (ckbM.Checked && ckbL.Checked && ckbXL.Checked)
                    {
                        spmoi.Size = "M,L,XL";
                    }
                    else if (ckbM.Checked && ckbXL.Checked && ckbXXL.Checked)
                    {
                        spmoi.Size = "M,XL,XXL";
                    }
                    else if (ckbL.Checked && ckbXL.Checked && ckbXXL.Checked)
                    {
                        spmoi.Size = "L,XL,XXL";
                    }
                    if (ckbDen.Checked)
                    {
                        spmoi.Mau = "Đen";
                    }
                    else if (ckbDo.Checked)
                    {
                        spmoi.Mau = "Đỏ";
                    }
                    else if (ckbTrang.Checked)
                    {
                        spmoi.Mau = "Trắng";
                    }
                    else if (ckbKhac.Checked)
                    {
                        spmoi.Mau = "Khác";
                    }
                    if(ckbDen.Checked && ckbDo.Checked)
                    {
                        spmoi.Mau = "Đen , Đỏ";
                    }
                    if (ckbDen.Checked && ckbTrang.Checked)
                    {
                        spmoi.Mau = "Đen , Trắng";
                    }
                    if (ckbDen.Checked && ckbKhac.Checked)
                    {
                        spmoi.Mau = "Đen , Khác";
                    }
                    if (ckbDo.Checked && ckbTrang.Checked)
                    {
                        spmoi.Mau = "Đỏ, Trắng";
                    }
                    if (ckbDo.Checked && ckbKhac.Checked)
                    {
                        spmoi.Mau = "Đỏ , Khác";
                    }
                    if (ckbTrang.Checked && ckbKhac.Checked)
                    {
                        spmoi.Mau = "Trắng,Khác";
                    }
                    if (ckbDen.Checked && ckbDo.Checked && ckbTrang.Checked)
                    {
                        spmoi.Mau = "Đen, Đỏ,Trắng";
                    }
                    if (ckbDen.Checked && ckbTrang.Checked && ckbKhac.Checked)
                    {
                        spmoi.Mau = "Đen,Trắng,Khác";
                    }
                    if (ckbDo.Checked && ckbTrang.Checked && ckbKhac.Checked)
                    {
                        spmoi.Mau = "Đỏ,Trắng,Khác";
                    }
                    spmoi.Slcon = int.Parse(txtSoLuong.Text);
                    spmoi.MaLoai = int.Parse(cbxTenLoai.SelectedValue.ToString());
                    //Thêm sản phẩm mới vào tập hợp SanPham của context
                    db.SanPhams.Add(spmoi);
                    //Cập nhật lên csdl
                    db.SaveChanges();
                    //Hiển thị lại dữ liệu lên datagrid view
                    HienThi();
                    txtMaSP.Focus();
                    txtMaSP.Clear();
                    txtTenSP.Clear();
                    txtGiaBan.Clear();
                    txtSoLuong.Clear();
                    cbxTenLoai.Items.Clear();
                }

            }

                

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Lấy ra SanPham muốn sửa
            SanPham spSua = db.SanPhams.SingleOrDefault(n => n.MaSp == txtMaSP.Text);
            if (ValidData())
            {
                //Sửa thông tin của SanPham
                spSua.TenSp = txtTenSP.Text;
                spSua.GiaBan = int.Parse(txtGiaBan.Text);
                if (ckbM.Checked)
                {
                    spSua.Size = "M";
                }
                else if (ckbL.Checked)
                {
                    spSua.Size = "L";
                }
                else if (ckbXL.Checked)
                {
                    spSua.Size = "XL";
                }
                else if (ckbXXL.Checked)
                {
                    spSua.Size = "XXL";
                }
                if (ckbM.Checked && ckbL.Checked)
                {
                    spSua.Size = "M , L";
                }
                if (ckbM.Checked && ckbXL.Checked)
                {
                    spSua.Size = "M ,XL";
                }
                else if (ckbM.Checked && ckbXXL.Checked)
                {
                    spSua.Size = "M,XXL";
                }
                else if (ckbL.Checked && ckbXL.Checked)
                {
                    spSua.Size = "L,XL";
                }
                else if (ckbL.Checked && ckbXXL.Checked)
                {
                    spSua.Size = "L,XXL";
                }
                else if (ckbXL.Checked && ckbXXL.Checked)
                {
                    spSua.Size = "XL,XXL";
                }
                else if (ckbM.Checked && ckbL.Checked && ckbXL.Checked)
                {
                    spSua.Size = "M,L,XL";
                }
                else if (ckbM.Checked && ckbXL.Checked && ckbXXL.Checked)
                {
                    spSua.Size = "M,XL,XXL";
                }
                else if (ckbL.Checked && ckbXL.Checked && ckbXXL.Checked)
                {
                    spSua.Size = "L,XL,XXL";
                }

                if (ckbDen.Checked)
                {
                    spSua.Mau = "Đen";
                }
                else if (ckbDo.Checked)
                {
                    spSua.Mau = "Đỏ";
                }
                else if (ckbTrang.Checked)
                {
                    spSua.Mau = "Trắng";
                }
                else if (ckbKhac.Checked)
                {
                    spSua.Mau = "Khác";
                }
                if (ckbDen.Checked && ckbDo.Checked)
                {
                    spSua.Mau = "Đen , Đỏ";
                }
                if (ckbDen.Checked && ckbTrang.Checked)
                {
                    spSua.Mau = "Đen , Trắng";
                }
                if (ckbDen.Checked && ckbKhac.Checked)
                {
                    spSua.Mau = "Đen , Khác";
                }
                if (ckbDo.Checked && ckbTrang.Checked)
                {
                    spSua.Mau = "Đỏ, Trắng";
                }
                if (ckbDo.Checked && ckbKhac.Checked)
                {
                    spSua.Mau = "Đỏ , Khác";
                }
                if (ckbTrang.Checked && ckbKhac.Checked)
                {
                    spSua.Mau = "Trắng,Khác";
                }
                if (ckbDen.Checked && ckbDo.Checked && ckbTrang.Checked)
                {
                    spSua.Mau = "Đen, Đỏ,Trắng";
                }
                if (ckbDen.Checked && ckbTrang.Checked && ckbKhac.Checked)
                {
                    spSua.Mau = "Đen,Trắng,Khác";
                }
                if (ckbDo.Checked && ckbTrang.Checked && ckbKhac.Checked)
                {
                    spSua.Mau = "Đỏ,Trắng,Khác";
                }
                spSua.Slcon = Convert.ToInt32(txtSoLuong.Text);
                spSua.MaLoai = int.Parse(cbxTenLoai.SelectedValue.ToString());
                //Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();
                //Hiển thị lại dữ liệu
                HienThi();
                txtMaSP.Focus();
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtGiaBan.Clear();
                txtSoLuong.Clear();
                cbxTenLoai.Items.Clear();

            }
            else
            {
                MessageBox.Show("Mã sản phẩm không tồn tại, Không thể sửa", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            txtMaSP.Text = dgvQLSanPham.Rows[index].Cells[0].Value.ToString();
            txtTenSP.Text = dgvQLSanPham.Rows[index].Cells[1].Value.ToString();
            txtGiaBan.Text = dgvQLSanPham.Rows[index].Cells[2].Value.ToString();
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("M"))
            {
                ckbM.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("L"))
            {
                ckbL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("XL"))
            {
                ckbXL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("XXL"))
            {
                ckbXXL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("M , L"))
            {
                ckbM.Checked = true; ckbL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("M ,XL"))
            {
                ckbM.Checked = true;
                ckbXL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("M,XXL"))
            {
                ckbM.Checked = true;
                ckbXXL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("L,XL"))
            {
                ckbL.Checked = true;
                ckbXL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("L,XXL"))
            {
                ckbL.Checked = true;
                ckbXXL.Checked = true;
            }
            if(dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("XL,XXL"))
            {
                ckbXL.Checked = true;
                ckbXXL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("M,L,XL"))
            {
                ckbM.Checked = true;
                ckbL.Checked = true;
                ckbXL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("M,XL,XXL"))
            {
                ckbM.Checked = true;
                ckbXL.Checked = true;
                ckbXXL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[3].Value.ToString().Equals("L,XL,XXL"))
            {
                ckbL.Checked = true;
                ckbXL.Checked = true;
                ckbXXL.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Đen"))
            {
                ckbDen.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Đỏ"))
            {
                ckbDo.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Trắng"))
            {
                ckbTrang.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Khác"))
            {
                ckbKhac.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Đen , Đỏ"))
            {
                ckbDen.Checked = true;
                ckbDo.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Đen , Trắng"))
            {
                ckbDen.Checked = true;
                ckbTrang.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Đen , Khác"))
            {
                ckbDen.Checked = true;
                ckbKhac.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Đỏ, Trắng"))
            {
                ckbDo.Checked = true;
                ckbTrang.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Đỏ , Khác"))
            {
                ckbDo.Checked = true;
                ckbKhac.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Trắng,Khác"))
            {
                ckbTrang.Checked = true;
                ckbKhac.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Đen, Đỏ,Trắng"))
            {
                ckbDen.Checked = true;
                ckbDo.Checked = true;
                ckbTrang.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Đen,Trắng,Khác"))
            {
                ckbDen.Checked = true;
                ckbTrang.Checked = true;
                ckbKhac.Checked = true;
            }
            if (dgvQLSanPham.Rows[index].Cells[4].Value.ToString().Equals("Đỏ,Trắng,Khác"))
            {
                ckbDo.Checked = true;
                ckbTrang.Checked = true;
                ckbKhac.Checked = true;
            }
            LoaiSp lsp = db.LoaiSps.Where(s => s.TenLoai == dgvQLSanPham.Rows[index].Cells[6].Value.ToString()).FirstOrDefault();
            cbxTenLoai.Text = lsp.TenLoai;
            txtSoLuong.Text = dgvQLSanPham.Rows[index].Cells[5].Value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //lấy ra SanPham muốn xóa
            SanPham spXoa = (from n in db.SanPhams
                             where n.MaSp == txtMaSP.Text
                             select n).FirstOrDefault();

            if (spXoa == null)
            {
                MessageBox.Show("Mã sản phẩm không tồn tại, Không thể xóa", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult tl = MessageBox.Show("Bạn muốn xóa sản phẩm có mã " + spXoa.MaSp, "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    //Xóa đối tượng khỏi tập hợp 
                    db.SanPhams.Remove(spXoa);
                    //Cập nhật thay đổi vào csdl    
                    db.SaveChanges();
                    //Hiển thị lại dữ liệu
                    HienThi();
                }
            }
            txtMaSP.Focus();
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            cbxTenLoai.Items.Clear();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Lấy dữ liệu từ bảng SanPhams
            var query = from sp in db.SanPhams
                        where sp.MaSp == txtTimKiem.Text
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.GiaBan,
                            sp.Size,
                            sp.Mau,
                            sp.Slcon,
                            sp.MaLoaiNavigation.TenLoai
                        };
            //Hiển thị lên datagrid view
            dgvQLSanPham.DataSource = query.ToList();
            txtMaSP.Focus();
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            cbxTenLoai.Items.Clear();

        }
    }
}

