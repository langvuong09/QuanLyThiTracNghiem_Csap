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
    public partial class Component_MonHocNguoiDung : UserControl
    {
        private MonHocBUS monHocBUS = new MonHocBUS();
        private ChuongBUS chuongBUS = new ChuongBUS();
        public Component_MonHocNguoiDung()
        {
            InitializeComponent();
            AddEvents();
        }

        private void AddEvents()
        {
            LoadDataLenTableMonHoc();
            dgvMonHoc.CellClick += new DataGridViewCellEventHandler(dgvMonHoc_CellClick);
            txtTimKiem.TextChanged += XuLyTimKiem;
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

        private void LoadDataLenTableChuong(string maMonHoc)
        {
            dgvChuong.Rows.Clear();
            List<Chuong> dsc = chuongBUS.GetChuongByMonHoc(maMonHoc);
            foreach (Chuong c in dsc)
            {
                dgvChuong.Rows.Add(
                    c.maChuong,
                    c.tenChuong
                    );
            }
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                XuLyClickDgvMonHoc();
            }
        }

        private void XuLyClickDgvMonHoc()
        {
            int row = dgvMonHoc.CurrentCell.RowIndex;
            if (row >= 0)
            {
                string maMonHoc = dgvMonHoc.Rows[row].Cells[0].Value?.ToString();

                LoadDataLenTableChuong(maMonHoc);
            }
        }
        private void XuLyTimKiem(object sender, EventArgs e)
        {
            dgvMonHoc.Rows.Clear();
            foreach (MonHoc mh in monHocBUS.GetListDSMonHoc(txtTimKiem.Text))
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
        
        private void HienThiLoGo()
        {
            pnHinhAnh.BackgroundImage = Image.FromFile(@"E:\Path\To\SGU-LOGO.png");
            pnHinhAnh.BackgroundImageLayout = ImageLayout.Zoom; // co ảnh cho đẹp

        }
    }
}
