using QuanLyThiTracNghiem.MyCustom;
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
    public partial class Component_NhomHocPhan : UserControl
    {
        NhomBUS nhomBUS = new NhomBUS();
        MonHocBUS monHocBUS = new MonHocBUS();
        GiaoVienBUS giaoVienBUS = new GiaoVienBUS();
        NhomThamGiaBUS nhomThamGiaBUS = new NhomThamGiaBUS();
        CTNhomQuyenBUS ctNhomQuyenBUS = new CTNhomQuyenBUS();
        private Panel pnDangChon = null;
        public Component_NhomHocPhan()
        {
            InitializeComponent();
            CheckPhanQuyen();
            pnNhom.AutoScroll = true;
            AddEvents();
        }

        public void AddEvents()
        {
            LoadDataLenTableNhom();
            btnReload.Click += btnReload_Click;
            btnTaoNhom.Click += btnTaoNhom_Click;
            btnDSSV.Click += btnDanhSachSinhVien_Click;
            btnDSDeKiemTra.Click += btnDanhSachDeKiemTra_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnXem.Click += btnSuaNhom_Click;
            btnXoa.Click += btnXoa_Click;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadDataLenTableNhom();
            txtTimKiem.Text = "";
        }

        public void btnTaoNhom_Click(object sender, EventArgs e)
        {
            Form dlgTaoNhom = new Form();
            dlgTaoNhom.Text = "Tạo nhóm";
            dlgTaoNhom.StartPosition = FormStartPosition.CenterScreen;
            dlgTaoNhom.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlgTaoNhom.MaximizeBox = false;
            dlgTaoNhom.MinimizeBox = false;

            Dialog_ThemNhom themNhom = new Dialog_ThemNhom();
            themNhom.Dock = DockStyle.Fill;

            dlgTaoNhom.ClientSize = themNhom.Size;
            dlgTaoNhom.Controls.Add(themNhom);
            dlgTaoNhom.ShowDialog();
        }

        public void LoadDataLenTableNhom()
        {
            pnNhom.Controls.Clear();
            nhomBUS.DocListNhom();
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.AutoScroll = true;
            flow.Padding = new Padding(0);
            ArrayList dsn = null;
            if (UserSession.Quyen == 1)
            {
                dsn = nhomBUS.GetListNhom();
            }
            else
            {
                dsn = nhomBUS.GetListByAssignment(UserSession.userId);
            }
            if (dsn == null) {
                MyDialog dlg = new MyDialog("Không tìm thấy nhóm theo phân công!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
            foreach (Nhom n in dsn)
            {
                Panel pnlItem = new Panel();
                pnlItem.Width = pnNhom.Width - 20;
                pnlItem.Height = 155;
                pnlItem.Margin = new Padding(0, 0, 0, 3);
                pnlItem.BorderStyle = BorderStyle.FixedSingle;
                pnlItem.BackColor = Color.LightGray;
                pnlItem.Tag = n;

                // Gắn sự kiện click
                pnlItem.Click += PnlItem_Click;

                // Tiêu đề in đậm
                Label lblTieuDe = new Label();
                lblTieuDe.Text = $"NHÓM: {n.maNhom}";
                lblTieuDe.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblTieuDe.Location = new Point(5, 5);
                lblTieuDe.AutoSize = true;

                string monHoc = monHocBUS.GetMonHoc(n.maMonHoc);

                Label lblMonHoc = new Label();
                lblMonHoc.Text = $"MÔN HỌC: {monHoc}";
                lblMonHoc.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblMonHoc.Location = new Point(5, 40);
                lblMonHoc.AutoSize = true;

                string tenGiangVien = giaoVienBUS.GetGiaoVienByID(n.maGiaoVien).tenGiaoVien;

                Label lblGiangVien = new Label();
                lblGiangVien.Text = $"Giảng viên: {tenGiangVien}";
                lblGiangVien.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblGiangVien.Location = new Point(5, 75);
                lblGiangVien.AutoSize = true;

                Label lblNamHoc = new Label();
                lblNamHoc.Text = $"Năm học: {n.namHoc}" + $"    Học kỳ: {n.hocKy}";
                lblNamHoc.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblNamHoc.Location = new Point(5, 100);
                lblNamHoc.AutoSize = true;

                Label lblSoLuong = new Label();
                lblSoLuong.Text = $"Sỉ số: {nhomThamGiaBUS.MaxSVMoiNhom(n.maNhom)}";
                lblSoLuong.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblSoLuong.Location = new Point(5, 125);
                lblSoLuong.AutoSize = true;

                foreach (Control ctrl in new Control[] { lblTieuDe, lblMonHoc, lblGiangVien, lblNamHoc, lblSoLuong })
                {
                    ctrl.Click += (s, e) => pnlItem.BackColor = Color.LightBlue;
                }

                pnlItem.Controls.Add(lblTieuDe);
                pnlItem.Controls.Add(lblMonHoc);
                pnlItem.Controls.Add(lblGiangVien);
                pnlItem.Controls.Add(lblNamHoc);
                pnlItem.Controls.Add(lblSoLuong);

                flow.Controls.Add(pnlItem);
            }

            pnNhom.Controls.Add(flow);
        }

        private void PnlItem_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;

            if (pnDangChon != null)
            {
                pnDangChon.BackColor = Color.LightGray;
            }

            // Chọn panel mới
            clickedPanel.BackColor = Color.LightBlue;
            pnDangChon = clickedPanel;

            Nhom n = clickedPanel.Tag as Nhom;
            if (n == null)
            {
                MyDialog dlg = new MyDialog("Error!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
        }

        private void btnDanhSachSinhVien_Click(object sender, EventArgs e)
        {
            if (pnDangChon == null)
            {
                MyDialog dlg = new MyDialog("Chưa chọn nhóm để xem!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
            Label lblTieuDe = pnDangChon.Controls
                .OfType<Label>()
                .FirstOrDefault(lbl => lbl.Text.StartsWith("NHÓM: "));

            Form dlgDanhSachSinhVien = new Form();
            dlgDanhSachSinhVien.Text = "Danh sách sinh viên";
            dlgDanhSachSinhVien.StartPosition = FormStartPosition.CenterScreen;
            dlgDanhSachSinhVien.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlgDanhSachSinhVien.MaximizeBox = false;
            dlgDanhSachSinhVien.MinimizeBox = false;

            string text = lblTieuDe.Text;
            string maNhom = text.Substring(text.IndexOf(":") + 1).Trim();

            Dialog_XemDSSVNhom dssv = new Dialog_XemDSSVNhom(maNhom);
            dssv.Dock = DockStyle.Fill;

            dlgDanhSachSinhVien.ClientSize = dssv.Size;
            dlgDanhSachSinhVien.Controls.Add(dssv);
            dlgDanhSachSinhVien.ShowDialog();
        }

        private void btnDanhSachDeKiemTra_Click(object sender, EventArgs e)
        {
            if (pnDangChon == null)
            {
                MyDialog dlg = new MyDialog("Chưa chọn nhóm để xem!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
            Label lblTieuDe = pnDangChon.Controls
                .OfType<Label>()
                .FirstOrDefault(lbl => lbl.Text.StartsWith("NHÓM: "));

            Form dlgDanhSachDeKiemTra = new Form();
            dlgDanhSachDeKiemTra.Text = "Danh sách đề kiểm tra";
            dlgDanhSachDeKiemTra.StartPosition = FormStartPosition.CenterScreen;
            dlgDanhSachDeKiemTra.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlgDanhSachDeKiemTra.MaximizeBox = false;
            dlgDanhSachDeKiemTra.MinimizeBox = false;

            string text = lblTieuDe.Text;
            string maNhom = text.Substring(text.IndexOf(":") + 1).Trim();

            Dialog_XemDanhSachDeThi dsDeKiemTra = new Dialog_XemDanhSachDeThi(maNhom);
            dsDeKiemTra.Dock = DockStyle.Fill;

            dlgDanhSachDeKiemTra.ClientSize = dsDeKiemTra.Size;
            dlgDanhSachDeKiemTra.Controls.Add(dsDeKiemTra);
            dlgDanhSachDeKiemTra.ShowDialog();
        }

        private void btnSuaNhom_Click(object sender, EventArgs e)
        {
            if (pnDangChon == null)
            {
                MyDialog dlg = new MyDialog("Chưa chọn nhóm để xem!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
            Label lblTieuDe = pnDangChon.Controls
                .OfType<Label>()
                .FirstOrDefault(lbl => lbl.Text.StartsWith("NHÓM: "));

            Form dlgSuaNhom = new Form();
            dlgSuaNhom.Text = "Xem nhóm";
            dlgSuaNhom.StartPosition = FormStartPosition.CenterScreen;
            dlgSuaNhom.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlgSuaNhom.MaximizeBox = false;
            dlgSuaNhom.MinimizeBox = false;

            string text = lblTieuDe.Text;
            string maNhom = text.Substring(text.IndexOf(":") + 1).Trim();

            Dialog_SuaNhom xemNhom = new Dialog_SuaNhom(maNhom);
            xemNhom.Dock = DockStyle.Fill;

            dlgSuaNhom.ClientSize = xemNhom.Size;
            dlgSuaNhom.Controls.Add(xemNhom);
            dlgSuaNhom.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MyDialog dlg = new MyDialog("Chưa nhập tên môn cần tìm!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
            LoadDataLenTableNhom(txtTimKiem.Text);
        }

        public void LoadDataLenTableNhom(string tenMonHoc)
        {
            pnNhom.Controls.Clear();
            nhomBUS.DocListNhom();
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.AutoScroll = true;
            flow.Padding = new Padding(0);

            ArrayList dsn = nhomBUS.SearchListByAssignment(UserSession.Quyen, tenMonHoc);

            foreach (Nhom n in dsn)
            {
                Panel pnlItem = new Panel();
                pnlItem.Width = pnNhom.Width - 20;
                pnlItem.Height = 155;
                pnlItem.Margin = new Padding(0, 0, 0, 3);
                pnlItem.BorderStyle = BorderStyle.FixedSingle;
                pnlItem.BackColor = Color.LightGray;
                pnlItem.Tag = n;

                // Gắn sự kiện click
                pnlItem.Click += PnlItem_Click;

                // Tiêu đề in đậm
                Label lblTieuDe = new Label();
                lblTieuDe.Text = $"NHÓM: {n.maNhom}";
                lblTieuDe.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblTieuDe.Location = new Point(5, 5);
                lblTieuDe.AutoSize = true;

                string monHoc = monHocBUS.GetMonHoc(n.maMonHoc);

                Label lblMonHoc = new Label();
                lblMonHoc.Text = $"MÔN HỌC: {monHoc}";
                lblMonHoc.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblMonHoc.Location = new Point(5, 40);
                lblMonHoc.AutoSize = true;

                string tenGiangVien = giaoVienBUS.GetGiaoVienByID(n.maGiaoVien).tenGiaoVien;

                Label lblGiangVien = new Label();
                lblGiangVien.Text = $"Giảng viên: {tenGiangVien}";
                lblGiangVien.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblGiangVien.Location = new Point(5, 75);
                lblGiangVien.AutoSize = true;

                Label lblNamHoc = new Label();
                lblNamHoc.Text = $"Năm học: {n.namHoc}" + $"    Học kỳ: {n.hocKy}";
                lblNamHoc.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblNamHoc.Location = new Point(5, 100);
                lblNamHoc.AutoSize = true;

                Label lblSoLuong = new Label();
                lblSoLuong.Text = $"Sỉ số: {nhomThamGiaBUS.MaxSVMoiNhom(n.maNhom)}";
                lblSoLuong.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblSoLuong.Location = new Point(5, 125);
                lblSoLuong.AutoSize = true;

                foreach (Control ctrl in new Control[] { lblTieuDe, lblMonHoc, lblGiangVien, lblNamHoc, lblSoLuong })
                {
                    ctrl.Click += (s, e) => pnlItem.BackColor = Color.LightBlue;
                }

                pnlItem.Controls.Add(lblTieuDe);
                pnlItem.Controls.Add(lblMonHoc);
                pnlItem.Controls.Add(lblGiangVien);
                pnlItem.Controls.Add(lblNamHoc);
                pnlItem.Controls.Add(lblSoLuong);

                flow.Controls.Add(pnlItem);
            }

            pnNhom.Controls.Add(flow);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (pnDangChon == null)
            {
                MyDialog dlg = new MyDialog("Chưa chọn nhóm để xóa!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }

            Label lblTieuDe = pnDangChon.Controls
                .OfType<Label>()
                .FirstOrDefault(lbl => lbl.Text.StartsWith("NHÓM: "));

            if (lblTieuDe != null)
            {
                string text = lblTieuDe.Text;
                string maNhom = text.Substring(text.IndexOf(":") + 1).Trim();

                if (nhomBUS.XoaNhom(maNhom))
                {
                    nhomBUS.DocListNhom();
                    LoadDataLenTableNhom();
                    return;
                }
            }
            else
            {
                MyDialog dlg = new MyDialog("Error!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
        }

        private void CheckPhanQuyen()
        {
            ArrayList dspq = ctNhomQuyenBUS.GetListCTNhomQuyen(UserSession.Quyen);
            foreach (CTNhomQuyen pq in dspq)
            {
                if(pq.maChucNang == 8)
                {
                    if(pq.them == 0)
                    {
                        btnTaoNhom.Visible = false;
                    }
                    if(pq.xoa == 0)
                    {
                        btnXoa.Visible = false;
                    }
                    if(pq.xem == 0)
                    {
                        btnDSDeKiemTra.Visible = false;
                        btnDSSV.Visible = false;
                    }
                }
            }
        }
    }
}
