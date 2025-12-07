namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_MonHocNguoiDung
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
            colMaChuong = new DataGridViewTextBoxColumn();
            colTenChuong = new DataGridViewTextBoxColumn();
            colMaMonHoc = new DataGridViewTextBoxColumn();
            colTenMonHoc = new DataGridViewTextBoxColumn();
            colTinChi = new DataGridViewTextBoxColumn();
            colSoTietLT = new DataGridViewTextBoxColumn();
            colSoTietTH = new DataGridViewTextBoxColumn();
            colHeSo = new DataGridViewTextBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_MonHocNguoiDung));
            dgvMonHoc = new DataGridView();
            dgvChuong = new DataGridView();
            pnHinhAnh = new Panel();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChuong).BeginInit();
            SuspendLayout();
            // 
            // dgvMonHoc
            // 
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToDeleteRows = false;
            dgvMonHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonHoc.BackgroundColor = SystemColors.ButtonFace;
            dgvMonHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMonHoc.ColumnHeadersHeight = 29;
            dgvMonHoc.Columns.AddRange(new DataGridViewColumn[] { colMaMonHoc, colTenMonHoc, colTinChi, colSoTietLT, colSoTietTH, colHeSo });
            dgvMonHoc.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#9BBCFF");
            dgvMonHoc.EnableHeadersVisualStyles = false;
            dgvMonHoc.Location = new Point(3, 89);
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.RowHeadersWidth = 21;
            dgvMonHoc.Size = new Size(1043, 842);
            dgvMonHoc.TabIndex = 0;
            // 
            // colMaMonHoc
            // 
            colMaMonHoc.HeaderText = "Mã MH";
            colMaMonHoc.MinimumWidth = 120;
            colMaMonHoc.Name = "colMaMonHoc";
            colMaMonHoc.ReadOnly = true;
            // 
            // colTenMonHoc
            // 
            colTenMonHoc.HeaderText = "Tên Môn học";
            colTenMonHoc.MinimumWidth = 300;
            colTenMonHoc.Name = "colTenMonHoc";
            colTenMonHoc.ReadOnly = true;
            // 
            // colTinChi
            // 
            colTinChi.HeaderText = "Tín chỉ";
            colTinChi.MinimumWidth = 150;
            colTinChi.Name = "colTinChi";
            colTinChi.ReadOnly = true;
            // 
            // colSoTietLT
            // 
            colSoTietLT.HeaderText = "Số tiết LT";
            colSoTietLT.MinimumWidth = 150;
            colSoTietLT.Name = "colSoTietLT";
            colSoTietLT.ReadOnly = true;
            // 
            // colSoTietTH
            // 
            colSoTietTH.HeaderText = "Số tiết TH";
            colSoTietTH.MinimumWidth = 150;
            colSoTietTH.Name = "colSoTietTH";
            colSoTietTH.ReadOnly = true;
            // 
            // colHeSo
            // 
            colHeSo.HeaderText = "Hệ số";
            colHeSo.MinimumWidth = 150;
            colHeSo.Name = "colHeSo";
            colHeSo.ReadOnly = true;
            // 
            // dgvChuong
            // 
            dgvChuong.AllowUserToAddRows = false;
            dgvChuong.AllowUserToDeleteRows = false;
            dgvChuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuong.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(101, 224, 199);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvChuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvChuong.ColumnHeadersHeight = 29;
            dgvChuong.Columns.AddRange(new DataGridViewColumn[] { colMaChuong, colTenChuong });
            dgvChuong.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#9BBCFF");
            dgvChuong.EnableHeadersVisualStyles = false;
            dgvChuong.MultiSelect = false;
            dgvChuong.Location = new Point(1052, 89);
            dgvChuong.Name = "dgvChuong";
            dgvChuong.ReadOnly = true;
            dgvChuong.RowHeadersWidth = 24;
            dgvChuong.Size = new Size(486, 355);
            dgvChuong.TabIndex = 1;
            // 
            // colMaChuong
            // 
            colMaChuong.HeaderText = "Mã";
            colMaChuong.MinimumWidth = 150;
            colMaChuong.Name = "colMaChuong";
            colMaChuong.ReadOnly = true;
            // 
            // colTenChuong
            // 
            colTenChuong.HeaderText = "Tên Chương";
            colTenChuong.MinimumWidth = 310;
            colTenChuong.Name = "colTenChuong";
            colTenChuong.ReadOnly = true;
            // 
            // lblChuong
            // 
            // 
            // pnHinhAnh
            // 
            pnHinhAnh.BackgroundImage = (Image)resources.GetObject("pnHinhAnh.BackgroundImage");
            pnHinhAnh.Location = new Point(1052, 450);
            pnHinhAnh.Name = "pnHinhAnh";
            pnHinhAnh.Size = new Size(486, 486);
            pnHinhAnh.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTimKiem.Location = new Point(83, 22);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(138, 37);
            lblTimKiem.TabIndex = 26;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(233, 20);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(813, 39);
            txtTimKiem.TabIndex = 25;
            // 
            // Component_MonHocNguoiDung
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(pnHinhAnh);
            Controls.Add(dgvChuong);
            Controls.Add(dgvMonHoc);
            Name = "Component_MonHocNguoiDung";
            Size = new Size(1541, 934);
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridViewTextBoxColumn colMaMonHoc;
        private DataGridViewTextBoxColumn colTenMonHoc;
        private DataGridViewTextBoxColumn colTinChi;
        private DataGridViewTextBoxColumn colSoTietLT;
        private DataGridViewTextBoxColumn colSoTietTH;
        private DataGridViewTextBoxColumn colHeSo;
        private DataGridViewTextBoxColumn colMaChuong;
        private DataGridViewTextBoxColumn colTenChuong;
        private DataGridView dgvMonHoc;
        private DataGridView dgvChuong;
        private Panel pnHinhAnh;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
    }
}
