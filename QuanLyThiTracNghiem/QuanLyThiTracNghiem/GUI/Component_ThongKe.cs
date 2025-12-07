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

            List<float> dsDiem = new List<float>();
            foreach (BaiLam bl in dsDeKiemTra)
                dsDiem.Add(bl.tongDiem);

            // Mốc 0 → 10 (bước 0.5)
            List<float> diemMoc = new List<float>();
            for (float d = 0.0f; d <= 10.0f; d += 0.5f)
                diemMoc.Add(d);

            int[] soLuong = new int[diemMoc.Count];

            foreach (float diem in dsDiem)
            {
                float diemLamTron = LamTronDiem_Custom(diem);

                int index = diemMoc.FindIndex(x => Math.Abs(x - diemLamTron) < 0.001f);

                if (index != -1)
                    soLuong[index]++;
            }

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            ChartArea area = new ChartArea("Area1");
            area.AxisX.Title = "Điểm";
            area.AxisY.Title = "Số lượng sinh viên";
            area.AxisX.Interval = 0.5;
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 10;
            chart.ChartAreas.Add(area);

            Series slSeries = new Series("Số lượng");
            slSeries.ChartType = SeriesChartType.Line;   // ← CHỈ SỬA DÒNG NÀY
            slSeries.BorderWidth = 3;
            slSeries.Color = Color.Blue;

            for (int i = 0; i < diemMoc.Count; i++)
                slSeries.Points.AddXY(diemMoc[i], soLuong[i]);

            chart.Series.Add(slSeries);
            pnDoThi.Controls.Add(chart);
        }

        private float LamTronDiem_Custom(float d)
        {
            int nguyen = (int)Math.Truncate(d);
            float thapPhan = d - nguyen;

            float kq;

            if (thapPhan <= 0.3f)
                kq = nguyen;
            else if (thapPhan <= 0.6f)
                kq = nguyen + 0.5f;
            else
                kq = nguyen + 1;

            // KHÔNG ép về 1
            if (kq < 0f) kq = 0f;
            if (kq > 10f) kq = 10f;

            return kq;
        }
    }
}
