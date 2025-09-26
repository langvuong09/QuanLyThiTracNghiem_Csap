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
    internal class NhomQuyenBUS
    {
        private NhomQuyenDAO nqDAO = new NhomQuyenDAO();
        private ArrayList listNhomQuyen;

        public NhomQuyenBUS()
        {
            DocListNhomQuyen();
        }

        public void DocListNhomQuyen()
        {
            this.listNhomQuyen = nqDAO.GetListNhomQuyen();
        }

        public ArrayList GetListNhomQuyen()
        {
            if(this.listNhomQuyen == null)
            {
                DocListNhomQuyen();
            }
            return listNhomQuyen;
        }
        public NhomQuyen? ThemQuyen(string tenQuyen)
        {
            NhomQuyen? kq = nqDAO.ThemQuyen(tenQuyen);
            if (kq != null)
            {
                return kq;
            }
            else return null;
        }
    }
}
