using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_DeThi : UserControl
    {
        private NhomBUS nhomBUS = new NhomBUS();
        private DeKiemTraBUS deKiemTraBUS = new DeKiemTraBUS();
        private int currentPage = 1;
        private int pageSize = 5; // Số mục trên mỗi trang
      
        public Component_DeThi()
        {
            InitializeComponent();
            Load_ComboBox_LocTheoNhom();
            Console.WriteLine("Mã sinh viên hiện tai: " + UserSession.userId);
            //FlowLayoutPanel flowLayoutPanel_Main ,ComboBox comboBox_LocTheoNhom, Form panel_TrangChu,string maSinhVien, int currentPage, int pageSize
            deKiemTraBUS.GetDeKTra_Mon_Nhom(flowLayoutPanel_Main, comboBox_LocTheoNhom, this.ParentForm, UserSession.userId, this.currentPage,this. pageSize);

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
    }
}
