using MySql.Data.MySqlClient;
using QLSinhVien.Models;
using System;
using System.Collections.Generic;

namespace QLSinhVien.Data
{
    public class SinhVienService
    {
        private DbConnection db = new DbConnection();

        // Lấy toàn bộ danh sách sinh viên từ DB
        public List<SinhVien> LoadData()
        {
            List<SinhVien> list = new List<SinhVien>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM sinhvien ORDER BY MaSV DESC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapSinhVien(reader));
                    }
                }
            }
            return list;
        }

        // Thêm mới sinh viên vào DB
        public bool AddStudent(SinhVien sv)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO sinhvien (MaSV, TenSV, Khoa, Nganh, Lop, NgaySinh, TrangThai, HocBong, KyLuat, GioiTinh) 
                                VALUES (@ma, @ten, @khoa, @nganh, @lop, @ngay, @trangthai, @hb, @kl, @gt)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, sv);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật sinh viên trong DB
        public bool UpdateStudent(SinhVien sv)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE sinhvien SET TenSV=@ten, Khoa=@khoa, Nganh=@nganh, Lop=@lop, 
                                NgaySinh=@ngay, TrangThai=@trangthai, HocBong=@hb, KyLuat=@kl, GioiTinh=@gt 
                                WHERE MaSV=@ma";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, sv);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa sinh viên khỏi DB
        public bool DeleteStudent(string maSV)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM sinhvien WHERE MaSV = @ma";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ma", maSV);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Tìm kiếm trong DB
        public List<SinhVien> Search(string keyword)
        {
            List<SinhVien> list = new List<SinhVien>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM sinhvien WHERE TenSV LIKE @key OR MaSV LIKE @key OR Lop LIKE @key";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapSinhVien(reader));
                    }
                }
            }
            return list;
        }

        // Tạo mã SV tự động (lưu vào DB)
        // Tạo mã SV tự động (lấy số lớn nhất + 1)
        public string GenerateMaSV()
        {
            string year = DateTime.Now.Year.ToString();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                // Lấy mã lớn nhất thay vì đếm số lượng
                string query = "SELECT MAX(MaSV) FROM sinhvien WHERE MaSV LIKE @prefix";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@prefix", "SV" + year + "%");

                object result = cmd.ExecuteScalar();

                if (result == DBNull.Value || result == null)
                {
                    // Chưa có sinh viên nào trong năm nay
                    return $"SV{year}0001";
                }
                else
                {
                    string maxMaSV = result.ToString(); // Ví dụ: SV20260005
                    string soThuTu = maxMaSV.Substring(6); // Lấy "0005"
                    int stt = int.Parse(soThuTu) + 1;
                    return $"SV{year}{stt:D4}";
                }
            }
        }
        // Xếp lớp - Cập nhật Lop trong DB
        public bool XepLop(string maSV, string lopMoi)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "UPDATE sinhvien SET Lop = @lop WHERE MaSV = @ma";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@lop", lopMoi);
                cmd.Parameters.AddWithValue("@ma", maSV);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật khen thưởng/kỷ luật/học bổng/trạng thái trong DB
        public bool CapNhatThuongPhat(string maSV, string cot, string giaTri)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = $"UPDATE sinhvien SET {cot} = @giaTri WHERE MaSV = @ma";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@giaTri", giaTri);
                cmd.Parameters.AddWithValue("@ma", maSV);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Bảo lưu - Cập nhật TrangThai trong DB
        public bool BaoLuu(string maSV)
        {
            return CapNhatThuongPhat(maSV, "TrangThai", "Bảo lưu");
        }

        // Thôi học - Cập nhật TrangThai trong DB
        public bool ThoiHoc(string maSV)
        {
            return CapNhatThuongPhat(maSV, "TrangThai", "Thôi học");
        }

        // Rút hồ sơ - Xóa khỏi DB
        public bool RutHoSo(string maSV)
        {
            return DeleteStudent(maSV);
        }

        // Thống kê theo tiêu chí từ DB
        public List<SinhVien> ThongKe(string tieuChi, string giaTri)
        {
            List<SinhVien> list = new List<SinhVien>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string cot = "";
                if (tieuChi == "Theo lớp") cot = "Lop";
                else if (tieuChi == "Theo khoa") cot = "Khoa";
                else if (tieuChi == "Theo ngành") cot = "Nganh";
                else if (tieuChi == "Theo trạng thái") cot = "TrangThai";
                else return list;

                string query = $"SELECT * FROM sinhvien WHERE {cot} = @giaTri ORDER BY TenSV";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@giaTri", giaTri);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(MapSinhVien(reader));
                }
            }
            return list;
        }

        // Helper Methods
        private void AddParameters(MySqlCommand cmd, SinhVien sv)
        {
            cmd.Parameters.AddWithValue("@ma", sv.MaSV);
            cmd.Parameters.AddWithValue("@ten", sv.TenSV);
            cmd.Parameters.AddWithValue("@khoa", sv.Khoa ?? "");
            cmd.Parameters.AddWithValue("@nganh", sv.Nganh ?? "");
            cmd.Parameters.AddWithValue("@lop", sv.Lop ?? "");
            cmd.Parameters.AddWithValue("@ngay", sv.NgaySinh);
            cmd.Parameters.AddWithValue("@trangthai", sv.TrangThai ?? "Đang học");
            cmd.Parameters.AddWithValue("@hb", sv.HocBong ?? "Không");
            cmd.Parameters.AddWithValue("@kl", sv.KyLuat ?? "Không");
            cmd.Parameters.AddWithValue("@gt", sv.GioiTinh ?? "Nam");
        }

        private SinhVien MapSinhVien(MySqlDataReader reader)
        {
            return new SinhVien
            {
                MaSV = reader["MaSV"].ToString(),
                TenSV = reader["TenSV"].ToString(),
                Khoa = reader["Khoa"]?.ToString(),
                Nganh = reader["Nganh"]?.ToString(),
                Lop = reader["Lop"]?.ToString(),
                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                TrangThai = reader["TrangThai"]?.ToString(),
                HocBong = reader["HocBong"]?.ToString(),
                KyLuat = reader["KyLuat"]?.ToString(),
                GioiTinh = reader["GioiTinh"]?.ToString()
            };
        }
    }
}