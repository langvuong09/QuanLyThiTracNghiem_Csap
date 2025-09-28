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
        }

        private void thêmTừFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themCauHoiTuFile.BringToFront();
        }
    }
}
