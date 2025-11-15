namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_ThongBaoAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_ThongBaoAdmin));
            btnXoa = new Button();
            btnReload = new Button();
            button6 = new Button();
            btnXem = new Button();
            pnThongBao = new Panel();
            btnTaoThongBao = new Button();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            SuspendLayout();
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Salmon;
            btnXoa.BackgroundImage = (Image)resources.GetObject("btnXoa.BackgroundImage");
            btnXoa.BackgroundImageLayout = ImageLayout.Center;
            btnXoa.Location = new Point(160, 120);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(74, 54);
            btnXoa.TabIndex = 17;
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnReload
            // 
            btnReload.BackColor = Color.LightCoral;
            btnReload.BackgroundImage = (Image)resources.GetObject("btnReload.BackgroundImage");
            btnReload.BackgroundImageLayout = ImageLayout.Center;
            btnReload.Location = new Point(1033, 32);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(82, 68);
            btnReload.TabIndex = 16;
            btnReload.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.Location = new Point(193, 140);
            button6.Name = "button6";
            button6.Size = new Size(8, 8);
            button6.TabIndex = 15;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.LightBlue;
            btnXem.BackgroundImage = (Image)resources.GetObject("btnXem.BackgroundImage");
            btnXem.BackgroundImageLayout = ImageLayout.Center;
            btnXem.Location = new Point(48, 120);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(65, 54);
            btnXem.TabIndex = 14;
            btnXem.UseVisualStyleBackColor = false;
            // 
            // pnThongBao
            // 
            pnThongBao.BackColor = Color.FromArgb(215, 229, 255);
            pnThongBao.Location = new Point(45, 188);
            pnThongBao.Name = "pnThongBao";
            pnThongBao.Size = new Size(1451, 715);
            pnThongBao.TabIndex = 13;
            // 
            // btnTaoThongBao
            // 
            btnTaoThongBao.BackColor = SystemColors.ActiveCaption;
            btnTaoThongBao.BackgroundImage = (Image)resources.GetObject("btnTaoThongBao.BackgroundImage");
            btnTaoThongBao.BackgroundImageLayout = ImageLayout.None;
            btnTaoThongBao.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaoThongBao.Location = new Point(1144, 32);
            btnTaoThongBao.Name = "btnTaoThongBao";
            btnTaoThongBao.Size = new Size(352, 66);
            btnTaoThongBao.TabIndex = 12;
            btnTaoThongBao.Text = "     TẠO THÔNG BÁO";
            btnTaoThongBao.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = SystemColors.ButtonHighlight;
            btnTimKiem.Location = new Point(800, 32);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(207, 68);
            btnTimKiem.TabIndex = 11;
            btnTimKiem.Text = "TÌM KIẾM";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 32.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(45, 33);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(727, 65);
            txtTimKiem.TabIndex = 10;
            // 
            // Component_ThongBaoAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnXoa);
            Controls.Add(btnReload);
            Controls.Add(button6);
            Controls.Add(btnXem);
            Controls.Add(pnThongBao);
            Controls.Add(btnTaoThongBao);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Name = "Component_ThongBaoAdmin";
            Size = new Size(1541, 934);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnXoa;
        private Button btnReload;
        private Button button6;
        private Button btnXem;
        private Panel pnThongBao;
        private Button btnTaoThongBao;
        public Button btnTimKiem;
        private TextBox txtTimKiem;
    }
}
