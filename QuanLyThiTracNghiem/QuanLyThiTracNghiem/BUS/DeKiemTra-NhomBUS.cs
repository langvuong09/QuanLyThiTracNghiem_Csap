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
    internal class DeKiemTra_NhomBUS
    {
        private DeKiemTra_NhomDAO deKiemTra_NhomDAO = new DeKiemTra_NhomDAO();
        
        public DeKiemTra_NhomBUS() { }

        /*
         * Phương thức lưu danh sách nhóm học phần cho đề thi
         * Input: int maDe - Mã đề thi, List<int> danhSachMaNhom - Danh sách mã nhóm cần lưu
         * Output: bool - true nếu lưu thành công, false nếu có lỗi
         * Dùng trong: Dialog_TaoDeThi (khi tạo mới hoặc cập nhật đề thi)
         * Created by: Hoàng Quyên
         */
        public bool SaveNhomForDeThi(int maDe, List<int> danhSachMaNhom)
        {
            try
            {
                // Xóa tất cả nhóm cũ của đề thi
                deKiemTra_NhomDAO.XoaDKT_NhomOfMaDe(maDe);

                // Thêm các nhóm mới
                foreach (int maNhom in danhSachMaNhom)
                {
                    if (!deKiemTra_NhomDAO.ThemDKT_Nhom(maDe, maNhom))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu nhóm cho đề thi: {ex.Message}");
                return false;
            }
        }

        /*
         * Phương thức lấy danh sách mã nhóm học phần của đề thi
         * Input: int maDe - Mã đề thi cần lấy danh sách nhóm
         * Output: List<int> - Danh sách mã nhóm học phần
         * Dùng trong: Dialog_TaoDeThi (để load lại nhóm đã chọn khi chỉnh sửa đề thi)
         * Created by: Hoàng Quyên
         */
        public List<int> GetListMaNhomByMaDe(int maDe)
        {
            try
            {
                ArrayList arrayList = deKiemTra_NhomDAO.GetListDKT_NhomByMaDe(maDe);
                List<int> result = new List<int>();

                if (arrayList != null)
                {
                    foreach (DeKiemTra_Nhom item in arrayList)
                    {
                        result.Add(item.maNhom);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách nhóm của đề thi: {ex.Message}");
                return new List<int>();
            }
        }
    }
}
