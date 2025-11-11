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
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class XemChiTietDeThi : UserControl
    {
        private BaiLamBUS baiLamBUS = new BaiLamBUS();
        private ChiTietBaiLamBUS chiTietBaiLamBUS = new ChiTietBaiLamBUS();
        private int currentMaDe = 0;
        private List<Dictionary<string, object>> danhSachBaiLam = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> danhSachBaiLamHienTai = new List<Dictionary<string, object>>();

        public XemChiTietDeThi()
        {
            InitializeComponent();
            SetupDataGridView();
            InitializeData();
        }

        // Phương thức public để load dữ liệu theo mã đề thi
        public void LoadDataByMaDe(int maDe)
        {
            currentMaDe = maDe;
            LoadBaiLamData();
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
                // Chỉ load dữ liệu nếu có mã đề thi
                if (currentMaDe > 0)
                {
                    LoadBaiLamData();
                }
                else
                {
                    // Xóa dữ liệu nếu chưa có mã đề thi
                    dataGridView1.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBaiLamData()
        {
            try
            {
                if (currentMaDe == 0)
                {
                    dataGridView1.Rows.Clear();
                    return;
                }

                // Load dữ liệu từ database
                danhSachBaiLam = baiLamBUS.GetBaiLamByMaDeWithSinhVien(currentMaDe);
                
                // Nếu không có dữ liệu từ database, xóa dữ liệu hiển thị
                if (danhSachBaiLam == null || danhSachBaiLam.Count == 0)
                {
                    dataGridView1.Rows.Clear();
                    danhSachBaiLamHienTai = new List<Dictionary<string, object>>();
                    return;
                }

                // Cập nhật danh sách hiện tại
                danhSachBaiLamHienTai = danhSachBaiLam;
                
                // Hiển thị dữ liệu
                DisplayBaiLamData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu bài làm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Rows.Clear();
            }
        }

        private void DisplayBaiLamData()
        {
            try
            {
                dataGridView1.Rows.Clear();
                
                foreach (var baiLam in danhSachBaiLamHienTai)
                {
                    string mssv = baiLam["maSinhVien"].ToString();
                    string tenSV = baiLam["hoVaTen"].ToString();
                    string diem = baiLam["tongDiem"].ToString();
                    int maBaiLam = Convert.ToInt32(baiLam["maBaiLam"]);
                    
                    // Lấy thời gian bắt đầu và nộp bài từ database
                    string timeVaoThi = "N/A";
                    string timeNopBai = "N/A";
                    
                    if (baiLam.ContainsKey("thoiGianBatDau") && baiLam["thoiGianBatDau"] != null)
                    {
                        DateTime thoiGianBatDau = (DateTime)baiLam["thoiGianBatDau"];
                        timeVaoThi = thoiGianBatDau.ToString("dd/MM/yyyy HH:mm:ss");
                    }
                    
                    if (baiLam.ContainsKey("thoiGianNopBai") && baiLam["thoiGianNopBai"] != null)
                    {
                        DateTime thoiGianNopBai = (DateTime)baiLam["thoiGianNopBai"];
                        timeNopBai = thoiGianNopBai.ToString("dd/MM/yyyy HH:mm:ss");
                    }
                    
                    // Thêm row vào DataGridView
                    int rowIndex = dataGridView1.Rows.Add(mssv, tenSV, diem, timeVaoThi, timeNopBai, "Xem");
                    
                    // Lưu maBaiLam vào Tag của row để dùng khi click Xem
                    dataGridView1.Rows[rowIndex].Tag = maBaiLam;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void comboBoxTatCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LỌC THEO COMBOBOX TẤT CẢ
            try
            {
                ApplyFilters();
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
                ApplyFilters();
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
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            try
            {
                if (danhSachBaiLam == null || danhSachBaiLam.Count == 0)
                {
                    dataGridView1.Rows.Clear();
                    return;
                }

                // Lọc theo từ khóa tìm kiếm
                string searchKeyword = textBoxTimKiem.Text.Trim().ToLower();
                var filteredList = danhSachBaiLam.Where(b => 
                    string.IsNullOrEmpty(searchKeyword) ||
                    b["maSinhVien"].ToString().ToLower().Contains(searchKeyword) ||
                    b["hoVaTen"].ToString().ToLower().Contains(searchKeyword)
                ).ToList();

                // Cập nhật danh sách hiện tại
                danhSachBaiLamHienTai = filteredList;
                
                // Hiển thị lại dữ liệu
                DisplayBaiLamData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // XUẤT EXCEL
            try
            {
                if (danhSachBaiLamHienTai == null || danhSachBaiLamHienTai.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị dialog chọn nơi lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx|CSV Files|*.csv|All Files|*.*";
                saveFileDialog.FileName = $"DanhSachBaiLam_DeThi_{currentMaDe}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    ExportToExcel(filePath);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(string filePath)
        {
            try
            {
                // Tạo file CSV (đơn giản hơn Excel, có thể mở bằng Excel)
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Ghi BOM để Excel nhận diện UTF-8
                    writer.Write('\uFEFF');
                    
                    // Ghi header
                    writer.WriteLine("MSSV,Tên Sinh Viên,Điểm,Thời Gian Vào Thi,Thời Gian Nộp Bài");
                    
                    // Ghi dữ liệu
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        
                        string mssv = row.Cells["ColMSSV"].Value?.ToString() ?? "";
                        string ten = row.Cells["ColTen"].Value?.ToString() ?? "";
                        string diem = row.Cells["ColDiem"].Value?.ToString() ?? "";
                        string timeVao = row.Cells["ColTimeVaoThi"].Value?.ToString() ?? "";
                        string timeNop = row.Cells["ColTimeNopBai"].Value?.ToString() ?? "";
                        
                        // Escape dấu phẩy trong dữ liệu
                        writer.WriteLine($"\"{mssv}\",\"{ten}\",\"{diem}\",\"{timeVao}\",\"{timeNop}\"");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi ghi file Excel: {ex.Message}");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // XỬ LÝ CLICK VÀO NÚT XEM BÀI LÀM
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
                        int maBaiLam = 0;
                        
                        // Lấy maBaiLam từ Tag hoặc từ danh sách
                        if (dataGridView1.Rows[e.RowIndex].Tag != null)
                        {
                            maBaiLam = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Tag);
                        }
                        else if (danhSachBaiLamHienTai != null && e.RowIndex < danhSachBaiLamHienTai.Count)
                        {
                            maBaiLam = Convert.ToInt32(danhSachBaiLamHienTai[e.RowIndex]["maBaiLam"]);
                        }
                        
                        if (!string.IsNullOrEmpty(mssv) && maBaiLam > 0)
                        {
                            // Mở dialog xem bài làm của sinh viên
                            OpenBaiLamDialog(mssv, tenSV, currentMaDe, maBaiLam);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin bài làm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý click: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenBaiLamDialog(string mssv, string tenSV, int maDe, int maBaiLam)
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
    }
}

