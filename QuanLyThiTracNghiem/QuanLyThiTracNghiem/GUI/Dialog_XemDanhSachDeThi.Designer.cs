using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Dialog_XemDanhSachDeThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_XemDanhSachDeThi));
            colMaDe = new DataGridViewTextBoxColumn();
            colTenDe = new DataGridViewTextBoxColumn();
            coltgBatDau = new DataGridViewTextBoxColumn();
            coltgKetThuc = new DataGridViewTextBoxColumn();
            colTongSinhVienLam = new DataGridViewTextBoxColumn();
            colMaSV = new DataGridViewTextBoxColumn();
            colTenSV = new DataGridViewTextBoxColumn();
            colDiem = new DataGridViewTextBoxColumn();
            coltgBDau = new DataGridViewTextBoxColumn();
            coltgNopBai = new DataGridViewTextBoxColumn();
            lblTitle = new Label();
            txtTimKiem = new TextBox();
            dgvDanhSachDeThi = new DataGridView();
            btnTimKiem = new Button();
            btnXem = new Button();
            dgvSinhVien = new DataGridView();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachDeThi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // colMaDe
            // 
            colMaDe.HeaderText = "Mã đề";
            colMaDe.MinimumWidth = 100;
            colMaDe.Name = "colMaDe";
            colMaDe.ReadOnly = true;
            colMaDe.Width = 147;
            // 
            // colTenDe
            // 
            colTenDe.HeaderText = "Tên đề";
            colTenDe.MinimumWidth = 200;
            colTenDe.Name = "colTenDe";
            colTenDe.ReadOnly = true;
            colTenDe.Width = 250;
            // 
            // coltgBatDau
            // 
            coltgBatDau.HeaderText = "Thời gian bắt đầu";
            coltgBatDau.MinimumWidth = 200;
            coltgBatDau.Name = "coltgBatDau";
            coltgBatDau.ReadOnly = true;
            coltgBatDau.Width = 330;
            // 
            // coltgKetThuc
            // 
            coltgKetThuc.HeaderText = "Thời gian kết thúc";
            coltgKetThuc.MinimumWidth = 200;
            coltgKetThuc.Name = "coltgKetThuc";
            coltgKetThuc.ReadOnly = true;
            coltgKetThuc.Width = 330;
            // 
            // colTongSinhVienLam
            // 
            colTongSinhVienLam.HeaderText = "Số lượng làm bài";
            colTongSinhVienLam.MinimumWidth = 150;
            colTongSinhVienLam.Name = "colTongSinhVienLam";
            colTongSinhVienLam.ReadOnly = true;
            colTongSinhVienLam.Width = 200;
            // 
            // colMaSV
            // 
            colMaSV.HeaderText = "MSSV";
            colMaSV.MinimumWidth = 150;
            colMaSV.Name = "colMaSV";
            colMaSV.ReadOnly = true;
            colMaSV.Width = 200;
            // 
            // colTenSV
            // 
            colTenSV.HeaderText = "Họ và tên";
            colTenSV.MinimumWidth = 300;
            colTenSV.Name = "colTenSV";
            colTenSV.ReadOnly = true;
            colTenSV.Width = 300;
            // 
            // colDiem
            // 
            colDiem.HeaderText = "Điểm";
            colDiem.MinimumWidth = 150;
            colDiem.Name = "colDiem";
            colDiem.ReadOnly = true;
            colDiem.Width = 157;
            // 
            // coltgBDau
            // 
            coltgBDau.HeaderText = "Thời gian bắt đầu";
            coltgBDau.MinimumWidth = 300;
            coltgBDau.Name = "coltgBDau";
            coltgBDau.ReadOnly = true;
            coltgBDau.Width = 300;
            // 
            // coltgNopBai
            // 
            coltgNopBai.HeaderText = "Thời gian nộp bài";
            coltgNopBai.MinimumWidth = 290;
            coltgNopBai.Name = "coltgNopBai";
            coltgNopBai.ReadOnly = true;
            coltgNopBai.Width = 300;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(457, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(374, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "DANH SÁCH ĐỀ KIỂM TRA";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(385, 72);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(406, 35);
            txtTimKiem.TabIndex = 2;
            // 
            // dgvDanhSachDeThi
            // 
            dgvDanhSachDeThi.AllowUserToAddRows = false;
            dgvDanhSachDeThi.AllowUserToDeleteRows = false;
            dgvDanhSachDeThi.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(155, 188, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvDanhSachDeThi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDanhSachDeThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachDeThi.Columns.AddRange(new DataGridViewColumn[] { colMaDe, colTenDe, coltgBatDau, coltgKetThuc, colTongSinhVienLam });
            dgvDanhSachDeThi.EnableHeadersVisualStyles = false;
            dgvDanhSachDeThi.Location = new Point(3, 140);
            dgvDanhSachDeThi.MultiSelect = false;
            dgvDanhSachDeThi.Name = "dgvDanhSachDeThi";
            dgvDanhSachDeThi.ReadOnly = true;
            dgvDanhSachDeThi.RowHeadersWidth = 51;
            dgvDanhSachDeThi.Size = new Size(1310, 537);
            dgvDanhSachDeThi.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = SystemColors.Control;
            btnTimKiem.Location = new Point(797, 68);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(136, 45);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.LightBlue;
            btnXem.BackgroundImage = (Image)resources.GetObject("btnXem.BackgroundImage");
            btnXem.BackgroundImageLayout = ImageLayout.Center;
            btnXem.Location = new Point(289, 65);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(62, 48);
            btnXem.TabIndex = 15;
            btnXem.UseVisualStyleBackColor = false;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.BackgroundColor = SystemColors.ButtonFace;
            dgvSinhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { colMaSV, colTenSV, colDiem, coltgBDau, coltgNopBai });
            dgvSinhVien.EnableHeadersVisualStyles = false;
            dgvSinhVien.Location = new Point(3, 140);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.Size = new Size(1310, 537);
            dgvSinhVien.TabIndex = 16;
            dgvSinhVien.Visible = false;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.LightBlue;
            btnReturn.BackgroundImage = (Image)resources.GetObject("btnReturn.BackgroundImage");
            btnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            btnReturn.Location = new Point(289, 65);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(62, 48);
            btnReturn.TabIndex = 17;
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Visible = false;
            // 
            // Dialog_XemDanhSachDeThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnReturn);
            Controls.Add(dgvSinhVien);
            Controls.Add(btnXem);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvDanhSachDeThi);
            Controls.Add(txtTimKiem);
            Controls.Add(lblTitle);
            Name = "Dialog_XemDanhSachDeThi";
            Size = new Size(1316, 680);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachDeThi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridViewCellStyle dataGridViewCellStyle1;
        private DataGridViewTextBoxColumn colMaDe;
        private DataGridViewTextBoxColumn colTenDe;
        private DataGridViewTextBoxColumn coltgBatDau;
        private DataGridViewTextBoxColumn coltgKetThuc;
        private DataGridViewTextBoxColumn colTongSinhVienLam;
        private DataGridViewTextBoxColumn colMaSV;
        private DataGridViewTextBoxColumn colTenSV;
        private DataGridViewTextBoxColumn colDiem;
        private DataGridViewTextBoxColumn coltgBDau;
        private DataGridViewTextBoxColumn coltgNopBai;
        private Label lblTitle;
        private TextBox txtTimKiem;
        private DataGridView dgvDanhSachDeThi;
        private Button btnTimKiem;
        private Button btnXem;
        private DataGridView dgvSinhVien;
        private Button btnReturn;
    }
}
