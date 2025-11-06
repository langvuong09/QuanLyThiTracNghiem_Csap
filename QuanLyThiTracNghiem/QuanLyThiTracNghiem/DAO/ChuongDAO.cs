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
    internal class ChuongDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListChuongOfMaMonHoc(string maMonHoc)
        {
            ArrayList dsc = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM chuong WHERE maMonHoc = @maMonHoc";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Chuong c = new Chuong
                        {
                            maChuong = reader.GetInt32(0),
                            maMonHoc = reader.GetString(1),
                            tenChuong = reader.GetString(2),
                        };
                        dsc.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsc;
        }

        public bool ThemChuong(int maChuong, string maMonHoc, string tenChuong)
        {
            try
            {
                string sql = "INSERT INTO chuong(maChuong, maMonHoc, tenChuong)" +
                    "VaLUES (@maChuong, @maMonHoc, @tenChuong)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maChuong", maChuong);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@tenChuong", tenChuong);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaChuong(int maChuong, string maMonHoc)
        {
            try
            {
                string sql = "DELETE FROM chuong WHERE maChuong = @maChuong AND maMonHoc = @maMonHoc";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maChuong", maChuong);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaChuongOfMaMonHoc(string maMonHoc)
        {
            try
            {
                string sql = "DELETE FROM chuong WHERE maMonHoc = @maMonHoc";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected >= 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SuaChuong(int maChuong, string maMonHoc, string tenChuong)
        {
            try
            {
                string sql = "UPDATE chuong SET tenChuong = @tenChuong WHERE maChuong = @maChuong AND maMonHoc = @maMonHoc";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tenChuong", tenChuong);
                    cmd.Parameters.AddWithValue("@maChuong", maChuong);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        // ==========================================
        // LẤY TẤT CẢ CHƯƠNG TỪ DATABASE
        // ==========================================
        public ArrayList GetAllChuong()
        {
            ArrayList dsc = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM chuong ORDER BY maMonHoc, maChuong";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Chuong c = new Chuong
                        {
                            maChuong = reader.GetInt32(0),
                            maMonHoc = reader.GetString(1),
                            tenChuong = reader.GetString(2),
                        };
                        dsc.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsc;
        }
    }
}
