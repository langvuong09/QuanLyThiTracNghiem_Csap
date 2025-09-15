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
            lblTitle = new Label();
            lblMa = new Label();
            lblTen = new Label();
            lblEmail = new Label();
            lblMatKhau = new Label();
            lblNhapLai = new Label();
            lblQuenMK = new Label();
            lblCoTaiKhoan = new Label();
            btnDangKy = new Button();
            txtMa = new TextBox();
            txtTen = new TextBox();
            txtEmail = new TextBox();
            txtMatKhau = new TextBox();
            txtNhapLai = new TextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(174, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(172, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ";
            // 
            // lblMa
            // 
            lblMa.AutoSize = true;
            lblMa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMa.Location = new Point(12, 101);
            lblMa.Name = "lblMa";
            lblMa.Size = new Size(125, 28);
            lblMa.TabIndex = 1;
            lblMa.Text = "Mã sinh viên:";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTen.Location = new Point(12, 157);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(100, 28);
            lblTen.TabIndex = 2;
            lblTen.Text = "Họ và tên:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(12, 216);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 28);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatKhau.Location = new Point(12, 271);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(98, 28);
            lblMatKhau.TabIndex = 4;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // lblNhapLai
            // 
            lblNhapLai.AutoSize = true;
            lblNhapLai.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNhapLai.Location = new Point(12, 329);
            lblNhapLai.Name = "lblNhapLai";
            lblNhapLai.Size = new Size(175, 28);
            lblNhapLai.TabIndex = 5;
            lblNhapLai.Text = "Nhập lại mật khẩu:";
            // 
            // lblQuenMK
            // 
            lblQuenMK.AutoSize = true;
            lblQuenMK.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuenMK.Location = new Point(42, 530);
            lblQuenMK.Name = "lblQuenMK";
            lblQuenMK.Size = new Size(154, 28);
            lblQuenMK.TabIndex = 6;
            lblQuenMK.Text = "Quên mật khẩu?";
            lblQuenMK.MouseEnter += lblQuenMK_MouseEnter;
            lblQuenMK.MouseLeave += lblQuenMK_MouseLeave;
            // 
            // lblCoTaiKhoan
            // 
            lblCoTaiKhoan.AutoSize = true;
            lblCoTaiKhoan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCoTaiKhoan.Location = new Point(324, 530);
            lblCoTaiKhoan.Name = "lblCoTaiKhoan";
            lblCoTaiKhoan.Size = new Size(157, 28);
            lblCoTaiKhoan.TabIndex = 7;
            lblCoTaiKhoan.Text = "Đã có tài khoản?";
            lblCoTaiKhoan.MouseEnter += lblCoTaiKhoan_MouseEnter;
            lblCoTaiKhoan.MouseLeave += lblCoTaiKhoan_MouseLeave;
            // 
            // btnDangKy
            // 
            btnDangKy.Font = new Font("Segoe UI", 16.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangKy.Location = new Point(174, 430);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(174, 57);
            btnDangKy.TabIndex = 8;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            // 
            // txtMa
            // 
            txtMa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMa.Location = new Point(190, 99);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(313, 30);
            txtMa.TabIndex = 9;
            // 
            // txtTen
            // 
            txtTen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTen.Location = new Point(190, 155);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(313, 30);
            txtTen.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(190, 214);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(313, 30);
            txtEmail.TabIndex = 11;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(190, 269);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(313, 30);
            txtMatKhau.TabIndex = 12;
            // 
            // txtNhapLai
            // 
            txtNhapLai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNhapLai.Location = new Point(190, 327);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.Size = new Size(313, 30);
            txtNhapLai.TabIndex = 13;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 610);
            Controls.Add(txtNhapLai);
            Controls.Add(txtMatKhau);
            Controls.Add(txtEmail);
            Controls.Add(txtTen);
            Controls.Add(txtMa);
            Controls.Add(btnDangKy);
            Controls.Add(lblCoTaiKhoan);
            Controls.Add(lblQuenMK);
            Controls.Add(lblNhapLai);
            Controls.Add(lblMatKhau);
            Controls.Add(lblEmail);
            Controls.Add(lblTen);
            Controls.Add(lblMa);
            Controls.Add(lblTitle);
            Name = "SignUp";
            Text = "SignUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblMa;
        private Label lblTen;
        private Label lblEmail;
        private Label lblMatKhau;
        private Label lblNhapLai;
        private Label lblQuenMK;
        private Label lblCoTaiKhoan;
        private Button btnDangKy;
        private TextBox txtMa;
        private TextBox txtTen;
        private TextBox txtEmail;
        private TextBox txtMatKhau;
        private TextBox txtNhapLai;
    }
}