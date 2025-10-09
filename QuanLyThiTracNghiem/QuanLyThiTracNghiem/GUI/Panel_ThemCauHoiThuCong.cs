using Mysqlx.Session;
using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Panel_ThemCauHoiThuCong : UserControl
    {
        private MonHocBUS monHocBUS = new MonHocBUS();
        private ChuongBUS chuongBUS = new ChuongBUS();

        private CauHoiBUS cauHoiBUS = new CauHoiBUS();
        private DapAnBUS dapAnBUS = new DapAnBUS();

        private int solgCauTraLoi = 1;
        private int soCauTraLoiDung = 0;
        private int rowIndex = -1;


        private List<DapAn> listDapAn = new List<DapAn>();

        public Panel_ThemCauHoiThuCong()
        {
            InitializeComponent();
            LoadMonHoc(comboBox_MonHoc);
            LoadDoKho(comboBox_DoKho);
            Load_PanelCauHoiMoi();
            CustomHeader_DataGridViewDSCauTraLoi();

        }

        private void CustomHeader_DataGridViewDSCauTraLoi()
        {
            if (dataGridView_DSCauTraLoi == null)
            {
                MessageBox.Show("Lỗi: DataGridView_DSCauTraLoi chưa được khởi tạo!",
                                "Lỗi khởi tạo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
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

            dataGridView_DSCauTraLoi.Columns.Add("MaDapAn", "Mã Đáp Án");
            dataGridView_DSCauTraLoi.Columns.Add("NoiDung", "Nội Dung");
            dataGridView_DSCauTraLoi.Columns.Add("DungSai", "Đúng/Sai");

            DataGridViewImageColumn colEdit = new DataGridViewImageColumn();
            colEdit.Name = "ChinhSua";
            colEdit.HeaderText = "Sửa";
            colEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colEdit.Image = Image.FromFile("image/Sua.png");

            dataGridView_DSCauTraLoi.Columns.Add(colEdit);

            //Custom dòng dữ liệu
            dataGridView_DSCauTraLoi.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridView_DSCauTraLoi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_DSCauTraLoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_DSCauTraLoi.DefaultCellStyle.BackColor = Color.White;
            dataGridView_DSCauTraLoi.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView_DSCauTraLoi.RowTemplate.Height = 40;
            dataGridView_DSCauTraLoi.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#9CC7FF");

            //Tùy chỉnh độ rộng cột
            dataGridView_DSCauTraLoi.Columns["MaDAPAn"].Width = 200;
            dataGridView_DSCauTraLoi.Columns["NoiDung"].Width = 400;
            dataGridView_DSCauTraLoi.Columns["NoiDung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_DSCauTraLoi.Columns["DungSai"].Width = 150;
        }

        private void Load_PanelCauHoiMoi()
        {
            cauHoiBUS.TaoMaCauHoiMoi(textBox_MaCauHoi);
            textBox_MaCauTraLoi.ReadOnly = true;
            textBox_MaCauTraLoi.Text = solgCauTraLoi.ToString();
            // Cho phép xem DataGridView nhưng không chỉnh sửa
            dataGridView_DSCauTraLoi.ReadOnly = true;
            dataGridView_DSCauTraLoi.AllowUserToAddRows = false;
            dataGridView_DSCauTraLoi.AllowUserToDeleteRows = false;
            dataGridView_DSCauTraLoi.AllowUserToResizeColumns = false;
            dataGridView_DSCauTraLoi.AllowUserToResizeRows = false;
        }

        //===================Load Môn Học==========================
        private void LoadMonHoc(System.Windows.Forms.ComboBox combo)
        {
            monHocBUS.LayListMonHoc(combo);
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
            combo.SelectedIndex = 0;
        }

        //====================Load Chương=======================
        private void LoadChuong(System.Windows.Forms.ComboBox combo, string maMonHoc)
        {
            combo.DataSource = null;
            combo.Items.Clear();
            chuongBUS.LayListChuong(combo, maMonHoc);
        }

        private void comboBox_MonHoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_MonHoc.SelectedIndex <= 0)
            {
                LoadChuong(comboBox_Chuong, "0");
                return;
            }

            var monHoc = comboBox_MonHoc.SelectedItem as MonHoc;
            if (monHoc == null) return;

            LoadChuong(comboBox_Chuong, monHoc.maMonHoc);
        }





        private void button_Them_Click(object sender, EventArgs e)
        {
            

        }

        private void button_ThemCauTraLoi_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các component
            string maCauTraLoi = textBox_MaCauTraLoi.Text.Trim();
            string noiDung = textBox_NDCauTraLoi.Text.Trim();
            string dungSai = radioButton_Dung.Checked ? "Đúng" : (radioButton_Sai.Checked ? "Sai" : "");

            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrEmpty(noiDung))
            {
                MyDialog dialog = new MyDialog("Vui lòng nhập nội dung câu trả lời.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }

            if (string.IsNullOrEmpty(dungSai))
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn đáp án đúng hay sai.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }
             
            if(this.soCauTraLoiDung == 1 && dungSai == "Đúng")
            {
                MyDialog dialog = new MyDialog("Mỗi câu hỏi đều chỉ có 4 đáp án. Trong đó chi một đáp án đúng", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }

            if (solgCauTraLoi <= 4)
            {
                int rowIndex = dataGridView_DSCauTraLoi.Rows.Add();
                dataGridView_DSCauTraLoi.Rows[rowIndex].Cells["MaDapAn"].Value = maCauTraLoi;
                dataGridView_DSCauTraLoi.Rows[rowIndex].Cells["NoiDung"].Value = noiDung;
                dataGridView_DSCauTraLoi.Rows[rowIndex].Cells["DungSai"].Value = dungSai;

                
                Console.WriteLine("\n Câu trả lời thứ:",this.solgCauTraLoi);
                // Reset form nhập
                this.solgCauTraLoi = this.solgCauTraLoi + 1;
                if(this.solgCauTraLoi > 4)
                {
                    textBox_NDCauTraLoi.Clear();
                    textBox_MaCauTraLoi.Clear();
                    radioButton_Dung.Checked = false;
                    radioButton_Sai.Checked = false;
                    button_ThemCauTraLoi.Visible= false;

                }
                else
                {
                    textBox_MaCauTraLoi.Text = this.solgCauTraLoi.ToString();
                    textBox_NDCauTraLoi.Clear();
                    if (dungSai == "Đúng")
                        this.soCauTraLoiDung = this.soCauTraLoiDung + 1;
                    radioButton_Dung.Checked = false;
                    radioButton_Sai.Checked = false;
                }
                   
            }
            else
            {
                MyDialog dialog = new MyDialog("Mỗi câu hỏi đều chỉ có 4 đáp án. Trong đó chi một đáp án đúng", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
            }

        }

        private void button_LuuChinhSua_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các component
            string noiDung = textBox_NDCauTraLoi.Text.Trim();

            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrEmpty(noiDung))
            {
                MyDialog dialog = new MyDialog("Vui lòng nhập nội dung câu trả lời.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }

            dataGridView_DSCauTraLoi.Rows[this.rowIndex].Cells["NoiDung"].Value = noiDung;
            this.rowIndex = -1;
            textBox_MaCauTraLoi.Clear();
            textBox_NDCauTraLoi.Clear();
            button_LuuChinhSua.Visible = false;

            if (this.solgCauTraLoi>4)
            {
                button_ThemCauTraLoi.Visible = false;
            }
            else
            {
                button_ThemCauTraLoi.Visible = true;
                textBox_MaCauTraLoi.Text = this.solgCauTraLoi.ToString();
                radioButton_Dung.Checked = false;
                radioButton_Sai.Checked = false;
                radioButton_Dung.Enabled = true;
                radioButton_Sai.Enabled = true;
            }


        }

        private void dataGridView_DSCauTraLoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dataGridView_DSCauTraLoi.Columns[e.ColumnIndex].Name;

            if (colName == "ChinhSua")
            {
                string ma = dataGridView_DSCauTraLoi.Rows[e.RowIndex].Cells["MaDapAn"].Value?.ToString();
                string nd = dataGridView_DSCauTraLoi.Rows[e.RowIndex].Cells["NoiDung"].Value?.ToString();
                string ds = dataGridView_DSCauTraLoi.Rows[e.RowIndex].Cells["DungSai"].Value?.ToString();

                textBox_MaCauTraLoi.Text = ma;
                textBox_NDCauTraLoi.Text = nd;
                if (ds == "Đúng") radioButton_Dung.Checked = true;
                else radioButton_Sai.Checked = true;

                button_LuuChinhSua.Visible = true;
                button_ThemCauTraLoi.Visible = false;
                radioButton_Dung.Enabled = false;
                radioButton_Sai.Enabled = false;

                this.rowIndex = e.RowIndex;

            }
        }
    }
}
