using System;

using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Login : Form
    {
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            XuLyDangNhap();
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
        }

        private void XuLyDangNhap()
        {
            string taikhoan = txtMa.Text.Trim();
            string password = txtPassword.Text.Trim();
            TaiKhoan tk = tkBUS.GetTaiKhoan(taikhoan,password);

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(taikhoan) || string.IsNullOrEmpty(password))
            {
                new MyDialog("Vui lòng nhập đầy đủ các thông tin cần thiết!", MyDialog.ERROR_DIALOG).ShowDialog();
                return;
            }

            if (tk == null)
            {
                new MyDialog("Đăng nhập không thành công!", MyDialog.ERROR_DIALOG).ShowDialog();
                return;
            }
            else
            {
                //UserSession.UserId = user.userId;
                new MyDialog("Đăng nhập thành công!", MyDialog.SUCCESS_DIALOG).ShowDialog();
                this.Hide();
            }
        }

    }
}
