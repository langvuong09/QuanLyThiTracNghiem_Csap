namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Dialog_ThemCauHoi
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
            menuStrip_Top = new MenuStrip();
            thêmThủCôngToolStripMenuItem = new ToolStripMenuItem();
            thêmTừFileToolStripMenuItem = new ToolStripMenuItem();
            panel_Main = new Panel();
            menuStrip_Top.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip_Top
            // 
            menuStrip_Top.BackColor = SystemColors.ActiveCaption;
            menuStrip_Top.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip_Top.Items.AddRange(new ToolStripItem[] { thêmThủCôngToolStripMenuItem, thêmTừFileToolStripMenuItem });
            menuStrip_Top.Location = new Point(0, 0);
            menuStrip_Top.Name = "menuStrip_Top";
            menuStrip_Top.Size = new Size(1480, 40);
            menuStrip_Top.TabIndex = 0;
            menuStrip_Top.Text = "menuStrip1";
            // 
            // thêmThủCôngToolStripMenuItem
            // 
            thêmThủCôngToolStripMenuItem.Name = "thêmThủCôngToolStripMenuItem";
            thêmThủCôngToolStripMenuItem.Size = new Size(206, 36);
            thêmThủCôngToolStripMenuItem.Text = "Thêm Thủ Công";
            thêmThủCôngToolStripMenuItem.Click += thêmThủCôngToolStripMenuItem_Click;
            // 
            // thêmTừFileToolStripMenuItem
            // 
            thêmTừFileToolStripMenuItem.Name = "thêmTừFileToolStripMenuItem";
            thêmTừFileToolStripMenuItem.Size = new Size(172, 36);
            thêmTừFileToolStripMenuItem.Text = "Thêm Từ File";
            thêmTừFileToolStripMenuItem.Click += thêmTừFileToolStripMenuItem_Click;
            // 
            // panel_Main
            // 
            panel_Main.Dock = DockStyle.Fill;
            panel_Main.Location = new Point(0, 40);
            panel_Main.Name = "panel_Main";
            panel_Main.Size = new Size(1480, 710);
            panel_Main.TabIndex = 1;
            // 
            // Dialog_ThemCauHoi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel_Main);
            Controls.Add(menuStrip_Top);
            Name = "Dialog_ThemCauHoi";
            Size = new Size(1480, 750);
            menuStrip_Top.ResumeLayout(false);
            menuStrip_Top.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip_Top;
        private ToolStripMenuItem thêmThủCôngToolStripMenuItem;
        private ToolStripMenuItem thêmTừFileToolStripMenuItem;
        private Panel panel_Main;
    }
}
