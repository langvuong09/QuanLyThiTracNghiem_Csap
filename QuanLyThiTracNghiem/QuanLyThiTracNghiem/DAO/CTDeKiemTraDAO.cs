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
    internal class CTDeKiemTraDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListCTDeKiemTra()
        {
            ArrayList dsctdkt = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM ctdekiemtra";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CTDeKiemTra ctdkt = new CTDeKiemTra
                        {
                            maDe = reader.GetInt32(0),
                            maMonHoc = reader.GetString(1),
                            maChuong = reader.GetInt32(2),
                        };
                        dsctdkt.Add(ctdkt);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsctdkt;
        }

        public bool ThemCTDeKiemTra(int maDe, string maMonHoc, int maChuong)
        {
            try
            {
                string sql = "INSERT INTO ctdekiemtra(maDe, maMonHoc, maChuong)" +
                    "VaLUES (@maDe, @maMonHoc, @maChuong)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@maChuong", maChuong);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaCTDeKiemTra(int maDe)
        {
            try
            {
                string sql = "DELETE FROM ctdekiemtra WHERE maDe = @maDe";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaCTDeKiemTra(int maDe, string maMonHoc, int maChuong)
        {
            try
            {
                string sql = "DELETE FROM ctdekiemtra WHERE maDe = @maDe AND maMonHoc = @maMonHoc AND maChuong = @maChuong";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@maChuong", maChuong);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
