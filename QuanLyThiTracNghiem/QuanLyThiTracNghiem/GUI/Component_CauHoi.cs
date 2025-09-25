using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_CauHoi : UserControl
    {
       
        public Component_CauHoi()
        {
            InitializeComponent();
            Custom_Component_CauHoi();
            Custom_HeaderDataGridView_DSCauHoi();
            LoadMonHoc(comboBox_MonHoc);
            LoadDoKho(comboBox_DoKho);
        }
        // ===========================================Custom Header DataGridView_DSCauHoi===========================================
        private void Custom_HeaderDataGridView_DSCauHoi()
        {
            //DATAGRIDVIEW_CAUHOI
            // Xóa hết cột cũ nếu cần
            dataGridView_DSCauHoi.Columns.Clear();
            //Bắt buộc để header nhận màu tùy chỉnh
            dataGridView_DSCauHoi.EnableHeadersVisualStyles = false;
            dataGridView_DSCauHoi.ScrollBars = ScrollBars.Both;

            //Header (tiêu đề cột)
            dataGridView_DSCauHoi.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#9BBCFF");
            dataGridView_DSCauHoi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_DSCauHoi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            dataGridView_DSCauHoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_DSCauHoi.ColumnHeadersHeight = 70;

            //Thêm các cột vào DataGridView
            dataGridView_DSCauHoi.Columns.Add("MaCauHoi", "Mã Câu Hỏi");
            dataGridView_DSCauHoi.Columns.Add("NoiDung", "Nội Dung");
            dataGridView_DSCauHoi.Columns.Add("MonHoc", "Môn Học");
            dataGridView_DSCauHoi.Columns.Add("DoKho", "Độ Khó");

            //Tùy chỉnh độ rộng cột
            dataGridView_DSCauHoi.Columns["MaCauHoi"].Width = 200;
            dataGridView_DSCauHoi.Columns["NoiDung"].Width = 900;
            dataGridView_DSCauHoi.Columns["MonHoc"].Width = 300;
            dataGridView_DSCauHoi.Columns["DoKho"].Width = 150;

            //Custom dòng dữ liệu
            dataGridView_DSCauHoi.DefaultCellStyle.Font = new Font("Segoe UI", 13);
            dataGridView_DSCauHoi.DefaultCellStyle.BackColor = Color.White;
            dataGridView_DSCauHoi.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView_DSCauHoi.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#9CC7FF");
            dataGridView_DSCauHoi.RowTemplate.Height = 150; // Chiều cao dòng


            // Chỉ cho phép 2 cột dài được wrap
            dataGridView_DSCauHoi.Columns["NoiDung"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView_DSCauHoi.Columns["MonHoc"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            //Dữ liệu tạm để dỡ trống
            var ds = new List<string[]>
            {
                new [] { "C01", "ạn có thể tạo sẵn một List<CauHoi> hoặc danh sách các object (hay đơn giản chỉ là mảng string) để truyền vào DataGridView ngay khi form load, như vậy DataGridView sẽ không bị trống.fcgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggghhhhhhhhhhhhhhhh", "Toán", "Dễ" },
                new [] { "C02", "ạn có thể tạo sẵn một List<CauHoi> hoặc danh sách các object (hay đơn giản chỉ là mảng string) để truyền vào DataGridView ngay khi form load, như vậy DataGridView sẽ không bị trống.", "Vật Lý", "Khó" },
                new [] { "C03", "ạn có thể tạo sẵn một List<CauHoi> hoặc danh sách các object (hay đơn giản chỉ là mảng string) để truyền vào DataGridView ngay khi form load, như vậy DataGridView sẽ không bị trống.", "Sinh", "Trung Bình" }
            };

            foreach (var item in ds)
            {
                dataGridView_DSCauHoi.Rows.Add(item);
            }

            // Sau khi đổ dữ liệu
            dataGridView_DSCauHoi.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        // ===========================================Custom Component_CauHoi===========================================
        private void Custom_Component_CauHoi()
        {
            //PANEL LOC VA TIM KIEM
            panel_LocVaTimKiem.BackColor = System.Drawing.ColorTranslator.FromHtml("#E2ECFF");
            //BUTTON RELOAD
            button_Reload.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF9D9D");

            //BUTTON THÊM CÂU HỎI
            button_ThemCauHoi.BackColor = System.Drawing.ColorTranslator.FromHtml("#81BAEF");

            //BUTTON TÌM KIẾM
            button_TimKiem.BackColor = System.Drawing.ColorTranslator.FromHtml("#8383FC");

            //BUTTON SỬA
            button_Sua.BackColor = System.Drawing.ColorTranslator.FromHtml("#AAFECD");

            //BUTTON XÓA
            button_Xoa.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBABA");

            //BUTTON NEXT
            button_Next.BackColor = System.Drawing.ColorTranslator.FromHtml("#9CC7FF");

            //BUTTON PREV
            button_Prev.BackColor = System.Drawing.ColorTranslator.FromHtml("#9CC7FF");

            //COMBOBOX MÔN HỌC
            comboBox_MonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_MonHoc.Font = new Font("Segoe UI", 14);
            comboBox_MonHoc.ForeColor = Color.Black;
            comboBox_MonHoc.BackColor = Color.White;
            comboBox_MonHoc.FlatStyle = FlatStyle.Flat;
            comboBox_MonHoc.Width = 455;
            comboBox_MonHoc.Height = 50;

            //COMBOBOX ĐỘ KHÓ
            comboBox_DoKho.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_DoKho.Font = new Font("Segoe UI", 14);
            comboBox_DoKho.ForeColor = Color.Black;
            comboBox_DoKho.BackColor = Color.White;
            comboBox_DoKho.FlatStyle = FlatStyle.Flat;
            comboBox_DoKho.Width = 277;
            comboBox_DoKho.Height = 50;

            //COMBOBOX CHƯƠNG
            // Chỉ hiện đúng 1 mục "Chọn Chương"
            comboBox_Chuong.DataSource = null;
            comboBox_Chuong.Items.Clear();
            comboBox_Chuong.Items.Add("Chọn Chương");
            comboBox_Chuong.SelectedIndex = 0;


        }

        private void button_ThemCauHoi_Click(object sender, EventArgs e)
        {
            //Tạo câu hỏi mới
        }

        private void button_Reload_Click(object sender, EventArgs e)
        {
            //Reload lại danh sách câu hỏi
        }

        private void button_TimKiem_Click(object sender, EventArgs e)
        {
            //Tim kiếm câu hỏi
        }

        private void button_Xem_Click(object sender, EventArgs e)
        {
            //Xem chi tiết câu hỏi
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            //Sửa câu hỏi
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            //Xóa câu hỏi
        }

        private void button_Prev_Click(object sender, EventArgs e)
        {
            //Trang trước
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            //Trang sau
        }

        private void dataGridView_DSCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //------------------------------------Load Môn Học Vào ComboBox-----------------------------------
        private void LoadMonHoc(System.Windows.Forms.ComboBox combo, List<MonHoc> danhSachMoi = null)
        {
            //Dọn sạch dữ liệu cũ trước (rất quan trọng khi reload)
            combo.DataSource = null;
            combo.Items.Clear();

            //Nếu không truyền vào danh sách mới thì tự tạo mẫu
            List<MonHoc> dsMonHoc;
            if (danhSachMoi != null)
            {
                dsMonHoc = danhSachMoi;
            }
            else
            {
                // Data mẫu để đỡ trống
                dsMonHoc = new List<MonHoc>
                {
                    new MonHoc("MH001", "Lập trình C#",       3, 30, 15, 2),
                    new MonHoc("MH002", "Cơ sở dữ liệu",      3, 30, 15, 2),
                    new MonHoc("MH003", "Mạng máy tính",      4, 45, 20, 3),
                    new MonHoc("MH004", "Trí tuệ nhân tạo",   3, 30, 15, 3),
                    new MonHoc("MH005", "Phát triển Web",     3, 25, 20, 2)
                };

            }

            //Thêm mục giả
            dsMonHoc.Insert(0, new MonHoc("0", "Chọn Môn Học", 3, 30, 15, 2));

            //Gán lại DataSource
            combo.DataSource = dsMonHoc;
            combo.DisplayMember = "tenMonHoc";
            combo.ValueMember = "maMonHoc";

            //Chọn mục giả mặc định
            combo.SelectedIndex = 0;
        }

        //------------------------------------Load độ khó Vào ComboBox-----------------------------------
        private void LoadDoKho(System.Windows.Forms.ComboBox combo)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            var dsDoKho = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int,string>(0, "Chọn Độ Khó"),
                    new KeyValuePair<int,string>(1, "Dễ"),
                    new KeyValuePair<int,string>(2, "Trung Bình"),
                    new KeyValuePair<int,string>(3, "Khó")
                };

            combo.DataSource = dsDoKho;
            combo.DisplayMember = "Value"; 
            combo.ValueMember = "Key";   

            combo.SelectedIndex = 0;
        }

        private void comboBox_MonHoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Kiểm tra index
            if (comboBox_MonHoc.SelectedIndex <= 0)
            {
                return;
            }

            // Lấy object đang chọn
            var monHoc = comboBox_MonHoc.SelectedItem as MonHoc;
            if (monHoc == null) return;

            LoadChuong(comboBox_Chuong, monHoc.maMonHoc);
            // Thực hiện điều kiện cho các mục khác
            MessageBox.Show($"Bạn đã chọn: {monHoc.tenMonHoc} (Mã: {monHoc.maMonHoc})");
        }

        private void comboBox_DoKho_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_DoKho.SelectedIndex <= 0) return;

            var selectedPair = (KeyValuePair<int, string>)comboBox_DoKho.SelectedItem;
            int doKhoKey = selectedPair.Key;
            string doKhoText = selectedPair.Value;

            // Xử lý theo giá trị
            switch (doKhoKey)
            {
                case 1: MessageBox.Show("Bạn chọn Độ Khó: Dễ"); break;
                case 2: MessageBox.Show("Bạn chọn Độ Khó: Trung Bình"); break;
                case 3: MessageBox.Show("Bạn chọn Độ Khó: Khó"); break;
            }
        }

        //--------------------------Load chuong vào ComboBox (nếu cần)--------------------------
        private void LoadChuong(System.Windows.Forms.ComboBox combo, string maMonHoc)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            // Data mẫu
            var dsChuongAll = new List<Chuong>
            {
                    new Chuong(1,"MH001","Giới thiệu C#"),
                    new Chuong(2,"MH001","Lập trình hướng đối tượng"),
                    new Chuong(3,"MH002","Cơ sở dữ liệu SQL"),
                    new Chuong(4,"MH002","Tối ưu truy vấn"),
                    new Chuong(5,"MH003","Mạng căn bản")
            };

            // Lọc theo mã môn
            var dsChuongTheoMon = dsChuongAll
                                    .Where(c => c.maMonHoc == maMonHoc)
                                    .ToList();

            // Thêm mục giả
            dsChuongTheoMon.Insert(0, new Chuong(0,maMonHoc, "Chọn Chương"));

            combo.DataSource = dsChuongTheoMon;
            combo.DisplayMember = "tenChuong";
            combo.ValueMember = "maChuong";
            combo.SelectedIndex = 0;
        }

        private void comboBox_Chuong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
          
        }
    }
}
