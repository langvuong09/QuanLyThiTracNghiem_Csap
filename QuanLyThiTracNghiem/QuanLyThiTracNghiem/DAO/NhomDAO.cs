using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;



namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    internal class NhomDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListNhom()
        {
            ArrayList dsn = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhom";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Nhom nhom = new Nhom
                        {
                            maNhom = reader.GetInt32(0),
                            tenNhom = reader.GetString(1),
                            ghiChu = !reader.IsDBNull(2) ? reader.GetString(2) : "",
                            maMonHoc = reader.GetString(3),
                            maGiaoVien = reader.GetString(4),
                            namHoc = reader.GetInt32(5),
                            hocKy = reader.GetInt32(6),
                        };
                        dsn.Add(nhom);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ArrayList();
            }
            return dsn;
        }

        public ArrayList GetListNhom(string maMonHoc)
        {
            ArrayList dsn = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhom WHERE maMonHoc = @maMonHoc";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Nhom nhom = new Nhom
                        {
                            maNhom = reader.GetInt32(0),
                            tenNhom = reader.GetString(1),
                            ghiChu = reader.GetString(2),
                            maMonHoc = reader.GetString(3),
                            maGiaoVien = reader.GetString(4),
                            namHoc = reader.GetInt32(5),
                            hocKy = reader.GetInt32(6),
                        };
                        dsn.Add(nhom);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsn;
        }

        public bool ThemNhom(string tenNhom, string ghiChu, string maMonHoc,string maGiaoVien, int namHoc, int hocKy)
        {
            try
            {
                string sql = "INSERT INTO nhom(tenNhom, ghiChu, maMonHoc, maGiaoVien, namHoc, hocKy)" +
                    "VaLUES (@tenNhom, @ghiChu, @maMonHoc, @maGiaoVien, @namHoc, @hocKy)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tenNhom", tenNhom);
                    cmd.Parameters.AddWithValue("@ghiChu", ghiChu);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);
                    cmd.Parameters.AddWithValue("@namHoc", namHoc);
                    cmd.Parameters.AddWithValue("@hocKy", hocKy);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaNhom(int maNhom)
        {
            try
            {
                string sql = "DELETE FROM nhom WHERE maNhom = @maNhom";

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

        public bool SuaNhom(int maNhom, string tenNhom, string ghiChu, string maMonHoc, string maGiaoVien, int namHoc, int hocKy)
        {
            try
            {
                string sql = "UPDATE nhom SET maNhom = @maNhom, tenNhom = @tenNhom, ghiChu = @ghiChu, maMonHoc = @maMonHoc, maGiaoVien = @maGiaoVien, namHoc = @namHoc, hocKy = @hocKy" +
                    " WHERE maCauHoi = @maCauHoi";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maNhom", maNhom);
                    cmd.Parameters.AddWithValue("@tenNhom", tenNhom);
                    cmd.Parameters.AddWithValue("@ghiChu", ghiChu);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);
                    cmd.Parameters.AddWithValue("@namHoc", namHoc);
                    cmd.Parameters.AddWithValue("@hocKy", hocKy);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }



        public int maxMaNhom()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MAX(*) FROM nhom";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    return Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /*
         Phương thức lấy danh sách nhóm mà sinh viên theo học 
         Là phương thức sử dụng 2 bảng:
            bảng nhomthamgia có (maNhom, maSinhVien)
            bảng nhom (maNhom, tenNhom, )
         */
        public ArrayList getListNhomTheoMaSinhVien (String maSinhVien)
        {
            ArrayList dsn = new ArrayList();
                        try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhom n JOIN nhomthamgia ntg ON ntg.maNhom = n.maNhom WHERE ntg.maSinhVien = @maSinhVien";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Nhom nhom = new Nhom
                        {
                            maNhom = reader.GetInt32(0),
                            tenNhom = reader.GetString(1)
                        };
                        dsn.Add(nhom);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DAO=> Lối khi lấy danh sách nhóm theo mã sinh viên",ex.Message);
                return null;
            }

            return dsn;
        }
    }
}
