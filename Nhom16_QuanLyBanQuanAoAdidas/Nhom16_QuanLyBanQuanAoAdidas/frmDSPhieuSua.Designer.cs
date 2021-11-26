
namespace Nhom16_QuanLyBanQuanAoAdidas
{
    partial class frmDSPhieuSua
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
            this.btnTim = new System.Windows.Forms.Button();
            this.btnHienThiChiTietPhieu = new System.Windows.Forms.Button();
            this.txtMaSua = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPhieuSua = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuSua)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.btnHienThiChiTietPhieu);
            this.groupBox1.Controls.Add(this.txtMaSua);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(52, 86);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(697, 72);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết phiếu sửa";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(282, 31);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 27;
            this.btnTim.Text = "Tìm Kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnHienThiChiTietPhieu
            // 
            this.btnHienThiChiTietPhieu.Location = new System.Drawing.Point(426, 29);
            this.btnHienThiChiTietPhieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHienThiChiTietPhieu.Name = "btnHienThiChiTietPhieu";
            this.btnHienThiChiTietPhieu.Size = new System.Drawing.Size(149, 22);
            this.btnHienThiChiTietPhieu.TabIndex = 18;
            this.btnHienThiChiTietPhieu.Text = "Hiển thị chi tiết phiếu";
            this.btnHienThiChiTietPhieu.UseVisualStyleBackColor = true;
            this.btnHienThiChiTietPhieu.Click += new System.EventHandler(this.btnHienThiChiTietPhieu_Click);
            // 
            // txtMaSua
            // 
            this.txtMaSua.Location = new System.Drawing.Point(144, 30);
            this.txtMaSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSua.Name = "txtMaSua";
            this.txtMaSua.Size = new System.Drawing.Size(110, 23);
            this.txtMaSua.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Sửa Hàng";
            // 
            // dgvPhieuSua
            // 
            this.dgvPhieuSua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuSua.Location = new System.Drawing.Point(35, 34);
            this.dgvPhieuSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPhieuSua.Name = "dgvPhieuSua";
            this.dgvPhieuSua.RowHeadersWidth = 51;
            this.dgvPhieuSua.RowTemplate.Height = 29;
            this.dgvPhieuSua.Size = new System.Drawing.Size(640, 128);
            this.dgvPhieuSua.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(334, 373);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 39);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPhieuSua);
            this.groupBox2.Location = new System.Drawing.Point(52, 187);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(697, 172);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách phiếu sửa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(272, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "Danh sách phiếu sửa hàng";
            // 
            // frmDSPhieuSua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Name = "frmDSPhieuSua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDSPhieuSua";
            this.Load += new System.EventHandler(this.frmDSPhieuSua_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuSua)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHienThiChiTietPhieu;
        private System.Windows.Forms.TextBox txtMaSua;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPhieuSua;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTim;
    }
}