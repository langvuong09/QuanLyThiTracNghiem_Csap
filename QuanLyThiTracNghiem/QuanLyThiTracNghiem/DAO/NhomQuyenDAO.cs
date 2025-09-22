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
    internal class NhomQuyenDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListNhomQuyen()
        {
            ArrayList dsnq = new ArrayList();
            try
            {
                using(MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhomquyen";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NhomQuyen q = new NhomQuyen
                        {
                            quyen = reader.GetString(0),
                        };
                        dsnq.Add(q);
                    }
                }
            }catch (Exception ex)
            {
                return null;
            }
            return dsnq;
        }

        public bool ThemQuyen(string quyen)
        {
            try
            {
                string sql = "INSERT INTO nhomquyen(quyen)" +
                    "VaLUES (@quyen)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@quyen", quyen);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaQuyen(string quyen)
        {
            try
            {
                string sql = "DELETE FROM nhomquyen WHERE quyen = @quyen";

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

        public ArrayList GetNhomQuyen(string quyen)
        {
            ArrayList dsnq = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhomquyen WHERE quyen = @quyen";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@quyen", quyen);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NhomQuyen q = new NhomQuyen
                        {
                            quyen = reader.GetString(0),
                        };
                        dsnq.Add(q);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsnq;
        }
    }
}
