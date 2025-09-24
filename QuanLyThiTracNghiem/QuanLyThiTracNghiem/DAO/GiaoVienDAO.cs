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
    internal class GiaoVienDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListGiaoVien()
        {
            ArrayList dsgv = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM giaovien";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GiaoVien gv = new GiaoVien
                        {
                            maGiaoVien = reader.GetString(0),
                            tenGiaoVien = reader.GetString(1),
                            email = reader.GetString(2),
                            SDT = reader.GetString(3),
                            moTa = reader.GetString(4),
                            quyen = reader.GetString(5),
                        };
                        dsgv.Add(gv);
                    }
                }
            }catch (Exception ex)
            {
                return null;
            }
            return dsgv;
        }

        public bool ThemGiaoVien(string maGiaoVien, string tenGiaoVien, string email, string SDT, string moTa)
        {
            try
            {
                string sql = "INSERT INTO giaovien(maGiaoVien, tenGiaoVien, email, SDT, moTa, maChucNang)" +
                    "VaLUES (@maGiaoVien, @tenGiaoVien, @email, @SDT, @moTa, 2)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);
                    cmd.Parameters.AddWithValue("@tenGiaoVien", tenGiaoVien);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@SDT", SDT);
                    cmd.Parameters.AddWithValue("@moTa", moTa);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }catch(Exception ex) { return false; }
        }

        public bool XoaGiaoVien(string maGiaoVien)
        {
            try
            {
                string sql = "DELETE FROM giaovien WHERE maGiaoVien = @maGiaoVien";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SuaGiaoVien(string maGiaoVien, string tenGiaoVien, string email, string SDT, string moTa)
        {
            try
            {
                string sql = "UPDATE giaovien SET tenGiaoVien = @tenGiaoVien, email = @email, SDT = @SDT, moTa = @moTa" +
                    " WHERE maGiaoVien = @maGiaoVien";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);              
                    cmd.Parameters.AddWithValue("@tenGiaoVien", tenGiaoVien);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@SDT", SDT);
                    cmd.Parameters.AddWithValue("@moTa", moTa);
                    cmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }
        
        public GiaoVien getGiaoVienByID(string maGiaoVien)
        {
            try
            {
                string sql = "SELECT * FROM giaovien WHERE maGiaoVien = @maGiaoVien";
                using(MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        GiaoVien gv = new GiaoVien
                        {
                            maGiaoVien = reader.GetString(0),
                            tenGiaoVien = reader.GetString(1),
                            email = reader.GetString(2),
                            SDT = reader.GetString(3),
                            moTa = reader.GetString(4),
                            quyen = reader.GetString(5),
                        };
                        return gv;
                    }
                    else return null;
                }
            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}
