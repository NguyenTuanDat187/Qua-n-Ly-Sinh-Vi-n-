using QLSinhVien.Data;
using QLSinhVien.Excel;
using QLSinhVien.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLSinhVien
{
    public partial class Form1 : Form
    {
        SinhVienService service = new SinhVienService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadDanhSachLop(); // Load các lớp đã có vào ComboBox Lớp

            lstThongKe.Items.Clear();

            cbGioiTinh.SelectedIndex = 0;

            cbTrangThai.Items.Clear();
            cbTrangThai.Items.AddRange(new object[] { "Đang học", "Bảo lưu", "Thôi học", "Rút hồ sơ" });
            cbTrangThai.SelectedIndex = 0;

            cbHocBong.Items.Clear();
            cbHocBong.Items.AddRange(new object[] { "Không", "Khá", "Giỏi", "Xuất sắc" });
            cbHocBong.SelectedIndex = 0;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Bật cột STT (RowHeaders)
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.RowHeadersWidth = 50;

            cboSoLuongLop.Items.Clear();
            cboSoLuongLop.Items.AddRange(new object[] { 5, 10, 15, 20 });
            cboSoLuongLop.SelectedIndex = 0;

            cboThongKe.Items.Clear();
            cboThongKe.Items.AddRange(new object[] {
                "Tất cả",
                // Đã bỏ "Theo trạng thái" theo yêu cầu
                "Theo học bổng",
                "Theo khen thưởng",
                "Đang học",
                "Bảo lưu",
                "Thôi học",
                "Rút hồ sơ"
            });
            cboThongKe.SelectedIndex = 0;
        }

        void LoadGrid()
        {
            dataGridView1.DataSource = service.LoadData();
        }

        void LoadDanhSachLop()
        {
            cbLop.Items.Clear();
            cbLop.Items.Add(""); // Dành cho sinh viên chưa có lớp
            List<string> classes = service.GetAllClasses();
            foreach (var lop in classes)
            {
                cbLop.Items.Add(lop);
            }
        }

        void ClearForm()
        {
            txtTen.Clear();
            txtKhoa.Clear();
            txtNganh.Clear();
            txtSearch.Clear();

            // Xóa CheckBox
            chkKhenThuong.Checked = false;
            chkKyLuat.Checked = false;

            // Reset ComboBox về định dạng chuẩn
            cbGioiTinh.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 0;
            cbHocBong.SelectedIndex = 0;
            cbLop.SelectedIndex = -1; // Rỗng

            dtNgaySinh.Value = DateTime.Now;

            // Mở lại các nút
            MoKhoaGiaoDien();
            btnAdd.Enabled = true; // Mở lại nút Thêm Mới
            dataGridView1.ClearSelection();
        }

        void KhoaGiaoDien()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTen.Enabled = false;
            txtKhoa.Enabled = false;
            txtNganh.Enabled = false;
            cbLop.Enabled = false;
            cbGioiTinh.Enabled = false;
            cbTrangThai.Enabled = false;
            dtNgaySinh.Enabled = false;
            cbHocBong.Enabled = false;
            chkKhenThuong.Enabled = false;
            chkKyLuat.Enabled = false;
        }

        void MoKhoaGiaoDien()
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtTen.Enabled = true;
            txtKhoa.Enabled = true;
            txtNganh.Enabled = true;
            cbLop.Enabled = true;
            cbGioiTinh.Enabled = true;
            cbTrangThai.Enabled = true;
            dtNgaySinh.Enabled = true;
            cbHocBong.Enabled = true;
            chkKhenThuong.Enabled = true;
            chkKyLuat.Enabled = true;
        }

        // Sự kiện vẽ cột Số Thứ Tự (STT)
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sv = new SinhVien()
            {
                MaSV = service.GenerateMaSV(),
                TenSV = txtTen.Text.Trim(),
                NgaySinh = dtNgaySinh.Value,
                GioiTinh = cbGioiTinh.Text,
                Khoa = txtKhoa.Text.Trim(),
                Nganh = txtNganh.Text.Trim(),
                Lop = cbLop.Text,
                TrangThai = cbTrangThai.Text,
                HocBong = cbHocBong.Text,
                KhenThuong = chkKhenThuong.Checked ? "Có" : "Không",
                KyLuat = chkKyLuat.Checked ? "Có" : "Không"
            };

            if (service.AddStudent(sv))
            {
                MessageBox.Show($"Thêm thành công! Mã SV: {sv.MaSV}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên dưới danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();
            var svCurrent = service.GetStudentByMaSV(ma);

            if (svCurrent == null) return;

            if (svCurrent.TrangThai == "Rút hồ sơ")
            {
                MessageBox.Show("Sinh viên đã rút hồ sơ, không thể sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbTrangThai.Text == "Rút hồ sơ")
            {
                if (MessageBox.Show("Chuyển trạng thái sang 'Rút hồ sơ' sẽ KHÔNG thể sửa sau này.\nTiếp tục?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            var sv = new SinhVien()
            {
                MaSV = ma,
                TenSV = txtTen.Text.Trim(),
                NgaySinh = dtNgaySinh.Value,
                GioiTinh = cbGioiTinh.Text,
                Khoa = txtKhoa.Text.Trim(),
                Nganh = txtNganh.Text.Trim(),
                Lop = cbLop.Text,
                TrangThai = cbTrangThai.Text,
                HocBong = cbHocBong.Text,
                KhenThuong = chkKhenThuong.Checked ? "Có" : "Không",
                KyLuat = chkKyLuat.Checked ? "Có" : "Không"
            };

            if (service.UpdateStudent(sv))
            {
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();
            var sv = service.GetStudentByMaSV(ma);

            if (sv == null) return;

            if (sv.TrangThai == "Rút hồ sơ")
            {
                MessageBox.Show("Sinh viên đã rút hồ sơ, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {ma}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (service.DeleteStudent(ma))
                {
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                    ClearForm();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Khóa nút thêm mới khi đang xem 1 sinh viên cụ thể
            btnAdd.Enabled = false;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            txtTen.Text = row.Cells["TenSV"].Value?.ToString();
            txtKhoa.Text = row.Cells["Khoa"].Value?.ToString();
            txtNganh.Text = row.Cells["Nganh"].Value?.ToString();
            cbLop.Text = row.Cells["Lop"].Value?.ToString();
            cbGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();

            string trangThaiStr = row.Cells["TrangThai"].Value?.ToString();
            if (!string.IsNullOrEmpty(trangThaiStr)) cbTrangThai.Text = trangThaiStr;

            string hocBongStr = row.Cells["HocBong"].Value?.ToString();
            if (!string.IsNullOrEmpty(hocBongStr)) cbHocBong.Text = hocBongStr;

            // Xử lý Checkbox Khen thưởng / Kỷ luật
            string khenThuong = row.Cells["KhenThuong"].Value?.ToString();
            chkKhenThuong.Checked = (khenThuong == "Có");

            string kyLuat = row.Cells["KyLuat"].Value?.ToString();
            chkKyLuat.Checked = (kyLuat == "Có");

            if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ns))
                dtNgaySinh.Value = ns;

            if (cbTrangThai.Text == "Rút hồ sơ")
            {
                KhoaGiaoDien();
                MessageBox.Show("Sinh viên này đã rút hồ sơ, bạn chỉ có thể xem.", "Chỉ xem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MoKhoaGiaoDien();
                btnAdd.Enabled = false; // Luôn giữ tắt Add để không thêm trùng
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadGrid();
            }
            else
            {
                var result = service.Search(keyword);
                dataGridView1.DataSource = result;
                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string luaChon = cboThongKe.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(luaChon))
            {
                MessageBox.Show("Vui lòng chọn tiêu chí thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstThongKe.Items.Clear();

            List<SinhVien> result = new List<SinhVien>();

            switch (luaChon)
            {
                case "Tất cả":
                    result = service.LoadData();
                    dataGridView1.DataSource = result;
                    lstThongKe.Items.Add($"Đã hiển thị toàn bộ {result.Count} sinh viên.");
                    return;

                case "Theo học bổng":
                    var hocBongList = service.ThongKeTheoHocBong();
                    lstThongKe.Items.Add("=== THỐNG KÊ HỌC BỔNG ===");
                    foreach (var item in hocBongList) lstThongKe.Items.Add($"• {item.Key,-10}: {item.Value} SV");
                    return;

                case "Theo khen thưởng":
                    var khenThuongList = service.ThongKeTheoKhenThuong();
                    lstThongKe.Items.Add("=== THỐNG KÊ KHEN THƯỞNG ===");
                    foreach (var item in khenThuongList) lstThongKe.Items.Add($"• {item.Key,-10}: {item.Value} SV");
                    return;

                case "Đang học":
                case "Bảo lưu":
                case "Thôi học":
                case "Rút hồ sơ":
                    result = service.ThongKeTheoTrangThaiCuThe(luaChon);
                    break;
            }

            if (result.Count > 0)
            {
                dataGridView1.DataSource = result;
                lstThongKe.Items.Add($"Đã hiển thị danh sách {result.Count} SV:");
                lstThongKe.Items.Add($"Danh mục: {luaChon}");
            }
            else
            {
                MessageBox.Show($"Không tìm thấy dữ liệu nào cho mục: {luaChon}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAutoCreateClass_Click(object sender, EventArgs e)
        {
            int soLuong = Convert.ToInt32(cboSoLuongLop.SelectedItem);

            if (service.CreateClassWithStudents(soLuong, out string maLop, out string message))
            {
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                LoadDanhSachLop(); // Cập nhật lại ComboBox lớp
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Lưu file Excel";
                    saveFileDialog.FileName = $"DanhSachSinhVien_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var excelService = new ExcelService();
                        List<SinhVien> danhSachSV = service.LoadData();
                        excelService.ExportToExcel(danhSachSV, saveFileDialog.FileName);

                        MessageBox.Show($"Xuất Excel thành công!\nĐường dẫn: {saveFileDialog.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}