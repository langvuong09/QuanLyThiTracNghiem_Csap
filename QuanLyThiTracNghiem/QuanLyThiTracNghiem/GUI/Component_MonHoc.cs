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
    public partial class Component_MonHoc : UserControl
    {
        private MonHocBUS monHocBUS = new MonHocBUS();
        public Component_MonHoc()
        {
            InitializeComponent();
            AddEvents();
        }
        private void AddEvents()
        {
            LoadDataLenTableMonHoc();
        }

        private void LoadDataLenTableMonHoc()
        {
            monHocBUS.DocListMonHoc();
            dgvMonHoc.Rows.Clear();
            ArrayList dsmh = monHocBUS.GetListMonHoc();
            foreach (MonHoc mh in dsmh)
            {
                dgvMonHoc.Rows.Add(
                    mh.maMonHoc,
                    mh.tenMonHoc,
                    mh.tinChi,
                    mh.soTietLyThuyet,
                    mh.soTietThucHanh,
                    mh.heSo
                    );
            }
        }

        public void btnThemChuong_Click(object sender, EventArgs e)
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
