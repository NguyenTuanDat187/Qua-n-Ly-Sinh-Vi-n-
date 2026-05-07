using System;

namespace QLSinhVien.Models
{
    public class SinhVien
    {
        // Thông tin cơ bản
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        // Thông tin học vụ
        public string Khoa { get; set; }
        public string Nganh { get; set; }
        public string Lop { get; set; }

        // Thông tin trạng thái & Đánh giá
        public string TrangThai { get; set; }  // Đang học, Bảo lưu, Thôi học, Rút hồ sơ
        public string HocBong { get; set; }    // Xuất sắc, Giỏi, Khá, Không
        public string KyLuat { get; set; }     // Cảnh cáo, Khiển trách, Không
        public string KhenThuong { get; set; } // Các hình thức khen thưởng khác

        // Constructor thiết lập giá trị mặc định
        public SinhVien()
        {
            TrangThai = "Đang học";
            HocBong = "Không";
            KyLuat = "Không";
            KhenThuong = "Không";
            NgaySinh = DateTime.Now;
        }
    }
}