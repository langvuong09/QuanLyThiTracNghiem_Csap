using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Dialog_XemDanhSachDeThi : UserControl
    {
        private BaiLamBUS baiLamBUS = new BaiLamBUS();
        private DeKiemTraBUS deKiemTraBUS = new DeKiemTraBUS();
        private SinhVienBUS sinhVienBUS = new SinhVienBUS();
        public string maNhomDuocChon { get; set; }
        private string maDeChon = "";
        public Dialog_XemDanhSachDeThi(string maNhom)
        {
            InitializeComponent();
            maNhomDuocChon = maNhom;
            AddEvents();
        }

        private void AddEvents()
        {
            LoadDataLenTableDeKiemTra();
            dgvDanhSachDeThi.CellClick += new DataGridViewCellEventHandler(dgvDanhSachBaiThi_CellClick);
            btnXem.Click += btnXem_Click;
            btnReturn.Click += btnReturn_Click;
            btnTimKiem.Click += btnTimKiem_Click;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachDeThi.CurrentRow != null && maDeChon != "")
            {
                dgvDanhSachDeThi.Visible = false;
                dgvSinhVien.Visible = true;
                btnTimKiem.Enabled = false;
                btnReturn.Visible = true;
                btnTimKiem.Enabled = true;

                
                LoadDataLenTableSinhVien(maDeChon);
            }
            else
            {
                MyDialog dlg = new MyDialog("Chưa chọn đề thi!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }
        }

        private void dgvDanhSachBaiThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                XuLyClickDgvDanhSachBaiThi();
            }
        }

        private void XuLyClickDgvDanhSachBaiThi()
        {
            int row = dgvDanhSachDeThi.CurrentCell.RowIndex;
            if (row >= 0)
            {
                maDeChon = dgvDanhSachDeThi.Rows[row].Cells[0].Value?.ToString();
            }            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            dgvDanhSachDeThi.Visible = true;
            dgvSinhVien.Visible = false;
            btnTimKiem.Enabled = true;
            btnReturn.Visible = false;
            btnTimKiem.Enabled = true;
            LoadDataLenTableDeKiemTra();
            dgvSinhVien.Rows.Clear();
        }

        private void LoadDataLenTableDeKiemTra()
        {            
            dgvDanhSachDeThi.Rows.Clear();
            int maNhom = Convert.ToInt32(maNhomDuocChon);
            ArrayList dsDeKiemTra = deKiemTraBUS.GetListDeKiemTraTheoMaNhom(maNhom);
            foreach(DeKiemTra dkt in dsDeKiemTra)
            {
                dgvDanhSachDeThi.Rows.Add(
                    dkt.maDe,
                    dkt.tenDe,
                    dkt.thoiGianBatDau,
                    dkt.thoiGianKetThuc,
                    baiLamBUS.GetCountBaiLam(dkt.maDe)
                    );
            }
        }

        private void LoadDataLenTableSinhVien(string maDe)
        {
            dgvSinhVien.Rows.Clear();
            int maD = Convert.ToInt32(maDe);
            ArrayList dsDeKiemTra = baiLamBUS.GetListBaiLam();
            foreach (BaiLam bl in dsDeKiemTra)
            {
                if (bl.maDe == maD)
                {
                    dgvSinhVien.Rows.Add(
                        bl.maDe,
                        sinhVienBUS.GetSinhVienByID(bl.maSinhVien).hoVaTen,
                        bl.tongDiem,
                        bl.thoiGianBatDau,
                        bl.thoiGianNopBai
                        );
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if(dgvDanhSachDeThi.Visible == true)
            {
                dgvDanhSachDeThi.Rows.Clear();
                int maNhom = Convert.ToInt32(maNhomDuocChon);
                ArrayList dsDeKiemTra = deKiemTraBUS.GetListDeKiemTraTheoMaNhom(maNhom);
                foreach (DeKiemTra dkt in dsDeKiemTra)
                {
                    if (dkt.tenDe.ToLower().Contains(keyword))
                    {
                        dgvDanhSachDeThi.Rows.Add(
                            dkt.maDe,
                            dkt.tenDe,
                            dkt.thoiGianBatDau,
                            dkt.thoiGianKetThuc,
                            baiLamBUS.GetCountBaiLam(dkt.maDe)
                            );
                    }
                }
            }
            else if(dgvSinhVien.Visible == true)
            {
                dgvSinhVien.Rows.Clear();
                int maD = Convert.ToInt32(maDeChon);
                ArrayList dsDeKiemTra = baiLamBUS.GetListBaiLam();
                ArrayList dsTemp = new ArrayList();
                foreach (BaiLam bl in dsDeKiemTra)
                {
                    if (bl.maDe == maD)
                    {
                        string tenSV = sinhVienBUS.GetSinhVienByID(bl.maSinhVien).hoVaTen;

                        dsTemp.Add(new KetQuaBaiLam
                        {
                            MaDe = bl.maDe,
                            TenSV = tenSV,
                            TongDiem = bl.tongDiem,
                            ThoiGianBatDau = bl.thoiGianBatDau,
                            ThoiGianNop = bl.thoiGianNopBai
                        });
                    }
                }
                foreach (KetQuaBaiLam kq in dsTemp)
                {
                    if (kq.TenSV.ToLower().Contains(keyword))
                    {
                        dgvSinhVien.Rows.Add(
                            kq.MaDe,
                            kq.TenSV,
                            kq.TongDiem,
                            kq.ThoiGianBatDau,
                            kq.ThoiGianNop
                            );
                    }
                }
            }
        }
    }
}
