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
    public partial class Component_MonHoc : UserControl
    {
        public Component_MonHoc()
        {
            InitializeComponent();
        }

        public void XuLyThemChuong(object sender, EventArgs e)
        {
            Form popup = new Form();
            popup.Text = "Thêm Chương";
            popup.StartPosition = FormStartPosition.CenterScreen;
            popup.FormBorderStyle = FormBorderStyle.FixedDialog;
            popup.MaximizeBox = false;
            popup.MinimizeBox = false;
            popup.Size = new Size(500, 350);

            Dialog_ThemChuong themChuong = new Dialog_ThemChuong();
            themChuong.Dock = DockStyle.Fill;

            popup.Controls.Add(themChuong);
            popup.ShowDialog(); // ✅ Hiển thị như cửa sổ modal
        }

    }
}
