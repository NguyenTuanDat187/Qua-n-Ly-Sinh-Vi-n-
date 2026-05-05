using QLSinhVien.Data;
using QLSinhVien.Models;
using System;
using System.Linq;
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
            cbGioiTinh.SelectedIndex = 0;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        void LoadGrid()
        {
            dataGridView1.DataSource = service.LoadData();
        }

        void ClearForm()
        {
            txtTen.Clear();
            txtLop.Clear();
            txtKhoa.Clear();
            txtNganh.Clear();
            txtSearch.Clear();
            cbGioiTinh.SelectedIndex = 0;
            dtNgaySinh.Value = DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sinh viên!");
                return;
            }

            var sv = new SinhVien()
            {
                MaSV = service.GenerateMaSV(),
                TenSV = txtTen.Text.Trim(),
                NgaySinh = dtNgaySinh.Value,
                GioiTinh = cbGioiTinh.Text,
                Lop = txtLop.Text.Trim(),
                Khoa = txtKhoa.Text.Trim(),
                Nganh = txtNganh.Text.Trim(),
                TrangThai = "Đang học"
            };

            if (service.AddStudent(sv))
            {
                MessageBox.Show("Thêm thành công! Mã SV: " + sv.MaSV);
                LoadGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
                return;
            }

            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();

            var sv = new SinhVien()
            {
                MaSV = ma,
                TenSV = txtTen.Text.Trim(),
                NgaySinh = dtNgaySinh.Value,
                GioiTinh = cbGioiTinh.Text,
                Lop = txtLop.Text.Trim(),
                Khoa = txtKhoa.Text.Trim(),
                Nganh = txtNganh.Text.Trim()
            };

            if (service.UpdateStudent(sv))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadGrid();
                ClearForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
                return;
            }

            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {ma}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (service.DeleteStudent(ma))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadGrid();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
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
                dataGridView1.DataSource = service.Search(keyword);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            txtTen.Text = row.Cells["TenSV"].Value?.ToString();
            txtLop.Text = row.Cells["Lop"].Value?.ToString();
            txtKhoa.Text = row.Cells["Khoa"].Value?.ToString();
            txtNganh.Text = row.Cells["Nganh"].Value?.ToString();
            cbGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ns))
                dtNgaySinh.Value = ns;
        }

        private void btnXepLop_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên!");
                return;
            }

            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();
            string lopMoi = Microsoft.VisualBasic.Interaction.InputBox("Nhập lớp mới:", "Xếp lớp", txtLop.Text);

            if (!string.IsNullOrWhiteSpace(lopMoi))
            {
                if (service.XepLop(ma, lopMoi))
                {
                    MessageBox.Show("Xếp lớp thành công!");
                    LoadGrid();
                }
            }
        }

        private void btnKhenThuong_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();

            string loai = Microsoft.VisualBasic.Interaction.InputBox("Nhập hình thức khen thưởng:", "Khen thưởng",
                "Xuất sắc, Giỏi, Khá, Tiên tiến");

            if (!string.IsNullOrWhiteSpace(loai))
            {
                if (service.CapNhatThuongPhat(ma, "HocBong", loai))
                {
                    MessageBox.Show($"Đã cập nhật khen thưởng: {loai}");
                    LoadGrid();
                }
            }
        }

        private void btnKyLuat_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();

            string hinhThuc = Microsoft.VisualBasic.Interaction.InputBox("Nhập hình thức kỷ luật:", "Kỷ luật",
                "Khiển trách, Cảnh cáo, Đình chỉ");

            if (!string.IsNullOrWhiteSpace(hinhThuc))
            {
                if (service.CapNhatThuongPhat(ma, "KyLuat", hinhThuc))
                {
                    MessageBox.Show($"Đã cập nhật kỷ luật: {hinhThuc}");
                    LoadGrid();
                }
            }
        }

        private void btnHocBong_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();

            string loaiHB = Microsoft.VisualBasic.Interaction.InputBox("Nhập loại học bổng:", "Học bổng",
                "Toàn phần, Bán phần, Khuyến khích");

            if (!string.IsNullOrWhiteSpace(loaiHB))
            {
                if (service.CapNhatThuongPhat(ma, "HocBong", loaiHB))
                {
                    MessageBox.Show($"Đã cập nhật học bổng: {loaiHB}");
                    LoadGrid();
                }
            }
        }

        private void btnBaoLuu_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();

            if (MessageBox.Show($"Bảo lưu sinh viên {ma}?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (service.BaoLuu(ma))
                {
                    MessageBox.Show("Đã bảo lưu!");
                    LoadGrid();
                }
            }
        }

        private void btnThoiHoc_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();

            if (MessageBox.Show($"Xác nhận thôi học cho sinh viên {ma}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (service.ThoiHoc(ma))
                {
                    MessageBox.Show("Đã cập nhật thôi học!");
                    LoadGrid();
                }
            }
        }

        private void btnRutHoSo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            string ma = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();

            if (MessageBox.Show($"Rút hồ sơ sẽ XÓA VĨNH VIỄN sinh viên {ma}. Tiếp tục?", "Cảnh báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (service.RutHoSo(ma))
                {
                    MessageBox.Show("Đã rút hồ sơ!");
                    LoadGrid();
                }
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string tieuChi = cboThongKe.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tieuChi))
            {
                MessageBox.Show("Vui lòng chọn tiêu chí thống kê!");
                return;
            }

            string giaTri = Microsoft.VisualBasic.Interaction.InputBox($"Nhập {tieuChi.ToLower()} cần thống kê:", "Thống kê");

            if (!string.IsNullOrWhiteSpace(giaTri))
            {
                var result = service.ThongKe(tieuChi, giaTri);
                dataGridView1.DataSource = result;
                MessageBox.Show($"Tìm thấy {result.Count} sinh viên thuộc {tieuChi}: {giaTri}");
            }
        }
    }
}