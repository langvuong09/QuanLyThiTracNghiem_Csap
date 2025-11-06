namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Dialog_ThemChuong
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
            lblTenChuong = new Label();
            txtTenChuong = new TextBox();
            btnThem = new Button();
            lblMaChuong = new Label();
            txtMaChuong = new TextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(115, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(237, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÊM CHƯƠNG";
            // 
            // lblTenChuong
            // 
            lblTenChuong.AutoSize = true;
            lblTenChuong.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenChuong.Location = new Point(36, 178);
            lblTenChuong.Name = "lblTenChuong";
            lblTenChuong.Size = new Size(135, 30);
            lblTenChuong.TabIndex = 1;
            lblTenChuong.Text = "Tên chương:";
            // 
            // txtTenChuong
            // 
            txtTenChuong.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenChuong.Location = new Point(36, 223);
            txtTenChuong.Name = "txtTenChuong";
            txtTenChuong.Size = new Size(400, 35);
            txtTenChuong.TabIndex = 2;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(149, 285);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(159, 44);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // lblMaChuong
            // 
            lblMaChuong.AutoSize = true;
            lblMaChuong.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaChuong.Location = new Point(36, 81);
            lblMaChuong.Name = "lblMaChuong";
            lblMaChuong.Size = new Size(132, 30);
            lblMaChuong.TabIndex = 5;
            lblMaChuong.Text = "Mã chương:";
            // 
            // txtMaChuong
            // 
            txtMaChuong.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaChuong.Location = new Point(36, 124);
            txtMaChuong.Name = "txtMaChuong";
            txtMaChuong.Size = new Size(400, 35);
            txtMaChuong.TabIndex = 6;
            // 
            // Dialog_ThemChuong
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtMaChuong);
            Controls.Add(lblMaChuong);
            Controls.Add(btnThem);
            Controls.Add(txtTenChuong);
            Controls.Add(lblTenChuong);
            Controls.Add(lblTitle);
            Name = "Dialog_ThemChuong";
            Size = new Size(475, 359);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblTenChuong;
        private TextBox txtTenChuong;
        private Button btnThem;
        private Label lblMaChuong;
        private TextBox txtMaChuong;
    }
}
