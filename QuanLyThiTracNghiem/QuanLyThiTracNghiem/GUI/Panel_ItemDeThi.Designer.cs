namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Panel_ItemDeThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_ItemDeThi));
            label_TenBaiKiemTra = new Label();
            label_TitleTrangThai = new Label();
            label_ThoiGian = new Label();
            label_MonHoc = new Label();
            label_TrangThai = new Label();
            button_XemChiTiet = new Button();
            SuspendLayout();
            // 
            // label_TenBaiKiemTra
            // 
            label_TenBaiKiemTra.AutoSize = true;
            label_TenBaiKiemTra.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TenBaiKiemTra.ForeColor = Color.OrangeRed;
            label_TenBaiKiemTra.Location = new Point(14, 9);
            label_TenBaiKiemTra.Name = "label_TenBaiKiemTra";
            label_TenBaiKiemTra.Size = new Size(205, 37);
            label_TenBaiKiemTra.TabIndex = 0;
            label_TenBaiKiemTra.Text = "Kiểm Tra Lần 1";
            // 
            // label_TitleTrangThai
            // 
            label_TitleTrangThai.AutoSize = true;
            label_TitleTrangThai.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_TitleTrangThai.Location = new Point(14, 130);
            label_TitleTrangThai.Name = "label_TitleTrangThai";
            label_TitleTrangThai.Size = new Size(104, 25);
            label_TitleTrangThai.TabIndex = 1;
            label_TitleTrangThai.Text = "Trạng Thái:";
            // 
            // label_ThoiGian
            // 
            label_ThoiGian.AutoSize = true;
            label_ThoiGian.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ThoiGian.Location = new Point(14, 96);
            label_ThoiGian.Name = "label_ThoiGian";
            label_ThoiGian.Size = new Size(433, 25);
            label_ThoiGian.TabIndex = 2;
            label_ThoiGian.Text = "Diễn ra từ 10:05 12/09/2025 đến 12:00 14/09/2025 ";
            // 
            // label_MonHoc
            // 
            label_MonHoc.AutoSize = true;
            label_MonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MonHoc.Location = new Point(14, 53);
            label_MonHoc.Name = "label_MonHoc";
            label_MonHoc.Size = new Size(291, 30);
            label_MonHoc.TabIndex = 3;
            label_MonHoc.Text = "Lập Trình Web Và Ứng Dụng";
            // 
            // label_TrangThai
            // 
            label_TrangThai.AutoSize = true;
            label_TrangThai.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TrangThai.ForeColor = Color.IndianRed;
            label_TrangThai.Location = new Point(134, 130);
            label_TrangThai.Name = "label_TrangThai";
            label_TrangThai.Size = new Size(126, 25);
            label_TrangThai.TabIndex = 4;
            label_TrangThai.Text = "Hoàn Thành";
            // 
            // button_XemChiTiet
            // 
            button_XemChiTiet.BackColor = SystemColors.ActiveCaption;
            button_XemChiTiet.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_XemChiTiet.ForeColor = SystemColors.ButtonFace;
            button_XemChiTiet.Image = (Image)resources.GetObject("button_XemChiTiet.Image");
            button_XemChiTiet.ImageAlign = ContentAlignment.MiddleLeft;
            button_XemChiTiet.Location = new Point(1303, 98);
            button_XemChiTiet.Name = "button_XemChiTiet";
            button_XemChiTiet.Size = new Size(207, 57);
            button_XemChiTiet.TabIndex = 5;
            button_XemChiTiet.Text = "   Xem Chi Tiết";
            button_XemChiTiet.TextAlign = ContentAlignment.MiddleRight;
            button_XemChiTiet.UseVisualStyleBackColor = false;
            button_XemChiTiet.Click += button_XemChiTiet_Click;
            // 
            // Panel_ItemDeThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(button_XemChiTiet);
            Controls.Add(label_TrangThai);
            Controls.Add(label_MonHoc);
            Controls.Add(label_ThoiGian);
            Controls.Add(label_TitleTrangThai);
            Controls.Add(label_TenBaiKiemTra);
            Name = "Panel_ItemDeThi";
            Size = new Size(1540, 170);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_TenBaiKiemTra;
        private Label label_TitleTrangThai;
        private Label label_ThoiGian;
        private Label label_MonHoc;
        private Label label_TrangThai;
        private Button button_XemChiTiet;
    }
}
