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
    internal class ThongBaoDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListThongBao()
        {
            ArrayList dstb = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM thongbao";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ThongBao tb = new ThongBao
                        {
                            maThongBao = reader.GetInt32("maThongBao"),
                            tenThongBao = reader.GetString("tenThongBao"),
                            noiDung = reader.GetString("noiDung"),
                            maMonHoc = reader.GetString("maMonHoc"),
                            thoiGian = reader.GetDateTime("thoiGian")
                        };
                        dstb.Add(tb);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dstb;
        }

        public int GetMaxMaThongBao()
        {
            int maxMa = 0;
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MAX(maThongBao) FROM thongbao";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        maxMa = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return maxMa;
        }


        public bool ThemThongBao(string maThongBao, string tenThongBao, string noiDung, string maMonHoc, DateTime thoiGian)
        {
            try
            {
                string sql = "INSERT INTO thongbao(maThongBao, tenThongBao, noiDung, maMonHoc, thoiGian)" +
                    "VaLUES (@maThongBao, @tenThongBao, @noiDung, @maMonHoc, @thoiGian)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maThongBao", maThongBao);
                    cmd.Parameters.AddWithValue("@tenThongBao", tenThongBao);
                    cmd.Parameters.AddWithValue("@noiDung", noiDung);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@thoiGian", thoiGian);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaThongBao(int maThongBao)
        {
            try
            {
                string sql = "DELETE FROM thongbao WHERE maThongBao = @maThongBao";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maThongBao", maThongBao);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SuaThongBao(int maThongBao, string tenThongBao, string noiDung)
        {
            try
            {
                string sql = "UPDATE thongbao SET tenThongBao = @tenThongBao, noiDung = @noiDung" +
                    " WHERE maThongBao = @maThongBao";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tenThongBao", tenThongBao);
                    cmd.Parameters.AddWithValue("@noiDung", noiDung);
                    cmd.Parameters.AddWithValue("@maThongBao", maThongBao);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }       
    }
}
