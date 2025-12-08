
namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Dialog_TaoDeThi
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            labelTendethi = new Label();
            textBoxTendethi = new TextBox();
            labelTimeBatDau = new Label();
            labelTimeKetThuc = new Label();
            textBoxTimeBatDau = new TextBox();
            textBoxTimeKetThuc = new TextBox();
            dateTimePickerBatDau = new DateTimePicker();
            dateTimePickerKetThuc = new DateTimePicker();
            btnIconLichBatDau = new Button();
            btnIconLichKetThuc = new Button();
            labelTimeLambai = new Label();
            labelHocPhan = new Label();
            textBoxTimeLamBai = new TextBox();
            comboBoxMonHoc = new ComboBox();
            textboxMonhoc = new TextBox();
            labelChuong = new Label();
            dataGridView1 = new DataGridView();
            ColumnChon = new DataGridViewCheckBoxColumn();
            ColumnMaChuong = new DataGridViewTextBoxColumn();
            ColumnTenChuong = new DataGridViewTextBoxColumn();
            textBoxSoCauDe = new TextBox();
            textBoxSoCauTB = new TextBox();
            textBoxSoCauKho = new TextBox();
            labelSoCauDe = new Label();
            labelSoCauTB = new Label();
            labelSoCauKho = new Label();
            checkBoxDeLuyenTap = new CheckBox();
            btnTaoDeThi = new Button();
            btnXoaND = new Button();
            btnXoaChuong = new Button();
            labelTimeCanhBao = new Label();
            textBoxTimeCB = new TextBox();
            panelNhomHocPhan = new Panel();
            labelNhomLop = new Label();
            checkBoxTatCaNhom = new CheckBox();
            flowLayoutPanelNhom = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelNhomHocPhan.SuspendLayout();
            SuspendLayout();
            // 
            // labelTendethi
            // 
            labelTendethi.AutoSize = true;
            labelTendethi.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTendethi.Location = new Point(30, 42);
            labelTendethi.Name = "labelTendethi";
            labelTendethi.Size = new Size(98, 25);
            labelTendethi.TabIndex = 0;
            labelTendethi.Text = "Tên đề thi";
            // 
            // textBoxTendethi
            // 
            textBoxTendethi.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTendethi.Location = new Point(30, 81);
            textBoxTendethi.Multiline = true;
            textBoxTendethi.Name = "textBoxTendethi";
            textBoxTendethi.Size = new Size(930, 47);
            textBoxTendethi.TabIndex = 1;
            // 
            // labelTimeBatDau
            // 
            labelTimeBatDau.AutoSize = true;
            labelTimeBatDau.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTimeBatDau.Location = new Point(30, 163);
            labelTimeBatDau.Name = "labelTimeBatDau";
            labelTimeBatDau.Size = new Size(168, 25);
            labelTimeBatDau.TabIndex = 2;
            labelTimeBatDau.Text = "Thời gian bắt đầu";
            labelTimeBatDau.Click += label1_Click;
            // 
            // labelTimeKetThuc
            // 
            labelTimeKetThuc.AutoSize = true;
            labelTimeKetThuc.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTimeKetThuc.Location = new Point(385, 163);
            labelTimeKetThuc.Name = "labelTimeKetThuc";
            labelTimeKetThuc.Size = new Size(172, 25);
            labelTimeKetThuc.TabIndex = 3;
            labelTimeKetThuc.Text = "Thời gian kết thúc";
            labelTimeKetThuc.Click += labelTimeKetThuc_Click;
            // 
            // textBoxTimeBatDau
            // 
            textBoxTimeBatDau.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimeBatDau.Location = new Point(34, 202);
            textBoxTimeBatDau.Multiline = true;
            textBoxTimeBatDau.Name = "textBoxTimeBatDau";
            textBoxTimeBatDau.Size = new Size(286, 47);
            textBoxTimeBatDau.TabIndex = 4;
            textBoxTimeBatDau.Visible = false;
            // 
            // textBoxTimeKetThuc
            // 
            textBoxTimeKetThuc.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimeKetThuc.Location = new Point(385, 202);
            textBoxTimeKetThuc.Multiline = true;
            textBoxTimeKetThuc.Name = "textBoxTimeKetThuc";
            textBoxTimeKetThuc.Size = new Size(310, 47);
            textBoxTimeKetThuc.TabIndex = 5;
            textBoxTimeKetThuc.Visible = false;
            // 
            // dateTimePickerBatDau
            // 
            dateTimePickerBatDau.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePickerBatDau.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerBatDau.Format = DateTimePickerFormat.Custom;
            dateTimePickerBatDau.Location = new Point(34, 205);
            dateTimePickerBatDau.Name = "dateTimePickerBatDau";
            dateTimePickerBatDau.Size = new Size(260, 32);
            dateTimePickerBatDau.TabIndex = 4;
            dateTimePickerBatDau.ValueChanged += DateTimePickerBatDau_ValueChanged;
            // 
            // btnIconLichBatDau
            // 
            btnIconLichBatDau.BackColor = Color.White;
            btnIconLichBatDau.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconLichBatDau.Location = new Point(300, 205);
            btnIconLichBatDau.Name = "btnIconLichBatDau";
            btnIconLichBatDau.Size = new Size(32, 32);
            btnIconLichBatDau.TabIndex = 30;
            btnIconLichBatDau.Text = "📅";
            btnIconLichBatDau.UseVisualStyleBackColor = false;
            btnIconLichBatDau.Click += BtnIconLichBatDau_Click;
            // 
            // dateTimePickerKetThuc
            // 
            dateTimePickerKetThuc.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePickerKetThuc.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerKetThuc.Format = DateTimePickerFormat.Custom;
            dateTimePickerKetThuc.Location = new Point(398, 205);
            dateTimePickerKetThuc.Name = "dateTimePickerKetThuc";
            dateTimePickerKetThuc.Size = new Size(265, 32);
            dateTimePickerKetThuc.TabIndex = 5;
            dateTimePickerKetThuc.ValueChanged += DateTimePickerKetThuc_ValueChanged;
            // 
            // btnIconLichKetThuc
            // 
            btnIconLichKetThuc.BackColor = Color.White;
            btnIconLichKetThuc.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconLichKetThuc.Location = new Point(669, 205);
            btnIconLichKetThuc.Name = "btnIconLichKetThuc";
            btnIconLichKetThuc.Size = new Size(32, 32);
            btnIconLichKetThuc.TabIndex = 31;
            btnIconLichKetThuc.Text = "📅";
            btnIconLichKetThuc.UseVisualStyleBackColor = false;
            btnIconLichKetThuc.Click += BtnIconLichKetThuc_Click;
            // 
            // labelTimeLambai
            // 
            labelTimeLambai.AutoSize = true;
            labelTimeLambai.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTimeLambai.Location = new Point(30, 283);
            labelTimeLambai.Name = "labelTimeLambai";
            labelTimeLambai.Size = new Size(164, 25);
            labelTimeLambai.TabIndex = 6;
            labelTimeLambai.Text = "Thời gian làm bài";
            // 
            // labelHocPhan
            // 
            labelHocPhan.AutoSize = true;
            labelHocPhan.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHocPhan.Location = new Point(523, 283);
            labelHocPhan.Name = "labelHocPhan";
            labelHocPhan.Size = new Size(98, 25);
            labelHocPhan.TabIndex = 7;
            labelHocPhan.Text = "Học phần";
            // 
            // textBoxTimeLamBai
            // 
            textBoxTimeLamBai.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimeLamBai.Location = new Point(30, 321);
            textBoxTimeLamBai.Multiline = true;
            textBoxTimeLamBai.Name = "textBoxTimeLamBai";
            textBoxTimeLamBai.Size = new Size(415, 47);
            textBoxTimeLamBai.TabIndex = 8;
            textBoxTimeLamBai.TextChanged += textBoxTimeLamBai_TextChanged;
            textBoxTimeLamBai.KeyDown += textBoxTimeLamBai_KeyDown;
            textBoxTimeLamBai.Leave += textBoxTimeLamBai_Leave;
            // 
            // comboBoxMonHoc
            // 
            comboBoxMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMonHoc.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxMonHoc.FormattingEnabled = true;
            comboBoxMonHoc.Location = new Point(523, 321);
            comboBoxMonHoc.Name = "comboBoxMonHoc";
            comboBoxMonHoc.Size = new Size(437, 33);
            comboBoxMonHoc.TabIndex = 9;
            comboBoxMonHoc.SelectedIndexChanged += comboBoxMonHoc_SelectedIndexChanged;
            // 
            // textboxMonhoc
            // 
            textboxMonhoc.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textboxMonhoc.Location = new Point(30, 396);
            textboxMonhoc.Multiline = true;
            textboxMonhoc.Name = "textboxMonhoc";
            textboxMonhoc.ReadOnly = true;
            textboxMonhoc.Size = new Size(450, 149);
            textboxMonhoc.TabIndex = 10;
            textboxMonhoc.BackColor = Color.White;
            // 
            // panelNhomHocPhan
            // 
            panelNhomHocPhan.BorderStyle = BorderStyle.FixedSingle;
            panelNhomHocPhan.Controls.Add(flowLayoutPanelNhom);
            panelNhomHocPhan.Controls.Add(checkBoxTatCaNhom);
            panelNhomHocPhan.Controls.Add(labelNhomLop);
            panelNhomHocPhan.Location = new Point(510, 396);
            panelNhomHocPhan.Name = "panelNhomHocPhan";
            panelNhomHocPhan.Size = new Size(450, 149);
            panelNhomHocPhan.TabIndex = 29;
            // 
            // labelNhomLop
            // 
            labelNhomLop.AutoSize = true;
            labelNhomLop.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNhomLop.Location = new Point(10, 10);
            labelNhomLop.Name = "labelNhomLop";
            labelNhomLop.Size = new Size(90, 21);
            labelNhomLop.TabIndex = 0;
            labelNhomLop.Text = "Nhóm lớp:";
            // 
            // checkBoxTatCaNhom
            // 
            checkBoxTatCaNhom.AutoSize = true;
            checkBoxTatCaNhom.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBoxTatCaNhom.Location = new Point(10, 35);
            checkBoxTatCaNhom.Name = "checkBoxTatCaNhom";
            checkBoxTatCaNhom.Size = new Size(75, 25);
            checkBoxTatCaNhom.TabIndex = 1;
            checkBoxTatCaNhom.Text = "Tất cả";
            checkBoxTatCaNhom.UseVisualStyleBackColor = true;
            checkBoxTatCaNhom.Visible = false;
            // 
            // flowLayoutPanelNhom
            // 
            flowLayoutPanelNhom.AutoScroll = true;
            flowLayoutPanelNhom.Location = new Point(10, 65);
            flowLayoutPanelNhom.Name = "flowLayoutPanelNhom";
            flowLayoutPanelNhom.Size = new Size(430, 75);
            flowLayoutPanelNhom.TabIndex = 2;
            // 
            // labelChuong
            // 
            labelChuong.AutoSize = true;
            labelChuong.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelChuong.Location = new Point(34, 568);
            labelChuong.Name = "labelChuong";
            labelChuong.Size = new Size(84, 25);
            labelChuong.TabIndex = 12;
            labelChuong.Text = "Chương";
            // 
            // dgvMonHoc
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnChon, ColumnMaChuong, ColumnTenChuong });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(126, 164, 241);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(30, 627);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dgvMonHoc";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(930, 280);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ColumnChon
            // 
            ColumnChon.HeaderText = "☑";
            ColumnChon.Name = "ColumnChon";
            ColumnChon.Width = 60;
            // 
            // ColumnMaChuong
            // 
            ColumnMaChuong.HeaderText = "Mã Chương";
            ColumnMaChuong.Name = "ColumnMaChuong";
            ColumnMaChuong.ReadOnly = true;
            ColumnMaChuong.Width = 200;
            // 
            // ColumnTenChuong
            // 
            ColumnTenChuong.HeaderText = "Tên Chương";
            ColumnTenChuong.Name = "ColumnTenChuong";
            ColumnTenChuong.ReadOnly = true;
            ColumnTenChuong.Width = 700;
            // 
            // textBoxSoCauDe
            // 
            textBoxSoCauDe.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSoCauDe.Location = new Point(34, 1002);
            textBoxSoCauDe.Multiline = true;
            textBoxSoCauDe.Name = "textBoxSoCauDe";
            textBoxSoCauDe.Size = new Size(164, 44);
            textBoxSoCauDe.TabIndex = 14;
            // 
            // textBoxSoCauTB
            // 
            textBoxSoCauTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSoCauTB.Location = new Point(262, 1002);
            textBoxSoCauTB.Multiline = true;
            textBoxSoCauTB.Name = "textBoxSoCauTB";
            textBoxSoCauTB.Size = new Size(164, 44);
            textBoxSoCauTB.TabIndex = 15;
            // 
            // textBoxSoCauKho
            // 
            textBoxSoCauKho.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSoCauKho.Location = new Point(491, 1002);
            textBoxSoCauKho.Multiline = true;
            textBoxSoCauKho.Name = "textBoxSoCauKho";
            textBoxSoCauKho.Size = new Size(164, 44);
            textBoxSoCauKho.TabIndex = 16;
            // 
            // labelSoCauDe
            // 
            labelSoCauDe.AutoSize = true;
            labelSoCauDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSoCauDe.Location = new Point(34, 948);
            labelSoCauDe.Name = "labelSoCauDe";
            labelSoCauDe.Size = new Size(98, 25);
            labelSoCauDe.TabIndex = 17;
            labelSoCauDe.Text = "Số câu dễ";
            // 
            // labelSoCauTB
            // 
            labelSoCauTB.AutoSize = true;
            labelSoCauTB.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSoCauTB.Location = new Point(262, 963);
            labelSoCauTB.Name = "labelSoCauTB";
            labelSoCauTB.Size = new Size(172, 25);
            labelSoCauTB.TabIndex = 18;
            labelSoCauTB.Text = "Số câu trung bình";
            // 
            // labelSoCauKho
            // 
            labelSoCauKho.AutoSize = true;
            labelSoCauKho.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSoCauKho.Location = new Point(491, 963);
            labelSoCauKho.Name = "labelSoCauKho";
            labelSoCauKho.Size = new Size(110, 25);
            labelSoCauKho.TabIndex = 19;
            labelSoCauKho.Text = "Số câu khó";
            // 
            // checkBoxDeLuyenTap
            // 
            checkBoxDeLuyenTap.AutoSize = true;
            checkBoxDeLuyenTap.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBoxDeLuyenTap.Location = new Point(34, 1100);
            checkBoxDeLuyenTap.Name = "checkBoxDeLuyenTap";
            checkBoxDeLuyenTap.Size = new Size(143, 29);
            checkBoxDeLuyenTap.TabIndex = 22;
            checkBoxDeLuyenTap.Text = "Đề luyện tập";
            checkBoxDeLuyenTap.UseVisualStyleBackColor = true;
            // 
            // btnTaoDeThi
            // 
            btnTaoDeThi.BackColor = Color.FromArgb(131, 131, 252);
            btnTaoDeThi.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaoDeThi.Location = new Point(364, 1178);
            btnTaoDeThi.Name = "btnTaoDeThi";
            btnTaoDeThi.Size = new Size(257, 68);
            btnTaoDeThi.TabIndex = 24;
            btnTaoDeThi.Text = "Tạo Đề Thi";
            btnTaoDeThi.UseVisualStyleBackColor = true;
            btnTaoDeThi.Click += btnTaoDeThi_Click;
            // 
            // btnXoaND
            // 
            btnXoaND.BackColor = Color.FromArgb(255, 192, 192);
            btnXoaND.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaND.Location = new Point(913, 551);
            btnXoaND.Name = "btnXoaND";
            btnXoaND.Size = new Size(47, 52);
            btnXoaND.TabIndex = 25;
            btnXoaND.Text = "X";
            btnXoaND.UseVisualStyleBackColor = false;
            btnXoaND.Visible = false;
            btnXoaND.Click += btnXoaND_Click;
            // 
            // btnXoaChuong
            // 
            btnXoaChuong.BackColor = Color.FromArgb(255, 192, 192);
            btnXoaChuong.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaChuong.Location = new Point(903, 948);
            btnXoaChuong.Name = "btnXoaChuong";
            btnXoaChuong.Size = new Size(47, 52);
            btnXoaChuong.TabIndex = 26;
            btnXoaChuong.Text = "X";
            btnXoaChuong.UseVisualStyleBackColor = false;
            btnXoaChuong.Visible = false;
            btnXoaChuong.Click += btnXoaChuong_Click;
            // 
            // labelTimeCanhBao
            // 
            labelTimeCanhBao.AutoSize = true;
            labelTimeCanhBao.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTimeCanhBao.Location = new Point(753, 163);
            labelTimeCanhBao.Name = "labelTimeCanhBao";
            labelTimeCanhBao.Size = new Size(96, 25);
            labelTimeCanhBao.TabIndex = 27;
            labelTimeCanhBao.Text = "Cảnh báo";
            labelTimeCanhBao.Click += label1_Click_1;
            // 
            // textBoxTimeCB
            // 
            textBoxTimeCB.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimeCB.Location = new Point(753, 202);
            textBoxTimeCB.Multiline = true;
            textBoxTimeCB.Name = "textBoxTimeCB";
            textBoxTimeCB.Size = new Size(207, 47);
            textBoxTimeCB.TabIndex = 28;
            textBoxTimeCB.TextChanged += textBoxTimeCB_TextChanged;
            // 
            // Dialog_TaoDeThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panelNhomHocPhan);
            Controls.Add(textBoxTimeCB);
            Controls.Add(labelTimeCanhBao);
            Controls.Add(btnXoaChuong);
            Controls.Add(btnXoaND);
            Controls.Add(btnTaoDeThi);
            Controls.Add(checkBoxDeLuyenTap);
            Controls.Add(labelSoCauKho);
            Controls.Add(labelSoCauTB);
            Controls.Add(labelSoCauDe);
            Controls.Add(textBoxSoCauKho);
            Controls.Add(textBoxSoCauTB);
            Controls.Add(textBoxSoCauDe);
            Controls.Add(dataGridView1);
            Controls.Add(labelChuong);
            Controls.Add(textboxMonhoc);
            Controls.Add(comboBoxMonHoc);
            Controls.Add(textBoxTimeLamBai);
            Controls.Add(labelHocPhan);
            Controls.Add(labelTimeLambai);
            Controls.Add(textBoxTimeKetThuc);
            Controls.Add(textBoxTimeBatDau);
            Controls.Add(btnIconLichKetThuc);
            Controls.Add(btnIconLichBatDau);
            Controls.Add(dateTimePickerKetThuc);
            Controls.Add(dateTimePickerBatDau);
            Controls.Add(labelTimeKetThuc);
            Controls.Add(labelTimeBatDau);
            Controls.Add(textBoxTendethi);
            Controls.Add(labelTendethi);
            Name = "Dialog_TaoDeThi";
            Size = new Size(1500, 1249);
            Load += Dialog_TaoDeThi_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelNhomHocPhan.ResumeLayout(false);
            panelNhomHocPhan.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTendethi;
        public TextBox textBoxTendethi;
        private Label labelTimeBatDau;
        private Label labelTimeKetThuc;
        public TextBox textBoxTimeBatDau;
        public TextBox textBoxTimeKetThuc;
        public DateTimePicker dateTimePickerBatDau;
        public DateTimePicker dateTimePickerKetThuc;
        private Label labelTimeLambai;
        private Label labelHocPhan;
        public TextBox textBoxTimeLamBai;
        public ComboBox comboBoxMonHoc;
        public TextBox textboxMonhoc;
        private Label labelChuong;
        private DataGridView dataGridView1;
        private DataGridViewCheckBoxColumn ColumnChon;
        private DataGridViewTextBoxColumn ColumnMaChuong;
        private DataGridViewTextBoxColumn ColumnTenChuong;
        private TextBox textBoxSoCauDe;
        private TextBox textBoxSoCauTB;
        private TextBox textBoxSoCauKho;
        private Label labelSoCauDe;
        private Label labelSoCauTB;
        private Label labelSoCauKho;
        private CheckBox checkBoxDeLuyenTap;
        private Button btnTaoDeThi;
        private Button btnXoaND;
        private Button btnXoaChuong;
        private Label labelTimeCanhBao;
        public TextBox textBoxTimeCB;
        private Panel panelNhomHocPhan;
        private Label labelNhomLop;
        private CheckBox checkBoxTatCaNhom;
        private FlowLayoutPanel flowLayoutPanelNhom;
        private Button btnIconLichBatDau;
        private Button btnIconLichKetThuc;
    }
}
