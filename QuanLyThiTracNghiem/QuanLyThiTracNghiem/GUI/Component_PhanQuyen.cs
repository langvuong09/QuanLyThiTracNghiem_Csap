using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
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
    public partial class Component_PhanQuyen : UserControl
    {
        private Panel pnlPopup;
        private TextBox txtTenNhomQuyen;
        private Button btnSave;
        private Button btnCancel;
        private NhomQuyenBUS bus = new NhomQuyenBUS();
        public Component_PhanQuyen()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            ArrayList list = bus.GetListNhomQuyen();
            dgvNhomQuyen.DataSource = list;
        }

        private void btnTaoNhomQuyen_Click(object sender, EventArgs e)
        {

        }
    }
}
