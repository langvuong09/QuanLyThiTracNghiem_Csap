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
    internal class SinhVien_DeKiemTraDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListBaiLam()
        {
            ArrayList listSVDKT = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM bailam";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BaiLam sd = new BaiLam
                        {
                            maBaiLam = reader.GetInt32(0),
                            maSinhVien = reader.GetString(1),
                            maDe = reader.GetInt32(2),
                            tongDiem = reader.GetInt32(3),
                        };
                        listSVDKT.Add(sd);
                    }
                }
            }catch (Exception ex)
            {
                return null;
            }
            return listSVDKT;
        }

        public ArrayList GetListSVOfBaiLam(string maSinhVien)
        {
            ArrayList listSVDKT = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM bailam WHERE maSinhVien = @maSinhVien";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BaiLam sd = new BaiLam
                        {
                            maBaiLam = reader.GetInt32(0),
                            maSinhVien = reader.GetString(1),
                            maDe = reader.GetInt32(2),
                            tongDiem = reader.GetInt32(3),
                        };
                        listSVDKT.Add(sd);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return listSVDKT;
        }

        public ArrayList GetListDKTOfBaiLam(string maDe)
        {
            ArrayList listSVDKT = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM bailam WHERE maDe = @maDe";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@maDe", maDe);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BaiLam sd = new BaiLam
                        {
                            maBaiLam = reader.GetInt32(0),
                            maSinhVien = reader.GetString(1),
                            maDe = reader.GetInt32(2),
                            tongDiem = reader.GetInt32(3),
                        };
                        listSVDKT.Add(sd);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return listSVDKT;
        }

        public bool ThemBaiLam(int maBaiLam, string maSinhVien, int maDe, float tongDiem)
        {
            try
            {
                string sql = "INSERT INTO bailam(maBaiLam, maSinhVien, maDe, tongDiem)" +
                    "VaLUES (@maBaiLam, @maSinhVien, @maDe, @tongDiem)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maBaiLam", maBaiLam);
                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    cmd.Parameters.AddWithValue("@tongDiem", tongDiem);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaBaiLam(int maBaiLam)
        {
            try
            {
                string sql = "DELETE FROM bailam WHERE maBaiLam = @maBaiLam";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maBaiLam", maBaiLam);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetMaxMaBaiLam()
        {
            int maxMaBaiLam = 0;
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MAX(maBaiLam) FROM bailam";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        maxMaBaiLam = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                
                maxMaBaiLam = 0;
            }
            return maxMaBaiLam;
        }

    }
}
