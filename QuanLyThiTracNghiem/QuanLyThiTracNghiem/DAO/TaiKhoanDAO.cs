using System;
using System.Collections;

using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic.ApplicationServices;
namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    internal class TaiKhoanDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListTaiKhoan()
        {
            ArrayList dstk = new ArrayList();

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM taikhoan";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TaiKhoan tk = new TaiKhoan
                        {
                            userId = reader.GetString(0),
                            password = reader.GetString(1),
                            trangThai = reader.GetInt32(2)
                        };
                        dstk.Add(tk);
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return dstk;
        }
        public ArrayList GetListUser()
        {
            ArrayList dstk = new ArrayList();

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM taikhoan WHERE trangThai = 1";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TaiKhoan tk = new TaiKhoan
                        {
                            userId = reader.GetString(0),
                            password = reader.GetString(1),
                            trangThai = reader.GetInt32(2),

                        };
                        dstk.Add(tk);
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return dstk;
        }

        public TaiKhoan GetTaiKhoan(string username, string password)
        {
            TaiKhoan tk = null;
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM taikhoan WHERE ma = @ma AND password = @password AND trangThai= 1";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        tk = new TaiKhoan()
                        {
                            userId = reader.GetString(0),
                            password = reader.GetString(1),
                            trangThai = reader.GetInt32(2),
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return tk;
        }

        public bool ThemTaiKhoan(string ma, string password)
        {
            try
            {
                string sql = "INSERT INTO taikhoan(ma,password,trangThai) " +
                    "VALUES (@userId, @password, 1)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@userId", ma);
                    cmd.Parameters.AddWithValue("@password", password);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SuaMKTaiKhoan(string ma, string newPassword)
        {
            try
            {
                string sql = "Update taikhoan SET password = @password WHERE ma=@ma";
                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    cmd.Parameters.AddWithValue("@ma", ma);
                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool khoaTaiKhoan(string ma)
        {
            string sql = "Update taikhoan SET trangThai= 0 WHERE ma=@ma";
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ma", ma);
                int rs = cmd.ExecuteNonQuery();
                return rs > 0;
            }
        }

        public bool moTaiKhoan(string ma)
        {
            string sql = "Update taikhoan SET trangThai= 1 WHERE ma=@ma";
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ma", ma);
                int rs = cmd.ExecuteNonQuery();
                return rs > 0;
            }
        }

        public bool xoaTaiKhoan(string ma)
        {
            string sql = "DELETE FROM taikhoan WHERE ma=@ma";
            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ma", ma);
                int rs = cmd.ExecuteNonQuery();
                return rs > 0;
            }
        }
    }
}
