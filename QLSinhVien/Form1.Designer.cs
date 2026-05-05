using System;

namespace QLSinhVien
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.labelKhoa = new System.Windows.Forms.Label();
            this.txtNganh = new System.Windows.Forms.TextBox();
            this.labelNganh = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBoxChucNang = new System.Windows.Forms.GroupBox();
            this.btnXepLop = new System.Windows.Forms.Button();
            this.btnKhenThuong = new System.Windows.Forms.Button();
            this.btnKyLuat = new System.Windows.Forms.Button();
            this.btnHocBong = new System.Windows.Forms.Button();
            this.btnBaoLuu = new System.Windows.Forms.Button();
            this.btnThoiHoc = new System.Windows.Forms.Button();
            this.btnRutHoSo = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.cboThongKe = new System.Windows.Forms.ComboBox();
            this.labelThongKe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(327, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm sinh viên";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 560);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1020, 250);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbGioiTinh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtNgaySinh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtLop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtKhoa);
            this.groupBox1.Controls.Add(this.labelKhoa);
            this.groupBox1.Controls.Add(this.txtNganh);
            this.groupBox1.Controls.Add(this.labelNganh);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 300);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbGioiTinh.Location = new System.Drawing.Point(93, 139);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(121, 21);
            this.cbGioiTinh.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Giới tính";
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.Location = new System.Drawing.Point(93, 101);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(211, 20);
            this.dtNgaySinh.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ngày sinh";
            // 
            // txtLop
            // 
            this.txtLop.Location = new System.Drawing.Point(93, 59);
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new System.Drawing.Size(182, 20);
            this.txtLop.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lớp";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(327, 72);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(106, 23);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa sinh viên";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(93, 22);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(182, 20);
            this.txtTen.TabIndex = 9;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(327, 129);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(106, 23);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa sinh viên";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tên SV";
            // 
            // txtKhoa
            // 
            this.txtKhoa.Location = new System.Drawing.Point(93, 176);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.Size = new System.Drawing.Size(182, 20);
            this.txtKhoa.TabIndex = 14;
            // 
            // labelKhoa
            // 
            this.labelKhoa.AutoSize = true;
            this.labelKhoa.Location = new System.Drawing.Point(8, 176);
            this.labelKhoa.Name = "labelKhoa";
            this.labelKhoa.Size = new System.Drawing.Size(32, 13);
            this.labelKhoa.TabIndex = 15;
            this.labelKhoa.Text = "Khoa";
            // 
            // txtNganh
            // 
            this.txtNganh.Location = new System.Drawing.Point(93, 213);
            this.txtNganh.Name = "txtNganh";
            this.txtNganh.Size = new System.Drawing.Size(182, 20);
            this.txtNganh.TabIndex = 16;
            // 
            // labelNganh
            // 
            this.labelNganh.AutoSize = true;
            this.labelNganh.Location = new System.Drawing.Point(8, 213);
            this.labelNganh.Name = "labelNganh";
            this.labelNganh.Size = new System.Drawing.Size(39, 13);
            this.labelNganh.TabIndex = 17;
            this.labelNganh.Text = "Ngành";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(202, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm sinh viên";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(314, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 20);
            this.txtSearch.TabIndex = 6;
            // 
            // groupBoxChucNang
            // 
            this.groupBoxChucNang.Controls.Add(this.btnXepLop);
            this.groupBoxChucNang.Controls.Add(this.btnKhenThuong);
            this.groupBoxChucNang.Controls.Add(this.btnKyLuat);
            this.groupBoxChucNang.Controls.Add(this.btnHocBong);
            this.groupBoxChucNang.Controls.Add(this.btnBaoLuu);
            this.groupBoxChucNang.Controls.Add(this.btnThoiHoc);
            this.groupBoxChucNang.Controls.Add(this.btnRutHoSo);
            this.groupBoxChucNang.Controls.Add(this.btnThongKe);
            this.groupBoxChucNang.Controls.Add(this.cboThongKe);
            this.groupBoxChucNang.Controls.Add(this.labelThongKe);
            this.groupBoxChucNang.Location = new System.Drawing.Point(536, 50);
            this.groupBoxChucNang.Name = "groupBoxChucNang";
            this.groupBoxChucNang.Size = new System.Drawing.Size(502, 300);
            this.groupBoxChucNang.TabIndex = 7;
            this.groupBoxChucNang.TabStop = false;
            this.groupBoxChucNang.Text = "Chức năng quản lý";
            // 
            // btnXepLop
            // 
            this.btnXepLop.Location = new System.Drawing.Point(20, 30);
            this.btnXepLop.Name = "btnXepLop";
            this.btnXepLop.Size = new System.Drawing.Size(140, 30);
            this.btnXepLop.TabIndex = 0;
            this.btnXepLop.Text = "📚 Xếp lớp";
            this.btnXepLop.UseVisualStyleBackColor = true;
            this.btnXepLop.Click += new System.EventHandler(this.btnXepLop_Click);
            // 
            // btnKhenThuong
            // 
            this.btnKhenThuong.Location = new System.Drawing.Point(180, 30);
            this.btnKhenThuong.Name = "btnKhenThuong";
            this.btnKhenThuong.Size = new System.Drawing.Size(140, 30);
            this.btnKhenThuong.TabIndex = 1;
            this.btnKhenThuong.Text = "🏆 Khen thưởng";
            this.btnKhenThuong.UseVisualStyleBackColor = true;
            this.btnKhenThuong.Click += new System.EventHandler(this.btnKhenThuong_Click);
            // 
            // btnKyLuat
            // 
            this.btnKyLuat.Location = new System.Drawing.Point(340, 30);
            this.btnKyLuat.Name = "btnKyLuat";
            this.btnKyLuat.Size = new System.Drawing.Size(140, 30);
            this.btnKyLuat.TabIndex = 2;
            this.btnKyLuat.Text = "⚠️ Kỷ luật";
            this.btnKyLuat.UseVisualStyleBackColor = true;
            this.btnKyLuat.Click += new System.EventHandler(this.btnKyLuat_Click);
            // 
            // btnHocBong
            // 
            this.btnHocBong.Location = new System.Drawing.Point(20, 80);
            this.btnHocBong.Name = "btnHocBong";
            this.btnHocBong.Size = new System.Drawing.Size(140, 30);
            this.btnHocBong.TabIndex = 3;
            this.btnHocBong.Text = "💰 Học bổng";
            this.btnHocBong.UseVisualStyleBackColor = true;
            this.btnHocBong.Click += new System.EventHandler(this.btnHocBong_Click);
            // 
            // btnBaoLuu
            // 
            this.btnBaoLuu.Location = new System.Drawing.Point(180, 80);
            this.btnBaoLuu.Name = "btnBaoLuu";
            this.btnBaoLuu.Size = new System.Drawing.Size(140, 30);
            this.btnBaoLuu.TabIndex = 4;
            this.btnBaoLuu.Text = "📦 Bảo lưu";
            this.btnBaoLuu.UseVisualStyleBackColor = true;
            this.btnBaoLuu.Click += new System.EventHandler(this.btnBaoLuu_Click);
            // 
            // btnThoiHoc
            // 
            this.btnThoiHoc.Location = new System.Drawing.Point(340, 80);
            this.btnThoiHoc.Name = "btnThoiHoc";
            this.btnThoiHoc.Size = new System.Drawing.Size(140, 30);
            this.btnThoiHoc.TabIndex = 5;
            this.btnThoiHoc.Text = "🚫 Thôi học";
            this.btnThoiHoc.UseVisualStyleBackColor = true;
            this.btnThoiHoc.Click += new System.EventHandler(this.btnThoiHoc_Click);
            // 
            // btnRutHoSo
            // 
            this.btnRutHoSo.Location = new System.Drawing.Point(20, 130);
            this.btnRutHoSo.Name = "btnRutHoSo";
            this.btnRutHoSo.Size = new System.Drawing.Size(140, 30);
            this.btnRutHoSo.TabIndex = 6;
            this.btnRutHoSo.Text = "📄 Rút hồ sơ";
            this.btnRutHoSo.UseVisualStyleBackColor = true;
            this.btnRutHoSo.Click += new System.EventHandler(this.btnRutHoSo_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(340, 200);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(140, 30);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "📊 Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // cboThongKe
            // 
            this.cboThongKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThongKe.Items.AddRange(new object[] {
            "Theo lớp",
            "Theo khoa",
            "Theo ngành",
            "Theo trạng thái"});
            this.cboThongKe.Location = new System.Drawing.Point(110, 202);
            this.cboThongKe.Name = "cboThongKe";
            this.cboThongKe.Size = new System.Drawing.Size(210, 21);
            this.cboThongKe.TabIndex = 8;
            // 
            // labelThongKe
            // 
            this.labelThongKe.AutoSize = true;
            this.labelThongKe.Location = new System.Drawing.Point(17, 205);
            this.labelThongKe.Name = "labelThongKe";
            this.labelThongKe.Size = new System.Drawing.Size(74, 13);
            this.labelThongKe.TabIndex = 9;
            this.labelThongKe.Text = "Chọn tiêu chí:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 830);
            this.Controls.Add(this.groupBoxChucNang);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxChucNang.ResumeLayout(false);
            this.groupBoxChucNang.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.Label labelKhoa;
        private System.Windows.Forms.TextBox txtNganh;
        private System.Windows.Forms.Label labelNganh;
        private System.Windows.Forms.GroupBox groupBoxChucNang;
        private System.Windows.Forms.Button btnXepLop;
        private System.Windows.Forms.Button btnKhenThuong;
        private System.Windows.Forms.Button btnKyLuat;
        private System.Windows.Forms.Button btnHocBong;
        private System.Windows.Forms.Button btnBaoLuu;
        private System.Windows.Forms.Button btnThoiHoc;
        private System.Windows.Forms.Button btnRutHoSo;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.ComboBox cboThongKe;
        private System.Windows.Forms.Label labelThongKe;
    }
}