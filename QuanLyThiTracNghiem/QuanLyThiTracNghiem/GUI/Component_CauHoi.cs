using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_CauHoi : UserControl
    {

        private MonHocBUS monHocBUS = new MonHocBUS();
        private CauHoiBUS cauHoiBUS = new CauHoiBUS();
        private ChuongBUS chuongBUS = new ChuongBUS();
        private PhanCongBUS phanCongBUS = new PhanCongBUS();
        private CTNhomQuyenBUS ctNhomQuyenBUS = new CTNhomQuyenBUS();

        //Các biến phục vụ phân trang
        private int currentPage = 1;// Trang hiện tại
        private int pageSize = 25; // Số mục trên mỗi trang
        private int totalPages = 0; // Tổng số trang

        //Xử lý các biến lọc
        private String is_MonHocSelected = "0"; // Môn học được chọn trong ComboBox
        private String is_DoKho = "0"; // Độ khó được chọn trong ComboBox
        private int is_Chuong = 0; // Chương được chọn trong ComboBox
        private bool isComboBoxChanging = false;


        public Component_CauHoi()
        {
            InitializeComponent();
            checkPhanQuyen();
            Custom_Component_CauHoi();
            Custom_HeaderDataGridView_DSCauHoi();
            LoadMonHoc(comboBox_MonHoc);
            LoadDoKho(comboBox_DoKho);
            //Hiển thị dữ liệu lên DataGridView
            LoadData_DSCauHoi();
        }
        // ===========================================Custom Header DataGridView_DSCauHoi===========================================
        private void Custom_HeaderDataGridView_DSCauHoi()
        {

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
            dataGridView_DSCauHoi.Columns.Add("MonHoc", "Mã Môn Học");
            dataGridView_DSCauHoi.Columns.Add("Chuong", "Mã Chương");
            dataGridView_DSCauHoi.Columns.Add("DoKho", "Độ Khó");

            //Custom dòng dữ liệu
            dataGridView_DSCauHoi.DefaultCellStyle.Font = new Font("Segoe UI", 13);
            dataGridView_DSCauHoi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_DSCauHoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_DSCauHoi.DefaultCellStyle.BackColor = Color.White;
            dataGridView_DSCauHoi.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView_DSCauHoi.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#9CC7FF");
            dataGridView_DSCauHoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_DSCauHoi.MultiSelect = false;
            dataGridView_DSCauHoi.ReadOnly = true;

            //Tùy chỉnh độ rộng cột
            dataGridView_DSCauHoi.Columns["MaCauHoi"].Width = 200;
            dataGridView_DSCauHoi.Columns["NoiDung"].Width = 600;
            dataGridView_DSCauHoi.Columns["NoiDung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_DSCauHoi.Columns["MonHoc"].Width = 200;
            dataGridView_DSCauHoi.Columns["Chuong"].Width = 200;
            dataGridView_DSCauHoi.Columns["DoKho"].Width = 150;

            // Chỉ cho phép 2 cột dài được wrap
            dataGridView_DSCauHoi.Columns["NoiDung"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        // ===========================================Load Data_DSCauHoi===========================================
        private void LoadData_DSCauHoi()
        {
            try
            {
                if (UserSession.Quyen != 1)
                {
                    this.totalPages = cauHoiBUS.LayDSCauHoi_PhanTrang(
                    UserSession.userId,
                    dataGridView_DSCauHoi,
                    this.currentPage,
                    this.pageSize,
                    this.is_MonHocSelected,
                    this.is_Chuong,
                    this.is_DoKho
                );
                }
                else
                {
                    // Lấy dữ liệu và cập nhật DataGridView
                    this.totalPages = cauHoiBUS.LayDSCauHoi_PhanTrang(
                        dataGridView_DSCauHoi,
                        this.currentPage,
                        this.pageSize,
                        this.is_MonHocSelected,
                        this.is_Chuong,
                        this.is_DoKho
                    );
                }

                // Cập nhật combobox phân trang
                isComboBoxChanging = true;
                comboBox_ChiSo.Items.Clear();
                for (int i = 1; i <= this.totalPages; i++)
                {
                    comboBox_ChiSo.Items.Add(i.ToString());
                }

                if (this.totalPages > 0)
                {
                    comboBox_ChiSo.SelectedIndex = this.currentPage - 1;
                }
                isComboBoxChanging = false;


                // Ẩn/hiện nút Prev/Next 
                button_Prev.Visible = currentPage > 1;
                button_Next.Visible = currentPage < totalPages;

                // Nếu chỉ có 1 trang hoặc không có dữ liệu -> ẩn luôn cả 2 nút
                if (totalPages <= 1)
                {
                    button_Prev.Visible = false;
                    button_Next.Visible = false;
                }

                // Tự động resize row sau khi đổ dữ liệu
                dataGridView_DSCauHoi.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CauHoiComponent => Lỗi khi tải danh sách câu hỏi: " + ex.Message);
            }
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
            //Mới bắt đầu chưa chọn môn học nên không có chương nào
            comboBox_Chuong.DataSource = null;
            comboBox_Chuong.Items.Clear();
            comboBox_Chuong.Items.Add("Chọn Chương");
            comboBox_Chuong.SelectedIndex = 0;


        }

        //===========================================Sự kiện các nút bấm và Combobox===========================================
        private void button_ThemCauHoi_Click(object sender, EventArgs e)
        {
            using (Form dlg = new Form())
            {
                dlg.Text = "THÊM CÂU HỎI";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ClientSize = new Size(1480, 750);
                dlg.AutoScroll = true;
                dlg.ShowInTaskbar = false;

                Dialog_ThemCauHoi dialog = new Dialog_ThemCauHoi();
                dialog.Dock = DockStyle.Top;

                dlg.Controls.Add(dialog);
                dlg.ShowDialog(this);
            }
        }

        private void button_Reload_Click(object sender, EventArgs e)
        {
            this.currentPage = 1;
            this.is_MonHocSelected = "0";
            this.is_Chuong = 0;
            this.is_DoKho = "0";
            button_Prev.Enabled = true;
            button_Next.Enabled = true;
            comboBox_ChiSo.Enabled = true;
            LoadData_DSCauHoi();
            comboBox_MonHoc.SelectedIndex = 0;
            comboBox_DoKho.SelectedIndex = 0;
            comboBox_Chuong.DataSource = null;
            comboBox_Chuong.Items.Clear();
            comboBox_Chuong.Items.Add("Chọn Chương");
            textBox_TimKiem.Text = "";
        }

        private void button_TimKiem_Click(object sender, EventArgs e)
        {
            //Ẩn comboBox phân trang
            button_Prev.Enabled = false;
            button_Next.Enabled = false;
            comboBox_ChiSo.Enabled = false;
            string tuKhoa = textBox_TimKiem.Text.Trim();
            cauHoiBUS.TimKiemCauHoi(dataGridView_DSCauHoi, tuKhoa);
        }

        private void button_Xem_Click(object sender, EventArgs e)
        {
            //Lấy mã câu hỏi đang chọn
            if (dataGridView_DSCauHoi.SelectedRows.Count == 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn câu hỏi để xem chi tiết.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }
            
            //Lấy mã câu hỏi từ dòng được chọn
            string maCauHoi = dataGridView_DSCauHoi.SelectedRows[0].Cells["MaCauHoi"].Value.ToString();
            using (Form dlg = new Form())
            {
                dlg.Text = "CHI TIẾT CÂU HỎI";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ClientSize = new Size(1480, 700);
                dlg.AutoScroll = true;
                dlg.ShowInTaskbar = false;

                //Truyền đối số 0 nghĩa là xác nhận đây là nút xem
                int id = Convert.ToInt32(dataGridView_DSCauHoi.SelectedRows[0].Cells["MaCauHoi"].Value);
                Dialog_SuaCauHoi dialog = new Dialog_SuaCauHoi(0, id);
                dialog.Dock = DockStyle.Top;

                dlg.Controls.Add(dialog);
                dlg.ShowDialog(this);
            }
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            //Lấy mã câu hỏi đang chọn
            if (dataGridView_DSCauHoi.SelectedRows.Count == 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn câu hỏi để sửa thông tin.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }

            using (Form dlg = new Form())
            {
                dlg.Text = "SỬA CÂU HỎI";
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ClientSize = new Size(1480, 700);
                dlg.AutoScroll = true;
                dlg.ShowInTaskbar = false;

                //Truyền đối số 1 nghĩa là xác nhận đây là nút sửa
                int id = Convert.ToInt32(dataGridView_DSCauHoi.SelectedRows[0].Cells["MaCauHoi"].Value);
                Dialog_SuaCauHoi dialog = new Dialog_SuaCauHoi(1,id);
                dialog.Dock = DockStyle.Top;

                dlg.Controls.Add(dialog);
                dlg.ShowDialog(this);
            }
        }

        private void button_Prev_Click(object sender, EventArgs e)
        {
            this.currentPage=this.currentPage-1;
            LoadData_DSCauHoi();
          
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            //Trang sau
            this.currentPage=this.currentPage+1;
            LoadData_DSCauHoi();
        }

        private void dataGridView_DSCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //------------------------------------Load Môn Học Vào ComboBox-----------------------------------
        private void LoadMonHoc(System.Windows.Forms.ComboBox combo)
        {
            //Load môn học từ BUS
            if (UserSession.Quyen != 1)
            {
                monHocBUS.getListByAssignment(UserSession.userId, combo);
            }
            else
            {
                monHocBUS.LayListMonHoc(combo);
            }
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
            // Nếu nhấn mục "Chọn Môn Học" thì load lại chương về 0
            if (comboBox_MonHoc.SelectedIndex <= 0)
            {
                LoadChuong(comboBox_Chuong, "0");
                this.is_MonHocSelected = "0";
                this.is_Chuong = 0;
                this.currentPage = 1;
                LoadData_DSCauHoi();
                return;
            }

            // Lấy object đang chọn
            var monHoc = comboBox_MonHoc.SelectedItem as MonHoc;
            if (monHoc == null) return;
            LoadChuong(comboBox_Chuong, monHoc.maMonHoc);

            this.currentPage = 1;
            this.is_MonHocSelected = monHoc.maMonHoc;
            this.is_Chuong = 0;
            LoadData_DSCauHoi();
        }

        private void comboBox_DoKho_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_DoKho.SelectedIndex <= 0) {
                this.is_DoKho = "0";
                this.currentPage = 1;

                LoadData_DSCauHoi();
                return; 
            }

            var selectedPair = (KeyValuePair<int, string>)comboBox_DoKho.SelectedItem;
            int doKhoKey = selectedPair.Key;
            string doKhoText = selectedPair.Value;

            // Xử lý theo giá trị
            switch (doKhoKey)
            {
                case 1: this.is_DoKho="Dễ"; break;
                case 2: this.is_DoKho = "Trung bình"; break;
                case 3: this.is_DoKho = "Khó"; break;
            }
            this.currentPage = 1;
            //Cập nhật lại DataGridView
            LoadData_DSCauHoi();
        }

        //--------------------------Load chuong vào ComboBox (nếu cần)--------------------------
        private void LoadChuong(System.Windows.Forms.ComboBox combo, string maMonHoc)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            chuongBUS.LayListChuong(combo, maMonHoc);
        }

        private void comboBox_Chuong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Kiểm tra index
            if (comboBox_Chuong.SelectedIndex <= 0)
            {
                this.is_Chuong = 0;
                this.currentPage = 1;
                LoadData_DSCauHoi();
                return;
            }

            // Lấy object đang chọn
            var chuong = comboBox_Chuong.SelectedItem as Chuong;
            if (chuong == null) return;
            this.is_Chuong = chuong.maChuong;
            this.currentPage = 1;
            LoadData_DSCauHoi();

        }

        private void comboBox_ChiSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isComboBoxChanging) return; 
            if (comboBox_ChiSo.SelectedIndex < 0) return;

            this.currentPage = comboBox_ChiSo.SelectedIndex + 1;
            LoadData_DSCauHoi();
        }

        private void checkPhanQuyen()
        {
            ArrayList dsctnq = ctNhomQuyenBUS.GetListCTNhomQuyen(UserSession.Quyen);
            foreach (CTNhomQuyen ctnq in dsctnq)
            {
                if (ctnq.maChucNang == 3)
                {
                    if (ctnq.them == 0)
                    {
                        button_ThemCauHoi.Visible = false;
                    }
                    if (ctnq.capNhat == 0)
                    {
                        button_Sua.Visible = false;
                    }
                    if(ctnq.xem == 0)
                    {
                        button_Xem.Visible = false;
                    }
                }
            }
        }
    }
}
