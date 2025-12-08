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
    internal class CauHoi_DeKiemTraDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListCH_DKT()
        {
            ArrayList listCH_DKT = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM `cauhoi-dekiemtra`";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CauHoi_DeKiemTra ch_dkt = new CauHoi_DeKiemTra
                        {
                            maDe = reader.GetInt32(0),
                            maCauHoi = reader.GetInt32(1),
                        };
                        listCH_DKT.Add(ch_dkt);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return listCH_DKT;
        }

        public bool ThemCH_DKT(int maDe, int maCauHoi)
        {
            try
            {
                string sql = "INSERT INTO `cauhoi-dekiemtra`(maDe, maCauHoi) " +
                    "VALUES (@maDe, @maCauHoi)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"Lỗi khi thêm câu hỏi vào đề thi: {ex.Message}");
                return false; 
            }
        }

        public bool XoaCH_DKT(int maDe)
        {
            try
            {
                string sql = "DELETE FROM `cauhoi-dekiemtra` WHERE maDe = @maDe";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected >= 0; // >= 0 vì có thể không có dữ liệu để xóa
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa câu hỏi của đề thi: {ex.Message}");
                return false;
            }
        }
    }
}
