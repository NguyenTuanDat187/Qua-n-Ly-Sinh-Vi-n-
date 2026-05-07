using MySql.Data.MySqlClient;
using QLSinhVien.Models;
using System;
using System.Collections.Generic;

namespace QLSinhVien.Data
{
    public class SinhVienService
    {
        private DbConnection db = new DbConnection();
        private static Random random = new Random();

        // 1. Lấy toàn bộ danh sách
        public List<SinhVien> LoadData()
        {
            List<SinhVien> list = new List<SinhVien>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM sinhvien ORDER BY MaSV DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
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

        // 2. Thêm sinh viên
        public bool AddStudent(SinhVien sv)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO sinhvien (MaSV, TenSV, Khoa, Nganh, Lop, NgaySinh, TrangThai, HocBong, KyLuat, KhenThuong, GioiTinh) 
                                VALUES (@ma, @ten, @khoa, @nganh, @lop, @ngay, @trangthai, @hb, @kl, @khenthuong, @gt)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    AddParameters(cmd, sv);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 3. Cập nhật sinh viên (CHẶN NẾU RÚT HỒ SƠ)
        public bool UpdateStudent(SinhVien sv)
        {
            var current = GetStudentByMaSV(sv.MaSV);
            if (current != null && current.TrangThai == "Rút hồ sơ")
            {
                return false;
            }

            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE sinhvien SET TenSV=@ten, Khoa=@khoa, Nganh=@nganh, Lop=@lop, 
                                NgaySinh=@ngay, TrangThai=@trangthai, HocBong=@hb, KyLuat=@kl, 
                                KhenThuong=@khenthuong, GioiTinh=@gt 
                                WHERE MaSV=@ma";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    AddParameters(cmd, sv);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 4. Xóa sinh viên (CHẶN NẾU RÚT HỒ SƠ)
        public bool DeleteStudent(string maSV)
        {
            var current = GetStudentByMaSV(maSV);
            if (current != null && current.TrangThai == "Rút hồ sơ")
            {
                return false;
            }

            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM sinhvien WHERE MaSV = @ma";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maSV);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 5. Lấy 1 sinh viên theo mã
        public SinhVien GetStudentByMaSV(string maSV)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM sinhvien WHERE MaSV = @ma";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maSV);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapSinhVien(reader);
                        }
                    }
                }
            }
            return null;
        }

        // 6. Tìm kiếm
        public List<SinhVien> Search(string keyword)
        {
            List<SinhVien> list = new List<SinhVien>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM sinhvien WHERE TenSV LIKE @key OR MaSV LIKE @key OR Lop LIKE @key";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapSinhVien(reader));
                        }
                    }
                }
            }
            return list;
        }

        // 7. Tạo mã SV tự động
        public string GenerateMaSV()
        {
            string prefix = "73DTCM";
            string year = DateTime.Now.Year.ToString();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT MAX(MaSV) FROM sinhvien WHERE MaSV LIKE @prefix";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@prefix", prefix + year + "%");
                    object result = cmd.ExecuteScalar();

                    if (result == DBNull.Value || result == null)
                    {
                        return $"{prefix}{year}0001";
                    }
                    else
                    {
                        string maxMaSV = result.ToString();
                        string soThuTu = maxMaSV.Substring(maxMaSV.Length - 4);
                        int stt = int.Parse(soThuTu) + 1;
                        return $"{prefix}{year}{stt:D4}";
                    }
                }
            }
        }

        // 8. Lấy danh sách sinh viên theo lớp
        public List<SinhVien> GetStudentsByClass(string maLop)
        {
            List<SinhVien> list = new List<SinhVien>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM sinhvien WHERE Lop = @lop ORDER BY MaSV";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lop", maLop);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapSinhVien(reader));
                        }
                    }
                }
            }
            return list;
        }

        // 9. Lấy tất cả các lớp hiện có
        public List<string> GetAllClasses()
        {
            List<string> classes = new List<string>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT DISTINCT Lop FROM sinhvien WHERE Lop IS NOT NULL AND Lop != '' ORDER BY Lop";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string lop = reader["Lop"]?.ToString();
                        if (!string.IsNullOrEmpty(lop))
                            classes.Add(lop);
                    }
                }
            }
            return classes;
        }

        // 10. NGHIỆP VỤ: Tạo lớp tự động với các sinh viên CHƯA CÓ LỚP
        public bool CreateClassWithStudents(int soLuong, out string maLop, out string message)
        {
            maLop = "";
            message = "";

            using (var conn = db.GetConnection())
            {
                conn.Open();

                string getUnassignedQuery = "SELECT * FROM sinhvien WHERE (Lop IS NULL OR Lop = '') AND TrangThai != 'Rút hồ sơ' ORDER BY MaSV";
                List<SinhVien> unassignedList = new List<SinhVien>();
                using (var cmd = new MySqlCommand(getUnassignedQuery, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) unassignedList.Add(MapSinhVien(reader));
                }

                if (unassignedList.Count == 0)
                {
                    message = "Không có sinh viên nào đang chờ xếp lớp!";
                    return false;
                }

                int maxNum = 0;
                string getMaxClassQuery = "SELECT Lop FROM sinhvien WHERE Lop LIKE 'ABC12%'";
                using (var cmd = new MySqlCommand(getMaxClassQuery, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string lop = reader["Lop"].ToString();
                        if (lop.Length > 5 && int.TryParse(lop.Substring(5), out int num))
                        {
                            if (num > maxNum) maxNum = num;
                        }
                    }
                }

                var transaction = conn.BeginTransaction();
                try
                {
                    int totalAssigned = 0;
                    int classCount = 0;

                    for (int i = 0; i < unassignedList.Count; i += soLuong)
                    {
                        maxNum++;
                        string currentClass = $"ABC12{maxNum:D2}";
                        if (i == 0) maLop = currentClass;

                        var batch = unassignedList.GetRange(i, Math.Min(soLuong, unassignedList.Count - i));

                        foreach (var sv in batch)
                        {
                            string updateQuery = "UPDATE sinhvien SET Lop = @lop WHERE MaSV = @ma";
                            using (var updateCmd = new MySqlCommand(updateQuery, conn, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@lop", currentClass);
                                updateCmd.Parameters.AddWithValue("@ma", sv.MaSV);
                                updateCmd.ExecuteNonQuery();
                            }
                            totalAssigned++;
                        }
                        classCount++;
                    }

                    transaction.Commit();
                    message = $"Hoàn tất! Đã tự động tạo {classCount} lớp mới và xếp chỗ cho {totalAssigned} sinh viên.";
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    message = $"Lỗi khi tạo lớp: {ex.Message}";
                    return false;
                }
            }
        }

        // 11. Thống kê số lượng theo trạng thái
        public Dictionary<string, int> ThongKeTheoTrangThai()
        {
            var result = new Dictionary<string, int>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT TrangThai, COUNT(*) FROM sinhvien GROUP BY TrangThai";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[reader[0].ToString()] = Convert.ToInt32(reader[1]);
                    }
                }
            }
            return result;
        }

        // 12. Thống kê theo học bổng
        public Dictionary<string, int> ThongKeTheoHocBong()
        {
            var result = new Dictionary<string, int>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT HocBong, COUNT(*) FROM sinhvien GROUP BY HocBong";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[reader[0].ToString()] = Convert.ToInt32(reader[1]);
                    }
                }
            }
            return result;
        }

        // 13. Thống kê theo khen thưởng
        public Dictionary<string, int> ThongKeTheoKhenThuong()
        {
            var result = new Dictionary<string, int>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT KhenThuong, COUNT(*) FROM sinhvien GROUP BY KhenThuong";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result[reader[0].ToString()] = Convert.ToInt32(reader[1]);
                    }
                }
            }
            return result;
        }

        // 14. Thống kê theo trạng thái cụ thể
        public List<SinhVien> ThongKeTheoTrangThaiCuThe(string trangThai)
        {
            List<SinhVien> list = new List<SinhVien>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM sinhvien WHERE TrangThai = @trangthai ORDER BY TenSV";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@trangthai", trangThai);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(MapSinhVien(reader));
                    }
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
            cmd.Parameters.AddWithValue("@khenthuong", sv.KhenThuong ?? "Không");
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
                NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : DateTime.Now,
                TrangThai = reader["TrangThai"]?.ToString(),
                HocBong = reader["HocBong"]?.ToString(),
                KyLuat = reader["KyLuat"]?.ToString(),
                KhenThuong = reader["KhenThuong"]?.ToString(),
                GioiTinh = reader["GioiTinh"]?.ToString()
            };
        }
    }
}