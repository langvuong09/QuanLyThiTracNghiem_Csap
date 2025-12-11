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
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(70, 130, 180);
            lblTitle.Location = new Point(487, 15);
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(230, 51);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN";
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonHoc.ForeColor = Color.FromArgb(70, 130, 180);
            lblMonHoc.Location = new Point(48, 85);
            lblMonHoc.Margin = new Padding(0);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(120, 30);
            lblMonHoc.TabIndex = 1;
            lblMonHoc.Text = "Môn học: ";
            // 
            // lblNhom
            // 
            lblNhom.AutoSize = true;
            lblNhom.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNhom.ForeColor = Color.FromArgb(70, 130, 180);
            lblNhom.Location = new Point(48, 135);
            lblNhom.Margin = new Padding(0);
            lblNhom.Name = "lblNhom";
            lblNhom.Size = new Size(92, 30);
            lblNhom.TabIndex = 2;
            lblNhom.Text = "Nhóm: ";
            // 
            // lblGiangVien
            // 
            lblGiangVien.AutoSize = true;
            lblGiangVien.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGiangVien.ForeColor = Color.FromArgb(70, 130, 180);
            lblGiangVien.Location = new Point(580, 85);
            lblGiangVien.Margin = new Padding(0);
            lblGiangVien.Name = "lblGiangVien";
            lblGiangVien.Size = new Size(130, 30);
            lblGiangVien.TabIndex = 3;
            lblGiangVien.Text = "Giảng viên:";
            // 
            // lblTongBaiKiemTra
            // 
            lblTongBaiKiemTra.AutoSize = true;
            lblTongBaiKiemTra.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongBaiKiemTra.ForeColor = Color.FromArgb(70, 130, 180);
            lblTongBaiKiemTra.Location = new Point(580, 135);
            lblTongBaiKiemTra.Margin = new Padding(0);
            lblTongBaiKiemTra.Name = "lblTongBaiKiemTra";
            lblTongBaiKiemTra.Size = new Size(200, 30);
            lblTongBaiKiemTra.TabIndex = 4;
            lblTongBaiKiemTra.Text = "Tổng bài kiểm tra:";
            // 
            // dgvBaiKiemTra
            // 
            dgvBaiKiemTra.AllowUserToAddRows = false;
            dgvBaiKiemTra.AllowUserToDeleteRows = false;
            dgvBaiKiemTra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaiKiemTra.BackgroundColor = Color.White;
            dgvBaiKiemTra.BorderStyle = BorderStyle.None;
            dgvBaiKiemTra.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(70, 130, 180);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(10, 5, 10, 5);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(70, 130, 180);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBaiKiemTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBaiKiemTra.ColumnHeadersHeight = 45;
            dgvBaiKiemTra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBaiKiemTra.Columns.AddRange(new DataGridViewColumn[] {colmaDe, coltgBatDau, coltgKetThuc, colTongDiem });
            dgvBaiKiemTra.EnableHeadersVisualStyles = false;
            dgvBaiKiemTra.GridColor = Color.FromArgb(230, 230, 235);
            dgvBaiKiemTra.Location = new Point(8, 250);
            dgvBaiKiemTra.Margin = new Padding(0);
            dgvBaiKiemTra.MultiSelect = false;
            dgvBaiKiemTra.Name = "dgvBaiKiemTra";
            dgvBaiKiemTra.ReadOnly = true;
            dgvBaiKiemTra.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBaiKiemTra.RowHeadersWidth = 51;
            dgvBaiKiemTra.RowTemplate.Height = 35;
            dgvBaiKiemTra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaiKiemTra.Size = new Size(1166, 493);
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
            lblDeKiemTra.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeKiemTra.ForeColor = Color.FromArgb(70, 130, 180);
            lblDeKiemTra.Location = new Point(450, 200);
            lblDeKiemTra.Margin = new Padding(0);
            lblDeKiemTra.Name = "lblDeKiemTra";
            lblDeKiemTra.Size = new Size(310, 32);
            lblDeKiemTra.TabIndex = 6;
            lblDeKiemTra.Text = "DANH SÁCH ĐỀ KIỂM TRA";
            // 
            // txtMonHoc
            // 
            txtMonHoc.BackColor = Color.White;
            txtMonHoc.BorderStyle = BorderStyle.FixedSingle;
            txtMonHoc.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMonHoc.Location = new Point(168, 80);
            txtMonHoc.Margin = new Padding(0);
            txtMonHoc.Name = "txtMonHoc";
            txtMonHoc.Enabled = false;
            txtMonHoc.Padding = new Padding(8);
            txtMonHoc.Size = new Size(337, 40);
            txtMonHoc.TabIndex = 7;
            // 
            // txtNhom
            // 
            txtNhom.BackColor = Color.White;
            txtNhom.BorderStyle = BorderStyle.FixedSingle;
            txtNhom.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNhom.Location = new Point(168, 130);
            txtNhom.Margin = new Padding(0);
            txtNhom.Name = "txtNhom";
            txtNhom.Enabled = false;
            txtNhom.Padding = new Padding(8);
            txtNhom.Size = new Size(337, 40);
            txtNhom.TabIndex = 8;
            // 
            // txtGiangVien
            // 
            txtGiangVien.BackColor = Color.White;
            txtGiangVien.BorderStyle = BorderStyle.FixedSingle;
            txtGiangVien.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGiangVien.Location = new Point(788, 80);
            txtGiangVien.Margin = new Padding(0);
            txtGiangVien.Name = "txtGiangVien";
            txtGiangVien.Enabled = false;
            txtGiangVien.Padding = new Padding(8);
            txtGiangVien.Size = new Size(330, 40);
            txtGiangVien.TabIndex = 9;
            // 
            // txtTongbaiKiemTra
            // 
            txtTongbaiKiemTra.BackColor = Color.White;
            txtTongbaiKiemTra.BorderStyle = BorderStyle.FixedSingle;
            txtTongbaiKiemTra.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTongbaiKiemTra.Location = new Point(788, 130);
            txtTongbaiKiemTra.Margin = new Padding(0);
            txtTongbaiKiemTra.Name = "txtTongbaiKiemTra";
            txtTongbaiKiemTra.Enabled = false;
            txtTongbaiKiemTra.Padding = new Padding(8);
            txtTongbaiKiemTra.Size = new Size(330, 40);
            txtTongbaiKiemTra.TabIndex = 10;
            // 
            // Dialog_XemThongTinHocPhan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
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
            Margin = new Padding(0);
            Padding = new Padding(20);
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
