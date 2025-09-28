using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Dialog_SuaCauHoi : UserControl
    {
        public Dialog_SuaCauHoi()
        {
            InitializeComponent();
            CustomDialog_SuaCauHoi();
            CustomHeader_DataGridViewDSCauTraLoi();
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
            dataGridView_DSCauTraLoi.Columns.Add("MaCauTraLoi", "Mã Câu Trả Lời");
            dataGridView_DSCauTraLoi.Columns.Add("NoiDung", "Nội Dung");
            dataGridView_DSCauTraLoi.Columns.Add("DungSai", "Đúng/Sai");

            //Custom dòng dữ liệu
            dataGridView_DSCauTraLoi.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridView_DSCauTraLoi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_DSCauTraLoi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_DSCauTraLoi.DefaultCellStyle.BackColor = Color.White;
            dataGridView_DSCauTraLoi.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView_DSCauTraLoi.DefaultCellStyle.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#9CC7FF");
            dataGridView_DSCauTraLoi.RowTemplate.Height = 100;
            dataGridView_DSCauTraLoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_DSCauTraLoi.MultiSelect = false;
            dataGridView_DSCauTraLoi.ReadOnly = true;

            //Tùy chỉnh độ rộng cột
            dataGridView_DSCauTraLoi.Columns["MaCauTraLoi"].Width = 200;
            dataGridView_DSCauTraLoi.Columns["NoiDung"].Width = 400;
            dataGridView_DSCauTraLoi.Columns["NoiDung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_DSCauTraLoi.Columns["DungSai"].Width = 150;
 
        }
    }
}
