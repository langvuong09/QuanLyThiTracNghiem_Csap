using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class BaiLamBUS
    {
        private SinhVien_DeKiemTraDAO baiLamDAO = new SinhVien_DeKiemTraDAO();
        public int TaoMaBaiLamMoi()
        {
            return baiLamDAO.GetMaxMaBaiLam() + 1;

        }
    }
}
