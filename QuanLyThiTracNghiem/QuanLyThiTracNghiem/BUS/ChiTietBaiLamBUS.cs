using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class ChiTietBaiLamBUS
    {
        private ChiTietBaiLamDAO chiTietBaiLamDAO = new ChiTietBaiLamDAO();

        public ChiTietBaiLamBUS()
        {
        }

        // LẤY CHI TIẾT BÀI LÀM THEO MÃ BÀI LÀM
        public List<ChiTietBaiLam> GetChiTietBaiLamByMaBaiLam(int maBaiLam)
        {
            try
            {
                return chiTietBaiLamDAO.GetChiTietBaiLamByMaBaiLam(maBaiLam);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ChiTietBaiLamBUS => Lỗi khi lấy chi tiết bài làm: " + ex.Message);
                return new List<ChiTietBaiLam>();
            }
        }
    }
}
