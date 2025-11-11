namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_DeKiemTra
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_DeKiemTra));
            combobox1 = new ComboBox();
            textBoxTimKiem = new TextBox();
            btnReload = new Button();
            btnTaodethi = new Button();
            panelKiemTra = new Panel();
            btnXoa = new Button();
            btnSua = new Button();
            btnXem = new Button();
            labeltrangthaithuc = new Label();
            labeltrangthai = new Label();
            labeltime = new Label();
            labelhocphan = new Label();
            labelkiemtra = new Label();
            listBoxDeThi = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnPrevious = new Button();
            lblPageInfo = new Label();
            btnNext = new Button();
            panelKiemTra.SuspendLayout();
            SuspendLayout();
            // 
            // combobox1
            // 
            combobox1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            combobox1.ForeColor = SystemColors.InactiveCaptionText;
            combobox1.FormattingEnabled = true;
            combobox1.Location = new Point(29, 47);
            combobox1.Name = "combobox1";
            combobox1.Size = new Size(164, 40);
            combobox1.TabIndex = 0;
            combobox1.Text = "Tất cả";
            combobox1.SelectedIndexChanged += combobox1_SelectedIndexChanged;
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimKiem.Location = new Point(224, 47);
            textBoxTimKiem.Multiline = true;
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.Size = new Size(360, 45);
            textBoxTimKiem.TabIndex = 1;
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            // 
            // btnReload
            // 
            btnReload.BackColor = Color.LightCoral;
            btnReload.BackgroundImage = (Image)resources.GetObject("btnReload.BackgroundImage");
            btnReload.Location = new Point(1186, 25);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(72, 68);
            btnReload.TabIndex = 2;
            btnReload.UseVisualStyleBackColor = false;
            btnReload.Click += btnReload_Click;
            // 
            // btnTaodethi
            // 
            btnTaodethi.BackColor = Color.FromArgb(131, 168, 238);
            btnTaodethi.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaodethi.Location = new Point(1284, 25);
            btnTaodethi.Name = "btnTaodethi";
            btnTaodethi.Size = new Size(216, 67);
            btnTaodethi.TabIndex = 3;
            btnTaodethi.Text = "Tạo Đề Thi";
            btnTaodethi.UseVisualStyleBackColor = false;
            btnTaodethi.Click += button2_Click;
            // 
            // panelKiemTra
            // 
            panelKiemTra.AutoScroll = true;
            panelKiemTra.BackColor = Color.FromArgb(215, 229, 255);
            panelKiemTra.Controls.Add(listBoxDeThi);
            panelKiemTra.Controls.Add(btnXoa);
            panelKiemTra.Controls.Add(btnSua);
            panelKiemTra.Controls.Add(btnXem);
            panelKiemTra.Controls.Add(labeltrangthaithuc);
            panelKiemTra.Controls.Add(labeltrangthai);
            panelKiemTra.Controls.Add(labeltime);
            panelKiemTra.Controls.Add(labelhocphan);
            panelKiemTra.Controls.Add(labelkiemtra);
            panelKiemTra.Location = new Point(29, 160);
            panelKiemTra.Name = "panelKiemTra";
            panelKiemTra.Size = new Size(1471, 600);
            panelKiemTra.TabIndex = 4;
            panelKiemTra.Paint += panel1_Paint;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(255, 128, 128);
            btnXoa.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(1326, 11);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(111, 47);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Visible = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(128, 128, 255);
            btnSua.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(1195, 11);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(111, 47);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Visible = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.PaleGreen;
            btnXem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXem.Location = new Point(1064, 11);
            btnXem.Name = "btnThem";
            btnXem.Size = new Size(111, 47);
            btnXem.TabIndex = 5;
            btnXem.Text = "Xem";
            btnXem.UseVisualStyleBackColor = false;
            btnXem.Visible = false;
            btnXem.Click += btnXem_Click;
            // 
            // labeltrangthaithuc
            // 
            labeltrangthaithuc.AutoSize = true;
            labeltrangthaithuc.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labeltrangthaithuc.ForeColor = Color.Red;
            labeltrangthaithuc.Location = new Point(109, 107);
            labeltrangthaithuc.Name = "labeltrangthaithuc";
            labeltrangthaithuc.Size = new Size(80, 21);
            labeltrangthaithuc.TabIndex = 4;
            labeltrangthaithuc.Text = "Đang mở";
            labeltrangthaithuc.Visible = false;
            // 
            // labeltrangthai
            // 
            labeltrangthai.AutoSize = true;
            labeltrangthai.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labeltrangthai.Location = new Point(13, 107);
            labeltrangthai.Name = "labeltrangthai";
            labeltrangthai.Size = new Size(90, 21);
            labeltrangthai.TabIndex = 3;
            labeltrangthai.Text = "Trạng thái: ";
            labeltrangthai.Visible = false;
            // 
            // labeltime
            // 
            labeltime.AutoSize = true;
            labeltime.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labeltime.Location = new Point(13, 76);
            labeltime.Name = "labeltime";
            labeltime.Size = new Size(373, 21);
            labeltime.TabIndex = 2;
            labeltime.Text = "Diễn ra từ 10:05 12/09/2025 đến 12:00 14/09/2025 ";
            labeltime.Visible = false;
            // 
            // labelhocphan
            // 
            labelhocphan.AutoSize = true;
            labelhocphan.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelhocphan.Location = new Point(13, 41);
            labelhocphan.Name = "labelhocphan";
            labelhocphan.Size = new Size(291, 25);
            labelhocphan.TabIndex = 1;
            labelhocphan.Text = "Lập trình web và ứng dụng - HKI";
            labelhocphan.Visible = false;
            labelhocphan.Click += label1_Click_1;
            // 
            // labelkiemtra
            // 
            labelkiemtra.AutoSize = true;
            labelkiemtra.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelkiemtra.Location = new Point(13, 11);
            labelkiemtra.Name = "labelkiemtra";
            labelkiemtra.Size = new Size(179, 30);
            labelkiemtra.TabIndex = 0;
            labelkiemtra.Text = "KIỂM TRA LẦN 1";
            labelkiemtra.Visible = false;
            labelkiemtra.Click += label1_Click;
            // 
            // listBoxDeThi
            // 
            listBoxDeThi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxDeThi.FormattingEnabled = true;
            listBoxDeThi.ItemHeight = 21;
            listBoxDeThi.Location = new Point(13, 140);
            listBoxDeThi.Name = "listBoxDeThi";
            listBoxDeThi.Size = new Size(1000, 130);
            listBoxDeThi.TabIndex = 8;
            listBoxDeThi.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.FromArgb(52, 152, 219);
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevious.ForeColor = Color.White;
            btnPrevious.Location = new Point(550, 780);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(120, 40);
            btnPrevious.TabIndex = 6;
            btnPrevious.Text = "◀ Trước";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;
            btnPrevious.MouseEnter += btnPrevious_MouseEnter;
            btnPrevious.MouseLeave += btnPrevious_MouseLeave;
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageInfo.ForeColor = Color.FromArgb(51, 51, 51);
            lblPageInfo.Location = new Point(690, 788);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(152, 21);
            lblPageInfo.TabIndex = 7;
            lblPageInfo.Text = "Trang 1 / 1";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(52, 152, 219);
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(860, 780);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(120, 40);
            btnNext.TabIndex = 8;
            btnNext.Text = "Sau ▶";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            btnNext.MouseEnter += btnNext_MouseEnter;
            btnNext.MouseLeave += btnNext_MouseLeave;
            // 
            // Component_DeKiemTra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnNext);
            Controls.Add(lblPageInfo);
            Controls.Add(btnPrevious);
            Controls.Add(panelKiemTra);
            Controls.Add(btnTaodethi);
            Controls.Add(btnReload);
            Controls.Add(textBoxTimKiem);
            Controls.Add(combobox1);
            Name = "Component_DeKiemTra";
            Size = new Size(1541, 934);
            Load += Component_DeKiemTra_Load;
            panelKiemTra.ResumeLayout(false);
            panelKiemTra.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox combobox1;
        private TextBox textBoxTimKiem;
        private Button btnReload;
        private Button btnTaodethi;
        private Panel panelKiemTra;
        private ContextMenuStrip contextMenuStrip1;
        private Label labelkiemtra;
        private Label labelhocphan;
        private Label labeltime;
        private Label labeltrangthaithuc;
        private Label labeltrangthai;
        private Button btnXoa;
        private Button btnSua;
        private Button btnXem;
        private ListBox listBoxDeThi;
        private Button btnPrevious;
        private Label lblPageInfo;
        private Button btnNext;
    }
}
