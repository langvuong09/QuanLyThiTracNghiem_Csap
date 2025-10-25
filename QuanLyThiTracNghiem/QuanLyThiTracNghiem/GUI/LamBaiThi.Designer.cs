namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class LamBaiThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LamBaiThi));
            panel_Top = new Panel();
            button_Thoat = new Button();
            label_TitleTrangChu = new Label();
            pictureBox_Logo = new PictureBox();
            panel_Bottom = new Panel();
            flowLayoutPanel_CauHoi = new FlowLayoutPanel();
            label_TenThiSinh = new Label();
            label_DemThoiGian = new Label();
            pictureBox_DongHo = new PictureBox();
            button_NopBai = new Button();
            label_SoCauDung = new Label();
            label1 = new Label();
            pictureBox_iconCauDung = new PictureBox();
            pictureBox_iconSoCauDung = new PictureBox();
            panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).BeginInit();
            panel_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_DongHo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_iconCauDung).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_iconSoCauDung).BeginInit();
            SuspendLayout();
            // 
            // panel_Top
            // 
            panel_Top.BackColor = SystemColors.ActiveCaption;
            panel_Top.BorderStyle = BorderStyle.Fixed3D;
            panel_Top.Controls.Add(pictureBox_DongHo);
            panel_Top.Controls.Add(label_DemThoiGian);
            panel_Top.Controls.Add(label_TenThiSinh);
            panel_Top.Controls.Add(button_Thoat);
            panel_Top.Controls.Add(label_TitleTrangChu);
            panel_Top.Controls.Add(pictureBox_Logo);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(1904, 100);
            panel_Top.TabIndex = 1;
            // 
            // button_Thoat
            // 
            button_Thoat.BackColor = Color.Coral;
            button_Thoat.Image = (Image)resources.GetObject("button_Thoat.Image");
            button_Thoat.Location = new Point(1822, 22);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(58, 52);
            button_Thoat.TabIndex = 2;
            button_Thoat.UseVisualStyleBackColor = false;
            button_Thoat.Click += button_Thoat_Click;
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
            // panel_Bottom
            // 
            panel_Bottom.BackColor = SystemColors.ActiveCaption;
            panel_Bottom.Controls.Add(pictureBox_iconSoCauDung);
            panel_Bottom.Controls.Add(pictureBox_iconCauDung);
            panel_Bottom.Controls.Add(label1);
            panel_Bottom.Controls.Add(label_SoCauDung);
            panel_Bottom.Controls.Add(button_NopBai);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 959);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(1904, 82);
            panel_Bottom.TabIndex = 2;
            // 
            // flowLayoutPanel_CauHoi
            // 
            flowLayoutPanel_CauHoi.Dock = DockStyle.Fill;
            flowLayoutPanel_CauHoi.Location = new Point(0, 100);
            flowLayoutPanel_CauHoi.Name = "flowLayoutPanel_CauHoi";
            flowLayoutPanel_CauHoi.Size = new Size(1904, 859);
            flowLayoutPanel_CauHoi.TabIndex = 3;
            // 
            // label_TenThiSinh
            // 
            label_TenThiSinh.AutoSize = true;
            label_TenThiSinh.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TenThiSinh.Location = new Point(1419, 31);
            label_TenThiSinh.Name = "label_TenThiSinh";
            label_TenThiSinh.Size = new Size(250, 37);
            label_TenThiSinh.TabIndex = 3;
            label_TenThiSinh.Text = "Phạm Công Thành";
            // 
            // label_DemThoiGian
            // 
            label_DemThoiGian.AutoSize = true;
            label_DemThoiGian.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_DemThoiGian.ForeColor = Color.OrangeRed;
            label_DemThoiGian.Location = new Point(1242, 29);
            label_DemThoiGian.Name = "label_DemThoiGian";
            label_DemThoiGian.Size = new Size(154, 45);
            label_DemThoiGian.TabIndex = 5;
            label_DemThoiGian.Text = "00:00:00";
            // 
            // pictureBox_DongHo
            // 
            pictureBox_DongHo.Image = (Image)resources.GetObject("pictureBox_DongHo.Image");
            pictureBox_DongHo.Location = new Point(1180, 29);
            pictureBox_DongHo.Name = "pictureBox_DongHo";
            pictureBox_DongHo.Size = new Size(56, 50);
            pictureBox_DongHo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_DongHo.TabIndex = 6;
            pictureBox_DongHo.TabStop = false;
            // 
            // button_NopBai
            // 
            button_NopBai.BackColor = Color.Tomato;
            button_NopBai.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_NopBai.ForeColor = SystemColors.ButtonHighlight;
            button_NopBai.Location = new Point(1620, 17);
            button_NopBai.Name = "button_NopBai";
            button_NopBai.Size = new Size(272, 53);
            button_NopBai.TabIndex = 0;
            button_NopBai.Text = "NỘP NÀI";
            button_NopBai.UseVisualStyleBackColor = false;
            // 
            // label_SoCauDung
            // 
            label_SoCauDung.AutoSize = true;
            label_SoCauDung.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_SoCauDung.ForeColor = Color.IndianRed;
            label_SoCauDung.Location = new Point(79, 23);
            label_SoCauDung.Name = "label_SoCauDung";
            label_SoCauDung.Size = new Size(226, 37);
            label_SoCauDung.TabIndex = 1;
            label_SoCauDung.Text = "Số Câu Đúng: 30";
            // 
            // lblTitle
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(433, 23);
            label1.Name = "lblTitle";
            label1.Size = new Size(204, 37);
            label1.TabIndex = 2;
            label1.Text = "Tổng Điểm: 30";
            // 
            // pictureBox_iconCauDung
            // 
            pictureBox_iconCauDung.Image = (Image)resources.GetObject("pictureBox_iconCauDung.Image");
            pictureBox_iconCauDung.Location = new Point(10, 17);
            pictureBox_iconCauDung.Name = "pictureBox_iconCauDung";
            pictureBox_iconCauDung.Size = new Size(63, 53);
            pictureBox_iconCauDung.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_iconCauDung.TabIndex = 3;
            pictureBox_iconCauDung.TabStop = false;
            // 
            // pictureBox_iconSoCauDung
            // 
            pictureBox_iconSoCauDung.Image = (Image)resources.GetObject("pictureBox_iconSoCauDung.Image");
            pictureBox_iconSoCauDung.Location = new Point(370, 17);
            pictureBox_iconSoCauDung.Name = "pictureBox_iconSoCauDung";
            pictureBox_iconSoCauDung.Size = new Size(57, 53);
            pictureBox_iconSoCauDung.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_iconSoCauDung.TabIndex = 4;
            pictureBox_iconSoCauDung.TabStop = false;
            // 
            // LamBaiThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(flowLayoutPanel_CauHoi);
            Controls.Add(panel_Bottom);
            Controls.Add(panel_Top);
            Name = "LamBaiThi";
            Text = "LamBaiThi";
            panel_Top.ResumeLayout(false);
            panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Logo).EndInit();
            panel_Bottom.ResumeLayout(false);
            panel_Bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_DongHo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_iconCauDung).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_iconSoCauDung).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Top;
        private Label label_TitleTrangChu;
        private PictureBox pictureBox_Logo;
        private Panel panel_Bottom;
        private FlowLayoutPanel flowLayoutPanel_CauHoi;
        private Button button_Thoat;
        private Label label_TenThiSinh;
        private Label label_DemThoiGian;
        private PictureBox pictureBox_DongHo;
        private Button button_NopBai;
        private Label label1;
        private Label label_SoCauDung;
        private PictureBox pictureBox_iconCauDung;
        private PictureBox pictureBox_iconSoCauDung;
    }
}