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
    public partial class Panel_ItemDeThi : UserControl
    {
        public Panel_ItemDeThi()
        {
            InitializeComponent();
        }
        // Khai báo event (callback)
        public event EventHandler XemChiTietClicked;


        private void button_XemChiTiet_Click(object sender, EventArgs e)
        {
            // Gọi event khi người dùng click
            XemChiTietClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
