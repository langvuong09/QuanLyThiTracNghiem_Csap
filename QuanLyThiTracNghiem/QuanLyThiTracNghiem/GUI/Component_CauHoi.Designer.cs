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
            comboBox_ChiSo = new ComboBox();
            button_Next = new Button();
            button_Prev = new Button();
            panel_LocVaTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSCauHoi).BeginInit();
            SuspendLayout();
            // 
            // button_ThemCauHoi
            // 
            button_ThemCauHoi.BackColor = Color.FromArgb(70, 130, 180);
            button_ThemCauHoi.FlatAppearance.BorderSize = 0;
            button_ThemCauHoi.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 100, 150);
            button_ThemCauHoi.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 150, 200);
            button_ThemCauHoi.FlatStyle = FlatStyle.Flat;
            button_ThemCauHoi.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ThemCauHoi.ForeColor = Color.White;
            button_ThemCauHoi.Image = (Image)resources.GetObject("button_ThemCauHoi.Image");
            button_ThemCauHoi.ImageAlign = ContentAlignment.MiddleLeft;
            button_ThemCauHoi.Location = new Point(1307, 15);
            button_ThemCauHoi.Margin = new Padding(0);
            button_ThemCauHoi.Name = "button_ThemCauHoi";
            button_ThemCauHoi.Padding = new Padding(10, 0, 10, 0);
            button_ThemCauHoi.Size = new Size(214, 75);
            button_ThemCauHoi.TabIndex = 0;
            button_ThemCauHoi.Text = "TẠO CÂU HỎI";
            button_ThemCauHoi.TextAlign = ContentAlignment.MiddleRight;
            button_ThemCauHoi.UseVisualStyleBackColor = false;
            button_ThemCauHoi.Click += button_ThemCauHoi_Click;
            // 
            // button_Reload
            // 
            button_Reload.BackColor = Color.FromArgb(255, 105, 180);
            button_Reload.FlatAppearance.BorderSize = 0;
            button_Reload.FlatAppearance.MouseDownBackColor = Color.FromArgb(220, 80, 150);
            button_Reload.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 130, 200);
            button_Reload.FlatStyle = FlatStyle.Flat;
            button_Reload.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Reload.ForeColor = Color.White;
            button_Reload.Image = (Image)resources.GetObject("button_Reload.Image");
            button_Reload.Location = new Point(1183, 15);
            button_Reload.Margin = new Padding(0);
            button_Reload.Name = "button_Reload";
            button_Reload.Size = new Size(103, 75);
            button_Reload.TabIndex = 1;
            button_Reload.TextAlign = ContentAlignment.MiddleRight;
            button_Reload.UseVisualStyleBackColor = false;
            button_Reload.Click += button_Reload_Click;
            // 
            // panel_LocVaTimKiem
            // 
            panel_LocVaTimKiem.BackColor = Color.FromArgb(240, 248, 255);
            panel_LocVaTimKiem.BorderStyle = BorderStyle.FixedSingle;
            panel_LocVaTimKiem.Controls.Add(button_TimKiem);
            panel_LocVaTimKiem.Controls.Add(textBox_TimKiem);
            panel_LocVaTimKiem.Controls.Add(comboBox_DoKho);
            panel_LocVaTimKiem.Controls.Add(comboBox_Chuong);
            panel_LocVaTimKiem.Controls.Add(comboBox_MonHoc);
            panel_LocVaTimKiem.Location = new Point(10, 105);
            panel_LocVaTimKiem.Margin = new Padding(0);
            panel_LocVaTimKiem.Name = "panel_LocVaTimKiem";
            panel_LocVaTimKiem.Padding = new Padding(15);
            panel_LocVaTimKiem.Size = new Size(1513, 160);
            panel_LocVaTimKiem.TabIndex = 2;
            // 
            // button_TimKiem
            // 
            button_TimKiem.BackColor = Color.FromArgb(70, 130, 180);
            button_TimKiem.FlatAppearance.BorderSize = 0;
            button_TimKiem.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 100, 150);
            button_TimKiem.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 150, 200);
            button_TimKiem.FlatStyle = FlatStyle.Flat;
            button_TimKiem.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_TimKiem.ForeColor = Color.White;
            button_TimKiem.Image = (Image)resources.GetObject("button_TimKiem.Image");
            button_TimKiem.ImageAlign = ContentAlignment.MiddleLeft;
            button_TimKiem.Location = new Point(1344, 88);
            button_TimKiem.Margin = new Padding(0);
            button_TimKiem.Name = "button_TimKiem";
            button_TimKiem.Padding = new Padding(8, 0, 8, 0);
            button_TimKiem.Size = new Size(155, 60);
            button_TimKiem.TabIndex = 4;
            button_TimKiem.Text = "Tìm Kiếm";
            button_TimKiem.TextAlign = ContentAlignment.MiddleRight;
            button_TimKiem.UseVisualStyleBackColor = false;
            button_TimKiem.Click += button_TimKiem_Click;
            // 
            // textBox_TimKiem
            // 
            textBox_TimKiem.BackColor = Color.White;
            textBox_TimKiem.BorderStyle = BorderStyle.FixedSingle;
            textBox_TimKiem.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_TimKiem.Location = new Point(18, 88);
            textBox_TimKiem.Margin = new Padding(0);
            textBox_TimKiem.Multiline = true;
            textBox_TimKiem.Name = "textBox_TimKiem";
            textBox_TimKiem.Size = new Size(1325, 60);
            textBox_TimKiem.TabIndex = 3;
            // 
            // comboBox_DoKho
            // 
            comboBox_DoKho.BackColor = Color.White;
            comboBox_DoKho.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_DoKho.FlatStyle = FlatStyle.Flat;
            comboBox_DoKho.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_DoKho.FormattingEnabled = true;
            comboBox_DoKho.Location = new Point(1222, 35);
            comboBox_DoKho.Margin = new Padding(0);
            comboBox_DoKho.Name = "comboBox_DoKho";
            comboBox_DoKho.Size = new Size(277, 33);
            comboBox_DoKho.TabIndex = 2;
            comboBox_DoKho.SelectedIndexChanged += comboBox_DoKho_SelectionChangeCommitted;
            // 
            // comboBox_Chuong
            // 
            comboBox_Chuong.BackColor = Color.White;
            comboBox_Chuong.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Chuong.FlatStyle = FlatStyle.Flat;
            comboBox_Chuong.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Chuong.FormattingEnabled = true;
            comboBox_Chuong.Location = new Point(492, 35);
            comboBox_Chuong.Margin = new Padding(0);
            comboBox_Chuong.Name = "comboBox_Chuong";
            comboBox_Chuong.Size = new Size(707, 33);
            comboBox_Chuong.TabIndex = 1;
            comboBox_Chuong.SelectedIndexChanged += comboBox_Chuong_SelectionChangeCommitted;
            // 
            // comboBox_MonHoc
            // 
            comboBox_MonHoc.BackColor = Color.White;
            comboBox_MonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_MonHoc.FlatStyle = FlatStyle.Flat;
            comboBox_MonHoc.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_MonHoc.FormattingEnabled = true;
            comboBox_MonHoc.Location = new Point(18, 35);
            comboBox_MonHoc.Margin = new Padding(0);
            comboBox_MonHoc.Name = "comboBox_MonHoc";
            comboBox_MonHoc.Size = new Size(455, 33);
            comboBox_MonHoc.TabIndex = 0;
            comboBox_MonHoc.SelectedIndexChanged += comboBox_MonHoc_SelectionChangeCommitted;
            // 
            // dataGridView_DSCauHoi
            // 
            dataGridView_DSCauHoi.AllowUserToAddRows = false;
            dataGridView_DSCauHoi.AllowUserToDeleteRows = false;
            dataGridView_DSCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_DSCauHoi.BackgroundColor = Color.White;
            dataGridView_DSCauHoi.BorderStyle = BorderStyle.None;
            dataGridView_DSCauHoi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView_DSCauHoi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView_DSCauHoi.GridColor = Color.FromArgb(230, 230, 235);
            dataGridView_DSCauHoi.Location = new Point(10, 280);
            dataGridView_DSCauHoi.Margin = new Padding(0);
            dataGridView_DSCauHoi.Name = "dataGridView_DSCauHoi";
            dataGridView_DSCauHoi.ReadOnly = true;
            dataGridView_DSCauHoi.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView_DSCauHoi.RowHeadersWidth = 51;
            dataGridView_DSCauHoi.RowTemplate.Height = 35;
            dataGridView_DSCauHoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_DSCauHoi.Size = new Size(1377, 603);
            dataGridView_DSCauHoi.TabIndex = 3;
            dataGridView_DSCauHoi.CellContentClick += dataGridView_DSCauHoi_CellContentClick;
            // 
            // button_Xem
            // 
            button_Xem.BackColor = Color.FromArgb(70, 130, 180);
            button_Xem.FlatAppearance.BorderSize = 0;
            button_Xem.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 100, 150);
            button_Xem.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 150, 200);
            button_Xem.FlatStyle = FlatStyle.Flat;
            button_Xem.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Xem.ForeColor = Color.White;
            button_Xem.Image = (Image)resources.GetObject("button_Xem.Image");
            button_Xem.ImageAlign = ContentAlignment.MiddleLeft;
            button_Xem.Location = new Point(1401, 280);
            button_Xem.Margin = new Padding(0);
            button_Xem.Name = "button_Xem";
            button_Xem.Padding = new Padding(5);
            button_Xem.Size = new Size(120, 60);
            button_Xem.TabIndex = 5;
            button_Xem.Text = "XEM";
            button_Xem.TextAlign = ContentAlignment.MiddleRight;
            button_Xem.UseVisualStyleBackColor = false;
            button_Xem.Click += button_Xem_Click;
            // 
            // button_Sua
            // 
            button_Sua.BackColor = Color.FromArgb(0, 206, 209);
            button_Sua.FlatAppearance.BorderSize = 0;
            button_Sua.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 180, 190);
            button_Sua.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 230, 240);
            button_Sua.FlatStyle = FlatStyle.Flat;
            button_Sua.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Sua.ForeColor = Color.White;
            button_Sua.Image = (Image)resources.GetObject("button_Sua.Image");
            button_Sua.ImageAlign = ContentAlignment.MiddleLeft;
            button_Sua.Location = new Point(1401, 350);
            button_Sua.Margin = new Padding(0);
            button_Sua.Name = "button_Sua";
            button_Sua.Padding = new Padding(5);
            button_Sua.Size = new Size(120, 60);
            button_Sua.TabIndex = 6;
            button_Sua.Text = "SỬA";
            button_Sua.TextAlign = ContentAlignment.MiddleRight;
            button_Sua.UseVisualStyleBackColor = false;
            button_Sua.Click += button_Sua_Click;
            // 
            // comboBox_ChiSo
            // 
            comboBox_ChiSo.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_ChiSo.FormattingEnabled = true;
            comboBox_ChiSo.Location = new Point(1309, 879);
            comboBox_ChiSo.Name = "comboBox_ChiSo";
            comboBox_ChiSo.Size = new Size(86, 35);
            comboBox_ChiSo.TabIndex = 8;
            comboBox_ChiSo.SelectedIndexChanged += comboBox_ChiSo_SelectedIndexChanged;
            // 
            // button_Next
            // 
            button_Next.BackColor = Color.FromArgb(70, 130, 180);
            button_Next.FlatAppearance.BorderSize = 0;
            button_Next.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 100, 150);
            button_Next.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 150, 200);
            button_Next.FlatStyle = FlatStyle.Flat;
            button_Next.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Next.ForeColor = Color.White;
            button_Next.ImageAlign = ContentAlignment.MiddleLeft;
            button_Next.Location = new Point(1418, 869);
            button_Next.Margin = new Padding(0);
            button_Next.Name = "button_Next";
            button_Next.Padding = new Padding(5);
            button_Next.Size = new Size(92, 45);
            button_Next.TabIndex = 9;
            button_Next.Text = "Next";
            button_Next.UseVisualStyleBackColor = false;
            button_Next.Click += button_Next_Click;
            // 
            // button_Prev
            // 
            button_Prev.BackColor = Color.FromArgb(70, 130, 180);
            button_Prev.FlatAppearance.BorderSize = 0;
            button_Prev.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 100, 150);
            button_Prev.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 150, 200);
            button_Prev.FlatStyle = FlatStyle.Flat;
            button_Prev.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Prev.ForeColor = Color.White;
            button_Prev.ImageAlign = ContentAlignment.MiddleLeft;
            button_Prev.Location = new Point(1203, 879);
            button_Prev.Margin = new Padding(0);
            button_Prev.Name = "button_Prev";
            button_Prev.Padding = new Padding(5);
            button_Prev.Size = new Size(83, 39);
            button_Prev.TabIndex = 10;
            button_Prev.Text = "Prev";
            button_Prev.UseVisualStyleBackColor = false;
            button_Prev.Click += button_Prev_Click;
            // 
            // Component_CauHoi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(button_Prev);
            Controls.Add(button_Next);
            Controls.Add(comboBox_ChiSo);
            Controls.Add(button_Sua);
            Controls.Add(button_Xem);
            Controls.Add(dataGridView_DSCauHoi);
            Controls.Add(panel_LocVaTimKiem);
            Controls.Add(button_Reload);
            Controls.Add(button_ThemCauHoi);
            Margin = new Padding(0);
            Name = "Component_CauHoi";
            Padding = new Padding(10);
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
        private ComboBox comboBox_ChiSo;
        private Button button_Next;
        private Button button_Prev;
    }
}
