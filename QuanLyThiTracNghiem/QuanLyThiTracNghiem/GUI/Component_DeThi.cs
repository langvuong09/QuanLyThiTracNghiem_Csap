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
    public partial class Component_DeThi : UserControl
    {
        public Component_DeThi()
        {
            InitializeComponent();
        }

        private void Component_DeThi_Load(object sender, EventArgs e)
        {
            //FLOWLAYOUTPANEL_MAIN
            flowLayoutPanel_Main.Dock = DockStyle.Fill;
            flowLayoutPanel_Main.AutoScroll = true;
            flowLayoutPanel_Main.WrapContents = false;
            flowLayoutPanel_Main.FlowDirection = FlowDirection.TopDown;
        }
    }
}
