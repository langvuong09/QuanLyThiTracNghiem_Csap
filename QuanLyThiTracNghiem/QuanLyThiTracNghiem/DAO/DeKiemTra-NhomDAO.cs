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
    internal class DeKiemTra_NhomDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListDKT_Nhom()
        {
            ArrayList listDKT_Nhom = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM dekiemtra-nhom";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DeKiemTra_Nhom dkt_nhom = new DeKiemTra_Nhom
                        {
                            maDe = reader.GetInt32(0),
                            maNhom = reader.GetInt32(1),
                        };
                        listDKT_Nhom.Add(dkt_nhom);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return listDKT_Nhom;
        }

        public bool ThemDKT_Nhom(int maDe, int maNhom)
        {
            try
            {
                string sql = "INSERT INTO dekiemtra-nhom(maDe, maNhom)" +
                    "VaLUES (@maDe, @maNhom)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    cmd.Parameters.AddWithValue("@maNhom", maNhom);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaDKT_NhomOfMaDe(int maDe)
        {
            try
            {
                string sql = "DELETE FROM dekiemtra-nhom WHERE maDe = @maDe";

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

        public bool XoaDKT_NhomOfMaNhom(int maNhom)
        {
            try
            {
                string sql = "DELETE FROM dekiemtra-nhom WHERE maNhom = @maNhom";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maNhom", maNhom);
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
