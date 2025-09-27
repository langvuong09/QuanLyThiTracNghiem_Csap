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
                            maQuyen = reader.GetInt32(0),
                            maChucNang = reader.GetInt32(1),
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
        public List<CTNhomQuyen> FindByMaQuyen(int maQuyen)
        {
            var list = new List<CTNhomQuyen>();
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT ctnq.maQuyen, ctnq.maChucNang, cn.tenChucNang, 
                              ctnq.xem, ctnq.them, ctnq.capNhat, ctnq.xoa
                       FROM ctnhomquyen ctnq
                       JOIN chucnang cn ON ctnq.maChucNang = cn.maChucNang
                       WHERE ctnq.maQuyen = @maQuyen";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maQuyen", maQuyen);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new CTNhomQuyen
                    {
                        maQuyen = reader.GetInt32("maQuyen"),
                        maChucNang = reader.GetInt32("maChucNang"),
                        tenChucNang = reader.GetString("tenChucNang"),
                        xem = reader.GetInt32("xem"),
                        them = reader.GetInt32("them"),
                        capNhat = reader.GetInt32("capNhat"),
                        xoa = reader.GetInt32("xoa")
                    });
                }
            }
            return list;
        }

        public ArrayList GetListCTNhomQuyen(int maQuyen)
        {
            ArrayList dsctnq = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM ctnhomquyen WHERE maQuyen = @maQuyen";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maQuyen", maQuyen);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CTNhomQuyen ctnq = new CTNhomQuyen
                        {
                            maQuyen = reader.GetInt32(0),
                            maChucNang = reader.GetInt32(1),
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

        public bool ThemCTNhomQuyen(int maQuyen, int maChucNang, int xem, int them, int capNhat, int xoa)
        {
            try
            {
                string sql = "INSERT INTO ctnhomquyen(maQuyen, maChucNang, xem, them, capNhat, xoa)" +
                    "VaLUES (@maQuyen, @maChucNang, @xem, @them, @capNhat, @xoa)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maQuyen", maQuyen);
                    cmd.Parameters.AddWithValue("@maChucNang", maChucNang);
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

        public bool XoaCTNhomQuyen(int maQuyen)
        {
            try
            {
                string sql = "DELETE FROM ctnhomquyen WHERE maQuyen = @maQuyen";

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

        public bool SuaCTNhomQuyen(int maQuyen, int maChucNang, int xem, int them, int capNhat, int xoa)
        {
            try
            {
                string sql = "UPDATE ctnhomquyen SET xem = @xem, them = @them, capNhat = @capNhat, xoa = @xoa WHERE maQuyen = @maQuyen AND maChucNang = @maChucNang";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@xem", xem);
                    cmd.Parameters.AddWithValue("@them", them);
                    cmd.Parameters.AddWithValue("@capNhat", capNhat);
                    cmd.Parameters.AddWithValue("@xoa", xoa);
                    cmd.Parameters.AddWithValue("@maQuyen", maQuyen);
                    cmd.Parameters.AddWithValue("@maChucNang", maChucNang);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}
