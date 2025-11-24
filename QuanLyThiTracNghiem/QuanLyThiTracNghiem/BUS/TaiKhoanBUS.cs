using Microsoft.VisualBasic.ApplicationServices;
using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

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
            if (username == null || password == null)
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

        public List<TaiKhoan> GetAllTaiKhoan()
        {
            ArrayList arr = tkDAO.GetListTaiKhoan();
            if (arr == null) return new List<TaiKhoan>();
            return arr.OfType<TaiKhoan>().ToList();
        }

        public bool SuaMKTaiKhoan(string ma, string newPassword)
        {
            return tkDAO.SuaMKTaiKhoan(ma, newPassword);
        }

        public bool khoaTaiKhoan(string ma)
        {
            return tkDAO.khoaTaiKhoan(ma);
        }

        public bool moTaiKhoan(string ma)
        {
            return tkDAO.moTaiKhoan(ma);
        }

        public TaiKhoan GetTaiKhoanById(string userId)
        {
            return tkDAO.GetTaiKhoanById(userId);
        }


    }
}
