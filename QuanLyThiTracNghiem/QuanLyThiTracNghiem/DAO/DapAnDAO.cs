using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    internal class DapAnDAO
    {
        private MyConnect db = new MyConnect();
        public bool ThemDapAn(int maDapAn, int maCauHoi, string tenDapAn, int dungSai)
        {
            try
            {
                string sql = "INSERT INTO dapan(maDapAn, maCauHoi, tenDapAn, dungSai)" +
                    "VaLUES (@maDapAn, @maCauHoi, @tenDapAn, @dungSai)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDapAn", maDapAn);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                    cmd.Parameters.AddWithValue("@tenDapAn", tenDapAn);
                    cmd.Parameters.AddWithValue("@dungSai", dungSai);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaDapAn(int maDapAn, int maCauHoi)
        {
            try
            {
                string sql = "DELETE FROM dapan WHERE maDapAn = @maDapAn AND maCauHoi = @maCauHoi";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDapAn", maDapAn);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaDapAnTheoCauHoi(int maCauHoi)
        {
            try
            {
                string sql = "DELETE FROM dapan WHERE maCauHoi = @maCauHoi";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
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
