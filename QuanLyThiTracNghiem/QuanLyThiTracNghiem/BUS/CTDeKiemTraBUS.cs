using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * File: CTDeKiemTraBUS.cs
 * Mô tả: BUS cho bảng ctdekiemtra
 * Chức năng:
 *   - Lưu danh sách chương cho đề thi
 *   - Lấy danh sách mã chương của đề thi
 * Dùng trong: Dialog_TaoDeThi
 * Created by: Hoàng Quyên
 */
namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class CTDeKiemTraBUS
    {
        private CTDeKiemTraDAO ctDeKiemTraDAO = new CTDeKiemTraDAO();
        
        public CTDeKiemTraBUS() { }

        /// <summary>Lưu danh sách chương cho đề thi.</summary>
        /// <param name="maDe">Mã đề thi.</param>
        /// <param name="maMonHoc">Mã môn học.</param>
        /// <param name="danhSachMaChuong">Danh sách mã chương cần lưu.</param>
        /// <returns>True nếu lưu thành công, False nếu có lỗi.</returns>
        /// Created by: Hoàng Quyên
        public bool SaveChuongForDeThi(int maDe, string maMonHoc, List<int> danhSachMaChuong)
        {
            try
            {
                try
                {
                    ctDeKiemTraDAO.XoaCTDeKiemTra(maDe);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lưu ý khi xóa chương cũ: {ex.Message}");
                }

                foreach (int maChuong in danhSachMaChuong)
                {
                    if (!ctDeKiemTraDAO.ThemCTDeKiemTra(maDe, maMonHoc, maChuong))
                    {
                        Console.WriteLine($"Lỗi khi thêm chương {maChuong} cho đề thi {maDe}, môn học {maMonHoc}");
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu chương cho đề thi: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return false;
            }
        }

        /*
         * Phương thức lấy danh sách mã chương của đề thi
         * Input: int maDe - Mã đề thi cần lấy danh sách chương
         * Output: List<int> - Danh sách mã chương
         * Dùng trong: Dialog_TaoDeThi (để load lại chương đã chọn khi chỉnh sửa đề thi)
         * Created by: Hoàng Quyên
         */
        public List<int> GetListMaChuongByMaDe(int maDe)
        {
            try
            {
                ArrayList arrayList = ctDeKiemTraDAO.GetListCTDeKiemTraByMaDe(maDe);
                List<int> result = new List<int>();

                if (arrayList != null)
                {
                    foreach (CTDeKiemTra item in arrayList)
                    {
                        result.Add(item.maChuong);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách chương của đề thi: {ex.Message}");
                return new List<int>();
            }
        }
    }
}

