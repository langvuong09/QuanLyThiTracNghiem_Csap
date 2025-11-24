using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class PhanCongBUS
    {
        private PhanCongDAO pcDAO = new PhanCongDAO();
        private ArrayList listPhanCong;


        public PhanCongBUS()
        {
            DocListPhanCong();
        }

        public void DocListPhanCong()
        {
            this.listPhanCong = pcDAO.GetListPhanCong();
        }

        public ArrayList GetListPhanCong()
        {
            return pcDAO.GetListPhanCong();
        }

        public bool ThemPhanCong(int maPhanCong, string maMonHoc, string maGiaoVien)
        {
            if (string.IsNullOrEmpty(maMonHoc) || string.IsNullOrEmpty(maGiaoVien))
                return false;

            return pcDAO.ThemPhanCong(maPhanCong, maMonHoc, maGiaoVien);
        }

        public bool XoaPhanCong(int maPhanCong)
        {
            if (maPhanCong <= 0)
                return false;

            return pcDAO.XoaPhanCong(maPhanCong);
        }

        public ArrayList GetListPhanCongOfGiaoVien(string maGiaoVien)
        {
            if (string.IsNullOrEmpty(maGiaoVien))
                return null;

            return pcDAO.GetListPhanCongOfGiaoVien(maGiaoVien);
        }

        public List<PhanCong> GetAllPhanCong()
        {
            ArrayList arr = pcDAO.GetListPhanCong();
            List<PhanCong> list = arr.OfType<PhanCong>().ToList();

            return list;
        }
    }
}
