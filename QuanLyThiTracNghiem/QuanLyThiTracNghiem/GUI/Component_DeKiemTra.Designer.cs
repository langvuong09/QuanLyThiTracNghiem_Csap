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
            listBoxDeThi = new ListBox();
            btnXoa = new Button();
            btnSua = new Button();
            btnXem = new Button();
            labeltrangthaithuc = new Label();
            labeltrangthai = new Label();
            labeltime = new Label();
            labelhocphan = new Label();
            labelkiemtra = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
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
            btnXem.Name = "btnXem";
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // button1
            // 
            button1.Location = new Point(1119, 836);
            button1.Name = "button1";
            button1.Size = new Size(117, 60);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1254, 836);
            button2.Name = "button2";
            button2.Size = new Size(109, 60);
            button2.TabIndex = 7;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(1385, 836);
            button3.Name = "button3";
            button3.Size = new Size(115, 60);
            button3.TabIndex = 8;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // Component_DeKiemTra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
