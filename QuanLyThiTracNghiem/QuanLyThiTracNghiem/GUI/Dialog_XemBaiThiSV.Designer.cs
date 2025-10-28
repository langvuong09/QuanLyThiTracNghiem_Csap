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
            panel1.SuspendLayout();
            panelNoiDung.SuspendLayout();
            panelDapAn.SuspendLayout();
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
            panelNoiDung.Controls.Add(panelDapAn);
            panelNoiDung.Controls.Add(textBoxCauHoi);
            panelNoiDung.Controls.Add(labelCauHoi);
            panelNoiDung.Location = new Point(39, 134);
            panelNoiDung.Name = "panelNoiDung";
            panelNoiDung.Size = new Size(994, 394);
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
            panelDapAn.BackColor = SystemColors.ActiveCaption;
            panelDapAn.Controls.Add(radioD);
            panelDapAn.Controls.Add(radioC);
            panelDapAn.Controls.Add(radioB);
            panelDapAn.Controls.Add(radioA);
            panelDapAn.Location = new Point(0, 327);
            panelDapAn.Name = "panelDapAn";
            panelDapAn.Size = new Size(994, 67);
            panelDapAn.TabIndex = 2;
            // 
            // radioA
            // 
            radioA.AutoSize = true;
            radioA.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioA.Location = new Point(259, 19);
            radioA.Name = "radioA";
            radioA.Size = new Size(43, 29);
            radioA.TabIndex = 0;
            radioA.TabStop = true;
            radioA.Text = "A";
            radioA.UseVisualStyleBackColor = true;
            radioA.CheckedChanged += this.radioButton1_CheckedChanged;
            // 
            // radioB
            // 
            radioB.AutoSize = true;
            radioB.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioB.Location = new Point(426, 19);
            radioB.Name = "radioB";
            radioB.Size = new Size(41, 29);
            radioB.TabIndex = 1;
            radioB.TabStop = true;
            radioB.Text = "B";
            radioB.UseVisualStyleBackColor = true;
            // 
            // radioC
            // 
            radioC.AutoSize = true;
            radioC.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioC.Location = new Point(586, 19);
            radioC.Name = "radioC";
            radioC.Size = new Size(42, 29);
            radioC.TabIndex = 2;
            radioC.TabStop = true;
            radioC.Text = "C";
            radioC.UseVisualStyleBackColor = true;
            // 
            // radioD
            // 
            radioD.AutoSize = true;
            radioD.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioD.Location = new Point(751, 19);
            radioD.Name = "radioD";
            radioD.Size = new Size(44, 29);
            radioD.TabIndex = 3;
            radioD.TabStop = true;
            radioD.Text = "D";
            radioD.UseVisualStyleBackColor = true;
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
    }
}
