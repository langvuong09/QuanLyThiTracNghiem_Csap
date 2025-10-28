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
            btnHuy = new Button();
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
            lblTenChuong.Location = new Point(36, 70);
            lblTenChuong.Name = "lblTenChuong";
            lblTenChuong.Size = new Size(135, 30);
            lblTenChuong.TabIndex = 1;
            lblTenChuong.Text = "Tên chương:";
            // 
            // txtTenChuong
            // 
            txtTenChuong.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenChuong.Location = new Point(36, 116);
            txtTenChuong.Name = "txtTenChuong";
            txtTenChuong.Size = new Size(400, 35);
            txtTenChuong.TabIndex = 2;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(115, 199);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(98, 44);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnHuy
            // 
            btnHuy.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.Location = new Point(254, 199);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(98, 44);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // Dialog_ThemChuong
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnHuy);
            Controls.Add(btnThem);
            Controls.Add(txtTenChuong);
            Controls.Add(lblTenChuong);
            Controls.Add(lblTitle);
            Name = "Dialog_ThemChuong";
            Size = new Size(475, 262);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblTenChuong;
        private TextBox txtTenChuong;
        private Button btnThem;
        private Button btnHuy;
    }
}
