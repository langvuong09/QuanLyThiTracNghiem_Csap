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
                string sql = "INSERT INTO chitietbailam(maBaiLam, maCauHoi, maDapAnDuocChon) " +
                    "VALUES (@maBaiLam, @maCauHoi, @maDapAnDuocChon)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maBaiLam", maBaiLam);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                    cmd.Parameters.AddWithValue("@maDapAnDuocChon", maDapAnDuocChon);

                    int rs = cmd.ExecuteNonQuery();
                    Console.WriteLine($"ThemCTBaiLam: maBaiLam={maBaiLam}, maCauHoi={maCauHoi}, maDapAnDuocChon={maDapAnDuocChon}, result={rs > 0}");
                    return rs > 0;
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"Lỗi khi thêm chi tiết bài làm: {ex.Message}");
                return false; 
            }
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


        //Thêm danh sách BaiLam vào database
        public bool ThemDanhSachCTBaiLam(List<ChiTietBaiLam> danhSachCT)
        {
            Console.WriteLine($"=== ThemDanhSachCTBaiLam: {danhSachCT?.Count ?? 0} chi tiết ===");
            
            if (danhSachCT == null || danhSachCT.Count == 0)
            {
                Console.WriteLine("Danh sách chi tiết bài làm rỗng!");
                return false;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // Tối ưu bằng cách batch nhiều giá trị cùng lúc nếu danh sách nhỏ
                            if (danhSachCT.Count <= 100)
                            {
                                string sql = "INSERT INTO chitietbailam (maBaiLam, maCauHoi, maDapAnDuocChon) VALUES ";
                                StringBuilder values = new StringBuilder();

                                for (int i = 0; i < danhSachCT.Count; i++)
                                {
                                    var ct = danhSachCT[i];
                                    Console.WriteLine($"  Chi tiết {i + 1}: maBaiLam={ct.maBaiLam}, maCauHoi={ct.maCauHoi}, maDapAnDuocChon={ct.maDapAnDuocChon}");
                                    values.AppendFormat("({0},{1},{2})", ct.maBaiLam, ct.maCauHoi, ct.maDapAnDuocChon);
                                    if (i < danhSachCT.Count - 1)
                                        values.Append(",");
                                }

                                sql += values.ToString();
                                Console.WriteLine($"SQL: {sql}");

                                using (MySqlCommand cmd = new MySqlCommand(sql, conn, tran))
                                {
                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    Console.WriteLine($"Đã thêm {rowsAffected} dòng vào chitietbailam");
                                }
                            }
                            else
                            {
                                // Nếu danh sách lớn, dùng prepared statement 
                                string sql = "INSERT INTO chitietbailam (maBaiLam, maCauHoi, maDapAnDuocChon) " +
                                             "VALUES (@maBaiLam, @maCauHoi, @maDapAnDuocChon)";
                                using (MySqlCommand cmd = new MySqlCommand(sql, conn, tran))
                                {
                                    cmd.Parameters.Add("@maBaiLam", MySqlDbType.Int32);
                                    cmd.Parameters.Add("@maCauHoi", MySqlDbType.Int32);
                                    cmd.Parameters.Add("@maDapAnDuocChon", MySqlDbType.Int32);
                                    cmd.Prepare();

                                    foreach (var ct in danhSachCT)
                                    {
                                        cmd.Parameters["@maBaiLam"].Value = ct.maBaiLam;
                                        cmd.Parameters["@maCauHoi"].Value = ct.maCauHoi;
                                        cmd.Parameters["@maDapAnDuocChon"].Value = ct.maDapAnDuocChon;
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            tran.Commit();
                            Console.WriteLine("=== Đã commit transaction thành công ===");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            Console.WriteLine($"LỖI KHI THÊM DANH SÁCH CHITIETBAILAM: {ex.Message}");
                            Console.WriteLine($"Stack trace: {ex.StackTrace}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ LỖI KẾT NỐI DB: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return false;
            }
        }

    }
}
