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
    internal class DeKiemTraDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListDeKiemTra()
        {
            ArrayList dsdkt = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM dekiemtra";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DeKiemTra dkt = new DeKiemTra
                        {
                            maDe = reader.GetInt32(0),
                            tenDe = reader.GetString(1),
                            thoiGianBatDau = reader.GetDateTime(2),
                            thoiGianKetThuc = reader.GetDateTime(3),
                            thoiGianCanhBao = reader.GetDateTime(4),
                            soCauDe = reader.GetInt32(5),
                            soCauTrungBinh = reader.GetInt32(6),
                            soCauKho =reader.GetInt32(7),
                            trangThai =reader.GetInt32(8),
                        };
                        dsdkt.Add(dkt);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsdkt;
        }

        public bool ThemDeKiemTra(int maDe, string tenDe, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, DateTime thoiGianCanhBao, int soCauDe, int soCauTrungBinh, int soCauKho)
        {
            try
            {
                string sql = "INSERT INTO dekiemtra(maDe, tenDe, thoiGianBatDau, thoiGianKetThuc, thoiGianCanhBao, soCauDe, soCauTrungBinh, soCauKho, trangThai)" +
                    "VaLUES (@maDe, @tenDe, @thoiGianBatDau, @thoiGianKetThuc, @thoiGianCanhBao, @soCauDe, @soCauTrungBinh, @soCauKho, 1)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    cmd.Parameters.AddWithValue("@tenDe", tenDe);
                    cmd.Parameters.AddWithValue("@thoiGianBatDau", thoiGianBatDau);
                    cmd.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
                    cmd.Parameters.AddWithValue("@thoiGianCanhBao", thoiGianCanhBao);
                    cmd.Parameters.AddWithValue("@soCauDe", soCauDe);
                    cmd.Parameters.AddWithValue("@soCauTrungBinh", soCauTrungBinh);
                    cmd.Parameters.AddWithValue("@soCauKho", soCauKho);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaDeKiemTra(int maDe)
        {
            try
            {
                string sql = "UPDATE dekiemtra SET trangThai = 0 WHERE maDe = @maDe";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SuaDeKiemTra(int maDe, string tenDe, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, DateTime thoiGianCanhBao, int soCauDe, int soCauTrungBinh, int soCauKho)
        {
            try
            {
                string sql = "UPDATE dekiemtra SET tenDe = @tenDe, thoiGianBatDau = @thoiGianBatDau, thoiGianKetThuc = @thoiGianKetThuc, thoiGianCanhBao = @thoiGianCanhBao, soCauDe = @soCauDe, soCauTrungBinh = @soCauTrngBinh, @soCauKho" +
                    " WHERE maDe = @maDe";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);                  
                    cmd.Parameters.AddWithValue("@tenDe", tenDe);
                    cmd.Parameters.AddWithValue("@thoiGianBatDau", thoiGianBatDau);
                    cmd.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
                    cmd.Parameters.AddWithValue("@thoiGianCanhBao", thoiGianCanhBao);
                    cmd.Parameters.AddWithValue("@soCauDe", soCauDe);
                    cmd.Parameters.AddWithValue("@soCauTrungBinh", soCauTrungBinh);
                    cmd.Parameters.AddWithValue("@soCauKho", soCauKho);
                    cmd.Parameters.AddWithValue("@maDe", maDe);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public DeKiemTra getDeKiemTraByID(int maDe)
        {
            try
            {
                string sql = "SELECT * FROM dekiemtra WHERE maDe = @maDe";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DeKiemTra dkt = new DeKiemTra
                        {
                            maDe = reader.GetInt32(0),
                            tenDe = reader.GetString(1),
                            thoiGianBatDau = reader.GetDateTime(2),
                            thoiGianKetThuc = reader.GetDateTime(3),
                            thoiGianCanhBao = reader.GetDateTime(4),
                            soCauDe = reader.GetInt32(5),
                            soCauTrungBinh = reader.GetInt32(6),
                            soCauKho = reader.GetInt32(7),
                            trangThai = reader.GetInt32(8),
                        };
                        return dkt;
                    }
                    else return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
