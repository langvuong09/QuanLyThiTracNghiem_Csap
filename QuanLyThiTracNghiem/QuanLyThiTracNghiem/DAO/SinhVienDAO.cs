using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    internal class SinhVienDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListSinhVien()
        {
            ArrayList dssv = new ArrayList();
            try
            {
                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();
                    string sql = "SELECT * FROM sinhvien";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SinhVien sv = new SinhVien
                        {
                            maSinhVien = reader.GetString(0),
                            hoVaTen = reader.GetString(1),
                            email = reader.GetString(2),
                            gioiTinh = reader.GetString(3),
                            ngaySinh = reader.GetDateTime(4),
                            anhDaiDien = reader.GetString(5),
                        };
                        dssv.Add(sv);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dssv;
        }

        public bool ThemSinhVien(string maSinhVien, string hoVaTen, string email)
        {
            try
            {
                string sql = "INSERT INTO sinhvien(maSinhVien, hoVaTen, email, gioiTinh, ngaySinh, anhDaiDien, maQuyen) " +
             "VALUES (@maSinhVien, @hoVaTen, @email, @gioiTinh, @ngaySinh, @anhDaiDien, @maQuyen)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);
                    cmd.Parameters.AddWithValue("@hoVaTen", hoVaTen);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@gioiTinh", "Nam");
                    cmd.Parameters.AddWithValue("@ngaySinh", new DateTime(2000, 1, 1));
                    cmd.Parameters.AddWithValue("@anhDaiDien", "default.jpg");
                    cmd.Parameters.AddWithValue("@maQuyen", 3);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public bool XoaSinhVien(string maSinhVien)
        {
            try
            {
                string sql = "DELETE FROM sinhvien WHERE maSinhVien = @maSinhVien";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SuaSinhVien(string maSinhVien, string hoVaTen, string email, string gioiTinh, DateTime ngaySinh, string anhDaiDien)
        {
            try
            {
                string sql = "UPDATE sinhvien SET hoVaTen = @hoVaTen, email = @email, gioiTinh = @gioiTinh, ngaySinh = @ngaySinh," +
                    "anhDaiDien = @anhDaiDien WHERE maSinhVien = @maSinhVien";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@hoVaTen", hoVaTen);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@anhDaiDien", anhDaiDien);
                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);

                    int rs = cmd.ExecuteNonQuery();

                    return rs > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public SinhVien getSinhVienByID(string maSinhVien)
        {
            try
            {
                string sql = "SELECT * FROM sinhvien WHERE maSinhVien=@maSinhVien";
                using(MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        SinhVien sv = new SinhVien
                        {
                            maSinhVien = reader.GetString(0),
                            hoVaTen = reader.GetString(1),
                            email = reader.GetString(2),
                            gioiTinh = reader.GetString(3),
                            ngaySinh = reader.GetDateTime(4),
                            anhDaiDien = reader.GetString(5),
                            quyen = reader.GetString(6),
                        };
                        return sv;
                    }
                    else return null;
                }
            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}
