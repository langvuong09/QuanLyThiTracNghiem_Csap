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
        private Panel pnDangChon = null;
        public Component_NhomHocPhan()
        {
            InitializeComponent();
            pnNhom.AutoScroll = true;
            AddEvents();
        }

        public void AddEvents()
        {
            btnTaoNhom.Click += btnTaoNhom_Click;
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

            ArrayList dsn = nhomBUS.GetListNhom();

            foreach (Nhom n in dsn)
            {
                Panel pnlItem = new Panel();
                pnlItem.Width = pnNhom.Width - 20;
                pnlItem.Height = 90;
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
                lblMonHoc.Location = new Point(5, 35);
                lblMonHoc.AutoSize = true;

                string tenGiangVien = giaoVienBUS.GetGiaoVienByID(n.maGiaoVien).tenGiaoVien;

                Label lblGiangVien = new Label();
                lblGiangVien.Text = $"Giảng viên: {tenGiangVien}";
                lblGiangVien.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblGiangVien.Location = new Point(5, 60);
                lblGiangVien.AutoSize = true;

                Label lblNamHoc = new Label();
                lblNamHoc.Text = $"Năm học: {n.namHoc}"+$"    Học kỳ: {n.hocKy}";
                lblNamHoc.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblNamHoc.Location = new Point(5, 85);
                lblNamHoc.AutoSize = true;
            }
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
    }
}
