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
    public partial class Component_HocPhan : UserControl
    {
        NhomBUS nhomBUS = new NhomBUS();
        NhomThamGiaBUS nhomThamGiaBUS = new NhomThamGiaBUS();
        MonHocBUS monHocBUS = new MonHocBUS();
        GiaoVienBUS giaoVienBUS = new GiaoVienBUS();
        private Panel pnDangChon = null;
        public Component_HocPhan()
        {
            InitializeComponent();
            pnNhom.AutoScroll = true;
            AddEvents();
        }

        private void AddEvents()
        {
            LoadDataLenTableNhom(UserSession.userId);
            btnReload.Click += btnReload_Click;
            btnXem.Click += btnXem_Click;
            btnTimKiem.Click += btnTimKiem_Click;
        }

        public void LoadDataLenTableNhom(string maSinhVien)
        {
            pnNhom.Controls.Clear();
            nhomBUS.DocListNhom();
            monHocBUS.DocListMonHoc();
            giaoVienBUS.DocListGiaoVien();
            nhomThamGiaBUS.DocListNhomThamGiaOfMaSV(maSinhVien);
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.AutoScroll = true;
            flow.Padding = new Padding(0);

            ArrayList dsn = nhomBUS.GetListNhom();
            ArrayList dsntg = nhomThamGiaBUS.GetListNhomThamGiaOfMaSV(maSinhVien);

            foreach (NhomThamGia ntg in dsntg)
            {
                foreach (Nhom n in dsn)
                {
                    if (ntg.maNhom == n.maNhom)
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
                        break;
                    }
                }
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

        public void btnReload_Click(object sender, EventArgs e)
        {
            LoadDataLenTableNhom(UserSession.userId);
        }

        private void btnXem_Click(object sender, EventArgs e)
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

            Form dlgXemNhom = new Form();
            dlgXemNhom.Text = "Xem nhóm";
            dlgXemNhom.StartPosition = FormStartPosition.CenterScreen;
            dlgXemNhom.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlgXemNhom.MaximizeBox = false;
            dlgXemNhom.MinimizeBox = false;

            string text = lblTieuDe.Text;
            string maNhom = text.Substring(text.IndexOf(":") + 1).Trim();

            Dialog_XemThongTinHocPhan xemNhom = new Dialog_XemThongTinHocPhan(maNhom);
            xemNhom.Dock = DockStyle.Fill;

            dlgXemNhom.ClientSize = xemNhom.Size;
            dlgXemNhom.Controls.Add(xemNhom);
            dlgXemNhom.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MyDialog dlg = new MyDialog("Chưa nhập tên môn cần tìm!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
            LoadDataLenTableNhomTheoMonHoc(txtTimKiem.Text);
        }

        public void LoadDataLenTableNhomTheoMonHoc(string tenMonHoc)
        {
            pnNhom.Controls.Clear();
            nhomBUS.DocListNhom();
            nhomThamGiaBUS.DocListNhomThamGiaOfMaSV(UserSession.userId);
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.AutoScroll = true;
            flow.Padding = new Padding(0);


            ArrayList dsn = nhomBUS.GetListNhomTheoMonHoc(tenMonHoc);
            ArrayList dsntg = nhomThamGiaBUS.GetListNhomThamGiaOfMaSV(UserSession.userId);

            foreach (NhomThamGia ntg in dsntg)
            {
                foreach (Nhom n in dsn)
                {
                    if (ntg.maNhom == n.maNhom)
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
                        break;
                    }
                }
            }
            pnNhom.Controls.Add(flow);
        }
    }
}
