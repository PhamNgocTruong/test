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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        QLQuanAoAdidasContext db = new QLQuanAoAdidasContext();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var query = from t in db.TaiKhoans
                        where t.TenTaiKhoan == txtTenTaiKhoan.Text && t.MatKhau == txtMatKhau.Text
                        select t;
            if(query.ToList().Count == 0)
            {
                MessageBox.Show("Đăng nhập thất bại");
            } else
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo ");
                frmTrangChu form = new frmTrangChu();
                form.Tag = query.FirstOrDefault(); 
                form.Show();
                this.Hide();
            }
        }


    }
}
