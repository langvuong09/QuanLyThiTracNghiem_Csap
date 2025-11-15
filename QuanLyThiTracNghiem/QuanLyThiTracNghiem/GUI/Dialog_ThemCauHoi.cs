using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Dialog_ThemCauHoi : UserControl
    {
        private Panel_ThemCauHoiThuCong themCauHoiThuCong = new Panel_ThemCauHoiThuCong();
        private Panel_ThemCauHoiTuFile themCauHoiTuFile = new Panel_ThemCauHoiTuFile();
        public Dialog_ThemCauHoi()
        {
            InitializeComponent();
            Custom_DialogThemCauHoi();
            themCauHoiThuCong.BringToFront();

        }

        private void Custom_DialogThemCauHoi()
        {
            //MENUSTRIP_TOP
            menuStrip_Top.AutoSize = false;
            menuStrip_Top.Height = 50;

            //PANEL_MAIN
            themCauHoiThuCong.Dock = DockStyle.Fill;
            themCauHoiTuFile.Dock = DockStyle.Fill;
            panel_Main.Controls.Add(themCauHoiThuCong);
            panel_Main.Controls.Add(themCauHoiTuFile);
        }

        private void thêmThủCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themCauHoiThuCong.BringToFront();
            HighlightMenuItem(thêmThủCôngToolStripMenuItem);
        }

        private void thêmTừFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themCauHoiTuFile.BringToFront();
            HighlightMenuItem(thêmTừFileToolStripMenuItem);
        }

        private void ResetMenuItemColor()
        {
            Color defaultColor = Color.White; // màu nền mặc định
            thêmThủCôngToolStripMenuItem.BackColor = defaultColor;
            thêmTừFileToolStripMenuItem.BackColor = defaultColor;
        }

        private void HighlightMenuItem(ToolStripMenuItem menuItem)
        {
            ResetMenuItemColor(); // reset tất cả về mặc định
            menuItem.BackColor = Color.LightBlue; // màu nổi bật
        }


    }
}
