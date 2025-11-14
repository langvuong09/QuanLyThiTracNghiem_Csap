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
    internal class GiaoVienBUS
    {
        private GiaoVienDAO gvDAO = new GiaoVienDAO();
        private ArrayList listGiaoVien;
        public GiaoVienBUS()
        {
            DocListGiaoVien();
        }
        public void DocListGiaoVien()
        {
            this.listGiaoVien = gvDAO.GetListGiaoVien();
        }

        public ArrayList GetListGiaoVien()
        {
            if (this.listGiaoVien == null)
            {
                DocListGiaoVien();
            }
            return listGiaoVien;
        }

        public GiaoVien GetGiaoVienByID(string maGiaoVien)
        {
            return gvDAO.getGiaoVienByID(maGiaoVien);
        }

        public List<GiaoVien> GetAllGiaoVien()
        {
            ArrayList arr = gvDAO.GetListGiaoVien();
            List<GiaoVien> list = arr.OfType<GiaoVien>().ToList();

            return list;
        }

        internal GiaoVien getGiaoVienByID(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
