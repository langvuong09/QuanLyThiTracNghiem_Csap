
using Org.BouncyCastle.Asn1.Crmf;
using System.Xml.Linq;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class XemChiTietDeThi
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
            comboBoxTatCa = new ComboBox();
            comboBoxTrangThaiNop = new ComboBox();
            textBoxTimKiem = new TextBox();
            btnXuatExcel = new Button();
            dataGridView1 = new DataGridView();
            ColMSSV = new DataGridViewTextBoxColumn();
            ColTen = new DataGridViewTextBoxColumn();
            ColDiem = new DataGridViewTextBoxColumn();
            ColTimeVaoThi = new DataGridViewTextBoxColumn();
            ColTimeNopBai = new DataGridViewTextBoxColumn();
            ColHanhDong = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxTatCa
            // 
            comboBoxTatCa.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBoxTatCa.FormattingEnabled = true;
            comboBoxTatCa.Items.AddRange(new object[] { "Tất cả", "" });
            comboBoxTatCa.Location = new Point(42, 36);
            comboBoxTatCa.Name = "comboBoxTatCa";
            comboBoxTatCa.Size = new Size(149, 38);
            comboBoxTatCa.TabIndex = 0;
            comboBoxTatCa.Text = "Tất cả";
            comboBoxTatCa.SelectedIndexChanged += comboBoxTatCa_SelectedIndexChanged;
            // 
            // comboBoxTrangThaiNop
            // 
            comboBoxTrangThaiNop.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBoxTrangThaiNop.FormattingEnabled = true;
            comboBoxTrangThaiNop.Items.AddRange(new object[] { "Đã nộp bài", "Chưa nộp bài", "" });
            comboBoxTrangThaiNop.Location = new Point(229, 36);
            comboBoxTrangThaiNop.Name = "comboBoxTrangThaiNop";
            comboBoxTrangThaiNop.Size = new Size(149, 38);
            comboBoxTrangThaiNop.TabIndex = 1;
            comboBoxTrangThaiNop.Text = "Đã nộp bài";
            comboBoxTrangThaiNop.SelectedIndexChanged += comboBoxTrangThaiNop_SelectedIndexChanged;
            // 
            // textBoxTimKiem
            // 
            textBoxTimKiem.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTimKiem.Location = new Point(419, 36);
            textBoxTimKiem.Multiline = true;
            textBoxTimKiem.Name = "textBoxTimKiem";
            textBoxTimKiem.Size = new Size(483, 38);
            textBoxTimKiem.TabIndex = 2;
            textBoxTimKiem.TextChanged += textBoxTimKiem_TextChanged;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.FromArgb(126, 164, 241);
            btnXuatExcel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuatExcel.Location = new Point(1026, 26);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(229, 57);
            btnXuatExcel.TabIndex = 3;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColMSSV, ColTen, ColDiem, ColTimeVaoThi, ColTimeNopBai, ColHanhDong });
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(126, 164, 241);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(44, 118);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1211, 639);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ColMSSV
            // 
            ColMSSV.HeaderText = "MSSV";
            ColMSSV.Name = "ColMSSV";
            // 
            // ColTen
            // 
            ColTen.HeaderText = "Tên";
            ColTen.Name = "ColTen";
            // 
            // ColDiem
            // 
            ColDiem.HeaderText = "Điểm";
            ColDiem.Name = "ColDiem";
            // 
            // ColTimeVaoThi
            // 
            ColTimeVaoThi.HeaderText = "Thời gian vào thi";
            ColTimeVaoThi.Name = "ColTimeVaoThi";
            // 
            // ColTimeNopBai
            // 
            ColTimeNopBai.HeaderText = "Thời gian nộp bài";
            ColTimeNopBai.Name = "ColTimeNopBai";
            // 
            // ColHanhDong
            // 
            ColHanhDong.HeaderText = "Hành động";
            ColHanhDong.Name = "ColHanhDong";
            ColHanhDong.Width = 150;
            // 
            // XemChiTietDeThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(btnXuatExcel);
            Controls.Add(textBoxTimKiem);
            Controls.Add(comboBoxTrangThaiNop);
            Controls.Add(comboBoxTatCa);
            Name = "XemChiTietDeThi";
            Size = new Size(1300, 800);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private ComboBox comboBoxTatCa;
        private ComboBox comboBoxTrangThaiNop;
        private TextBox textBoxTimKiem;
        private Button btnXuatExcel;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColMSSV;
        private DataGridViewTextBoxColumn ColTen;
        private DataGridViewTextBoxColumn ColDiem;
        private DataGridViewTextBoxColumn ColTimeVaoThi;
        private DataGridViewTextBoxColumn ColTimeNopBai;
        private DataGridViewTextBoxColumn ColHanhDong;
    }
}
