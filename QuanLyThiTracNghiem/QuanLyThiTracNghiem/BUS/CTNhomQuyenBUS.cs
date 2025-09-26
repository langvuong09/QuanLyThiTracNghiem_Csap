using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class CTNhomQuyenBUS
    {
        private CTNhomQuyenDAO ctnqDAO = new CTNhomQuyenDAO();
        private ArrayList listCTNhomQuyen;

        public CTNhomQuyenBUS()
        {
            DocListCTNhomQuyen();
        }

        public void DocListCTNhomQuyen()
        {
            this.listCTNhomQuyen = ctnqDAO.GetListCTNhomQuyen();
        }

        public void DocListCTNhomQuyen(int maQuyen)
        {
            this.listCTNhomQuyen = ctnqDAO.GetListCTNhomQuyen(maQuyen);
        }

        public ArrayList GetListCTNhomQuyen()
        {
            DocListCTNhomQuyen();
            return listCTNhomQuyen;
        }

        public ArrayList GetListCTNhomQuyen(int maQuyen)
        {
            DocListCTNhomQuyen(maQuyen);
            return listCTNhomQuyen;
        }
        
        public bool ThemCTNhomQuyen(int maQuyen, int maChucNang, int xem, int them, int capNhat, int xoa)
        {
            bool result = ctnqDAO.ThemCTNhomQuyen(maQuyen, maChucNang, xem, them, capNhat, xoa);
            if (result)
            {
                DocListCTNhomQuyen();
            }
            return result;
        }
    }
}
