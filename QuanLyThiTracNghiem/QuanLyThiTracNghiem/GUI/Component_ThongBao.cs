using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;

using System;
using System.Collections;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using QuanLyThiTracNghiem.MyCustom;
namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{   
    public partial class Component_ThongBao : UserControl
    {
        ThongBaoBUS thongBaoBUS = new ThongBaoBUS();
        ThongBao_NhomBUS thongBao_NhomBUS = new ThongBao_NhomBUS();
        MonHocBUS monHocBUS = new MonHocBUS();
        NhomBUS nhomBUS = new NhomBUS();
        NhomThamGiaBUS nhomThamGiaBUS = new NhomThamGiaBUS();
        private Panel pnDangChon = null;
        public Component_ThongBao()
        {
            InitializeComponent();
            AddEvents();
        }

        private void AddEvents()
        {
            LoadDataLenTableThongBao(UserSession.userId);
            btnReload.Click += btnReload_Click;
        }

        public void btnReload_Click(object sender, EventArgs e)
        {
            LoadDataLenTableThongBao(UserSession.userId);
        }
        

        public void LoadDataLenTableThongBao(string maSinhVien)
        {
            pnThongBao.Controls.Clear();
            thongBaoBUS.DocListThongBao();
            thongBao_NhomBUS.DocListThongBao_Nhom();
            nhomBUS.DocListNhom();
            monHocBUS.DocListMonHoc();
            nhomThamGiaBUS.DocListNhomThamGiaOfMaSV(maSinhVien);

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Dock = DockStyle.Fill;
            flow.FlowDirection = FlowDirection.TopDown;
            flow.WrapContents = false;
            flow.AutoScroll = true;
            flow.Padding = new Padding(0);

            ArrayList dstb = thongBaoBUS.GetListThongBao();
            ArrayList dsNhomOfSV = nhomThamGiaBUS.GetListNhomThamGiaOfMaSV(maSinhVien);

            foreach (NhomThamGia ntg in dsNhomOfSV)
            {
                string maMonHoc = nhomBUS.GetNhomTheoMa(ntg.maNhom).maMonHoc;
                string tenMonHoc = monHocBUS.GetMonHoc(maMonHoc);

                Panel pnlItem = new Panel();
                pnlItem.Width = pnThongBao.Width - 20;
                pnlItem.Height = 150;
                pnlItem.Margin = new Padding(0, 0, 0, 3);
                pnlItem.BorderStyle = BorderStyle.FixedSingle;
                pnlItem.BackColor = Color.LightGray;

                // Tiêu đề in đậm
                Label lblTieuDe = new Label();
                lblTieuDe.Text = $"{tenMonHoc}"+" - "+$"Nhóm: {ntg.maNhom}";
                lblTieuDe.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblTieuDe.Location = new Point(5, 5);
                lblTieuDe.AutoSize = true;

                ArrayList dsTB_N = thongBao_NhomBUS.GetListThongBao_NhomTheoMaNhom(ntg.maNhom);

                foreach(ThongBao_Nhom tbn in dsTB_N)
                {
                    foreach (ThongBao tb in dstb) 
                    {
                        if (tbn.maThongBao == tb.maThongBao)
                        {
                            Label lblGuiCho = new Label();
                            lblGuiCho.Text = $"THÔNG BÁO: {tb.tenThongBao}";
                            lblGuiCho.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                            lblGuiCho.Location = new Point(5, 35);
                            lblGuiCho.AutoSize = true;

                            Label lblNoiDung = new Label();
                            lblNoiDung.Text = $"Nội dung: {tb.noiDung}";
                            lblNoiDung.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                            lblNoiDung.Location = new Point(5, 60);
                            lblNoiDung.AutoSize = true;

                            Label lblThoiGian = new Label();
                            lblThoiGian.Text = $"Thời gian: {tb.thoiGian}";
                            lblThoiGian.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                            lblThoiGian.Location = new Point(5, 120);
                            lblThoiGian.AutoSize = true;

                            foreach (Control ctrl in new Control[] { lblTieuDe, lblGuiCho, lblNoiDung, lblThoiGian })
                            {
                                ctrl.Click += (s, e) => pnlItem.BackColor = Color.LightBlue;
                            }

                            pnlItem.Controls.Add(lblTieuDe);
                            pnlItem.Controls.Add(lblGuiCho);
                            pnlItem.Controls.Add(lblNoiDung);
                            pnlItem.Controls.Add(lblThoiGian);

                            flow.Controls.Add(pnlItem);
                        }
                    }
                }
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
    }
}
