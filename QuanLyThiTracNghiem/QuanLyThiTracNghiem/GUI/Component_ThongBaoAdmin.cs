using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

using System;
using System.Collections;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_ThongBaoAdmin : UserControl
    {
        private ThongBaoBUS thongBaoBUS = new ThongBaoBUS();
        private MonHocBUS monHocBUS = new MonHocBUS();
        private CTNhomQuyenBUS ctnhomQuyenBUS = new CTNhomQuyenBUS();
        private Panel pnDangChon = null;
        public Component_ThongBaoAdmin()
        {
            InitializeComponent();
            CheckPhanQuyen();
            pnThongBao.AutoScroll = true;
            AddEvents();
        }

        private void AddEvents()
        {
            LoadDataLenTableThongBao();
            btnTaoThongBao.Click += btnTaoThongBao_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnReload.Click += btnReload_Click;
            btnXoa.Click += btnXoa_Click;
            btnXem.Click += btnXem_Click;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (pnDangChon == null)
            {
                MyDialog dlg = new MyDialog("Chưa chọn thông báo để xóa!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }

            Label lblTieuDe = pnDangChon.Controls
                .OfType<Label>()
                .FirstOrDefault(lbl => lbl.Text.StartsWith("THÔNG BÁO: "));

            if (lblTieuDe != null)
            {
                string text = lblTieuDe.Text;
                string maThongBao = text.Substring(text.IndexOf(":") + 1).Trim();

                if (thongBaoBUS.XoaThongBao(maThongBao))
                {
                    thongBaoBUS.DocListThongBao();
                    LoadDataLenTableThongBao();
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            if(pnDangChon == null)
            {
                MyDialog dlg = new MyDialog("Chưa chọn thông báo để xem!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
            Label lblTieuDe = pnDangChon.Controls
                .OfType<Label>()
                .FirstOrDefault(lbl => lbl.Text.StartsWith("THÔNG BÁO: "));                

            Form dlgXemThongBao = new Form();
            dlgXemThongBao.Text = "Xem thông báo";
            dlgXemThongBao.StartPosition = FormStartPosition.CenterScreen;
            dlgXemThongBao.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlgXemThongBao.MaximizeBox = false;
            dlgXemThongBao.MinimizeBox = false;   

            string text = lblTieuDe.Text;
            string maThongBao = text.Substring(text.IndexOf(":") + 1).Trim();

            Dialog_XemThongBao xemThongBao = new Dialog_XemThongBao(maThongBao);
            xemThongBao.Dock = DockStyle.Fill;

            dlgXemThongBao.ClientSize = xemThongBao.Size;
            dlgXemThongBao.Controls.Add(xemThongBao);
            dlgXemThongBao.ShowDialog();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text == "")
            {
                MyDialog dlg = new MyDialog("Chưa nhập tên môn cần tìm!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
            LoadDataLenTableThongBao(txtTimKiem.Text);
        }
        private void btnTaoThongBao_Click(object sender, EventArgs e)
        {
            Form dlgTaoThongBao = new Form();
            dlgTaoThongBao.Text = "Tạo thông báo";
            dlgTaoThongBao.StartPosition = FormStartPosition.CenterScreen;
            dlgTaoThongBao.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlgTaoThongBao.MaximizeBox = false;
            dlgTaoThongBao.MinimizeBox = false;

            Dialog_TaoThongBao taoThongBao = new Dialog_TaoThongBao();
            taoThongBao.Dock = DockStyle.Fill;

            dlgTaoThongBao.ClientSize = taoThongBao.Size;
            dlgTaoThongBao.Controls.Add(taoThongBao);
            dlgTaoThongBao.ShowDialog();
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadDataLenTableThongBao();
            txtTimKiem.Text = "";
        }
        
        private void LoadDataLenTableThongBao()
        {
            pnThongBao.Controls.Clear();
            thongBaoBUS.DocListThongBao();
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.AutoScroll = true;
            flow.Padding = new Padding(0);

            ArrayList dstb = thongBaoBUS.GetListThongBao();

            foreach (ThongBao tb in dstb)
            {
                Panel pnlItem = new Panel();
                pnlItem.Width = pnThongBao.Width - 20;
                pnlItem.Height = 90;
                pnlItem.Margin = new Padding(0, 0, 0, 3);
                pnlItem.BorderStyle = BorderStyle.FixedSingle;
                pnlItem.BackColor = Color.LightGray;
                pnlItem.Tag = tb;

                // Gắn sự kiện click
                pnlItem.Click += PnlItem_Click;

                // Tiêu đề in đậm
                Label lblTieuDe = new Label();
                lblTieuDe.Text = $"THÔNG BÁO: {tb.maThongBao}";
                lblTieuDe.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblTieuDe.Location = new Point(5, 5);
                lblTieuDe.AutoSize = true;

                string monHoc = monHocBUS.GetMonHoc(tb.maMonHoc);

                Label lblGuiCho = new Label();
                lblGuiCho.Text = $"Gửi cho: {monHoc}";
                lblGuiCho.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblGuiCho.Location = new Point(5, 35);
                lblGuiCho.AutoSize = true;

                Label lblThoiGian = new Label();
                lblThoiGian.Text = $"Thời gian: {tb.thoiGian}";
                lblThoiGian.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblThoiGian.Location = new Point(5, 60);
                lblThoiGian.AutoSize = true;

                foreach (Control ctrl in new Control[] { lblTieuDe, lblGuiCho, lblThoiGian })
                {
                    ctrl.Click += (s, e) => pnlItem.BackColor = Color.LightBlue;
                }

                pnlItem.Controls.Add(lblTieuDe);
                pnlItem.Controls.Add(lblGuiCho);
                pnlItem.Controls.Add(lblThoiGian);

                flow.Controls.Add(pnlItem);
            }

            pnThongBao.Controls.Add(flow);
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

            ThongBao tb = clickedPanel.Tag as ThongBao;
            if (tb == null)
            {
                MyDialog dlg = new MyDialog("Error!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
        }

        private void LoadDataLenTableThongBao(string tenMonHoc)
        {
            pnThongBao.Controls.Clear();

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.AutoScroll = true;
            flow.Padding = new Padding(0);

            ArrayList dstb = thongBaoBUS.GetListDSThongBao(tenMonHoc);

            foreach (ThongBao tb in dstb)
            {
                Panel pnlItem = new Panel();
                pnlItem.Width = pnThongBao.Width - 20;
                pnlItem.Height = 90;
                pnlItem.Margin = new Padding(0, 0, 0, 3);
                pnlItem.BorderStyle = BorderStyle.FixedSingle;
                pnlItem.BackColor = Color.LightGray;

                // Tiêu đề in đậm
                Label lblTieuDe = new Label();
                lblTieuDe.Text = $"THÔNG BÁO: {tb.maThongBao}";
                lblTieuDe.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblTieuDe.Location = new Point(5, 5);
                lblTieuDe.AutoSize = true;

                string monHoc = monHocBUS.GetMonHoc(tb.maMonHoc);

                Label lblGuiCho = new Label();
                lblGuiCho.Text = $"Gửi cho: {monHoc}";
                lblGuiCho.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblGuiCho.Location = new Point(5, 35);
                lblGuiCho.AutoSize = true;

                Label lblThoiGian = new Label();
                lblThoiGian.Text = $"Thời gian: {tb.thoiGian}";
                lblThoiGian.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                lblThoiGian.Location = new Point(5, 60);
                lblThoiGian.AutoSize = true;

                pnlItem.Controls.Add(lblTieuDe);
                pnlItem.Controls.Add(lblGuiCho);
                pnlItem.Controls.Add(lblThoiGian);

                flow.Controls.Add(pnlItem);
            }

            pnThongBao.Controls.Add(flow);
        }

        private void CheckPhanQuyen()
        {
            ArrayList dspq = ctnhomQuyenBUS.GetListCTNhomQuyen(UserSession.Quyen);
            foreach (CTNhomQuyen pq in dspq)
            {
                if(pq.maChucNang == 10)
                {
                    if(pq.xem == 0)
                    {
                        btnXem.Visible = false;
                    }
                    if(pq.them == 0)
                    {
                        btnTaoThongBao.Visible = false;
                    }
                    if(pq.xoa == 0)
                    {
                        btnXoa.Visible = false;
                    }
                }
            }
        }
    }
}
