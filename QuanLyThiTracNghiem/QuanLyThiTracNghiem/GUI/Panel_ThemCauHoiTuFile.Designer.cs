namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Panel_ThemCauHoiTuFile
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
            label_MonHoc = new Label();
            label_DoKho = new Label();
            label_Chuong = new Label();
            label_message = new Label();
            panel_Left = new Panel();
            comboBox_DoKho = new ComboBox();
            comboBox_Chuong = new ComboBox();
            comboBox_MonHoc = new ComboBox();
            button_MauFileGoc = new Button();
            button_Luu = new Button();
            panel_Left.SuspendLayout();
            SuspendLayout();
            // 
            // label_MonHoc
            // 
            label_MonHoc.AutoSize = true;
            label_MonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_MonHoc.Location = new Point(26, 51);
            label_MonHoc.Name = "label_MonHoc";
            label_MonHoc.Size = new Size(110, 30);
            label_MonHoc.TabIndex = 0;
            label_MonHoc.Text = "Môn Học:";
            // 
            // label_DoKho
            // 
            label_DoKho.AutoSize = true;
            label_DoKho.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_DoKho.Location = new Point(26, 166);
            label_DoKho.Name = "label_DoKho";
            label_DoKho.Size = new Size(93, 30);
            label_DoKho.TabIndex = 1;
            label_DoKho.Text = "Độ Khó:";
            // 
            // label_Chuong
            // 
            label_Chuong.AutoSize = true;
            label_Chuong.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Chuong.Location = new Point(26, 109);
            label_Chuong.Name = "label_Chuong";
            label_Chuong.Size = new Size(98, 30);
            label_Chuong.TabIndex = 2;
            label_Chuong.Text = "Chương:";
            // 
            // label_message
            // 
            label_message.AutoSize = true;
            label_message.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_message.Location = new Point(743, 48);
            label_message.Name = "label_message";
            label_message.Size = new Size(404, 30);
            label_message.TabIndex = 4;
            label_message.Text = "Vui lòng soạn thảo theo mẫu dưới đây :";
            // 
            // panel_Left
            // 
            panel_Left.BorderStyle = BorderStyle.FixedSingle;
            panel_Left.Controls.Add(comboBox_DoKho);
            panel_Left.Controls.Add(comboBox_Chuong);
            panel_Left.Controls.Add(comboBox_MonHoc);
            panel_Left.Controls.Add(label_MonHoc);
            panel_Left.Controls.Add(label_Chuong);
            panel_Left.Controls.Add(label_DoKho);
            panel_Left.Dock = DockStyle.Left;
            panel_Left.Location = new Point(0, 0);
            panel_Left.Name = "panel_Left";
            panel_Left.Size = new Size(738, 700);
            panel_Left.TabIndex = 5;
            // 
            // comboBox_DoKho
            // 
            comboBox_DoKho.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_DoKho.FormattingEnabled = true;
            comboBox_DoKho.Location = new Point(155, 158);
            comboBox_DoKho.Name = "comboBox_DoKho";
            comboBox_DoKho.Size = new Size(559, 38);
            comboBox_DoKho.TabIndex = 5;
            // 
            // comboBox_Chuong
            // 
            comboBox_Chuong.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Chuong.FormattingEnabled = true;
            comboBox_Chuong.Location = new Point(155, 101);
            comboBox_Chuong.Name = "comboBox_Chuong";
            comboBox_Chuong.Size = new Size(559, 38);
            comboBox_Chuong.TabIndex = 4;
            // 
            // comboBox_MonHoc
            // 
            comboBox_MonHoc.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_MonHoc.FormattingEnabled = true;
            comboBox_MonHoc.Location = new Point(155, 43);
            comboBox_MonHoc.Name = "comboBox_MonHoc";
            comboBox_MonHoc.Size = new Size(559, 38);
            comboBox_MonHoc.TabIndex = 3;
            comboBox_MonHoc.SelectionChangeCommitted += comboBox_MonHoc_SelectionChangeCommitted;
            // 
            // button_MauFileGoc
            // 
            button_MauFileGoc.BackColor = Color.DarkSeaGreen;
            button_MauFileGoc.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_MauFileGoc.ForeColor = SystemColors.ButtonFace;
            button_MauFileGoc.Location = new Point(1153, 41);
            button_MauFileGoc.Name = "button_MauFileGoc";
            button_MauFileGoc.Size = new Size(123, 44);
            button_MauFileGoc.TabIndex = 8;
            button_MauFileGoc.Text = "File Mẫu";
            button_MauFileGoc.UseVisualStyleBackColor = false;
            button_MauFileGoc.Click += button_MauFileGoc_Click;
            // 
            // button_Luu
            // 
            button_Luu.BackColor = SystemColors.ActiveCaption;
            button_Luu.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Luu.ForeColor = SystemColors.ButtonFace;
            button_Luu.Location = new Point(744, 96);
            button_Luu.Name = "button_Luu";
            button_Luu.Size = new Size(713, 61);
            button_Luu.TabIndex = 9;
            button_Luu.Text = "CHỌN FILE ";
            button_Luu.UseVisualStyleBackColor = false;
            button_Luu.Click += button_Luu_Click;
            // 
            // Panel_ThemCauHoiTuFile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(button_Luu);
            Controls.Add(button_MauFileGoc);
            Controls.Add(panel_Left);
            Controls.Add(label_message);
            Name = "Panel_ThemCauHoiTuFile";
            Size = new Size(1480, 700);
            panel_Left.ResumeLayout(false);
            panel_Left.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_MonHoc;
        private Label label_DoKho;
        private Label label_Chuong;
        private Label label_message;
        private Panel panel_Left;
        private ComboBox comboBox_DoKho;
        private ComboBox comboBox_Chuong;
        private ComboBox comboBox_MonHoc;
        private Button button_MauFileGoc;
        private Button button_Luu;
    }
}
