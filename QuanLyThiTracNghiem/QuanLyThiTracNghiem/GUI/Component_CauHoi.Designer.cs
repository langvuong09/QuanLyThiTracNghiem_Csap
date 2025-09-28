namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_CauHoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_CauHoi));
            button_ThemCauHoi = new Button();
            button_Reload = new Button();
            panel_LocVaTimKiem = new Panel();
            button_TimKiem = new Button();
            textBox_TimKiem = new TextBox();
            comboBox_DoKho = new ComboBox();
            comboBox_Chuong = new ComboBox();
            comboBox_MonHoc = new ComboBox();
            dataGridView_DSCauHoi = new DataGridView();
            button_Xem = new Button();
            button_Sua = new Button();
            button_Xoa = new Button();
            comboBox_ChiSo = new ComboBox();
            button_Next = new Button();
            button_Prev = new Button();
            panel_LocVaTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSCauHoi).BeginInit();
            SuspendLayout();
            // 
            // button_ThemCauHoi
            // 
            button_ThemCauHoi.BackColor = Color.DeepSkyBlue;
            button_ThemCauHoi.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ThemCauHoi.ForeColor = SystemColors.ButtonHighlight;
            button_ThemCauHoi.Image = (Image)resources.GetObject("button_ThemCauHoi.Image");
            button_ThemCauHoi.ImageAlign = ContentAlignment.MiddleLeft;
            button_ThemCauHoi.Location = new Point(1307, 18);
            button_ThemCauHoi.Name = "button_ThemCauHoi";
            button_ThemCauHoi.Size = new Size(214, 64);
            button_ThemCauHoi.TabIndex = 0;
            button_ThemCauHoi.Text = "TẠO CÂU HỎI";
            button_ThemCauHoi.TextAlign = ContentAlignment.MiddleRight;
            button_ThemCauHoi.UseVisualStyleBackColor = false;
            button_ThemCauHoi.Click += button_ThemCauHoi_Click;
            // 
            // button_Reload
            // 
            button_Reload.BackColor = Color.DeepPink;
            button_Reload.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Reload.ForeColor = SystemColors.ButtonHighlight;
            button_Reload.Image = (Image)resources.GetObject("button_Reload.Image");
            button_Reload.Location = new Point(1183, 18);
            button_Reload.Name = "button_Reload";
            button_Reload.Size = new Size(103, 64);
            button_Reload.TabIndex = 1;
            button_Reload.TextAlign = ContentAlignment.MiddleRight;
            button_Reload.UseVisualStyleBackColor = false;
            button_Reload.Click += button_Reload_Click;
            // 
            // panel_LocVaTimKiem
            // 
            panel_LocVaTimKiem.BackColor = Color.SkyBlue;
            panel_LocVaTimKiem.Controls.Add(button_TimKiem);
            panel_LocVaTimKiem.Controls.Add(textBox_TimKiem);
            panel_LocVaTimKiem.Controls.Add(comboBox_DoKho);
            panel_LocVaTimKiem.Controls.Add(comboBox_Chuong);
            panel_LocVaTimKiem.Controls.Add(comboBox_MonHoc);
            panel_LocVaTimKiem.Location = new Point(8, 99);
            panel_LocVaTimKiem.Name = "panel_LocVaTimKiem";
            panel_LocVaTimKiem.Size = new Size(1513, 141);
            panel_LocVaTimKiem.TabIndex = 2;
            // 
            // button_TimKiem
            // 
            button_TimKiem.BackColor = Color.DeepSkyBlue;
            button_TimKiem.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_TimKiem.ForeColor = SystemColors.ButtonHighlight;
            button_TimKiem.Image = (Image)resources.GetObject("button_TimKiem.Image");
            button_TimKiem.ImageAlign = ContentAlignment.MiddleLeft;
            button_TimKiem.Location = new Point(1344, 74);
            button_TimKiem.Name = "button_TimKiem";
            button_TimKiem.Size = new Size(155, 52);
            button_TimKiem.TabIndex = 4;
            button_TimKiem.Text = "Tìm Kiếm";
            button_TimKiem.TextAlign = ContentAlignment.MiddleRight;
            button_TimKiem.UseVisualStyleBackColor = false;
            button_TimKiem.Click += button_TimKiem_Click;
            // 
            // textBox_TimKiem
            // 
            textBox_TimKiem.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_TimKiem.Location = new Point(13, 74);
            textBox_TimKiem.Multiline = true;
            textBox_TimKiem.Name = "textBox_TimKiem";
            textBox_TimKiem.Size = new Size(1325, 52);
            textBox_TimKiem.TabIndex = 3;
            // 
            // comboBox_DoKho
            // 
            comboBox_DoKho.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_DoKho.FormattingEnabled = true;
            comboBox_DoKho.Location = new Point(1222, 29);
            comboBox_DoKho.Name = "comboBox_DoKho";
            comboBox_DoKho.Size = new Size(277, 32);
            comboBox_DoKho.TabIndex = 2;
            comboBox_DoKho.SelectedIndexChanged += comboBox_DoKho_SelectionChangeCommitted;
            // 
            // comboBox_Chuong
            // 
            comboBox_Chuong.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Chuong.FormattingEnabled = true;
            comboBox_Chuong.Location = new Point(492, 29);
            comboBox_Chuong.Name = "comboBox_Chuong";
            comboBox_Chuong.Size = new Size(707, 32);
            comboBox_Chuong.TabIndex = 1;
            comboBox_Chuong.SelectedIndexChanged += comboBox_Chuong_SelectionChangeCommitted;
            // 
            // comboBox_MonHoc
            // 
            comboBox_MonHoc.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_MonHoc.FormattingEnabled = true;
            comboBox_MonHoc.Location = new Point(13, 29);
            comboBox_MonHoc.Name = "comboBox_MonHoc";
            comboBox_MonHoc.Size = new Size(455, 32);
            comboBox_MonHoc.TabIndex = 0;
            comboBox_MonHoc.SelectedIndexChanged += comboBox_MonHoc_SelectionChangeCommitted;
            // 
            // dataGridView_DSCauHoi
            // 
            dataGridView_DSCauHoi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_DSCauHoi.Location = new Point(8, 257);
            dataGridView_DSCauHoi.Name = "dataGridView_DSCauHoi";
            dataGridView_DSCauHoi.Size = new Size(1377, 603);
            dataGridView_DSCauHoi.TabIndex = 3;
            dataGridView_DSCauHoi.CellContentClick += dataGridView_DSCauHoi_CellContentClick;
            // 
            // button_Xem
            // 
            button_Xem.BackColor = Color.DeepSkyBlue;
            button_Xem.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Xem.ForeColor = SystemColors.ButtonHighlight;
            button_Xem.Image = (Image)resources.GetObject("button_Xem.Image");
            button_Xem.ImageAlign = ContentAlignment.MiddleLeft;
            button_Xem.Location = new Point(1401, 257);
            button_Xem.Name = "button_Xem";
            button_Xem.Size = new Size(120, 52);
            button_Xem.TabIndex = 5;
            button_Xem.Text = "XEM";
            button_Xem.TextAlign = ContentAlignment.MiddleRight;
            button_Xem.UseVisualStyleBackColor = false;
            button_Xem.Click += button_Xem_Click;
            // 
            // button_Sua
            // 
            button_Sua.BackColor = Color.DarkTurquoise;
            button_Sua.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Sua.ForeColor = SystemColors.ButtonHighlight;
            button_Sua.Image = (Image)resources.GetObject("button_Sua.Image");
            button_Sua.ImageAlign = ContentAlignment.MiddleLeft;
            button_Sua.Location = new Point(1401, 326);
            button_Sua.Name = "button_Sua";
            button_Sua.Size = new Size(120, 52);
            button_Sua.TabIndex = 6;
            button_Sua.Text = "SỬA";
            button_Sua.TextAlign = ContentAlignment.MiddleRight;
            button_Sua.UseVisualStyleBackColor = false;
            button_Sua.Click += button_Sua_Click;
            // 
            // button_Xoa
            // 
            button_Xoa.BackColor = Color.Pink;
            button_Xoa.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Xoa.ForeColor = SystemColors.ButtonHighlight;
            button_Xoa.Image = (Image)resources.GetObject("button_Xoa.Image");
            button_Xoa.ImageAlign = ContentAlignment.TopLeft;
            button_Xoa.Location = new Point(1401, 399);
            button_Xoa.Name = "button_Xoa";
            button_Xoa.Size = new Size(120, 52);
            button_Xoa.TabIndex = 7;
            button_Xoa.Text = "XÓA";
            button_Xoa.TextAlign = ContentAlignment.MiddleRight;
            button_Xoa.UseVisualStyleBackColor = false;
            button_Xoa.Click += button_Xoa_Click;
            // 
            // comboBox_ChiSo
            // 
            comboBox_ChiSo.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_ChiSo.FormattingEnabled = true;
            comboBox_ChiSo.Location = new Point(1309, 879);
            comboBox_ChiSo.Name = "comboBox_ChiSo";
            comboBox_ChiSo.Size = new Size(86, 35);
            comboBox_ChiSo.TabIndex = 8;
            // 
            // button_Next
            // 
            button_Next.BackColor = Color.DeepSkyBlue;
            button_Next.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Next.ForeColor = SystemColors.ButtonHighlight;
            button_Next.ImageAlign = ContentAlignment.MiddleLeft;
            button_Next.Location = new Point(1401, 870);
            button_Next.Name = "button_Next";
            button_Next.Size = new Size(120, 50);
            button_Next.TabIndex = 9;
            button_Next.Text = "Next";
            button_Next.UseVisualStyleBackColor = false;
            button_Next.Click += button_Next_Click;
            // 
            // button_Prev
            // 
            button_Prev.BackColor = Color.DeepSkyBlue;
            button_Prev.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Prev.ForeColor = SystemColors.ButtonHighlight;
            button_Prev.ImageAlign = ContentAlignment.MiddleLeft;
            button_Prev.Location = new Point(1183, 870);
            button_Prev.Name = "button_Prev";
            button_Prev.Size = new Size(120, 50);
            button_Prev.TabIndex = 10;
            button_Prev.Text = "Prev";
            button_Prev.UseVisualStyleBackColor = false;
            button_Prev.Click += button_Prev_Click;
            // 
            // Component_CauHoi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button_Prev);
            Controls.Add(button_Next);
            Controls.Add(comboBox_ChiSo);
            Controls.Add(button_Xoa);
            Controls.Add(button_Sua);
            Controls.Add(button_Xem);
            Controls.Add(dataGridView_DSCauHoi);
            Controls.Add(panel_LocVaTimKiem);
            Controls.Add(button_Reload);
            Controls.Add(button_ThemCauHoi);
            Name = "Component_CauHoi";
            Size = new Size(1541, 934);
            panel_LocVaTimKiem.ResumeLayout(false);
            panel_LocVaTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSCauHoi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button_ThemCauHoi;
        private Button button_Reload;
        private Panel panel_LocVaTimKiem;
        private ComboBox comboBox_DoKho;
        private ComboBox comboBox_Chuong;
        private ComboBox comboBox_MonHoc;
        private TextBox textBox_TimKiem;
        private Button button_TimKiem;
        private DataGridView dataGridView_DSCauHoi;
        private Button button_Xem;
        private Button button_Sua;
        private Button button_Xoa;
        private ComboBox comboBox_ChiSo;
        private Button button_Next;
        private Button button_Prev;
    }
}
