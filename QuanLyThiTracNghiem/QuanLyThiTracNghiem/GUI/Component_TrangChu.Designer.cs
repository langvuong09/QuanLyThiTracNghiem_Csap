namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_TrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_TrangChu));
            pictureBox_TrangChu = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_TrangChu).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_TrangChu
            // 
            pictureBox_TrangChu.BackColor = SystemColors.ButtonHighlight;
            pictureBox_TrangChu.Image = (Image)resources.GetObject("pictureBox_TrangChu.Image");
            pictureBox_TrangChu.Location = new Point(185, 141);
            pictureBox_TrangChu.Name = "pictureBox_TrangChu";
            pictureBox_TrangChu.Size = new Size(1171, 652);
            pictureBox_TrangChu.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_TrangChu.TabIndex = 1;
            pictureBox_TrangChu.TabStop = false;
            pictureBox_TrangChu.Click += pictureBox_TrangChu_Click;
            // 
            // Component_TrangChu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(pictureBox_TrangChu);
            Name = "Component_TrangChu";
            Size = new Size(1541, 934);
            ((System.ComponentModel.ISupportInitialize)pictureBox_TrangChu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_TrangChu;
    }
}
