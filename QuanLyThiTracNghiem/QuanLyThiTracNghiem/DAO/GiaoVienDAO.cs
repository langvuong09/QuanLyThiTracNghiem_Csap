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
                            gioiTinh = reader.GetString(3),
                            ngaySinh = reader.GetDateTime(4),
                            anhDaiDien = reader.GetString(5),
                            
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

        public bool ThemGiaoVien(string maGiaoVien, string tenGiaoVien, string email, string gioiTinh, DateTime ngaySinh, string anhDaiDien, string quyen)
        {
            try
            {
                string sql = "INSERT INTO giaovien(maGiaoVien, tenGiaoVien, email, gioiTinh, ngaySinh, anhDaiDien, quyen)" +
                    "VaLUES (@maGiaoVien, @tenGiaoVien, @email, @gioiTinh, @ngaySinh, @anhDaiDien, @quyen)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);
                    cmd.Parameters.AddWithValue("@tenGiaoVien", tenGiaoVien);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@gioiTinh", "Nam");
                    cmd.Parameters.AddWithValue("@ngaySinh", new DateTime(2000, 1, 1));
                    cmd.Parameters.AddWithValue("@anhDaiDien", "default.jpg");
                    cmd.Parameters.AddWithValue("@maQuyen", 3);

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

        public bool SuaGiaoVien(string maGiaoVien, string tenGiaoVien, string email, string gioiTinh, DateTime ngaySinh, string anhDaiDien)
        {
            try
            {
                string sql = "UPDATE giaovien SET tenGiaoVien = @tenGiaoVien, email = @email, ngaySinh = @ngaySinh," +
                    "anhDaiDien = @anhDaiDien + WHERE maGiaoVien = @maGiaoVien";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);              
                    cmd.Parameters.AddWithValue("@tenGiaoVien", tenGiaoVien);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@anhDaiDien", anhDaiDien);
                    cmd.Parameters.AddWithValue("@maSinhVien", maGiaoVien);

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
                            gioiTinh = reader.GetString(3),
                            ngaySinh =  reader.GetDateTime(4),
                            anhDaiDien = reader.GetString(5),
                            quyen = reader.GetString(6),
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
