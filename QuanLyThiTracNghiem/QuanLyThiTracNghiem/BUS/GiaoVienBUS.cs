using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class GiaoVienBUS
    {
        private GiaoVienDAO gvDAO = new GiaoVienDAO();
        private List<GiaoVien> listGiaoVien;
        public GiaoVienBUS()
        {
            DocListGiaoVien();
        }
        public void DocListGiaoVien()
        {
            this.listGiaoVien = gvDAO.GetListGiaoVien();
        }

        public List<GiaoVien> GetListGiaoVien()
        {
            if (this.listGiaoVien == null)
            {
                DocListGiaoVien();
            }
            return listGiaoVien;
        }

        public GiaoVien GetGiaoVienByID(string id)
        {
            return gvDAO.GetGiaoVienByID(id);
        }

        public List<GiaoVien> GetAllGiaoVien()
        {
            return gvDAO.GetListGiaoVien();
        }


        public bool SuaGiaoVien(string maGiaoVien, string tenGiaoVien, string email, string gioiTinh, DateTime ngaySinh, string anhDaiDien)
        {
            GiaoVien gv = new GiaoVien
            {
                maGiaoVien = maGiaoVien,
                tenGiaoVien = tenGiaoVien,
                email = email,
                gioiTinh = gioiTinh,
                ngaySinh = ngaySinh,
                anhDaiDien = anhDaiDien
            };
            if (gvDAO.SuaGiaoVien(gv))
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
            GiaoVien gv = new GiaoVien
            {
                maGiaoVien = maGiaoVien,
                tenGiaoVien = tenGiaoVien,
                email = email,
                gioiTinh = gioiTinh,
                ngaySinh = ngaySinh,
                anhDaiDien = anhDaiDien,
                quyen = maQuyen
            };

            return gvDAO.ThemGiaoVien(gv);
        }

        public bool XoaGiaoVien(string ma)
        {
            if(ma == null)
            {
                new MyDialog("Chưa chọn giáo viên để xóa!", MyDialog.ERROR_DIALOG).ShowDialog();
                return false;
            }
            return gvDAO.XoaGiaoVien(ma);
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
