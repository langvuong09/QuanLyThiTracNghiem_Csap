namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Dialog_XemThongBao
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
            btnSua = new Button();
            cklbxNhom = new CheckedListBox();
            cbxMonHoc = new ComboBox();
            lblMonHoc = new Label();
            lblNoiDung = new Label();
            txtTitle = new TextBox();
            lblTitle = new Label();
            txtNoiDung = new TextBox();
            SuspendLayout();
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ActiveCaption;
            btnSua.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.ForeColor = SystemColors.ButtonHighlight;
            btnSua.Location = new Point(52, 447);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(863, 53);
            btnSua.TabIndex = 15;
            btnSua.Text = "CẬP NHẬT THÔNG BÁO";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // cklbxNhom
            // 
            cklbxNhom.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cklbxNhom.FormattingEnabled = true;
            cklbxNhom.Location = new Point(525, 154);
            cklbxNhom.Name = "cklbxNhom";
            cklbxNhom.Size = new Size(390, 228);
            cklbxNhom.TabIndex = 14;
            // 
            // cbxMonHoc
            // 
            cbxMonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxMonHoc.FormattingEnabled = true;
            cbxMonHoc.Location = new Point(525, 86);
            cbxMonHoc.Name = "cbxMonHoc";
            cbxMonHoc.Enabled = false;
            cbxMonHoc.Size = new Size(390, 38);
            cbxMonHoc.TabIndex = 13;
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMonHoc.Location = new Point(525, 42);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(107, 30);
            lblMonHoc.TabIndex = 11;
            lblMonHoc.Text = "Môn học: ";
            // 
            // lblNoiDung
            // 
            lblNoiDung.AutoSize = true;
            lblNoiDung.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoiDung.Location = new Point(52, 151);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(111, 30);
            lblNoiDung.TabIndex = 10;
            lblNoiDung.Text = "Nội dung: ";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(52, 86);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(409, 35);
            txtTitle.TabIndex = 9;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(52, 42);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(86, 30);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Tiêu đề:";
            // 
            // txtNoiDung
            // 
            txtNoiDung.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNoiDung.Location = new Point(52, 192);
            txtNoiDung.Multiline = true;
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(409, 190);
            txtNoiDung.TabIndex = 16;
            // 
            // Dialog_XemThongBao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtNoiDung);
            Controls.Add(btnSua);
            Controls.Add(cklbxNhom);
            Controls.Add(cbxMonHoc);
            Controls.Add(lblMonHoc);
            Controls.Add(lblNoiDung);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Name = "Dialog_XemThongBao";
            Size = new Size(967, 542);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSua;
        private CheckedListBox cklbxNhom;
        private ComboBox cbxMonHoc;
        private Label lblMonHoc;
        private Label lblNoiDung;
        private TextBox txtTitle;
        private Label lblTitle;
        private TextBox txtNoiDung;
    }
}
