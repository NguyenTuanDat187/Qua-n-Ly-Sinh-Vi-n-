using System;
using System.Windows.Forms;

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
            this.cbHocBong = new System.Windows.Forms.ComboBox();
            this.labelHocBong = new System.Windows.Forms.Label();
            this.chkKhenThuong = new System.Windows.Forms.CheckBox();
            this.chkKyLuat = new System.Windows.Forms.CheckBox();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.labelLop = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.labelKhoa = new System.Windows.Forms.Label();
            this.txtNganh = new System.Windows.Forms.TextBox();
            this.labelNganh = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBoxChucNang = new System.Windows.Forms.GroupBox();
            this.groupBoxThongKe = new System.Windows.Forms.GroupBox();
            this.lstThongKe = new System.Windows.Forms.ListBox();
            this.cboThongKe = new System.Windows.Forms.ComboBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.groupBoxQuanLy = new System.Windows.Forms.GroupBox();
            this.btnAutoCreateClass = new System.Windows.Forms.Button();
            this.cboSoLuongLop = new System.Windows.Forms.ComboBox();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxChucNang.SuspendLayout();
            this.groupBoxThongKe.SuspendLayout();
            this.groupBoxQuanLy.SuspendLayout();
            this.SuspendLayout();

            // ============== KHUNG THÔNG TIN SINH VIÊN ==============
            this.groupBox1.Controls.Add(this.cbHocBong);
            this.groupBox1.Controls.Add(this.labelHocBong);
            this.groupBox1.Controls.Add(this.chkKhenThuong);
            this.groupBox1.Controls.Add(this.chkKyLuat);
            this.groupBox1.Controls.Add(this.cbLop);
            this.groupBox1.Controls.Add(this.labelLop);
            this.groupBox1.Controls.Add(this.cbTrangThai);
            this.groupBox1.Controls.Add(this.labelTrangThai);
            this.groupBox1.Controls.Add(this.cbGioiTinh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtNgaySinh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtKhoa);
            this.groupBox1.Controls.Add(this.labelKhoa);
            this.groupBox1.Controls.Add(this.txtNganh);
            this.groupBox1.Controls.Add(this.labelNganh);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 280);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên (Chọn dòng phía dưới để Sửa/Xem)";

            // Cột 1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tên SV:";

            this.txtTen.Location = new System.Drawing.Point(80, 21);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(180, 20);
            this.txtTen.TabIndex = 9;

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ngày sinh:";

            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgaySinh.Location = new System.Drawing.Point(80, 53);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(180, 20);
            this.dtNgaySinh.TabIndex = 11;

            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Giới tính:";

            this.cbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            this.cbGioiTinh.Location = new System.Drawing.Point(80, 85);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(180, 21);
            this.cbGioiTinh.TabIndex = 13;

            this.labelKhoa.AutoSize = true;
            this.labelKhoa.Location = new System.Drawing.Point(10, 120);
            this.labelKhoa.Name = "labelKhoa";
            this.labelKhoa.Size = new System.Drawing.Size(35, 13);
            this.labelKhoa.TabIndex = 15;
            this.labelKhoa.Text = "Khoa:";

            this.txtKhoa.Location = new System.Drawing.Point(80, 117);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.Size = new System.Drawing.Size(180, 20);
            this.txtKhoa.TabIndex = 14;

            this.labelNganh.AutoSize = true;
            this.labelNganh.Location = new System.Drawing.Point(10, 152);
            this.labelNganh.Name = "labelNganh";
            this.labelNganh.Size = new System.Drawing.Size(42, 13);
            this.labelNganh.TabIndex = 17;
            this.labelNganh.Text = "Ngành:";

            this.txtNganh.Location = new System.Drawing.Point(80, 149);
            this.txtNganh.Name = "txtNganh";
            this.txtNganh.Size = new System.Drawing.Size(180, 20);
            this.txtNganh.TabIndex = 16;

            this.labelTrangThai.AutoSize = true;
            this.labelTrangThai.Location = new System.Drawing.Point(10, 184);
            this.labelTrangThai.Name = "labelTrangThai";
            this.labelTrangThai.Size = new System.Drawing.Size(58, 13);
            this.labelTrangThai.TabIndex = 18;
            this.labelTrangThai.Text = "Trạng thái:";

            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(80, 181);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(180, 21);
            this.cbTrangThai.TabIndex = 19;

            this.labelLop.AutoSize = true;
            this.labelLop.Location = new System.Drawing.Point(10, 216);
            this.labelLop.Name = "labelLop";
            this.labelLop.Size = new System.Drawing.Size(28, 13);
            this.labelLop.TabIndex = 20;
            this.labelLop.Text = "Lớp:";

            this.cbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(80, 213);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(180, 21);
            this.cbLop.TabIndex = 21;

            // Cột 2
            this.labelHocBong.AutoSize = true;
            this.labelHocBong.Location = new System.Drawing.Point(280, 24);
            this.labelHocBong.Name = "labelHocBong";
            this.labelHocBong.Size = new System.Drawing.Size(57, 13);
            this.labelHocBong.TabIndex = 22;
            this.labelHocBong.Text = "Học bổng:";

            this.cbHocBong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHocBong.FormattingEnabled = true;
            this.cbHocBong.Location = new System.Drawing.Point(360, 21);
            this.cbHocBong.Name = "cbHocBong";
            this.cbHocBong.Size = new System.Drawing.Size(180, 21);
            this.cbHocBong.TabIndex = 23;

            this.chkKhenThuong.AutoSize = true;
            this.chkKhenThuong.Location = new System.Drawing.Point(283, 56);
            this.chkKhenThuong.Name = "chkKhenThuong";
            this.chkKhenThuong.Size = new System.Drawing.Size(102, 17);
            this.chkKhenThuong.TabIndex = 25;
            this.chkKhenThuong.Text = "Có khen thưởng";
            this.chkKhenThuong.UseVisualStyleBackColor = true;

            this.chkKyLuat.AutoSize = true;
            this.chkKyLuat.Location = new System.Drawing.Point(283, 88);
            this.chkKyLuat.Name = "chkKyLuat";
            this.chkKyLuat.Size = new System.Drawing.Size(72, 17);
            this.chkKyLuat.TabIndex = 27;
            this.chkKyLuat.Text = "Bị kỷ luật";
            this.chkKyLuat.UseVisualStyleBackColor = true;

            // Cột Nút Bấm
            this.btnClear.Location = new System.Drawing.Point(283, 140);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "🔄 Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.btnAdd.Location = new System.Drawing.Point(400, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnSua.Location = new System.Drawing.Point(400, 180);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(140, 30);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "✏️ Lưu Chỉnh Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(400, 220);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(140, 30);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // ============== TÌM KIẾM ==============
            this.txtSearch.Location = new System.Drawing.Point(220, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 20);
            this.txtSearch.TabIndex = 6;

            this.btnSearch.Location = new System.Drawing.Point(120, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // ============== KHUNG CHỨC NĂNG CHÍNH ==============
            this.groupBoxChucNang.Controls.Add(this.groupBoxThongKe);
            this.groupBoxChucNang.Controls.Add(this.groupBoxQuanLy);
            this.groupBoxChucNang.Location = new System.Drawing.Point(580, 50);
            this.groupBoxChucNang.Name = "groupBoxChucNang";
            this.groupBoxChucNang.Size = new System.Drawing.Size(520, 280);
            this.groupBoxChucNang.TabIndex = 7;
            this.groupBoxChucNang.TabStop = false;
            this.groupBoxChucNang.Text = "Quản lý && Thống kê";

            // ============== KHUNG THỐNG KÊ ==============
            this.groupBoxThongKe.Controls.Add(this.lstThongKe);
            this.groupBoxThongKe.Controls.Add(this.btnThongKe);
            this.groupBoxThongKe.Controls.Add(this.cboThongKe);
            this.groupBoxThongKe.Location = new System.Drawing.Point(10, 20);
            this.groupBoxThongKe.Name = "groupBoxThongKe";
            this.groupBoxThongKe.Size = new System.Drawing.Size(280, 245);
            this.groupBoxThongKe.TabIndex = 0;
            this.groupBoxThongKe.TabStop = false;
            this.groupBoxThongKe.Text = "📊 THỐNG KÊ";

            this.cboThongKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThongKe.FormattingEnabled = true;
            this.cboThongKe.Location = new System.Drawing.Point(10, 22);
            this.cboThongKe.Name = "cboThongKe";
            this.cboThongKe.Size = new System.Drawing.Size(150, 21);
            this.cboThongKe.TabIndex = 13;

            this.btnThongKe.Location = new System.Drawing.Point(170, 20);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(100, 23);
            this.btnThongKe.TabIndex = 14;
            this.btnThongKe.Text = "Xem thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);

            this.lstThongKe.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lstThongKe.FormattingEnabled = true;
            this.lstThongKe.Location = new System.Drawing.Point(10, 50);
            this.lstThongKe.Name = "lstThongKe";
            this.lstThongKe.Size = new System.Drawing.Size(260, 186);
            this.lstThongKe.TabIndex = 12;

            // ============== KHUNG QUẢN LÝ ==============
            this.groupBoxQuanLy.Controls.Add(this.btnAutoCreateClass);
            this.groupBoxQuanLy.Controls.Add(this.cboSoLuongLop);
            this.groupBoxQuanLy.Controls.Add(this.labelSoLuong);
            this.groupBoxQuanLy.Controls.Add(this.btnExportExcel);
            this.groupBoxQuanLy.Location = new System.Drawing.Point(300, 20);
            this.groupBoxQuanLy.Name = "groupBoxQuanLy";
            this.groupBoxQuanLy.Size = new System.Drawing.Size(210, 245);
            this.groupBoxQuanLy.TabIndex = 1;
            this.groupBoxQuanLy.TabStop = false;
            this.groupBoxQuanLy.Text = "⚙️ QUẢN LÝ LỚP & DATA";

            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Location = new System.Drawing.Point(10, 30);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(95, 13);
            this.labelSoLuong.TabIndex = 13;
            this.labelSoLuong.Text = "Số sinh viên/lớp:";

            this.cboSoLuongLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoLuongLop.FormattingEnabled = true;
            this.cboSoLuongLop.Location = new System.Drawing.Point(110, 27);
            this.cboSoLuongLop.Name = "cboSoLuongLop";
            this.cboSoLuongLop.Size = new System.Drawing.Size(90, 21);
            this.cboSoLuongLop.TabIndex = 11;

            this.btnAutoCreateClass.Location = new System.Drawing.Point(10, 60);
            this.btnAutoCreateClass.Name = "btnAutoCreateClass";
            this.btnAutoCreateClass.Size = new System.Drawing.Size(190, 30);
            this.btnAutoCreateClass.TabIndex = 10;
            this.btnAutoCreateClass.Text = "🎓 Tạo lớp";
            this.btnAutoCreateClass.UseVisualStyleBackColor = true;
            this.btnAutoCreateClass.Click += new System.EventHandler(this.btnAutoCreateClass_Click);

            this.btnExportExcel.Location = new System.Drawing.Point(10, 100);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(190, 35);
            this.btnExportExcel.TabIndex = 9;
            this.btnExportExcel.Text = "📥 Xuất Excel toàn bộ";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // ============== DANH SÁCH SINH VIÊN ==============
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 350);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1088, 280);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);

            // ============== FORM1 ==============
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 650);
            this.Controls.Add(this.groupBoxChucNang);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Quản lý sinh viên - Đại học ABC";
            this.Load += new System.EventHandler(this.Form1_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxChucNang.ResumeLayout(false);
            this.groupBoxThongKe.ResumeLayout(false);
            this.groupBoxQuanLy.ResumeLayout(false);
            this.groupBoxQuanLy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ============== KHAI BÁO CONTROLS ==============
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.Label labelKhoa;
        private System.Windows.Forms.TextBox txtNganh;
        private System.Windows.Forms.Label labelNganh;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Label labelTrangThai;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.Label labelLop;

        private System.Windows.Forms.ComboBox cbHocBong;
        private System.Windows.Forms.Label labelHocBong;
        private System.Windows.Forms.CheckBox chkKhenThuong;
        private System.Windows.Forms.CheckBox chkKyLuat;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.GroupBox groupBoxChucNang;
        private System.Windows.Forms.GroupBox groupBoxThongKe;
        private System.Windows.Forms.ListBox lstThongKe;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.ComboBox cboThongKe;

        private System.Windows.Forms.GroupBox groupBoxQuanLy;
        private System.Windows.Forms.ComboBox cboSoLuongLop;
        private System.Windows.Forms.Button btnAutoCreateClass;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.Button btnExportExcel;
    }
}