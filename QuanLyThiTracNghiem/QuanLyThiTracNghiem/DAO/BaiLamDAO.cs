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
    internal class BaiLamDAO
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
                            thoiGianBatDau = reader.GetDateTime(4),
                            thoiGianNopBai = reader.GetDateTime(5)
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

        public ArrayList GetListBaiLamOfSV(string maSinhVien)
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
                            thoiGianBatDau = reader.GetDateTime(4),
                            thoiGianNopBai = reader.GetDateTime(5)
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
                            thoiGianBatDau = reader.GetDateTime(4),
                            thoiGianNopBai = reader.GetDateTime(5)
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

        public int GetCountBaiLam(int maDe)
        {
            int countMaBaiLam = 0;
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM bailam WHERE maDe = @maDe";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        countMaBaiLam = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {

                countMaBaiLam = 0;
            }
            return countMaBaiLam;
        }

        // Lấy max MaBaiLam
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

        // Tìm kiếm bài làm theo maDe, maSinhVien
        public bool KiemTraTonTaiBaiLam(int maDe, string maSinhVien)
        {
            bool tonTai = false;

            try
            {
                string sql = "SELECT COUNT(*) FROM bailam WHERE maDe = @maDe AND maSinhVien = @maSinhVien";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDe", maDe);
                        cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        tonTai = count > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Lỗi] Khi kiểm tra bài làm của sinh viên ({maSinhVien}) trong đề ({maDe}): {ex.Message}");
            }

            return tonTai;
        }

        // Lấy danh sách bài làm theo mã đề thi kèm thông tin sinh viên
        public List<Dictionary<string, object>> GetBaiLamByMaDeWithSinhVien(int maDe)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT bl.maBaiLam, bl.maSinhVien, bl.maDe, bl.tongDiem,
                                   bl.thoiGianBatDau, bl.thoiGianNopBai,
                                   sv.hoVaTen
                                   FROM bailam bl
                                   LEFT JOIN sinhvien sv ON bl.maSinhVien = sv.maSinhVien
                                   WHERE bl.maDe = @maDe
                                   ORDER BY bl.maBaiLam";
                    
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDe", maDe);
                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Dictionary<string, object> row = new Dictionary<string, object>();
                                row["maBaiLam"] = reader.GetInt32("maBaiLam");
                                row["maSinhVien"] = reader.GetString("maSinhVien");
                                row["maDe"] = reader.GetInt32("maDe");
                                row["tongDiem"] = reader.GetFloat("tongDiem");
                                
                                // Xử lý hoVaTen có thể null
                                if (reader.IsDBNull(reader.GetOrdinal("hoVaTen")))
                                {
                                    row["hoVaTen"] = "";
                                }
                                else
                                {
                                    row["hoVaTen"] = reader.GetString("hoVaTen");
                                }
                                
                                // Xử lý thoiGianBatDau có thể null
                                int thoiGianBatDauOrdinal = reader.GetOrdinal("thoiGianBatDau");
                                if (reader.IsDBNull(thoiGianBatDauOrdinal))
                                {
                                    row["thoiGianBatDau"] = null;
                                }
                                else
                                {
                                    row["thoiGianBatDau"] = reader.GetDateTime("thoiGianBatDau");
                                }
                                
                                // Xử lý thoiGianNopBai có thể null
                                int thoiGianNopBaiOrdinal = reader.GetOrdinal("thoiGianNopBai");
                                if (reader.IsDBNull(thoiGianNopBaiOrdinal))
                                {
                                    row["thoiGianNopBai"] = null;
                                }
                                else
                                {
                                    row["thoiGianNopBai"] = reader.GetDateTime("thoiGianNopBai");
                                }
                                
                                result.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách bài làm: {ex.Message}");
            }
            return result;
        }


    }
}
