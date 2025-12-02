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
            pnThongBao = new Panel();
            lbxThongBao = new ListBox();
            btnReload = new Button();
            lblTitle = new Label();
            pnThongBao.SuspendLayout();
            SuspendLayout();
            // 
            // pnThongBao
            // 
            pnThongBao.BackColor = Color.FromArgb(215, 229, 255);
            pnThongBao.Controls.Add(lbxThongBao);
            pnThongBao.Location = new Point(43, 95);
            pnThongBao.Name = "pnThongBao";
            pnThongBao.Size = new Size(1451, 802);
            pnThongBao.TabIndex = 4;
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
            // btnReload
            // 
            btnReload.BackColor = Color.LightCoral;
            btnReload.BackgroundImage = (Image)resources.GetObject("btnReload.BackgroundImage");
            btnReload.BackgroundImageLayout = ImageLayout.Center;
            btnReload.Location = new Point(1149, 21);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(82, 68);
            btnReload.TabIndex = 8;
            btnReload.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(614, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(315, 65);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "THÔNG BÁO";
            // 
            // Component_ThongBao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblTitle);
            Controls.Add(btnReload);
            Controls.Add(pnThongBao);
            Name = "Component_ThongBao";
            Size = new Size(1541, 934);
            pnThongBao.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnThongBao;
        private ListBox lbxThongBao;
        private Button btnReload;
        private Label lblTitle;
    }
}
