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
    internal class NhomQuyenDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListNhomQuyen()
        {
            ArrayList dsnq = new ArrayList();
            try
            {
                using(MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM nhomquyen";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Quyen q = new Quyen
                        {
                            quyen = reader.GetString(0),
                            thamGiaHoatDong = reader.GetInt32(1),
                            qlDeThi = reader.GetInt32(2),
                            qlSinhVien = reader.GetInt32(3),
                            qlGiaoVien = reader.GetInt32(4),
                            qlNhom = reader.GetInt32(5),
                            qlPhanCong = reader.GetInt32(6),
                            qlMon = reader.GetInt32(7),
                            qlCauHoi = reader.GetInt32(8),
                            qlThongBao = reader.GetInt32(9),
                        };
                        dsnq.Add(q);
                    }
                }
            }catch (Exception ex)
            {
                return null;
            }
            return dsnq;
        }
    }
}
