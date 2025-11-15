namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_ThongBao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_ThongBao));
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnTaoThongBao = new Button();
            panel1 = new Panel();
            lbxThongBao = new ListBox();
            btnXem = new Button();
            button6 = new Button();
            btnReload = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 32.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(43, 27);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(727, 65);
            txtTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = SystemColors.ButtonHighlight;
            btnTimKiem.Location = new Point(798, 26);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(207, 68);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "TÌM KIẾM";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnTaoThongBao
            // 
            btnTaoThongBao.BackColor = SystemColors.ActiveCaption;
            btnTaoThongBao.BackgroundImage = (Image)resources.GetObject("btnTaoThongBao.BackgroundImage");
            btnTaoThongBao.BackgroundImageLayout = ImageLayout.None;
            btnTaoThongBao.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaoThongBao.Location = new Point(1142, 26);
            btnTaoThongBao.Name = "btnTaoThongBao";
            btnTaoThongBao.Size = new Size(352, 66);
            btnTaoThongBao.TabIndex = 3;
            btnTaoThongBao.Text = "     TẠO THÔNG BÁO";
            btnTaoThongBao.UseVisualStyleBackColor = false;
            btnTaoThongBao.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(215, 229, 255);
            panel1.Controls.Add(lbxThongBao);
            panel1.Location = new Point(43, 182);
            panel1.Name = "panel1";
            panel1.Size = new Size(1451, 715);
            panel1.TabIndex = 4;
            // 
            // lbxThongBao
            // 
            lbxThongBao.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbxThongBao.FormattingEnabled = true;
            lbxThongBao.ItemHeight = 30;
            lbxThongBao.Location = new Point(3, 3);
            lbxThongBao.Name = "lbxThongBao";
            lbxThongBao.Size = new Size(1445, 94);
            lbxThongBao.TabIndex = 0;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.LightBlue;
            btnXem.BackgroundImage = (Image)resources.GetObject("btnXem.BackgroundImage");
            btnXem.BackgroundImageLayout = ImageLayout.Center;
            btnXem.Location = new Point(46, 114);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(65, 54);
            btnXem.TabIndex = 5;
            btnXem.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.Location = new Point(191, 134);
            button6.Name = "button6";
            button6.Size = new Size(8, 8);
            button6.TabIndex = 7;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            btnReload.BackColor = Color.LightCoral;
            btnReload.BackgroundImage = (Image)resources.GetObject("btnReload.BackgroundImage");
            btnReload.BackgroundImageLayout = ImageLayout.Center;
            btnReload.Location = new Point(1031, 26);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(82, 68);
            btnReload.TabIndex = 8;
            btnReload.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Salmon;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.Location = new Point(158, 114);
            button1.Name = "button1";
            button1.Size = new Size(74, 54);
            button1.TabIndex = 9;
            button1.UseVisualStyleBackColor = false;
            // 
            // Component_ThongBao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button1);
            Controls.Add(btnReload);
            Controls.Add(button6);
            Controls.Add(btnXem);
            Controls.Add(panel1);
            Controls.Add(btnTaoThongBao);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Name = "Component_ThongBao";
            Size = new Size(1541, 934);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTimKiem;
        private Button btnTaoThongBao;
        private Panel panel1;
        private ListBox lbxThongBao;
        private Button btnXem;
        private Button button6;
        public Button btnTimKiem;
        private Button btnReload;
        private Button button1;
    }
}
