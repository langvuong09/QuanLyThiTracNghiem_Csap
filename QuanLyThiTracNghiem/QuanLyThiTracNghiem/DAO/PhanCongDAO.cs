using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using MySql.Data.MySqlClient;

using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    internal class PhanCongDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListPhanCong()
        {
            ArrayList dsc = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM phancong";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PhanCong pc = new PhanCong
                        {
                            maPhanCong = reader.GetInt32(0),
                            maMonHoc = reader.GetString(1),
                            maGiaoVien = reader.GetString(2),
                        };
                        dsc.Add(pc);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsc;
        }
        public bool Existed(string maMonHoc, string maGV)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM phancong WHERE maMonHoc = @maMonHoc AND maGiaoVien = @maGV";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@maGV", maGV);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ThemPhanCong(int maPhanCong,string maMonHoc, string maGiaoVien)
        {
            try
            {
                string sql = "INSERT INTO phancong(maPhanCong, maMonHoc, maGiaoVien)" +
                    "VaLUES (@maPhanCong, @maMonHoc, @maGiaoVien)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maPhanCong", maPhanCong);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaPhanCong(int maPhanCong)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand disableFK = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0;", conn);
                    disableFK.ExecuteNonQuery();

                    string sql = "DELETE FROM phancong WHERE maPhanCong = @maPhanCong";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maPhanCong", maPhanCong);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    MySqlCommand enableFK = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1;", conn);
                    enableFK.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SuaPhanCong(int maPhanCong, string maMonHoc, string maGiaoVien)
        {
            try
            {
                string sql = "UPDATE phancong SET maMonHoc = @maMonHoc, maGiaoVien = @maGiaoVien WHERE maPhanCong = @maPhanCong";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maPhanCong", maPhanCong);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ArrayList GetListPhanCongOfGiaoVien(string maGiaoVien)
        {
            ArrayList dsc = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM phancong WHERE maGiaoVien = @maGiaoVien";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PhanCong pc = new PhanCong
                        {
                            maPhanCong = reader.GetInt32(0),
                            maMonHoc = reader.GetString(1),
                            maGiaoVien = reader.GetString(2),
                        };
                        dsc.Add(pc);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsc;
        }

        public int GetMaxMaPhanCong()
        {
            int maxMa = 0;
            string query = "SELECT MAX(maPhanCong) FROM phancong";
            using (var conn = db.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        maxMa = Convert.ToInt32(result);
                    }
                }
            }
            return maxMa;
        }
    }
}

