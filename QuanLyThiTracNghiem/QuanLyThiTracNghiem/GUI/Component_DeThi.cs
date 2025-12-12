using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_DeThi : UserControl
    {
        private NhomBUS nhomBUS = new NhomBUS();
        private DeKiemTraBUS deKiemTraBUS = new DeKiemTraBUS();
        private CTNhomQuyenBUS cTNhomQuyenBUS = new CTNhomQuyenBUS();
     

        private Form? panel_TrangChu;
        private String maSinhVien;

        private int currentPage = 1;
        private int pageSize = 5;
        private int totalPages = 0;


        public Component_DeThi()
        {
            InitializeComponent();
            Load_ComboBox_LocTheoNhom();
            this.panel_TrangChu = this.FindForm();
            this.maSinhVien = UserSession.userId;
            Load_Data();

        }

        private void Load_Data()
        {
            try
            {
                // Lấy dữ liệu và tổng số item
                int totalItems = deKiemTraBUS.GetDeKTra_Mon_NhomPhanTrang(
                    flowLayoutPanel_Main,
                    comboBox_LocTheoNhom,
                    this.panel_TrangChu,
                    this.maSinhVien,
                    this.currentPage,
                    this.pageSize
                );

                // Tính tổng số trang
                this.totalPages = (int)Math.Ceiling((double)totalItems / this.pageSize);

                // Cập nhật combobox phân trang
                comboBox_PhanTrang.Items.Clear();
                for (int i = 1; i <= this.totalPages; i++)
                    comboBox_PhanTrang.Items.Add(i.ToString());

                if (this.totalPages > 0)
                    comboBox_PhanTrang.SelectedIndex = Math.Min(currentPage - 1, totalPages - 1);

                // Hiển thị nút Prev/Next
                bool showButtons = totalPages > 1;
                button_Prev.Visible = showButtons && currentPage > 1;
                button_Next.Visible = showButtons && currentPage < totalPages;
            }
            catch (Exception ex)
            {
            }
        }


        private void Load_ComboBox_LocTheoNhom()
        {
            nhomBUS.GetListNhomTheoMaSV(UserSession.userId, comboBox_LocTheoNhom);
        }

        private void Component_DeThi_Load(object sender, EventArgs e)
        {
            // FLOWLAYOUTPANEL_MAIN 
            flowLayoutPanel_Main.AutoScroll = true;
            flowLayoutPanel_Main.WrapContents = false;
            flowLayoutPanel_Main.FlowDirection = FlowDirection.TopDown;

            // Style nút next/prev
            button_Next.BackColor = ColorTranslator.FromHtml("#9CC7FF");
            button_Prev.BackColor = ColorTranslator.FromHtml("#9CC7FF");



        }

        private void button_Prev_Click(object sender, EventArgs e)
        {
            this.currentPage = this.currentPage - 1;
            Load_Data();

        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            this.currentPage = this.currentPage + 1;
            Load_Data();
        }

        private void comboBox_LocTheoNhom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_LocTheoNhom.SelectedIndex <= 0)
            {
                this.currentPage = 1;
                Load_Data();
                return;
            }
            this.currentPage = 1;
            Load_Data();

        }

        private void button_TimKiem_Click(object sender, EventArgs e)
        {
            button_Next.Visible = false;
            button_Prev.Visible = false;
            comboBox_PhanTrang.Visible = false;
            deKiemTraBUS.TimKiemTheoMaDeHoacTen(flowLayoutPanel_Main, this.panel_TrangChu, this.maSinhVien, textBox_TimKiem.Text);

        }

        private void button_Reload_Click(object sender, EventArgs e)
        {
            this.currentPage = 1;
            comboBox_LocTheoNhom.SelectedIndex = 0;
            textBox_TimKiem.Text = "";
            button_Next.Visible = true;
            button_Prev.Visible = true;
            comboBox_PhanTrang.Visible = true;
            Load_Data();

        }

        private void comboBox_PhanTrang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_PhanTrang.SelectedIndex < 0)
                return;
            this.currentPage = comboBox_PhanTrang.SelectedIndex;
            Load_Data();
        }
        
    }
}
