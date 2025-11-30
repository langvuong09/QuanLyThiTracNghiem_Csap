namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_PhanCong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_PhanCong));
            dataGridView_DSPC = new DataGridView();
            textBoxTimKiem = new TextBox();
            panel_PhanCong = new Panel();
            btnExit = new Button();
            label3 = new Label();
            comboBox_GiaoVien = new ComboBox();
            label2 = new Label();
            textBox_MaPC = new TextBox();
            comboBox_MonHoc = new ComboBox();
            label1 = new Label();
            button_HanhDong = new Button();
            button_ThemPC = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSPC).BeginInit();
            panel_PhanCong.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView_DSPC
            // 
            dataGridView_DSPC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_DSPC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_DSPC.Location = new Point(16, 94);
            dataGridView_DSPC.Name = "dataGridView_DSPC";
            dataGridView_DSPC.Size = new Size(1508, 827);
            dataGridView_DSPC.TabIndex = 5;
            dataGridView_DSPC.CellClick += dataGridView_DSPC_CellClick;
            dataGridView_DSPC.CellFormatting += dataGridView_DSPC_CellFormatting;
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimKiem.Location = new Point(16, 20);
            textBoxTimKiem.Multiline = true;
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.Size = new Size(1253, 45);
            textBoxTimKiem.TabIndex = 6;
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            textBoxTimKiem.KeyDown += textBoxTimKiem_KeyDown;
            // 
            // panel_PhanCong
            // 
            panel_PhanCong.BackColor = Color.LightGray;
            panel_PhanCong.BorderStyle = BorderStyle.Fixed3D;
            panel_PhanCong.Controls.Add(btnExit);
            panel_PhanCong.Controls.Add(label3);
            panel_PhanCong.Controls.Add(comboBox_GiaoVien);
            panel_PhanCong.Controls.Add(label2);
            panel_PhanCong.Controls.Add(textBox_MaPC);
            panel_PhanCong.Controls.Add(comboBox_MonHoc);
            panel_PhanCong.Controls.Add(label1);
            panel_PhanCong.Controls.Add(button_HanhDong);
            panel_PhanCong.Location = new Point(510, 130);
            panel_PhanCong.Name = "panel_PhanCong";
            panel_PhanCong.Size = new Size(540, 302);
            panel_PhanCong.TabIndex = 9;
            panel_PhanCong.Visible = false;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(477, 11);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(51, 23);
            btnExit.TabIndex = 8;
            btnExit.Text = "Đóng";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 179);
            label3.Name = "label3";
            label3.Size = new Size(117, 30);
            label3.TabIndex = 7;
            label3.Text = "Giáo viên: ";
            // 
            // comboBox_GiaoVien
            // 
            comboBox_GiaoVien.Enabled = false;
            comboBox_GiaoVien.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_GiaoVien.FormattingEnabled = true;
            comboBox_GiaoVien.Location = new Point(198, 179);
            comboBox_GiaoVien.Name = "comboBox_GiaoVien";
            comboBox_GiaoVien.Size = new Size(312, 38);
            comboBox_GiaoVien.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 112);
            label2.Name = "label2";
            label2.Size = new Size(113, 30);
            label2.TabIndex = 5;
            label2.Text = "Môn học: ";
            // 
            // textBox_MaPC
            // 
            textBox_MaPC.Enabled = false;
            textBox_MaPC.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_MaPC.Location = new Point(198, 48);
            textBox_MaPC.Name = "textBox_MaPC";
            textBox_MaPC.Size = new Size(312, 35);
            textBox_MaPC.TabIndex = 4;
            // 
            // comboBox_MonHoc
            // 
            comboBox_MonHoc.Enabled = false;
            comboBox_MonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_MonHoc.FormattingEnabled = true;
            comboBox_MonHoc.Location = new Point(198, 112);
            comboBox_MonHoc.Name = "comboBox_MonHoc";
            comboBox_MonHoc.Size = new Size(312, 38);
            comboBox_MonHoc.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 48);
            label1.Name = "label1";
            label1.Size = new Size(167, 30);
            label1.TabIndex = 2;
            label1.Text = "Mã phân công: ";
            // 
            // button_HanhDong
            // 
            button_HanhDong.Location = new Point(218, 246);
            button_HanhDong.Name = "button_HanhDong";
            button_HanhDong.Size = new Size(110, 39);
            button_HanhDong.TabIndex = 1;
            button_HanhDong.Text = "Tạo phân công";
            button_HanhDong.UseVisualStyleBackColor = true;
            button_HanhDong.Click += button_HanhDong_Click;
            // 
            // button_ThemPC
            // 
            button_ThemPC.BackColor = Color.DeepSkyBlue;
            button_ThemPC.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ThemPC.ForeColor = SystemColors.ButtonHighlight;
            button_ThemPC.Image = (Image)resources.GetObject("button_ThemPC.Image");
            button_ThemPC.ImageAlign = ContentAlignment.MiddleLeft;
            button_ThemPC.Location = new Point(1305, 20);
            button_ThemPC.Name = "button_ThemPC";
            button_ThemPC.Size = new Size(219, 45);
            button_ThemPC.TabIndex = 14;
            button_ThemPC.Text = "THÊM PHÂN CÔNG";
            button_ThemPC.TextAlign = ContentAlignment.MiddleRight;
            button_ThemPC.UseVisualStyleBackColor = false;
            button_ThemPC.Click += button_ThemPC_Click;
            // 
            // Component_PhanCong
            // 
            BackColor = Color.White;
            Controls.Add(button_ThemPC);
            Controls.Add(panel_PhanCong);
            Controls.Add(textBoxTimKiem);
            Controls.Add(dataGridView_DSPC);
            Name = "Component_PhanCong";
            Size = new Size(1541, 934);
            Load += Component_PhanCong_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSPC).EndInit();
            panel_PhanCong.ResumeLayout(false);
            panel_PhanCong.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_DSPC;
        private TextBox textBoxTimKiem;
        private Panel panel_PhanCong;
        private Label label1;
        private Button button_HanhDong;
        private ComboBox comboBox_MonHoc;
        private TextBox textBox_MaPC;
        private Label label3;
        private ComboBox comboBox_GiaoVien;
        private Label label2;
        private Button button_ThemPC;
        private Button btnExit;
    }
}
