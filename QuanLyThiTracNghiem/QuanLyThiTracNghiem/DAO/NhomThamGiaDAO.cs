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
    internal class NhomThamGiaDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListNhomTG(int maNhom)
        {
            ArrayList listNTG = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhomthamgia WHERE maNhom = @maNhom";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maNhom", maNhom);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        NhomThamGia ntg = new NhomThamGia
                        {
                            maNhom = reader.GetInt32(0),
                            maSinhVien = reader.GetString(1),
                        };
                        listNTG.Add(ntg);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return listNTG;
        }

        public ArrayList GetListNhomTGOfSV(string maSinhVien)
        {
            ArrayList listNTG = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhomthamgia WHERE maSinhVien = @maSinhVien";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        NhomThamGia ntg = new NhomThamGia
                        {
                            maNhom = reader.GetInt32(0),
                            maSinhVien = reader.GetString(1),
                        };
                        listNTG.Add(ntg);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return listNTG;
        }

        public bool ThemNhomTG(int maNhom, int maSinhVien)
        {
            try
            {
                string sql = "INSERT INTO nhomthamgia(maNhom, maSinhVien)" +
                    "VaLUES (@maNhom, @maSinhVien)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maNhom", maNhom);
                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoanhomTG(int maNhom)
        {
            try
            {
                string sql = "DELETE FROM nhomthamgia WHERE maNhom = @maNhom";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maNhom", maNhom);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int MaxNhomTG(int maNhom)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM nhomthamgia WHERE maNhom = @maNhom";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maNhom", maNhom);

                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
