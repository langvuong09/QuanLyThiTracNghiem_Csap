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

        private NhomQuyenBUS rolebus = new NhomQuyenBUS();
        private ChucNangBUS molbus = new ChucNangBUS();
        public Component_PhanQuyen()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            ArrayList list = rolebus.GetListNhomQuyen();
            dgvNhomQuyen.DataSource = list;
        }

        private void btnTaoNhomQuyen_Click(object sender, EventArgs e)
        {
            txtTenNhomQuyen.Text = "";

            ArrayList list = molbus.GetListChucNang();
            dgvPopupChucNang.DataSource = list;
            pnlPopup.Visible = true;
            pnlPopup.BringToFront();
        }

        private void btnHuyPopup_Click(object sender, EventArgs e)
        {
            pnlPopup.Visible = false;
        }
    }
}
