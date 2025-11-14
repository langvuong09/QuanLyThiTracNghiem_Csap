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
            button_Xem = new Button();
            button_Khoa = new Button();
            button_Mokhoa = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSGVSV).BeginInit();
            SuspendLayout();
            // 
            // comboboxLoc
            // 
            comboboxLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboboxLoc.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboboxLoc.ForeColor = SystemColors.InactiveCaptionText;
            comboboxLoc.FormattingEnabled = true;
            comboboxLoc.Items.AddRange(new object[] { "Sinh Viên", "Giáo Viên" });
            comboboxLoc.Location = new Point(1237, 46);
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
            textBoxTimKiem.Size = new Size(1165, 45);
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
            dataGridView_DSGVSV.Size = new Size(1377, 776);
            dataGridView_DSGVSV.TabIndex = 4;
            dataGridView_DSGVSV.DataBindingComplete += DataGridView_DSGVSV_DataBindingComplete;
            // 
            // button_Xem
            // 
            button_Xem.BackColor = Color.DeepSkyBlue;
            button_Xem.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Xem.ForeColor = SystemColors.ButtonHighlight;
            button_Xem.Image = (Image)resources.GetObject("button_Xem.Image");
            button_Xem.ImageAlign = ContentAlignment.MiddleLeft;
            button_Xem.Location = new Point(1418, 145);
            button_Xem.Name = "button_Xem";
            button_Xem.Size = new Size(120, 52);
            button_Xem.TabIndex = 6;
            button_Xem.Text = "XEM";
            button_Xem.TextAlign = ContentAlignment.MiddleRight;
            button_Xem.UseVisualStyleBackColor = false;
            // 
            // button_Khoa
            // 
            button_Khoa.BackColor = Color.DarkTurquoise;
            button_Khoa.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Khoa.ForeColor = SystemColors.ButtonHighlight;
            button_Khoa.Image = (Image)resources.GetObject("button_Khoa.Image");
            button_Khoa.ImageAlign = ContentAlignment.MiddleLeft;
            button_Khoa.Location = new Point(1418, 240);
            button_Khoa.Name = "button_Khoa";
            button_Khoa.Size = new Size(120, 52);
            button_Khoa.TabIndex = 7;
            button_Khoa.Text = "Khóa";
            button_Khoa.TextAlign = ContentAlignment.MiddleRight;
            button_Khoa.UseVisualStyleBackColor = false;
            // 
            // button_Mokhoa
            // 
            button_Mokhoa.BackColor = Color.DarkTurquoise;
            button_Mokhoa.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Mokhoa.ForeColor = SystemColors.ButtonHighlight;
            button_Mokhoa.Image = (Image)resources.GetObject("button_Mokhoa.Image");
            button_Mokhoa.ImageAlign = ContentAlignment.MiddleLeft;
            button_Mokhoa.Location = new Point(1418, 333);
            button_Mokhoa.Name = "button_Mokhoa";
            button_Mokhoa.Size = new Size(120, 52);
            button_Mokhoa.TabIndex = 8;
            button_Mokhoa.Text = "Mở ";
            button_Mokhoa.TextAlign = ContentAlignment.MiddleRight;
            button_Mokhoa.UseVisualStyleBackColor = false;
            // 
            // Component_NguoiDung
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(button_Mokhoa);
            Controls.Add(button_Khoa);
            Controls.Add(button_Xem);
            Controls.Add(dataGridView_DSGVSV);
            Controls.Add(textBoxTimKiem);
            Controls.Add(comboboxLoc);
            Name = "Component_NguoiDung";
            Size = new Size(1541, 934);
            Load += Component_NguoiDung_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSGVSV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboboxLoc;
        private TextBox textBoxTimKiem;
        private DataGridView dataGridView_DSGVSV;
        private Button button_Xem;
        private Button button_Khoa;
        private Button button_Mokhoa;
    }
}
