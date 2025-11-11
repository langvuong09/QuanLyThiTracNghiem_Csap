namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Dialog_XemBaiThiSV
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
            panel1 = new Panel();
            labelThiSinh = new Label();
            labelMSSV = new Label();
            textBoxMSSV = new TextBox();
            textBoxTenSV = new TextBox();
            panelNoiDung = new Panel();
            labelCauHoi = new Label();
            textBoxCauHoi = new TextBox();
            panelDapAn = new Panel();
            radioA = new RadioButton();
            radioB = new RadioButton();
            radioC = new RadioButton();
            radioD = new RadioButton();
            panelPhanTrang = new Panel();
            btnPrevious = new Button();
            btnNext = new Button();
            labelSoCau = new Label();
            panel1.SuspendLayout();
            panelNoiDung.SuspendLayout();
            panelDapAn.SuspendLayout();
            panelPhanTrang.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(196, 205, 255);
            panel1.Controls.Add(textBoxTenSV);
            panel1.Controls.Add(textBoxMSSV);
            panel1.Controls.Add(labelMSSV);
            panel1.Controls.Add(labelThiSinh);
            panel1.Location = new Point(39, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(994, 74);
            panel1.TabIndex = 0;
            // 
            // labelThiSinh
            // 
            labelThiSinh.AutoSize = true;
            labelThiSinh.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelThiSinh.Location = new Point(463, 32);
            labelThiSinh.Name = "labelThiSinh";
            labelThiSinh.Size = new Size(91, 25);
            labelThiSinh.TabIndex = 0;
            labelThiSinh.Text = "THÍ SINH:";
            labelThiSinh.Click += this.label1_Click;
            // 
            // labelMSSV
            // 
            labelMSSV.AutoSize = true;
            labelMSSV.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMSSV.Location = new Point(35, 32);
            labelMSSV.Name = "labelMSSV";
            labelMSSV.Size = new Size(70, 25);
            labelMSSV.TabIndex = 1;
            labelMSSV.Text = "MSSV: ";
            labelMSSV.Click += this.labelMSSV_Click;
            // 
            // textBoxMSSV
            // 
            textBoxMSSV.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMSSV.Location = new Point(119, 17);
            textBoxMSSV.Multiline = true;
            textBoxMSSV.Name = "textBoxMSSV";
            textBoxMSSV.Size = new Size(232, 40);
            textBoxMSSV.TabIndex = 2;
            // 
            // textBoxTenSV
            // 
            textBoxTenSV.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTenSV.Location = new Point(572, 17);
            textBoxTenSV.Multiline = true;
            textBoxTenSV.Name = "textBoxTenSV";
            textBoxTenSV.Size = new Size(385, 40);
            textBoxTenSV.TabIndex = 3;
            // 
            // panelNoiDung
            // 
            panelNoiDung.Controls.Add(panelPhanTrang);
            panelNoiDung.Controls.Add(panelDapAn);
            panelNoiDung.Controls.Add(textBoxCauHoi);
            panelNoiDung.Controls.Add(labelCauHoi);
            panelNoiDung.Location = new Point(39, 134);
            panelNoiDung.Name = "panelNoiDung";
            panelNoiDung.Size = new Size(994, 450);
            panelNoiDung.TabIndex = 1;
            // 
            // labelCauHoi
            // 
            labelCauHoi.AutoSize = true;
            labelCauHoi.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCauHoi.Location = new Point(14, 14);
            labelCauHoi.Name = "labelCauHoi";
            labelCauHoi.Size = new Size(91, 25);
            labelCauHoi.TabIndex = 0;
            labelCauHoi.Text = "CÂU HỎI";
            // 
            // textBoxCauHoi
            // 
            textBoxCauHoi.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCauHoi.Location = new Point(119, 14);
            textBoxCauHoi.Multiline = true;
            textBoxCauHoi.Name = "textBoxCauHoi";
            textBoxCauHoi.Size = new Size(838, 273);
            textBoxCauHoi.TabIndex = 1;
            // 
            // panelDapAn
            // 
            panelDapAn.BackColor = Color.FromArgb(245, 245, 250);
            panelDapAn.Controls.Add(radioD);
            panelDapAn.Controls.Add(radioC);
            panelDapAn.Controls.Add(radioB);
            panelDapAn.Controls.Add(radioA);
            panelDapAn.Location = new Point(0, 300);
            panelDapAn.Name = "panelDapAn";
            panelDapAn.Size = new Size(994, 94);
            panelDapAn.TabIndex = 2;
            // 
            // radioA
            // 
            radioA.AutoSize = true;
            radioA.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioA.Location = new Point(20, 10);
            radioA.Name = "radioA";
            radioA.Padding = new Padding(0, 5, 0, 5);
            radioA.Size = new Size(450, 30);
            radioA.TabIndex = 0;
            radioA.TabStop = true;
            radioA.Text = "A.";
            radioA.UseVisualStyleBackColor = true;
            radioA.CheckedChanged += this.radioButton1_CheckedChanged;
            // 
            // radioB
            // 
            radioB.AutoSize = true;
            radioB.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioB.Location = new Point(20, 50);
            radioB.Name = "radioB";
            radioB.Padding = new Padding(0, 5, 0, 5);
            radioB.Size = new Size(450, 30);
            radioB.TabIndex = 1;
            radioB.TabStop = true;
            radioB.Text = "B.";
            radioB.UseVisualStyleBackColor = true;
            // 
            // radioC
            // 
            radioC.AutoSize = true;
            radioC.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioC.Location = new Point(500, 10);
            radioC.Name = "radioC";
            radioC.Padding = new Padding(0, 5, 0, 5);
            radioC.Size = new Size(450, 30);
            radioC.TabIndex = 2;
            radioC.TabStop = true;
            radioC.Text = "C.";
            radioC.UseVisualStyleBackColor = true;
            // 
            // radioD
            // 
            radioD.AutoSize = true;
            radioD.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioD.Location = new Point(500, 50);
            radioD.Name = "radioD";
            radioD.Padding = new Padding(0, 5, 0, 5);
            radioD.Size = new Size(450, 30);
            radioD.TabIndex = 3;
            radioD.TabStop = true;
            radioD.Text = "D.";
            radioD.UseVisualStyleBackColor = true;
            // 
            // panelPhanTrang
            // 
            panelPhanTrang.BackColor = Color.FromArgb(240, 240, 240);
            panelPhanTrang.Controls.Add(btnPrevious);
            panelPhanTrang.Controls.Add(btnNext);
            panelPhanTrang.Controls.Add(labelSoCau);
            panelPhanTrang.Location = new Point(0, 394);
            panelPhanTrang.Name = "panelPhanTrang";
            panelPhanTrang.Size = new Size(994, 56);
            panelPhanTrang.TabIndex = 3;
            // 
            // btnPrevious
            // 
            btnPrevious.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevious.Location = new Point(300, 12);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(120, 35);
            btnPrevious.TabIndex = 0;
            btnPrevious.Text = "◄ Câu trước";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(574, 12);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(120, 35);
            btnNext.TabIndex = 1;
            btnNext.Text = "Câu sau ►";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // labelSoCau
            // 
            labelSoCau.AutoSize = true;
            labelSoCau.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSoCau.Location = new Point(450, 17);
            labelSoCau.Name = "labelSoCau";
            labelSoCau.Size = new Size(94, 25);
            labelSoCau.TabIndex = 2;
            labelSoCau.Text = "Câu 1 / 5";
            labelSoCau.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Dialog_XemBaiThiSV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelNoiDung);
            Controls.Add(panel1);
            Name = "Dialog_XemBaiThiSV";
            Size = new Size(1086, 633);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelNoiDung.ResumeLayout(false);
            panelNoiDung.PerformLayout();
            panelDapAn.ResumeLayout(false);
            panelDapAn.PerformLayout();
            panelPhanTrang.ResumeLayout(false);
            panelPhanTrang.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelThiSinh;
        private TextBox textBoxMSSV;
        private Label labelMSSV;
        private TextBox textBoxTenSV;
        private Panel panelNoiDung;
        private Panel panelDapAn;
        private TextBox textBoxCauHoi;
        private Label labelCauHoi;
        private RadioButton radioA;
        private RadioButton radioB;
        private RadioButton radioD;
        private RadioButton radioC;
        private Panel panelPhanTrang;
        private Button btnPrevious;
        private Button btnNext;
        private Label labelSoCau;
    }
}
