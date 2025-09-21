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
        public ArrayList GetListThongBao(int maThongBao)
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
                        ThongBao tb= new ThongBao
                        {
                            maThongBao = reader.GetInt32(0),
                            tenThongBao = reader.GetString(1),
                            noiDung = reader.GetString(2),
                        };
                        dstb.Add(tb);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dstb;
        }

        public bool ThemThongBao(int maThongBao, string tenThongBao, string noiDung)
        {
            try
            {
                string sql = "INSERT INTO thongbao(maThongBao, tenThongBao, noiDung)" +
                    "VaLUES (@maThongBao, @tenThongBao, @noiDung)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maThongBao", maThongBao);
                    cmd.Parameters.AddWithValue("@tenThongBao", tenThongBao);
                    cmd.Parameters.AddWithValue("@noiDung", noiDung);

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
