using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

/*
 * File: CTDeKiemTraDAO.cs
 * Mô tả: DAO cho bảng ctdekiemtra
 * Chức năng:
 *   - Lấy danh sách chương của đề thi
 *   - Thêm chương vào đề thi
 *   - Xóa chương của đề thi
 * Dùng trong: Dialog_TaoDeThi
 * Created by: Hoàng Quyên
 */
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
            catch (Exception)
            {
                return null;
            }
            return dsctdkt;
        }

        /// <summary>
        /// Thêm một chương vào đề thi.
        /// Dùng trong: <see cref="QuanLyThiTracNghiem.GUI.Dialog_TaoDeThi"/> (khi tạo mới hoặc cập nhật đề thi).
        /// </summary>
        /// <param name="maDe">Mã đề thi.</param>
        /// <param name="maMonHoc">Mã môn học.</param>
        /// <param name="maChuong">Mã chương cần thêm.</param>
        /// <returns>true nếu thêm thành công, false nếu có lỗi.</returns>
        /// Created by: Hoàng Quyên
        public bool ThemCTDeKiemTra(int maDe, string maMonHoc, int maChuong)
        {
            try
            {
                string sql = "INSERT INTO ctdekiemtra(maDe, maMonHoc, maChuong)" +
                    "VALUES (@maDe, @maMonHoc, @maChuong)";
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
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm chương vào đề thi: {ex.Message}");
                Console.WriteLine($"maDe: {maDe}, maMonHoc: {maMonHoc}, maChuong: {maChuong}");
                return false;
            }
        }

        /// <summary>
        /// Xóa tất cả chương của đề thi.
        /// Dùng trong: <see cref="QuanLyThiTracNghiem.GUI.Dialog_TaoDeThi"/> (khi tạo mới hoặc cập nhật đề thi).
        /// </summary>
        /// <param name="maDe">Mã đề thi.</param>
        /// <returns>true nếu xóa thành công, false nếu có lỗi.</returns>
        /// Created by: Hoàng Quyên
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
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa chương của đề thi: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa một chương cụ thể của đề thi.
        /// </summary>
        /// <param name="maDe">Mã đề thi.</param>
        /// <param name="maMonHoc">Mã môn học.</param>
        /// <param name="maChuong">Mã chương.</param>
        /// <returns>True nếu thành công, False nếu có lỗi.</returns>
        /// Created by: Hoàng Quyên
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
            catch (Exception)
            {
                return false;
            }
        }

        /*
         * Phương thức lấy danh sách chương theo mã đề thi
         * Input: int maDe - Mã đề thi cần lấy danh sách chương
         * Output: ArrayList - Danh sách các đối tượng CTDeKiemTra
         * Dùng trong: Dialog_TaoDeThi (để load lại chương đã chọn khi chỉnh sửa đề thi)
         * Created by: Hoàng Quyên
         */
        public ArrayList GetListCTDeKiemTraByMaDe(int maDe)
        {
            ArrayList dsctdkt = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM ctdekiemtra WHERE maDe = @maDe";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
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
            catch (Exception)
            {
                return null;
            }
            return dsctdkt;
        }
    }
}
