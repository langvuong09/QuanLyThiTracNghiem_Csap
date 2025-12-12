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
            return false;
        }

        public bool XoaCauHoi(int maCauHoi)
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
                    string sql = "SELECT MAX(maCauHoi) FROM cauhoi";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    return Convert.ToInt32(cmd.ExecuteScalar());

                }
            }catch (Exception ex)
            {
                return 0;
            }
        }
        /*
         Phương thức tìm kiếm theo nội dung câu hỏi
            Input: noiDungCauHoi
            Output: CauHoi
            Created by: Đỗ Mai Anh
         */
        public CauHoi TimKiemCauHoiTheoNoiDung(string noiDungCauHoi)
        {
            CauHoi cauHoi = null;
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM cauhoi WHERE LOWER(noiDungCauHoi) LIKE LOWER(@noiDungCauHoi)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@noiDungCauHoi", "%" + noiDungCauHoi + "%");
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        cauHoi = new CauHoi
                        {
                            maCauHoi = reader.GetInt32(0),
                            maMonHoc = reader.GetString(1),
                            maChuong = reader.GetInt32(2),
                            doKho = reader.GetString(3),
                            noiDungCauHoi = reader.GetString(4),
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm câu hỏi: {ex}");
            }
            return cauHoi;
        }


        /*
         Phương thưc Lấy Danh sách Câu hỏi để hiển thị lên DataGridView <Phân trang>
            Input: curentPage, pageSize, maMonHoc, maChuong, doKho 
                   <2 cái đầu là bắt buộc phải có , 
                   3 biến sau có thể đề mặc định>
            Output: ListCauHoi, totalPages
            Created by: Đỗ Mai Anh
         */

        // --------------------- LẤY DANH SÁCH CÂU HỎI (CÓ PHÂN TRANG + LỌC) ---------------------
        public (List<CauHoi> Data, int TotalPages) GetListCauHoiPhanTrang(
            int currentPage,
            int pageSize,
            string maMonHoc = "",
            int maChuong = 0,
            string doKho = "0")
        {
            List<CauHoi> result = new List<CauHoi>();
            int totalRows = 0;

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sqlFilter = "WHERE 1=1";
                    if (!string.IsNullOrEmpty(maMonHoc) && maMonHoc != "0")
                        sqlFilter += " AND maMonHoc = @maMonHoc";
                    if (maChuong > 0)
                        sqlFilter += " AND maChuong = @maChuong";
                    if (doKho != "0")
                        sqlFilter += " AND doKho = @doKho";

                    // Đếm tổng số dòng
                    string sqlCount = $"SELECT COUNT(*) FROM cauhoi {sqlFilter}";
                    using (MySqlCommand countCmd = new MySqlCommand(sqlCount, conn))
                    {
                        if (!string.IsNullOrEmpty(maMonHoc) && maMonHoc != "0")
                            countCmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                        if (maChuong > 0)
                            countCmd.Parameters.AddWithValue("@maChuong", maChuong);
                        if (doKho != "0")
                            countCmd.Parameters.AddWithValue("@doKho", doKho);

                        totalRows = Convert.ToInt32(countCmd.ExecuteScalar());
                    }

                    int offset = Math.Max((currentPage - 1), 0) * pageSize;

                    // Lấy dữ liệu phân trang
                    string sqlData = $@"
                                    SELECT * FROM cauhoi {sqlFilter}
                                    ORDER BY maCauHoi
                                    LIMIT @PageSize OFFSET @Offset";

                    using (MySqlCommand dataCmd = new MySqlCommand(sqlData, conn))
                    {
                        if (!string.IsNullOrEmpty(maMonHoc) && maMonHoc != "0")
                            dataCmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                        if (maChuong > 0)
                            dataCmd.Parameters.AddWithValue("@maChuong", maChuong);
                        if (doKho != "0")
                            dataCmd.Parameters.AddWithValue("@doKho", doKho);

                        dataCmd.Parameters.AddWithValue("@PageSize", pageSize);
                        dataCmd.Parameters.AddWithValue("@Offset", offset);

                        using (MySqlDataReader reader = dataCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new CauHoi
                                {
                                    maCauHoi = reader.GetInt32("maCauHoi"),
                                    maMonHoc = reader.GetString("maMonHoc"),
                                    maChuong = reader.GetInt32("maChuong"),
                                    doKho = reader.GetString("doKho"),
                                    noiDungCauHoi = reader.GetString("noiDungCauHoi")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách câu hỏi phân trang: {ex}");
                
            }

            int totalPages = (int)Math.Ceiling((double)totalRows / pageSize);
            return (result, totalPages);
        }

        public (List<CauHoi> Data, int TotalPages) GetListCauHoiPhanTrang(
            int currentPage,
            int pageSize,
            string maGiaoVien,
            string maMonHoc = "",
            int maChuong = 0,
            string doKho = "0")
        {
            List<CauHoi> result = new List<CauHoi>();
            int totalRows = 0;

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sqlFilter = "WHERE 1=1";
                    if (!string.IsNullOrEmpty(maGiaoVien))
                        sqlFilter += " AND p.maGiaoVien = @maGiaoVien";
                    if (!string.IsNullOrEmpty(maMonHoc) && maMonHoc != "0")
                        sqlFilter += " AND c.maMonHoc = @maMonHoc";
                    if (maChuong > 0)
                        sqlFilter += " AND c.maChuong = @maChuong";
                    if (doKho != "0")
                        sqlFilter += " AND c.doKho = @doKho";

                    // Đếm tổng số dòng với join phancong (sử dụng DISTINCT để tránh trùng lặp)
                    string sqlCount = $@"SELECT COUNT(DISTINCT c.maCauHoi) 
                                        FROM cauhoi c 
                                        INNER JOIN phancong p ON c.maMonHoc = p.maMonHoc 
                                        {sqlFilter}";
                    using (MySqlCommand countCmd = new MySqlCommand(sqlCount, conn))
                    {
                        if (!string.IsNullOrEmpty(maGiaoVien))
                            countCmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);
                        if (!string.IsNullOrEmpty(maMonHoc) && maMonHoc != "0")
                            countCmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                        if (maChuong > 0)
                            countCmd.Parameters.AddWithValue("@maChuong", maChuong);
                        if (doKho != "0")
                            countCmd.Parameters.AddWithValue("@doKho", doKho);

                        totalRows = Convert.ToInt32(countCmd.ExecuteScalar());
                    }

                    int offset = Math.Max((currentPage - 1), 0) * pageSize;

                    // Lấy dữ liệu phân trang với join phancong (sử dụng DISTINCT để tránh trùng lặp)
                    string sqlData = $@"
                                    SELECT DISTINCT c.* 
                                    FROM cauhoi c 
                                    INNER JOIN phancong p ON c.maMonHoc = p.maMonHoc 
                                    {sqlFilter}
                                    ORDER BY c.maCauHoi
                                    LIMIT @PageSize OFFSET @Offset";

                    using (MySqlCommand dataCmd = new MySqlCommand(sqlData, conn))
                    {
                        if (!string.IsNullOrEmpty(maGiaoVien))
                            dataCmd.Parameters.AddWithValue("@maGiaoVien", maGiaoVien);
                        if (!string.IsNullOrEmpty(maMonHoc) && maMonHoc != "0")
                            dataCmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                        if (maChuong > 0)
                            dataCmd.Parameters.AddWithValue("@maChuong", maChuong);
                        if (doKho != "0")
                            dataCmd.Parameters.AddWithValue("@doKho", doKho);

                        dataCmd.Parameters.AddWithValue("@PageSize", pageSize);
                        dataCmd.Parameters.AddWithValue("@Offset", offset);

                        using (MySqlDataReader reader = dataCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new CauHoi
                                {
                                    maCauHoi = reader.GetInt32("maCauHoi"),
                                    maMonHoc = reader.GetString("maMonHoc"),
                                    maChuong = reader.GetInt32("maChuong"),
                                    doKho = reader.GetString("doKho"),
                                    noiDungCauHoi = reader.GetString("noiDungCauHoi")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách câu hỏi phân trang theo giáo viên: {ex}");
                
            }

            int totalPages = (int)Math.Ceiling((double)totalRows / pageSize);
            return (result, totalPages);
        }

        /*
         Phương thức lấy danh sách câu hỏi theo mã đề thi (có trộn ngẫu nhiên)
            Input: int MaDe
            Output: List<CauHoi> (đã được xáo trộn)
            Created by: Đỗ Mai Anh

            Các bảng có liên quan:
                + cauhoi_dekiemtra(maDe, maCauHoi)
                + cauhoi(maCauHoi, maMonHoc, maChuong, doKho, noiDungCauHoi)
        */

        public List<CauHoi> GetListCauHoiTheoMaDe(int maDe)
        {
            List<CauHoi> result = new List<CauHoi>();

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                SELECT c.maCauHoi, c.maMonHoc, c.maChuong, c.doKho, c.noiDungCauHoi
                FROM `cauhoi-dekiemtra` cd
                INNER JOIN cauhoi c ON cd.maCauHoi = c.maCauHoi
                WHERE cd.maDe = @MaDe";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDe", maDe);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new CauHoi
                                {
                                    maCauHoi = reader.GetInt32("maCauHoi"),
                                    maMonHoc = reader.GetString("maMonHoc"),
                                    maChuong = reader.GetInt32("maChuong"),
                                    doKho = reader.GetString("doKho"),
                                    noiDungCauHoi = reader.GetString("noiDungCauHoi")
                                });
                            }
                        }
                    }
                }

                // Xáo trộn ngẫu nhiên thứ tự câu hỏi 
                Random rnd = new Random();
                result = result.OrderBy(x => rnd.Next()).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách câu hỏi theo mã đề {maDe}: {ex.Message}");
            }

            return result;
        }

        /*
         Phương thức lấy danh sách câu hỏi theo mã đề thi (KHÔNG trộn, giữ nguyên thứ tự)
            Input: int MaDe
            Output: List<CauHoi> (sắp xếp theo maCauHoi)
            Created by: Hoàng Quyên
        */
        public List<CauHoi> GetListCauHoiTheoMaDeKhongTron(int maDe)
        {
            List<CauHoi> result = new List<CauHoi>();

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                SELECT c.maCauHoi, c.maMonHoc, c.maChuong, c.doKho, c.noiDungCauHoi
                FROM `cauhoi-dekiemtra` cd
                INNER JOIN cauhoi c ON cd.maCauHoi = c.maCauHoi
                WHERE cd.maDe = @MaDe
                ORDER BY c.maCauHoi";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDe", maDe);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new CauHoi
                                {
                                    maCauHoi = reader.GetInt32("maCauHoi"),
                                    maMonHoc = reader.GetString("maMonHoc"),
                                    maChuong = reader.GetInt32("maChuong"),
                                    doKho = reader.GetString("doKho"),
                                    noiDungCauHoi = reader.GetString("noiDungCauHoi")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách câu hỏi theo mã đề {maDe} (không trộn): {ex.Message}");
            }

            return result;
        }

        /*
         Phương thức đếm số câu hỏi theo danh sách chương và độ khó
            Input: List<int> danhSachMaChuong, string doKho
            Output: int (số lượng câu hỏi)
            Created by: Hoàng Quyên
        */
        public int DemSoCauHoiTheoChuongVaDoKho(List<int> danhSachMaChuong, string doKho)
        {
            int count = 0;
            try
            {
                if (danhSachMaChuong == null || danhSachMaChuong.Count == 0)
                {
                    return 0;
                }

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Tạo parameterized query an toàn
                    var parameters = new List<string>();
                    for (int i = 0; i < danhSachMaChuong.Count; i++)
                    {
                        parameters.Add($"@maChuong{i}");
                    }
                    
                    string chuongList = string.Join(",", parameters);
                    string sql = $@"
                        SELECT COUNT(*) 
                        FROM cauhoi 
                        WHERE maChuong IN ({chuongList}) 
                        AND doKho = @doKho";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Thêm parameters cho danh sách chương
                        for (int i = 0; i < danhSachMaChuong.Count; i++)
                        {
                            cmd.Parameters.AddWithValue($"@maChuong{i}", danhSachMaChuong[i]);
                        }
                        
                        cmd.Parameters.AddWithValue("@doKho", doKho);
                        
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            count = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đếm số câu hỏi theo chương và độ khó: {ex.Message}");
            }

            return count;
        }

        /*
         Phương thức lấy danh sách câu hỏi theo danh sách chương và độ khó
            Input: List<int> danhSachMaChuong, string doKho
            Output: List<CauHoi> (danh sách câu hỏi)
            Created by: Auto
        */
        public List<CauHoi> GetCauHoiTheoChuongVaDoKho(List<int> danhSachMaChuong, string doKho)
        {
            List<CauHoi> result = new List<CauHoi>();
            try
            {
                if (danhSachMaChuong == null || danhSachMaChuong.Count == 0)
                {
                    return result;
                }

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Tạo parameterized query an toàn
                    var parameters = new List<string>();
                    for (int i = 0; i < danhSachMaChuong.Count; i++)
                    {
                        parameters.Add($"@maChuong{i}");
                    }
                    
                    string chuongList = string.Join(",", parameters);
                    string sql = $@"
                        SELECT maCauHoi, maMonHoc, maChuong, doKho, noiDungCauHoi
                        FROM cauhoi 
                        WHERE maChuong IN ({chuongList}) 
                        AND doKho = @doKho";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Thêm parameters cho danh sách chương
                        for (int i = 0; i < danhSachMaChuong.Count; i++)
                        {
                            cmd.Parameters.AddWithValue($"@maChuong{i}", danhSachMaChuong[i]);
                        }
                        
                        cmd.Parameters.AddWithValue("@doKho", doKho);
                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new CauHoi
                                {
                                    maCauHoi = reader.GetInt32("maCauHoi"),
                                    maMonHoc = reader.GetString("maMonHoc"),
                                    maChuong = reader.GetInt32("maChuong"),
                                    doKho = reader.GetString("doKho"),
                                    noiDungCauHoi = reader.GetString("noiDungCauHoi")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy câu hỏi theo chương và độ khó: {ex.Message}");
            }

            return result;
        }

    }

}
