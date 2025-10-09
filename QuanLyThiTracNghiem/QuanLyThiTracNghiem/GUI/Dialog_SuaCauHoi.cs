using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;


namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Dialog_SuaCauHoi : UserControl
    {
        private int is_EditButton;

        private MonHocBUS monHocBUS = new MonHocBUS();
        private ChuongBUS chuongBUS = new ChuongBUS();
        private CauHoiBUS cauHoiBUS = new CauHoiBUS();
        private DapAnBUS dapAnBUS = new DapAnBUS();

        private CauHoi cauHoi;


        public Dialog_SuaCauHoi(int is_EditButton, int maCauHoi)
        {
            InitializeComponent();
            this.is_EditButton = is_EditButton;
            CustomDialog_SuaCauHoi();
            CustomHeader_DataGridViewDSCauTraLoi();

            this.cauHoi = cauHoiBUS.LayCauHoiTheoMa(maCauHoi, textBox_MaCauHoi, textBox_NDCauHoi);
            LoadMonHoc(comboBox_MonHoc);
            LoadDoKho(comboBox_DoKho);
            LoadChuong(comboBox_Chuong, this.cauHoi.maMonHoc, this.cauHoi.maChuong);
            Load_DataGridViewCauTraLoi();


        }

        //=========================================Custom Dialog Sửa Câu Hỏi=========================================
        private void CustomDialog_SuaCauHoi()
        {
            //BUTTON SỬA CÂU HỎI
            button_SuaCauHoi.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");

            //BUTTON SỦA CÂU TRẢ LỜI
            button_SuaCauTraLoi.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");

            //TEXTBOX NỘI DUNG CÂU HỎI
            textBox_NDCauHoi.ScrollBars = ScrollBars.Vertical;
            textBox_NDCauHoi.WordWrap = true;

            //TEXTBOX NỘI DUNG CÂU TRẢ LỜI
            textBox_NDCauTraLoi.ScrollBars = ScrollBars.Vertical;
            textBox_NDCauTraLoi.WordWrap = true;

            if (this.is_EditButton == 0)
            {
                // Ẩn nút sửa
                button_SuaCauHoi.Visible = false;
                button_SuaCauTraLoi.Visible = false;

                // Vô hiệu hóa tất cả các trường nhập liệu
                textBox_MaCauHoi.ReadOnly = true;
                textBox_NDCauHoi.ReadOnly = true;
                textBox_MaCauTraLoi.ReadOnly = true;
                textBox_NDCauTraLoi.ReadOnly = true;

                // Vô hiệu hóa các combobox
                comboBox_DoKho.Enabled = false;
                comboBox_Chuong.Enabled = false;
                comboBox_MonHoc.Enabled = false;

                // Vô hiệu hóa radio button
                radioButton_Dung.Enabled = false;
                radioButton_Sai.Enabled = false;

                // Cho phép xem DataGridView nhưng không chỉnh sửa
                dataGridView_DSCauTraLoi.ReadOnly = true;
                dataGridView_DSCauTraLoi.AllowUserToAddRows = false;
                dataGridView_DSCauTraLoi.AllowUserToDeleteRows = false;
                dataGridView_DSCauTraLoi.AllowUserToResizeColumns = false;
                dataGridView_DSCauTraLoi.AllowUserToResizeRows = false;
            }

        }

        //========================================Custom Header DatagridView ==========================================
        private void CustomHeader_DataGridViewDSCauTraLoi()
        {
            // Xóa hết cột cũ nếu cần
            dataGridView_DSCauTraLoi.Columns.Clear();
            //Bắt buộc để header nhận màu tùy chỉnh
            dataGridView_DSCauTraLoi.EnableHeadersVisualStyles = false;
            dataGridView_DSCauTraLoi.ScrollBars = ScrollBars.Both;

            //Header (tiêu đề cột)
            dataGridView_DSCauTraLoi.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#9BBCFF");
            dataGridView_DSCauTraLoi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_DSCauTraLoi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            dataGridView_DSCauTraLoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_DSCauTraLoi.ColumnHeadersHeight = 50;

            //Thêm các cột vào DataGridView
            dataGridView_DSCauTraLoi.Columns.Add("MaCauTraLoi", "Mã Đáp Án");
            dataGridView_DSCauTraLoi.Columns.Add("NoiDung", "Nội Dung");
            dataGridView_DSCauTraLoi.Columns.Add("DungSai", "Đúng/Sai");

            //Custom dòng dữ liệu
            dataGridView_DSCauTraLoi.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridView_DSCauTraLoi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_DSCauTraLoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_DSCauTraLoi.DefaultCellStyle.BackColor = Color.White;
            dataGridView_DSCauTraLoi.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView_DSCauTraLoi.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#9CC7FF");
            dataGridView_DSCauTraLoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_DSCauTraLoi.MultiSelect = false;
            dataGridView_DSCauTraLoi.ReadOnly = true;

            //Tùy chỉnh độ rộng cột
            dataGridView_DSCauTraLoi.Columns["MaCauTraLoi"].Width = 200;
            dataGridView_DSCauTraLoi.Columns["NoiDung"].Width = 400;
            dataGridView_DSCauTraLoi.Columns["NoiDung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_DSCauTraLoi.Columns["DungSai"].Width = 150;

        }


        //===================Load Môn Học==========================
        private void LoadMonHoc(System.Windows.Forms.ComboBox combo)
        {
            //Load môn học từ BUS
            monHocBUS.LayListMonHoc(combo, this.cauHoi.maMonHoc);
        }
        //=======================Load Độ Khó======================
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

            for (int i = 0; i < dsDoKho.Count; i++)
            {
                if (dsDoKho[i].Value == this.cauHoi.doKho)
                {
                    combo.SelectedIndex = i;
                    break;
                }
            }


        }

        //====================Load Chương=======================
        private void LoadChuong(System.Windows.Forms.ComboBox combo, string maMonHoc = "0", int maChuong = 0)
        {
            combo.DataSource = null;
            combo.Items.Clear();
            chuongBUS.LayListChuong(combo, maMonHoc, maChuong);
        }

        private void Load_DataGridViewCauTraLoi()
        {
            dapAnBUS.LayDSDapAnTheoMaCauHoi(dataGridView_DSCauTraLoi, this.cauHoi.maCauHoi);
        }

        private void comboBox_MonHoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Nếu nhấn mục "Chọn Môn Học" thì load lại chương về 0
            if (comboBox_MonHoc.SelectedIndex <= 0)
            {
                LoadChuong(comboBox_Chuong, "0");
                return;
            }

            // Lấy object đang chọn
            var monHoc = comboBox_MonHoc.SelectedItem as MonHoc;
            if (monHoc == null) return;

            // Cập nhật ComboBox_Chuong
            LoadChuong(comboBox_Chuong, monHoc.maMonHoc);

        }



        private void comboBox_Chuong_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBox_DoKho_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void dataGridView_DSCauTraLoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy dòng hiện tại được chọn
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_DSCauTraLoi.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView_DSCauTraLoi.Rows[e.RowIndex];
                if (selectedRow == null) return;
                // Lấy dữ liệu từ dòng được chọn
                textBox_MaCauTraLoi.Text = selectedRow.Cells["MaCauTraLoi"].Value?.ToString() ?? "";
                textBox_NDCauTraLoi.Text = selectedRow.Cells["NoiDung"].Value?.ToString() ?? "";
                string dungSai = selectedRow.Cells["DungSai"].Value?.ToString() ?? "";
                // Cập nhật RadioButton dựa trên giá trị "Đúng/Sai"
                if (dungSai == "Đúng")
                {
                    radioButton_Dung.Checked = true;
                }
                else if (dungSai == "Sai")
                {
                    radioButton_Sai.Checked = true;
                }
                else
                {
                    radioButton_Dung.Checked = false;
                    radioButton_Sai.Checked = false;
                }
            }
        }

        private void button_SuaCauHoi_Click(object sender, EventArgs e)
        {
            cauHoiBUS.SuaCauHoi(textBox_MaCauHoi, textBox_NDCauHoi, comboBox_MonHoc, comboBox_Chuong, comboBox_DoKho);
        }

        private void button_SuaCauTraLoi_Click(object sender, EventArgs e)
        {
            dapAnBUS.SuaDapAnVaTaiLaiDataGridView(dataGridView_DSCauTraLoi, this.cauHoi.maCauHoi, textBox_NDCauTraLoi, textBox_MaCauTraLoi);
        }
    }
}
