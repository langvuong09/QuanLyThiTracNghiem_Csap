namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class TrangChuSinhVien
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChuSinhVien));
            panel_Top = new Panel();
            button_ThongTin = new Button();
            button_ThongBao = new Button();
            button_DangXuat = new Button();
            label_TitleTrangChu = new Label();
            pictureBox_Logo = new PictureBox();
            panel_Left = new FlowLayoutPanel();
            button_TrangChu = new Button();
            button_PhanQuyen = new Button();
            button_PhanCong = new Button();
            button_MonHoc = new Button();
            button_ThongBaoAdmin = new Button();
            button_CauHoi = new Button();
            button_DeKiemTra = new Button();
            button_NhomHocPhan = new Button();
            button_DeThi = new Button();
            button_HocPhan = new Button();
            button_NguoiDung = new Button();
            panel_Main = new Panel();
            panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).BeginInit();
            panel_Left.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Top
            // 
            panel_Top.BackColor = SystemColors.ActiveCaption;
            panel_Top.BorderStyle = BorderStyle.Fixed3D;
            panel_Top.Controls.Add(button_ThongTin);
            panel_Top.Controls.Add(button_ThongBao);
            panel_Top.Controls.Add(button_DangXuat);
            panel_Top.Controls.Add(label_TitleTrangChu);
            panel_Top.Controls.Add(pictureBox_Logo);
            panel_Top.Location = new Point(1, 1);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(1920, 100);
            panel_Top.TabIndex = 0;
            // 
            // button_ThongTin
            // 
            button_ThongTin.BackColor = SystemColors.AppWorkspace;
            button_ThongTin.FlatStyle = FlatStyle.Flat;
            button_ThongTin.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ThongTin.ForeColor = SystemColors.ButtonHighlight;
            button_ThongTin.Image = (Image)resources.GetObject("button_ThongTin.Image");
            button_ThongTin.ImageAlign = ContentAlignment.MiddleRight;
            button_ThongTin.Location = new Point(1411, 9);
            button_ThongTin.Name = "button_ThongTin";
            button_ThongTin.Size = new Size(275, 65);
            button_ThongTin.TabIndex = 4;
            button_ThongTin.Text = "Phạm Công Thành";
            button_ThongTin.TextAlign = ContentAlignment.MiddleLeft;
            button_ThongTin.UseVisualStyleBackColor = false;
            button_ThongTin.Click += button_ThongTin_Click;
            // 
            // button_ThongBao
            // 
            button_ThongBao.BackColor = SystemColors.AppWorkspace;
            button_ThongBao.FlatStyle = FlatStyle.Flat;
            button_ThongBao.Image = (Image)resources.GetObject("button_ThongBao.Image");
            button_ThongBao.Location = new Point(1716, 9);
            button_ThongBao.Name = "button_ThongBao";
            button_ThongBao.Size = new Size(65, 65);
            button_ThongBao.TabIndex = 3;
            button_ThongBao.UseVisualStyleBackColor = false;
            button_ThongBao.Click += button_ThongBao_Click;
            // 
            // button_DangXuat
            // 
            button_DangXuat.BackColor = SystemColors.AppWorkspace;
            button_DangXuat.FlatStyle = FlatStyle.Flat;
            button_DangXuat.Image = (Image)resources.GetObject("button_DangXuat.Image");
            button_DangXuat.Location = new Point(1807, 9);
            button_DangXuat.Name = "button_DangXuat";
            button_DangXuat.Size = new Size(65, 65);
            button_DangXuat.TabIndex = 2;
            button_DangXuat.UseVisualStyleBackColor = false;
            button_DangXuat.Click += button_DangXuat_Click;
            // 
            // label_TitleTrangChu
            // 
            label_TitleTrangChu.AutoSize = true;
            label_TitleTrangChu.Font = new Font("Segoe UI Black", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TitleTrangChu.ForeColor = SystemColors.ButtonFace;
            label_TitleTrangChu.Location = new Point(110, 9);
            label_TitleTrangChu.Name = "label_TitleTrangChu";
            label_TitleTrangChu.Size = new Size(988, 65);
            label_TitleTrangChu.TabIndex = 1;
            label_TitleTrangChu.Text = "HỆ THỐNG QUẢN LÝ TRẮC NGHIỆM SGU";
            // 
            // pictureBox_Logo
            // 
            pictureBox_Logo.Image = (Image)resources.GetObject("pictureBox_Logo.Image");
            pictureBox_Logo.Location = new Point(9, 3);
            pictureBox_Logo.Name = "pictureBox_Logo";
            pictureBox_Logo.Size = new Size(90, 90);
            pictureBox_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Logo.TabIndex = 0;
            pictureBox_Logo.TabStop = false;
            // 
            // panel_Left
            // 
            panel_Left.BackColor = SystemColors.ActiveCaption;
            panel_Left.Controls.Add(button_TrangChu);
            panel_Left.Controls.Add(button_PhanQuyen);
            panel_Left.Controls.Add(button_PhanCong);
            panel_Left.Controls.Add(button_MonHoc);
            panel_Left.Controls.Add(button_ThongBaoAdmin);
            panel_Left.Controls.Add(button_CauHoi);
            panel_Left.Controls.Add(button_DeKiemTra);
            panel_Left.Controls.Add(button_NhomHocPhan);
            panel_Left.Controls.Add(button_DeThi);
            panel_Left.Controls.Add(button_HocPhan);
            panel_Left.Controls.Add(button_NguoiDung);
            panel_Left.Location = new Point(1, 107);
            panel_Left.Name = "panel_Left";
            panel_Left.Size = new Size(365, 934);
            panel_Left.TabIndex = 1;
            // 
            // button_TrangChu
            // 
            button_TrangChu.BackColor = Color.DarkGray;
            button_TrangChu.FlatStyle = FlatStyle.Flat;
            button_TrangChu.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_TrangChu.ForeColor = SystemColors.ButtonHighlight;
            button_TrangChu.Image = (Image)resources.GetObject("button_TrangChu.Image");
            button_TrangChu.ImageAlign = ContentAlignment.MiddleLeft;
            button_TrangChu.Location = new Point(3, 3);
            button_TrangChu.Name = "button_TrangChu";
            button_TrangChu.Size = new Size(353, 65);
            button_TrangChu.TabIndex = 0;
            button_TrangChu.Text = "Trang Chủ";
            button_TrangChu.UseVisualStyleBackColor = false;
            button_TrangChu.Click += button_TrangChu_Click;
            // 
            // button_PhanQuyen
            // 
            button_PhanQuyen.BackColor = Color.DarkGray;
            button_PhanQuyen.FlatStyle = FlatStyle.Flat;
            button_PhanQuyen.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_PhanQuyen.ForeColor = SystemColors.ButtonHighlight;
            button_PhanQuyen.Image = (Image)resources.GetObject("button_PhanQuyen.Image");
            button_PhanQuyen.ImageAlign = ContentAlignment.MiddleLeft;
            button_PhanQuyen.Location = new Point(3, 74);
            button_PhanQuyen.Name = "button_PhanQuyen";
            button_PhanQuyen.Size = new Size(353, 65);
            button_PhanQuyen.TabIndex = 9;
            button_PhanQuyen.Text = "Phân Quyền";
            button_PhanQuyen.UseVisualStyleBackColor = false;
            button_PhanQuyen.Click += button_PhanQuyen_Click;
            // 
            // button_PhanCong
            // 
            button_PhanCong.BackColor = Color.DarkGray;
            button_PhanCong.FlatStyle = FlatStyle.Flat;
            button_PhanCong.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_PhanCong.ForeColor = SystemColors.ButtonHighlight;
            button_PhanCong.Image = (Image)resources.GetObject("button_PhanCong.Image");
            button_PhanCong.ImageAlign = ContentAlignment.MiddleLeft;
            button_PhanCong.Location = new Point(3, 145);
            button_PhanCong.Name = "button_PhanCong";
            button_PhanCong.Size = new Size(353, 65);
            button_PhanCong.TabIndex = 8;
            button_PhanCong.Text = "Phân Công";
            button_PhanCong.UseVisualStyleBackColor = false;
            button_PhanCong.Click += button_PhanCong_Click;
            // 
            // button_MonHoc
            // 
            button_MonHoc.BackColor = Color.DarkGray;
            button_MonHoc.FlatStyle = FlatStyle.Flat;
            button_MonHoc.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_MonHoc.ForeColor = SystemColors.ButtonHighlight;
            button_MonHoc.Image = (Image)resources.GetObject("button_MonHoc.Image");
            button_MonHoc.ImageAlign = ContentAlignment.MiddleLeft;
            button_MonHoc.Location = new Point(3, 216);
            button_MonHoc.Name = "button_MonHoc";
            button_MonHoc.Size = new Size(353, 65);
            button_MonHoc.TabIndex = 7;
            button_MonHoc.Text = "Môn Học";
            button_MonHoc.UseVisualStyleBackColor = false;
            button_MonHoc.Click += button_MonHoc_Click;
            // 
            // button_ThongBaoAdmin
            // 
            button_ThongBaoAdmin.BackColor = Color.DarkGray;
            button_ThongBaoAdmin.FlatStyle = FlatStyle.Flat;
            button_ThongBaoAdmin.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ThongBaoAdmin.ForeColor = SystemColors.ButtonHighlight;
            button_ThongBaoAdmin.Image = (Image)resources.GetObject("button_ThongBaoAdmin.Image");
            button_ThongBaoAdmin.ImageAlign = ContentAlignment.MiddleLeft;
            button_ThongBaoAdmin.Location = new Point(3, 287);
            button_ThongBaoAdmin.Name = "button_ThongBaoAdmin";
            button_ThongBaoAdmin.Size = new Size(353, 65);
            button_ThongBaoAdmin.TabIndex = 6;
            button_ThongBaoAdmin.Text = "Thông Báo";
            button_ThongBaoAdmin.UseVisualStyleBackColor = false;
            button_ThongBaoAdmin.Click += button_ThongBaoAdmin_Click;
            // 
            // button_CauHoi
            // 
            button_CauHoi.BackColor = Color.DarkGray;
            button_CauHoi.FlatStyle = FlatStyle.Flat;
            button_CauHoi.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_CauHoi.ForeColor = SystemColors.ButtonHighlight;
            button_CauHoi.Image = (Image)resources.GetObject("button_CauHoi.Image");
            button_CauHoi.ImageAlign = ContentAlignment.MiddleLeft;
            button_CauHoi.Location = new Point(3, 358);
            button_CauHoi.Name = "button_CauHoi";
            button_CauHoi.Size = new Size(353, 65);
            button_CauHoi.TabIndex = 5;
            button_CauHoi.Text = "Câu Hỏi";
            button_CauHoi.UseVisualStyleBackColor = false;
            button_CauHoi.Click += button_CauHoi_Click;
            // 
            // button_DeKiemTra
            // 
            button_DeKiemTra.BackColor = Color.DarkGray;
            button_DeKiemTra.FlatStyle = FlatStyle.Flat;
            button_DeKiemTra.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_DeKiemTra.ForeColor = SystemColors.ButtonHighlight;
            button_DeKiemTra.Image = (Image)resources.GetObject("button_DeKiemTra.Image");
            button_DeKiemTra.ImageAlign = ContentAlignment.MiddleLeft;
            button_DeKiemTra.Location = new Point(3, 429);
            button_DeKiemTra.Name = "button_DeKiemTra";
            button_DeKiemTra.Size = new Size(353, 65);
            button_DeKiemTra.TabIndex = 4;
            button_DeKiemTra.Text = "   Đề Kiểm Tra";
            button_DeKiemTra.UseVisualStyleBackColor = false;
            button_DeKiemTra.Click += button_DeKiemTra_Click;
            // 
            // button_NhomHocPhan
            // 
            button_NhomHocPhan.BackColor = Color.DarkGray;
            button_NhomHocPhan.FlatStyle = FlatStyle.Flat;
            button_NhomHocPhan.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_NhomHocPhan.ForeColor = SystemColors.ButtonHighlight;
            button_NhomHocPhan.Image = (Image)resources.GetObject("button_NhomHocPhan.Image");
            button_NhomHocPhan.ImageAlign = ContentAlignment.MiddleLeft;
            button_NhomHocPhan.Location = new Point(3, 500);
            button_NhomHocPhan.Name = "button_NhomHocPhan";
            button_NhomHocPhan.Size = new Size(353, 65);
            button_NhomHocPhan.TabIndex = 3;
            button_NhomHocPhan.Text = "     Nhóm Học Phần";
            button_NhomHocPhan.UseVisualStyleBackColor = false;
            button_NhomHocPhan.Click += button_NhomHocPhan_Click;
            // 
            // button_DeThi
            // 
            button_DeThi.BackColor = Color.DarkGray;
            button_DeThi.FlatStyle = FlatStyle.Flat;
            button_DeThi.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_DeThi.ForeColor = SystemColors.ButtonHighlight;
            button_DeThi.Image = (Image)resources.GetObject("button_DeThi.Image");
            button_DeThi.ImageAlign = ContentAlignment.MiddleLeft;
            button_DeThi.Location = new Point(3, 571);
            button_DeThi.Name = "button_DeThi";
            button_DeThi.Size = new Size(353, 65);
            button_DeThi.TabIndex = 2;
            button_DeThi.Text = "Đề Thi";
            button_DeThi.UseVisualStyleBackColor = false;
            button_DeThi.Click += button_DeThi_Click;
            // 
            // button_HocPhan
            // 
            button_HocPhan.BackColor = Color.DarkGray;
            button_HocPhan.FlatStyle = FlatStyle.Flat;
            button_HocPhan.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_HocPhan.ForeColor = SystemColors.ButtonHighlight;
            button_HocPhan.Image = (Image)resources.GetObject("button_HocPhan.Image");
            button_HocPhan.ImageAlign = ContentAlignment.MiddleLeft;
            button_HocPhan.Location = new Point(3, 642);
            button_HocPhan.Name = "button_HocPhan";
            button_HocPhan.Size = new Size(353, 65);
            button_HocPhan.TabIndex = 1;
            button_HocPhan.Text = "Học Phần";
            button_HocPhan.UseVisualStyleBackColor = false;
            button_HocPhan.Click += button_HocPhan_Click;
            // 
            // button_NguoiDung
            // 
            button_NguoiDung.BackColor = Color.DarkGray;
            button_NguoiDung.FlatStyle = FlatStyle.Flat;
            button_NguoiDung.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_NguoiDung.ForeColor = SystemColors.ButtonHighlight;
            button_NguoiDung.Image = (Image)resources.GetObject("button_NguoiDung.Image");
            button_NguoiDung.ImageAlign = ContentAlignment.MiddleLeft;
            button_NguoiDung.Location = new Point(3, 713);
            button_NguoiDung.Name = "button_NguoiDung";
            button_NguoiDung.Size = new Size(353, 65);
            button_NguoiDung.TabIndex = 10;
            button_NguoiDung.Text = "Người Dùng";
            button_NguoiDung.UseVisualStyleBackColor = false;
            button_NguoiDung.Click += button_NguoiDung_Click;
            // 
            // panel_Main
            // 
            panel_Main.BackColor = SystemColors.ButtonHighlight;
            panel_Main.Location = new Point(363, 107);
            panel_Main.Name = "panel_Main";
            panel_Main.Size = new Size(1541, 934);
            panel_Main.TabIndex = 2;
            // 
            // TrangChuSinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel_Main);
            Controls.Add(panel_Left);
            Controls.Add(panel_Top);
            Name = "TrangChuSinhVien";
            Text = "TrangChuSinhVien";
            panel_Top.ResumeLayout(false);
            panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).EndInit();
            panel_Left.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Top;
        private FlowLayoutPanel panel_Left;
        private Panel panel_Main;
        private PictureBox pictureBox_Logo;
        private Label label_TitleTrangChu;
        private Button button_DangXuat;
        private Button button_ThongBao;
        private Button button_ThongTin;
        private Button button_TrangChu;
        private Button button_DeThi;
        private Button button_HocPhan;
        private Button button_ThongBaoAdmin;
        private Button button_CauHoi;
        private Button button_DeKiemTra;
        private Button button_NhomHocPhan;
        private Button button_PhanQuyen;
        private Button button_PhanCong;
        private Button button_MonHoc;
        private Button button_NguoiDung;
    }
}