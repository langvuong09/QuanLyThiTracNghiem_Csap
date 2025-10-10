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
    internal class DapAnBUS
    {
        private DapAnDAO dapAnDAO = new DapAnDAO();
        public DapAnBUS()
        {
        }

        /*
            Phương thức lấy danh sách đáp án theo Mã Câu Hỏi và bỏ nó vào DataGridView
               Input: dataGridView
               Output: none
               Created by: Đỗ Mai Anh
               Dùng trong :Dialog_SuaCauHoi

        */
        public void LayDSDapAnTheoMaCauHoi(DataGridView dataGridView, int maCauHoi)
        {
            try
            {
                var dsDapAn = dapAnDAO.LayDSDapAnTheoMaCauHoi(maCauHoi);
                // Đảm bảo DataGridView có cột
                if (dataGridView.Columns.Count == 0)
                {
                    Console.WriteLine("DataGridView chưa có cột — kiểm tra lại quá trình khởi tạo.");
                    return;
                }

                // Xóa dữ liệu cũ
                dataGridView.Rows.Clear();
                // Thêm dữ liệu mới
                foreach (var item in dsDapAn)
                {
                    dataGridView.Rows.Add(
                        item.maDapAn,
                        item.tenDapAn,
                        item.dungSai == 1 ? "Đúng" : "Sai"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DapAnBUS => Lỗi khi lấy danh sách đáp án: " + ex.Message);
            }
        }

        /*
            Phương thức sửa đáp án và tải lại DataGridView
               Input: dataGridView, textBox_TenDapAn,textBox_maDapAn
               Output: none
               Created by: Đỗ Mai Anh
               Dùng trong :Dialog_SuaCauHoi
        */

        public void SuaDapAnVaTaiLaiDataGridView(
            DataGridView dataGridView,
            int maCauHoi,
            TextBox textBox_TenDapAn,
            TextBox textBox_maDapAn
        )
        {
            try
            {

                if (string.IsNullOrWhiteSpace(textBox_TenDapAn.Text))
                {
                    MyDialog dialog = new MyDialog("Vui lòng nhập tên đáp án.", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                 
                    return;
                }
                if (!int.TryParse(textBox_maDapAn.Text, out int maDapAn))
                {

                    MyDialog dialog = new MyDialog("Mã đáp án không hợp lệ.", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                    return;
                }
                bool success = dapAnDAO.SuaDapAn(maDapAn, textBox_TenDapAn.Text, maCauHoi);
                if (success)
                {
                    // Tải lại danh sách đáp án vào DataGridView
                    LayDSDapAnTheoMaCauHoi(dataGridView, maCauHoi);

                    MyDialog dialog = new MyDialog("Sửa đáp án thành công.", MyDialog.SUCCESS_DIALOG);
                    dialog.ShowDialog();
                }
                else
                {

                    MyDialog dialog = new MyDialog("Sửa đáp án thất bại. Vui lòng thử lại.", MyDialog.ERROR_DIALOG);
                    dialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DapAnBUS => Lỗi khi sửa đáp án: " + ex.Message);

                MyDialog dialog = new MyDialog("Đã xảy ra lỗi khi sửa đáp án. Vui lòng thử lại.", MyDialog.ERROR_DIALOG);
                dialog.ShowDialog();
            }
        }

        /*
          Phương thức thêm danh sách đáp án vào cơ sở dữ liệu
             Input: DataGridView_DSDapAn, maCauHoi
             Output: boolean
             Created by: Đỗ Mai Anh

        */
        public bool ThemDSDapAnTuDataGridView(DataGridView DataGridView_DSDapAn, int maCauHoi)
        {
            try
            {
                List<DapAn> danhSachDapAn = new List<DapAn>();
                foreach (DataGridViewRow row in DataGridView_DSDapAn.Rows)
                {
                    if (row.IsNewRow) continue; // Bỏ qua dòng mới
                    string maDapAnStr = row.Cells["MaDapAn"].Value?.ToString();
                    string tenDapAn = row.Cells["NoiDung"].Value?.ToString();
                    string dungSaiStr = row.Cells["DungSai"].Value?.ToString();


                    if (string.IsNullOrWhiteSpace(tenDapAn) || string.IsNullOrWhiteSpace(dungSaiStr))
                    {

                        MyDialog dialog = new MyDialog("Tên đáp án và Đúng/Sai không được để trống.", MyDialog.WARNING_DIALOG);
                        dialog.ShowDialog();
                        return false;
                    }
                    int maDapAn = int.TryParse(maDapAnStr, out int tempMaDapAn) ? tempMaDapAn : 1;
                    int dungSai = dungSaiStr.Equals("Đúng", StringComparison.OrdinalIgnoreCase) ? 1 : 0;
                    
                    DapAn dapAn = new DapAn(maDapAn, maCauHoi, tenDapAn, dungSai);

                    danhSachDapAn.Add(dapAn);
                }
                if (danhSachDapAn.Count == 0)
                {

                    MyDialog dialog = new MyDialog("Vui lòng thêm đủ 4 đáp án", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                    return false;
                }
                bool success = dapAnDAO.ThemDSDapAn(danhSachDapAn);
                if (success)
                {

                    MyDialog dialog = new MyDialog("Thêm danh sách đáp án thành công.", MyDialog.SUCCESS_DIALOG);
                    dialog.ShowDialog();
                }
                else
                {

                    MyDialog dialog = new MyDialog("Thêm danh sách đáp án thất bại. Vui lòng thử lại.", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                }
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DapAnBUS => Lỗi khi thêm danh sách đáp án: " + ex.Message);

                MyDialog dialog = new MyDialog("Đã xảy ra lỗi khi thêm danh sách đáp án. Vui lòng thử lại.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();

            }
            return false;
        }

        /*
          Phương thức xóa đáp án theo mã câu hỏi
             Input: maCauHoi
             Output: none
             Created by: Đỗ Mai Anh

        */
        public void XoaDapAnTheoMaCauHoi(int maCauHoi)
        {
            try
            {
                bool success = dapAnDAO.XoaDSDapAnTheoMaCauHoi(maCauHoi);
                if (success)
                {
                    Console.WriteLine("Xóa đáp án theo mã câu hỏi thành công.");
                }
                else
                {
                    Console.WriteLine("Xóa đáp án theo mã câu hỏi thất bại. Vui lòng thử lại.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("DapAnBUS => Lỗi khi xóa đáp án theo mã câu hỏi: " + ex.Message);
            }



        }
    }
}
