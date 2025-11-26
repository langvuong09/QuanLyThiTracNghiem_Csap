using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_PhanCong : UserControl
    {
        PhanCongBUS pcBUS = new PhanCongBUS();
        GiaoVienBUS gvBUS = new GiaoVienBUS();
        MonHocBUS mhBUS = new MonHocBUS();
        BindingSource bs = new BindingSource();
        private System.Windows.Forms.Timer searchTimer;



        public Component_PhanCong()
        {
            InitializeComponent();

            dataGridView_DSPC.AutoGenerateColumns = true;
            dataGridView_DSPC.DataSource = bs;

            if (searchTimer == null)
            {
                searchTimer = new System.Windows.Forms.Timer();
                searchTimer.Interval = 300; // ms
                searchTimer.Tick += SearchTimer_Tick;
            }
        }

        public void Component_PhanCong_Load(object sender, EventArgs e)
        {
            bs.DataSource = LoadData();

        }

        public class PhanCongView
        {
            public string MaPC { get; set; }
            public string MaMon { get; set; }
            public string TenMon { get; set; }
            public string MaGV { get; set; }
            public string TenGV { get; set; }
        }

        public List<PhanCongView> LoadData()
        {
            var listPC = pcBUS.GetAllPhanCong() ?? new List<PhanCong>();
            var listGV = gvBUS.GetAllGiaoVien() ?? new List<GiaoVien>();
            var listMH = mhBUS.GetAllMonHoc() ?? new List<MonHoc>();


            var listAll = (from pc in listPC
                            join mh in listMH on pc.maMonHoc equals mh.maMonHoc into mh_join
                            from mh in mh_join.DefaultIfEmpty()
                            join gv in listGV on pc.maGiaoVien equals gv.maGiaoVien into gv_join
                            from gv in gv_join.DefaultIfEmpty()
                            select new PhanCongView
                            {
                                MaPC = pc.maPhanCong.ToString(),
                                MaMon = pc.maMonHoc,
                                TenMon = mh?.tenMonHoc ?? "",
                                MaGV = pc.maGiaoVien,
                                TenGV = gv?.tenGiaoVien ?? ""
                            }).ToList();

            return listAll;
        }

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

            string[] preferProps = new[] { "maPhanCong", "maMonHoc", "tenMonHoc", "", "maGiaoVien", "tenGiaoVien" };

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
                    bs.DataSource = LoadData();            }
                else
                {
                    var all = LoadData();
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
