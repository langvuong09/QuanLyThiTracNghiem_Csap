using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

using System;
using System.Collections;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_MonHoc : UserControl
    {
        private MonHocBUS monHocBUS = new MonHocBUS();
        private ChuongBUS chuongBUS = new ChuongBUS();
        public Component_MonHoc()
        {
            InitializeComponent();            
            AddEvents();
        }
        private void AddEvents()
        {
            LoadDataLenTableMonHoc();
            dgvMonHoc.CellClick += new DataGridViewCellEventHandler(dgvMonHoc_CellClick);
            btnThemChuong.Click += btnThemChuong_Click;
            btnXoaChuong.Click += btnXoaChuong_Click;
            btnReset.Click += btnReset_Click;
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
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
            if(row >= 0)
            {
                string maMonHoc = dgvMonHoc.Rows[row].Cells[0].Value?.ToString();
                string tenMonHoc = dgvMonHoc.Rows[row].Cells[1].Value?.ToString();
                string tinChi = dgvMonHoc.Rows[row].Cells[2].Value?.ToString();
                string soTietLT= dgvMonHoc.Rows[row].Cells[3].Value?.ToString();
                string soTietTH = dgvMonHoc.Rows[row].Cells[4].Value?.ToString();
                string heSo = dgvMonHoc.Rows[row].Cells[5].Value?.ToString();

                txtMaMonHoc.Text = maMonHoc;
                txtTenMonHoc.Text = tenMonHoc;
                txtTinChi.Text = tinChi;
                txtSoTietLT.Text = soTietLT;
                txtSoTietTH.Text = soTietTH;
                txtHeSo.Text = heSo;

                LoadDataLenTableChuong(maMonHoc);
            }
        }

        public void btnThemChuong_Click(object sender, EventArgs e)
        {
            if (txtMaMonHoc.Text == "")
            {
                MyDialog dlg = new MyDialog("Chưa chọn môn học để thêm chương!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
            Form popup = new Form();
            popup.Text = "Thêm Chương";
            popup.StartPosition = FormStartPosition.CenterScreen;
            popup.FormBorderStyle = FormBorderStyle.FixedDialog;
            popup.MaximizeBox = false;
            popup.MinimizeBox = false;
            popup.Size = new Size(500, 400);

            Dialog_ThemChuong themChuong = new Dialog_ThemChuong();
            themChuong.Dock = DockStyle.Fill;
            themChuong.MaMonHoc = txtMaMonHoc.Text;

            popup.Controls.Add(themChuong);
            popup.ShowDialog();
            LoadDataLenTableChuong(txtMaMonHoc.Text);
        }

        public void btnXoaChuong_Click(object sender, EventArgs e)
        {
            if (dgvChuong.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvChuong.SelectedRows[0];

                string maChuong = dgvChuong.SelectedRows[0].Cells[0].Value.ToString();

                if (chuongBUS.XoaChuong(maChuong, txtMaMonHoc.Text))
                {
                    MyDialog dlg = new MyDialog("Xóa chương thành công!", MyDialog.SUCCESS_DIALOG);
                    dlg.ShowDialog();
                    LoadDataLenTableChuong(txtMaMonHoc.Text);
                    return;
                }
            }
            else
            {
                MyDialog dlg = new MyDialog("Chưa chọn chương để xóa!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
        }

        public void btnReset_Click(object sender, EventArgs e)
        {
            txtMaMonHoc.Text = "";
            txtTenMonHoc.Text = "";
            txtTinChi.Text = "";
            txtSoTietLT.Text = "";
            txtSoTietTH.Text = "";
            txtHeSo.Text = "";
            dgvChuong.Rows.Clear();
            LoadDataLenTableMonHoc();
        }

        public void btnThem_Click(object sender, EventArgs e)
        {
            ArrayList dsmh = monHocBUS.GetListMonHoc();
            foreach (MonHoc mh in dsmh)
            {
                if(mh.maMonHoc == txtMaMonHoc.Text)
                {
                    MyDialog dlg = new MyDialog("Môn học đã tồn tại!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return;
                }
            }
            bool flag = monHocBUS.ThemMonHoc(txtTenMonHoc.Text,txtTinChi.Text,txtSoTietLT.Text,txtSoTietTH.Text,txtHeSo.Text);
            if (flag)
            {
                LoadDataLenTableMonHoc();
                btnReset_Click(sender, e);
                return;
            }
            else
            {
                MyDialog dlg = new MyDialog("Lỗi!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
        }

        public void btnXoa_Click(object sender, EventArgs e)
        {
            bool flag = monHocBUS.XoaMonHoc(txtMaMonHoc.Text);
            bool flag1 = chuongBUS.XoaChuongTheoMonHoc(txtMaMonHoc.Text);
            if (flag && flag1)
            {
                LoadDataLenTableMonHoc();
                btnReset_Click(sender, e);
                return;
            }
            else
            {
                MyDialog dlg = new MyDialog("Lỗi!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
        }

        public void btnSua_Click(object sender, EventArgs e)
        {
            bool flag = monHocBUS.SuaMonHoc(txtMaMonHoc.Text, txtTenMonHoc.Text, txtTinChi.Text, txtSoTietLT.Text, txtSoTietTH.Text, txtHeSo.Text);
            if (flag)
            {
                LoadDataLenTableMonHoc();
                btnReset_Click(sender,e);
                return;
            }
            else
            {
                MyDialog dlg = new MyDialog("Lỗi!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
        }

        public void XuLyTimKiem(object sender, EventArgs e)
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
    }
}
