using System;
using System.Collections;

using Microsoft.VisualBasic.ApplicationServices;

using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

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
            return tkDAO.GetTaiKhoan(username, password);
        }
    }
}
