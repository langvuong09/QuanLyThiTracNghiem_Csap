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

/*
 * File: Dialog_TaoDeThi.cs
 * Mô tả: UserControl để tạo mới hoặc chỉnh sửa đề thi
 * Chức năng:
 *   - Tạo đề thi mới với thông tin: tên đề, thời gian, môn học, số câu hỏi
 *   - Chỉnh sửa đề thi đã có
 *   - Quản lý chương của môn học được chọn
 *   - Tự động tính toán thời gian làm bài, thời gian kết thúc, thời gian cảnh báo
 * Dùng trong: Component_DeKiemTra
 */

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Dialog_TaoDeThi : UserControl
    {
        private bool isEditMode = false;
        private bool isInitializing = true;
        private DeKiemTra currentDeThi = null;
        private ChuongBUS chuongBUS = new ChuongBUS();
        private DeKiemTraBUS deThiBUS = new DeKiemTraBUS();
        private MonHocBUS monHocBUS = new MonHocBUS();
        private CauHoiBUS cauHoiBUS = new CauHoiBUS();
        private NhomBUS nhomBUS = new NhomBUS();
        private DeKiemTra_NhomBUS deKiemTra_NhomBUS = new DeKiemTra_NhomBUS();
        private CTDeKiemTraBUS ctDeKiemTraBUS = new CTDeKiemTraBUS();
        private Dictionary<int, CheckBox> checkBoxNhomDict = new Dictionary<int, CheckBox>();
        
        public event EventHandler DataChanged;

        public Dialog_TaoDeThi()
        {
            InitializeComponent();
            
            dateTimePickerBatDau.ValueChanged -= DateTimePickerBatDau_ValueChanged;
            
            SetupDataGridView();
            LoadMonHocData();
            LoadChuongData();
            
            // Ràng buộc nhập số nguyên cho các ô số câu
            textBoxSoCauDe.KeyPress += OnlyDigits_KeyPress;
            textBoxSoCauTB.KeyPress += OnlyDigits_KeyPress;
            textBoxSoCauKho.KeyPress += OnlyDigits_KeyPress;
            textBoxSoCauDe.TextChanged += IntegerTextBox_TextChanged;
            textBoxSoCauTB.TextChanged += IntegerTextBox_TextChanged;
            textBoxSoCauKho.TextChanged += IntegerTextBox_TextChanged;
            
            dateTimePickerBatDau.Value = DateTime.Now.AddMinutes(1);
            dateTimePickerBatDau.ValueChanged += DateTimePickerBatDau_ValueChanged;
            
            isInitializing = false;
            checkBoxTatCaNhom.CheckedChanged += CheckBoxTatCaNhom_CheckedChanged;
        }

        /// <summary>
        /// Thiết lập màu sắc, font và kích thước cho DataGridView
        /// </summary>
        private void SetupDataGridView()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(126, 164, 241);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            
            dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
        }
        
        /// <summary>
        /// Xử lý sự kiện khi trạng thái của cell được thay đổi
        /// Lưu lại thay đổi khi người dùng chọn/bỏ chọn checkbox
        /// </summary>
        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty && dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        
        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1) // Click vào header của cột checkbox
            {
                bool allChecked = true;
                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null || !(bool)row.Cells[0].Value)
                    {
                        allChecked = false;
                        break;
                    }
                }
                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = !allChecked;
                }
                
                dataGridView1.Refresh();
            }
        }

        private void LoadMonHocData()
        {
            try
            {
                List<MonHoc> monHocList = monHocBUS.GetAllMonHoc();
                comboBoxMonHoc.Items.Clear();
                
                MonHoc placeholderMonHoc = new MonHoc
                {
                    maMonHoc = "",
                    tenMonHoc = "Chọn học phần",
                    tinChi = 0,
                    soTietLyThuyet = 0,
                    soTietThucHanh = 0,
                    heSo = 0
                };
                comboBoxMonHoc.Items.Add(placeholderMonHoc);
                
                foreach (MonHoc monHoc in monHocList)
                {
                    comboBoxMonHoc.Items.Add(monHoc);
                }
                
                comboBoxMonHoc.DisplayMember = "tenMonHoc";
                comboBoxMonHoc.ValueMember = "maMonHoc";
                comboBoxMonHoc.SelectedIndex = 0;
                textboxMonhoc.Text = "";
                dataGridView1.Rows.Clear();
            }
            catch (Exception ex) { }
        }

        private void LoadChuongData()
        {
            try
            {
                if (comboBoxMonHoc.SelectedIndex == 0 || comboBoxMonHoc.SelectedItem == null)
                {
                    dataGridView1.Rows.Clear();
                    return;
                }
                
                if (comboBoxMonHoc.SelectedItem is MonHoc selectedMonHoc && string.IsNullOrEmpty(selectedMonHoc.maMonHoc))
                {
                    dataGridView1.Rows.Clear();
                    return;
                }
                
                string maMonHoc = "";
                if (comboBoxMonHoc.SelectedItem is MonHoc monHocSelected)
                {
                    maMonHoc = monHocSelected.maMonHoc ?? "";
                }
                
                if (string.IsNullOrEmpty(maMonHoc))
                {
                    maMonHoc = comboBoxMonHoc.SelectedValue?.ToString() ?? "";
                }
                
                if (!string.IsNullOrEmpty(maMonHoc))
                {
                    // Lấy danh sách chương đã chọn từ DataGridView (nếu đang edit thì lấy từ database)
                    List<int> selectedChuongIds = new List<int>();
                    if (isEditMode && currentDeThi != null)
                    {
                        // Load từ database khi đang ở chế độ edit
                        selectedChuongIds = ctDeKiemTraBUS.GetListMaChuongByMaDe(currentDeThi.maDe);
                    }
                    else
                    {
                        // Lấy từ DataGridView khi đang tạo mới
                        selectedChuongIds = GetSelectedChuongIds();
                    }
                    
                    dataGridView1.Rows.Clear();
                    List<Chuong> chuongList = chuongBUS.GetChuongByMonHoc(maMonHoc);

                    foreach (Chuong chuong in chuongList)
                    {
                        bool isSelected = selectedChuongIds.Contains(chuong.maChuong);
                        dataGridView1.Rows.Add(isSelected, chuong.maChuong, chuong.tenChuong);
                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                }
            }
            catch (Exception ex) { }
        }
        
        /// <summary>
        /// Lấy danh sách mã chương đã chọn trong DataGridView
        /// </summary>
        /// <returns>Danh sách mã chương đã chọn</returns>
        private List<int> GetSelectedChuongIds()
        {
            List<int> selectedIds = new List<int>();
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                    {
                        if (row.Cells[1].Value != null && int.TryParse(row.Cells[1].Value.ToString(), out int maChuong))
                        {
                            selectedIds.Add(maChuong);
                        }
                    }
                }
            }
            catch
            {
                // Bỏ qua lỗi
            }
            return selectedIds;
        }

        /// <summary>
        /// Thiết lập chế độ chỉnh sửa đề thi
        /// </summary>
        /// <param name="deThi">Đề thi cần chỉnh sửa</param>
        public void SetEditMode(DeKiemTra deThi)
        {
            isEditMode = true;
            currentDeThi = deThi;
            btnXoaND.Visible = true;
            btnXoaChuong.Visible = true;
            btnTaoDeThi.Text = "Cập Nhật Đề Thi";
            LoadDeThiData();
        }

        /// <summary>
        /// Thiết lập chế độ tạo mới đề thi
        /// </summary>
        public void SetCreateMode()
        {
            isEditMode = false;
            currentDeThi = null;
            btnXoaND.Visible = false;
            btnXoaChuong.Visible = false;
            btnTaoDeThi.Text = "Tạo Đề Thi";
            ClearForm();
        }

        /// <summary>
        /// Load dữ liệu đề thi vào form để chỉnh sửa
        /// </summary>
        private void LoadDeThiData()
        {
            if (currentDeThi != null)
            {
                dateTimePickerBatDau.ValueChanged -= DateTimePickerBatDau_ValueChanged;
                dateTimePickerKetThuc.ValueChanged -= DateTimePickerKetThuc_ValueChanged;
                
                textBoxTendethi.Text = currentDeThi.tenDe;
                dateTimePickerBatDau.Value = currentDeThi.thoiGianBatDau;
                dateTimePickerKetThuc.Value = currentDeThi.thoiGianKetThuc;

                TimeSpan thoiGianLamBai = currentDeThi.thoiGianKetThuc - currentDeThi.thoiGianBatDau;
                int totalMinutes = (int)thoiGianLamBai.TotalMinutes;
                int hours = totalMinutes / 60;
                int minutes = totalMinutes % 60;
                textBoxTimeLamBai.Text = $"{hours:D2}:{minutes:D2}";

                TimeSpan thoiGianCanhBao = currentDeThi.thoiGianKetThuc - currentDeThi.thoiGianCanhBao;
                int phutCanhBao = (int)thoiGianCanhBao.TotalMinutes;
                textBoxTimeCB.Text = phutCanhBao.ToString();

                // Load môn học đã chọn
                if (!string.IsNullOrEmpty(currentDeThi.maMonHoc))
                {
                    for (int i = 1; i < comboBoxMonHoc.Items.Count; i++)
                    {
                        if (comboBoxMonHoc.Items[i] is MonHoc monHoc && 
                            !string.IsNullOrEmpty(monHoc.maMonHoc) &&
                            monHoc.maMonHoc.Trim() == currentDeThi.maMonHoc.Trim())
                        {
                            comboBoxMonHoc.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    // Nếu không có maMonHoc, chọn item đầu tiên (placeholder)
                    comboBoxMonHoc.SelectedIndex = 0;
                }
                textBoxSoCauDe.Text = currentDeThi.soCauDe.ToString();
                textBoxSoCauTB.Text = currentDeThi.soCauTrungBinh.ToString();
                textBoxSoCauKho.Text = currentDeThi.soCauKho.ToString();
                
                dateTimePickerBatDau.ValueChanged += DateTimePickerBatDau_ValueChanged;
                dateTimePickerKetThuc.ValueChanged += DateTimePickerKetThuc_ValueChanged;
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi checkbox được chọn/bỏ chọn
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void labelTimeKetThuc_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        /// <summary>
        /// Xử lý sự kiện click nút tạo hoặc cập nhật đề thi
        /// Kiểm tra dữ liệu đầu vào, sau đó tạo mới hoặc cập nhật đề thi tùy theo chế độ
        /// </summary>
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

        /// <summary>
        /// Xử lý sự kiện click nút xóa nội dung đề thi
        /// Hiển thị hộp thoại xác nhận trước khi xóa
        /// </summary>
        private void btnXoaND_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nội dung đề thi này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút xóa chương đã chọn
        /// Xóa các chương được chọn trong DataGridView sau khi xác nhận
        /// </summary>
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

        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu đầu vào trước khi tạo/cập nhật đề thi
        /// </summary>
        /// <returns>true nếu dữ liệu hợp lệ, false nếu không</returns>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxTendethi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTendethi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxTimeLamBai.Text) || !IsValidTimeFormat(textBoxTimeLamBai.Text))
            {
                MessageBox.Show("Vui lòng nhập thời gian làm bài theo định dạng HH:MM (giờ:phút)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTimeLamBai.Focus();
                return false;
            }
            
            // Kiểm tra thời gian bắt đầu phải lớn hơn thời gian hiện tại (chỉ khi tạo mới)
            if (!isEditMode && dateTimePickerBatDau.Value <= DateTime.Now)
            {
                MessageBox.Show("Thời gian bắt đầu phải lớn hơn thời điểm hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerBatDau.Focus();
                return false;
            }
            
            if (dateTimePickerKetThuc.Value <= dateTimePickerBatDau.Value)
            {
                MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerKetThuc.Focus();
                return false;
            }

            if (comboBoxMonHoc.SelectedIndex == 0 || comboBoxMonHoc.SelectedItem == null || 
                !(comboBoxMonHoc.SelectedItem is MonHoc selectedMonHoc) || 
                string.IsNullOrEmpty(selectedMonHoc.maMonHoc))
            {
                MessageBox.Show("Vui lòng chọn học phần!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxMonHoc.Focus();
                return false;
            }

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

            try
            {
                int tongSoCau = soCauDe + soCauTB + soCauKho;
                string[] timeParts = textBoxTimeLamBai.Text.Split(':');
                int hours = int.Parse(timeParts[0]);
                int minutes = int.Parse(timeParts[1]);
                int tongPhut = hours * 60 + minutes;
                double minPhut = Math.Ceiling(0.8 * tongSoCau);
                
                if (tongPhut < minPhut)
                {
                    MessageBox.Show($"Thời gian làm bài quá ngắn.\nTối thiểu 0.8 phút/câu ⇒ tối thiểu {minPhut} phút cho {tongSoCau} câu.\nBạn có thể chọn thời gian dài hơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTimeLamBai.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Không thể tính được thời gian làm bài từ HH:MM.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTimeLamBai.Focus();
                return false;
            }

            bool hasSelectedChuong = false;
            List<int> selectedChuongIds = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                {
                    hasSelectedChuong = true;
                    if (row.Cells[1].Value != null && int.TryParse(row.Cells[1].Value.ToString(), out int maChuong))
                    {
                        selectedChuongIds.Add(maChuong);
                    }
                }
            }
            
            if (!hasSelectedChuong)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một chương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra số câu hỏi có đủ không
            if (!KiemTraSoCauHoi(selectedChuongIds, soCauDe, soCauTB, soCauKho))
            {
                return false;
            }

            // Kiểm tra có chọn ít nhất một nhóm
            List<int> selectedNhomIds = GetSelectedNhomIds();
            if (selectedNhomIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một nhóm học phần!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra số câu hỏi có đủ trong các chương đã chọn theo từng độ khó
        /// </summary>
        /// <param name="danhSachMaChuong">Danh sách mã chương đã chọn</param>
        /// <param name="soCauDe">Số câu dễ yêu cầu</param>
        /// <param name="soCauTB">Số câu trung bình yêu cầu</param>
        /// <param name="soCauKho">Số câu khó yêu cầu</param>
        /// <returns>true nếu đủ số câu hỏi, false nếu không đủ</returns>
        private bool KiemTraSoCauHoi(List<int> danhSachMaChuong, int soCauDe, int soCauTB, int soCauKho)
        {
            try
            {
                int soCauDeCo = cauHoiBUS.DemSoCauHoiTheoChuongVaDoKho(danhSachMaChuong, "Dễ");
                int soCauTBCo = cauHoiBUS.DemSoCauHoiTheoChuongVaDoKho(danhSachMaChuong, "Trung Bình");
                int soCauKhoCo = cauHoiBUS.DemSoCauHoiTheoChuongVaDoKho(danhSachMaChuong, "Khó");

                // Kiểm tra từng loại câu hỏi
                bool coLoi = false;
                string thongBaoLoi = "Số câu hỏi trong các chương đã chọn không đủ:\n\n";

                if (soCauDeCo < soCauDe)
                {
                    coLoi = true;
                    thongBaoLoi += $"• Câu dễ: Yêu cầu {soCauDe} câu, nhưng chỉ có {soCauDeCo} câu\n";
                }

                if (soCauTBCo < soCauTB)
                {
                    coLoi = true;
                    thongBaoLoi += $"• Câu trung bình: Yêu cầu {soCauTB} câu, nhưng chỉ có {soCauTBCo} câu\n";
                }

                if (soCauKhoCo < soCauKho)
                {
                    coLoi = true;
                    thongBaoLoi += $"• Câu khó: Yêu cầu {soCauKho} câu, nhưng chỉ có {soCauKhoCo} câu\n";
                }

                if (coLoi)
                {
                    thongBaoLoi += "\nVui lòng chọn thêm chương hoặc giảm số câu hỏi yêu cầu!";
                    MessageBox.Show(thongBaoLoi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra số câu hỏi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Tạo đề thi mới với thông tin từ form
        /// Lưu đề thi, chương và nhóm học phần vào database
        /// </summary>
        private void CreateDeThi()
        {
            DateTime thoiGianBatDau = dateTimePickerBatDau.Value;
            DateTime thoiGianKetThuc = dateTimePickerKetThuc.Value;
            DateTime thoiGianCanhBao = thoiGianKetThuc.AddMinutes(-15);
            
            if (!string.IsNullOrWhiteSpace(textBoxTimeCB.Text))
            {
                if (int.TryParse(textBoxTimeCB.Text, out int phutCanhBao) && phutCanhBao >= 0)
                {
                    thoiGianCanhBao = thoiGianKetThuc.AddMinutes(-phutCanhBao);
                }
            }

            // Lấy maMonHoc từ SelectedItem
            string maMonHoc = "";
            if (comboBoxMonHoc.SelectedItem is MonHoc selectedMonHoc)
            {
                maMonHoc = selectedMonHoc.maMonHoc ?? "";
            }
            
            // Fallback: nếu không lấy được từ SelectedItem, thử SelectedValue
            if (string.IsNullOrEmpty(maMonHoc))
            {
                maMonHoc = comboBoxMonHoc.SelectedValue?.ToString() ?? "";
            }

            // Kiểm tra maMonHoc không được rỗng
            if (string.IsNullOrEmpty(maMonHoc))
            {
                MessageBox.Show("Vui lòng chọn học phần!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxMonHoc.Focus();
                return;
            }

            DeKiemTra newDeThi = new DeKiemTra
            {
                tenDe = textBoxTendethi.Text,
                thoiGianBatDau = thoiGianBatDau,
                thoiGianKetThuc = thoiGianKetThuc,
                thoiGianCanhBao = thoiGianCanhBao,
                maMonHoc = maMonHoc,
                soCauDe = int.Parse(textBoxSoCauDe.Text),
                soCauTrungBinh = int.Parse(textBoxSoCauTB.Text),
                soCauKho = int.Parse(textBoxSoCauKho.Text),
                trangThai = checkBoxDeLuyenTap.Checked ? 0 : 1
            };

            if (deThiBUS.CreateDeThi(newDeThi))
            {
                int maDe = deThiBUS.GetMaxMaDe();
                
                List<int> selectedChuongIds = GetSelectedChuong();
                if (selectedChuongIds.Count > 0)
                {
                    try
                    {
                        if (!ctDeKiemTraBUS.SaveChuongForDeThi(maDe, maMonHoc, selectedChuongIds))
                        {
                            MessageBox.Show($"Tạo đề thi thành công nhưng có lỗi khi lưu chương!\nVui lòng kiểm tra Console để xem chi tiết lỗi.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lưu chương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                // Lưu danh sách nhóm đã chọn
                List<int> selectedNhomIds = GetSelectedNhomIds();
                if (selectedNhomIds.Count > 0)
                {
                    if (!deKiemTra_NhomBUS.SaveNhomForDeThi(maDe, selectedNhomIds))
                    {
                        MessageBox.Show("Tạo đề thi thành công nhưng có lỗi khi lưu nhóm học phần!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
                MessageBox.Show("Tạo đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo đề thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật đề thi đã có với thông tin từ form
        /// Cập nhật đề thi, chương và nhóm học phần trong database
        /// </summary>
        private void UpdateDeThi()
        {
            DateTime thoiGianBatDau = dateTimePickerBatDau.Value;
            DateTime thoiGianKetThuc = dateTimePickerKetThuc.Value;
            DateTime thoiGianCanhBao = thoiGianKetThuc.AddMinutes(-15);
            
            if (!string.IsNullOrWhiteSpace(textBoxTimeCB.Text))
            {
                if (int.TryParse(textBoxTimeCB.Text, out int phutCanhBao) && phutCanhBao >= 0)
                {
                    thoiGianCanhBao = thoiGianKetThuc.AddMinutes(-phutCanhBao);
                }
            }

            // Lấy maMonHoc từ SelectedItem
            string maMonHoc = "";
            if (comboBoxMonHoc.SelectedItem is MonHoc selectedMonHoc)
            {
                maMonHoc = selectedMonHoc.maMonHoc ?? "";
            }
            
            // Fallback: nếu không lấy được từ SelectedItem, thử SelectedValue
            if (string.IsNullOrEmpty(maMonHoc))
            {
                maMonHoc = comboBoxMonHoc.SelectedValue?.ToString() ?? "";
            }

            // Kiểm tra maMonHoc không được rỗng
            if (string.IsNullOrEmpty(maMonHoc))
            {
                MessageBox.Show("Vui lòng chọn học phần!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxMonHoc.Focus();
                return;
            }

            currentDeThi.tenDe = textBoxTendethi.Text;
            currentDeThi.thoiGianBatDau = thoiGianBatDau;
            currentDeThi.thoiGianKetThuc = thoiGianKetThuc;
            currentDeThi.thoiGianCanhBao = thoiGianCanhBao;
            currentDeThi.maMonHoc = maMonHoc;
            currentDeThi.soCauDe = int.Parse(textBoxSoCauDe.Text);
            currentDeThi.soCauTrungBinh = int.Parse(textBoxSoCauTB.Text);
            currentDeThi.soCauKho = int.Parse(textBoxSoCauKho.Text);
            currentDeThi.trangThai = checkBoxDeLuyenTap.Checked ? 0 : 1;

            if (deThiBUS.UpdateDeThi(currentDeThi))
            {
                List<int> selectedChuongIds = GetSelectedChuong();
                if (selectedChuongIds.Count > 0)
                {
                    if (!ctDeKiemTraBUS.SaveChuongForDeThi(currentDeThi.maDe, maMonHoc, selectedChuongIds))
                    {
                        MessageBox.Show("Cập nhật đề thi thành công nhưng có lỗi khi lưu chương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
                // Lưu danh sách nhóm đã chọn
                List<int> selectedNhomIds = GetSelectedNhomIds();
                if (!deKiemTra_NhomBUS.SaveNhomForDeThi(currentDeThi.maDe, selectedNhomIds))
                {
                    MessageBox.Show("Cập nhật đề thi thành công nhưng có lỗi khi lưu nhóm học phần!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Cập nhật đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Cập nhật đề thi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa tất cả dữ liệu trong form về trạng thái ban đầu
        /// </summary>
        private void ClearForm()
        {
            dateTimePickerBatDau.ValueChanged -= DateTimePickerBatDau_ValueChanged;
            dateTimePickerKetThuc.ValueChanged -= DateTimePickerKetThuc_ValueChanged;
            
            textBoxTendethi.Clear();
            dateTimePickerBatDau.Value = DateTime.Now.AddMinutes(1);
            dateTimePickerKetThuc.Value = DateTime.Now.AddHours(2);
            textBoxTimeLamBai.Text = "02:00";
            textBoxTimeCB.Text = "00";
            comboBoxMonHoc.SelectedIndex = 0;
            textBoxSoCauDe.Clear();
            textBoxSoCauTB.Clear();
            textBoxSoCauKho.Clear();
            checkBoxDeLuyenTap.Checked = false;
            dataGridView1.ClearSelection();
            ClearNhomCheckboxes();
            
            dateTimePickerBatDau.ValueChanged += DateTimePickerBatDau_ValueChanged;
            dateTimePickerKetThuc.ValueChanged += DateTimePickerKetThuc_ValueChanged;
        }

        private void Dialog_TaoDeThi_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e) { }

        private void textBoxTimeCB_TextChanged(object sender, EventArgs e) { }

        private void textBoxTimeLamBai_TextChanged(object sender, EventArgs e) { }
        
        /// <summary>
        /// Xử lý sự kiện khi nhấn Enter trong textBoxTimeLamBai
        /// Cập nhật thời gian kết thúc và thời gian cảnh báo từ thời gian làm bài
        /// </summary>
        private void textBoxTimeLamBai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessTimeLamBai();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        
        private void textBoxTimeLamBai_Leave(object sender, EventArgs e)
        {
            ProcessTimeLamBai();
        }
        
        private void ProcessTimeLamBai()
        {
            try
            {
                dateTimePickerKetThuc.ValueChanged -= DateTimePickerKetThuc_ValueChanged;
                
                if (IsValidTimeFormat(textBoxTimeLamBai.Text))
                {
                    UpdateKetThucTime();
                    UpdateCanhBaoTimeFromKetThuc();
                }
                
                dateTimePickerKetThuc.ValueChanged += DateTimePickerKetThuc_ValueChanged;
            }
            catch (Exception ex)
            {
                dateTimePickerKetThuc.ValueChanged += DateTimePickerKetThuc_ValueChanged;
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện khi thời gian bắt đầu được thay đổi
        /// Cập nhật thời gian làm bài và thời gian cảnh báo từ thời gian bắt đầu
        /// </summary>
        private void DateTimePickerBatDau_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isInitializing)
                {
                    return;
                }
                
                if (!isEditMode && dateTimePickerBatDau.Value <= DateTime.Now)
                {
                    MessageBox.Show("Thời gian bắt đầu phải lớn hơn thời điểm hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateTimePickerBatDau.Value = DateTime.Now.AddMinutes(1);
                    return;
                }
                
                textBoxTimeLamBai.TextChanged -= textBoxTimeLamBai_TextChanged;
                dateTimePickerKetThuc.ValueChanged -= DateTimePickerKetThuc_ValueChanged;
                
                if (IsValidTimeFormat(textBoxTimeLamBai.Text))
                {
                    UpdateKetThucTime();
                    UpdateCanhBaoTimeFromKetThuc();
                }
                else
                {
                    UpdateLamBaiTime();
                }
                
                textBoxTimeLamBai.TextChanged += textBoxTimeLamBai_TextChanged;
                dateTimePickerKetThuc.ValueChanged += DateTimePickerKetThuc_ValueChanged;
            }
            catch (Exception ex)
            {
                textBoxTimeLamBai.TextChanged += textBoxTimeLamBai_TextChanged;
                dateTimePickerKetThuc.ValueChanged += DateTimePickerKetThuc_ValueChanged;
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện khi thời gian kết thúc được thay đổi
        /// Cập nhật thời gian làm bài và thời gian cảnh báo từ thời gian kết thúc
        /// </summary>
        private void DateTimePickerKetThuc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxTimeLamBai.TextChanged -= textBoxTimeLamBai_TextChanged;
                UpdateLamBaiTime();
                UpdateCanhBaoTimeFromKetThuc();
                textBoxTimeLamBai.TextChanged += textBoxTimeLamBai_TextChanged;
            }
            catch (Exception ex)
            {
                textBoxTimeLamBai.TextChanged += textBoxTimeLamBai_TextChanged;
            }
        }

        /// <summary>
        /// Kiểm tra định dạng thời gian
        /// </summary>
        /// <param name="timeText">Chuỗi thời gian</param>
        /// <returns>true nếu định dạng hợp lệ, false nếu không</returns>
        private bool IsValidTimeFormat(string timeText)
        {
            if (string.IsNullOrEmpty(timeText)) return false;
            
            if (timeText.Length == 5 && timeText[2] == ':')
            {
                string[] parts = timeText.Split(':');
                if (parts.Length == 2)
                {
                    if (int.TryParse(parts[0], out int firstPart) && int.TryParse(parts[1], out int secondPart))
                    {
                        return firstPart >= 0 && firstPart <= 99 && secondPart >= 0 && secondPart <= 59;
                    }
                }
            }
            return false;
        }

        private void UpdateKetThucTime()
        {
            try
            {
                if (IsValidTimeFormat(textBoxTimeLamBai.Text))
                {
                    string[] parts = textBoxTimeLamBai.Text.Split(':');
                    int hours = int.Parse(parts[0]);
                    int minutes = int.Parse(parts[1]);
                    
                    int totalMinutes = hours * 60 + minutes;
                    
                    DateTime thoiGianBatDau = dateTimePickerBatDau.Value;
                    DateTime thoiGianKetThuc = thoiGianBatDau.AddMinutes(totalMinutes);
                    dateTimePickerKetThuc.Value = thoiGianKetThuc;
                }
            }
            catch (Exception ex) { }
        }
        
        private void UpdateLamBaiTime()
        {
            try
            {
                DateTime thoiGianBatDau = dateTimePickerBatDau.Value;
                DateTime thoiGianKetThuc = dateTimePickerKetThuc.Value;
                TimeSpan khoangThoiGian = thoiGianKetThuc - thoiGianBatDau;
                
                if (khoangThoiGian.TotalMinutes < 0)
                {
                    return;
                }
                
                int totalMinutes = (int)khoangThoiGian.TotalMinutes;
                int hours = totalMinutes / 60;
                int minutes = totalMinutes % 60;
                textBoxTimeLamBai.Text = $"{hours:D2}:{minutes:D2}";
            }
            catch (Exception ex) { }
        }
        
        /// <summary>
        /// Cập nhật thời gian cảnh báo từ thời gian kết thúc
        /// </summary>
        private void UpdateCanhBaoTimeFromKetThuc()
        {
            if (string.IsNullOrWhiteSpace(textBoxTimeCB.Text))
            {
                textBoxTimeCB.Text = "15";
            }
        }

        /// <summary>
        /// Lấy thời gian làm bài từ textBoxTimeLamBai
        /// </summary>
        /// <returns>Thời gian làm bài tính bằng phút</returns>
        private int GetLamBaiMinutes()
        {
            if (IsValidTimeFormat(textBoxTimeLamBai.Text))
            {
                string[] parts = textBoxTimeLamBai.Text.Split(':');
                return int.Parse(parts[0]) * 60 + int.Parse(parts[1]);
            }
            return 0;
        }

        /// <summary>
        /// Lấy danh sách mã chương đã chọn trong DataGridView
        /// </summary>
        /// <returns>Danh sách mã chương đã chọn</returns>
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

        /// <summary>
        /// Xử lý sự kiện khi chọn môn học trong comboBox
        /// Tải danh sách chương và nhóm học phần theo môn học đã chọn
        /// </summary>
        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxMonHoc.SelectedItem is MonHoc selectedMonHoc && string.IsNullOrEmpty(selectedMonHoc.maMonHoc))
                {
                    textboxMonhoc.Text = "";
                    dataGridView1.Rows.Clear();
                    ClearNhomCheckboxes();
                    return;
                }
                
                if (comboBoxMonHoc.SelectedItem is MonHoc monHoc && !string.IsNullOrEmpty(monHoc.maMonHoc))
                {
                    textboxMonhoc.Text = $"Môn học: {monHoc.tenMonHoc}\r\n" +
                                         $"Mã môn học: {monHoc.maMonHoc}\r\n" +
                                         $"Tín chỉ: {monHoc.tinChi}\r\n" +
                                         $"Lý thuyết: {monHoc.soTietLyThuyet} tiết\r\n" +
                                         $"Thực hành: {monHoc.soTietThucHanh} tiết";
                    LoadChuongData();
                    LoadNhomData(monHoc.maMonHoc);
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    textboxMonhoc.Text = "";
                    ClearNhomCheckboxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thay đổi môn học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn phím trong textBox
        /// Chỉ cho phép nhập số nguyên
        /// </summary>
        private void OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhập số nguyên trong textBox
        /// Chỉ cho phép nhập số nguyên
        /// </summary>
        private void IntegerTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                string digitsOnly = new string(tb.Text.Where(char.IsDigit).ToArray());
                if (tb.Text != digitsOnly)
                {
                    int selectionStart = tb.SelectionStart;
                    tb.Text = digitsOnly;
                    tb.SelectionStart = Math.Min(selectionStart, tb.Text.Length);
                }
            }
        }

        /// <summary>
        /// Load danh sách nhóm học phần theo mã môn học
        /// </summary>
        /// <param name="maMonHoc">Mã môn học</param>
        private void LoadNhomData(string maMonHoc)
        {
            try
            {
                ClearNhomCheckboxes();
                
                List<Nhom> danhSachNhom = nhomBUS.GetListNhomByMonHoc(maMonHoc);
                
                if (danhSachNhom == null || danhSachNhom.Count == 0)
                {
                    checkBoxTatCaNhom.Visible = false;
                    return;
                }
                
                checkBoxTatCaNhom.Visible = true;
                
                foreach (Nhom nhom in danhSachNhom)
                {
                    CheckBox checkBox = new CheckBox
                    {
                        Text = $"{nhom.tenNhom} ({nhom.namHoc}-HK{nhom.hocKy})",
                        Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0),
                        AutoSize = true,
                        Tag = nhom.maNhom
                    };
                    checkBox.CheckedChanged += CheckBoxNhom_CheckedChanged;
                    
                    checkBoxNhomDict[nhom.maNhom] = checkBox;
                    flowLayoutPanelNhom.Controls.Add(checkBox);
                }
                
                if (isEditMode && currentDeThi != null)
                {
                    LoadSelectedNhom();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load danh sách nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Xóa tất cả checkbox nhóm học phần
        /// </summary>
        private void ClearNhomCheckboxes()
        {
            checkBoxTatCaNhom.Checked = false;
            checkBoxTatCaNhom.Visible = false;
            flowLayoutPanelNhom.Controls.Clear();
            checkBoxNhomDict.Clear();
        }

        private void CheckBoxTatCaNhom_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxTatCaNhom.Checked;
            
            foreach (var checkBox in checkBoxNhomDict.Values)
            {
                checkBox.CheckedChanged -= CheckBoxNhom_CheckedChanged;
                checkBox.Checked = isChecked;
                checkBox.CheckedChanged += CheckBoxNhom_CheckedChanged;
            }
        }

        private void CheckBoxNhom_CheckedChanged(object sender, EventArgs e)
        {
            bool allChecked = checkBoxNhomDict.Values.Count > 0 && 
                             checkBoxNhomDict.Values.All(cb => cb.Checked);
            
            checkBoxTatCaNhom.CheckedChanged -= CheckBoxTatCaNhom_CheckedChanged;
            checkBoxTatCaNhom.Checked = allChecked;
            checkBoxTatCaNhom.CheckedChanged += CheckBoxTatCaNhom_CheckedChanged;
        }

        /// <summary>
        /// Lấy danh sách mã nhóm học phần đã được chọn
        /// </summary>
        /// <returns>Danh sách mã nhóm đã chọn</returns>
        private List<int> GetSelectedNhomIds()
        {
            List<int> selectedIds = new List<int>();
            foreach (var kvp in checkBoxNhomDict)
            {
                if (kvp.Value.Checked)
                {
                    selectedIds.Add(kvp.Key);
                }
            }
            return selectedIds;
        }

        /// <summary>
        /// Load danh sách nhóm học phần đã được chọn cho đề thi đang chỉnh sửa
        /// </summary>
        private void LoadSelectedNhom()
        {
            if (currentDeThi == null) return;
            
            try
            {
                List<int> selectedNhomIds = deKiemTra_NhomBUS.GetListMaNhomByMaDe(currentDeThi.maDe);
                
                foreach (var checkBox in checkBoxNhomDict.Values)
                {
                    checkBox.CheckedChanged -= CheckBoxNhom_CheckedChanged;
                }
                
                foreach (int maNhom in selectedNhomIds)
                {
                    if (checkBoxNhomDict.ContainsKey(maNhom))
                    {
                        checkBoxNhomDict[maNhom].Checked = true;
                    }
                }
                
                foreach (var checkBox in checkBoxNhomDict.Values)
                {
                    checkBox.CheckedChanged += CheckBoxNhom_CheckedChanged;
                }
                
                CheckBoxNhom_CheckedChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load nhóm đã chọn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
