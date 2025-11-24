namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Dialog_TaoThongBao
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
            lblTitle = new Label();
            txtTieuDe = new TextBox();
            lblNoiDung = new Label();
            lblMonHoc = new Label();
            cbxMonHoc = new ComboBox();
            cklbxNhom = new CheckedListBox();
            btnThem = new Button();
            txtNoiDung = new TextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(51, 29);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(86, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tiêu đề:";
            // 
            // txtTieuDe
            // 
            txtTieuDe.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTieuDe.Location = new Point(51, 73);
            txtTieuDe.Name = "txtTieuDe";
            txtTieuDe.Size = new Size(409, 35);
            txtTieuDe.TabIndex = 1;
            // 
            // lblNoiDung
            // 
            lblNoiDung.AutoSize = true;
            lblNoiDung.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoiDung.Location = new Point(51, 138);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(111, 30);
            lblNoiDung.TabIndex = 2;
            lblNoiDung.Text = "Nội dung: ";
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMonHoc.Location = new Point(524, 29);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(107, 30);
            lblMonHoc.TabIndex = 3;
            lblMonHoc.Text = "Môn học: ";
            // 
            // cbxMonHoc
            // 
            cbxMonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxMonHoc.FormattingEnabled = true;
            cbxMonHoc.Location = new Point(524, 73);
            cbxMonHoc.Name = "cbxMonHoc";
            cbxMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMonHoc.Size = new Size(390, 38);
            cbxMonHoc.TabIndex = 5;
            // 
            // cklbxNhom
            // 
            cklbxNhom.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cklbxNhom.FormattingEnabled = true;
            cklbxNhom.Location = new Point(524, 141);
            cklbxNhom.Name = "cklbxNhom";
            cklbxNhom.Size = new Size(390, 228);
            cklbxNhom.TabIndex = 6;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ActiveCaption;
            btnThem.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.ButtonHighlight;
            btnThem.Location = new Point(51, 434);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(863, 60);
            btnThem.TabIndex = 7;
            btnThem.Text = "TẠO THÔNG BÁO";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // txtNoiDung
            // 
            txtNoiDung.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNoiDung.Location = new Point(51, 180);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Multiline = true;
            txtNoiDung.WordWrap = true;
            txtNoiDung.Size = new Size(409, 190);
            txtNoiDung.TabIndex = 8;
            // 
            // Dialog_TaoThongBao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(txtNoiDung);
            Controls.Add(btnThem);
            Controls.Add(cklbxNhom);
            Controls.Add(cbxMonHoc);
            Controls.Add(lblMonHoc);
            Controls.Add(lblNoiDung);
            Controls.Add(txtTieuDe);
            Controls.Add(lblTitle);
            Name = "Dialog_TaoThongBao";
            Size = new Size(967, 540);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtTieuDe;
        private Label lblNoiDung;
        private Label lblMonHoc;
        private ComboBox cbxMonHoc;
        private CheckedListBox cklbxNhom;
        private Button btnThem;
        private TextBox txtNoiDung;
    }
}
