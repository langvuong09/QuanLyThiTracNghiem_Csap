using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;


namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_ThongKe : UserControl
    {
        private MonHocBUS monHocBUS = new MonHocBUS();
        private NhomBUS nhomBUS = new NhomBUS();
        private DeKiemTraBUS deKiemTraBUS = new DeKiemTraBUS();
        private DeKiemTra_NhomBUS deKiemTra_NhomBUS = new DeKiemTra_NhomBUS();
        private BaiLamBUS baiLamBUS = new BaiLamBUS();
        public Component_ThongKe()
        {
            InitializeComponent();
            AddEvents();
        }

        private void AddEvents()
        {
            LoadDataLenComboBoxMonHoc();
            cbxMonHoc.SelectedIndexChanged += cbxMonHoc_Choose;
            cbxNhom.SelectedIndexChanged += cbxNhom_Choose;
            cklbxBaiKiemTra.ItemCheck += cklbxDeKiemTra_ItemCheck;
        }

        private void LoadDataLenComboBoxMonHoc()
        {
            cbxMonHoc.Items.Clear();
            ArrayList dsmh = monHocBUS.GetListMonHoc();

            foreach(MonHoc mh in dsmh)
            {
                cbxMonHoc.Items.Add(mh.tenMonHoc);
            }
        }

        private void cbxMonHoc_Choose(object sender, EventArgs e)
        {
            cbxNhom.Items.Clear();
            string monHoc = cbxMonHoc.SelectedItem?.ToString();
            string maMonHoc = monHocBUS.GetMonHocTheoTen(monHoc).maMonHoc;
            LoadDataLenComBoxNhom(maMonHoc);
            cbxNhom.SelectedIndex = -1;
        }

        private void LoadDataLenComBoxNhom(string maMonHoc)
        {
            cbxNhom.Items.Clear();
            ArrayList dsn = nhomBUS.GetListNhom(maMonHoc);

            if (dsn != null)
            {
                foreach (Nhom n in dsn)
                {
                    cbxNhom.Items.Add(n.maNhom + "-" + n.tenNhom);
                }
            }
        }

        private void cbxNhom_Choose(object sender, EventArgs e)
        {
            string nhom = cbxNhom.SelectedItem?.ToString();

            string[] parts = nhom.Split('-');
            if (parts.Length > 0)
            {
                string maNhom = parts[0];
                
                LoadDataLenListBoxDeKiemTra(maNhom);
            }
        }

        private void LoadDataLenListBoxDeKiemTra(string maNhom)
        {
            cklbxBaiKiemTra.Items.Clear();
            int maN = Convert.ToInt32(maNhom);
            ArrayList dsdkt = deKiemTraBUS.GetListDeKiemTraTheoMaNhom(maN);
            foreach(DeKiemTra dkt in dsdkt)
            {
                cklbxBaiKiemTra.Items.Add(dkt.maDe+"-"+dkt.tenDe);
            }
        }

        private void cklbxDeKiemTra_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < cklbxBaiKiemTra.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        cklbxBaiKiemTra.SetItemChecked(i, false);
                    }
                }
            }
            VeBieuDo();
        }

        private void VeBieuDo()
        {
            pnDoThi.Controls.Clear();

            string deKiemTra = cklbxBaiKiemTra.Text.ToString();
            string[] parts = deKiemTra.Split('-');
            string maDe = parts[0].Trim();

            ArrayList dsDeKiemTra = baiLamBUS.GetListBaiLamByDeKiemTra(maDe);

            // Danh sách điểm (float)
            List<float> dsDiem = new List<float>();
            foreach (BaiLam bl in dsDeKiemTra)
            {
                dsDiem.Add((float)bl.tongDiem);
            }

            // Đếm số lượng sinh viên theo từng điểm (1–10)
            int[] soLuong = new int[11]; // index 1..10
            foreach (float d in dsDiem)
            {
                int diemLamTron = (int)Math.Round(d);
                if (diemLamTron >= 1 && diemLamTron <= 10)
                {
                    soLuong[diemLamTron]++;
                }
            }

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea("Area1");
            area.AxisX.Title = "Điểm";
            area.AxisY.Title = "Số lượng sinh viên";
            area.AxisX.Interval = 1;
            area.AxisX.Minimum = 1;
            area.AxisX.Maximum = 10;
            chart.ChartAreas.Add(area);

            Series slSeries = new Series("Số lượng");
            slSeries.ChartType = SeriesChartType.Line;
            slSeries.BorderWidth = 3;
            slSeries.Color = Color.Blue;

            for (int diem = 1; diem <= 10; diem++)
            {
                slSeries.Points.AddXY(diem, soLuong[diem]);
            }

            chart.Series.Add(slSeries);

            pnDoThi.Controls.Add(chart);
        }
    }
}
