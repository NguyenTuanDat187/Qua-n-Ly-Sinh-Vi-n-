using MySql.Data.MySqlClient;
using System;

namespace QLSinhVien.Data
{
    public class DbConnection
    {
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