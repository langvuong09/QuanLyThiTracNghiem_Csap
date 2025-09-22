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
    internal class CTNhomQuyenDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListCTNhomQuyen()
        {
            ArrayList dsctnq = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM ctnhomquyen";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CTNhomQuyen ctnq = new CTNhomQuyen
                        {
                            quyen = reader.GetString(0),
                            tenQuyen = reader.GetString(1),
                            xem = reader.GetInt32(2),
                            them = reader.GetInt32(3),
                            capNhat = reader.GetInt32(4),
                            xoa = reader.GetInt32(5),
                        };
                        dsctnq.Add(ctnq);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsctnq;
        }

        public ArrayList GetListCTNhomQuyen(string quyen)
        {
            ArrayList dsctnq = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM ctnhomquyen WHERE quyen = @quyen";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@quyen", quyen);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CTNhomQuyen ctnq = new CTNhomQuyen
                        {
                            quyen = reader.GetString(0),
                            tenQuyen = reader.GetString(1),
                            xem = reader.GetInt32(2),
                            them = reader.GetInt32(3),
                            capNhat = reader.GetInt32(4),
                            xoa = reader.GetInt32(5),
                        };
                        dsctnq.Add(ctnq);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsctnq;
        }

        public bool ThemCTNhomQuyen(string quyen, string tenQuyen, int xem, int them, int capNhat, int xoa)
        {
            try
            {
                string sql = "INSERT INTO ctnhomquyen(quyen, tenQuyen, xem, them, capNhat, xoa)" +
                    "VaLUES (@quyen, @tenQuyen, @xem, @them, @capNhat, @xoa)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@quyen", quyen);
                    cmd.Parameters.AddWithValue("@tenQuyen", tenQuyen);
                    cmd.Parameters.AddWithValue("@xem", xem);
                    cmd.Parameters.AddWithValue("@them", them);
                    cmd.Parameters.AddWithValue("@capNhat", capNhat);
                    cmd.Parameters.AddWithValue("@xoa", xoa);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaCTNhomQuyen(string quyen)
        {
            try
            {
                string sql = "DELETE FROM ctnhomquyen WHERE quyen = @quyen";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@quyen", quyen);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SuaCTNhomQuyen(string quyen, string tenQuyen, int xem, int them, int capNhat, int xoa)
        {
            try
            {
                string sql = "UPDATE ctnhomquyen SET xem = @xem, them = @them, capNhat = @capNhat, xoa = @xoa WHERE quyen = @quyen AND tenQuyen = @tenQuyen";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@xem", xem);
                    cmd.Parameters.AddWithValue("@them", them);
                    cmd.Parameters.AddWithValue("@capNhat", capNhat);
                    cmd.Parameters.AddWithValue("@xoa", xoa);
                    cmd.Parameters.AddWithValue("@quyen", quyen);
                    cmd.Parameters.AddWithValue("@tenQuyen", tenQuyen);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}
