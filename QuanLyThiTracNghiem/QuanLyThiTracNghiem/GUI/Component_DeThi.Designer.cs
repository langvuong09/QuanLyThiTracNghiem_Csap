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
            comboBox_LocDeThi = new ComboBox();
            textBox1 = new TextBox();
            button_Reload = new Button();
            panel_Top = new Panel();
            panel_Bottom = new Panel();
            comboBox1 = new ComboBox();
            button_Prev = new Button();
            button_Next = new Button();
            flowLayoutPanel_Main = new FlowLayoutPanel();
            panel_Top.SuspendLayout();
            panel_Bottom.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox_LocDeThi
            // 
            comboBox_LocDeThi.BackColor = SystemColors.InactiveCaption;
            comboBox_LocDeThi.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_LocDeThi.FormattingEnabled = true;
            comboBox_LocDeThi.Location = new Point(19, 25);
            comboBox_LocDeThi.Name = "comboBox_LocDeThi";
            comboBox_LocDeThi.Size = new Size(254, 40);
            comboBox_LocDeThi.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(297, 15);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1052, 50);
            textBox1.TabIndex = 1;
            // 
            // button_Reload
            // 
            button_Reload.BackColor = Color.Salmon;
            button_Reload.Image = (Image)resources.GetObject("button_Reload.Image");
            button_Reload.Location = new Point(1437, 12);
            button_Reload.Name = "button_Reload";
            button_Reload.Size = new Size(88, 55);
            button_Reload.TabIndex = 2;
            button_Reload.UseVisualStyleBackColor = false;
            // 
            // panel_Top
            // 
            panel_Top.Controls.Add(comboBox_LocDeThi);
            panel_Top.Controls.Add(button_Reload);
            panel_Top.Controls.Add(textBox1);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(1541, 71);
            panel_Top.TabIndex = 3;
            // 
            // panel_Bottom
            // 
            panel_Bottom.Controls.Add(comboBox1);
            panel_Bottom.Controls.Add(button_Prev);
            panel_Bottom.Controls.Add(button_Next);
            panel_Bottom.Dock = DockStyle.Bottom;
            panel_Bottom.Location = new Point(0, 866);
            panel_Bottom.Name = "panel_Bottom";
            panel_Bottom.Size = new Size(1541, 68);
            panel_Bottom.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1342, 11);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(60, 33);
            comboBox1.TabIndex = 2;
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
            // 
            // button_Next
            // 
            button_Next.BackColor = SystemColors.ActiveCaption;
            button_Next.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Next.ForeColor = SystemColors.ButtonFace;
            button_Next.Location = new Point(1435, 6);
            button_Next.Name = "button_Next";
            button_Next.Size = new Size(90, 40);
            button_Next.TabIndex = 0;
            button_Next.Text = "Next";
            button_Next.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel_Main
            // 
            flowLayoutPanel_Main.Dock = DockStyle.Fill;
            flowLayoutPanel_Main.Location = new Point(0, 71);
            flowLayoutPanel_Main.Name = "flowLayoutPanel_Main";
            flowLayoutPanel_Main.Size = new Size(1541, 795);
            flowLayoutPanel_Main.TabIndex = 5;
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

        private ComboBox comboBox_LocDeThi;
        private TextBox textBox1;
        private Button button_Reload;
        private Panel panel_Top;
        private Panel panel_Bottom;
        private ComboBox comboBox1;
        private Button button_Prev;
        private Button button_Next;
        private FlowLayoutPanel flowLayoutPanel_Main;
    }
}
