namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Dialog_XemDanhSachDeThi
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
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            btnTimKiem = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(457, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(374, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "DANH SÁCH ĐỀ KIỂM TRA";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(385, 72);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(406, 35);
            textBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 140);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1310, 537);
            dataGridView1.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = SystemColors.Control;
            btnTimKiem.Location = new Point(797, 68);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(136, 45);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // Dialog_XemDanhSachDeThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnTimKiem);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(lblTitle);
            Name = "Dialog_XemDanhSachDeThi";
            Size = new Size(1316, 680);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button btnTimKiem;
    }
}
