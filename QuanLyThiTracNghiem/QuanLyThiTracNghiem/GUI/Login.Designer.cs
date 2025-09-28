namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel_Right = new Panel();
            button_DangKi = new Button();
            label_titleDangKi = new Label();
            button_Login = new Button();
            pictureBox_MatKhau = new PictureBox();
            pictureBox_MaTaiKhoan = new PictureBox();
            textBox_MatKhau = new TextBox();
            textBox_MaTaiKhoan = new TextBox();
            label_MatKhau = new Label();
            label_MaTaiKhoan = new Label();
            pictureBox_Logo = new PictureBox();
            pictureBox_backgroundLogin = new PictureBox();
            panel_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MatKhau).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MaTaiKhoan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_backgroundLogin).BeginInit();
            SuspendLayout();
            // 
            // panel_Right
            // 
            panel_Right.BackColor = SystemColors.ActiveCaption;
            panel_Right.Controls.Add(button_DangKi);
            panel_Right.Controls.Add(label_titleDangKi);
            panel_Right.Controls.Add(button_Login);
            panel_Right.Controls.Add(pictureBox_MatKhau);
            panel_Right.Controls.Add(pictureBox_MaTaiKhoan);
            panel_Right.Controls.Add(textBox_MatKhau);
            panel_Right.Controls.Add(textBox_MaTaiKhoan);
            panel_Right.Controls.Add(label_MatKhau);
            panel_Right.Controls.Add(label_MaTaiKhoan);
            panel_Right.Controls.Add(pictureBox_Logo);
            panel_Right.Location = new Point(832, -1);
            panel_Right.Margin = new Padding(3, 2, 3, 2);
            panel_Right.Name = "panel_Right";
            panel_Right.Size = new Size(833, 776);
            panel_Right.TabIndex = 0;
            // 
            // button_DangKi
            // 
            button_DangKi.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_DangKi.ForeColor = Color.Red;
            button_DangKi.Location = new Point(317, 636);
            button_DangKi.Name = "button_DangKi";
            button_DangKi.Size = new Size(205, 49);
            button_DangKi.TabIndex = 9;
            button_DangKi.Text = "Đăng ký";
            button_DangKi.UseVisualStyleBackColor = true;
            button_DangKi.Click += button_DangKi_Click;
            // 
            // label_titleDangKi
            // 
            label_titleDangKi.AutoSize = true;
            label_titleDangKi.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_titleDangKi.ForeColor = Color.Firebrick;
            label_titleDangKi.Location = new Point(36, 644);
            label_titleDangKi.Name = "label_titleDangKi";
            label_titleDangKi.Size = new Size(276, 32);
            label_titleDangKi.TabIndex = 8;
            label_titleDangKi.Text = "Bạn chưa có tài khoản ?";
            // 
            // button_Login
            // 
            button_Login.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Login.ForeColor = SystemColors.ButtonFace;
            button_Login.Location = new Point(36, 547);
            button_Login.Name = "button_Login";
            button_Login.Size = new Size(768, 70);
            button_Login.TabIndex = 7;
            button_Login.Text = "ĐĂNG NHẬP";
            button_Login.UseVisualStyleBackColor = true;
            button_Login.Click += button_Login_Click;
            // 
            // pictureBox_MatKhau
            // 
            pictureBox_MatKhau.Image = (Image)resources.GetObject("pictureBox_MatKhau.Image");
            pictureBox_MatKhau.Location = new Point(750, 414);
            pictureBox_MatKhau.Name = "pictureBox_MatKhau";
            pictureBox_MatKhau.Size = new Size(54, 54);
            pictureBox_MatKhau.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_MatKhau.TabIndex = 6;
            pictureBox_MatKhau.TabStop = false;
            pictureBox_MatKhau.Click += pictureBox_MatKhau_Click;
            // 
            // pictureBox_MaTaiKhoan
            // 
            pictureBox_MaTaiKhoan.Image = (Image)resources.GetObject("pictureBox_MaTaiKhoan.Image");
            pictureBox_MaTaiKhoan.Location = new Point(750, 330);
            pictureBox_MaTaiKhoan.Name = "pictureBox_MaTaiKhoan";
            pictureBox_MaTaiKhoan.Size = new Size(54, 54);
            pictureBox_MaTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_MaTaiKhoan.TabIndex = 5;
            pictureBox_MaTaiKhoan.TabStop = false;
            // 
            // textBox_MatKhau
            // 
            textBox_MatKhau.Font = new Font("Calibri", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_MatKhau.Location = new Point(229, 414);
            textBox_MatKhau.Name = "textBox_MatKhau";
            textBox_MatKhau.Size = new Size(515, 40);
            textBox_MatKhau.TabIndex = 4;
            textBox_MatKhau.UseSystemPasswordChar = true;
            // 
            // textBox_MaTaiKhoan
            // 
            textBox_MaTaiKhoan.Font = new Font("Calibri", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_MaTaiKhoan.Location = new Point(229, 330);
            textBox_MaTaiKhoan.Multiline = true;
            textBox_MaTaiKhoan.Name = "textBox_MaTaiKhoan";
            textBox_MaTaiKhoan.Size = new Size(515, 54);
            textBox_MaTaiKhoan.TabIndex = 3;
            // 
            // label_MatKhau
            // 
            label_MatKhau.AutoSize = true;
            label_MatKhau.Font = new Font("Calibri", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MatKhau.Location = new Point(36, 432);
            label_MatKhau.Name = "label_MatKhau";
            label_MatKhau.Size = new Size(141, 36);
            label_MatKhau.TabIndex = 2;
            label_MatKhau.Text = "Mật Khẩu:";
            // 
            // label_MaTaiKhoan
            // 
            label_MaTaiKhoan.AutoSize = true;
            label_MaTaiKhoan.Font = new Font("Calibri", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MaTaiKhoan.Location = new Point(36, 346);
            label_MaTaiKhoan.Name = "label_MaTaiKhoan";
            label_MaTaiKhoan.Size = new Size(187, 36);
            label_MaTaiKhoan.TabIndex = 1;
            label_MaTaiKhoan.Text = "Mã Tài Khoản:";
            // 
            // pictureBox_Logo
            // 
            pictureBox_Logo.BackgroundImage = (Image)resources.GetObject("pictureBox_Logo.BackgroundImage");
            pictureBox_Logo.Location = new Point(317, 13);
            pictureBox_Logo.Name = "pictureBox_Logo";
            pictureBox_Logo.Size = new Size(250, 250);
            pictureBox_Logo.TabIndex = 0;
            pictureBox_Logo.TabStop = false;
            // 
            // pictureBox_backgroundLogin
            // 
            pictureBox_backgroundLogin.BackgroundImage = (Image)resources.GetObject("pictureBox_backgroundLogin.BackgroundImage");
            pictureBox_backgroundLogin.Location = new Point(41, 61);
            pictureBox_backgroundLogin.Margin = new Padding(3, 2, 3, 2);
            pictureBox_backgroundLogin.Name = "pictureBox_backgroundLogin";
            pictureBox_backgroundLogin.Size = new Size(683, 703);
            pictureBox_backgroundLogin.TabIndex = 1;
            pictureBox_backgroundLogin.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1664, 775);
            Controls.Add(pictureBox_backgroundLogin);
            Controls.Add(panel_Right);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            Text = "Login";
            panel_Right.ResumeLayout(false);
            panel_Right.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MatKhau).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MaTaiKhoan).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_backgroundLogin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Right;
        private PictureBox pictureBox_backgroundLogin;
        private PictureBox pictureBox_Logo;
        private TextBox textBox_MaTaiKhoan;
        private Label label_MatKhau;
        private Label label_MaTaiKhoan;
        private PictureBox pictureBox_MaTaiKhoan;
        private Button button_Login;
        private PictureBox pictureBox_MatKhau;
        private Label label_titleDangKi;
        private Button button_DangKi;
        private TextBox textBox_MatKhau;
    }
}