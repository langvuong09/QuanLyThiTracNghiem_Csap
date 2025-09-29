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
    public partial class Dialog_BatDauLamBaiThi : UserControl
    {
        public Dialog_BatDauLamBaiThi()
        {
            InitializeComponent();
        }

        private void Dialog_BatDauLamBaiThi_Load(object sender, EventArgs e)
        {

        }

        // Event khi nhấn nút Làm Bài
        public event EventHandler LamBaiClicked;

        private void button_LamBaiThi_Click(object sender, EventArgs e)
        {
            LamBaiClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
