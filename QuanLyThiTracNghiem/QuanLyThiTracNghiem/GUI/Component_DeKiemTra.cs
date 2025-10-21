using System;
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
        private List<DeKiemTra> danhSachDeThi = new List<DeKiemTra>();
        private bool isInitializing = false; // Flag để kiểm tra đang khởi tạo

        private void InitializeData()
        {
            // KHỞI TẠO DỮ LIỆU CHO COMBOBOX VÀ LOAD DỮ LIỆU ĐỀ THI
            try
            {
                isInitializing = true; // Đánh dấu đang khởi tạo
                
                // Khởi tạo ComboBox
                combobox1.Items.Clear();
                combobox1.Items.Add("Tất cả");
                combobox1.Items.Add("Đang mở");
                combobox1.Items.Add("Đã đóng");
                combobox1.Items.Add("Sắp diễn ra");
                combobox1.Items.Add("Đã kết thúc");
                combobox1.SelectedIndex = 0; // Chọn "Tất cả" mặc định
                
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

        // LOAD DỮ LIỆU ĐỀ THI TỪ DATABASE
        private void LoadDeThiData()
        {
            try
            {
                // Load tất cả đề thi từ database
                danhSachDeThi = deKiemTraBUS.GetListDeKiemTra();
                
                // Hiển thị dữ liệu lên giao diện
                DisplayDeThiData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu đề thi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HIỂN THỊ DỮ LIỆU ĐỀ THI LÊN GIAO DIỆN
        private void DisplayDeThiData()
        {
            try
            {
                if (danhSachDeThi != null && danhSachDeThi.Count > 0)
                {
                    // Xóa các panel cũ
                    ClearAllDeThiPanels();
                    
                    // Tạo panel cho từng đề thi
                    int yPosition = 10;
                    foreach (var deThi in danhSachDeThi)
                    {
                        CreateDeThiPanel(deThi, yPosition);
                        yPosition += 160; // Khoảng cách giữa các panel
                    }
                }
                else
                {
                    // Không có dữ liệu
                    ClearAllDeThiPanels();
                    labelkiemtra.Text = "CHƯA CÓ ĐỀ THI";
                    labelhocphan.Text = "Chưa có môn học";
                    labeltime.Text = "Chưa có thời gian";
                    labeltrangthaithuc.Text = "Không có dữ liệu";
                    labeltrangthaithuc.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TẠO PANEL CHO MỘT ĐỀ THI
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

            Label lblMonHoc = new Label();
            lblMonHoc.Text = $"Môn học: {deThi.maMonHoc}";
            lblMonHoc.Font = new Font("Segoe UI", 12F);
            lblMonHoc.Location = new Point(15, 50);
            lblMonHoc.Size = new Size(400, 25);

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

        // XÓA ĐỀ THI
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

        // XÁC ĐỊNH TRẠNG THÁI ĐỀ THI DỰA TRÊN THỜI GIAN
        private string GetTrangThaiDeThi(DeKiemTra deThi, DateTime now)
        {
            if (now < deThi.thoiGianBatDau)
            {
                return "[Sắp diễn ra]";
            }
            else if (now >= deThi.thoiGianBatDau && now <= deThi.thoiGianKetThuc)
            {
                return "[Đang mở]";
            }
            else
            {
                return "[Đã kết thúc]";
            }
        }

        private void Component_DeKiemTra_Load(object sender, EventArgs e)
        {

        }

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

        private void combobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LỌC ĐỀ KIỂM TRA THEO COMBOBOX
            try
            {
                // Bỏ qua nếu đang khởi tạo
                if (isInitializing)
                    return;
                
                string selectedValue = combobox1.SelectedItem?.ToString() ?? "Tất cả";
                
                // Lọc và hiển thị dữ liệu theo trạng thái
                FilterDeThiByStatus(selectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc đề kiểm tra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            // TÌM KIẾM ĐỀ KIỂM TRA THEO TỪ KHÓA
            try
            {
                string searchKeyword = textBoxTimKiem.Text.Trim();
                
                if (string.IsNullOrEmpty(searchKeyword))
                {
                    // Hiển thị tất cả đề kiểm tra khi không có từ khóa
                    DisplayDeThiData();
                    return;
                }
                
                // Tìm kiếm đề thi theo từ khóa
                SearchDeThi(searchKeyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LỌC ĐỀ THI THEO TRẠNG THÁI
        private void FilterDeThiByStatus(string status)
        {
            try
            {
                if (danhSachDeThi == null || danhSachDeThi.Count == 0)
                {
                    DisplayDeThiData();
                    return;
                }

                List<DeKiemTra> filteredList = new List<DeKiemTra>();
                DateTime now = DateTime.Now;

                switch (status)
                {
                    case "Tất cả":
                        filteredList = danhSachDeThi;
                        break;
                    case "Đang mở":
                        filteredList = danhSachDeThi.Where(d => now >= d.thoiGianBatDau && now <= d.thoiGianKetThuc).ToList();
                        break;
                    case "Đã đóng":
                        filteredList = danhSachDeThi.Where(d => now > d.thoiGianKetThuc).ToList();
                        break;
                    case "Sắp diễn ra":
                        filteredList = danhSachDeThi.Where(d => now < d.thoiGianBatDau).ToList();
                        break;
                    case "Đã kết thúc":
                        filteredList = danhSachDeThi.Where(d => now > d.thoiGianKetThuc).ToList();
                        break;
                    default:
                        filteredList = danhSachDeThi;
                        break;
                }

                // Hiển thị các panel đề thi đã lọc
                ClearAllDeThiPanels();
                int yPosition = 10;
                foreach (var deThi in filteredList)
                {
                    CreateDeThiPanel(deThi, yPosition);
                    yPosition += 160;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc đề thi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // TÌM KIẾM ĐỀ THI THEO TỪ KHÓA
        private void SearchDeThi(string keyword)
        {
            try
            {
                if (danhSachDeThi == null || danhSachDeThi.Count == 0)
                {
                    DisplayDeThiData();
                    return;
                }

                // Tìm kiếm theo tên đề thi hoặc mã môn học
                var searchResults = danhSachDeThi.Where(d => 
                    d.tenDe.ToLower().Contains(keyword.ToLower()) ||
                    d.maMonHoc.ToLower().Contains(keyword.ToLower())
                ).ToList();

                // Hiển thị các panel đề thi tìm được
                ClearAllDeThiPanels();
                int yPosition = 10;
                foreach (var deThi in searchResults)
                {
                    CreateDeThiPanel(deThi, yPosition);
                    yPosition += 160;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ShowCreateExamDialog(bool isEditMode, DTO.DeKiemTra deThiToEdit)
        {
            // HIỂN THỊ DIALOG TẠO/SỬA ĐỀ THI
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            // RELOAD DỮ LIỆU ĐỀ KIỂM TRA
            try
            {
                // Load lại dữ liệu từ database
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
            // XEM CHI TIẾT ĐỀ KIỂM TRA
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            // SỬA ĐỀ KIỂM TRA ĐÃ CHỌN
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // XÓA ĐỀ KIỂM TRA ĐÃ CHỌN
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
    }
}
