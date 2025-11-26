namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_PhanCong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            dataGridView_DSPC = new DataGridView();
            textBoxTimKiem = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSPC).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_DSPC
            // 
            dataGridView_DSPC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_DSPC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_DSPC.Location = new Point(16, 139);
            dataGridView_DSPC.Name = "dataGridView_DSPC";
            dataGridView_DSPC.Size = new Size(1489, 776);
            dataGridView_DSPC.TabIndex = 5;
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimKiem.Location = new Point(33, 47);
            textBoxTimKiem.Multiline = true;
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.Size = new Size(1146, 45);
            textBoxTimKiem.TabIndex = 6;
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            textBoxTimKiem.KeyDown += textBoxTimKiem_KeyDown;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1227, 47);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 45);
            comboBox1.TabIndex = 7;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(1384, 47);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 45);
            comboBox2.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Location = new Point(620, 190);
            panel1.Name = "panel1";
            panel1.Size = new Size(540, 374);
            panel1.TabIndex = 9;
            panel1.Visible = false;
            // 
            // Component_PhanCong
            // 
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBoxTimKiem);
            Controls.Add(dataGridView_DSPC);
            Name = "Component_PhanCong";
            Size = new Size(1541, 934);
            Load += Component_PhanCong_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_DSPC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_DSPC;
        private TextBox textBoxTimKiem;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Panel panel1;
    }
}
