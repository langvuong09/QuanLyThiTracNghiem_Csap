namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Dialog_XemThongTinHocPhan
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
            dataGridViewCellStyle1 = new DataGridViewCellStyle();
            colmaDe = new DataGridViewTextBoxColumn();
            coltgBatDau = new DataGridViewTextBoxColumn();
            coltgKetThuc = new DataGridViewTextBoxColumn();
            colTongDiem = new DataGridViewTextBoxColumn();
            lblTitle = new Label();
            lblMonHoc = new Label();
            lblNhom = new Label();
            lblGiangVien = new Label();
            lblTongBaiKiemTra = new Label();
            dgvBaiKiemTra = new DataGridView();
            lblDeKiemTra = new Label();
            txtMonHoc = new TextBox();
            txtNhom = new TextBox();
            txtGiangVien = new TextBox();
            txtTongbaiKiemTra = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvBaiKiemTra).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(487, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(199, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN";
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonHoc.Location = new Point(41, 67);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(113, 30);
            lblMonHoc.TabIndex = 1;
            lblMonHoc.Text = "Môn học: ";
            // 
            // lblNhom
            // 
            lblNhom.AutoSize = true;
            lblNhom.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNhom.Location = new Point(41, 108);
            lblNhom.Name = "lblNhom";
            lblNhom.Size = new Size(87, 30);
            lblNhom.TabIndex = 2;
            lblNhom.Text = "Nhóm: ";
            // 
            // lblGiangVien
            // 
            lblGiangVien.AutoSize = true;
            lblGiangVien.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGiangVien.Location = new Point(573, 67);
            lblGiangVien.Name = "lblGiangVien";
            lblGiangVien.Size = new Size(124, 30);
            lblGiangVien.TabIndex = 3;
            lblGiangVien.Text = "Giảng viên:";
            // 
            // lblTongBaiKiemTra
            // 
            lblTongBaiKiemTra.AutoSize = true;
            lblTongBaiKiemTra.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongBaiKiemTra.Location = new Point(573, 108);
            lblTongBaiKiemTra.Name = "lblTongBaiKiemTra";
            lblTongBaiKiemTra.Size = new Size(193, 30);
            lblTongBaiKiemTra.TabIndex = 4;
            lblTongBaiKiemTra.Text = "Tổng bài kiểm tra:";
            // 
            // dgvBaiKiemTra
            // 
            dgvBaiKiemTra.AllowUserToAddRows = false;
            dgvBaiKiemTra.AllowUserToDeleteRows = false;
            dgvBaiKiemTra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaiKiemTra.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(101, 224, 199);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvBaiKiemTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBaiKiemTra.ColumnHeadersHeight = 29;
            dgvBaiKiemTra.Columns.AddRange(new DataGridViewColumn[] {colmaDe, coltgBatDau, coltgKetThuc, colTongDiem });
            dgvBaiKiemTra.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#9BBCFF");           
            dgvBaiKiemTra.EnableHeadersVisualStyles = false;
            dgvBaiKiemTra.Location = new Point(3, 210);
            dgvBaiKiemTra.MultiSelect = false;
            dgvBaiKiemTra.Name = "dgvBaiKiemTra";
            dgvBaiKiemTra.ReadOnly = true;
            dgvBaiKiemTra.RowHeadersWidth = 51;
            dgvBaiKiemTra.Size = new Size(1176, 493);
            dgvBaiKiemTra.TabIndex = 5;
            // 
            // colmaDe
            // 
            colmaDe.HeaderText = "Mã đề";
            colmaDe.MinimumWidth = 200;
            colmaDe.Name = "colmaDe";
            colmaDe.ReadOnly = false;
            // 
            // coltgBatDau
            // 
            coltgBatDau.HeaderText = "Thời gian bắt đầu";
            coltgBatDau.MinimumWidth = 360;
            coltgBatDau.Name = "coltgBatDau";
            coltgBatDau.ReadOnly = false;
            // 
            // coltgKetThuc
            // 
            coltgKetThuc.HeaderText = "Thời gian kết thúc";
            coltgKetThuc.MinimumWidth = 360;
            coltgKetThuc.Name = "coltgKetThuc";
            coltgKetThuc.ReadOnly = false;
            // 
            // colTongDiem
            // 
            colTongDiem.HeaderText = "Tổng điểm";
            colTongDiem.MinimumWidth = 210;
            colTongDiem.Name = "colTongDiem";
            colTongDiem.ReadOnly = false;
            // 
            // lblDeKiemTra
            // 
            lblDeKiemTra.AutoSize = true;
            lblDeKiemTra.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeKiemTra.Location = new Point(450, 167);
            lblDeKiemTra.Name = "lblDeKiemTra";
            lblDeKiemTra.Size = new Size(275, 30);
            lblDeKiemTra.TabIndex = 6;
            lblDeKiemTra.Text = "DANH SÁCH ĐỀ KIỂM TRA";
            // 
            // txtMonHoc
            // 
            txtMonHoc.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMonHoc.Location = new Point(160, 63);
            txtMonHoc.Name = "txtMonHoc";
            txtMonHoc.Enabled = false;
            txtMonHoc.Size = new Size(337, 34);
            txtMonHoc.TabIndex = 7;
            // 
            // txtNhom
            // 
            txtNhom.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNhom.Location = new Point(160, 104);
            txtNhom.Name = "txtNhom";
            txtNhom.Enabled = false;
            txtNhom.Size = new Size(337, 34);
            txtNhom.TabIndex = 8;
            // 
            // txtGiangVien
            // 
            txtGiangVien.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGiangVien.Location = new Point(788, 63);
            txtGiangVien.Name = "txtGiangVien";
            txtGiangVien.Enabled = false;
            txtGiangVien.Size = new Size(330, 34);
            txtGiangVien.TabIndex = 9;
            // 
            // txtTongbaiKiemTra
            // 
            txtTongbaiKiemTra.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTongbaiKiemTra.Location = new Point(788, 106);
            txtTongbaiKiemTra.Name = "txtTongbaiKiemTra";
            txtTongbaiKiemTra.Enabled = false;
            txtTongbaiKiemTra.Size = new Size(330, 34);
            txtTongbaiKiemTra.TabIndex = 10;
            // 
            // Dialog_XemThongTinHocPhan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtTongbaiKiemTra);
            Controls.Add(txtGiangVien);
            Controls.Add(txtNhom);
            Controls.Add(txtMonHoc);
            Controls.Add(lblDeKiemTra);
            Controls.Add(dgvBaiKiemTra);
            Controls.Add(lblTongBaiKiemTra);
            Controls.Add(lblGiangVien);
            Controls.Add(lblNhom);
            Controls.Add(lblMonHoc);
            Controls.Add(lblTitle);
            Name = "Dialog_XemThongTinHocPhan";
            Size = new Size(1182, 706);
            ((System.ComponentModel.ISupportInitialize)dgvBaiKiemTra).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridViewCellStyle dataGridViewCellStyle1;
        private DataGridViewTextBoxColumn colmaDe;
        private DataGridViewTextBoxColumn coltgBatDau;  
        private DataGridViewTextBoxColumn coltgKetThuc;  
        private DataGridViewTextBoxColumn colTongDiem;  
        private Label lblTitle;
        private Label lblMonHoc;
        private Label lblNhom;
        private Label lblGiangVien;
        private Label lblTongBaiKiemTra;
        private DataGridView dgvBaiKiemTra;
        private Label lblDeKiemTra;
        private TextBox txtMonHoc;
        private TextBox txtNhom;
        private TextBox txtGiangVien;
        private TextBox txtTongbaiKiemTra;
    }
}
