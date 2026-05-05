using MySql.Data.MySqlClient;
using System;

namespace QLSinhVien.Data
{
    public class DbConnection
    {
        // Đã cập nhật Uid=qlsvdb và Pwd=123456 
        // đăng nhập vào db ghi tên đăng nhập qlsvdb   và mật khẩu là 123456 thấy bảng lưu dữ liệu tên : qlsinhvien 
        private readonly string _connString = "Server=localhost;Database=qlsinhvien;Uid=qlsvdb;Pwd=123456;Charset=utf8;Convert Zero Datetime=True";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connString);
        }

        public bool IsConnected()
        {
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}