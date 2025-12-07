using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Dialog_XemDSSVNhom
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            colSTT = new DataGridViewTextBoxColumn();
            colMaSV = new DataGridViewTextBoxColumn();
            colTenSV = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colGioiTinh = new DataGridViewTextBoxColumn();
            colNgaySinh = new DataGridViewTextBoxColumn();
            lblTitle = new Label();
            btnTimKiem = new Button();
            txtTimKIem = new TextBox();
            btnXuat = new Button();
            txtMaSV = new TextBox();
            btnThem = new Button();
            lblMaSV = new Label();
            dgvSinhVien = new DataGridView();
            btnXoaSV = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // colSTT
            // 
            colSTT.HeaderText = "STT";
            colSTT.MinimumWidth = 70;
            colSTT.Name = "colSTT";
            colSTT.ReadOnly = true;
            colSTT.Width = 70;
            // 
            // colMaSV
            // 
            colMaSV.HeaderText = "MSSV";
            colMaSV.MinimumWidth = 100;
            colMaSV.Name = "colMaSV";
            colMaSV.ReadOnly = true;
            // 
            // colTenSV
            // 
            colTenSV.HeaderText = "Họ và tên";
            colTenSV.MinimumWidth = 205;
            colTenSV.Name = "colTenSV";
            colTenSV.ReadOnly = true;
            colTenSV.Width = 205;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 150;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 350;
            // 
            // colGioiTinh
            // 
            colGioiTinh.HeaderText = "Giới tính";
            colGioiTinh.MinimumWidth = 100;
            colGioiTinh.Name = "colGioiTinh";
            colGioiTinh.ReadOnly = true;
            // 
            // colNgaySinh
            // 
            colNgaySinh.HeaderText = "Ngày sinh";
            colNgaySinh.MinimumWidth = 200;
            colNgaySinh.Name = "colNgaySinh";
            colNgaySinh.ReadOnly = true;
            colNgaySinh.Width = 200;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(382, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(339, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "DANH SÁCH SINH VIÊN";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = SystemColors.Control;
            btnTimKiem.Location = new Point(288, 63);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(117, 46);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKIem
            // 
            txtTimKIem.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKIem.Location = new Point(30, 68);
            txtTimKIem.Name = "txtTimKIem";
            txtTimKIem.Size = new Size(252, 35);
            txtTimKIem.TabIndex = 2;
            // 
            // btnXuat
            // 
            btnXuat.BackColor = SystemColors.ActiveCaption;
            btnXuat.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuat.ForeColor = SystemColors.Control;
            btnXuat.Location = new Point(930, 120);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(157, 46);
            btnXuat.TabIndex = 3;
            btnXuat.Text = "Xuất dữ liệu";
            btnXuat.UseVisualStyleBackColor = false;
            // 
            // txtMaSV
            // 
            txtMaSV.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaSV.Location = new Point(584, 68);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(370, 35);
            txtMaSV.TabIndex = 5;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ActiveCaption;
            btnThem.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.Control;
            btnThem.Location = new Point(975, 63);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 46);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm SV";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // lblMaSV
            // 
            lblMaSV.AutoSize = true;
            lblMaSV.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaSV.Location = new Point(477, 73);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(82, 30);
            lblMaSV.TabIndex = 6;
            lblMaSV.Text = "Mã SV:";
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(155, 188, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvSinhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { colSTT, colMaSV, colTenSV, colEmail, colGioiTinh, colNgaySinh });
            dgvSinhVien.EnableHeadersVisualStyles = false;
            dgvSinhVien.Location = new Point(30, 177);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersWidth = 30;
            dgvSinhVien.Size = new Size(1057, 554);
            dgvSinhVien.TabIndex = 7;
            // 
            // btnXoaSV
            // 
            btnXoaSV.BackColor = SystemColors.ActiveCaption;
            btnXoaSV.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaSV.ForeColor = SystemColors.Control;
            btnXoaSV.Location = new Point(768, 120);
            btnXoaSV.Name = "btnXoaSV";
            btnXoaSV.Size = new Size(135, 46);
            btnXoaSV.TabIndex = 8;
            btnXoaSV.Text = "Xóa SV";
            btnXoaSV.UseVisualStyleBackColor = false;
            // 
            // Dialog_XemDSSVNhom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnXoaSV);
            Controls.Add(dgvSinhVien);
            Controls.Add(lblMaSV);
            Controls.Add(txtMaSV);
            Controls.Add(btnThem);
            Controls.Add(btnXuat);
            Controls.Add(txtTimKIem);
            Controls.Add(btnTimKiem);
            Controls.Add(lblTitle);
            Name = "Dialog_XemDSSVNhom";
            Size = new Size(1121, 734);
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridViewCellStyle dataGridViewCellStyle1;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colMaSV;
        private DataGridViewTextBoxColumn colTenSV;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colGioiTinh;
        private DataGridViewTextBoxColumn colNgaySinh;
        private Label lblTitle;
        private Button btnTimKiem;
        private TextBox txtTimKIem;
        private Button btnXuat;
        private TextBox txtMaSV;
        private Button btnThem;
        private Label lblMaSV;
        private DataGridView dgvSinhVien;
        private Button btnXoaSV;
    }
}
