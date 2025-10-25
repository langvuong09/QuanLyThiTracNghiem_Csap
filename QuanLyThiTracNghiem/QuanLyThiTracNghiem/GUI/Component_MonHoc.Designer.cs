namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_MonHoc
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
            lblTitle = new Label();
            lblMaMonHoc = new Label();
            lblTenMonHoc = new Label();
            lblTinChi = new Label();
            lblSoTietTH = new Label();
            lblHeSo = new Label();
            lblSoTietLT = new Label();
            txtMaMonHoc = new TextBox();
            txtTenMonHoc = new TextBox();
            txtTinChi = new TextBox();
            txtSoTietLT = new TextBox();
            txtSoTietTH = new TextBox();
            txtHeSo = new TextBox();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            dgvChuong = new DataGridView();
            lblChuong = new Label();
            btnXoaChuong = new Button();
            btnThemChuong = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvChuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.Highlight;
            lblTitle.Location = new Point(599, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(354, 86);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MÔN HỌC";
            // 
            // lblMaMonHoc
            // 
            lblMaMonHoc.AutoSize = true;
            lblMaMonHoc.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblMaMonHoc.Location = new Point(19, 128);
            lblMaMonHoc.Name = "lblMaMonHoc";
            lblMaMonHoc.Size = new Size(205, 40);
            lblMaMonHoc.TabIndex = 1;
            lblMaMonHoc.Text = "Mã môn học: ";
            // 
            // lblTenMonHoc
            // 
            lblTenMonHoc.AutoSize = true;
            lblTenMonHoc.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblTenMonHoc.Location = new Point(19, 184);
            lblTenMonHoc.Name = "lblTenMonHoc";
            lblTenMonHoc.Size = new Size(201, 40);
            lblTenMonHoc.TabIndex = 2;
            lblTenMonHoc.Text = "Tên môn học:";
            // 
            // lblTinChi
            // 
            lblTinChi.AutoSize = true;
            lblTinChi.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblTinChi.Location = new Point(19, 237);
            lblTinChi.Name = "lblTinChi";
            lblTinChi.Size = new Size(115, 40);
            lblTinChi.TabIndex = 3;
            lblTinChi.Text = "Tín chỉ:";
            // 
            // lblSoTietTH
            // 
            lblSoTietTH.AutoSize = true;
            lblSoTietTH.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblSoTietTH.Location = new Point(19, 346);
            lblSoTietTH.Name = "lblSoTietTH";
            lblSoTietTH.Size = new Size(258, 40);
            lblSoTietTH.TabIndex = 5;
            lblSoTietTH.Text = "Số tiết thực hành:";
            // 
            // lblHeSo
            // 
            lblHeSo.AutoSize = true;
            lblHeSo.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblHeSo.Location = new Point(19, 399);
            lblHeSo.Name = "lblHeSo";
            lblHeSo.Size = new Size(102, 40);
            lblHeSo.TabIndex = 6;
            lblHeSo.Text = "Hệ số:";
            // 
            // lblSoTietLT
            // 
            lblSoTietLT.AutoSize = true;
            lblSoTietLT.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblSoTietLT.Location = new Point(19, 291);
            lblSoTietLT.Name = "lblSoTietLT";
            lblSoTietLT.Size = new Size(242, 40);
            lblSoTietLT.TabIndex = 7;
            lblSoTietLT.Text = "Số tiết lý thuyết:";
            // 
            // txtMaMonHoc
            // 
            txtMaMonHoc.Font = new Font("Segoe UI", 20.25F);
            txtMaMonHoc.Location = new Point(312, 125);
            txtMaMonHoc.Name = "txtMaMonHoc";
            txtMaMonHoc.Size = new Size(624, 43);
            txtMaMonHoc.TabIndex = 8;
            // 
            // txtTenMonHoc
            // 
            txtTenMonHoc.Font = new Font("Segoe UI", 20.25F);
            txtTenMonHoc.Location = new Point(312, 181);
            txtTenMonHoc.Name = "txtTenMonHoc";
            txtTenMonHoc.Size = new Size(624, 43);
            txtTenMonHoc.TabIndex = 9;
            // 
            // txtTinChi
            // 
            txtTinChi.Font = new Font("Segoe UI", 20.25F);
            txtTinChi.Location = new Point(312, 234);
            txtTinChi.Name = "txtTinChi";
            txtTinChi.Size = new Size(624, 43);
            txtTinChi.TabIndex = 10;
            // 
            // txtSoTietLT
            // 
            txtSoTietLT.Font = new Font("Segoe UI", 20.25F);
            txtSoTietLT.Location = new Point(312, 288);
            txtSoTietLT.Name = "txtSoTietLT";
            txtSoTietLT.Size = new Size(624, 43);
            txtSoTietLT.TabIndex = 11;
            // 
            // txtSoTietTH
            // 
            txtSoTietTH.Font = new Font("Segoe UI", 20.25F);
            txtSoTietTH.Location = new Point(312, 343);
            txtSoTietTH.Name = "txtSoTietTH";
            txtSoTietTH.Size = new Size(624, 43);
            txtSoTietTH.TabIndex = 12;
            // 
            // txtHeSo
            // 
            txtHeSo.Font = new Font("Segoe UI", 20.25F);
            txtHeSo.Location = new Point(312, 396);
            txtHeSo.Name = "txtHeSo";
            txtHeSo.Size = new Size(624, 43);
            txtHeSo.TabIndex = 13;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(134, 489);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(152, 49);
            btnThem.TabIndex = 14;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(341, 489);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(152, 49);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(552, 489);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(152, 49);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // dgvChuong
            // 
            dgvChuong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuong.Location = new Point(978, 184);
            dgvChuong.Name = "dgvChuong";
            dgvChuong.Size = new Size(538, 255);
            dgvChuong.TabIndex = 17;
            // 
            // lblChuong
            // 
            lblChuong.AutoSize = true;
            lblChuong.Font = new Font("Segoe UI", 32.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChuong.ForeColor = Color.SteelBlue;
            lblChuong.Location = new Point(1148, 109);
            lblChuong.Name = "lblChuong";
            lblChuong.Size = new Size(217, 59);
            lblChuong.TabIndex = 18;
            lblChuong.Text = "CHƯƠNG";
            // 
            // btnXoaChuong
            // 
            btnXoaChuong.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoaChuong.Location = new Point(1284, 489);
            btnXoaChuong.Name = "btnXoaChuong";
            btnXoaChuong.Size = new Size(152, 49);
            btnXoaChuong.TabIndex = 19;
            btnXoaChuong.Text = "Xóa";
            btnXoaChuong.UseVisualStyleBackColor = true;
            btnThemChuong.Click += XuLyThemChuong;

            // 
            // btnThemChuong
            // 
            btnThemChuong.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemChuong.Location = new Point(1066, 489);
            btnThemChuong.Name = "btnThemChuong";
            btnThemChuong.Size = new Size(152, 49);
            btnThemChuong.TabIndex = 20;
            btnThemChuong.Text = "Thêm";
            btnThemChuong.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 580);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1541, 354);
            dataGridView1.TabIndex = 21;
            // 
            // Component_MonHoc
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(dataGridView1);
            Controls.Add(btnThemChuong);
            Controls.Add(btnXoaChuong);
            Controls.Add(lblChuong);
            Controls.Add(dgvChuong);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(txtHeSo);
            Controls.Add(txtSoTietTH);
            Controls.Add(txtSoTietLT);
            Controls.Add(txtTinChi);
            Controls.Add(txtTenMonHoc);
            Controls.Add(txtMaMonHoc);
            Controls.Add(lblSoTietLT);
            Controls.Add(lblHeSo);
            Controls.Add(lblSoTietTH);
            Controls.Add(lblTinChi);
            Controls.Add(lblTenMonHoc);
            Controls.Add(lblMaMonHoc);
            Controls.Add(lblTitle);
            Name = "Component_MonHoc";
            Size = new Size(1541, 934);
            ((System.ComponentModel.ISupportInitialize)dgvChuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblMaMonHoc;
        private Label lblTenMonHoc;
        private Label lblTinChi;
        private Label lblSoTietTH;
        private Label lblHeSo;
        private Label lblSoTietLT;
        private TextBox txtMaMonHoc;
        private TextBox txtTenMonHoc;
        private TextBox txtTinChi;
        private TextBox txtSoTietLT;
        private TextBox txtSoTietTH;
        private TextBox txtHeSo;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private DataGridView dgvChuong;
        private Label lblChuong;
        private Button btnXoaChuong;
        private Button btnThemChuong;
        private DataGridView dataGridView1;
    }
}
