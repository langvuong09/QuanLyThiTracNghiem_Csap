namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_NhomHocPhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_NhomHocPhan));
            pnNhom = new Panel();
            btnXoa = new Button();
            btnXem = new Button();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            btnReload = new Button();
            btnTaoNhom = new Button();
            btnDSDeKiemTra = new Button();
            btnDSSV = new Button();
            SuspendLayout();
            // 
            // pnNhom
            // 
            pnNhom.BackColor = Color.FromArgb(215, 229, 255);
            pnNhom.Location = new Point(45, 197);
            pnNhom.Name = "pnNhom";
            pnNhom.Size = new Size(1451, 734);
            pnNhom.TabIndex = 31;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Salmon;
            btnXoa.BackgroundImage = (Image)resources.GetObject("btnXoa.BackgroundImage");
            btnXoa.BackgroundImageLayout = ImageLayout.Center;
            btnXoa.Location = new Point(133, 113);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(74, 54);
            btnXoa.TabIndex = 30;
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.LightBlue;
            btnXem.BackgroundImage = (Image)resources.GetObject("btnXem.BackgroundImage");
            btnXem.BackgroundImageLayout = ImageLayout.Center;
            btnXem.Location = new Point(45, 113);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(65, 54);
            btnXem.TabIndex = 28;
            btnXem.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = SystemColors.ButtonHighlight;
            btnTimKiem.Location = new Point(793, 22);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(207, 68);
            btnTimKiem.TabIndex = 27;
            btnTimKiem.Text = "TÌM KIẾM";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 32.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(45, 25);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(727, 65);
            txtTimKiem.TabIndex = 26;
            // 
            // btnReload
            // 
            btnReload.BackColor = Color.LightCoral;
            btnReload.BackgroundImage = (Image)resources.GetObject("btnReload.BackgroundImage");
            btnReload.BackgroundImageLayout = ImageLayout.Center;
            btnReload.Location = new Point(1029, 22);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(82, 68);
            btnReload.TabIndex = 25;
            btnReload.UseVisualStyleBackColor = false;
            // 
            // btnTaoNhom
            // 
            btnTaoNhom.BackColor = SystemColors.ActiveCaption;
            btnTaoNhom.BackgroundImage = (Image)resources.GetObject("btnTaoNhom.BackgroundImage");
            btnTaoNhom.BackgroundImageLayout = ImageLayout.None;
            btnTaoNhom.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaoNhom.Location = new Point(1144, 24);
            btnTaoNhom.Name = "btnTaoNhom";
            btnTaoNhom.Size = new Size(352, 66);
            btnTaoNhom.TabIndex = 24;
            btnTaoNhom.Text = "     TẠO NHÓM";
            btnTaoNhom.UseVisualStyleBackColor = false;
            // 
            // btnDSDeKiemTra
            // 
            btnDSDeKiemTra.BackColor = Color.DarkSlateGray;
            btnDSDeKiemTra.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDSDeKiemTra.ForeColor = SystemColors.ButtonHighlight;
            btnDSDeKiemTra.Location = new Point(511, 113);
            btnDSDeKiemTra.Name = "btnDSDeKiemTra";
            btnDSDeKiemTra.Size = new Size(261, 54);
            btnDSDeKiemTra.TabIndex = 32;
            btnDSDeKiemTra.Text = "Danh sách đề kiểm tra";
            btnDSDeKiemTra.UseVisualStyleBackColor = false;
            // 
            // btnDSSV
            // 
            btnDSSV.BackColor = Color.DarkSlateGray;
            btnDSSV.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDSSV.ForeColor = SystemColors.ButtonHighlight;
            btnDSSV.Location = new Point(235, 113);
            btnDSSV.Name = "btnDSSV";
            btnDSSV.Size = new Size(250, 54);
            btnDSSV.TabIndex = 33;
            btnDSSV.Text = "Danh sách sinh viên";
            btnDSSV.UseVisualStyleBackColor = false;
            // 
            // Component_NhomHocPhan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnDSSV);
            Controls.Add(btnDSDeKiemTra);
            Controls.Add(pnNhom);
            Controls.Add(btnXoa);
            Controls.Add(btnXem);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnReload);
            Controls.Add(btnTaoNhom);
            Name = "Component_NhomHocPhan";
            Size = new Size(1541, 934);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnNhom;
        private Button btnXoa;
        private Button btnXem;
        public Button btnTimKiem;
        private TextBox txtTimKiem;
        private Button btnReload;
        private Button btnTaoNhom;
        public Button btnDSDeKiemTra;
        public Button btnDSSV;
    }
}
