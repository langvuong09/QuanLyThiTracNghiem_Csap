using MySql.Data.MySqlClient;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    internal class DeKiemTraDAO
    {
        private MyConnect db = new MyConnect();
        public ArrayList GetListDeKiemTra()
        {
            ArrayList dsdkt = new ArrayList();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM dekiemtra WHERE trangThai = 1 ORDER BY maDe DESC";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DeKiemTra dkt = new DeKiemTra
                        {
                            maDe = reader.GetInt32(0),
                            tenDe = reader.GetString(1),
                            thoiGianBatDau = reader.GetDateTime(2),
                            thoiGianKetThuc = reader.GetDateTime(3),
                            thoiGianCanhBao = reader.GetDateTime(4),
                            maMonHoc = reader.GetString(5),
                            soCauDe = reader.GetInt32(6),
                            soCauTrungBinh = reader.GetInt32(7),
                            soCauKho = reader.GetInt32(8),
                            trangThai = reader.GetInt32(9),
                        };
                        dsdkt.Add(dkt);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dsdkt;
        }

        public bool ThemDeKiemTra(int maDe, string tenDe, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, DateTime thoiGianCanhBao, string maMonHoc, int soCauDe, int soCauTrungBinh, int soCauKho)
        {
            try
            {
                string sql = "INSERT INTO dekiemtra(maDe, tenDe, thoiGianBatDau, thoiGianKetThuc, thoiGianCanhBao, maMonHoc, soCauDe, soCauTrungBinh, soCauKho, trangThai)" +
                    "VALUES (@maDe, @tenDe, @thoiGianBatDau, @thoiGianKetThuc, @thoiGianCanhBao, @maMonHoc, @soCauDe, @soCauTrungBinh, @soCauKho, 1)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    cmd.Parameters.AddWithValue("@tenDe", tenDe);
                    cmd.Parameters.AddWithValue("@thoiGianBatDau", thoiGianBatDau);
                    cmd.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
                    cmd.Parameters.AddWithValue("@thoiGianCanhBao", thoiGianCanhBao);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@soCauDe", soCauDe);
                    cmd.Parameters.AddWithValue("@soCauTrungBinh", soCauTrungBinh);
                    cmd.Parameters.AddWithValue("@soCauKho", soCauKho);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        // Lấy mã đề lớn nhất trong database
        public int GetMaxMaDe()
        {
            try
            {
                string sql = "SELECT COALESCE(MAX(maDe), 0) FROM dekiemtra";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool XoaDeKiemTra(int maDe)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    
                    // Sử dụng transaction để đảm bảo tính toàn vẹn dữ liệu
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Xóa các bảng liên quan trước (mặc dù có CASCADE nhưng để chắc chắn)
                            // Xóa trong bảng dekiemtra-nhom
                            string sqlDeleteDeKiemTraNhom = "DELETE FROM `dekiemtra-nhom` WHERE maDe = @maDe";
                            MySqlCommand cmdDeleteNhom = new MySqlCommand(sqlDeleteDeKiemTraNhom, conn, transaction);
                            cmdDeleteNhom.Parameters.AddWithValue("@maDe", maDe);
                            cmdDeleteNhom.ExecuteNonQuery();
                            
                            // Xóa trong bảng cauhoi-dekiemtra
                            string sqlDeleteCauHoiDeKiemTra = "DELETE FROM `cauhoi-dekiemtra` WHERE maDe = @maDe";
                            MySqlCommand cmdDeleteCauHoi = new MySqlCommand(sqlDeleteCauHoiDeKiemTra, conn, transaction);
                            cmdDeleteCauHoi.Parameters.AddWithValue("@maDe", maDe);
                            cmdDeleteCauHoi.ExecuteNonQuery();
                            
                            // Xóa đề thi (các bảng liên quan khác như bailam sẽ tự động xóa do CASCADE)
                            string sql = "DELETE FROM dekiemtra WHERE maDe = @maDe";
                            MySqlCommand cmd = new MySqlCommand(sql, conn, transaction);
                            cmd.Parameters.AddWithValue("@maDe", maDe);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            
                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SuaDeKiemTra(int maDe, string tenDe, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, DateTime thoiGianCanhBao, string maMonHoc, int soCauDe, int soCauTrungBinh, int soCauKho)
        {
            try
            {
                string sql = "UPDATE dekiemtra SET tenDe = @tenDe, thoiGianBatDau = @thoiGianBatDau, thoiGianKetThuc = @thoiGianKetThuc, thoiGianCanhBao = @thoiGianCanhBao, maMonHoc = @maMonHoc, soCauDe = @soCauDe, soCauTrungBinh = @soCauTrungBinh, soCauKho = @soCauKho" +
                    " WHERE maDe = @maDe";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);                  
                    cmd.Parameters.AddWithValue("@tenDe", tenDe);
                    cmd.Parameters.AddWithValue("@thoiGianBatDau", thoiGianBatDau);
                    cmd.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
                    cmd.Parameters.AddWithValue("@thoiGianCanhBao", thoiGianCanhBao);
                    cmd.Parameters.AddWithValue("@maMonHoc", maMonHoc);
                    cmd.Parameters.AddWithValue("@soCauDe", soCauDe);
                    cmd.Parameters.AddWithValue("@soCauTrungBinh", soCauTrungBinh);
                    cmd.Parameters.AddWithValue("@soCauKho", soCauKho);
                    cmd.Parameters.AddWithValue("@maDe", maDe);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public DeKiemTra getDeKiemTraByID(int maDe)
        {
            try
            {
                string sql = "SELECT * FROM dekiemtra WHERE maDe = @maDe";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DeKiemTra dkt = new DeKiemTra
                        {
                            maDe = reader.GetInt32(0),
                            tenDe = reader.GetString(1),
                            thoiGianBatDau = reader.GetDateTime(2),
                            thoiGianKetThuc = reader.GetDateTime(3),
                            thoiGianCanhBao = reader.GetDateTime(4),
                            maMonHoc = reader.GetString(5),
                            soCauDe = reader.GetInt32(6),
                            soCauTrungBinh = reader.GetInt32(7),
                            soCauKho = reader.GetInt32(8),
                            trangThai = reader.GetInt32(9),
                        };
                        return dkt;
                    }
                    else return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /*
         Phương thức lấy danh sách Đề Kiểm Tra - Nhóm
             Input: maSinhVien (string), currentPage, pageSize, maNhom (int) => có thể có hoặc không, maMonHoc (string) => có thể có hoặc không, 
             Output: List (DeKiemTra,MaNhom, TenNhom, TenMonHoc) (Danh sách đề kiểm tra)
             Created by: Đỗ Mai Anh
             Dùng trong trang : Component_DeThi
             => Phương thức liên quan đến các bảng sau:

                        + nhomthamgia <lấy danh sách nhóm học phần mà sinh viên đã tham gia>
                        + dekiemtra-nhom <lấy danh sách đề kiểm tra theo các nhóm đó>
                        + dekiemtra <lấy thông tin đề kiểm tra>
                        + monhoc <lấy tên môn học theo mã môn học trong bảng dekiemtra>
                        + nhomh <lấy tên nhóm học phần theo mã nhóm học phần trong bảng dekiemtra-nhom>

        bảng nhomthamgia có (maNhom, maSinhVien)
        bảng dekiemtra-nhom có (maDe, maNhom)
        bảng dekiemtra có (maDe, soCauDe, soCauKho, soCauTrungBinh, tenDe, thoiGianBatDau, thoiGianKetThuc)
        bảng monhoc có (maMonHoc, tenMonHoc)
        bảng nhom có (maNhom, tenNhom)
          */

        public (List<DeKTra_Mon_Nhom> Data, int TotalRows) GetDeKTra_Mon_Nhom(
        string maSinhVien, int currentPage, int pageSize, int? maNhom = null)
        {
            List<DeKTra_Mon_Nhom> list = new List<DeKTra_Mon_Nhom>();
            int totalRows = 0;
            int offset = (currentPage - 1) * pageSize;

            try
            {
                // --- Tạo base SQL ---
                string baseSelect = @"
            FROM nhomthamgia ntg
            JOIN `dekiemtra-nhom` dkn ON ntg.maNhom = dkn.maNhom
            JOIN dekiemtra dk ON dk.maDe = dkn.maDe
            JOIN nhom n ON n.maNhom = dkn.maNhom
            JOIN monhoc mh ON mh.maMonHoc = n.maMonHoc
            WHERE ntg.maSinhVien = @maSinhVien
        ";

                // Nếu có maNhom thì thêm điều kiện
                if (maNhom.HasValue)
                    baseSelect += " AND ntg.maNhom = @maNhom ";

                // --- Tạo câu SQL chính ---
                string sql = $@"
            SELECT 
                dk.maDe, dk.tenDe, 
                mh.maMonHoc, mh.tenMonHoc,
                n.maNhom, n.tenNhom,
                dk.soCauDe, dk.soCauKho, dk.soCauTrungBinh,
                dk.thoiGianBatDau, dk.thoiGianKetThuc, 
                dk.thoiGianCanhBao, dk.trangThai
            {baseSelect}
            ORDER BY dk.thoiGianBatDau DESC
            LIMIT @pageSize OFFSET @offset;
        ";

                // --- Câu SQL đếm số dòng ---
                string sqlCount = $"SELECT COUNT(*) {baseSelect};";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // --- Lấy tổng số dòng ---
                    using (MySqlCommand cmdCount = new MySqlCommand(sqlCount, conn))
                    {
                        cmdCount.Parameters.AddWithValue("@maSinhVien", maSinhVien.Trim());
                        if (maNhom.HasValue)
                            cmdCount.Parameters.AddWithValue("@maNhom", maNhom.Value);

                        object? result = cmdCount.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            totalRows = Convert.ToInt32(result);
                    }

                    // --- Lấy dữ liệu chính ---
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien.Trim());
                        if (maNhom.HasValue)
                            cmd.Parameters.AddWithValue("@maNhom", maNhom.Value);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);
                        cmd.Parameters.AddWithValue("@offset", offset);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DeKTra_Mon_Nhom item = new DeKTra_Mon_Nhom
                                {
                                    DeKiemTra = new DeKiemTra
                                    {
                                        maDe = reader.GetInt32("maDe"),
                                        tenDe = reader.GetString("tenDe"),
                                        soCauDe = reader.GetInt32("soCauDe"),
                                        soCauKho = reader.GetInt32("soCauKho"),
                                        soCauTrungBinh = reader.GetInt32("soCauTrungBinh"),
                                        thoiGianBatDau = reader.GetDateTime("thoiGianBatDau"),
                                        thoiGianKetThuc = reader.GetDateTime("thoiGianKetThuc"),
                                        thoiGianCanhBao = reader.GetDateTime("thoiGianCanhBao"),
                                        trangThai = reader.GetInt32("trangThai")
                                    },
                                    MaNhom = reader.GetInt32("maNhom"),
                                    TenNhom = reader.GetString("tenNhom"),
                                    MaMonHoc = reader.GetString("maMonHoc"),
                                    TenMonHoc = reader.GetString("tenMonHoc")
                                };
                                list.Add(item);
                            }
                        }
                    }

                    Console.WriteLine($"[DAO INFO]  Lấy danh sách đề kiểm tra - nhóm thành công. Tổng số dòng: {totalRows}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DAO ERROR]  Lỗi khi lấy danh sách đề kiểm tra - nhóm: {ex.Message}");
            }

            return (list, totalRows);
        }

        /*
         Phương thức tìm kiếm theo mã đề kiểm tra hoặc tên bài kiểm tra
            Input: maSinhVien (string), String noiDungTimKiem> => Chỉ có thể là mã <nếu là int> hoặc tên <nếu String> thôi không tìm kiếm cả hai 
                 Output: List (DeKiemTra,MaNhom, TenNhom, TenMonHoc) (Danh sách đề kiểm tra)
                 Created by: Đỗ Mai Anh
                 Dùng trong trang : Component_DeThi
                 => Phương thức liên quan đến các bảng sau:

                            + nhomthamgia <lấy danh sách nhóm học phần mà sinh viên đã tham gia>
                            + dekiemtra-nhom <lấy danh sách đề kiểm tra theo các nhóm đó>
                            + dekiemtra <lấy thông tin đề kiểm tra>
                            + monhoc <lấy tên môn học theo mã môn học trong bảng dekiemtra>
                            + nhomh <lấy tên nhóm học phần theo mã nhóm học phần trong bảng dekiemtra-nhom>

            bảng nhomthamgia có (maNhom, maSinhVien)
            bảng dekiemtra-nhom có (maDe, maNhom)
            bảng dekiemtra có (maDe, soCauDe, soCauKho, soCauTrungBinh, tenDe, thoiGianBatDau, thoiGianKetThuc)
            bảng monhoc có (maMonHoc, tenMonHoc)
            bảng nhom có (maNhom, tenNhom)
         */

        public List<DeKTra_Mon_Nhom> SearchDeKTra_Mon_Nhom(string maSinhVien, string noiDungTimKiem)
        {
            List<DeKTra_Mon_Nhom> list = new List<DeKTra_Mon_Nhom>();

            try
            {
                string sql = @"
            SELECT 
                dk.maDe, dk.tenDe, 
                mh.maMonHoc, mh.tenMonHoc,
                n.maNhom, n.tenNhom,
                dk.soCauDe, dk.soCauKho, dk.soCauTrungBinh,
                dk.thoiGianBatDau, dk.thoiGianKetThuc, 
                dk.thoiGianCanhBao, dk.trangThai
            FROM nhomthamgia ntg
            JOIN `dekiemtra-nhom` dkn ON ntg.maNhom = dkn.maNhom
            JOIN dekiemtra dk ON dk.maDe = dkn.maDe
            JOIN nhom n ON n.maNhom = dkn.maNhom
            JOIN monhoc mh ON mh.maMonHoc = n.maMonHoc
            WHERE ntg.maSinhVien = @maSinhVien
        ";

                if (!string.IsNullOrWhiteSpace(noiDungTimKiem))
                {
                    int maDeSearch;
                    if (int.TryParse(noiDungTimKiem, out maDeSearch))
                    {
                        sql += " AND dk.maDe = @maDe ";
                    }
                    else
                    {
                        // LOWER() để so sánh không phân biệt hoa thường
                        sql += " AND LOWER(dk.tenDe) LIKE LOWER(@tenDe) ";
                    }
                }

                sql += " ORDER BY dk.thoiGianBatDau DESC;";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSinhVien", maSinhVien.Trim());

                        if (!string.IsNullOrWhiteSpace(noiDungTimKiem))
                        {
                            int maDeSearch;
                            if (int.TryParse(noiDungTimKiem, out maDeSearch))
                            {
                                cmd.Parameters.AddWithValue("@maDe", maDeSearch);
                            }
                            else
                            {
                                // Dùng % để tìm kiếm chuỗi con
                                cmd.Parameters.AddWithValue("@tenDe", "%" + noiDungTimKiem.Trim().ToLower() + "%");
                            }
                        }

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DeKTra_Mon_Nhom item = new DeKTra_Mon_Nhom
                                {
                                    DeKiemTra = new DeKiemTra
                                    {
                                        maDe = reader.GetInt32("maDe"),
                                        tenDe = reader.GetString("tenDe"),
                                        soCauDe = reader.GetInt32("soCauDe"),
                                        soCauKho = reader.GetInt32("soCauKho"),
                                        soCauTrungBinh = reader.GetInt32("soCauTrungBinh"),
                                        thoiGianBatDau = reader.GetDateTime("thoiGianBatDau"),
                                        thoiGianKetThuc = reader.GetDateTime("thoiGianKetThuc"),
                                        thoiGianCanhBao = reader.GetDateTime("thoiGianCanhBao"),
                                        trangThai = reader.GetInt32("trangThai")
                                    },
                                    MaNhom = reader.GetInt32("maNhom"),
                                    TenNhom = reader.GetString("tenNhom"),
                                    MaMonHoc = reader.GetString("maMonHoc"),
                                    TenMonHoc = reader.GetString("tenMonHoc")
                                };
                                list.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DAO ERROR] Lỗi khi tìm kiếm danh sách đề kiểm tra - nhóm: {ex.Message}");
            }

            return list;
        }
    }
}
