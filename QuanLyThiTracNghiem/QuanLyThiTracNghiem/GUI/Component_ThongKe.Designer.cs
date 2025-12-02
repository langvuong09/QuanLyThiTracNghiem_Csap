namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_ThongKe
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
            cbxNhom = new ComboBox();
            cklbxBaiKiemTra = new CheckedListBox();
            cbxMonHoc = new ComboBox();
            lblNhom = new Label();
            lblBaiKiemTra = new Label();
            lblMonHoc = new Label();
            pnDoThi = new Panel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(643, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(271, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THỐNG KÊ";
            // 
            // cbxNhom
            // 
            cbxNhom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxNhom.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxNhom.FormattingEnabled = true;
            cbxNhom.Location = new Point(619, 146);
            cbxNhom.Name = "cbxNhom";
            cbxNhom.Size = new Size(278, 40);
            cbxNhom.TabIndex = 1;
            // 
            // cklbxBaiKiemTra
            // 
            cklbxBaiKiemTra.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cklbxBaiKiemTra.FormattingEnabled = true;
            cklbxBaiKiemTra.Location = new Point(1159, 145);
            cklbxBaiKiemTra.Name = "cklbxBaiKiemTra";
            cklbxBaiKiemTra.Size = new Size(344, 184);
            cklbxBaiKiemTra.TabIndex = 2;
            // 
            // cbxMonHoc
            // 
            cbxMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMonHoc.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxMonHoc.FormattingEnabled = true;
            cbxMonHoc.Location = new Point(177, 147);
            cbxMonHoc.Name = "cbxMonHoc";
            cbxMonHoc.Size = new Size(278, 40);
            cbxMonHoc.TabIndex = 3;
            // 
            // lblNhom
            // 
            lblNhom.AutoSize = true;
            lblNhom.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNhom.Location = new Point(510, 146);
            lblNhom.Name = "lblNhom";
            lblNhom.Size = new Size(103, 37);
            lblNhom.TabIndex = 5;
            lblNhom.Text = "Nhóm:";
            // 
            // lblBaiKiemTra
            // 
            lblBaiKiemTra.AutoSize = true;
            lblBaiKiemTra.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBaiKiemTra.Location = new Point(935, 145);
            lblBaiKiemTra.Name = "lblBaiKiemTra";
            lblBaiKiemTra.Size = new Size(181, 37);
            lblBaiKiemTra.TabIndex = 6;
            lblBaiKiemTra.Text = "Bài Kiểm tra:";
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonHoc.Location = new Point(35, 146);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(136, 37);
            lblMonHoc.TabIndex = 7;
            lblMonHoc.Text = "Môn học:";
            // 
            // pnDoThi
            // 
            pnDoThi.BackColor = Color.Gainsboro;
            pnDoThi.Location = new Point(115, 356);
            pnDoThi.Name = "pnDoThi";
            pnDoThi.Size = new Size(1311, 575);
            pnDoThi.TabIndex = 9;
            // 
            // Component_ThongKe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnDoThi);
            Controls.Add(lblMonHoc);
            Controls.Add(lblBaiKiemTra);
            Controls.Add(lblNhom);
            Controls.Add(cbxMonHoc);
            Controls.Add(cklbxBaiKiemTra);
            Controls.Add(cbxNhom);
            Controls.Add(lblTitle);
            Name = "Component_ThongKe";
            Size = new Size(1541, 934);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private CheckedListBox checkedListBox1;
        private ComboBox comboBox2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblTitle;
        private Label lblNhom;
        private Label lblBaiKiemTra;
        private Label lblMonHoc;
        private ComboBox cbxNhom;
        private CheckedListBox cklbxBaiKiemTra;
        private ComboBox cbxMonHoc;
        private Panel pnDoThi;
    }
}
