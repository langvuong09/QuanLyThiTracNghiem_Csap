﻿using MySqlX.XDevAPI.Common;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class DeKiemTraBUS
    {
        private DeKiemTraDAO deKiemTraDAO = new DeKiemTraDAO();
        public DeKiemTraBUS() { }

        // ==========================================
        // TẠO ĐỀ THI MỚI
        // ==========================================
        public bool CreateDeThi(DeKiemTra deThi)
        {
            try
            {
                // Tạo mã đề thi tự động 
                int maDe = GetNextMaDe();
                
                return deKiemTraDAO.ThemDeKiemTra(
                    maDe,
                    deThi.tenDe,
                    deThi.thoiGianBatDau,
                    deThi.thoiGianKetThuc,
                    deThi.thoiGianCanhBao,
                    deThi.maMonHoc,
                    deThi.soCauDe,
                    deThi.soCauTrungBinh,
                    deThi.soCauKho
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo đề thi: {ex.Message}");
                return false;
            }
        }

        // ==========================================
        // CẬP NHẬT ĐỀ THI
        // ==========================================
        public bool UpdateDeThi(DeKiemTra deThi)
        {
            try
            {
                return deKiemTraDAO.SuaDeKiemTra(
                    deThi.maDe,
                    deThi.tenDe,
                    deThi.thoiGianBatDau,
                    deThi.thoiGianKetThuc,
                    deThi.thoiGianCanhBao,
                    deThi.maMonHoc,
                    deThi.soCauDe,
                    deThi.soCauTrungBinh,
                    deThi.soCauKho
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật đề thi: {ex.Message}");
                return false;
            }
        }

        // ==========================================
        // XÓA ĐỀ THI
        // ==========================================
        public bool DeleteDeThi(int maDe)
        {
            try
            {
                return deKiemTraDAO.XoaDeKiemTra(maDe);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa đề thi: {ex.Message}");
                return false;
            }
        }

        // ==========================================
        // LẤY DANH SÁCH TẤT CẢ ĐỀ THI
        // ==========================================
        public List<DeKiemTra> GetListDeKiemTra()
        {
            try
            {
                ArrayList arrayList = deKiemTraDAO.GetListDeKiemTra();
                List<DeKiemTra> result = new List<DeKiemTra>();
                
                if (arrayList != null)
                {
                    foreach (DeKiemTra item in arrayList)
                    {
                        result.Add(item);
                    }
                }
                
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách đề thi: {ex.Message}");
                return new List<DeKiemTra>();
            }
        }

        // ==========================================
        // LẤY MÃ ĐỀ THI TIẾP THEO
        // ==========================================
        private int GetNextMaDe()
        {
            return DateTime.Now.Millisecond + new Random().Next(1000, 9999);
        }

        public void GetDeKTra_Mon_Nhom(FlowLayoutPanel flowLayoutPanel_Main,ComboBox comboBox_LocTheoNhom, Form panel_TrangChu,string maSinhVien, int currentPage, int pageSize)
        {
            int? maNhom = null; 

            if (comboBox_LocTheoNhom.SelectedItem != null)
            {
                var selectedNhom = comboBox_LocTheoNhom.SelectedItem as Nhom;

                if (selectedNhom != null && selectedNhom.maNhom != 0)
                {
                    maNhom = selectedNhom.maNhom;
                }
           
            }

            var result = deKiemTraDAO.GetDeKTra_Mon_Nhom(maSinhVien, currentPage, pageSize, maNhom);
           
            List<DeKTra_Mon_Nhom> dsDeKiemTra= result.Data;

            foreach (var dekiemtra in dsDeKiemTra)
            {
                Panel_ItemDeThi item = new Panel_ItemDeThi(dekiemtra);

               
                item.XemChiTietClicked += (s, e2) =>
                {
                   
                    Form formThongTin = new Form();
                    formThongTin.Text = "THÔNG TIN BÀI THI";
                    formThongTin.FormBorderStyle = FormBorderStyle.FixedDialog;
                    formThongTin.StartPosition = FormStartPosition.CenterParent;
                    formThongTin.ClientSize = new Size(824, 589);
                    formThongTin.AutoScroll = true;
                    formThongTin.ShowInTaskbar = false;

                
                    Dialog_BatDauLamBaiThi dialog = new Dialog_BatDauLamBaiThi();
                    dialog.Dock = DockStyle.Fill;

                    // Đăng ký event Làm Bài
                    dialog.LamBaiClicked += (ss, ee) =>
                    {
                        // Khi nhấn nút Làm Bài → mở FormLamBai
                        LamBaiThi fLamBai = new LamBaiThi();

                        fLamBai.TroVeClicked += (sss, eee) =>
                        {
                            // Khi nhấn Trở về → đóng form làm bài, hiện lại form thông tin
                            fLamBai.Close();
                            formThongTin.Show();
                        };

                        formThongTin.Hide(); 
                        fLamBai.ShowDialog(formThongTin);  // Mở form làm bài
                    };

                    formThongTin.Controls.Add(dialog);
                    formThongTin.ShowDialog(panel_TrangChu); // Mở modal trên FormTrangChu
                };

                flowLayoutPanel_Main.Controls.Add(item);
            }
        }

    }
}
