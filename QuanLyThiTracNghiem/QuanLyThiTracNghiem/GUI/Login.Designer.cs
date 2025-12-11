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
            panel_Right.BackColor = Color.FromArgb(125, 162, 206);
            panel_Right.BorderStyle = BorderStyle.None;
            panel_Right.Controls.Add(button_Login);
            panel_Right.Controls.Add(pictureBox_MatKhau);
            panel_Right.Controls.Add(pictureBox_MaTaiKhoan);
            panel_Right.Controls.Add(textBox_MatKhau);
            panel_Right.Controls.Add(textBox_MaTaiKhoan);
            panel_Right.Controls.Add(label_MatKhau);
            panel_Right.Controls.Add(label_MaTaiKhoan);
            panel_Right.Controls.Add(pictureBox_Logo);
            panel_Right.Location = new Point(832, -1);
            panel_Right.Margin = new Padding(0);
            panel_Right.Name = "panel_Right";
            panel_Right.Padding = new Padding(20);
            panel_Right.Size = new Size(833, 776);
            panel_Right.TabIndex = 0;
            // 
            // button_Login
            // 
            button_Login.BackColor = Color.FromArgb(70, 130, 180);
            button_Login.FlatAppearance.BorderSize = 0;
            button_Login.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 100, 150);
            button_Login.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 150, 200);
            button_Login.FlatStyle = FlatStyle.Flat;
            button_Login.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Login.ForeColor = Color.White;
            button_Login.Location = new Point(48, 570);
            button_Login.Margin = new Padding(0);
            button_Login.Name = "button_Login";
            button_Login.Size = new Size(740, 80);
            button_Login.TabIndex = 7;
            button_Login.Text = "ĐĂNG NHẬP";
            button_Login.UseVisualStyleBackColor = false;
            button_Login.Click += button_Login_Click;
            // 
            // pictureBox_MatKhau
            // 
            pictureBox_MatKhau.Image = (Image)resources.GetObject("pictureBox_MatKhau.Image");
            pictureBox_MatKhau.Location = new Point(750, 420);
            pictureBox_MatKhau.Margin = new Padding(4, 3, 4, 3);
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
            pictureBox_MaTaiKhoan.Location = new Point(750, 340);
            pictureBox_MaTaiKhoan.Margin = new Padding(4, 3, 4, 3);
            pictureBox_MaTaiKhoan.Name = "pictureBox_MaTaiKhoan";
            pictureBox_MaTaiKhoan.Size = new Size(54, 54);
            pictureBox_MaTaiKhoan.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_MaTaiKhoan.TabIndex = 5;
            pictureBox_MaTaiKhoan.TabStop = false;
            // 
            // textBox_MatKhau
            // 
            textBox_MatKhau.BackColor = Color.White;
            textBox_MatKhau.BorderStyle = BorderStyle.FixedSingle;
            textBox_MatKhau.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_MatKhau.Location = new Point(240, 430);
            textBox_MatKhau.Margin = new Padding(0);
            textBox_MatKhau.Name = "textBox_MatKhau";
            textBox_MatKhau.Padding = new Padding(10);
            textBox_MatKhau.Size = new Size(500, 48);
            textBox_MatKhau.TabIndex = 4;
            textBox_MatKhau.UseSystemPasswordChar = true;
            // 
            // textBox_MaTaiKhoan
            // 
            textBox_MaTaiKhoan.BackColor = Color.White;
            textBox_MaTaiKhoan.BorderStyle = BorderStyle.FixedSingle;
            textBox_MaTaiKhoan.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_MaTaiKhoan.Location = new Point(240, 350);
            textBox_MaTaiKhoan.Margin = new Padding(0);
            textBox_MaTaiKhoan.Multiline = true;
            textBox_MaTaiKhoan.Name = "textBox_MaTaiKhoan";
            textBox_MaTaiKhoan.Padding = new Padding(10);
            textBox_MaTaiKhoan.Size = new Size(500, 60);
            textBox_MaTaiKhoan.TabIndex = 3;
            // 
            // label_MatKhau
            // 
            label_MatKhau.AutoSize = true;
            label_MatKhau.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MatKhau.ForeColor = Color.FromArgb(240, 248, 255);
            label_MatKhau.Location = new Point(48, 440);
            label_MatKhau.Margin = new Padding(0);
            label_MatKhau.Name = "label_MatKhau";
            label_MatKhau.Size = new Size(150, 37);
            label_MatKhau.TabIndex = 2;
            label_MatKhau.Text = "Mật Khẩu:";
            // 
            // label_MaTaiKhoan
            // 
            label_MaTaiKhoan.AutoSize = true;
            label_MaTaiKhoan.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MaTaiKhoan.ForeColor = Color.FromArgb(240, 248, 255);
            label_MaTaiKhoan.Location = new Point(48, 360);
            label_MaTaiKhoan.Margin = new Padding(0);
            label_MaTaiKhoan.Name = "label_MaTaiKhoan";
            label_MaTaiKhoan.Size = new Size(200, 37);
            label_MaTaiKhoan.TabIndex = 1;
            label_MaTaiKhoan.Text = "Mã Tài Khoản:";
            // 
            // pictureBox_Logo
            // 
            pictureBox_Logo.BackgroundImage = (Image)resources.GetObject("pictureBox_Logo.BackgroundImage");
            pictureBox_Logo.Location = new Point(317, 30);
            pictureBox_Logo.Margin = new Padding(0);
            pictureBox_Logo.Name = "pictureBox_Logo";
            pictureBox_Logo.Size = new Size(250, 250);
            pictureBox_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Logo.TabIndex = 0;
            pictureBox_Logo.TabStop = false;
            // 
            // pictureBox_backgroundLogin
            // 
            pictureBox_backgroundLogin.BackgroundImage = (Image)resources.GetObject("pictureBox_backgroundLogin.BackgroundImage");
            pictureBox_backgroundLogin.Location = new Point(48, 68);
            pictureBox_backgroundLogin.Margin = new Padding(4, 3, 4, 3);
            pictureBox_backgroundLogin.Name = "pictureBox_backgroundLogin";
            pictureBox_backgroundLogin.Size = new Size(683, 703);
            pictureBox_backgroundLogin.TabIndex = 1;
            pictureBox_backgroundLogin.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 250);
            ClientSize = new Size(1664, 775);
            Controls.Add(pictureBox_backgroundLogin);
            Controls.Add(panel_Right);
            Margin = new Padding(4, 3, 4, 3);
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
        private TextBox textBox_MatKhau;
    }
}