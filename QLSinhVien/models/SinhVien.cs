using System;

namespace QLSinhVien.Models
{
    public class SinhVien
    {
        // Khóa chính
        public string MaSV { get; set; }

        public string TenSV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        // Tổ chức lớp học
        public string Khoa { get; set; }
        public string Nganh { get; set; }
        public string Lop { get; set; }

        // Quản lý tình trạng và thành tích
        public string TrangThai { get; set; } // Ví dụ: Đang học, Bảo lưu, Thôi học
        public string HocBong { get; set; }   // Ví dụ: Loại Xuất sắc, Khá, Không
        public string KyLuat { get; set; }    // Ví dụ: Cảnh cáo, Khiển trách, Không

        // Constructor mặc định để tránh lỗi null khi khởi tạo
        public SinhVien()
        {
            TrangThai = "Đang học";
            HocBong = "Không";
            KyLuat = "Không";
            NgaySinh = DateTime.Now;
        }
    }
}