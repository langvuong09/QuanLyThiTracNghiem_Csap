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
    internal class CauHoiDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListCauHoi()
        {
            ArrayList dsch = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM cauhoi";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CauHoi ch = new CauHoi
                        {
                            maCauHoi = reader.GetInt32(0),
                            maMonHoc = reader.GetString(1),
                            maChuong = reader.GetInt32(2),
                            doKho = reader.GetString(3),
                            noiDungCauHoi = reader.GetString(4),
                        };
                        dsch.Add(ch);
                    }
                }
            }catch (Exception ex)
            {
                return null;
            }
            return dsch;
        }

        public bool ThemCauHoi(int maCauHoi, string maMonHoc, int maChuong, string doKho, string noiDungCauHoi)
        {
            try
            {
                string sql = "INSERT INTO cauhoi(maCauHoi, maMonHoc, maChuong, doKho, noiDungCauHoi)" +
                    "VaLUES (@maCauHoi, @maMonHoc, @maChuong, @doKho, @noiDungCauHoi)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@maChuong", maChuong);
                    cmd.Parameters.AddWithValue("@doKho", doKho);
                    cmd.Parameters.AddWithValue("@noiDungCauHoi", noiDungCauHoi);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaCauHoi(string maCauHoi)
        {
            try
            {
                string sql = "DELETE FROM cauhoi WHERE maCauHoi = @maCauHoi";

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

        public bool SuaCauHoi(int maCauHoi, string maMonHoc, int maChuong, string doKho, string noiDungCauHoi)
        {
            try
            {
                string sql = "UPDATE cauhoi SET maMonHoc = @maMonHoc, maChuong = @maChuong, doKho = @doKho, noiDungCauHoi = @noiDungCauHoi" +
                    " WHERE maCauHoi = @maCauHoi";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@maChuong", maChuong);
                    cmd.Parameters.AddWithValue("@doKho", doKho);
                    cmd.Parameters.AddWithValue("@noiDungCauHoi", noiDungCauHoi);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public CauHoi GetListCauHoiById(int maCauHoi)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM cauhoi WHERE maCauHoi = @maCauHoi";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maCauHoi", maCauHoi);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        CauHoi ch = new CauHoi
                        {
                            maCauHoi = reader.GetInt32(0),
                            maMonHoc = reader.GetString(1),
                            maChuong = reader.GetInt32(2),
                            doKho = reader.GetString(3),
                            noiDungCauHoi = reader.GetString(4),
                        };
                        return ch;
                    }
                    else return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int maxMaCauHoi()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MAX(*) FROM cauhoi";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    return Convert.ToInt32(cmd.ExecuteScalar())+1;

                }
            }catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
