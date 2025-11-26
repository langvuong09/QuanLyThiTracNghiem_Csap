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
            lblTitle = new Label();
            btnTimKiem = new Button();
            txtTimKIem = new TextBox();
            btnXuat = new Button();
            txtMaSV = new TextBox();
            btnThem = new Button();
            lblMaSV = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            btnXuat.Location = new Point(930, 63);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(157, 46);
            btnXuat.TabIndex = 3;
            btnXuat.Text = "Xuất dữ liệu";
            btnXuat.UseVisualStyleBackColor = false;
            // 
            // txtMaSV
            // 
            txtMaSV.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaSV.Location = new Point(554, 68);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(252, 35);
            txtMaSV.TabIndex = 5;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ActiveCaption;
            btnThem.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.Control;
            btnThem.Location = new Point(812, 63);
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
            lblMaSV.Location = new Point(466, 73);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(82, 30);
            lblMaSV.TabIndex = 6;
            lblMaSV.Text = "Mã SV:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1057, 571);
            dataGridView1.TabIndex = 7;
            // 
            // Dialog_XemDSSVNhom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(lblMaSV);
            Controls.Add(txtMaSV);
            Controls.Add(btnThem);
            Controls.Add(btnXuat);
            Controls.Add(txtTimKIem);
            Controls.Add(btnTimKiem);
            Controls.Add(lblTitle);
            Name = "Dialog_XemDSSVNhom";
            Size = new Size(1121, 734);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnTimKiem;
        private TextBox txtTimKIem;
        private Button btnXuat;
        private TextBox txtMaSV;
        private Button btnThem;
        private Label lblMaSV;
        private DataGridView dataGridView1;
    }
}
