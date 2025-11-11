using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;

/*
 * File: Component_DeKiemTra.cs
 * Mô tả: UserControl quản lý danh sách đề kiểm tra
 * Chức năng:
 *   - Hiển thị danh sách đề thi với phân trang
 *   - Lọc đề thi theo trạng thái (Tất cả, Đang diễn ra, Sắp diễn ra, Đã kết thúc)
 *   - Tìm kiếm đề thi theo tên hoặc mã môn học
 *   - Tạo mới, sửa, xóa, xem chi tiết đề thi
 *   - Tự động xác định trạng thái đề thi dựa trên thời gian hiện tại
 * Dùng trong: Form chính quản lý đề thi
 */

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_DeKiemTra : UserControl
    {
        public Component_DeKiemTra()
        {
            InitializeComponent();
            InitializeData();
        }

        private DeKiemTraBUS deKiemTraBUS = new DeKiemTraBUS();
        private MonHocDAO monHocDAO = new MonHocDAO();
        private Dictionary<string, string> dictMonHoc = new Dictionary<string, string>(); // Dictionary để map maMonHoc -> tenMonHoc
        private List<DeKiemTra> danhSachDeThi = new List<DeKiemTra>();
        private List<DeKiemTra> danhSachDeThiHienTai = new List<DeKiemTra>(); // Danh sách đề thi hiển thị (sau khi lọc/tìm)
        private bool isInitializing = false; // Flag để kiểm tra đang khởi tạo
        private string currentFilterStatus = "Tất cả"; // Trạng thái lọc hiện tại
        private string currentSearchKeyword = ""; // Từ khóa tìm kiếm hiện tại
        
   
        private int currentPage = 1;
        private int itemsPerPage = 3; // Số đề thi hiển thị mỗi trang
        private int totalPages = 1;

        

        private void InitializeData()
        {
            // KHỞI TẠO DỮ LIỆU CHO COMBOBOX VÀ LOAD DỮ LIỆU ĐỀ THI
            try
            {
                isInitializing = true; // Đánh dấu đang khởi tạo
                
                // Khởi tạo các biến lọc
                currentFilterStatus = "Tất cả";
                currentSearchKeyword = "";
                
                // Load danh sách môn học vào dictionary
                LoadMonHocDictionary();
                
                // Khởi tạo ComboBox - chỉ 4 lựa chọn
                combobox1.Items.Clear();
                combobox1.Items.Add("Tất cả");
                combobox1.Items.Add("Đang diễn ra");
                combobox1.Items.Add("Sắp diễn ra");
                combobox1.Items.Add("Đã kết thúc");
                combobox1.SelectedIndex = 0; // Chọn "Tất cả" mặc định
                
                // Khởi tạo phân trang
                currentPage = 1;
                itemsPerPage = 3;
                
                // Load dữ liệu đề thi từ database
                LoadDeThiData();
                
                isInitializing = false; // Kết thúc khởi tạo
            }
            catch (Exception ex)
            {
                isInitializing = false;
                MessageBox.Show($"Lỗi khi khởi tạo dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách môn học vào dictionary để tra cứu nhanh
        private void LoadMonHocDictionary()
        {
            try
            {
                dictMonHoc.Clear();
                ArrayList danhSachMonHoc = monHocDAO.GetListMonHoc();
                
                if (danhSachMonHoc != null)
                {
                    foreach (MonHoc monHoc in danhSachMonHoc)
                    {
                        if (monHoc != null && !string.IsNullOrEmpty(monHoc.maMonHoc) && !string.IsNullOrEmpty(monHoc.tenMonHoc))
                        {
                            dictMonHoc[monHoc.maMonHoc] = monHoc.tenMonHoc;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, dictionary sẽ rỗng và sẽ hiển thị chỉ mã môn học
                dictMonHoc.Clear();
                // Có thể log lỗi ở đây nếu cần
                System.Diagnostics.Debug.WriteLine($"Lỗi khi load danh sách môn học: {ex.Message}");
            }
        }

        //========================================================================
        // LOAD DỮ LIỆU
        //========================================================================

        private void LoadDeThiData()
        {
            try
            {
                // Load tất cả đề thi từ database
                danhSachDeThi = deKiemTraBUS.GetListDeKiemTra();
                
                // Reset về trang đầu khi reload
                currentPage = 1;
                
                // Áp dụng lại bộ lọc và tìm kiếm hiện tại
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu đề thi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HIỂN THỊ DỮ LIỆU ĐỀ THI LÊN GIAO DIỆN VỚI PHÂN TRANG
        private void DisplayDeThiData()
        {
            try
            {
                // Không ghi đè danhSachDeThiHienTai - chỉ hiển thị dữ liệu đã được lọc
                if (danhSachDeThiHienTai == null)
                {
                    danhSachDeThiHienTai = new List<DeKiemTra>();
                }
                
                // Tính toán phân trang
                totalPages = (int)Math.Ceiling((double)danhSachDeThiHienTai.Count / itemsPerPage);
                if (totalPages == 0) totalPages = 1;
                
                // Đảm bảo currentPage không vượt quá totalPages
                if (currentPage > totalPages)
                    currentPage = totalPages;
                if (currentPage < 1)
                    currentPage = 1;
                
                // Xóa các panel cũ
                ClearAllDeThiPanels();
                
                if (danhSachDeThiHienTai != null && danhSachDeThiHienTai.Count > 0)
                {
                    // Tính toán vị trí bắt đầu và kết thúc
                    int startIndex = (currentPage - 1) * itemsPerPage;
                    int endIndex = Math.Min(startIndex + itemsPerPage, danhSachDeThiHienTai.Count);
                    
                    // Tạo panel cho từng đề thi trong trang hiện tại
                    int yPosition = 10;
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        CreateDeThiPanel(danhSachDeThiHienTai[i], yPosition);
                        yPosition += 160; // Khoảng cách giữa các panel
                    }
                }
                else
                {
                    // Không có dữ liệu
                    labelkiemtra.Text = "CHƯA CÓ ĐỀ THI";
                    labelhocphan.Text = "Chưa có môn học";
                    labeltime.Text = "Chưa có thời gian";
                    labeltrangthaithuc.Text = "Không có dữ liệu";
                    labeltrangthaithuc.ForeColor = Color.Gray;
                }
                
                // Cập nhật UI phân trang
                UpdatePaginationUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void UpdatePaginationUI()
        {
            try
            {
                // Cập nhật label thông tin trang
                lblPageInfo.Text = $"Trang {currentPage} / {totalPages}";
                
                // Cập nhật trạng thái nút Previous
                btnPrevious.Enabled = currentPage > 1;
                btnPrevious.BackColor = currentPage > 1 
                    ? Color.FromArgb(52, 152, 219) 
                    : Color.FromArgb(200, 200, 200);
                
                // Cập nhật trạng thái nút Next
                btnNext.Enabled = currentPage < totalPages;
                btnNext.BackColor = currentPage < totalPages 
                    ? Color.FromArgb(52, 152, 219) 
                    : Color.FromArgb(200, 200, 200);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật phân trang: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //========================================================================
        // TẠO VÀ QUẢN LÝ UI
        //========================================================================

        private void CreateDeThiPanel(DeKiemTra deThi, int yPosition)
        {
            // Tạo panel chính
            Panel deThiPanel = new Panel();
            deThiPanel.Name = $"panelDeThi_{deThi.maDe}";
            deThiPanel.Size = new Size(1400, 150);
            deThiPanel.Location = new Point(10, yPosition);
            deThiPanel.BackColor = Color.FromArgb(215, 229, 255);
            deThiPanel.BorderStyle = BorderStyle.FixedSingle;
            deThiPanel.Tag = deThi; // Lưu thông tin đề thi

            // Tạo các label cho thông tin đề thi
            Label lblTenDe = new Label();
            lblTenDe.Text = $"ĐỀ THI #{deThi.maDe} - {deThi.tenDe.ToUpper()}";
            lblTenDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTenDe.Location = new Point(15, 15);
            lblTenDe.Size = new Size(800, 30);
            lblTenDe.ForeColor = Color.FromArgb(51, 51, 51);

            // Lấy tên môn học từ dictionary
            string tenMonHoc = "";
            string maMonHoc = deThi.maMonHoc?.Trim() ?? "";
            
            if (!string.IsNullOrEmpty(maMonHoc) && dictMonHoc != null && dictMonHoc.ContainsKey(maMonHoc))
            {
                tenMonHoc = dictMonHoc[maMonHoc];
            }
            
            // Nếu không tìm thấy trong dictionary, thử load trực tiếp từ database
            if (string.IsNullOrEmpty(tenMonHoc) && !string.IsNullOrEmpty(maMonHoc))
            {
                try
                {
                    MonHoc monHoc = monHocDAO.getMonHocByID(maMonHoc);
                    if (monHoc != null && !string.IsNullOrEmpty(monHoc.tenMonHoc))
                    {
                        tenMonHoc = monHoc.tenMonHoc;
                        // Cập nhật vào dictionary để lần sau không cần query lại
                        dictMonHoc[maMonHoc] = tenMonHoc;
                    }
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, chỉ hiển thị mã môn học
                    System.Diagnostics.Debug.WriteLine($"Lỗi khi lấy tên môn học cho mã {maMonHoc}: {ex.Message}");
                }
            }
            
            Label lblMonHoc = new Label();
            if (!string.IsNullOrEmpty(tenMonHoc))
            {
                lblMonHoc.Text = $"Môn học: {maMonHoc} - {tenMonHoc}";
            }
            else
            {
                lblMonHoc.Text = string.IsNullOrEmpty(maMonHoc) ? "Môn học: (Chưa có)" : $"Môn học: {maMonHoc}";
            }
            lblMonHoc.Font = new Font("Segoe UI", 12F);
            lblMonHoc.Location = new Point(15, 50);
            lblMonHoc.Size = new Size(800, 25);

            Label lblThoiGian = new Label();
            lblThoiGian.Text = $"Thời gian: {deThi.thoiGianBatDau:dd/MM/yyyy HH:mm} - {deThi.thoiGianKetThuc:dd/MM/yyyy HH:mm}";
            lblThoiGian.Font = new Font("Segoe UI", 12F);
            lblThoiGian.Location = new Point(15, 75);
            lblThoiGian.Size = new Size(600, 25);

            // Xác định trạng thái và màu sắc
            DateTime now = DateTime.Now;
            string trangThai = GetTrangThaiDeThi(deThi, now);
            Color trangThaiColor = Color.Black;

            if (now < deThi.thoiGianBatDau)
                trangThaiColor = Color.Blue;
            else if (now >= deThi.thoiGianBatDau && now <= deThi.thoiGianKetThuc)
                trangThaiColor = Color.Green;
            else
                trangThaiColor = Color.Red;

            Label lblTrangThai = new Label();
            lblTrangThai.Text = $"Trạng thái: {trangThai}";
            lblTrangThai.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTrangThai.Location = new Point(15, 100);
            lblTrangThai.Size = new Size(300, 25);
            lblTrangThai.ForeColor = trangThaiColor;

            // Tạo các nút hành động
            Button btnXem = new Button();
            btnXem.Text = "Xem";
            btnXem.Size = new Size(80, 35);
            btnXem.Location = new Point(1200, 20);
            btnXem.BackColor = Color.FromArgb(52, 152, 219);
            btnXem.ForeColor = Color.White;
            btnXem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXem.Tag = deThi;
            btnXem.Click += (s, e) => {
                var selectedDeThi = (DeKiemTra)((Button)s).Tag;
                ShowXemChiTietDialog(selectedDeThi);
            };

            Button btnSua = new Button();
            btnSua.Text = "Sửa";
            btnSua.Size = new Size(80, 35);
            btnSua.Location = new Point(1200, 60);
            btnSua.BackColor = Color.FromArgb(241, 196, 15);
            btnSua.ForeColor = Color.White;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.Tag = deThi;
            btnSua.Click += (s, e) => {
                var selectedDeThi = (DeKiemTra)((Button)s).Tag;
                ShowCreateExamDialog(true, selectedDeThi);
            };

            Button btnXoa = new Button();
            btnXoa.Text = "Xóa";
            btnXoa.Size = new Size(80, 35);
            btnXoa.Location = new Point(1200, 100);
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.ForeColor = Color.White;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.Tag = deThi;
            btnXoa.Click += (s, e) => {
                var selectedDeThi = (DeKiemTra)((Button)s).Tag;
                DeleteDeThi(selectedDeThi);
            };

            // Thêm các control vào panel
            deThiPanel.Controls.Add(lblTenDe);
            deThiPanel.Controls.Add(lblMonHoc);
            deThiPanel.Controls.Add(lblThoiGian);
            deThiPanel.Controls.Add(lblTrangThai);
            deThiPanel.Controls.Add(btnXem);
            deThiPanel.Controls.Add(btnSua);
            deThiPanel.Controls.Add(btnXoa);

            // Thêm panel vào panelKiemTra
            panelKiemTra.Controls.Add(deThiPanel);
        }

        // XÓA TẤT CẢ PANEL ĐỀ THI
        private void ClearAllDeThiPanels()
        {
            // Xóa tất cả panel đề thi (trừ các control gốc)
            var controlsToRemove = new List<Control>();
            foreach (Control control in panelKiemTra.Controls)
            {
                if (control.Name.StartsWith("panelDeThi_"))
                {
                    controlsToRemove.Add(control);
                }
            }
            
            foreach (var control in controlsToRemove)
            {
                panelKiemTra.Controls.Remove(control);
                control.Dispose();
            }
        }

        //========================================================================
        // XỬ LÝ NGHIỆP VỤ
        //========================================================================

        private void DeleteDeThi(DeKiemTra deThi)
        {
            try
            {
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa đề thi '{deThi.tenDe}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    if (deKiemTraBUS.DeleteDeThi(deThi.maDe))
                    {
                        MessageBox.Show("Đã xóa đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDeThiData(); // Reload dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đề thi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HIỂN THỊ DIALOG XEM CHI TIẾT ĐỀ THI
        private void ShowXemChiTietDialog(DeKiemTra deThi)
        {
            try
            {
                // Tạo form wrapper cho XemChiTietDeThi
                Form dialogForm = new Form();
                dialogForm.Text = $"Chi tiết đề thi: {deThi.tenDe}";
                dialogForm.Size = new Size(1200, 800);
                dialogForm.StartPosition = FormStartPosition.CenterParent;
                dialogForm.FormBorderStyle = FormBorderStyle.Sizable;
                dialogForm.MaximizeBox = true;
                dialogForm.MinimizeBox = true;
                dialogForm.MinimumSize = new Size(1200, 800);

                // Tạo panel để scroll
                Panel scrollPanel = new Panel();
                scrollPanel.Dock = DockStyle.Fill;
                scrollPanel.AutoScroll = true;

                // Tạo XemChiTietDeThi user control
                XemChiTietDeThi xemChiTietDeThi = new XemChiTietDeThi();
                xemChiTietDeThi.Size = new Size(1200, 800);
                xemChiTietDeThi.Location = new Point(0, 0);
                
                // Load dữ liệu theo mã đề thi
                xemChiTietDeThi.LoadDataByMaDe(deThi.maDe);

                // Thêm vào panel và form
                scrollPanel.Controls.Add(xemChiTietDeThi);
                dialogForm.Controls.Add(scrollPanel);

                // Hiển thị dialog
                dialogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị chi tiết đề thi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTrangThaiDeThi(DeKiemTra deThi, DateTime now)
        {
            if (now < deThi.thoiGianBatDau)
            {
                return "[Sắp diễn ra]";
            }
            else if (now >= deThi.thoiGianBatDau && now <= deThi.thoiGianKetThuc)
            {
                return "[Đang diễn ra]";
            }
            else
            {
                return "[Đã kết thúc]";
            }
        }

        //========================================================================
        // XỬ LÝ SỰ KIỆN
        //========================================================================

        private void Component_DeKiemTra_Load(object sender, EventArgs e)
        {

        }

        // Tạo đề kiểm tra mới
        private void button2_Click(object sender, EventArgs e)
        {
            // TẠO ĐỀ KIỂM TRA MỚI
            try
            {
                // Mở dialog tạo đề thi ở chế độ tạo mới
                ShowCreateExamDialog(false, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo đề kiểm tra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Lọc đề kiểm tra theo trạng thái
        private void combobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Bỏ qua nếu đang khởi tạo
                if (isInitializing)
                    return;
                
                string selectedValue = combobox1.SelectedItem?.ToString() ?? "Tất cả";
                currentFilterStatus = selectedValue;
                
                // Áp dụng cả lọc trạng thái và tìm kiếm
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc đề kiểm tra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tìm kiếm đề kiểm tra theo từ khóa
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchKeyword = textBoxTimKiem.Text.Trim();
                currentSearchKeyword = searchKeyword;
                
                // Áp dụng cả lọc trạng thái và tìm kiếm
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //========================================================================
        // LỌC VÀ TÌM KIẾM
        //========================================================================

        // Áp dụng cả lọc trạng thái và tìm kiếm
        private void ApplyFilters()
        {
            try
            {
                if (danhSachDeThi == null || danhSachDeThi.Count == 0)
                {
                    danhSachDeThiHienTai = new List<DeKiemTra>();
                    DisplayDeThiData();
                    return;
                }

                // Bước 1: Lọc theo trạng thái
                List<DeKiemTra> filteredList = new List<DeKiemTra>();
                DateTime now = DateTime.Now;

                switch (currentFilterStatus)
                {
                    case "Tất cả":
                        filteredList = danhSachDeThi.ToList(); // Tạo bản sao
                        break;
                    case "Đang diễn ra":
                        filteredList = danhSachDeThi.Where(d => now >= d.thoiGianBatDau && now <= d.thoiGianKetThuc).ToList();
                        break;
                    case "Sắp diễn ra":
                        filteredList = danhSachDeThi.Where(d => now < d.thoiGianBatDau).ToList();
                        break;
                    case "Đã kết thúc":
                        filteredList = danhSachDeThi.Where(d => now > d.thoiGianKetThuc).ToList();
                        break;
                    default:
                        filteredList = danhSachDeThi.ToList();
                        break;
                }

                // Bước 2: Áp dụng tìm kiếm (nếu có từ khóa)
                if (!string.IsNullOrWhiteSpace(currentSearchKeyword))
                {
                    filteredList = filteredList.Where(d => 
                        d.tenDe.ToLower().Contains(currentSearchKeyword.ToLower()) ||
                        d.maMonHoc.ToLower().Contains(currentSearchKeyword.ToLower())
                    ).ToList();
                }

                // Cập nhật danh sách hiện tại
                danhSachDeThiHienTai = filteredList;
                currentPage = 1; // Reset về trang đầu
                
                // Hiển thị dữ liệu với phân trang
                DisplayDeThiData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Hiển thị dialog tạo/sửa đề thi
        private void ShowCreateExamDialog(bool isEditMode, DTO.DeKiemTra deThiToEdit)
        {
            try
            {
                // Tạo Form tạm thời để hiển thị UserControl như dialog
                Form dialogForm = new Form();
                dialogForm.Text = isEditMode ? "Sửa Đề Thi" : "Tạo Đề Thi";
                dialogForm.FormBorderStyle = FormBorderStyle.Sizable;
                dialogForm.MaximizeBox = true;
                dialogForm.MinimizeBox = true;
                dialogForm.StartPosition = FormStartPosition.CenterParent;
                dialogForm.Size = new Size(1000, 800); 
                dialogForm.MinimumSize = new Size(1000, 800);
                
                // Tạo Panel để chứa UserControl với scroll
                Panel scrollPanel = new Panel();
                scrollPanel.Dock = DockStyle.Fill;
                scrollPanel.AutoScroll = true;
                scrollPanel.BorderStyle = BorderStyle.None;
                
                // Tạo UserControl và KHÔNG dock để có thể cuộn
                Dialog_TaoDeThi dialogTaoDeThi = new Dialog_TaoDeThi();
                dialogTaoDeThi.Location = new Point(0, 0); // Đặt vị trí cố định
                dialogTaoDeThi.Size = new Size(1000, 1270); // Giữ nguyên kích thước gốc của UserControl
                
                // ĐĂNG KÝ EVENT ĐỂ RELOAD DỮ LIỆU KHI CÓ THAY ĐỔI
                dialogTaoDeThi.DataChanged += (sender, e) => {
                    LoadMonHocDictionary(); // Reload danh sách môn học
                    LoadDeThiData(); // Reload dữ liệu khi có thay đổi
                };
                
                // Thiết lập chế độ edit hoặc create
                if (isEditMode && deThiToEdit != null)
                {
                    dialogTaoDeThi.SetEditMode(deThiToEdit);
                }
                else
                {
                    dialogTaoDeThi.SetCreateMode();
                }
                
                scrollPanel.Controls.Add(dialogTaoDeThi);
                
                // Thêm Panel vào Form
                dialogForm.Controls.Add(scrollPanel);
                
                // Hiển thị dialog
                dialogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dialog: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Reload dữ liệu đề kiểm tra
        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                // Load lại danh sách môn học
                LoadMonHocDictionary();
                
                // Load lại dữ liệu từ database
                LoadDeThiData();
                MessageBox.Show("Đã reload dữ liệu đề kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi reload dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xem chi tiết đề kiểm tra
        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo Form tạm thời để hiển thị UserControl như dialog
                Form dialogForm = new Form();
                dialogForm.Text = "Xem Chi Tiết Đề Thi";
                dialogForm.FormBorderStyle = FormBorderStyle.Sizable;
                dialogForm.MaximizeBox = true;
                dialogForm.MinimizeBox = true;
                dialogForm.StartPosition = FormStartPosition.CenterParent;
                dialogForm.Size = new Size(1300, 800); 
                dialogForm.MinimumSize = new Size(1300, 800);
                
                // Tạo UserControl XemChiTietDeThi
                XemChiTietDeThi xemChiTietDeThi = new XemChiTietDeThi();
                xemChiTietDeThi.Dock = DockStyle.Fill;
                dialogForm.Controls.Add(xemChiTietDeThi);
                
                // Hiển thị dialog
                dialogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết đề kiểm tra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa đề kiểm tra đã chọn
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có đề nào được chọn trong ListBox không
                if (listBoxDeThi.SelectedIndex >= 0 && listBoxDeThi.SelectedIndex < danhSachDeThi.Count)
                {
                    var deThiToEdit = danhSachDeThi[listBoxDeThi.SelectedIndex];
                    
                    // Mở dialog tạo đề thi ở chế độ edit
                    ShowCreateExamDialog(true, deThiToEdit);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đề thi cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa đề kiểm tra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa đề kiểm tra đã chọn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có đề nào được chọn trong ListBox không
                if (listBoxDeThi.SelectedIndex >= 0 && listBoxDeThi.SelectedIndex < danhSachDeThi.Count)
                {
                    var deThiToDelete = danhSachDeThi[listBoxDeThi.SelectedIndex];
                    
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa đề thi '{deThiToDelete.tenDe}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        // Thực hiện xóa đề thi từ database
                        if (deKiemTraBUS.DeleteDeThi(deThiToDelete.maDe))
                        {
                            MessageBox.Show("Đã xóa đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Reload dữ liệu sau khi xóa
                            LoadDeThiData();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi xóa đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đề thi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đề kiểm tra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //========================================================================
        // PHÂN TRANG
        //========================================================================

        // Chuyển về trang trước
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    DisplayDeThiData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuyển trang: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Chuyển sang trang sau
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPage < totalPages)
                {
                    currentPage++;
                    DisplayDeThiData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuyển trang: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Hiệu ứng hover cho nút phân trang
        private void btnPrevious_MouseEnter(object sender, EventArgs e)
        {
            if (btnPrevious.Enabled)
            {
                btnPrevious.BackColor = Color.FromArgb(41, 128, 185);
            }
        }
        
        private void btnPrevious_MouseLeave(object sender, EventArgs e)
        {
            if (btnPrevious.Enabled)
            {
                btnPrevious.BackColor = Color.FromArgb(52, 152, 219);
            }
        }
        
        private void btnNext_MouseEnter(object sender, EventArgs e)
        {
            if (btnNext.Enabled)
            {
                btnNext.BackColor = Color.FromArgb(41, 128, 185);
            }
        }
        
        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            if (btnNext.Enabled)
            {
                btnNext.BackColor = Color.FromArgb(52, 152, 219);
            }
        }
    }
}

