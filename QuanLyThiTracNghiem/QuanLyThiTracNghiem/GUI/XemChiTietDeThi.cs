using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class XemChiTietDeThi : UserControl
    {
        public XemChiTietDeThi()
        {
            InitializeComponent();
            SetupDataGridView();
            InitializeData();
        }

        private void SetupDataGridView()
        {
            // THIẾT LẬP MÀU SẮC VÀ FONT CHO DATAGRIDVIEW
            try
            {
                // Thiết lập màu sắc cho header
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(126, 164, 241);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                // Thiết lập font cho nội dung các cell
                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.DefaultCellStyle.BackColor = Color.White; // Nền trắng cho tất cả hàng
                
                // Thiết lập kích thước cột
                ColMSSV.Width = 150;
                ColTen.Width = 200;
                ColDiem.Width = 100;
                ColTimeVaoThi.Width = 200;
                ColTimeNopBai.Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thiết lập DataGridView: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeData()
        {
            // KHỞI TẠO DỮ LIỆU CHO DATAGRIDVIEW
            try
            {
                // TODO: Load dữ liệu từ database
                LoadSampleData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSampleData()
        {
            // DỮ LIỆU MẪU ĐỂ TEST - Sử dụng MSSV thực tế từ database
            dataGridView1.Rows.Clear();
            
            dataGridView1.Rows.Add("3122410006", "Mai Anh", "8.5", "08:00", "09:30", "Xem");
            dataGridView1.Rows.Add("111111", "Cường", "7.2", "08:05", "09:25", "Xem");
            dataGridView1.Rows.Add("3122410006", "Mai Anh", "9.0", "08:10", "09:35", "Xem");
            dataGridView1.Rows.Add("111111", "Cường", "6.8", "08:15", "09:20", "Xem");
            dataGridView1.Rows.Add("3122410006", "Mai Anh", "8.0", "08:20", "09:40", "Xem");
        }


        private void comboBoxTatCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LỌC THEO COMBOBOX TẤT CẢ
            try
            {
                string selectedValue = comboBoxTatCa.SelectedItem?.ToString() ?? "Tất cả";
                MessageBox.Show($"Lọc theo: {selectedValue}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxTrangThaiNop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LỌC THEO TRẠNG THÁI NỘP BÀI
            try
            {
                string selectedValue = comboBoxTrangThaiNop.SelectedItem?.ToString() ?? "Đã nộp bài";
                MessageBox.Show($"Lọc theo trạng thái: {selectedValue}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc trạng thái: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            // TÌM KIẾM THEO TỪ KHÓA
            try
            {
                string searchKeyword = textBoxTimKiem.Text.Trim();
                
                if (string.IsNullOrEmpty(searchKeyword))
                {
                    // Hiển thị tất cả dữ liệu khi không có từ khóa
                    LoadSampleData();
                    return;
                }
                
                // TODO: Thực hiện tìm kiếm
                MessageBox.Show($"Tìm kiếm: {searchKeyword}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // XUẤT EXCEL
            try
            {
                MessageBox.Show("Chức năng xuất Excel đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // XỬ LÝ CLICK VÀO ICON XEM BÀI LÀM
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Kiểm tra xem có phải click vào cột hành động không
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "ColHanhDong")
                    {
                        // Lấy thông tin sinh viên
                        string mssv = dataGridView1.Rows[e.RowIndex].Cells["ColMSSV"].Value?.ToString();
                        string tenSV = dataGridView1.Rows[e.RowIndex].Cells["ColTen"].Value?.ToString();
                        
                        if (!string.IsNullOrEmpty(mssv))
                        {
                            // Mở dialog xem bài làm của sinh viên
                            OpenBaiLamDialog(mssv, tenSV);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý click: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenBaiLamDialog(string mssv, string tenSV)
        {
            // MỞ DIALOG XEM BÀI LÀM CỦA SINH VIÊN
            try
            {
                // Tạo Form tạm thời để hiển thị UserControl như dialog
                Form dialogForm = new Form();
                dialogForm.Text = $"Xem bài làm - {tenSV} ({mssv})";
                dialogForm.FormBorderStyle = FormBorderStyle.Sizable;
                dialogForm.MaximizeBox = true;
                dialogForm.MinimizeBox = true;
                dialogForm.StartPosition = FormStartPosition.CenterParent;
                dialogForm.Size = new Size(1000, 700);
                dialogForm.MinimumSize = new Size(800, 600);
                
                // Tạo UserControl xem bài làm
                Dialog_XemBaiThiSV dialogXemBaiThi = new Dialog_XemBaiThiSV();
                dialogXemBaiThi.Dock = DockStyle.Fill;
                
                // Truyền dữ liệu bài làm của sinh viên vào dialog
                // Lấy maDe và maBaiLam tương ứng với MSSV
                int maDe = GetMaDeByMSSV(mssv);
                int maBaiLam = GetMaBaiLamByMSSV(mssv);
                dialogXemBaiThi.LoadBaiLam(mssv, tenSV, maDe, maBaiLam);
                
                dialogForm.Controls.Add(dialogXemBaiThi);
                
                // Hiển thị dialog
                dialogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở dialog xem bài làm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LẤY MÃ ĐỀ THI THEO MSSV (DỮ LIỆU MẪU)
        private int GetMaDeByMSSV(string mssv)
        {
            // Dữ liệu mẫu để test
            switch (mssv)
            {
                case "3122410006":
                    return 1; // Mai Anh làm đề thi 1
                case "111111":
                    return 1; // Cường làm đề thi 1
                default:
                    return 1; // Mặc định đề thi 1
            }
        }

        // LẤY MÃ BÀI LÀM THEO MSSV (DỮ LIỆU MẪU)
        private int GetMaBaiLamByMSSV(string mssv)
        {
            // Dữ liệu mẫu để test
            switch (mssv)
            {
                case "3122410006":
                    return 1; // Mai Anh có bài làm 1
                case "111111":
                    return 2; // Cường có bài làm 2
                default:
                    return 1; // Mặc định bài làm 1
            }
        }
    }
}
