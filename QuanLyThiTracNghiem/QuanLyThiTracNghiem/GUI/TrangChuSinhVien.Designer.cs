using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System.Collections;

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
            btnNotice = new Button();
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
            button_ThongKe = new Button();
            panel_Main = new Panel();
            panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).BeginInit();
            SuspendLayout();
            // 
            // panel_Top
            // 
            panel_Top.BackColor = Color.FromArgb(70, 130, 180);
            panel_Top.BorderStyle = BorderStyle.None;
            panel_Top.Controls.Add(btnNotice);
            panel_Top.Controls.Add(button_ThongTin);
            panel_Top.Controls.Add(button_ThongBao);
            panel_Top.Controls.Add(button_DangXuat);
            panel_Top.Controls.Add(label_TitleTrangChu);
            panel_Top.Controls.Add(pictureBox_Logo);
            panel_Top.Location = new Point(0, 0);
            panel_Top.Margin = new Padding(0);
            panel_Top.Name = "panel_Top";
            panel_Top.Padding = new Padding(15, 10, 15, 10);
            panel_Top.Size = new Size(1920, 110);
            panel_Top.TabIndex = 0;
            // 
            // btnNotice
            // 
            btnNotice.BackColor = Color.FromArgb(255, 99, 71);
            btnNotice.FlatStyle = FlatStyle.Flat;
            btnNotice.Location = new Point(1768, 61);
            btnNotice.Margin = new Padding(4, 3, 4, 3);
            btnNotice.Name = "btnNotice";
            btnNotice.Size = new Size(15, 15);
            btnNotice.TabIndex = 5;
            btnNotice.UseVisualStyleBackColor = false;
            // 
            // button_ThongTin
            // 
            button_ThongTin.AutoSize = true;
            button_ThongTin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_ThongTin.BackColor = Color.FromArgb(100, 100, 100);
            button_ThongTin.FlatAppearance.BorderSize = 0;
            button_ThongTin.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 80, 80);
            button_ThongTin.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 120, 120);
            button_ThongTin.FlatStyle = FlatStyle.Flat;
            button_ThongTin.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ThongTin.ForeColor = Color.White;
            button_ThongTin.Image = (Image)resources.GetObject("button_ThongTin.Image");
            button_ThongTin.ImageAlign = ContentAlignment.MiddleRight;
            button_ThongTin.Location = new Point(1610, 15);
            button_ThongTin.Margin = new Padding(0);
            button_ThongTin.Name = "button_ThongTin";
            button_ThongTin.Padding = new Padding(8);
            button_ThongTin.Size = new Size(79, 79);
            button_ThongTin.TabIndex = 4;
            button_ThongTin.TextAlign = ContentAlignment.MiddleLeft;
            button_ThongTin.UseVisualStyleBackColor = false;
            button_ThongTin.Click += button_ThongTin_Click;
            // 
            // button_ThongBao
            // 
            button_ThongBao.BackColor = Color.FromArgb(100, 100, 100);
            button_ThongBao.FlatAppearance.BorderSize = 0;
            button_ThongBao.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 80, 80);
            button_ThongBao.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 120, 120);
            button_ThongBao.FlatStyle = FlatStyle.Flat;
            button_ThongBao.Image = (Image)resources.GetObject("button_ThongBao.Image");
            button_ThongBao.Location = new Point(1716, 20);
            button_ThongBao.Margin = new Padding(0);
            button_ThongBao.Name = "button_ThongBao";
            button_ThongBao.Size = new Size(70, 70);
            button_ThongBao.TabIndex = 3;
            button_ThongBao.UseVisualStyleBackColor = false;
            button_ThongBao.Click += button_ThongBao_Click;
            // 
            // button_DangXuat
            // 
            button_DangXuat.BackColor = Color.FromArgb(100, 100, 100);
            button_DangXuat.FlatAppearance.BorderSize = 0;
            button_DangXuat.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 80, 80);
            button_DangXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 120, 120);
            button_DangXuat.FlatStyle = FlatStyle.Flat;
            button_DangXuat.Image = (Image)resources.GetObject("button_DangXuat.Image");
            button_DangXuat.Location = new Point(1807, 20);
            button_DangXuat.Margin = new Padding(0);
            button_DangXuat.Name = "button_DangXuat";
            button_DangXuat.Size = new Size(70, 70);
            button_DangXuat.TabIndex = 2;
            button_DangXuat.UseVisualStyleBackColor = false;
            button_DangXuat.Click += button_DangXuat_Click;
            // 
            // label_TitleTrangChu
            // 
            label_TitleTrangChu.AutoSize = true;
            label_TitleTrangChu.Font = new Font("Segoe UI", 38F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TitleTrangChu.ForeColor = Color.White;
            label_TitleTrangChu.Location = new Point(120, 20);
            label_TitleTrangChu.Margin = new Padding(0);
            label_TitleTrangChu.Name = "label_TitleTrangChu";
            label_TitleTrangChu.Size = new Size(1020, 68);
            label_TitleTrangChu.TabIndex = 1;
            label_TitleTrangChu.Text = "HỆ THỐNG QUẢN LÝ TRẮC NGHIỆM SGU";
            // 
            // pictureBox_Logo
            // 
            pictureBox_Logo.Image = (Image)resources.GetObject("pictureBox_Logo.Image");
            pictureBox_Logo.Location = new Point(15, 15);
            pictureBox_Logo.Margin = new Padding(0);
            pictureBox_Logo.Name = "pictureBox_Logo";
            pictureBox_Logo.Size = new Size(90, 90);
            pictureBox_Logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Logo.TabIndex = 0;
            pictureBox_Logo.TabStop = false;
            // 
            // panel_Left
            // 
            panel_Left.BackColor = Color.FromArgb(70, 130, 180);
            panel_Left.BorderStyle = BorderStyle.None;
            panel_Left.Location = new Point(0, 110);
            panel_Left.Margin = new Padding(0);
            panel_Left.Name = "panel_Left";
            panel_Left.Padding = new Padding(5);
            panel_Left.Size = new Size(365, 934);
            panel_Left.TabIndex = 1;
            // 
            // button_TrangChu
            // 
            button_TrangChu.BackColor = Color.FromArgb(90, 90, 90);
            button_TrangChu.FlatAppearance.BorderSize = 0;
            button_TrangChu.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_TrangChu.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_TrangChu.FlatStyle = FlatStyle.Flat;
            button_TrangChu.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_TrangChu.ForeColor = Color.White;
            button_TrangChu.Image = (Image)resources.GetObject("button_TrangChu.Image");
            button_TrangChu.ImageAlign = ContentAlignment.MiddleLeft;
            button_TrangChu.Location = new Point(5, 5);
            button_TrangChu.Margin = new Padding(0);
            button_TrangChu.Name = "button_TrangChu";
            button_TrangChu.Padding = new Padding(10, 0, 10, 0);
            button_TrangChu.Size = new Size(355, 75);
            button_TrangChu.TabIndex = 0;
            button_TrangChu.Text = "Trang Chủ";
            button_TrangChu.TextAlign = ContentAlignment.MiddleCenter;
            button_TrangChu.UseVisualStyleBackColor = false;
            button_TrangChu.Click += button_TrangChu_Click;
            // 
            // button_PhanQuyen
            // 
            button_PhanQuyen.BackColor = Color.FromArgb(90, 90, 90);
            button_PhanQuyen.FlatAppearance.BorderSize = 0;
            button_PhanQuyen.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_PhanQuyen.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_PhanQuyen.FlatStyle = FlatStyle.Flat;
            button_PhanQuyen.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_PhanQuyen.ForeColor = Color.White;
            button_PhanQuyen.Image = (Image)resources.GetObject("button_PhanQuyen.Image");
            button_PhanQuyen.ImageAlign = ContentAlignment.MiddleLeft;
            button_PhanQuyen.Location = new Point(5, 85);
            button_PhanQuyen.Margin = new Padding(0);
            button_PhanQuyen.Name = "button_PhanQuyen";
            button_PhanQuyen.Padding = new Padding(10, 0, 10, 0);
            button_PhanQuyen.Size = new Size(355, 75);
            button_PhanQuyen.TabIndex = 9;
            button_PhanQuyen.Text = "Phân Quyền";
            button_PhanQuyen.TextAlign = ContentAlignment.MiddleCenter;
            button_PhanQuyen.UseVisualStyleBackColor = false;
            button_PhanQuyen.Click += button_PhanQuyen_Click;
            // 
            // button_PhanCong
            // 
            button_PhanCong.BackColor = Color.FromArgb(90, 90, 90);
            button_PhanCong.FlatAppearance.BorderSize = 0;
            button_PhanCong.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_PhanCong.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_PhanCong.FlatStyle = FlatStyle.Flat;
            button_PhanCong.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_PhanCong.ForeColor = Color.White;
            button_PhanCong.Image = (Image)resources.GetObject("button_PhanCong.Image");
            button_PhanCong.ImageAlign = ContentAlignment.MiddleLeft;
            button_PhanCong.Location = new Point(5, 165);
            button_PhanCong.Margin = new Padding(0);
            button_PhanCong.Name = "button_PhanCong";
            button_PhanCong.Padding = new Padding(10, 0, 10, 0);
            button_PhanCong.Size = new Size(355, 75);
            button_PhanCong.TabIndex = 8;
            button_PhanCong.Text = "Phân Công";
            button_PhanCong.TextAlign = ContentAlignment.MiddleCenter;
            button_PhanCong.UseVisualStyleBackColor = false;
            button_PhanCong.Click += button_PhanCong_Click;
            // 
            // button_MonHoc
            // 
            button_MonHoc.BackColor = Color.FromArgb(90, 90, 90);
            button_MonHoc.FlatAppearance.BorderSize = 0;
            button_MonHoc.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_MonHoc.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_MonHoc.FlatStyle = FlatStyle.Flat;
            button_MonHoc.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_MonHoc.ForeColor = Color.White;
            button_MonHoc.Image = (Image)resources.GetObject("button_MonHoc.Image");
            button_MonHoc.ImageAlign = ContentAlignment.MiddleLeft;
            button_MonHoc.Location = new Point(5, 245);
            button_MonHoc.Margin = new Padding(0);
            button_MonHoc.Name = "button_MonHoc";
            button_MonHoc.Padding = new Padding(10, 0, 10, 0);
            button_MonHoc.Size = new Size(355, 75);
            button_MonHoc.TabIndex = 7;
            button_MonHoc.Text = "Môn Học";
            button_MonHoc.TextAlign = ContentAlignment.MiddleCenter;
            button_MonHoc.UseVisualStyleBackColor = false;
            ArrayList ctpq = cTNhomQuyenBUS.GetListCTNhomQuyen(UserSession.Quyen);
            foreach (CTNhomQuyen pq in ctpq)
            {
                if (pq.maChucNang == 4)
                {
                    if (pq.xem == 0)
                    {
                        button_MonHoc.Click += button_MonHocNguoiDung_Click;
                    }
                    else
                    {
                        button_MonHoc.Click += button_MonHoc_Click;
                    }

                }
            }
            // 
            // button_ThongBaoAdmin
            // 
            button_ThongBaoAdmin.BackColor = Color.FromArgb(90, 90, 90);
            button_ThongBaoAdmin.FlatAppearance.BorderSize = 0;
            button_ThongBaoAdmin.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_ThongBaoAdmin.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_ThongBaoAdmin.FlatStyle = FlatStyle.Flat;
            button_ThongBaoAdmin.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ThongBaoAdmin.ForeColor = Color.White;
            button_ThongBaoAdmin.Image = (Image)resources.GetObject("button_ThongBaoAdmin.Image");
            button_ThongBaoAdmin.ImageAlign = ContentAlignment.MiddleLeft;
            button_ThongBaoAdmin.Location = new Point(5, 325);
            button_ThongBaoAdmin.Margin = new Padding(0);
            button_ThongBaoAdmin.Name = "button_ThongBaoAdmin";
            button_ThongBaoAdmin.Padding = new Padding(10, 0, 10, 0);
            button_ThongBaoAdmin.Size = new Size(355, 75);
            button_ThongBaoAdmin.TabIndex = 6;
            button_ThongBaoAdmin.Text = "Thông Báo";
            button_ThongBaoAdmin.TextAlign = ContentAlignment.MiddleCenter;
            button_ThongBaoAdmin.UseVisualStyleBackColor = false;
            button_ThongBaoAdmin.Click += button_ThongBaoAdmin_Click;
            // 
            // button_CauHoi
            // 
            button_CauHoi.BackColor = Color.FromArgb(90, 90, 90);
            button_CauHoi.FlatAppearance.BorderSize = 0;
            button_CauHoi.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_CauHoi.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_CauHoi.FlatStyle = FlatStyle.Flat;
            button_CauHoi.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_CauHoi.ForeColor = Color.White;
            button_CauHoi.Image = (Image)resources.GetObject("button_CauHoi.Image");
            button_CauHoi.ImageAlign = ContentAlignment.MiddleLeft;
            button_CauHoi.Location = new Point(5, 405);
            button_CauHoi.Margin = new Padding(0);
            button_CauHoi.Name = "button_CauHoi";
            button_CauHoi.Padding = new Padding(10, 0, 10, 0);
            button_CauHoi.Size = new Size(355, 75);
            button_CauHoi.TabIndex = 5;
            button_CauHoi.Text = "Câu Hỏi";
            button_CauHoi.TextAlign = ContentAlignment.MiddleCenter;
            button_CauHoi.UseVisualStyleBackColor = false;
            button_CauHoi.Click += button_CauHoi_Click;
            // 
            // button_DeKiemTra
            // 
            button_DeKiemTra.BackColor = Color.FromArgb(90, 90, 90);
            button_DeKiemTra.FlatAppearance.BorderSize = 0;
            button_DeKiemTra.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_DeKiemTra.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_DeKiemTra.FlatStyle = FlatStyle.Flat;
            button_DeKiemTra.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_DeKiemTra.ForeColor = Color.White;
            button_DeKiemTra.Image = (Image)resources.GetObject("button_DeKiemTra.Image");
            button_DeKiemTra.ImageAlign = ContentAlignment.MiddleLeft;
            button_DeKiemTra.Location = new Point(5, 485);
            button_DeKiemTra.Margin = new Padding(0);
            button_DeKiemTra.Name = "button_DeKiemTra";
            button_DeKiemTra.Padding = new Padding(10, 0, 10, 0);
            button_DeKiemTra.Size = new Size(355, 75);
            button_DeKiemTra.TabIndex = 4;
            button_DeKiemTra.Text = "Đề Kiểm Tra";
            button_DeKiemTra.TextAlign = ContentAlignment.MiddleCenter;
            button_DeKiemTra.UseVisualStyleBackColor = false;
            button_DeKiemTra.Click += button_DeKiemTra_Click;
            // 
            // button_NhomHocPhan
            // 
            button_NhomHocPhan.BackColor = Color.FromArgb(90, 90, 90);
            button_NhomHocPhan.FlatAppearance.BorderSize = 0;
            button_NhomHocPhan.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_NhomHocPhan.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_NhomHocPhan.FlatStyle = FlatStyle.Flat;
            button_NhomHocPhan.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_NhomHocPhan.ForeColor = Color.White;
            button_NhomHocPhan.Image = (Image)resources.GetObject("button_NhomHocPhan.Image");
            button_NhomHocPhan.ImageAlign = ContentAlignment.MiddleLeft;
            button_NhomHocPhan.Location = new Point(5, 565);
            button_NhomHocPhan.Margin = new Padding(0);
            button_NhomHocPhan.Name = "button_NhomHocPhan";
            button_NhomHocPhan.Padding = new Padding(10, 0, 10, 0);
            button_NhomHocPhan.Size = new Size(355, 75);
            button_NhomHocPhan.TabIndex = 3;
            button_NhomHocPhan.Text = "Nhóm Học Phần";
            button_NhomHocPhan.TextAlign = ContentAlignment.MiddleCenter;
            button_NhomHocPhan.UseVisualStyleBackColor = false;
            button_NhomHocPhan.Click += button_NhomHocPhan_Click;
            // 
            // button_DeThi
            // 
            button_DeThi.BackColor = Color.FromArgb(90, 90, 90);
            button_DeThi.FlatAppearance.BorderSize = 0;
            button_DeThi.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_DeThi.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_DeThi.FlatStyle = FlatStyle.Flat;
            button_DeThi.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_DeThi.ForeColor = Color.White;
            button_DeThi.Image = (Image)resources.GetObject("button_DeThi.Image");
            button_DeThi.ImageAlign = ContentAlignment.MiddleLeft;
            button_DeThi.Location = new Point(5, 645);
            button_DeThi.Margin = new Padding(0);
            button_DeThi.Name = "button_DeThi";
            button_DeThi.Padding = new Padding(10, 0, 10, 0);
            button_DeThi.Size = new Size(355, 75);
            button_DeThi.TabIndex = 2;
            button_DeThi.Text = "Đề Thi";
            button_DeThi.TextAlign = ContentAlignment.MiddleCenter;
            button_DeThi.UseVisualStyleBackColor = false;
            button_DeThi.Click += button_DeThi_Click;
            // 
            // button_HocPhan
            // 
            button_HocPhan.BackColor = Color.FromArgb(90, 90, 90);
            button_HocPhan.FlatAppearance.BorderSize = 0;
            button_HocPhan.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_HocPhan.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_HocPhan.FlatStyle = FlatStyle.Flat;
            button_HocPhan.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_HocPhan.ForeColor = Color.White;
            button_HocPhan.Image = (Image)resources.GetObject("button_HocPhan.Image");
            button_HocPhan.ImageAlign = ContentAlignment.MiddleLeft;
            button_HocPhan.Location = new Point(5, 725);
            button_HocPhan.Margin = new Padding(0);
            button_HocPhan.Name = "button_HocPhan";
            button_HocPhan.Padding = new Padding(10, 0, 10, 0);
            button_HocPhan.Size = new Size(355, 75);
            button_HocPhan.TabIndex = 1;
            button_HocPhan.Text = "Nhóm tham gia";
            button_HocPhan.TextAlign = ContentAlignment.MiddleCenter;
            button_HocPhan.UseVisualStyleBackColor = false;
            button_HocPhan.Click += button_HocPhan_Click;
            // 
            // button_NguoiDung
            // 
            button_NguoiDung.BackColor = Color.FromArgb(90, 90, 90);
            button_NguoiDung.FlatAppearance.BorderSize = 0;
            button_NguoiDung.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_NguoiDung.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_NguoiDung.FlatStyle = FlatStyle.Flat;
            button_NguoiDung.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_NguoiDung.ForeColor = Color.White;
            button_NguoiDung.Image = (Image)resources.GetObject("button_NguoiDung.Image");
            button_NguoiDung.ImageAlign = ContentAlignment.MiddleLeft;
            button_NguoiDung.Location = new Point(5, 805);
            button_NguoiDung.Margin = new Padding(0);
            button_NguoiDung.Name = "button_NguoiDung";
            button_NguoiDung.Padding = new Padding(10, 0, 10, 0);
            button_NguoiDung.Size = new Size(355, 75);
            button_NguoiDung.TabIndex = 10;
            button_NguoiDung.Text = "Người Dùng";
            button_NguoiDung.TextAlign = ContentAlignment.MiddleCenter;
            button_NguoiDung.UseVisualStyleBackColor = false;
            button_NguoiDung.Click += button_NguoiDung_Click;
            // 
            // button_ThongKe
            // 
            button_ThongKe.BackColor = Color.FromArgb(90, 90, 90);
            button_ThongKe.FlatAppearance.BorderSize = 0;
            button_ThongKe.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 70, 70);
            button_ThongKe.FlatAppearance.MouseOverBackColor = Color.FromArgb(110, 110, 110);
            button_ThongKe.FlatStyle = FlatStyle.Flat;
            button_ThongKe.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ThongKe.ForeColor = Color.White;
            button_ThongKe.Image = (Image)resources.GetObject("button_ThongKe.Image");
            button_ThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            button_ThongKe.Location = new Point(5, 885);
            button_ThongKe.Margin = new Padding(0);
            button_ThongKe.Name = "button_ThongKe";
            button_ThongKe.Padding = new Padding(10, 0, 10, 0);
            button_ThongKe.Size = new Size(355, 75);
            button_ThongKe.TabIndex = 11;
            button_ThongKe.Text = "Thống kê";
            button_ThongKe.TextAlign = ContentAlignment.MiddleCenter;
            button_ThongKe.UseVisualStyleBackColor = false;
            button_ThongKe.Click += button_ThongKe_Click;
            // 
            // panel_Main
            // 
            panel_Main.BackColor = Color.FromArgb(248, 250, 252);
            panel_Main.BorderStyle = BorderStyle.None;
            panel_Main.Location = new Point(365, 110);
            panel_Main.Margin = new Padding(0);
            panel_Main.Name = "panel_Main";
            panel_Main.Padding = new Padding(10);
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
            Load += Form1_Load;
            panel_Top.ResumeLayout(false);
            panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).EndInit();
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
        private Button button_ThongKe;
        private Button btnNotice;
    }
}