using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class NhomThamGiaBUS
    {
        private NhomThamGiaDAO nhomThamGiaDAO = new NhomThamGiaDAO();
        private ArrayList listNhomThamGiaOfMaNhom;
        private ArrayList listNhomThamGiaOfmaSV;
        public NhomThamGiaBUS()
        {
        }

        public void DocListNhomThamGiaOfMaNhom(int maNhom)
        {
            this.listNhomThamGiaOfMaNhom = nhomThamGiaDAO.GetListNhomTG(maNhom);
        }
        public ArrayList GetListNhomThamGiaOfMaNhom(int maNhom)
        {
            if(listNhomThamGiaOfMaNhom == null)
            {
                DocListNhomThamGiaOfMaNhom(maNhom);
            }
            return listNhomThamGiaOfMaNhom;
        }

        public void DocListNhomThamGiaOfMaSV(string maSinhVien)
        {
            this.listNhomThamGiaOfmaSV = nhomThamGiaDAO.GetListNhomTGOfSV(maSinhVien);
        }
        public ArrayList GetListNhomThamGiaOfMaSV(string maSinhVien)
        {
            if (listNhomThamGiaOfmaSV == null)
            {
                DocListNhomThamGiaOfMaSV(maSinhVien);
            }
            return listNhomThamGiaOfmaSV;
        }
    }
}
