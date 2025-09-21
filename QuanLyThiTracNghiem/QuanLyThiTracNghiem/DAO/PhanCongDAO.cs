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

        public bool ThemPhanCong(int maPhanCong,string maMonHoc, string maGiaoVien)
        {
            try
            {
                string sql = "INSERT INTO chuong(maPhanCong, maMonHoc, maGiaoVien)" +
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
                string sql = "DELETE FROM phancong WHERE maPhanCong = @maPhanCong";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maPhanCong", maPhanCong);
                    cmd.Parameters.AddWithValue("@maPhanCong", maPhanCong);
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
    }
}
