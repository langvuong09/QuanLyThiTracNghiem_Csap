using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class CauHoiBUS
    {
        private CauHoiDAO CauHoiDAO = new CauHoiDAO();
        public CauHoiBUS()
        {
        }

        /*
         Phương thưc Lấy Danh sách Câu hỏi để hiển thị lên DataGridView <Phân trang>
            Input: dataGridView ,curentPage, pageSize, maMonHoc, maChuong, doKho 
                   <3 cái đầu là bắt buộc phải có , 
                   3 biến sau có thể đề mặc định>
            Output: none
            Created by: Đỗ Mai Anh
            Dùng trong : Component_CauHoi
         
         */

        public int LayDSCauHoi_PhanTrang(
             DataGridView dataGridView,
             int currentPage,
             int pageSize,
             string maMonHoc = "0",
             int maChuong = 0,
             string doKho = "0")
        {
            try
            {
                var result = CauHoiDAO.GetListCauHoiPhanTrang(currentPage, pageSize, maMonHoc, maChuong, doKho);

                // Đảm bảo DataGridView có cột
                if (dataGridView.Columns.Count == 0)
                {
                    Console.WriteLine("⚠ DataGridView chưa có cột — kiểm tra lại quá trình khởi tạo.");
                    return 0;
                }

                // Xóa dữ liệu cũ
                dataGridView.Rows.Clear();

                // Thêm dữ liệu mới
                foreach (var item in result.Data)
                {
                    dataGridView.Rows.Add(
                        item.maCauHoi,
                        item.noiDungCauHoi,
                        item.maMonHoc,
                        item.maChuong,
                        item.doKho,
                        item.noiDungCauHoi
                    );
                }

                return result.TotalPages;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CauHoiBUS => Lỗi khi lấy danh sách câu hỏi: " + ex.Message);
                return 0;
            }
        }

        /*
             Phương thức tìm kiếm theo Mã Câu Hỏi hoặc Nội Dung Câu Hỏi
                Input: dataGridView
                Output: none
                Created by: Đỗ Mai Anh
                Dùng trong : Component_CauHoi
         */
        public void TimKiemCauHoi(DataGridView dataGridView, string noiDungTimKiem)
        {
            if (noiDungTimKiem == "")
            {
                MyDialog dialog = new MyDialog("Vui lòng nhập từ khóa để tìm kiếm.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }
            //Nếu là số thì tìm theo mã câu hỏi
            if (int.TryParse(noiDungTimKiem, out int maCauHoi))
            {
                var cauHoi = CauHoiDAO.GetListCauHoiById(maCauHoi);
                if (cauHoi != null)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Rows.Add(
                        cauHoi.maCauHoi,
                        cauHoi.noiDungCauHoi,
                        cauHoi.maMonHoc,
                        cauHoi.maChuong,
                        cauHoi.doKho,
                        cauHoi.noiDungCauHoi
                    );
                }
                else
                {
                    MyDialog dialog = new MyDialog("Không tìm thấy câu hỏi.", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                }
            }
            else //Ngược lại tìm theo nội dung câu hỏi
            {
                var cauHoi = CauHoiDAO.TimKiemCauHoiTheoNoiDung(noiDungTimKiem);
                if (cauHoi != null)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Rows.Add(
                        cauHoi.maCauHoi,
                        cauHoi.noiDungCauHoi,
                        cauHoi.maMonHoc,
                        cauHoi.maChuong,
                        cauHoi.doKho,
                        cauHoi.noiDungCauHoi
                    );
                }
                else
                {
                    MyDialog dialog = new MyDialog("Không tìm thấy câu hỏi.", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                }

            }
        }


    }
}
