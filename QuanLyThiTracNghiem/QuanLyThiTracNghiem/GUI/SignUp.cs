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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            customFormSignUp_Load();
        }

        private void customFormSignUp_Load()
        {
            // 1) Đặt form nằm giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;

            // 2) Không cho resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false; // tắt nút maximize
            this.MinimizeBox = false; // tắt nút minimize
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#9CC7FF");
            button_DangKy.BackColor = System.Drawing.ColorTranslator.FromHtml("#4A7EFA");
            button_DangNhap.BackColor = System.Drawing.ColorTranslator.FromHtml("#9CC7FF");
            button_DangNhap.FlatStyle = FlatStyle.Flat;
            button_DangNhap.FlatAppearance.BorderSize = 0;

            textBox_MatKhau.AutoSize = false;           
            textBox_MatKhau.Height = 47;

            // Cho phép chỉnh chiều cao thủ công
            textBox_NhapLaiMK.AutoSize = false;           // tắt tự động co chiều cao
            textBox_NhapLaiMK.Height = 47;
        }

        private void label_NhapLaiMK_Click(object sender, EventArgs e)
        {

        }

        private void label_MaTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_MatKhau_Click(object sender, EventArgs e)
        {
            // Đảo trạng thái ẩn/hiện mât khẩu
            textBox_MatKhau.UseSystemPasswordChar = !textBox_MatKhau.UseSystemPasswordChar;
        }

        private void pictureBox_NhapLaiMK_Click(object sender, EventArgs e)
        {
            // Đảo trạng thái ẩn/hiện mât khẩu
            textBox_NhapLaiMK.UseSystemPasswordChar = !textBox_NhapLaiMK.UseSystemPasswordChar;
        }

        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            Login s = new Login();
            s.Show();       
            this.Close();   
        }

        private void button_DangKy_Click(object sender, EventArgs e)
        {
            
            Login s = new Login();
            s.Show();
            this.Close();
        }
    }
}
