using System.Windows.Forms;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            colMaChuong = new DataGridViewTextBoxColumn();
            colTenChuong = new DataGridViewTextBoxColumn();
            lblChuong = new Label();
            btnXoaChuong = new Button();
            btnThemChuong = new Button();
            dgvMonHoc = new DataGridView();
            colMaMonHoc = new DataGridViewTextBoxColumn();
            colTenMonHoc = new DataGridViewTextBoxColumn();
            colTinChi = new DataGridViewTextBoxColumn();
            colSoTietLT = new DataGridViewTextBoxColumn();
            colSoTietTH = new DataGridViewTextBoxColumn();
            colHeSo = new DataGridViewTextBoxColumn();
            btnReset = new Button();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvChuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
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
            txtMaMonHoc.ReadOnly = true;
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
            btnThem.Location = new Point(58, 465);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(152, 49);
            btnThem.TabIndex = 14;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(251, 465);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(152, 49);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(445, 465);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(152, 49);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // dgvChuong
            // 
            dgvChuong.AllowUserToAddRows = false;
            dgvChuong.AllowUserToDeleteRows = false;
            dgvChuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChuong.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(101, 224, 199);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvChuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvChuong.ColumnHeadersHeight = 29;
            dgvChuong.Columns.AddRange(new DataGridViewColumn[] { colMaChuong, colTenChuong });
            dgvChuong.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#9BBCFF");
            dgvChuong.EnableHeadersVisualStyles = false;
            dgvChuong.Location = new Point(978, 184);
            dgvChuong.MultiSelect = false;
            dgvChuong.Name = "dgvChuong";
            dgvChuong.ReadOnly = true;
            dgvChuong.RowHeadersWidth = 51;
            dgvChuong.Size = new Size(538, 255);
            dgvChuong.TabIndex = 17;
            // 
            // colMaChuong
            // 
            colMaChuong.HeaderText = "Mã";
            colMaChuong.MinimumWidth = 6;
            colMaChuong.Name = "colMaChuong";
            colMaChuong.ReadOnly = true;
            // 
            // colTenChuong
            // 
            colTenChuong.HeaderText = "Tên Chương";
            colTenChuong.MinimumWidth = 6;
            colTenChuong.Name = "colTenChuong";
            colTenChuong.ReadOnly = true;
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
            btnXoaChuong.Location = new Point(1280, 465);
            btnXoaChuong.Name = "btnXoaChuong";
            btnXoaChuong.Size = new Size(152, 49);
            btnXoaChuong.TabIndex = 19;
            btnXoaChuong.Text = "Xóa";
            btnXoaChuong.UseVisualStyleBackColor = true;
            // 
            // btnThemChuong
            // 
            btnThemChuong.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemChuong.Location = new Point(1062, 465);
            btnThemChuong.Name = "btnThemChuong";
            btnThemChuong.Size = new Size(152, 49);
            btnThemChuong.TabIndex = 20;
            btnThemChuong.Text = "Thêm";
            btnThemChuong.UseVisualStyleBackColor = true;
            // 
            // dgvMonHoc
            // 
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToDeleteRows = false;
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonHoc.BackgroundColor = SystemColors.ButtonFace;
            dgvMonHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMonHoc.ColumnHeadersHeight = 29;
            dgvMonHoc.Columns.AddRange(new DataGridViewColumn[] { colMaMonHoc, colTenMonHoc, colTinChi, colSoTietLT, colSoTietTH, colHeSo });
            dgvMonHoc.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#9BBCFF");
            dgvMonHoc.EnableHeadersVisualStyles = false;
            dgvMonHoc.Location = new Point(0, 607);
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.RowHeadersWidth = 51;
            dgvMonHoc.Size = new Size(1541, 327);
            dgvMonHoc.TabIndex = 21;
            // 
            // colMaMonHoc
            // 
            colMaMonHoc.HeaderText = "Mã MH";
            colMaMonHoc.MinimumWidth = 6;
            colMaMonHoc.Name = "colMaMonHoc";
            colMaMonHoc.ReadOnly = true;
            // 
            // colTenMonHoc
            // 
            colTenMonHoc.HeaderText = "Tên MH";
            colTenMonHoc.MinimumWidth = 6;
            colTenMonHoc.Name = "colTenMonHoc";
            colTenMonHoc.ReadOnly = true;
            // 
            // colTinChi
            // 
            colTinChi.HeaderText = "Tín chỉ";
            colTinChi.MinimumWidth = 6;
            colTinChi.Name = "colTinChi";
            colTinChi.ReadOnly = true;
            // 
            // colSoTietLT
            // 
            colSoTietLT.HeaderText = "Số tiết LT";
            colSoTietLT.MinimumWidth = 6;
            colSoTietLT.Name = "colSoTietLT";
            colSoTietLT.ReadOnly = true;
            // 
            // colSoTietTH
            // 
            colSoTietTH.HeaderText = "Số tiết TH";
            colSoTietTH.MinimumWidth = 6;
            colSoTietTH.Name = "colSoTietTH";
            colSoTietTH.ReadOnly = true;
            // 
            // colHeSo
            // 
            colHeSo.HeaderText = "Hệ số";
            colHeSo.MinimumWidth = 6;
            colHeSo.Name = "colHeSo";
            colHeSo.ReadOnly = true;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.Location = new Point(646, 465);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(152, 49);
            btnReset.TabIndex = 22;
            btnReset.Text = "ĐẶT LẠI";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(401, 547);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(813, 39);
            txtTimKiem.TabIndex = 23;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTimKiem.Location = new Point(251, 549);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(138, 37);
            lblTimKiem.TabIndex = 24;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // Component_MonHoc
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnReset);
            Controls.Add(dgvMonHoc);
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
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
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
        private DataGridViewTextBoxColumn colMaMonHoc;
        private DataGridViewTextBoxColumn colTenMonHoc;
        private DataGridViewTextBoxColumn colTinChi;
        private DataGridViewTextBoxColumn colSoTietLT;
        private DataGridViewTextBoxColumn colSoTietTH;
        private DataGridViewTextBoxColumn colHeSo;
        private DataGridViewTextBoxColumn colMaChuong;
        private DataGridViewTextBoxColumn colTenChuong;
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
        private DataGridView dgvMonHoc;
        private Button btnReset;
        private TextBox txtTimKiem;
        private Label lblTimKiem;
    }
}
