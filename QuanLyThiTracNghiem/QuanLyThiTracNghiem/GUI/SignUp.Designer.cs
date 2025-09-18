namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            pictureBox_Logo = new PictureBox();
            label_MaTaiKhoan = new Label();
            label_TenTaiKhoan = new Label();
            label_Email = new Label();
            label_MatKhau = new Label();
            label_NhapLaiMK = new Label();
            textBox_MaTaiKhoan = new TextBox();
            textBox_HoTen = new TextBox();
            textBox_Email = new TextBox();
            textBox_MatKhau = new TextBox();
            textBox_NhapLaiMK = new TextBox();
            pictureBox_MSSV = new PictureBox();
            pictureBox_HoTen = new PictureBox();
            pictureBox_Email = new PictureBox();
            pictureBox_MatKhau = new PictureBox();
            pictureBox_NhapLaiMK = new PictureBox();
            button_DangKy = new Button();
            label_TitleDangNhap = new Label();
            button_DangNhap = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MSSV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_HoTen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Email).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MatKhau).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_NhapLaiMK).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_Logo
            // 
            pictureBox_Logo.Image = (Image)resources.GetObject("pictureBox_Logo.Image");
            pictureBox_Logo.Location = new Point(230, 31);
            pictureBox_Logo.Name = "pictureBox_Logo";
            pictureBox_Logo.Size = new Size(200, 200);
            pictureBox_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Logo.TabIndex = 0;
            pictureBox_Logo.TabStop = false;
            // 
            // label_MaTaiKhoan
            // 
            label_MaTaiKhoan.AutoSize = true;
            label_MaTaiKhoan.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MaTaiKhoan.Location = new Point(36, 326);
            label_MaTaiKhoan.Name = "label_MaTaiKhoan";
            label_MaTaiKhoan.Size = new Size(83, 32);
            label_MaTaiKhoan.TabIndex = 1;
            label_MaTaiKhoan.Text = "MSSV:";
            label_MaTaiKhoan.Click += label_MaTaiKhoan_Click;
            // 
            // label_TenTaiKhoan
            // 
            label_TenTaiKhoan.AutoSize = true;
            label_TenTaiKhoan.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TenTaiKhoan.Location = new Point(36, 398);
            label_TenTaiKhoan.Name = "label_TenTaiKhoan";
            label_TenTaiKhoan.Size = new Size(97, 32);
            label_TenTaiKhoan.TabIndex = 2;
            label_TenTaiKhoan.Text = "Họ Tên:";
            // 
            // label_Email
            // 
            label_Email.AutoSize = true;
            label_Email.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Email.Location = new Point(36, 464);
            label_Email.Name = "label_Email";
            label_Email.Size = new Size(78, 32);
            label_Email.TabIndex = 3;
            label_Email.Text = "Email:";
            // 
            // label_MatKhau
            // 
            label_MatKhau.AutoSize = true;
            label_MatKhau.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MatKhau.Location = new Point(36, 533);
            label_MatKhau.Name = "label_MatKhau";
            label_MatKhau.Size = new Size(127, 32);
            label_MatKhau.TabIndex = 4;
            label_MatKhau.Text = "Mật Khẩu:";
            // 
            // label_NhapLaiMK
            // 
            label_NhapLaiMK.AutoSize = true;
            label_NhapLaiMK.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_NhapLaiMK.Location = new Point(36, 602);
            label_NhapLaiMK.Name = "label_NhapLaiMK";
            label_NhapLaiMK.Size = new Size(117, 32);
            label_NhapLaiMK.TabIndex = 5;
            label_NhapLaiMK.Text = "Nhập Lại:";
            label_NhapLaiMK.Click += label_NhapLaiMK_Click;
            // 
            // textBox_MaTaiKhoan
            // 
            textBox_MaTaiKhoan.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_MaTaiKhoan.Location = new Point(188, 311);
            textBox_MaTaiKhoan.Multiline = true;
            textBox_MaTaiKhoan.Name = "textBox_MaTaiKhoan";
            textBox_MaTaiKhoan.Size = new Size(385, 47);
            textBox_MaTaiKhoan.TabIndex = 6;
            // 
            // textBox_HoTen
            // 
            textBox_HoTen.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_HoTen.Location = new Point(188, 383);
            textBox_HoTen.Multiline = true;
            textBox_HoTen.Name = "textBox_HoTen";
            textBox_HoTen.Size = new Size(385, 47);
            textBox_HoTen.TabIndex = 7;
            // 
            // textBox_Email
            // 
            textBox_Email.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_Email.Location = new Point(188, 449);
            textBox_Email.Multiline = true;
            textBox_Email.Name = "textBox_Email";
            textBox_Email.Size = new Size(385, 47);
            textBox_Email.TabIndex = 8;
            // 
            // textBox_MatKhau
            // 
            textBox_MatKhau.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_MatKhau.Location = new Point(188, 518);
            textBox_MatKhau.Multiline = true;
            textBox_MatKhau.Name = "textBox_MatKhau";
            textBox_MatKhau.Size = new Size(385, 47);
            textBox_MatKhau.TabIndex = 9;
            // 
            // textBox_NhapLaiMK
            // 
            textBox_NhapLaiMK.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_NhapLaiMK.Location = new Point(188, 587);
            textBox_NhapLaiMK.Multiline = true;
            textBox_NhapLaiMK.Name = "textBox_NhapLaiMK";
            textBox_NhapLaiMK.Size = new Size(385, 47);
            textBox_NhapLaiMK.TabIndex = 10;
            // 
            // pictureBox_MSSV
            // 
            pictureBox_MSSV.Image = (Image)resources.GetObject("pictureBox_MSSV.Image");
            pictureBox_MSSV.Location = new Point(593, 311);
            pictureBox_MSSV.Name = "pictureBox_MSSV";
            pictureBox_MSSV.Size = new Size(53, 47);
            pictureBox_MSSV.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_MSSV.TabIndex = 11;
            pictureBox_MSSV.TabStop = false;
            // 
            // pictureBox_HoTen
            // 
            pictureBox_HoTen.Image = (Image)resources.GetObject("pictureBox_HoTen.Image");
            pictureBox_HoTen.Location = new Point(593, 383);
            pictureBox_HoTen.Name = "pictureBox_HoTen";
            pictureBox_HoTen.Size = new Size(53, 47);
            pictureBox_HoTen.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_HoTen.TabIndex = 12;
            pictureBox_HoTen.TabStop = false;
            // 
            // pictureBox_Email
            // 
            pictureBox_Email.Image = (Image)resources.GetObject("pictureBox_Email.Image");
            pictureBox_Email.Location = new Point(579, 436);
            pictureBox_Email.Name = "pictureBox_Email";
            pictureBox_Email.Size = new Size(78, 76);
            pictureBox_Email.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Email.TabIndex = 13;
            pictureBox_Email.TabStop = false;
            // 
            // pictureBox_MatKhau
            // 
            pictureBox_MatKhau.Image = (Image)resources.GetObject("pictureBox_MatKhau.Image");
            pictureBox_MatKhau.Location = new Point(593, 518);
            pictureBox_MatKhau.Name = "pictureBox_MatKhau";
            pictureBox_MatKhau.Size = new Size(53, 47);
            pictureBox_MatKhau.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_MatKhau.TabIndex = 14;
            pictureBox_MatKhau.TabStop = false;
            // 
            // pictureBox_NhapLaiMK
            // 
            pictureBox_NhapLaiMK.Image = (Image)resources.GetObject("pictureBox_NhapLaiMK.Image");
            pictureBox_NhapLaiMK.Location = new Point(593, 587);
            pictureBox_NhapLaiMK.Name = "pictureBox_NhapLaiMK";
            pictureBox_NhapLaiMK.Size = new Size(53, 47);
            pictureBox_NhapLaiMK.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_NhapLaiMK.TabIndex = 15;
            pictureBox_NhapLaiMK.TabStop = false;
            // 
            // button_DangKy
            // 
            button_DangKy.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_DangKy.Location = new Point(36, 653);
            button_DangKy.Name = "button_DangKy";
            button_DangKy.Size = new Size(610, 70);
            button_DangKy.TabIndex = 16;
            button_DangKy.Text = "ĐĂNG KÝ";
            button_DangKy.UseVisualStyleBackColor = true;
            // 
            // label_TitleDangNhap
            // 
            label_TitleDangNhap.AutoSize = true;
            label_TitleDangNhap.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TitleDangNhap.ForeColor = Color.IndianRed;
            label_TitleDangNhap.Location = new Point(36, 747);
            label_TitleDangNhap.Name = "label_TitleDangNhap";
            label_TitleDangNhap.Size = new Size(251, 32);
            label_TitleDangNhap.TabIndex = 17;
            label_TitleDangNhap.Text = "Bạn đã có tài khoản ?";
            // 
            // button_DangNhap
            // 
            button_DangNhap.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_DangNhap.ForeColor = Color.Red;
            button_DangNhap.Location = new Point(293, 739);
            button_DangNhap.Name = "button_DangNhap";
            button_DangNhap.Size = new Size(196, 48);
            button_DangNhap.TabIndex = 18;
            button_DangNhap.Text = "Đăng nhập";
            button_DangNhap.UseVisualStyleBackColor = true;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(684, 861);
            Controls.Add(button_DangNhap);
            Controls.Add(label_TitleDangNhap);
            Controls.Add(button_DangKy);
            Controls.Add(pictureBox_NhapLaiMK);
            Controls.Add(pictureBox_MatKhau);
            Controls.Add(pictureBox_Email);
            Controls.Add(pictureBox_HoTen);
            Controls.Add(pictureBox_MSSV);
            Controls.Add(textBox_NhapLaiMK);
            Controls.Add(textBox_MatKhau);
            Controls.Add(textBox_Email);
            Controls.Add(textBox_HoTen);
            Controls.Add(textBox_MaTaiKhoan);
            Controls.Add(label_NhapLaiMK);
            Controls.Add(label_MatKhau);
            Controls.Add(label_Email);
            Controls.Add(label_TenTaiKhoan);
            Controls.Add(label_MaTaiKhoan);
            Controls.Add(pictureBox_Logo);
            Name = "SignUp";
            Text = "DangKy";
            Load += SignUp_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MSSV).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_HoTen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Email).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_MatKhau).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_NhapLaiMK).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_Logo;
        private Label label_MaTaiKhoan;
        private Label label_TenTaiKhoan;
        private Label label_Email;
        private Label label_MatKhau;
        private Label label_NhapLaiMK;
        private TextBox textBox_MaTaiKhoan;
        private TextBox textBox_HoTen;
        private TextBox textBox_Email;
        private TextBox textBox_MatKhau;
        private TextBox textBox_NhapLaiMK;
        private PictureBox pictureBox_MSSV;
        private PictureBox pictureBox_HoTen;
        private PictureBox pictureBox_Email;
        private PictureBox pictureBox_MatKhau;
        private PictureBox pictureBox_NhapLaiMK;
        private Button button_DangKy;
        private Label label_TitleDangNhap;
        private Button button_DangNhap;
    }
}