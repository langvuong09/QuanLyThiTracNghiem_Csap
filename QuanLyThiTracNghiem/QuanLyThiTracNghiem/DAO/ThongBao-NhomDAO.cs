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
    internal class ThongBao_NhomDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListTB_Nhom()
        {
            ArrayList dsch = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM `thongbao-nhom`";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ThongBao_Nhom tb_nhom = new ThongBao_Nhom
                        {
                            maNhom = reader.GetInt32(0),
                            maThongBao = reader.GetInt32(1),                           
                        };
                        dsch.Add(tb_nhom);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsch;
        }

        public bool ThemThongBao(int maNhom, int maThongBao)
        {
            try
            {
                string sql = "INSERT INTO `thongbao-nhom`(maNhom, maThongBao)" +
                    "VaLUES (@maNhom, @maThongBao)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maNhom", maNhom);
                    cmd.Parameters.AddWithValue("@maThongBao", maThongBao);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaThongBao(int maThongBao)
        {
            try
            {
                string sql = "DELETE FROM `thongbao-nhom` WHERE maThongBao = @maThongBao";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maThongBao", maThongBao);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ArrayList GetListTB_Nhom(int maThongBao)
        {
            ArrayList dsch = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM `thongbao-nhom` WHERE maThongBao = @maThongBao";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maThongBao", maThongBao);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        ThongBao_Nhom tb_nhom = new ThongBao_Nhom
                        {
                            maNhom = reader.GetInt32(0),
                            maThongBao = reader.GetInt32(1),
                        };
                        dsch.Add(tb_nhom);
                    }
                }
                return dsch;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
