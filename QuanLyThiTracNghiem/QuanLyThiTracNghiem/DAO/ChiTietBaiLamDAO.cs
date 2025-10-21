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
    internal class ChiTietBaiLamDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListCTBaiLam()
        {
            ArrayList listCTBaiLam = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM chitietbailam";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ChiTietBaiLam sd = new ChiTietBaiLam
                        {
                            maBaiLam = reader.GetInt32(0),
                            maCauHoi = reader.GetInt32(1),
                            maDapAnDuocChon = reader.GetInt32(2),
                        };
                        listCTBaiLam.Add(sd);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return listCTBaiLam;
        }

        public bool ThemCTBaiLam(int maBaiLam, int maCauHoi, int maDapAnDuocChon)
        {
            try
            {
                string sql = "INSERT INTO chitietbailam(maBaiLam, maCauHoi, maDapAnDuocChon)" +
                    "VaLUES (@maBaiLam, @maCauHoi, @maDapAnDuocChon)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maBaiLam", maBaiLam);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                    cmd.Parameters.AddWithValue("@maDapAnDuocChon", maDapAnDuocChon);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaCTBaiLam(int maBaiLam)
        {
            try
            {
                string sql = "DELETE FROM chitietbailam WHERE maBaiLam = @maBaiLam";

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

        // LẤY CHI TIẾT BÀI LÀM THEO MÃ BÀI LÀM
        public List<ChiTietBaiLam> GetChiTietBaiLamByMaBaiLam(int maBaiLam)
        {
            List<ChiTietBaiLam> result = new List<ChiTietBaiLam>();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT maBaiLam, maCauHoi, maDapAnDuocChon FROM chitietbailam WHERE maBaiLam = @maBaiLam ORDER BY maCauHoi";
                    
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maBaiLam", maBaiLam);
                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new ChiTietBaiLam
                                {
                                    maBaiLam = reader.GetInt32("maBaiLam"),
                                    maCauHoi = reader.GetInt32("maCauHoi"),
                                    maDapAnDuocChon = reader.GetInt32("maDapAnDuocChon")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy chi tiết bài làm: {ex.Message}");
            }
            return result;
        }
    }
}
