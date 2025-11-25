namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_NguoiDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_NguoiDung));
            comboboxLoc = new ComboBox();
            textBoxTimKiem = new TextBox();
            dataGridView_DSGVSV = new DataGridView();
            panelThongTin = new Panel();
            checkBoxAD = new CheckBox();
            buttonTaoND = new Button();
            textBoxNS = new DateTimePicker();
            textBoxMK = new TextBox();
            labelMK = new Label();
            comboBoxGT = new ComboBox();
            textBoxEmail = new TextBox();
            textBoxHoTen = new TextBox();
            textBoxMa = new TextBox();
            label5 = new Label();
            labelGT = new Label();
            label3 = new Label();
            labelHoTen = new Label();
            labelMa = new Label();
            buttonTrangThai = new Button();
            buttonSua = new Button();
            buttonThayAnh = new Button();
            pictureBoxAVT = new PictureBox();
            btnExit = new Button();
            button_ThemND = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSGVSV).BeginInit();
            panelThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAVT).BeginInit();
            SuspendLayout();
            // 
            // comboboxLoc
            // 
            comboboxLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboboxLoc.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboboxLoc.ForeColor = SystemColors.InactiveCaptionText;
            comboboxLoc.FormattingEnabled = true;
            comboboxLoc.Items.AddRange(new object[] { "Sinh Viên", "Giáo Viên" });
            comboboxLoc.Location = new Point(1117, 46);
            comboboxLoc.Name = "comboboxLoc";
            comboboxLoc.Size = new Size(164, 45);
            comboboxLoc.TabIndex = 1;
            comboboxLoc.SelectedIndexChanged += comboboxLoc_SelectedIndexChanged;
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimKiem.Location = new Point(24, 46);
            textBoxTimKiem.Multiline = true;
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.Size = new Size(1051, 45);
            textBoxTimKiem.TabIndex = 2;
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            textBoxTimKiem.KeyDown += textBoxTimKiem_KeyDown;
            // 
            // dataGridView_DSGVSV
            // 
            dataGridView_DSGVSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_DSGVSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_DSGVSV.Location = new Point(24, 145);
            dataGridView_DSGVSV.Name = "dataGridView_DSGVSV";
            dataGridView_DSGVSV.Size = new Size(1489, 776);
            dataGridView_DSGVSV.TabIndex = 4;
            dataGridView_DSGVSV.CellClick += dataGridView_DSGVSV_CellClick;
            dataGridView_DSGVSV.DataBindingComplete += DataGridView_DSGVSV_DataBindingComplete;
            // 
            // panelThongTin
            // 
            panelThongTin.BackColor = Color.FromArgb(224, 224, 224);
            panelThongTin.BorderStyle = BorderStyle.Fixed3D;
            panelThongTin.Controls.Add(checkBoxAD);
            panelThongTin.Controls.Add(buttonTaoND);
            panelThongTin.Controls.Add(textBoxNS);
            panelThongTin.Controls.Add(textBoxMK);
            panelThongTin.Controls.Add(labelMK);
            panelThongTin.Controls.Add(comboBoxGT);
            panelThongTin.Controls.Add(textBoxEmail);
            panelThongTin.Controls.Add(textBoxHoTen);
            panelThongTin.Controls.Add(textBoxMa);
            panelThongTin.Controls.Add(label5);
            panelThongTin.Controls.Add(labelGT);
            panelThongTin.Controls.Add(label3);
            panelThongTin.Controls.Add(labelHoTen);
            panelThongTin.Controls.Add(labelMa);
            panelThongTin.Controls.Add(buttonTrangThai);
            panelThongTin.Controls.Add(buttonSua);
            panelThongTin.Controls.Add(buttonThayAnh);
            panelThongTin.Controls.Add(pictureBoxAVT);
            panelThongTin.Controls.Add(btnExit);
            panelThongTin.Location = new Point(370, 217);
            panelThongTin.Name = "panelThongTin";
            panelThongTin.Size = new Size(800, 500);
            panelThongTin.TabIndex = 12;
            panelThongTin.Visible = false;
            // 
            // checkBoxAD
            // 
            checkBoxAD.AutoSize = true;
            checkBoxAD.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBoxAD.Location = new Point(582, 431);
            checkBoxAD.Name = "checkBoxAD";
            checkBoxAD.Size = new Size(90, 29);
            checkBoxAD.TabIndex = 21;
            checkBoxAD.Text = "Admin";
            checkBoxAD.UseVisualStyleBackColor = true;
            checkBoxAD.Visible = false;
            // 
            // buttonTaoND
            // 
            buttonTaoND.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonTaoND.Location = new Point(471, 424);
            buttonTaoND.Name = "buttonTaoND";
            buttonTaoND.Size = new Size(88, 36);
            buttonTaoND.TabIndex = 20;
            buttonTaoND.Text = "Thêm";
            buttonTaoND.UseVisualStyleBackColor = true;
            buttonTaoND.Visible = false;
            buttonTaoND.Click += buttonTaoND_Click;
            // 
            // textBoxNS
            // 
            textBoxNS.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxNS.Format = DateTimePickerFormat.Short;
            textBoxNS.Location = new Point(369, 250);
            textBoxNS.Name = "textBoxNS";
            textBoxNS.Size = new Size(303, 39);
            textBoxNS.TabIndex = 19;
            textBoxNS.ValueChanged += textBoxNS_ValueChanged;
            // 
            // textBoxMK
            // 
            textBoxMK.BorderStyle = BorderStyle.FixedSingle;
            textBoxMK.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMK.Location = new Point(369, 370);
            textBoxMK.Name = "textBoxMK";
            textBoxMK.Size = new Size(303, 39);
            textBoxMK.TabIndex = 18;
            textBoxMK.Visible = false;
            // 
            // labelMK
            // 
            labelMK.AutoSize = true;
            labelMK.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMK.Location = new Point(228, 372);
            labelMK.Name = "labelMK";
            labelMK.Size = new Size(135, 32);
            labelMK.TabIndex = 17;
            labelMK.Text = "Mật khẩu: ";
            labelMK.Visible = false;
            // 
            // comboBoxGT
            // 
            comboBoxGT.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxGT.FormattingEnabled = true;
            comboBoxGT.Items.AddRange(new object[] { "Nam", "Nữ" });
            comboBoxGT.Location = new Point(369, 183);
            comboBoxGT.Name = "comboBoxGT";
            comboBoxGT.Size = new Size(303, 40);
            comboBoxGT.TabIndex = 14;
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxEmail.Location = new Point(369, 312);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(303, 39);
            textBoxEmail.TabIndex = 13;
            // 
            // textBoxHoTen
            // 
            textBoxHoTen.BorderStyle = BorderStyle.FixedSingle;
            textBoxHoTen.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxHoTen.Location = new Point(369, 113);
            textBoxHoTen.Name = "textBoxHoTen";
            textBoxHoTen.Size = new Size(303, 39);
            textBoxHoTen.TabIndex = 10;
            // 
            // textBoxMa
            // 
            textBoxMa.BorderStyle = BorderStyle.FixedSingle;
            textBoxMa.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMa.Location = new Point(369, 46);
            textBoxMa.Name = "textBoxMa";
            textBoxMa.Size = new Size(303, 39);
            textBoxMa.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(273, 319);
            label5.Name = "label5";
            label5.Size = new Size(90, 32);
            label5.TabIndex = 8;
            label5.Text = "Email: ";
            // 
            // labelGT
            // 
            labelGT.AutoSize = true;
            labelGT.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelGT.Location = new Point(232, 183);
            labelGT.Name = "labelGT";
            labelGT.Size = new Size(131, 32);
            labelGT.TabIndex = 7;
            labelGT.Text = "Giới Tính: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(219, 250);
            label3.Name = "label3";
            label3.Size = new Size(144, 32);
            label3.TabIndex = 6;
            label3.Text = "Ngày Sinh: ";
            // 
            // labelHoTen
            // 
            labelHoTen.AutoSize = true;
            labelHoTen.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHoTen.Location = new Point(255, 113);
            labelHoTen.Name = "labelHoTen";
            labelHoTen.Size = new Size(108, 32);
            labelHoTen.TabIndex = 5;
            labelHoTen.Text = "Họ Tên: ";
            // 
            // labelMa
            // 
            labelMa.AutoSize = true;
            labelMa.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMa.Location = new Point(299, 46);
            labelMa.Name = "labelMa";
            labelMa.Size = new Size(64, 32);
            labelMa.TabIndex = 4;
            labelMa.Text = "Mã: ";
            // 
            // buttonTrangThai
            // 
            buttonTrangThai.Location = new Point(597, 424);
            buttonTrangThai.Name = "buttonTrangThai";
            buttonTrangThai.Size = new Size(75, 23);
            buttonTrangThai.TabIndex = 0;
            buttonTrangThai.Text = "Khóa";
            buttonTrangThai.UseVisualStyleBackColor = true;
            buttonTrangThai.Visible = false;
            buttonTrangThai.Click += buttonTrangThai_Click;
            // 
            // buttonSua
            // 
            buttonSua.Location = new Point(369, 424);
            buttonSua.Name = "buttonSua";
            buttonSua.Size = new Size(75, 23);
            buttonSua.TabIndex = 3;
            buttonSua.Text = "Sửa";
            buttonSua.UseVisualStyleBackColor = true;
            buttonSua.Visible = false;
            buttonSua.Click += buttonSua_Click;
            // 
            // buttonThayAnh
            // 
            buttonThayAnh.Location = new Point(76, 277);
            buttonThayAnh.Name = "buttonThayAnh";
            buttonThayAnh.Size = new Size(75, 23);
            buttonThayAnh.TabIndex = 2;
            buttonThayAnh.Text = "Thay ảnh";
            buttonThayAnh.UseVisualStyleBackColor = true;
            buttonThayAnh.Visible = false;
            buttonThayAnh.Click += buttonThayAnh_Click;
            // 
            // pictureBoxAVT
            // 
            pictureBoxAVT.BackColor = Color.White;
            pictureBoxAVT.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxAVT.Location = new Point(42, 46);
            pictureBoxAVT.Name = "pictureBoxAVT";
            pictureBoxAVT.Size = new Size(150, 225);
            pictureBoxAVT.TabIndex = 1;
            pictureBoxAVT.TabStop = false;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(731, 22);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(51, 23);
            btnExit.TabIndex = 0;
            btnExit.Text = "Đóng";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // button_ThemND
            // 
            button_ThemND.BackColor = Color.DeepSkyBlue;
            button_ThemND.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ThemND.ForeColor = SystemColors.ButtonHighlight;
            button_ThemND.Image = (Image)resources.GetObject("button_ThemND.Image");
            button_ThemND.ImageAlign = ContentAlignment.MiddleLeft;
            button_ThemND.Location = new Point(1310, 46);
            button_ThemND.Name = "button_ThemND";
            button_ThemND.Size = new Size(203, 45);
            button_ThemND.TabIndex = 13;
            button_ThemND.Text = "THÊM SINH VIÊN";
            button_ThemND.TextAlign = ContentAlignment.MiddleRight;
            button_ThemND.UseVisualStyleBackColor = false;
            button_ThemND.Click += button_ThemND_Click;
            // 
            // Component_NguoiDung
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(button_ThemND);
            Controls.Add(panelThongTin);
            Controls.Add(dataGridView_DSGVSV);
            Controls.Add(textBoxTimKiem);
            Controls.Add(comboboxLoc);
            Name = "Component_NguoiDung";
            Size = new Size(1541, 934);
            Load += Component_NguoiDung_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSGVSV).EndInit();
            panelThongTin.ResumeLayout(false);
            panelThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAVT).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboboxLoc;
        private TextBox textBoxTimKiem;
        private DataGridView dataGridView_DSGVSV;
        private Panel panelThongTin;
        private Button btnExit;
        private PictureBox pictureBoxAVT;
        private Button buttonSua;
        private Button buttonThayAnh;
        private Button buttonTrangThai;
        private Label labelHoTen;
        private Label labelMa;
        private Label label5;
        private Label labelGT;
        private Label label3;
        private TextBox textBoxHoTen;
        private TextBox textBoxMa;
        private TextBox textBoxEmail;
        private ComboBox comboBoxGT;
        private Button button_ThemND;
        private TextBox textBoxMK;
        private Label labelMK;
        private DateTimePicker textBoxNS;
        private Button buttonTaoND;
        private CheckBox checkBoxAD;
    }
}
