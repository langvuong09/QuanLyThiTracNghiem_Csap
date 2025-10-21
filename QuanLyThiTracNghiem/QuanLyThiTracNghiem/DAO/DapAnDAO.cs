using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    internal class DapAnDAO
    {
        private MyConnect db = new MyConnect();
        public bool ThemDapAn(int maDapAn, int maCauHoi, string tenDapAn, int dungSai)
        {
            try
            {
                string sql = "INSERT INTO dapan(maDapAn, maCauHoi, tenDapAn, dungSai)" +
                    "VaLUES (@maDapAn, @maCauHoi, @tenDapAn, @dungSai)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDapAn", maDapAn);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                    cmd.Parameters.AddWithValue("@tenDapAn", tenDapAn);
                    cmd.Parameters.AddWithValue("@dungSai", dungSai);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaDapAn(int maDapAn, int maCauHoi)
        {
            try
            {
                string sql = "DELETE FROM dapan WHERE maDapAn = @maDapAn AND maCauHoi = @maCauHoi";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDapAn", maDapAn);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaDapAnTheoCauHoi(int maCauHoi)
        {
            try
            {
                string sql = "DELETE FROM dapan WHERE maCauHoi = @maCauHoi";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*
          Phương thức lấy danh sách đáp án theo Mã Câu Hỏi
             Input: Mã Câu Hỏi
             Output: List <DapAn>
             Created by: Đỗ Mai Anh

        */

        public List<DapAn> LayDSDapAnTheoMaCauHoi(int maCauHoi)
        {
            List<DapAn> danhSachDapAn = new List<DapAn>();

            try
            {
                string sql = "SELECT * FROM dapan WHERE maCauHoi = @maCauHoi";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DapAn dapAn = new DapAn
                            {
                                maDapAn = reader.GetInt32("maDapAn"),
                                maCauHoi = reader.GetInt32("maCauHoi"),
                                tenDapAn = reader.GetString("tenDapAn"),
                                dungSai = reader.GetInt32("dungSai")
                            };

                            danhSachDapAn.Add(dapAn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách đáp án theo mã câu hỏi: " + ex.Message);
            }

            return danhSachDapAn;
        }

        /*
          Phương thức sửa đáp án theo Mã Đáp Án
             Input: Mã Đáp Án, Tên Đáp Án
             Output: true/false
             Created by: Đỗ Mai Anh

        */
        public bool SuaDapAn(int maDapAn, string tenDapAn, int maCauHoi)
        {
            try
            {
                string sql = "UPDATE dapan SET tenDapAn = @tenDapAn WHERE maDapAn = @maDapAn AND maCauHoi = @maCauHoi ";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDapAn", maDapAn);
                        cmd.Parameters.AddWithValue("@tenDapAn", tenDapAn);
                        cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi để dễ debug (tuỳ bạn có thể dùng Console, MessageBox hoặc log file)
                Console.WriteLine("Lỗi khi sửa đáp án: " + ex.Message);
                return false;
            }
        }

        /*
          Phương thức thêm danh sách đáp án vào cơ sở dữ liệu
             Input: List <DapAn>
             Output: boolean
             Created by: Đỗ Mai Anh

        */

        public bool ThemDSDapAn(List<DapAn> danhSachDapAn)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        string sql = "INSERT INTO dapan (maDapAn, maCauHoi, tenDapAn, dungSai) " +
                                     "VALUES (@maDapAn, @maCauHoi, @tenDapAn, @dungSai)";
                        foreach (var dapAn in danhSachDapAn)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(sql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@maDapAn", dapAn.maDapAn);
                                cmd.Parameters.AddWithValue("@maCauHoi", dapAn.maCauHoi);
                                cmd.Parameters.AddWithValue("@tenDapAn", dapAn.tenDapAn);
                                cmd.Parameters.AddWithValue("@dungSai", dapAn.dungSai);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm danh sách đáp án:\n" + ex.Message,
               "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return false;
            }
            return false;
        }

        /*
          Phương thức xóa danh sách đáp án theo Mã Câu Hỏi
             Input: maCauHoi
             Output: boolean
             Created by: Đỗ Mai Anh

        */
        public bool XoaDSDapAnTheoMaCauHoi(int maCauHoi)
        {
            try
            {
                string sql = "DELETE FROM dapan WHERE maCauHoi = @maCauHoi";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // LẤY DANH SÁCH ĐÁP ÁN THEO MÃ CÂU HỎI
        public List<DapAn> GetDapAnByCauHoi(int maCauHoi)
        {
            List<DapAn> result = new List<DapAn>();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT maDapAn, maCauHoi, tenDapAn, dungSai FROM dapan WHERE maCauHoi = @maCauHoi ORDER BY maDapAn";
                    
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new DapAn
                                {
                                    maDapAn = reader.GetInt32("maDapAn"),
                                    maCauHoi = reader.GetInt32("maCauHoi"),
                                    tenDapAn = reader.GetString("tenDapAn"),
                                    dungSai = reader.GetInt32("dungSai")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy đáp án theo câu hỏi: {ex.Message}");
            }
            return result;
        }
    }

}
