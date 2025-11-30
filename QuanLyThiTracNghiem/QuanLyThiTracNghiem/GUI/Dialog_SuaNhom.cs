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
    public partial class Dialog_SuaNhom : UserControl
    {
        private NhomBUS nhomBUS = new NhomBUS();
        private MonHocBUS monHocBUS = new MonHocBUS();
        private GiaoVienBUS giangVienBUS = new GiaoVienBUS();
        public string maNhomDuocChon { get; set; }
        public Dialog_SuaNhom(string maNhom)
        {
            InitializeComponent();
            maNhomDuocChon = maNhom;
            AddEvents();
        }

        private void AddEvents()
        {
            LoadDataLenComboBoxMonHoc(maNhomDuocChon);
            LoadDataLenComboBoxNamHoc(maNhomDuocChon);
            LoadDataLenComboBoxHocKy(maNhomDuocChon);
            LoadDataLenComboBoxGiaoVien(maNhomDuocChon);
            btnCapNhat.Click += btnSua_Click;
        }

        private void LoadDataLenComboBoxMonHoc(string maNhom)
        {
            cbxMonHoc.Items.Clear();
            monHocBUS.DocListMonHoc();
            nhomBUS.DocListNhom();
            int maN = Convert.ToInt32(maNhom);
            Nhom n = nhomBUS.GetNhomTheoMa(maN);

            txtTenNhom.Text = n.tenNhom;
            txtGhiChu.Text = n.ghiChu;

            string tenMH = monHocBUS.GetMonHoc(n.maMonHoc);
            ArrayList dsmh = monHocBUS.GetListMonHoc();

            cbxMonHoc.Items.Add("Chọn môn học");
            foreach (MonHoc mh in dsmh)
            {
                cbxMonHoc.Items.Add(mh.tenMonHoc);
            }
            for (int i = 0; i < cbxMonHoc.Items.Count; i++)
            {
                if (cbxMonHoc.Items[i].ToString() == tenMH)
                {
                    cbxMonHoc.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadDataLenComboBoxNamHoc(string maNhom)
        {
            cbxNamHoc.Items.Clear();
            nhomBUS.DocListNhom();
            int maN = Convert.ToInt32(maNhom);
            Nhom n = nhomBUS.GetNhomTheoMa(maN);
            string namHoc = Convert.ToString(n.namHoc);

            int yearStart = 2020;
            int yearNow = DateTime.Now.Year;

            for (int year = yearStart; year <= yearNow; year++)
            {
                cbxNamHoc.Items.Add(year.ToString());
            }
            for (int i = 0; i < cbxNamHoc.Items.Count; i++)
            {
                if (cbxNamHoc.Items[i].ToString() == namHoc)
                {
                    cbxNamHoc.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadDataLenComboBoxHocKy(string maNhom)
        {
            cbxHocKy.Items.Clear();
            nhomBUS.DocListNhom();
            int maN = Convert.ToInt32(maNhom);
            Nhom n = nhomBUS.GetNhomTheoMa(maN);
            string hocKy = Convert.ToString(n.hocKy);

            for (int i = 1; i <= 3; i++)
            {
                cbxHocKy.Items.Add(i.ToString());
            }
            for (int i = 0; i < cbxHocKy.Items.Count; i++)
            {
                if (cbxHocKy.Items[i].ToString() == hocKy)
                {
                    cbxHocKy.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadDataLenComboBoxGiaoVien(string maNhom)
        {
            cbxHocKy.Items.Clear();
            nhomBUS.DocListNhom();
            giangVienBUS.DocListGiaoVien();
            ArrayList dsgv = giangVienBUS.GetListGiaoVien();
            int maN = Convert.ToInt32(maNhom);
            Nhom n = nhomBUS.GetNhomTheoMa(maN);
            GiaoVien giaoVien = giangVienBUS.GetGiaoVienByID(n.maGiaoVien);
            string GV = giaoVien.maGiaoVien+"-"+giaoVien.tenGiaoVien;

            cbxGiangVien.Items.Add("Chọn giảng viên");
            foreach (GiaoVien gv in dsgv)
            {
                cbxGiangVien.Items.Add(gv.maGiaoVien + "-" + gv.tenGiaoVien);
            }
            for (int i = 0; i < cbxGiangVien.Items.Count; i++)
            {
                if (cbxGiangVien.Items[i].ToString() == GV)
                {
                    cbxGiangVien.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string monHoc = cbxMonHoc.SelectedItem?.ToString();
            string maGiaoVien = Convert.ToString(cbxGiangVien.SelectedItem)?.Split('-')[0];
            string namHoc = cbxNamHoc.SelectedItem?.ToString();
            string hocKy = cbxHocKy.SelectedItem?.ToString();
            if(nhomBUS.SuaNhom(maNhomDuocChon, txtTenNhom.Text, txtGhiChu.Text, monHoc, maGiaoVien, namHoc, hocKy))
            {
                return;
            }
        }
    }
}
