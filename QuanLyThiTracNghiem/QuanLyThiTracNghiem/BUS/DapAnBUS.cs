using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
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
                    MessageBox.Show("Vui lòng nhập tên đáp án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(textBox_maDapAn.Text, out int maDapAn))
                {
                    MessageBox.Show("Mã đáp án không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = dapAnDAO.SuaDapAn(maDapAn, textBox_TenDapAn.Text,maCauHoi);
                if (success)
                {
                    // Tải lại danh sách đáp án vào DataGridView
                    LayDSDapAnTheoMaCauHoi(dataGridView, maCauHoi);
                    MessageBox.Show("Sửa đáp án thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa đáp án thất bại. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DapAnBUS => Lỗi khi sửa đáp án: " + ex.Message);
                MessageBox.Show("Đã xảy ra lỗi khi sửa đáp án. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
