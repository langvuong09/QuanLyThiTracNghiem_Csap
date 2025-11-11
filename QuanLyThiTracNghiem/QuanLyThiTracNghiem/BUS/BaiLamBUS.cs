using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class BaiLamBUS
    {
        private SinhVien_DeKiemTraDAO baiLamDAO = new SinhVien_DeKiemTraDAO();
        private ChiTietBaiLamDAO chiTietBaiLamDAO = new ChiTietBaiLamDAO();
        public int TaoMaBaiLamMoi()
        {
            return baiLamDAO.GetMaxMaBaiLam() + 1;

        }
        /*
        Phương thức lưu bài làm của thí sinh vào Database 
         */
        public void LuuBaiLamMoi(BaiLam bailam, List<ChiTietBaiLam>dschitietbaialam) {
            if(baiLamDAO.ThemBaiLam(bailam.maBaiLam, bailam.maSinhVien, bailam.maDe, bailam.tongDiem))
            {
                if (chiTietBaiLamDAO.ThemDanhSachCTBaiLam(dschitietbaialam))
                {
                    MyDialog dialog = new MyDialog("Bạn đã nộp bài thành công.", MyDialog.SUCCESS_DIALOG);
                    dialog.ShowDialog();
                }
                else
                {
                    MyDialog dialog = new MyDialog("Đã có lỗi xảy ra. Vui lòng báo cáo với giảng viên hướng dẫn.", MyDialog.ERROR_DIALOG);
                    dialog.ShowDialog();
                    bool xoaChiTiet=chiTietBaiLamDAO.XoaCTBaiLam(bailam.maBaiLam);
                    bool xoaBaiLam= baiLamDAO.XoaBaiLam(bailam.maBaiLam);
                    if(xoaChiTiet && xoaBaiLam)
                    {
                        Console.WriteLine("Đã xóa hết bài làm bị thêm lỗi");
                    }
                }

            }
            else
            {
                MyDialog dialog = new MyDialog("Đã có lỗi xảy ra. Vui lòng báo cáo với giảng viên hướng dẫn.", MyDialog.ERROR_DIALOG);
                dialog.ShowDialog();
            }
        }

        // Lấy danh sách bài làm theo mã đề thi kèm thông tin sinh viên
        public List<Dictionary<string, object>> GetBaiLamByMaDeWithSinhVien(int maDe)
        {
            return baiLamDAO.GetBaiLamByMaDeWithSinhVien(maDe);
        }

        
    }
}
