namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_HocPhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_HocPhan));
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            btnReload = new Button();
            pnNhom = new Panel();
            btnXem = new Button();
            SuspendLayout();
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.ActiveCaption;
            btnTimKiem.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = SystemColors.ButtonHighlight;
            btnTimKiem.Location = new Point(959, 26);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(207, 68);
            btnTimKiem.TabIndex = 30;
            btnTimKiem.Text = "TÌM KIẾM";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 32.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(211, 29);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(727, 65);
            txtTimKiem.TabIndex = 29;
            // 
            // btnReload
            // 
            btnReload.BackColor = Color.LightCoral;
            btnReload.BackgroundImage = (Image)resources.GetObject("btnReload.BackgroundImage");
            btnReload.BackgroundImageLayout = ImageLayout.Center;
            btnReload.Location = new Point(1195, 26);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(82, 68);
            btnReload.TabIndex = 28;
            btnReload.UseVisualStyleBackColor = false;
            // 
            // pnNhom
            // 
            pnNhom.BackColor = Color.FromArgb(215, 229, 255);
            pnNhom.Location = new Point(43, 109);
            pnNhom.Name = "pnNhom";
            pnNhom.Size = new Size(1451, 822);
            pnNhom.TabIndex = 32;
            // 
            // btnXem
            // 
            btnXem.BackColor = Color.LightBlue;
            btnXem.BackgroundImage = (Image)resources.GetObject("btnXem.BackgroundImage");
            btnXem.BackgroundImageLayout = ImageLayout.Center;
            btnXem.Location = new Point(94, 33);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(65, 54);
            btnXem.TabIndex = 33;
            btnXem.UseVisualStyleBackColor = false;
            // 
            // Component_HocPhan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnXem);
            Controls.Add(pnNhom);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnReload);
            Name = "Component_HocPhan";
            Size = new Size(1541, 934);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button btnTimKiem;
        private TextBox txtTimKiem;
        private Button btnReload;
        private Panel pnNhom;
        private Button btnXem;
    }
}
