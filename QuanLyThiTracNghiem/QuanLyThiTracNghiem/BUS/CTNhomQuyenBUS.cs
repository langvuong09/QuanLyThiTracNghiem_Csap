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
        private ChucNangDAO ChucNangDAO = new ChucNangDAO();
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
        
        public List<CTNhomQuyen> FindByMaQuyen(int maQuyen)
        {
            var list = ctnqDAO.FindByMaQuyen(maQuyen);
            var result = new List<CTNhomQuyen>();

            foreach (var item in list)
            {
                ChucNang chucnang = ChucNangDAO.GetChucNang(item.maChucNang);
                result.Add(new CTNhomQuyen(item.maQuyen, item.maChucNang, chucnang.tenChucNang, item.xem, item.them, item.capNhat, item.xoa));
            }
            return result;
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
        public bool XoaCTNhomQuyen(int maQuyen)
        {
            bool result = ctnqDAO.XoaCTNhomQuyen(maQuyen);
            if (result)
            {
                DocListCTNhomQuyen();
            }
            return result;
        }
    }
}
