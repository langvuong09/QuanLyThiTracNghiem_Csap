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
    internal class MonHocDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListMonHoc()
        {
            ArrayList listMonHoc = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM monhoc";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        MonHoc monHoc = new MonHoc
                        {
                            maMonHoc = reader.GetString(0),
                            tenMonHoc = reader.GetString(1),
                            tinChi = reader.GetInt32(2),
                            soTietLyThuyet = reader.GetInt32(3),
                            soTietThucHanh = reader.GetInt32(4),
                            heSo = reader.GetInt32(5),
                        };
                        listMonHoc.Add(monHoc);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return listMonHoc;
        }

        public bool ThemMonHoc(string maMonHoc, string tenMonHoc, int tinChi, int soTietLyThuyet, int soTietThucHanh, int heSo)
        {
            try
            {
                string sql = "INSERT INTO monhoc(maMonHoc, tenMonHoc, tinChi, soTietLyThuyet, soTietThucHanh, heSo)" +
                    "VaLUES (@maMonHoc, @tenMonHoc, @tinChi, @soTietLyThuyet, @soTietThucHanh, @heSo)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@tenMonHoc", tenMonHoc);
                    cmd.Parameters.AddWithValue("@tinChi", tinChi);
                    cmd.Parameters.AddWithValue("@soTietLyThuyet", soTietLyThuyet);
                    cmd.Parameters.AddWithValue("@soTietThucHanh", soTietThucHanh);
                    cmd.Parameters.AddWithValue("@heSo", heSo);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaMonHoc(string maMonHoc)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand disableFK = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0;", conn);
                    disableFK.ExecuteNonQuery();

                    string sql = "DELETE FROM monhoc WHERE maMonHoc = @maMonHoc";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
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


        public bool SuaMonHoc(string maMonHoc, string tenMonHoc, int tinChi, int soTietLyThuyet, int soTietThucHanh, int heSo)
        {
            try
            {
                string sql = "UPDATE monhoc SET tenMonHoc = @tenMonHoc, tinChi = @tinChi, soTietLyThuyet = @soTietLyThuyet, soTietThucHanh = @soTietThucHanh," +
                    "heSo = @heSo WHERE maMonHoc = @maMonHoc";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tenMonHoc", tenMonHoc);
                    cmd.Parameters.AddWithValue("@tinChi", tinChi);
                    cmd.Parameters.AddWithValue("@soTietLyThuyet", soTietLyThuyet);
                    cmd.Parameters.AddWithValue("@soTietThucHanh", soTietThucHanh);
                    cmd.Parameters.AddWithValue("@heSo", heSo);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public MonHoc getMonHocByID(string maMonHoc)
        {
            try
            {
                string sql = "SELECT * FROM monhoc WHERE maMonHoc = @maMonHoc";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MonHoc mh = new MonHoc
                        {
                            maMonHoc = reader.GetString(0),
                            tenMonHoc = reader.GetString(1),
                            tinChi = reader.GetInt32(2),
                            soTietLyThuyet = reader.GetInt32(3),
                            soTietThucHanh = reader.GetInt32(4),
                            heSo = reader.GetInt32(5)
                        };
                        return mh;
                    }
                    else return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetMaxMaMonHoc()
        {
            try
            {
                string sql = "SELECT maMonHoc FROM monhoc ORDER BY maMonHoc DESC LIMIT 1";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string ma = result.ToString();
                        if (ma.Length >= 5)
                        {
                            string so = ma.Substring(ma.Length - 3);
                            return so;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return "000";
        }

    }
}
