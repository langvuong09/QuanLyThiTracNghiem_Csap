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
    public partial class TrangChuSinhVien : Form
    {
        public TrangChuSinhVien()
        {
            InitializeComponent();
            customFormTrangChuSinhVien_Load();
        }
        // Kích thước màn hình chính (Primary Screen)
        private static readonly int SCREEN_WIDTH = Screen.PrimaryScreen.Bounds.Width;
        private static readonly int SCREEN_HEIGHT = Screen.PrimaryScreen.Bounds.Height;



        private void customFormTrangChuSinhVien_Load()
        {
            // 1) Đặt form nằm giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);

            // 2) Không cho resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false; // tắt nút maximize
            this.MinimizeBox = false; // tắt nút minimize

            //PANEL TOP
            panel_Top.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            panel_Top.Size = new Size(SCREEN_WIDTH, 100);
            panel_Top.Dock = DockStyle.Top;

           
            //PANEL LEFT
            panel_Left.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            panel_Left.Size = new Size(300, SCREEN_HEIGHT - panel_Top.Height);
            panel_Left.Dock = DockStyle.Left;
            panel_Left.AutoScroll = true;

            //PANEL MAIN
            panel_Main.Size = new Size(SCREEN_WIDTH - panel_Left.Width, SCREEN_HEIGHT - panel_Top.Height);
            panel_Main.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            panel_Main.Dock = DockStyle.Fill;
            
            //BUTTON ĐĂNG XUẤT
            button_DangXuat.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_DangXuat.FlatStyle = FlatStyle.Flat;
            button_DangXuat.FlatAppearance.BorderSize = 0;

            //BUTTON THÔNG BÁO
            button_ThongBao.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_ThongBao.FlatStyle = FlatStyle.Flat;
            button_ThongBao.FlatAppearance.BorderSize = 0;

            //BUTTON THÔNG TIN
            button_ThongTin.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_ThongTin.FlatStyle = FlatStyle.Flat;
            button_ThongTin.FlatAppearance.BorderSize = 0;

            //BUTTON TRANG CHỦ
            button_TrangChu.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_TrangChu.FlatStyle = FlatStyle.Flat;
            button_TrangChu.FlatAppearance.BorderSize = 0;

            //BUTTON HỌC PHẦN
            button_HocPhan.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_HocPhan.FlatStyle = FlatStyle.Flat;
            button_HocPhan.FlatAppearance.BorderSize = 0;

            //BUTTON ĐỀ THI
            button_DeThi.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_DeThi.FlatStyle = FlatStyle.Flat;
            button_DeThi.FlatAppearance.BorderSize = 0;


            //ADD CÁC BUTTON VÔ PANEL LEFT
            panel_Left.Controls.Add(button_TrangChu);
            panel_Left.Controls.Add(button_HocPhan);
            panel_Left.Controls.Add(button_DeThi);


        }
    }
}
