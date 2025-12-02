using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class BaiLamBUS
    {
        private BaiLamDAO baiLamDAO = new BaiLamDAO();
        private DeKiemTra_NhomDAO deKiemTra_NhomDAO = new DeKiemTra_NhomDAO();
        private ChiTietBaiLamDAO chiTietBaiLamDAO = new ChiTietBaiLamDAO();
        private ArrayList listBaiLam;
        private ArrayList listBaiLamOfSV;
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

        public int CountBaiLamByMaSV(string maSV)
        {
            ArrayList dsbl = baiLamDAO.GetListBaiLamOfSV(maSV);
            return dsbl.Count;
        }

        public void DocListBaiLam()
        {
            listBaiLam = baiLamDAO.GetListBaiLam();
        }

        public ArrayList GetListBaiLam()
        {
            if(listBaiLam == null)
            {
                DocListBaiLam();
            }
            return listBaiLam;
        }

        public void DocListBaiLam(string maSinhVien)
        {
            listBaiLamOfSV = baiLamDAO.GetListBaiLamOfSV(maSinhVien);
        }

        public ArrayList GetListBaiLamOfSV(string maSinhVien, int maNhom)
        {
            DocListBaiLam();
            
            ArrayList dsbl = GetListBaiLam();
            ArrayList dsdkt_n = deKiemTra_NhomDAO.GetListDKT_Nhom();
            ArrayList ds = new ArrayList();
            foreach (BaiLam bl in dsbl)
            {
                foreach(DeKiemTra_Nhom dkt_n in dsdkt_n)
                {
                    if(dkt_n.maDe == bl.maDe && bl.maSinhVien == maSinhVien && dkt_n.maNhom == maNhom)
                    {
                        ds.Add(bl);
                    }
                }
            }
            return ds;
        }

        public ArrayList GetListBaiLamByDeKiemTra(string maDe)
        {
            DocListBaiLam();
            int maD = Convert.ToInt32(maDe);
            ArrayList dsbl = GetListBaiLam();
            ArrayList ds = new ArrayList();
            foreach (BaiLam bl in dsbl)
            {
                if(bl.maDe == maD)
                {
                    ds.Add(bl);
                }
            }
            return ds;
        }

        public int GetCountBaiLam(int maDe)
        {
            return baiLamDAO.GetCountBaiLam(maDe);
        }
    }
}
