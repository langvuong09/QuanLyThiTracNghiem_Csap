using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;


namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Dialog_XemThongTinHocPhan : UserControl
    {
        NhomBUS nhomBUS = new NhomBUS();
        MonHocBUS monHocBUS = new MonHocBUS();
        GiaoVienBUS giaoVienBUS = new GiaoVienBUS();
        BaiLamBUS baiLamBUS = new BaiLamBUS();
        public string maNhomDuocChon { get; set; }
        public Dialog_XemThongTinHocPhan(string maNhom)
        {
            InitializeComponent();
            maNhomDuocChon = maNhom;
            AddEvents();
        }

        private void AddEvents()
        {
            LoadInternationalOnTextBox();
            LoadDataLentable();
        }

        private void LoadInternationalOnTextBox()
        {
            monHocBUS.DocListMonHoc();

            int ma = Convert.ToInt32(maNhomDuocChon);
            Nhom nhom = nhomBUS.GetNhomTheoMa(ma);

            string tenMonHoc = monHocBUS.GetMonHoc(nhom.maMonHoc);
            string tenGiaoVien = giaoVienBUS.GetGiaoVienByID(nhom.maGiaoVien).tenGiaoVien;
            int sumBaiLam = baiLamBUS.CountBaiLamByMaSV(UserSession.userId);

            txtMonHoc.Text = tenMonHoc;
            txtNhom.Text = maNhomDuocChon;
            txtGiangVien.Text = tenGiaoVien;
            txtTongbaiKiemTra.Text = sumBaiLam.ToString();
        }

        private void LoadDataLentable()
        {
            baiLamBUS.DocListBaiLam();
            dgvBaiKiemTra.Rows.Clear();
            int maNhom = Convert.ToInt32(maNhomDuocChon);
            ArrayList dsbl = baiLamBUS.GetListBaiLamOfSV(UserSession.userId, maNhom);
            foreach(BaiLam bl in dsbl)
            {
                dgvBaiKiemTra.Rows.Add(
                    bl.maDe,
                    bl.thoiGianBatDau,
                    bl.thoiGianNopBai,
                    bl.tongDiem
                    );
            }
        }
    }
}
