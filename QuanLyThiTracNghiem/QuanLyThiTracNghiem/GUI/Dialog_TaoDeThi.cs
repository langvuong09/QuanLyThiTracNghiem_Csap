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
    public partial class Dialog_TaoDeThi : UserControl
    {
        private bool isEditMode = false;
        private DeKiemTra currentDeThi = null;
        private ChuongBUS chuongBUS = new ChuongBUS();
        private DeKiemTraBUS deThiBUS = new DeKiemTraBUS();
        private MonHocBUS monHocBUS = new MonHocBUS();
        
        // EVENT ĐỂ THÔNG BÁO KHI CÓ THAY ĐỔI DỮ LIỆU
        public event EventHandler DataChanged;

        public Dialog_TaoDeThi()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadMonHocData();
            LoadChuongData();
        }

        private void SetupDataGridView()
        {
            // Thiết lập màu nền và font cho header
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(126, 164, 241);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Thiết lập font cho nội dung các cell
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.DefaultCellStyle.BackColor = Color.White; // Nền trắng cho tất cả hàng
        }

        // LOAD DỮ LIỆU MÔN HỌC VÀO COMBOBOX
        private void LoadMonHocData()
        {
            try
            {
                // Load dữ liệu môn học từ database
                List<MonHoc> monHocList = monHocBUS.GetAllMonHoc();
                
                // Clear và thêm dữ liệu vào ComboBox
                comboBoxMonHoc.Items.Clear();
                comboBoxMonHoc.DataSource = monHocList;
                comboBoxMonHoc.DisplayMember = "tenMonHoc";
                comboBoxMonHoc.ValueMember = "maMonHoc";
                
                // Set môn học đầu tiên làm mặc định
                if (monHocList.Count > 0)
                {
                    comboBoxMonHoc.SelectedIndex = 0;
                    
                    // Hiển thị thông tin môn học đầu tiên vào textBox1
                    MonHoc firstMonHoc = monHocList[0];
                    textBox1.Text = $"Môn học: {firstMonHoc.tenMonHoc}\nMã môn học: {firstMonHoc.maMonHoc}\nTín chỉ: {firstMonHoc.tinChi}\nLý thuyết: {firstMonHoc.soTietLyThuyet} tiết\nThực hành: {firstMonHoc.soTietThucHanh} tiết";
                }
            }
            catch (Exception ex)
            {
                // Không hiển thị MessageBox
            }
        }

        // LOAD DỮ LIỆU CHƯƠNG THEO MÔN HỌC ĐÃ CHỌN VÀO DATAGRIDVIEW
        private void LoadChuongData()
        {
            try
            {
                dataGridView1.Rows.Clear();
                
                // Lấy mã môn học từ comboBoxMonHoc
                string maMonHoc = comboBoxMonHoc.SelectedValue?.ToString() ?? "";
                
                if (!string.IsNullOrEmpty(maMonHoc))
                {
                    List<Chuong> chuongList = chuongBUS.GetChuongByMonHoc(maMonHoc);

                    // Load chương vào DataGridView
                    foreach (Chuong chuong in chuongList)
                    {
                        dataGridView1.Rows.Add(false, chuong.maChuong, chuong.tenChuong);
                    }
                }
                else
                {
                    // Nếu chưa chọn môn học, load tất cả chương
                    List<Chuong> chuongList = chuongBUS.GetAllChuong();

                    foreach (Chuong chuong in chuongList)
                    {
                        dataGridView1.Rows.Add(false, chuong.maChuong, chuong.tenChuong);
                    }
                }
            }
            catch (Exception ex)
            {
                // Không hiển thị MessageBox
            }
        }

        // Phương thức để thiết lập chế độ chỉnh sửa
        public void SetEditMode(DeKiemTra deThi)
        {
            isEditMode = true;
            currentDeThi = deThi;

            // Hiển thị các nút xóa
            btnXoaND.Visible = true;
            btnXoaChuong.Visible = true;

            // Thay đổi text nút chính
            btnTaoDeThi.Text = "Cập Nhật Đề Thi";

            // Điền dữ liệu vào form
            LoadDeThiData();
        }

        // Phương thức để thiết lập chế độ tạo mới
        public void SetCreateMode()
        {
            isEditMode = false;
            currentDeThi = null;

            // Ẩn các nút xóa
            btnXoaND.Visible = false;
            btnXoaChuong.Visible = false;

            // Thay đổi text nút chính
            btnTaoDeThi.Text = "Tạo Đề Thi";

            // Xóa dữ liệu form
            ClearForm();
        }

        private void LoadDeThiData()
        {
            if (currentDeThi != null)
            {
                textBoxTendethi.Text = currentDeThi.tenDe;
                dateTimePickerBatDau.Value = currentDeThi.thoiGianBatDau;
                dateTimePickerKetThuc.Value = currentDeThi.thoiGianKetThuc;

                // Tính thời gian làm bài từ thời gian bắt đầu và kết thúc
                TimeSpan thoiGianLamBai = currentDeThi.thoiGianKetThuc - currentDeThi.thoiGianBatDau;
                textBoxTimeLamBai.Text = $"{thoiGianLamBai.Minutes:D2}:{thoiGianLamBai.Seconds:D2}";

                // Tính thời gian cảnh báo từ thời gian kết thúc và cảnh báo
                TimeSpan thoiGianCanhBao = currentDeThi.thoiGianKetThuc - currentDeThi.thoiGianCanhBao;
                textBoxTimeCB.Text = $"{thoiGianCanhBao.Minutes:D2}:{thoiGianCanhBao.Seconds:D2}";

                // Set môn học trong ComboBox
                foreach (MonHoc monHoc in comboBoxMonHoc.Items)
                {
                    if (monHoc.maMonHoc == currentDeThi.maMonHoc)
                    {
                        comboBoxMonHoc.SelectedItem = monHoc;
                        break;
                    }
                }
                textBoxSoCauDe.Text = currentDeThi.soCauDe.ToString();
                textBoxSoCauTB.Text = currentDeThi.soCauTrungBinh.ToString();
                textBoxSoCauKho.Text = currentDeThi.soCauKho.ToString();

                // Note: DeKiemTra DTO không có field LoaiDe, có thể thêm logic khác
                // checkBoxDeLuyenTap.Checked = currentDeThi.LoaiDe == "Luyện tập";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào cell trong DataGridView
        }

        private void labelTimeKetThuc_Click(object sender, EventArgs e)
        {
            // XỬ LÝ CLICK VÀO LABEL THỜI GIAN KẾT THÚC
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Xử lý khi click vào label
        }

        // Sự kiện cho nút Tạo/Cập nhật đề thi
        private void btnTaoDeThi_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    if (isEditMode)
                    {
                        UpdateDeThi();
                    }
                    else
                    {
                        CreateDeThi();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện cho nút Xóa ND
        private void btnXoaND_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nội dung đề thi này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        // Sự kiện cho nút Xóa Chương
        private void btnXoaChuong_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa chương đã chọn?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chương cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Validate dữ liệu đầu vào
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxTendethi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTendethi.Focus();
                return false;
            }

            // Kiểm tra thời gian làm bài có định dạng hợp lệ
            if (string.IsNullOrWhiteSpace(textBoxTimeLamBai.Text) || !IsValidTimeFormat(textBoxTimeLamBai.Text))
            {
                MessageBox.Show("Vui lòng nhập thời gian làm bài theo định dạng MM:SS!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTimeLamBai.Focus();
                return false;
            }

            // Kiểm tra học phần
            if (comboBoxMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn học phần!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxMonHoc.Focus();
                return false;
            }

            // Kiểm tra số câu hỏi
            if (string.IsNullOrWhiteSpace(textBoxSoCauDe.Text) || !int.TryParse(textBoxSoCauDe.Text, out int soCauDe) || soCauDe <= 0)
            {
                MessageBox.Show("Vui lòng nhập số câu dễ hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSoCauDe.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxSoCauTB.Text) || !int.TryParse(textBoxSoCauTB.Text, out int soCauTB) || soCauTB <= 0)
            {
                MessageBox.Show("Vui lòng nhập số câu trung bình hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSoCauTB.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxSoCauKho.Text) || !int.TryParse(textBoxSoCauKho.Text, out int soCauKho) || soCauKho <= 0)
            {
                MessageBox.Show("Vui lòng nhập số câu khó hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSoCauKho.Focus();
                return false;
            }

            // Kiểm tra có chọn ít nhất một chương
            bool hasSelectedChuong = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                {
                    hasSelectedChuong = true;
                    break;
                }
            }
            
            if (!hasSelectedChuong)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một chương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Tạo đề thi mới
        private void CreateDeThi()
        {
            // Lấy thời gian bắt đầu và kết thúc từ DateTimePicker
            DateTime thoiGianBatDau = dateTimePickerBatDau.Value;
            DateTime thoiGianKetThuc = dateTimePickerKetThuc.Value;
            
            // Tính thời gian cảnh báo từ textbox MM:SS (nếu có)
            DateTime thoiGianCanhBao = thoiGianKetThuc.AddMinutes(-15); // Mặc định 15 phút
            if (!string.IsNullOrWhiteSpace(textBoxTimeCB.Text) && IsValidTimeFormat(textBoxTimeCB.Text))
            {
                string[] parts = textBoxTimeCB.Text.Split(':');
                int minutes = int.Parse(parts[0]);
                int seconds = int.Parse(parts[1]);
                thoiGianCanhBao = thoiGianKetThuc.AddMinutes(-minutes).AddSeconds(-seconds);
            }

            DeKiemTra newDeThi = new DeKiemTra
            {
                tenDe = textBoxTendethi.Text,
                thoiGianBatDau = thoiGianBatDau,
                thoiGianKetThuc = thoiGianKetThuc,
                thoiGianCanhBao = thoiGianCanhBao,
                maMonHoc = comboBoxMonHoc.SelectedValue?.ToString() ?? "",  // THÊM LẠI FIELD NÀY
                soCauDe = int.Parse(textBoxSoCauDe.Text),
                soCauTrungBinh = int.Parse(textBoxSoCauTB.Text),
                soCauKho = int.Parse(textBoxSoCauKho.Text),
                trangThai = 1 // 1 = hoạt động, 0 = đã xóa
            };

            if (deThiBUS.CreateDeThi(newDeThi))
            {
                MessageBox.Show("Tạo đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                
                // THÔNG BÁO CHO COMPONENT_DEKIEMTRA ĐỂ RELOAD DỮ LIỆU
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật đề thi
        private void UpdateDeThi()
        {
            // Lấy thời gian bắt đầu và kết thúc từ DateTimePicker
            DateTime thoiGianBatDau = dateTimePickerBatDau.Value;
            DateTime thoiGianKetThuc = dateTimePickerKetThuc.Value;

            // Tính thời gian cảnh báo từ textbox MM:SS (nếu có)
            DateTime thoiGianCanhBao = thoiGianKetThuc.AddMinutes(-15); // Mặc định 15 phút
            if (!string.IsNullOrWhiteSpace(textBoxTimeCB.Text) && IsValidTimeFormat(textBoxTimeCB.Text))
            {
                string[] parts = textBoxTimeCB.Text.Split(':');
                int minutes = int.Parse(parts[0]);
                int seconds = int.Parse(parts[1]);
                thoiGianCanhBao = thoiGianKetThuc.AddMinutes(-minutes).AddSeconds(-seconds);
            }

            currentDeThi.tenDe = textBoxTendethi.Text;
            currentDeThi.thoiGianBatDau = thoiGianBatDau;
            currentDeThi.thoiGianKetThuc = thoiGianKetThuc;
            currentDeThi.thoiGianCanhBao = thoiGianCanhBao;
            currentDeThi.maMonHoc = comboBoxMonHoc.SelectedValue?.ToString() ?? "";  // THÊM LẠI FIELD NÀY
            currentDeThi.soCauDe = int.Parse(textBoxSoCauDe.Text);
            currentDeThi.soCauTrungBinh = int.Parse(textBoxSoCauTB.Text);
            currentDeThi.soCauKho = int.Parse(textBoxSoCauKho.Text);

            if (deThiBUS.UpdateDeThi(currentDeThi))
            {
                MessageBox.Show("Cập nhật đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // THÔNG BÁO CHO COMPONENT_DEKIEMTRA ĐỂ RELOAD DỮ LIỆU
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Cập nhật đề thi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa form
        private void ClearForm()
        {
            textBoxTendethi.Clear();
            dateTimePickerBatDau.Value = DateTime.Now;
            dateTimePickerKetThuc.Value = DateTime.Now.AddHours(2); // Mặc định 2 giờ sau
            textBoxTimeLamBai.Text = "00:00";
            textBoxTimeCB.Text = "10:00"; // Mặc định cảnh báo 10 phút
            comboBoxMonHoc.SelectedIndex = -1;
            textBoxSoCauDe.Clear();
            textBoxSoCauTB.Clear();
            textBoxSoCauKho.Clear();
            checkBoxDeLuyenTap.Checked = false;
            dataGridView1.ClearSelection();
        }

        private void Dialog_TaoDeThi_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            // XỬ LÝ CLICK VÀO LABEL CẢNH BÁO
        }

        // XỬ LÝ SỰ KIỆN THAY ĐỔI THỜI GIAN CẢNH BÁO
        private void textBoxTimeCB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // KIỂM TRA ĐỊNH DẠNG MM:SS
                if (IsValidTimeFormat(textBoxTimeCB.Text))
                {
                    // Tính toán thời gian cảnh báo dựa trên thời gian kết thúc
                    UpdateCanhBaoTime();
                }
            }
            catch (Exception ex)
            {
                // Không hiển thị lỗi khi đang nhập
            }
        }

        // XỬ LÝ SỰ KIỆN THAY ĐỔI THỜI GIAN LÀM BÀI
        private void textBoxTimeLamBai_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // KIỂM TRA ĐỊNH DẠNG MM:SS
                if (IsValidTimeFormat(textBoxTimeLamBai.Text))
                {
                    // Tính toán thời gian kết thúc dựa trên thời gian bắt đầu và làm bài
                    UpdateKetThucTime();
                }
            }
            catch (Exception ex)
            {
                // Không hiển thị lỗi khi đang nhập
            }
        }

        // KIỂM TRA ĐỊNH DẠNG THỜI GIAN MM:SS
        private bool IsValidTimeFormat(string timeText)
        {
            if (string.IsNullOrEmpty(timeText)) return false;
            
            // Kiểm tra định dạng MM:SS
            if (timeText.Length == 5 && timeText[2] == ':')
            {
                string[] parts = timeText.Split(':');
                if (parts.Length == 2)
                {
                    if (int.TryParse(parts[0], out int minutes) && int.TryParse(parts[1], out int seconds))
                    {
                        return minutes >= 0 && minutes <= 59 && seconds >= 0 && seconds <= 59;
                    }
                }
            }
            return false;
        }

        // CẬP NHẬT THỜI GIAN CẢNH BÁO
        private void UpdateCanhBaoTime()
        {
            try
            {
                if (IsValidTimeFormat(textBoxTimeCB.Text))
                {
                    string[] parts = textBoxTimeCB.Text.Split(':');
                    int minutes = int.Parse(parts[0]);
                    int seconds = int.Parse(parts[1]);
                    
                    // Tính thời gian cảnh báo = thời gian kết thúc - thời gian cảnh báo
                    DateTime thoiGianKetThuc = dateTimePickerKetThuc.Value;
                    DateTime thoiGianCanhBao = thoiGianKetThuc.AddMinutes(-minutes).AddSeconds(-seconds);
                    
                    // Cập nhật thời gian bắt đầu để đảm bảo logic hợp lý
                    DateTime thoiGianBatDau = thoiGianCanhBao.AddMinutes(-GetLamBaiMinutes());
                    dateTimePickerBatDau.Value = thoiGianBatDau;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
            }
        }

        // CẬP NHẬT THỜI GIAN KẾT THÚC
        private void UpdateKetThucTime()
        {
            try
            {
                if (IsValidTimeFormat(textBoxTimeLamBai.Text))
                {
                    string[] parts = textBoxTimeLamBai.Text.Split(':');
                    int minutes = int.Parse(parts[0]);
                    int seconds = int.Parse(parts[1]);
                    
                    // Tính thời gian kết thúc = thời gian bắt đầu + thời gian làm bài
                    DateTime thoiGianBatDau = dateTimePickerBatDau.Value;
                    DateTime thoiGianKetThuc = thoiGianBatDau.AddMinutes(minutes).AddSeconds(seconds);
                    
                    dateTimePickerKetThuc.Value = thoiGianKetThuc;
                    
                    // Cập nhật thời gian cảnh báo nếu đã có
                    if (IsValidTimeFormat(textBoxTimeCB.Text))
                    {
                        UpdateCanhBaoTime();
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
            }
        }

        // LẤY SỐ PHÚT LÀM BÀI
        private int GetLamBaiMinutes()
        {
            if (IsValidTimeFormat(textBoxTimeLamBai.Text))
            {
                string[] parts = textBoxTimeLamBai.Text.Split(':');
                return int.Parse(parts[0]);
            }
            return 0;
        }

        // LẤY DANH SÁCH CHƯƠNG ĐÃ CHỌN
        private List<int> GetSelectedChuong()
        {
            List<int> selectedChuong = new List<int>();
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                {
                    int maChuong = int.Parse(row.Cells[1].Value.ToString());
                    selectedChuong.Add(maChuong);
                }
            }
            
            return selectedChuong;
        }

        // XỬ LÝ SỰ KIỆN THAY ĐỔI MÔN HỌC
        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hiển thị thông tin môn học đã chọn vào textBox1
            if (comboBoxMonHoc.SelectedItem != null)
            {
                MonHoc selectedMonHoc = (MonHoc)comboBoxMonHoc.SelectedItem;
                textBox1.Text = $"Môn học: {selectedMonHoc.tenMonHoc}\nMã môn học: {selectedMonHoc.maMonHoc}\nTín chỉ: {selectedMonHoc.tinChi}\nLý thuyết: {selectedMonHoc.soTietLyThuyet} tiết\nThực hành: {selectedMonHoc.soTietThucHanh} tiết";
            }
            
            // Khi thay đổi môn học, load lại danh sách chương
            LoadChuongData();
        }

    }
}
