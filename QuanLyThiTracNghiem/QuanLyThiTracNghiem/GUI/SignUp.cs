using System;

using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI;
namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class SignUp : Form
    {
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();
        private SinhVienBUS svBUS = new SinhVienBUS();
        public SignUp()
        {
            InitializeComponent();
            AddEvents();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddEvents()
        {
            btnDangKy.Click += (s, e) =>
            {
                XuLyDangKy();
            };
            lblCoTaiKhoan.Click += (s, e) =>
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            };
        }

        private bool XuLyDangKy()
        {
            if (svBUS.ThemSinhVien(txtMa.Text, txtTen.Text, txtEmail.Text, txtMatKhau.Text, txtNhapLai.Text))
            {
                bool flag = tkBUS.ThemTaiKhoan(txtMa.Text, txtMatKhau.Text);
                return flag;
            }
            else
            {
                return false;
            }          
        }

        private void lblCoTaiKhoan_MouseEnter(object sender, EventArgs e)
        {
            lblCoTaiKhoan.ForeColor = Color.Blue;
        }

        private void lblCoTaiKhoan_MouseLeave(object sender, EventArgs e)
        {
            lblCoTaiKhoan.ForeColor = Color.Black;
        }

        private void lblQuenMK_MouseEnter(object sender, EventArgs e)
        {
            lblQuenMK.ForeColor = Color.Blue;
        }

        private void lblQuenMK_MouseLeave(object sender, EventArgs e)
        {
            lblQuenMK.ForeColor= Color.Black;
        }
    }
}
