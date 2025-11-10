using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class GiaoVienBUS
    {
        private GiaoVienDAO gvDAO = new GiaoVienDAO();
        public GiaoVienBUS()
        {
        }
        public GiaoVien getGiaoVienByID(string maGiaoVien)
        {
           
            return gvDAO.getGiaoVienByID(maGiaoVien);
        }
    }
}
