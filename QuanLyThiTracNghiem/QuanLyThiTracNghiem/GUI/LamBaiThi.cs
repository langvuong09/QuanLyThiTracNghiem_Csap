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
    public partial class LamBaiThi : Form
    {


        public LamBaiThi()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            // 1) Đặt form nằm giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
            // 2) Không cho resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //PANEL TOP
            panel_Top.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");

            //PANEL BOTTOM
            panel_Bottom.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");

            // FLOWLAYOUTPANEL_CAUHOI cấu hình hiển thị danh sách Item đề thi
            flowLayoutPanel_CauHoi.AutoScroll = true;
            flowLayoutPanel_CauHoi.WrapContents = false;
            flowLayoutPanel_CauHoi.FlowDirection = FlowDirection.TopDown;

            for (int i = 0; i < 20; i++)
            {
                flowLayoutPanel_CauHoi.Controls.Add(new Panel_ItemCauHoi());
            }


        }

        private void LamBaiThi_Load(object sender, EventArgs e)
        {
        }

        // Event khi nhấn nút Trở về
        public event EventHandler TroVeClicked;
        private void button_Thoat_Click(object sender, EventArgs e)
        {
            TroVeClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
