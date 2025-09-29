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
    internal class ChucNangDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListChucNang()
        {
            ArrayList dscn = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM chucnang";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ChucNang cn = new ChucNang
                        {
                            maChucNang = reader.GetInt32(0),
                            tenChucNang = reader.GetString(1),
                            
                        };
                        dscn.Add(cn);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dscn;
        }

        public bool ThemChucNang(int maChucNang, string tenChucNang)
        {
            try
            {
                string sql = "INSERT INTO chucnang(maChucNang, tenChucNang)" +
                    "VaLUES (@maChucNang,@tenChucNang)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maChucNang", maChucNang);
                    cmd.Parameters.AddWithValue("@tenChucNang", tenChucNang);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaChucNang(int maChucNang)
        {
            try
            {
                string sql = "DELETE FROM chucnang WHERE maChucNang = @maChucNang";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maChucNang", maChucNang);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ChucNang GetChucNang(int maChucNang)
        {
            ArrayList dscn = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM chucnang WHERE maChucNang = @maChucNang";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maChucNang", maChucNang);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ChucNang cn = new ChucNang
                        {
                            maChucNang = reader.GetInt32(0),
                            tenChucNang = reader.GetString(1),

                        };
                        return cn;
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
