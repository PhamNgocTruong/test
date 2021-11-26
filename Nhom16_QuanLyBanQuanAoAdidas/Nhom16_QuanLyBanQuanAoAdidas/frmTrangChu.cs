using Nhom16_QuanLyBanQuanAoAdidas.D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nhom16_QuanLyBanQuanAoAdidas
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }
        private bool KiemTraFormDaCo(string tenForm)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name == tenForm)
                    return true;
            }
            return false;
        }

        private void HienThiFormHienHanh(string tenForm)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name == tenForm)
                {
                    item.Activate();
                    break;
                }
            }
        }
        private void toolStripMenuItemNhaCC_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)this.Tag;
            if (!KiemTraFormDaCo("frmQuanLyNCC"))
            {
                frmQuanLyNCC form = new frmQuanLyNCC();
                form.MdiParent = this;
                form.Tag = tk;
                form.Show();
            }
            else
                HienThiFormHienHanh("frmQuanLyNCC");
        }

        private void toolStripMenuItemLapPhieuNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)this.Tag;
            if (!KiemTraFormDaCo("Form1"))
            {
                Form1 form = new Form1();
                form.MdiParent = this;
                form.Tag = tk;
                form.Show();
            }
            else
                HienThiFormHienHanh("Form1");
        }

        private void toolStripMenuItemPhieuNhap_Click(object sender, EventArgs e)
        {
            if (!KiemTraFormDaCo("frmDSPhieuNhap"))
            {
                frmDSPhieuNhap form = new frmDSPhieuNhap();
                form.MdiParent = this;
                form.Show();
            }
            else
                HienThiFormHienHanh("frmDSPhieuNhap");
        }

        private void toolStripMenuItemDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap form = new frmDangNhap();
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItemDatHang_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)this.Tag;
            if (!KiemTraFormDaCo("frmPhieuDatHangNCC"))
            {
                frmPhieuDatHangNCC form = new frmPhieuDatHangNCC();
                form.MdiParent = this;
                form.Tag = tk;
                form.Show();
            }
            else
                HienThiFormHienHanh("frmPhieuDatHangNCC");
        }

        private void toolStripMenuItemPhieuDatHang_Click(object sender, EventArgs e)
        {
            if (!KiemTraFormDaCo("frmDanhSachPhieuDat"))
            {
                frmDanhSachPhieuDat form = new frmDanhSachPhieuDat();
                form.MdiParent = this;
                form.Show();
            }
            else
                HienThiFormHienHanh("frmDanhSachPhieuDat");
        }

        private void toolStripMenuItemBaoCaoNhap_Click(object sender, EventArgs e)
        {
            if (!KiemTraFormDaCo("frmBaoCaoNhap"))
            {
                frmBaoCaoNhap form = new frmBaoCaoNhap();
                form.MdiParent = this;
                form.Show();
            }
            else
                HienThiFormHienHanh("frmBaoCaoNhap");
        }

        private void toolStripMenuItemBaoCaoXuat_Click(object sender, EventArgs e)
        {
            if (!KiemTraFormDaCo("frmBaoCaoNhap"))
            {
                frmBaoCaoXuat form = new frmBaoCaoXuat();
                form.MdiParent = this;
                form.Show();
            }
            else
                HienThiFormHienHanh("frmBaoCaoXuat");
        }
    }
}
