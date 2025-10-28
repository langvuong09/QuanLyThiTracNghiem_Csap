namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_DeThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_DeThi));
            textBox_TimKiem = new TextBox();
            button_Reload = new Button();
            panel_Top = new Panel();
            button_TimKiem = new Button();
            comboBox_LocTheoNhom = new ComboBox();
            panel_Bottom = new Panel();
            comboBox_PhanTrang = new ComboBox();
            button_Prev = new Button();
            button_Next = new Button();
            flowLayoutPanel_Main = new FlowLayoutPanel();
            panel_Top.SuspendLayout();
            panel_Bottom.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_TimKiem
            // 
            textBox_TimKiem.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_TimKiem.Location = new Point(19, 95);
            textBox_TimKiem.Multiline = true;
            textBox_TimKiem.Name = "textBox_TimKiem";
            textBox_TimKiem.Size = new Size(1230, 50);
            textBox_TimKiem.TabIndex = 1;
            // 
            // button_Reload
            // 
            button_Reload.AutoSize = true;
            button_Reload.BackColor = Color.Salmon;
            button_Reload.Image = (Image)resources.GetObject("button_Reload.Image");
            button_Reload.Location = new Point(1272, 16);
            button_Reload.Name = "button_Reload";
            button_Reload.Size = new Size(83, 73);
            button_Reload.TabIndex = 2;
            button_Reload.UseVisualStyleBackColor = false;
            button_Reload.Click += button_Reload_Click;
            // 
            // panel_Top
            // 
            panel_Top.Controls.Add(button_TimKiem);
            panel_Top.Controls.Add(comboBox_LocTheoNhom);
            panel_Top.Controls.Add(button_Reload);
            panel_Top.Controls.Add(textBox_TimKiem);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(1541, 162);
            panel_Top.TabIndex = 3;
            // 
            // button_TimKiem
            // 
            button_TimKiem.BackColor = SystemColors.ActiveCaption;
            button_TimKiem.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_TimKiem.ForeColor = SystemColors.ButtonFace;
            button_TimKiem.Image = (Image)resources.GetObject("button_TimKiem.Image");
            button_TimKiem.ImageAlign = ContentAlignment.MiddleLeft;
            button_TimKiem.Location = new Point(1272, 95);
            button_TimKiem.Name = "button_TimKiem";
            button_TimKiem.Size = new Size(251, 52);
            button_TimKiem.TabIndex = 4;
            button_TimKiem.Text = "Tìm Kiếm";
            button_TimKiem.UseVisualStyleBackColor = false;
            button_TimKiem.Click += button_TimKiem_Click;
            // 
            // comboBox_LocTheoNhom
            // 
            comboBox_LocTheoNhom.BackColor = SystemColors.InactiveCaption;
            comboBox_LocTheoNhom.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_LocTheoNhom.FormattingEnabled = true;
            comboBox_LocTheoNhom.Location = new Point(19, 36);
            comboBox_LocTheoNhom.Name = "comboBox_LocTheoNhom";
            comboBox_LocTheoNhom.Size = new Size(1230, 40);
            comboBox_LocTheoNhom.TabIndex = 3;
            comboBox_LocTheoNhom.SelectionChangeCommitted += comboBox_LocTheoNhom_SelectionChangeCommitted;
            // 
            // panel_Bottom
            // 
            panel_Bottom.Controls.Add(comboBox_PhanTrang);
            panel_Bottom.Controls.Add(button_Prev);
            panel_Bottom.Controls.Add(button_Next);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 866);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(1541, 68);
            panel_Bottom.TabIndex = 4;
            // 
            // comboBox_PhanTrang
            // 
            comboBox_PhanTrang.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox_PhanTrang.FormattingEnabled = true;
            comboBox_PhanTrang.Location = new Point(1342, 11);
            comboBox_PhanTrang.Name = "comboBox_PhanTrang";
            comboBox_PhanTrang.Size = new Size(60, 33);
            comboBox_PhanTrang.TabIndex = 2;
            comboBox_PhanTrang.SelectionChangeCommitted += comboBox_PhanTrang_SelectionChangeCommitted;
            // 
            // button_Prev
            // 
            button_Prev.BackColor = SystemColors.ActiveCaption;
            button_Prev.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Prev.ForeColor = SystemColors.ButtonFace;
            button_Prev.Location = new Point(1218, 6);
            button_Prev.Name = "button_Prev";
            button_Prev.Size = new Size(90, 40);
            button_Prev.TabIndex = 1;
            button_Prev.Text = "Prev";
            button_Prev.UseVisualStyleBackColor = false;
            button_Prev.Click += button_Prev_Click;
            // 
            // button_Next
            // 
            button_Next.BackColor = SystemColors.ActiveCaption;
            button_Next.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Next.ForeColor = SystemColors.ButtonFace;
            button_Next.Location = new Point(1433, 6);
            button_Next.Name = "button_Next";
            button_Next.Size = new Size(90, 40);
            button_Next.TabIndex = 0;
            button_Next.Text = "Next";
            button_Next.UseVisualStyleBackColor = false;
            button_Next.Click += button_Next_Click;
            // 
            // flowLayoutPanel_Main
            // 
            flowLayoutPanel_Main.AutoScroll = true;
            flowLayoutPanel_Main.Dock = DockStyle.Fill;
            flowLayoutPanel_Main.Location = new Point(0, 162);
            flowLayoutPanel_Main.Name = "flowLayoutPanel_Main";
            flowLayoutPanel_Main.Size = new Size(1541, 704);
            flowLayoutPanel_Main.TabIndex = 5;
            flowLayoutPanel_Main.WrapContents = false;
            // 
            // Component_DeThi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(flowLayoutPanel_Main);
            Controls.Add(panel_Bottom);
            Controls.Add(panel_Top);
            Name = "Component_DeThi";
            Size = new Size(1541, 934);
            Load += Component_DeThi_Load;
            panel_Top.ResumeLayout(false);
            panel_Top.PerformLayout();
            panel_Bottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox_TimKiem;
        private Button button_Reload;
        private Panel panel_Top;
        private Panel panel_Bottom;
        private ComboBox comboBox_PhanTrang;
        private Button button_Prev;
        private Button button_Next;
        private FlowLayoutPanel flowLayoutPanel_Main;
        private Button button_TimKiem;
        private ComboBox comboBox_LocTheoNhom;
    }
}
