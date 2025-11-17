using QuanLyThiTracNghiem.MyCustom;
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
    internal class ThongBao_NhomBUS
    {
        private ThongBao_NhomDAO thongBao_NhomDAO = new ThongBao_NhomDAO();
        private ArrayList listThongBao_Nhom;
        private ArrayList listThongBao_NhomTheoMaThongBao;
        private ArrayList listThongBao_NhomTheoMaNhom;
        public ThongBao_NhomBUS()
        {
            DocListThongBao_Nhom();
        }
        public void DocListThongBao_Nhom()
        {
            this.listThongBao_Nhom = thongBao_NhomDAO.GetListTB_Nhom();
        }

        public ArrayList GetListThongBao_Nhom()
        {
            if(listThongBao_Nhom == null)
            {
                DocListThongBao_Nhom();
            }
            return listThongBao_Nhom;
        }

        public void DocListThongBao_Nhom(int maThongBao)
        {
            this.listThongBao_NhomTheoMaThongBao = thongBao_NhomDAO.GetListTB_Nhom(maThongBao);
        }

        public ArrayList GetListThongBao_Nhom(int maThongBao)
        {
            if (listThongBao_NhomTheoMaThongBao == null)
            {
                DocListThongBao_Nhom(maThongBao);
            }
            return listThongBao_NhomTheoMaThongBao;
        }

        public void DocListThongBao_NhomTheoMaNhom(int maNhom)
        {
            this.listThongBao_NhomTheoMaNhom = thongBao_NhomDAO.GetListTB_NhomOfMaNhom(maNhom);
        }

        public ArrayList GetListThongBao_NhomTheoMaNhom(int maNhom)
        {
            if (listThongBao_NhomTheoMaNhom == null)
            {
                DocListThongBao_NhomTheoMaNhom(maNhom);
            }
            return listThongBao_NhomTheoMaNhom;
        }

        public bool ThemThongBao_Nhom(string maNhom,string maThongBao)
        {
            try
            {
                int maN = Convert.ToInt32(maNhom);
                int maTB = Convert.ToInt32(maThongBao);
                if (thongBao_NhomDAO.ThemThongBao(maN,maTB))
                {
                    return true;
                }
                else
                {
                    MyDialog dlg = new MyDialog("Lỗi!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool XoaThongBao_Nhom(string maThongBao)
        {
            try
            {
                int maTB = Convert.ToInt32(maThongBao);
                if (thongBao_NhomDAO.XoaThongBao(maTB))
                {
                    return true;
                }
                else
                {
                    MyDialog dlg = new MyDialog("Lỗi!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
            }
            catch( Exception ex )
            {
                return false;
            }
        }
    }
}
