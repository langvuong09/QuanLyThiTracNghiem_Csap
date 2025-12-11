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
            panel1.BackColor = Color.FromArgb(70, 130, 180);
            panel1.BorderStyle = BorderStyle.None;
            panel1.Controls.Add(textBoxTenSV);
            panel1.Controls.Add(textBoxMSSV);
            panel1.Controls.Add(labelMSSV);
            panel1.Controls.Add(labelThiSinh);
            panel1.Location = new Point(48, 40);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(994, 90);
            panel1.TabIndex = 0;
            // 
            // labelThiSinh
            // 
            labelThiSinh.AutoSize = true;
            labelThiSinh.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelThiSinh.ForeColor = Color.White;
            labelThiSinh.Location = new Point(463, 40);
            labelThiSinh.Margin = new Padding(0);
            labelThiSinh.Name = "labelThiSinh";
            labelThiSinh.Size = new Size(100, 30);
            labelThiSinh.TabIndex = 0;
            labelThiSinh.Text = "THÍ SINH:";
            labelThiSinh.Click += this.label1_Click;
            // 
            // labelMSSV
            // 
            labelMSSV.AutoSize = true;
            labelMSSV.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMSSV.ForeColor = Color.White;
            labelMSSV.Location = new Point(40, 40);
            labelMSSV.Margin = new Padding(0);
            labelMSSV.Name = "labelMSSV";
            labelMSSV.Size = new Size(75, 30);
            labelMSSV.TabIndex = 1;
            labelMSSV.Text = "MSSV: ";
            labelMSSV.Click += this.labelMSSV_Click;
            // 
            // textBoxMSSV
            // 
            textBoxMSSV.BackColor = Color.White;
            textBoxMSSV.BorderStyle = BorderStyle.FixedSingle;
            textBoxMSSV.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxMSSV.Location = new Point(125, 25);
            textBoxMSSV.Margin = new Padding(0);
            textBoxMSSV.Multiline = true;
            textBoxMSSV.Name = "textBoxMSSV";
            textBoxMSSV.Padding = new Padding(8);
            textBoxMSSV.Size = new Size(232, 50);
            textBoxMSSV.TabIndex = 2;
            // 
            // textBoxTenSV
            // 
            textBoxTenSV.BackColor = Color.White;
            textBoxTenSV.BorderStyle = BorderStyle.FixedSingle;
            textBoxTenSV.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTenSV.Location = new Point(578, 25);
            textBoxTenSV.Margin = new Padding(0);
            textBoxTenSV.Multiline = true;
            textBoxTenSV.Name = "textBoxTenSV";
            textBoxTenSV.Padding = new Padding(8);
            textBoxTenSV.Size = new Size(385, 50);
            textBoxTenSV.TabIndex = 3;
            // 
            // panelNoiDung
            // 
            panelNoiDung.BackColor = Color.FromArgb(248, 250, 252);
            panelNoiDung.BorderStyle = BorderStyle.FixedSingle;
            panelNoiDung.Controls.Add(panelPhanTrang);
            panelNoiDung.Controls.Add(panelDapAn);
            panelNoiDung.Controls.Add(textBoxCauHoi);
            panelNoiDung.Controls.Add(labelCauHoi);
            panelNoiDung.Location = new Point(48, 150);
            panelNoiDung.Margin = new Padding(0);
            panelNoiDung.Name = "panelNoiDung";
            panelNoiDung.Padding = new Padding(15);
            panelNoiDung.Size = new Size(994, 470);
            panelNoiDung.TabIndex = 1;
            // 
            // labelCauHoi
            // 
            labelCauHoi.AutoSize = true;
            labelCauHoi.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCauHoi.ForeColor = Color.FromArgb(70, 130, 180);
            labelCauHoi.Location = new Point(18, 20);
            labelCauHoi.Margin = new Padding(0);
            labelCauHoi.Name = "labelCauHoi";
            labelCauHoi.Size = new Size(100, 30);
            labelCauHoi.TabIndex = 0;
            labelCauHoi.Text = "CÂU HỎI";
            // 
            // textBoxCauHoi
            // 
            textBoxCauHoi.BackColor = Color.White;
            textBoxCauHoi.BorderStyle = BorderStyle.FixedSingle;
            textBoxCauHoi.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCauHoi.Location = new Point(125, 20);
            textBoxCauHoi.Margin = new Padding(0);
            textBoxCauHoi.Multiline = true;
            textBoxCauHoi.Name = "textBoxCauHoi";
            textBoxCauHoi.Padding = new Padding(10);
            textBoxCauHoi.Size = new Size(838, 290);
            textBoxCauHoi.TabIndex = 1;
            // 
            // panelDapAn
            // 
            panelDapAn.BackColor = Color.FromArgb(240, 248, 255);
            panelDapAn.BorderStyle = BorderStyle.FixedSingle;
            panelDapAn.Controls.Add(radioD);
            panelDapAn.Controls.Add(radioC);
            panelDapAn.Controls.Add(radioB);
            panelDapAn.Controls.Add(radioA);
            panelDapAn.Location = new Point(0, 320);
            panelDapAn.Margin = new Padding(0);
            panelDapAn.Name = "panelDapAn";
            panelDapAn.Padding = new Padding(10);
            panelDapAn.Size = new Size(994, 110);
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
            panelPhanTrang.BackColor = Color.FromArgb(240, 248, 255);
            panelPhanTrang.BorderStyle = BorderStyle.FixedSingle;
            panelPhanTrang.Controls.Add(btnPrevious);
            panelPhanTrang.Controls.Add(btnNext);
            panelPhanTrang.Controls.Add(labelSoCau);
            panelPhanTrang.Location = new Point(0, 430);
            panelPhanTrang.Margin = new Padding(0);
            panelPhanTrang.Name = "panelPhanTrang";
            panelPhanTrang.Padding = new Padding(10);
            panelPhanTrang.Size = new Size(994, 70);
            panelPhanTrang.TabIndex = 3;
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.FromArgb(70, 130, 180);
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 100, 150);
            btnPrevious.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 150, 200);
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrevious.ForeColor = Color.White;
            btnPrevious.Location = new Point(300, 18);
            btnPrevious.Margin = new Padding(0);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Padding = new Padding(5);
            btnPrevious.Size = new Size(130, 42);
            btnPrevious.TabIndex = 0;
            btnPrevious.Text = "◄ Câu trước";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(70, 130, 180);
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 100, 150);
            btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 150, 200);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(574, 18);
            btnNext.Margin = new Padding(0);
            btnNext.Name = "btnNext";
            btnNext.Padding = new Padding(5);
            btnNext.Size = new Size(130, 42);
            btnNext.TabIndex = 1;
            btnNext.Text = "Câu sau ►";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // labelSoCau
            // 
            labelSoCau.AutoSize = true;
            labelSoCau.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSoCau.ForeColor = Color.FromArgb(70, 130, 180);
            labelSoCau.Location = new Point(450, 23);
            labelSoCau.Margin = new Padding(0);
            labelSoCau.Name = "labelSoCau";
            labelSoCau.Size = new Size(100, 28);
            labelSoCau.TabIndex = 2;
            labelSoCau.Text = "Câu 1 / 5";
            labelSoCau.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Dialog_XemBaiThiSV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(panelNoiDung);
            Controls.Add(panel1);
            Margin = new Padding(0);
            Padding = new Padding(20);
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
