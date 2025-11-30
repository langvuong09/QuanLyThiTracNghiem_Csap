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
using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Dialog_ThemNhom : UserControl
    {
        private NhomBUS nhomBUS = new NhomBUS();
        private MonHocBUS monHocBUS = new MonHocBUS();
        private GiaoVienBUS giaoVienBUS = new GiaoVienBUS();
        public Dialog_ThemNhom()
        {
            InitializeComponent();
            AddEvents();
        }

        private void AddEvents()
        {
            LoadDataLenComboBoxMonHoc();
            LoadDataLenComboBoxNamHoc();
            LoadDataLenComboBoxHocKy();
            LoadDataLenComboBoxGiaoVien();
            btnLuu.Click += btnThem_Click;
        }

        private void LoadDataLenComboBoxMonHoc()
        {
            cbxMonHoc.Items.Clear();
            ArrayList dsmh = monHocBUS.GetListMonHoc();

            cbxMonHoc.Items.Add("Chọn môn học");
            foreach (MonHoc mh in dsmh)
            {
                cbxMonHoc.Items.Add(mh.tenMonHoc);
            }
            cbxMonHoc.SelectedIndex = 0;
        }

        private void LoadDataLenComboBoxNamHoc()
        {
            cbxNamHoc.Items.Clear();

            int yearStart = 2020;
            int yearNow = DateTime.Now.Year;

            for (int year = yearStart; year <= yearNow; year++)
            {
                cbxNamHoc.Items.Add(year.ToString());
            }
            cbxNamHoc.SelectedIndex = 0;
        }

        private void LoadDataLenComboBoxHocKy()
        {
            cbxHocKy.Items.Clear();

            for(int i = 1; i <= 3; i++)
            {
                cbxHocKy.Items.Add(i.ToString());
            }
            cbxHocKy.SelectedIndex = 0;
        }

        private void LoadDataLenComboBoxGiaoVien()
        {
            cbxGiangVien.Items.Clear();
            ArrayList dsgv = giaoVienBUS.GetListGiaoVien();

            cbxGiangVien.Items.Add("Chọn giảng viên");
            foreach (GiaoVien gv in dsgv)
            {
                cbxGiangVien.Items.Add(gv.maGiaoVien+"-"+gv.tenGiaoVien);
            }
            cbxGiangVien.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string monHoc = cbxMonHoc.SelectedItem?.ToString();
            string namHoc = cbxNamHoc.SelectedItem?.ToString();
            string hocKy = cbxHocKy.SelectedItem?.ToString();
            string giaoVien = cbxGiangVien.SelectedItem?.ToString();

            string maGiaoVien = Convert.ToString(giaoVien.Split('-')[0]);

            if (nhomBUS.ThemNhom(txtTenNhom.Text ,txtGhiChu.Text,monHoc,maGiaoVien,namHoc,hocKy))
            {
                Form parentForm = this.FindForm();
                if (parentForm != null)
                    parentForm.Close();
                return;
            }
        }
    }
}
