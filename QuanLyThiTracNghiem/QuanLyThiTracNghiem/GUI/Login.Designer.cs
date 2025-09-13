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
            btnLogin = new Button();
            btnSignUp = new Button();
            lblTitle = new Label();
            lblMa = new Label();
            lblPassword = new Label();
            lblKhongCoTaiKhoan = new Label();
            txtMa = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 16.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(101, 297);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(227, 61);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignUp.Location = new Point(240, 388);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(135, 50);
            btnSignUp.TabIndex = 1;
            btnSignUp.Text = "Đăng ký";
            btnSignUp.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(101, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(227, 46);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "ĐĂNG NHẬP";
            // 
            // lblMa
            // 
            lblMa.AutoSize = true;
            lblMa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMa.Location = new Point(12, 98);
            lblMa.Name = "lblMa";
            lblMa.Size = new Size(125, 28);
            lblMa.TabIndex = 3;
            lblMa.Text = "Mã sinh viên:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(12, 185);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(98, 28);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Mật khẩu:";
            // 
            // lblKhongCoTaiKhoan
            // 
            lblKhongCoTaiKhoan.AutoSize = true;
            lblKhongCoTaiKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKhongCoTaiKhoan.Location = new Point(43, 402);
            lblKhongCoTaiKhoan.Name = "lblKhongCoTaiKhoan";
            lblKhongCoTaiKhoan.Size = new Size(167, 23);
            lblKhongCoTaiKhoan.TabIndex = 7;
            lblKhongCoTaiKhoan.Text = "Không có tài khoản?";
            // 
            // txtMa
            // 
            txtMa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMa.Location = new Point(143, 96);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(253, 30);
            txtMa.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(143, 183);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(253, 30);
            txtPassword.TabIndex = 6;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 502);
            Controls.Add(lblKhongCoTaiKhoan);
            Controls.Add(txtPassword);
            Controls.Add(txtMa);
            Controls.Add(lblPassword);
            Controls.Add(lblMa);
            Controls.Add(lblTitle);
            Controls.Add(btnSignUp);
            Controls.Add(btnLogin);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnSignUp;
        private Label lblTitle;
        private Label lblMa;
        private Label lblPassword;
        private TextBox txtMa;
        private TextBox txtPassword;
        private Label lblKhongCoTaiKhoan;
    }
}