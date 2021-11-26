
namespace Nhom16_QuanLyBanQuanAoAdidas
{
    partial class frmDanhSachPhieuDat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHienThiChiTietPhieuDatHang = new System.Windows.Forms.Button();
            this.txtMaDH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuDat = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuDat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHienThiChiTietPhieuDatHang);
            this.groupBox1.Controls.Add(this.txtMaDH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(45, 82);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(697, 72);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết phiếu đặt hàng";
            // 
            // btnHienThiChiTietPhieuDatHang
            // 
            this.btnHienThiChiTietPhieuDatHang.Location = new System.Drawing.Point(424, 25);
            this.btnHienThiChiTietPhieuDatHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHienThiChiTietPhieuDatHang.Name = "btnHienThiChiTietPhieuDatHang";
            this.btnHienThiChiTietPhieuDatHang.Size = new System.Drawing.Size(149, 27);
            this.btnHienThiChiTietPhieuDatHang.TabIndex = 1;
            this.btnHienThiChiTietPhieuDatHang.Text = "Hiển thị chi tiết phiếu";
            this.btnHienThiChiTietPhieuDatHang.UseVisualStyleBackColor = true;
            this.btnHienThiChiTietPhieuDatHang.Click += new System.EventHandler(this.btnHienThiChiTietPhieuDatHang_Click);
            // 
            // txtMaDH
            // 
            this.txtMaDH.Location = new System.Drawing.Point(144, 30);
            this.txtMaDH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaDH.Name = "txtMaDH";
            this.txtMaDH.Size = new System.Drawing.Size(110, 23);
            this.txtMaDH.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu đặt";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(327, 369);
            this.btnDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(96, 22);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPhieuDat);
            this.groupBox2.Location = new System.Drawing.Point(45, 183);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(697, 172);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách phiếu đặt hàng";
            // 
            // dgvPhieuDat
            // 
            this.dgvPhieuDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuDat.Location = new System.Drawing.Point(35, 34);
            this.dgvPhieuDat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPhieuDat.Name = "dgvPhieuDat";
            this.dgvPhieuDat.RowHeadersWidth = 51;
            this.dgvPhieuDat.RowTemplate.Height = 29;
            this.dgvPhieuDat.Size = new System.Drawing.Size(640, 128);
            this.dgvPhieuDat.TabIndex = 9;
            this.dgvPhieuDat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuDat_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(265, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(241, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "Danh sách phiếu đặt hàng";
            // 
            // frmDanhSachPhieuDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Name = "frmDanhSachPhieuDat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDanhSachPhieuDat";
            this.Load += new System.EventHandler(this.frmDanhSachPhieuDat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuDat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHienThiChiTietPhieuDatHang;
        private System.Windows.Forms.TextBox txtMaDH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPhieuDat;
        private System.Windows.Forms.Label label6;
    }
}