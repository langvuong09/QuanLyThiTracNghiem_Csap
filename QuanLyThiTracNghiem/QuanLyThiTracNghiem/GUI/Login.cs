using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            customFormLogin_Load();
        }

        private void customFormLogin_Load()
        {
            // 1) Đặt form nằm giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;

            // 2) Không cho resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false; // tắt nút maximize
            this.MinimizeBox = false; // tắt nút minimize

            //Set màu background 
            panel_Right.BackColor = System.Drawing.ColorTranslator.FromHtml("#97B6FF");
            button_Login.BackColor = System.Drawing.ColorTranslator.FromHtml("#458FFF");

            RoundButton(button_Login, 60);
            button_Login.FlatStyle = FlatStyle.Flat;   // bỏ border mặc định
            button_Login.FlatAppearance.BorderSize = 0;

            button_DangKi.FlatAppearance.BorderSize = 0;
            button_DangKi.FlatStyle = FlatStyle.Flat;
            button_DangKi.BackColor = System.Drawing.ColorTranslator.FromHtml("#97B6FF");




            textBox_MatKhau.AutoSize = false;
            textBox_MatKhau.Height = 54;

        }

        //Bo góc testBox
        private void RoundButton(Button btn, int radius)
        {
            var path = new GraphicsPath();
            int w = btn.Width;
            int h = btn.Height;

            // 4 góc bo tròn
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(w - radius, 0, radius, radius, 270, 90);
            path.AddArc(w - radius, h - radius, radius, radius, 0, 90);
            path.AddArc(0, h - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }



        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel_Right_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox_MatKhau_Click(object sender, EventArgs e)
        {
            // Đảo trạng thái ẩn/hiện mât khẩu
            textBox_MatKhau.UseSystemPasswordChar = !textBox_MatKhau.UseSystemPasswordChar;
        }

        private void button_DangKi_Click(object sender, EventArgs e)
        {

            SignUp s = new SignUp();
            s.Show();       
            this.Close();   
        }

        private void button_Login_Click(object sender, EventArgs e)
        {

            // Sau khi tự kiểm tra tài khoản hợp lệ
            TrangChuSinhVien s = new TrangChuSinhVien();

            s.FormClosed += (s1, e1) => Application.Exit();

            s.Show();
            this.Hide();  
            this.Close();  
        }
    }


}
