using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
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
        private readonly BindingSource bs = new BindingSource();
        private System.Windows.Forms.Timer searchTimer;

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
                    catch { /* ignore */ }
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
                catch
                {
                    // ignore property không đọc được
                }
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
    }
}
