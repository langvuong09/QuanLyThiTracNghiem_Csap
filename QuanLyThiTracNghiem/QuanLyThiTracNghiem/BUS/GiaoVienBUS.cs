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

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class GiaoVienBUS
    {
        private GiaoVienDAO gvDAO = new GiaoVienDAO();
        private ArrayList listGiaoVien;
        public GiaoVienBUS()
        {
            DocListGiaoVien();
        }
        public void DocListGiaoVien()
        {
            this.listGiaoVien = gvDAO.GetListGiaoVien();
        }

        public ArrayList GetListGiaoVien()
        {
            if (this.listGiaoVien == null)
            {
                DocListGiaoVien();
            }
            return listGiaoVien;
        }

        public GiaoVien GetGiaoVienByID(string maGiaoVien)
        {
            return gvDAO.getGiaoVienByID(maGiaoVien);
        }

        public List<GiaoVien> GetAllGiaoVien()
        {
            ArrayList arr = gvDAO.GetListGiaoVien();
            List<GiaoVien> list = arr.OfType<GiaoVien>().ToList();

            return list;
        }


        public bool SuaGiaoVien(string maGiaoVien, string tenGiaoVien, string email, string gioiTinh, DateTime ngaySinh, string anhDaiDien)
        {
            if (gvDAO.SuaGiaoVien(maGiaoVien, tenGiaoVien, email, gioiTinh, ngaySinh, anhDaiDien))
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

        public bool ThemGiaoVien(string maGiaoVien, string tenGiaoVien, string email, string gioiTinh, DateTime ngaySinh, string anhDaiDien, int maQuyen)
        {
            // ===== Kiểm tra mã sinh viên =====
            if (string.IsNullOrWhiteSpace(maGiaoVien))
            {
                new MyDialog("Không được để trống mã sinh viên!", MyDialog.ERROR_DIALOG).ShowDialog();
                return false;
            }
            

            // ===== Kiểm tra họ tên =====
            if (string.IsNullOrWhiteSpace(tenGiaoVien))
            {
                new MyDialog("Không được để trống họ và tên!", MyDialog.ERROR_DIALOG).ShowDialog();
                return false;
            }
            else if (!CheckTen(tenGiaoVien))
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
            if (gvDAO.ThemGiaoVien(maGiaoVien, tenGiaoVien, email, gioiTinh, ngaySinh, anhDaiDien, maQuyen))
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

        
    }
}
