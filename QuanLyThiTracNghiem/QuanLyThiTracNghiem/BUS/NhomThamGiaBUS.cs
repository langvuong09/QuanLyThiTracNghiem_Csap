using QuanLyThiTracNghiem.MyCustom;
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

        public bool ThemNhomThamGia(string maNhom, string maSV)
        {
            try
            {
                int maN = Convert.ToInt32(maNhom);
                if (nhomThamGiaDAO.ThemNhomTG(maN, maSV))
                {
                    return true;
                }else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                MyDialog dlg = new MyDialog("Error! "+ex, MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }

        public bool XoaNhomThamGiaOfSV(string maSV)
        {
            try
            {
                if(nhomThamGiaDAO.XoanhomTG(maSV))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                   return false;
            }
        }

        public int MaxSVMoiNhom(int maNhom)
        {
            return nhomThamGiaDAO.MaxNhomTG(maNhom);
        }
    }
}
