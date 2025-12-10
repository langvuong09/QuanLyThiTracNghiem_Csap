using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
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
        private CTNhomQuyenBUS nqBUS = new CTNhomQuyenBUS();
        private System.Windows.Forms.Timer searchTimer;
        private object currentSelectedItem = null;


        public Component_PhanCong()
        {
            InitializeComponent();
            CheckPhanQuyen();
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


            AddDeleteButtonColumn();
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

        private void AddDeleteButtonColumn()
        {
            // Nếu đã có cột thì không thêm nữa
            if (!dataGridView_DSPC.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "btnDelete";
                btnDelete.HeaderText = "";
                btnDelete.Text = "Xóa";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.Width = 70; 
                btnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dataGridView_DSPC.Columns.Add(btnDelete);
            }
        }

        private void dataGridView_DSPC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView_DSPC.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                e.CellStyle.ForeColor = Color.Red;
            }
        }


        private void dataGridView_DSPC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 )
                return;

            if (dataGridView_DSPC.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                var row = dataGridView_DSPC.Rows[e.RowIndex];
                var item = row.DataBoundItem;
                if (item == null) return;

                lockcontrols();
                currentSelectedItem = item;
                panel_PhanCong.Visible = true;
                LoadPhanCong(item);
                button_HanhDong.Text = "Xác nhận xóa";
                button_HanhDong.ForeColor = Color.Red;
            }
            else
            {
                var row = dataGridView_DSPC.Rows[e.RowIndex];
                var item = row.DataBoundItem;
                if (item == null) return;

                lockcontrols();
                currentSelectedItem = item;
                panel_PhanCong.Visible = true;
                LoadPhanCong(item);
                button_HanhDong.Text = "Sửa";
            }
        }

        private void LoadPhanCong(object item)
        {
            if (item == null) return;
            else if (item is PhanCongView pc)
            {
                textBox_MaPC.Text = pc.MaPC;

                loadGiaoVien();
                LoadMonHoc();

                comboBox_GiaoVien.SelectedValue = pc.MaGV ?? "";
                comboBox_MonHoc.SelectedValue = pc.MaMon ?? "";
            }
        }

        private void lockcontrols()
        {
            dataGridView_DSPC.Enabled = false;
            textBoxTimKiem.Enabled = false;
            button_ThemPC.Enabled = false;
        }

        private void unlockcontrols()
        {
            dataGridView_DSPC.Enabled = true;
            textBoxTimKiem.Enabled = true;
            button_ThemPC.Enabled = true;
        }

        private void khoathongtin()
        {
            textBox_MaPC.Enabled = false;
            comboBox_GiaoVien.Enabled = false;
            comboBox_MonHoc.Enabled = false;
        }

        private void mothongtin()
        {
            textBox_MaPC.Enabled = true;
            comboBox_GiaoVien.Enabled = true;
            comboBox_MonHoc.Enabled = true;
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
                    bs.DataSource = LoadData();
                }
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

        private void LoadMonHoc()
        {
            var listMH = mhBUS.GetAllMonHoc() ?? new List<MonHoc>();
            var listWithDefault = new List<MonHoc>();
            listWithDefault.Add(new MonHoc { maMonHoc = "", tenMonHoc = "-- Chọn môn --" });
            listWithDefault.AddRange(listMH);

            comboBox_MonHoc.DataSource = null;
            comboBox_MonHoc.DataSource = listWithDefault;
            comboBox_MonHoc.DisplayMember = "tenMonHoc";
            comboBox_MonHoc.ValueMember = "maMonHoc";
            comboBox_MonHoc.SelectedIndex = 0;
        }

        private void loadGiaoVien()
        {
            var listGV = gvBUS.GetAllGiaoVien() ?? new List<GiaoVien>();
            // chèn option chọn
            var listWithDefault = new List<GiaoVien>();
            listWithDefault.Add(new GiaoVien { maGiaoVien = "", tenGiaoVien = "-- Chọn giáo viên --" });
            listWithDefault.AddRange(listGV);

            comboBox_GiaoVien.DataSource = null;
            comboBox_GiaoVien.DataSource = listWithDefault;
            comboBox_GiaoVien.DisplayMember = "tenGiaoVien";
            comboBox_GiaoVien.ValueMember = "maGiaoVien";
            comboBox_GiaoVien.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            panel_PhanCong.Visible = false;
            khoathongtin();
            unlockcontrols();
        }

        private void button_ThemPC_Click(object sender, EventArgs e)
        {
            lockcontrols();
            mothongtin();
            panel_PhanCong.Visible = true;
            button_HanhDong.Text = "Thêm phân công";
            textBox_MaPC.Text = pcBUS.LayMaPhanCongTiepTheo().ToString();
            loadGiaoVien();
            LoadMonHoc();
        }

        private void button_HanhDong_Click(object sender, EventArgs e)
        {
            if (button_HanhDong.Text == "Xác nhận xóa")
            {
                if (pcBUS.XoaPhanCong(int.Parse(textBox_MaPC.Text)))
                {
                    panel_PhanCong.Visible = false;
                    bs.DataSource = LoadData();
                    bs.ResetBindings(false);
                    unlockcontrols();
                }
                else
                {
                    return;
                }

            }

            else if (button_HanhDong.Text == "Thêm phân công")
            {
                string maMH = comboBox_MonHoc.SelectedValue as string;
                string maGV = comboBox_GiaoVien.SelectedValue as string;

                if (pcBUS.ThemPhanCong(int.Parse(textBox_MaPC.Text), maMH, maGV))
                {
                    panel_PhanCong.Visible = false;
                    bs.DataSource = LoadData();
                    bs.ResetBindings(false);
                    unlockcontrols();
                }
                else
                {
                    return;
                }
            }

            else if (button_HanhDong.Text == "Sửa")
            {
                mothongtin();
                textBox_MaPC.Enabled = false;
                button_HanhDong.Text = "Lưu";
            }

            else if (button_HanhDong.Text == "Lưu")
            {
                string maMH = comboBox_MonHoc.SelectedValue as string;
                string maGV = comboBox_GiaoVien.SelectedValue as string;
                if (pcBUS.SuaPhanCong(int.Parse(textBox_MaPC.Text), maMH, maGV))
                {
                    panel_PhanCong.Visible = false;
                    bs.DataSource = LoadData();
                    bs.ResetBindings(false);
                    unlockcontrols();
                }
                else
                {
                    return;
                }
            }            
        }

        private void CheckPhanQuyen()
        {
            ArrayList dspq = nqBUS.GetListCTNhomQuyen(UserSession.Quyen);
            foreach(CTNhomQuyen pq in dspq)
            {
                if(pq.maChucNang == 6)
                {
                    if(pq.them == 0)
                    {
                        button_ThemPC.Visible = false;
                    }
                    if(pq.xoa == 0)
                    {
                        button_HanhDong.Visible = false;
                    }
                }
            }
        }
    }
}
