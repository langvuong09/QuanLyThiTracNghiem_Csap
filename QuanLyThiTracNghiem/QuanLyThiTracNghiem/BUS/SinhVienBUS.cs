using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class SinhVienBUS
    {
        private SinhVienDAO svDAO = new SinhVienDAO();
        private ArrayList listSinhVien;
        public SinhVienBUS()
        {
            DocListSinhVien();
        }

        public void DocListSinhVien()
        {
            this.listSinhVien = svDAO.GetListSinhVien();
        }

        public ArrayList GetListSinhVien()
        {
            if(this.listSinhVien == null)
            {
                DocListSinhVien();
            }
            return listSinhVien;
        }

        public bool ThemSinhVien(string maSinhVien, string hoVaTen, string email, string gioiTinh, DateTime ngaySinh, string anhDaiDien)
        {
            // ===== Kiểm tra mã sinh viên =====
            if (string.IsNullOrWhiteSpace(maSinhVien))
            {
                new MyDialog("Không được để trống mã sinh viên!", MyDialog.ERROR_DIALOG).ShowDialog();
                return false;
            }
            else if (!CheckUsername(maSinhVien))
            {
                new MyDialog("Mã sinh viên không hợp lệ!", MyDialog.ERROR_DIALOG).ShowDialog();
                return false;
            }

            // ===== Kiểm tra họ tên =====
            if (string.IsNullOrWhiteSpace(hoVaTen))
            {
                new MyDialog("Không được để trống họ và tên!", MyDialog.ERROR_DIALOG).ShowDialog();
                return false;
            }
            else if (!CheckTen(hoVaTen))
            {
                new MyDialog("Họ và tên không hợp lệ!", MyDialog.ERROR_DIALOG).ShowDialog();
                return false;
            }

            // ===== Kiểm tra email =====
            if (string.IsNullOrWhiteSpace(email))
            {
                new MyDialog("Không được để trống email!", MyDialog.ERROR_DIALOG).ShowDialog();
                return false;
            }
            else if (!CheckEmail(email))
            {
                new MyDialog("Email không hợp lệ!", MyDialog.ERROR_DIALOG).ShowDialog();
                return false;
            }
            // ===== Gọi DAO (CHUẨN theo DAO bạn đưa) =====
            if (svDAO.ThemSinhVien(maSinhVien, hoVaTen, email, gioiTinh, ngaySinh, anhDaiDien)) 
            { 
                return true; 
            } 
            else 
            { 
                return false; 
            }
        }


        private bool CheckUsername(string username)
        {
            string pattern = @"^\d{6,}$";
            return Regex.IsMatch(username, pattern);
        }
        private bool CheckPassword(string password)
        {
            string pattern = @"^\S{6,}$";
            return Regex.IsMatch(password, pattern);
        }     
        private bool CheckTen(string ten)
        {
            string pattern = @"^[\p{L}]+(?:\s[\p{L}]+)*$";
            return Regex.IsMatch(ten, pattern);
        }
        private bool CheckEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

  
        public SinhVien GetSinhVienByID(string maSinhVien)
        {
            return svDAO.getSinhVienByID(maSinhVien);
        }

        public bool SuaSinhVien(string maSinhVien, string hoVaTen, string email, string gioiTinh, DateTime ngaySinh, string anhDaiDien)
        {
            if (svDAO.SuaSinhVien(maSinhVien, hoVaTen, email, gioiTinh, ngaySinh, anhDaiDien))
            {
                MyDialog dlg = new MyDialog("Cập nhật thông tin thành công!", MyDialog.SUCCESS_DIALOG);
                dlg.ShowDialog();
                return true;
            }
            else
            {
                MyDialog dlg = new MyDialog("Cập nhật thông tin thất bại!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }


        public List<SinhVien> GetAllSinhVien()
        {
            ArrayList arr = svDAO.GetListSinhVien();
            List<SinhVien> list = arr.OfType<SinhVien>().ToList();

            return list;
        }

        

    }
}
