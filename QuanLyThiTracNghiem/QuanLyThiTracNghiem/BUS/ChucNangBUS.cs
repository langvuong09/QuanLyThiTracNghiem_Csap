using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class ChucNangBUS
    {
        private ChucNangDAO chucNangDAO = new ChucNangDAO();
        private ArrayList list;

        public ChucNangBUS()
        {
            DocListNhomQuyen();
        }

        public void DocListNhomQuyen()
        {
            this.list = chucNangDAO.GetListChucNang();
        }

        public ArrayList GetListChucNang()
        {
            if (this.list == null)
            {
                DocListNhomQuyen();
            }
            return list;
        }
    }
}
