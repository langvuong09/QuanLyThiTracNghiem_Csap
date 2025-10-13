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
            button_XemChiTiet = new Button();
            label_BaiKiemTra = new Label();
            label_NhomHocPhan = new Label();
            label_MonHoc = new Label();
            label_ThoiGianBatDau = new Label();
            label_ThoiGianKetThuc = new Label();
            textBox_BaiKiemTra = new TextBox();
            textBox_NhomHocPhan = new TextBox();
            textBox_MonHoc = new TextBox();
            textBox_TGianBDau = new TextBox();
            textBox_TGianKThuc = new TextBox();
            SuspendLayout();
            // 
            // button_XemChiTiet
            // 
            button_XemChiTiet.BackColor = SystemColors.ActiveCaption;
            button_XemChiTiet.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_XemChiTiet.ForeColor = SystemColors.ButtonFace;
            button_XemChiTiet.Image = (Image)resources.GetObject("button_XemChiTiet.Image");
            button_XemChiTiet.Location = new Point(1414, 117);
            button_XemChiTiet.Name = "button_XemChiTiet";
            button_XemChiTiet.Size = new Size(101, 45);
            button_XemChiTiet.TabIndex = 5;
            button_XemChiTiet.TextAlign = ContentAlignment.MiddleRight;
            button_XemChiTiet.UseVisualStyleBackColor = false;
            button_XemChiTiet.Click += button_XemChiTiet_Click;
            // 
            // label_BaiKiemTra
            // 
            label_BaiKiemTra.AutoSize = true;
            label_BaiKiemTra.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_BaiKiemTra.Location = new Point(15, 23);
            label_BaiKiemTra.Name = "label_BaiKiemTra";
            label_BaiKiemTra.Size = new Size(127, 30);
            label_BaiKiemTra.TabIndex = 6;
            label_BaiKiemTra.Text = "Bài kiểm tra:";
            // 
            // label_NhomHocPhan
            // 
            label_NhomHocPhan.AutoSize = true;
            label_NhomHocPhan.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_NhomHocPhan.Location = new Point(15, 78);
            label_NhomHocPhan.Name = "label_NhomHocPhan";
            label_NhomHocPhan.Size = new Size(169, 30);
            label_NhomHocPhan.TabIndex = 7;
            label_NhomHocPhan.Text = "Nhóm học phần:";
            // 
            // label_MonHoc
            // 
            label_MonHoc.AutoSize = true;
            label_MonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_MonHoc.Location = new Point(15, 132);
            label_MonHoc.Name = "label_MonHoc";
            label_MonHoc.Size = new Size(101, 30);
            label_MonHoc.TabIndex = 8;
            label_MonHoc.Text = "Môn học:";
            // 
            // label_ThoiGianBatDau
            // 
            label_ThoiGianBatDau.AutoSize = true;
            label_ThoiGianBatDau.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ThoiGianBatDau.Location = new Point(765, 21);
            label_ThoiGianBatDau.Name = "label_ThoiGianBatDau";
            label_ThoiGianBatDau.Size = new Size(181, 30);
            label_ThoiGianBatDau.TabIndex = 9;
            label_ThoiGianBatDau.Text = "Thòi gian bắt đầu:";
            // 
            // label_ThoiGianKetThuc
            // 
            label_ThoiGianKetThuc.AutoSize = true;
            label_ThoiGianKetThuc.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ThoiGianKetThuc.Location = new Point(765, 76);
            label_ThoiGianKetThuc.Name = "label_ThoiGianKetThuc";
            label_ThoiGianKetThuc.Size = new Size(185, 30);
            label_ThoiGianKetThuc.TabIndex = 10;
            label_ThoiGianKetThuc.Text = "Thòi gian kết thúc:";
            // 
            // textBox_BaiKiemTra
            // 
            textBox_BaiKiemTra.BackColor = SystemColors.GradientActiveCaption;
            textBox_BaiKiemTra.BorderStyle = BorderStyle.None;
            textBox_BaiKiemTra.Enabled = false;
            textBox_BaiKiemTra.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_BaiKiemTra.ForeColor = Color.IndianRed;
            textBox_BaiKiemTra.Location = new Point(190, 18);
            textBox_BaiKiemTra.Name = "textBox_BaiKiemTra";
            textBox_BaiKiemTra.Size = new Size(560, 36);
            textBox_BaiKiemTra.TabIndex = 11;
            // 
            // textBox_NhomHocPhan
            // 
            textBox_NhomHocPhan.BackColor = SystemColors.GradientActiveCaption;
            textBox_NhomHocPhan.BorderStyle = BorderStyle.None;
            textBox_NhomHocPhan.Enabled = false;
            textBox_NhomHocPhan.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_NhomHocPhan.Location = new Point(190, 73);
            textBox_NhomHocPhan.Name = "textBox_NhomHocPhan";
            textBox_NhomHocPhan.Size = new Size(560, 28);
            textBox_NhomHocPhan.TabIndex = 12;
            // 
            // textBox_MonHoc
            // 
            textBox_MonHoc.BackColor = SystemColors.GradientActiveCaption;
            textBox_MonHoc.BorderStyle = BorderStyle.None;
            textBox_MonHoc.Enabled = false;
            textBox_MonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_MonHoc.Location = new Point(190, 127);
            textBox_MonHoc.Name = "textBox_MonHoc";
            textBox_MonHoc.Size = new Size(560, 28);
            textBox_MonHoc.TabIndex = 13;
            // 
            // textBox_TGianBDau
            // 
            textBox_TGianBDau.BackColor = SystemColors.GradientActiveCaption;
            textBox_TGianBDau.BorderStyle = BorderStyle.None;
            textBox_TGianBDau.Enabled = false;
            textBox_TGianBDau.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_TGianBDau.Location = new Point(952, 25);
            textBox_TGianBDau.Name = "textBox_TGianBDau";
            textBox_TGianBDau.Size = new Size(574, 28);
            textBox_TGianBDau.TabIndex = 14;
            // 
            // textBox_TGianKThuc
            // 
            textBox_TGianKThuc.BackColor = SystemColors.GradientActiveCaption;
            textBox_TGianKThuc.BorderStyle = BorderStyle.None;
            textBox_TGianKThuc.Enabled = false;
            textBox_TGianKThuc.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_TGianKThuc.Location = new Point(952, 78);
            textBox_TGianKThuc.Name = "textBox_TGianKThuc";
            textBox_TGianKThuc.Size = new Size(574, 28);
            textBox_TGianKThuc.TabIndex = 15;
            // 
            // Panel_ItemDeThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(textBox_TGianKThuc);
            Controls.Add(textBox_TGianBDau);
            Controls.Add(textBox_MonHoc);
            Controls.Add(textBox_NhomHocPhan);
            Controls.Add(textBox_BaiKiemTra);
            Controls.Add(label_ThoiGianKetThuc);
            Controls.Add(label_ThoiGianBatDau);
            Controls.Add(label_MonHoc);
            Controls.Add(label_NhomHocPhan);
            Controls.Add(label_BaiKiemTra);
            Controls.Add(button_XemChiTiet);
            Name = "Panel_ItemDeThi";
            Size = new Size(1540, 186);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_XemChiTiet;
        private Label label_BaiKiemTra;
        private Label label_NhomHocPhan;
        private Label label_MonHoc;
        private Label label_ThoiGianBatDau;
        private Label label_ThoiGianKetThuc;
        private TextBox textBox_BaiKiemTra;
        private TextBox textBox_NhomHocPhan;
        private TextBox textBox_MonHoc;
        private TextBox textBox_TGianBDau;
        private TextBox textBox_TGianKThuc;
    }
}
