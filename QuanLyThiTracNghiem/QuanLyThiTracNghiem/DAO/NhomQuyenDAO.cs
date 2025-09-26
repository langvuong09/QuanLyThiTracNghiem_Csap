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
                            maQuyen = reader.GetInt32(0),
                            tenQuyen = reader.GetString(1),
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

        public NhomQuyen ThemQuyen(string tenQuyen)
        {
            try
            {
                string sql = "INSERT INTO nhomquyen(tenQuyen) VALUES (@tenQuyen)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tenQuyen", tenQuyen);

                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        long newId = cmd.LastInsertedId;

                        return new NhomQuyen
                        {
                            maQuyen = (int)newId,
                            tenQuyen = tenQuyen
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }


        public bool XoaQuyen(int maQuyen)
        {
            try
            {
                string sql = "DELETE FROM nhomquyen WHERE maQuyen = @maQuyen";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maQuyen", maQuyen);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public NhomQuyen GetNhomQuyen(int maQuyen)
        {
            ArrayList dsnq = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhomquyen WHERE maQuyen = @maQuyen";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maQuyen", maQuyen);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        NhomQuyen q = new NhomQuyen
                        {
                            maQuyen = reader.GetInt32(0),
                            tenQuyen = reader.GetString(1),
                        };
                        return q;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
    }
}
