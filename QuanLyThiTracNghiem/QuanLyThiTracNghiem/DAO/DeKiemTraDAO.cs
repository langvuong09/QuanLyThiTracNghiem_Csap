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
                    string sql = "SELECT * FROM dekiemtra";
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
                            soCauDe = reader.GetInt32(5),
                            soCauTrungBinh = reader.GetInt32(6),
                            soCauKho =reader.GetInt32(7),
                            trangThai =reader.GetInt32(8),
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

        public bool ThemDeKiemTra(int maDe, string tenDe, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, DateTime thoiGianCanhBao, int soCauDe, int soCauTrungBinh, int soCauKho)
        {
            try
            {
                string sql = "INSERT INTO dekiemtra(maDe, tenDe, thoiGianBatDau, thoiGianKetThuc, thoiGianCanhBao, soCauDe, soCauTrungBinh, soCauKho, trangThai)" +
                    "VaLUES (@maDe, @tenDe, @thoiGianBatDau, @thoiGianKetThuc, @thoiGianCanhBao, @soCauDe, @soCauTrungBinh, @soCauKho, 1)";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maDe", maDe);
                    cmd.Parameters.AddWithValue("@tenDe", tenDe);
                    cmd.Parameters.AddWithValue("@thoiGianBatDau", thoiGianBatDau);
                    cmd.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
                    cmd.Parameters.AddWithValue("@thoiGianCanhBao", thoiGianCanhBao);
                    cmd.Parameters.AddWithValue("@soCauDe", soCauDe);
                    cmd.Parameters.AddWithValue("@soCauTrungBinh", soCauTrungBinh);
                    cmd.Parameters.AddWithValue("@soCauKho", soCauKho);

                    int rs = cmd.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception ex) { return false; }
        }

        public bool XoaDeKiemTra(int maDe)
        {
            try
            {
                string sql = "UPDATE dekiemtra SET trangThai = 0 WHERE maDe = @maDe";

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

        public bool SuaDeKiemTra(int maDe, string tenDe, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, DateTime thoiGianCanhBao, int soCauDe, int soCauTrungBinh, int soCauKho)
        {
            try
            {
                string sql = "UPDATE dekiemtra SET tenDe = @tenDe, thoiGianBatDau = @thoiGianBatDau, thoiGianKetThuc = @thoiGianKetThuc, thoiGianCanhBao = @thoiGianCanhBao, soCauDe = @soCauDe, soCauTrungBinh = @soCauTrngBinh, @soCauKho" +
                    " WHERE maDe = @maDe";
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);                  
                    cmd.Parameters.AddWithValue("@tenDe", tenDe);
                    cmd.Parameters.AddWithValue("@thoiGianBatDau", thoiGianBatDau);
                    cmd.Parameters.AddWithValue("@thoiGianKetThuc", thoiGianKetThuc);
                    cmd.Parameters.AddWithValue("@thoiGianCanhBao", thoiGianCanhBao);
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
                            soCauDe = reader.GetInt32(5),
                            soCauTrungBinh = reader.GetInt32(6),
                            soCauKho = reader.GetInt32(7),
                            trangThai = reader.GetInt32(8),
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



    }
}
