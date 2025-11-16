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
         * Created by: Hoàng Quyên
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
        private Dictionary<string, string> dictMonHoc = new Dictionary<string, string>(); 
        private List<DeKiemTra> danhSachDeThi = new List<DeKiemTra>();
        private List<DeKiemTra> danhSachDeThiHienTai = new List<DeKiemTra>();
        private bool isInitializing = false; 
        private string currentFilterStatus = "Tất cả"; 
        private string currentSearchKeyword = ""; 
        
   
        private int currentPage = 1;
        private int itemsPerPage = 3; 
        private int totalPages = 1;

        /// <summary>
        /// Khởi tạo dữ liệu: load môn học, khởi tạo ComboBox và load danh sách đề thi
        /// </summary>
        private void InitializeData()
        {
            try
            {
                isInitializing = true;
                currentFilterStatus = "Tất cả";
                currentSearchKeyword = "";
                LoadMonHocDictionary();
                
                combobox1.Items.Clear();
                combobox1.Items.Add("Tất cả");
                combobox1.Items.Add("Đang diễn ra");
                combobox1.Items.Add("Sắp diễn ra");
                combobox1.Items.Add("Đã kết thúc");
                combobox1.SelectedIndex = 0;
                
                currentPage = 1;
                itemsPerPage = 3;
                LoadDeThiData();
                
                isInitializing = false;
            }
            catch (Exception ex)
            {
                isInitializing = false;
                MessageBox.Show($"Lỗi khi khởi tạo dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                dictMonHoc.Clear();
                System.Diagnostics.Debug.WriteLine($"Lỗi khi load danh sách môn học: {ex.Message}");
            }
        }

        /// <summary>
        /// Load danh sách đề thi từ database và áp dụng bộ lọc hiện tại
        /// </summary>
        private void LoadDeThiData()
        {
            try
            {
                danhSachDeThi = deKiemTraBUS.GetListDeKiemTra();
                currentPage = 1;
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu đề thi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị danh sách đề thi lên giao diện với phân trang
        /// </summary>
        private void DisplayDeThiData()
        {
            try
            {
                if (danhSachDeThiHienTai == null)
                {
                    danhSachDeThiHienTai = new List<DeKiemTra>();
                }
                
                totalPages = (int)Math.Ceiling((double)danhSachDeThiHienTai.Count / itemsPerPage);
                if (totalPages == 0) totalPages = 1;
                
                if (currentPage > totalPages)
                    currentPage = totalPages;
                if (currentPage < 1)
                    currentPage = 1;
                
                ClearAllDeThiPanels();
                
                if (danhSachDeThiHienTai != null && danhSachDeThiHienTai.Count > 0)
                {
                    int startIndex = (currentPage - 1) * itemsPerPage;
                    int endIndex = Math.Min(startIndex + itemsPerPage, danhSachDeThiHienTai.Count);
                    
                    int yPosition = 10;
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        CreateDeThiPanel(danhSachDeThiHienTai[i], yPosition);
                        yPosition += 160;
                    }
                }
                else
                {
                    labelkiemtra.Text = "CHƯA CÓ ĐỀ THI";
                    labelhocphan.Text = "Chưa có môn học";
                    labeltime.Text = "Chưa có thời gian";
                    labeltrangthaithuc.Text = "Không có dữ liệu";
                    labeltrangthaithuc.ForeColor = Color.Gray;
                }
                
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
                lblPageInfo.Text = $"Trang {currentPage} / {totalPages}";
                btnPrevious.Enabled = currentPage > 1;
                btnPrevious.BackColor = currentPage > 1 
                    ? Color.FromArgb(52, 152, 219) 
                    : Color.FromArgb(200, 200, 200);
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

        /// <summary>
        /// Tạo panel hiển thị thông tin đề thi với các nút Xem, Sửa, Xóa
        /// </summary>
        private void CreateDeThiPanel(DeKiemTra deThi, int yPosition)
        {
            Panel deThiPanel = new Panel();
            deThiPanel.Name = $"panelDeThi_{deThi.maDe}";
            deThiPanel.Size = new Size(1400, 150);
            deThiPanel.Location = new Point(10, yPosition);
            deThiPanel.BackColor = Color.FromArgb(215, 229, 255);
            deThiPanel.BorderStyle = BorderStyle.FixedSingle;
            deThiPanel.Tag = deThi;

            Label lblTenDe = new Label();
            lblTenDe.Text = $"ĐỀ THI #{deThi.maDe} - {deThi.tenDe.ToUpper()}";
            lblTenDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTenDe.Location = new Point(15, 15);
            lblTenDe.Size = new Size(800, 30);
            lblTenDe.ForeColor = Color.FromArgb(51, 51, 51);

            string tenMonHoc = "";
            string maMonHoc = deThi.maMonHoc?.Trim() ?? "";
            
            if (!string.IsNullOrEmpty(maMonHoc) && dictMonHoc != null && dictMonHoc.ContainsKey(maMonHoc))
            {
                tenMonHoc = dictMonHoc[maMonHoc];
            }
            
            if (string.IsNullOrEmpty(tenMonHoc) && !string.IsNullOrEmpty(maMonHoc))
            {
                try
                {
                    MonHoc monHoc = monHocDAO.GetMonHocByID(maMonHoc);
                    if (monHoc != null && !string.IsNullOrEmpty(monHoc.tenMonHoc))
                    {
                        tenMonHoc = monHoc.tenMonHoc;
                        dictMonHoc[maMonHoc] = tenMonHoc;
                    }
                }
                catch (Exception ex)
                {
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

            deThiPanel.Controls.Add(lblTenDe);
            deThiPanel.Controls.Add(lblMonHoc);
            deThiPanel.Controls.Add(lblThoiGian);
            deThiPanel.Controls.Add(lblTrangThai);
            deThiPanel.Controls.Add(btnXem);
            deThiPanel.Controls.Add(btnSua);
            deThiPanel.Controls.Add(btnXoa);

            panelKiemTra.Controls.Add(deThiPanel);
        }

        private void ClearAllDeThiPanels()
        {
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

        /// <summary>
        /// Xóa đề thi sau khi xác nhận từ người dùng
        /// Hiển thị hộp thoại xác nhận trước khi xóa
        /// Sau khi xóa thành công sẽ reload lại danh sách đề thi
        /// </summary>
        /// <param name="deThi">Đề thi cần xóa</param>
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
                        LoadDeThiData();
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

        /// <summary>
        /// Hiển thị dialog xem chi tiết đề thi
        /// </summary>
        private void ShowXemChiTietDialog(DeKiemTra deThi)
        {
            try
            {
                Form dialogForm = new Form();
                dialogForm.Text = $"Chi tiết đề thi: {deThi.tenDe}";
                dialogForm.Size = new Size(1300, 800);
                dialogForm.StartPosition = FormStartPosition.CenterParent;
                dialogForm.FormBorderStyle = FormBorderStyle.Sizable;
                dialogForm.MaximizeBox = true;
                dialogForm.MinimizeBox = true;
                dialogForm.MinimumSize = new Size(1300, 800);

                XemChiTietDeThi xemChiTietDeThi = new XemChiTietDeThi();
                xemChiTietDeThi.Dock = DockStyle.Fill;
                xemChiTietDeThi.LoadDataByMaDe(deThi.maDe);

                dialogForm.Controls.Add(xemChiTietDeThi);
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

        private void Component_DeKiemTra_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Xử lý sự kiện click nút tạo đề kiểm tra mới
        /// Mở dialog tạo đề thi ở chế độ tạo mới
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
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

        private void combobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (isInitializing)
                    return;
                
                string selectedValue = combobox1.SelectedItem?.ToString() ?? "Tất cả";
                currentFilterStatus = selectedValue;
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc đề kiểm tra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchKeyword = textBoxTimKiem.Text.Trim();
                currentSearchKeyword = searchKeyword;
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Áp dụng bộ lọc trạng thái và tìm kiếm, sau đó hiển thị kết quả
        /// </summary>
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

                List<DeKiemTra> filteredList = new List<DeKiemTra>();
                DateTime now = DateTime.Now;

                switch (currentFilterStatus)
                {
                    case "Tất cả":
                        filteredList = danhSachDeThi.ToList();
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

                if (!string.IsNullOrWhiteSpace(currentSearchKeyword))
                {
                    filteredList = filteredList.Where(d => 
                        d.tenDe.ToLower().Contains(currentSearchKeyword.ToLower()) ||
                        d.maMonHoc.ToLower().Contains(currentSearchKeyword.ToLower())
                    ).ToList();
                }

                danhSachDeThiHienTai = filteredList;
                currentPage = 1;
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

        /// <summary>
        /// Hiển thị dialog tạo mới hoặc sửa đề thi
        /// Tạo form dialog với UserControl Dialog_TaoDeThi
        /// Đăng ký sự kiện DataChanged để reload dữ liệu sau khi có thay đổi
        /// </summary>
        /// <param name="isEditMode">true nếu là chế độ sửa, false nếu là chế độ tạo mới</param>
        /// <param name="deThiToEdit">Đề thi cần sửa (null nếu là tạo mới)</param>
        private void ShowCreateExamDialog(bool isEditMode, DTO.DeKiemTra deThiToEdit)
        {
            try
            {
                Form dialogForm = new Form();
                dialogForm.Text = isEditMode ? "Sửa Đề Thi" : "Tạo Đề Thi";
                dialogForm.FormBorderStyle = FormBorderStyle.Sizable;
                dialogForm.MaximizeBox = true;
                dialogForm.MinimizeBox = true;
                dialogForm.StartPosition = FormStartPosition.CenterParent;
                dialogForm.Size = new Size(1000, 800); 
                dialogForm.MinimumSize = new Size(1000, 800);
                
                Panel scrollPanel = new Panel();
                scrollPanel.Dock = DockStyle.Fill;
                scrollPanel.AutoScroll = true;
                scrollPanel.BorderStyle = BorderStyle.None;
                
                Dialog_TaoDeThi dialogTaoDeThi = new Dialog_TaoDeThi();
                dialogTaoDeThi.Location = new Point(0, 0);
                dialogTaoDeThi.Size = new Size(1000, 1270);
                
                dialogTaoDeThi.DataChanged += (sender, e) => {
                    LoadMonHocDictionary();
                    LoadDeThiData();
                };
                
                if (isEditMode && deThiToEdit != null)
                {
                    dialogTaoDeThi.SetEditMode(deThiToEdit);
                }
                else
                {
                    dialogTaoDeThi.SetCreateMode();
                }
                
                scrollPanel.Controls.Add(dialogTaoDeThi);
                dialogForm.Controls.Add(scrollPanel);
                dialogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dialog: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                LoadMonHocDictionary();
                LoadDeThiData();
                MessageBox.Show("Đã reload dữ liệu đề kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi reload dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                Form dialogForm = new Form();
                dialogForm.Text = "Xem Chi Tiết Đề Thi";
                dialogForm.FormBorderStyle = FormBorderStyle.Sizable;
                dialogForm.MaximizeBox = true;
                dialogForm.MinimizeBox = true;
                dialogForm.StartPosition = FormStartPosition.CenterParent;
                dialogForm.Size = new Size(1300, 800); 
                dialogForm.MinimumSize = new Size(1300, 800);
                
                XemChiTietDeThi xemChiTietDeThi = new XemChiTietDeThi();
                xemChiTietDeThi.Dock = DockStyle.Fill;
                dialogForm.Controls.Add(xemChiTietDeThi);
                dialogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết đề kiểm tra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút sửa đề kiểm tra
        /// Kiểm tra đề thi được chọn trong ListBox
        /// Mở dialog sửa đề thi ở chế độ edit với đề thi đã chọn
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxDeThi.SelectedIndex >= 0 && listBoxDeThi.SelectedIndex < danhSachDeThi.Count)
                {
                    var deThiToEdit = danhSachDeThi[listBoxDeThi.SelectedIndex];
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

        /// <summary>
        /// Xử lý sự kiện click nút xóa đề kiểm tra
        /// Kiểm tra đề thi được chọn trong ListBox
        /// Hiển thị hộp thoại xác nhận trước khi xóa
        /// Sau khi xóa thành công sẽ reload lại danh sách đề thi
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxDeThi.SelectedIndex >= 0 && listBoxDeThi.SelectedIndex < danhSachDeThi.Count)
                {
                    var deThiToDelete = danhSachDeThi[listBoxDeThi.SelectedIndex];
                    
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa đề thi '{deThiToDelete.tenDe}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        if (deKiemTraBUS.DeleteDeThi(deThiToDelete.maDe))
                        {
                            MessageBox.Show("Đã xóa đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        
        /// <summary>
        /// Xử lý sự kiện click nút chuyển trang trước
        /// Kiểm tra xem có thể chuyển trang trước không
        /// Nếu có thì giảm currentPage và hiển thị lại danh sách đề thi
        /// </summary>
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
        
        /// <summary>
        /// Xử lý sự kiện click nút chuyển trang tiếp
        /// Kiểm tra xem có thể chuyển trang tiếp không
        /// Nếu có thì tăng currentPage và hiển thị lại danh sách đề thi
        /// </summary>
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
        
        /// <summary>
        /// Xử lý sự kiện hover nút chuyển trang trước
        /// Thay đổi màu sắc nút khi hover
        /// </summary>
        private void btnPrevious_MouseEnter(object sender, EventArgs e)
        {
            if (btnPrevious.Enabled)
            {
                btnPrevious.BackColor = Color.FromArgb(41, 128, 185);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện hover rời nút chuyển trang trước
        /// Thay đổi màu sắc nút khi hover rời
        /// </summary>
        private void btnPrevious_MouseLeave(object sender, EventArgs e)
        {
            if (btnPrevious.Enabled)
            {
                btnPrevious.BackColor = Color.FromArgb(52, 152, 219);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện hover nút chuyển trang tiếp
        /// Thay đổi màu sắc nút khi hover
        /// </summary>
        private void btnNext_MouseEnter(object sender, EventArgs e)
        {
            if (btnNext.Enabled)
            {
                btnNext.BackColor = Color.FromArgb(41, 128, 185);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện hover rời nút chuyển trang tiếp
        /// Thay đổi màu sắc nút khi hover rời
        /// </summary>
        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            if (btnNext.Enabled)
            {
                btnNext.BackColor = Color.FromArgb(52, 152, 219);
            }
        }
    }
}

