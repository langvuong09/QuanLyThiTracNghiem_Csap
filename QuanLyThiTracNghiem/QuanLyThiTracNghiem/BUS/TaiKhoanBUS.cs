using Microsoft.VisualBasic.ApplicationServices;
using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class TaiKhoanBUS
    {
        private TaiKhoanDAO tkDAO = new TaiKhoanDAO();
        private ArrayList listTK;
        public TaiKhoanBUS()
        {
            DocListTaiKhoan();
        }
        public void DocListTaiKhoan()
        {
            this.listTK = tkDAO.GetListTaiKhoan();
        }
        public TaiKhoan GetTaiKhoan(string username, string password)
        {
            if(username == null || password == null)
            {
                MyDialog dlg = new MyDialog("Không được để trống thông tin!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return null;
            }
            return tkDAO.GetTaiKhoan(username, password);
        }

        public bool ThemTaiKhoan(string ma, string matKhau)
        {
            if (tkDAO.ThemTaiKhoan(ma, matKhau))
            {
                MyDialog dlg = new MyDialog("Đăng ký thành công!", MyDialog.SUCCESS_DIALOG);
                dlg.ShowDialog();
                return true;
            }
            else
            {
                MyDialog dlg = new MyDialog("Đăng ký thất bại!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }

        public bool SuaMKTaiKhoan(string ma, string newPassword)
        {
            return tkDAO.SuaMKTaiKhoan(ma, newPassword);
        }
    }      
}
