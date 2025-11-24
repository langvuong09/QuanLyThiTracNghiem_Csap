using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_NguoiDung : UserControl
    {
        private readonly SinhVienBUS svBUS = new SinhVienBUS();
        private readonly GiaoVienBUS gvBUS = new GiaoVienBUS();
        private readonly TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private readonly BindingSource bs = new BindingSource();
        private System.Windows.Forms.Timer searchTimer;

        private object currentSelectedItem = null;
        private string selectedImageFileName = null;
        private string IDaccount = null;
        private bool isEditing = false;

        private object currentSelectedAccount = null;


        public Component_NguoiDung()
        {
            InitializeComponent();

            // Dùng BindingSource để bind DataGridView ổn định
            dataGridView_DSGVSV.AutoGenerateColumns = true;
            dataGridView_DSGVSV.DataSource = bs;

            if (searchTimer == null)
            {
                searchTimer = new System.Windows.Forms.Timer();
                searchTimer.Interval = 300; // ms
                searchTimer.Tick += SearchTimer_Tick;
            }

            // Ẩn cột sau khi bind xong (DataBindingComplete gọi mỗi lần set DataSource)
            dataGridView_DSGVSV.DataBindingComplete += DataGridView_DSGVSV_DataBindingComplete;
        }

        private void Component_NguoiDung_Load(object sender, EventArgs e)
        {
            if (comboboxLoc.Items.Count > 0)
                comboboxLoc.SelectedIndex = 0;

            HienthiSV();
        }

        private void HienthiSV()
        {
            // Lấy danh sách từ BUS 
            var list = svBUS.GetAllSinhVien() ?? new List<SinhVien>();
            bs.DataSource = list;
            // Các cột sẽ được ẩn trong DataBindingComplete event
        }

        private void HienthiGV()
        {
            var list = gvBUS.GetAllGiaoVien() ?? new List<GiaoVien>();
            bs.DataSource = list;
            // ẩn cột trong DataBindingComplete
        }

        private void comboboxLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxLoc.SelectedIndex == 0)
                HienthiSV();
            else if (comboboxLoc.SelectedIndex == 1)
                HienthiGV();
        }

        // Tìm nhanh bằng cách so sánh tất cả property public (case-insensitive)
        private static string NormalizeForSearch(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            s = s.Trim().ToLowerInvariant();

            // Chuyển 'đ' trước (nếu có)
            s = s.Replace('đ', 'd').Replace('Đ', 'D');

            // Loại dấu bằng chuẩn hoá FormD và bỏ NonSpacingMark
            string formD = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in formD)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            string cleaned = sb.ToString().Normalize(NormalizationForm.FormC);

            // loại bỏ ký tự thừa (nhiều khoảng trắng)
            cleaned = System.Text.RegularExpressions.Regex.Replace(cleaned, @"\s+", " ").Trim();

            return cleaned;
        }

        // Tìm nhanh bằng cách so sánh tất cả property public (sử dụng chuỗi đã chuẩn hoá)
        // Lưu ý: keyword đã được chuẩn hoá trước khi truyền vào
        private bool MatchesKeyword(object obj, string normalizedKeyword)
        {
            if (obj == null || string.IsNullOrEmpty(normalizedKeyword)) return false;

            var type = obj.GetType();

            string[] preferProps = new[] { "maSinhVien", "maGiaoVien", "Id", "IdSinhVien", "maGV", "ma", "hoVaTen", "ten", "Name", "email", "soDienThoai" };

            foreach (var pName in preferProps)
            {
                var p = type.GetProperty(pName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (p != null)
                {
                    try
                    {
                        var rawVal = p.GetValue(obj)?.ToString() ?? string.Empty;
                        var normVal = NormalizeForSearch(rawVal);
                        if (normVal.Contains(normalizedKeyword)) return true;
                    }
                    catch { }
                }
            }

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                try
                {
                    var val = prop.GetValue(obj);
                    if (val == null) continue;
                    var s = val.ToString();
                    if (string.IsNullOrEmpty(s)) continue;

                    var norm = NormalizeForSearch(s);
                    if (norm.Contains(normalizedKeyword))
                        return true;
                }
                catch { }
            }
            return false;
        }

        // Sau mỗi lần binding hoàn tất, ẩn cột nếu có
        private void DataGridView_DSGVSV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // ẩn cột "anhDaiDien" nếu có
            if (dataGridView_DSGVSV.Columns.Contains("anhDaiDien"))
            {
                dataGridView_DSGVSV.Columns["anhDaiDien"].Visible = false;
            }

            // ẩn cột "quyen" nếu có (cả SV & GV)
            if (dataGridView_DSGVSV.Columns.Contains("quyen"))
            {
                dataGridView_DSGVSV.Columns["quyen"].Visible = false;
            }
        }

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            // restart debounce timer mỗi khi gõ
            if (searchTimer.Enabled)
                searchTimer.Stop();
            searchTimer.Start();
        }

        // Timer tick => gọi tìm và dừng timer
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            PerformSearch();
        }


        private void textBoxTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                // MessageBox.Show("Enter pressed");
                if (searchTimer.Enabled) searchTimer.Stop();
                PerformSearch();
            }
        }

        private void PerformSearch()
        {
            try
            {
                string keyword = textBoxTimKiem.Text?.Trim() ?? string.Empty;
                keyword = NormalizeForSearch(keyword);

                if (string.IsNullOrEmpty(keyword))
                {
                    if (comboboxLoc.SelectedIndex == 0) HienthiSV();
                    else if (comboboxLoc.SelectedIndex == 1) HienthiGV();
                    return;
                }

                if (comboboxLoc.SelectedIndex == 0)
                {
                    var all = svBUS.GetAllSinhVien() ?? new List<SinhVien>();
                    var result = all.Where(s => MatchesKeyword(s, keyword)).ToList();
                    bs.DataSource = result;
                    bs.ResetBindings(false);
                }
                else if (comboboxLoc.SelectedIndex == 1)
                {
                    var all = gvBUS.GetAllGiaoVien() ?? new List<GiaoVien>();
                    var result = all.Where(g => MatchesKeyword(g, keyword)).ToList();
                    bs.DataSource = result;
                    bs.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void lockControls()
        {
            dataGridView_DSGVSV.Enabled = false;
            textBoxTimKiem.Enabled = false;
            comboboxLoc.Enabled = false;
        }

        private void unlockControls()
        {
            dataGridView_DSGVSV.Enabled = true;
            textBoxTimKiem.Enabled = true;
            comboboxLoc.Enabled = true;
        }





        private void dataGridView_DSGVSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView_DSGVSV.Rows.Count)
                return;

            var row = dataGridView_DSGVSV.Rows[e.RowIndex];
            var item = row.DataBoundItem;
            if (item == null) return;

            currentSelectedItem = item;
            panelThongTin.Visible = true;
            lockControls();
            KhoaThongTin();
            LoadSelectedUser(item);
        }


        private void LoadSelectedUser(object obj)
        {
            if (obj == null) return;

            string tenHinh = null;
            string ngaySinhStr = string.Empty;

            if (obj is SinhVien sv)
            {
                textBoxMa.Text = sv.maSinhVien ?? string.Empty;
                textBoxHoTen.Text = sv.hoVaTen ?? string.Empty;
                textBoxEmail.Text = sv.email ?? string.Empty;
                comboBoxGT.Text = sv.gioiTinh ?? string.Empty;
                IDaccount = sv.maSinhVien;

                // xử lý ngày nếu nullable
                if (sv.ngaySinh is DateTime dsv)
                    ngaySinhStr = dsv.ToString("dd/MM/yyyy");
                else
                    ngaySinhStr = string.Empty;

                tenHinh = sv.anhDaiDien;
                checkTrangThai();
            }
            else if (obj is GiaoVien gv)
            {
                textBoxMa.Text = gv.maGiaoVien ?? string.Empty;
                textBoxHoTen.Text = gv.tenGiaoVien ?? string.Empty;
                textBoxEmail.Text = gv.email ?? string.Empty;
                comboBoxGT.Text = gv.gioiTinh ?? string.Empty;
                IDaccount = gv.maGiaoVien;

                if (gv.ngaySinh is DateTime dgv)
                    ngaySinhStr = dgv.ToString("dd/MM/yyyy");
                else
                    ngaySinhStr = string.Empty;

                tenHinh = gv.anhDaiDien;
                checkTrangThai();
            }
            else
            {

                return;
            }

            textBoxNS.Text = ngaySinhStr;

            // load ảnh an toàn (copy vào Bitmap để không khoá file)
            if (!string.IsNullOrWhiteSpace(tenHinh))
            {
                try
                {
                    string duongDanAnh = Path.Combine(Application.StartupPath, "Image", tenHinh);
                    if (File.Exists(duongDanAnh))
                    {
                        // dispose ảnh cũ nếu có
                        if (pictureBoxAVT.Image != null)
                        {
                            var old = pictureBoxAVT.Image;
                            pictureBoxAVT.Image = null;
                            old.Dispose();
                        }

                        using (var fs = new FileStream(duongDanAnh, FileMode.Open, FileAccess.Read, FileShare.Read))
                        using (var img = Image.FromStream(fs))
                        {
                            // copy để tránh giữ stream/khóa file
                            var bmp = new Bitmap(img);
                            pictureBoxAVT.Image = bmp;
                        }
                    }
                    else
                    {
                        // file không tồn tại
                        if (pictureBoxAVT.Image != null)
                        {
                            var old = pictureBoxAVT.Image;
                            pictureBoxAVT.Image = null;
                            old.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // bắt lỗi hiển thị ảnh (ví dụ format lỗi). Log hoặc show nếu cần
                    Debug.WriteLine("Lỗi load ảnh: " + ex);
                    if (pictureBoxAVT.Image != null)
                    {
                        var old = pictureBoxAVT.Image;
                        pictureBoxAVT.Image = null;
                        old.Dispose();
                    }
                }
            }
            else
            {
                if (pictureBoxAVT.Image != null)
                {
                    var old = pictureBoxAVT.Image;
                    pictureBoxAVT.Image = null;
                    old.Dispose();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            unlockControls();
            panelThongTin.Visible = false;

        }

        private void KhoaThongTin()
        {
            textBoxMa.Enabled = false;
            textBoxHoTen.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxNS.Enabled = false;
            comboBoxGT.Enabled = false;

        }

        private void MoKhoaThongTin()
        {
            textBoxHoTen.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxNS.Enabled = true;
            comboBoxGT.Enabled = true;
            buttonThayAnh.Visible = true; // Hiện nút chọn ảnh
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isEditing)
                {
                    // bắt đầu chỉnh sửa
                    isEditing = true;
                    buttonSua.Text = "Lưu";
                    MoKhoaThongTin();
                    buttonThayAnh.Visible = true;
                    lockControls();
                }
                else
                {
                    // Lưu
                    // Basic validation
                    if (string.IsNullOrWhiteSpace(textBoxHoTen.Text))
                    {
                        MessageBox.Show("Họ và tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy ngày (nếu người dùng nhập)
                    DateTime? parsedDate = null;
                    if (!string.IsNullOrWhiteSpace(textBoxNS.Text))
                    {
                        if (DateTime.TryParseExact(textBoxNS.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime d))
                            parsedDate = d;
                        else
                        {
                            MessageBox.Show("Ngày sinh không đúng định dạng dd/MM/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }



                    // Nếu là SinhVien
                    if (currentSelectedItem is SinhVien sv)
                    {
                        string ma = sv.maSinhVien;
                        string ten = textBoxHoTen.Text.Trim();
                        string email = textBoxEmail.Text?.Trim() ?? string.Empty;
                        string gioiTinh = comboBoxGT.Text?.Trim() ?? string.Empty;
                        DateTime ngaySinh = parsedDate ?? (sv.ngaySinh is DateTime ds ? ds : DateTime.MinValue);
                        string anh = selectedImageFileName ?? sv.anhDaiDien ?? string.Empty;

                        // Gọi BUS.SuaSinhVien
                        bool ok = svBUS.SuaSinhVien(ma, ten, email, gioiTinh, ngaySinh, anh);


                        // refresh hiển thị
                        HienthiSV();
                    }
                    else if (currentSelectedItem is GiaoVien gv)
                    {
                        string ma = gv.maGiaoVien;
                        string ten = textBoxHoTen.Text.Trim();
                        string email = textBoxEmail.Text?.Trim() ?? string.Empty;
                        string gioiTinh = comboBoxGT.Text?.Trim() ?? string.Empty;
                        DateTime ngaySinh = parsedDate ?? (gv.ngaySinh is DateTime dg ? dg : DateTime.MinValue);
                        string anh = selectedImageFileName ?? gv.anhDaiDien ?? string.Empty;

                        // Gọi BUS.suaGiaoVien (theo BUS bạn đưa)
                        bool ok = gvBUS.SuaGiaoVien(ma, ten, email, gioiTinh, ngaySinh, anh);

                        HienthiGV();
                    }
                    else
                    {
                        MessageBox.Show("Đối tượng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // reset trạng thái edit
                    isEditing = false;
                    buttonSua.Text = "Sửa";
                    KhoaThongTin();
                    buttonThayAnh.Visible = false;
                    selectedImageFileName = null;
                    unlockControls();

                    // reselect item vừa lưu
                    TryReselectSavedItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TryReselectSavedItem()
        {
            try
            {
                if (currentSelectedItem == null) return;

                string key = null;
                string keyName = null;

                if (currentSelectedItem is SinhVien sv)
                {
                    key = sv.maSinhVien;
                    keyName = "maSinhVien";
                }
                else if (currentSelectedItem is GiaoVien gv)
                {
                    key = gv.maGiaoVien;
                    keyName = "maGiaoVien";
                }
                else return;

                if (string.IsNullOrEmpty(key)) return;

                // BindingSource có thể đang chứa List<SinhVien> hoặc List<GiaoVien>
                var list = bs.DataSource as System.Collections.IEnumerable;
                if (list == null) return;

                int idx = -1, i = 0;
                foreach (var it in list)
                {
                    if (it == null) { i++; continue; }
                    var type = it.GetType();
                    var prop = type.GetProperty(keyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    if (prop != null)
                    {
                        var val = prop.GetValue(it)?.ToString();
                        if (val == key)
                        {
                            idx = i;
                            break;
                        }
                    }
                    i++;
                }

                if (idx >= 0 && idx < dataGridView_DSGVSV.Rows.Count)
                {
                    dataGridView_DSGVSV.ClearSelection();
                    dataGridView_DSGVSV.Rows[idx].Selected = true;
                    dataGridView_DSGVSV.FirstDisplayedScrollingRowIndex = Math.Max(0, idx - 3);
                }
            }
            catch { }
        }

        private void buttonThayAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(ofd.FileName);
                    string destFolder = Path.Combine(Application.StartupPath, "Image");
                    Directory.CreateDirectory(destFolder);
                    string dest = Path.Combine(destFolder, fileName);

                    // copy file (ghi đè nếu cần)
                    File.Copy(ofd.FileName, dest, true);

                    // update pictureBox
                    if (pictureBoxAVT.Image != null)
                    {
                        var old = pictureBoxAVT.Image;
                        pictureBoxAVT.Image = null;
                        old.Dispose();
                    }
                    using (var fs = new FileStream(dest, FileMode.Open, FileAccess.Read, FileShare.Read))
                    using (var img = Image.FromStream(fs))
                    {
                        pictureBoxAVT.Image = new Bitmap(img);
                    }

                    selectedImageFileName = fileName;
                }
            }
        }

        private void buttonTrangThai_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = tkBUS.GetTaiKhoanById(IDaccount);
            if (buttonTrangThai.Text == "Khóa")
            {
                bool kq = tkBUS.khoaTaiKhoan(IDaccount);
                buttonTrangThai.Text = "Mở khóa";
            }
            else
            {
                bool kq = tkBUS.moTaiKhoan(IDaccount);
                buttonTrangThai.Text = "Khóa";
            }
        }

        private void checkTrangThai()
        {
            TaiKhoan tk = tkBUS.GetTaiKhoanById(IDaccount);
            if (tk.trangThai == 1)
            {
                buttonTrangThai.Text = "Khóa";
            }
            else
            {
                buttonTrangThai.Text = "Mở khóa";
            }
        }

    }   
}
