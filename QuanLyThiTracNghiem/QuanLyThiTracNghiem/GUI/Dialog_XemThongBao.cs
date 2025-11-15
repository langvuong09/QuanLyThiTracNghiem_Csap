using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

using System;
using System.Collections;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Dialog_XemThongBao : UserControl
    {
        private MonHocBUS monHocBus = new MonHocBUS();
        private NhomBUS nhomBUS = new NhomBUS();
        private ThongBaoBUS thongBaoBUS = new ThongBaoBUS();
        private ThongBao_NhomBUS thongBao_NhomBUS = new ThongBao_NhomBUS();
        public string maThongBaoDuocChon { get; set; }
        public Dialog_XemThongBao(string maThongBao)
        {
            InitializeComponent();
            maThongBaoDuocChon = maThongBao;
            AddEvents();
        }

        private  void AddEvents()
        {
            LoadDataLenComboBoxMonHoc(maThongBaoDuocChon);
            LoadDataLenListBoxNhomHocTheoMa();
            cbxMonHoc.SelectedIndexChanged += CbxMonHoc_Choose;
            cklbxNhom.SelectedIndexChanged += CklbxNhom_Choose;
            btnSua.Click += btnSua_Click;
        }

        private void LoadDataLenComboBoxMonHoc(string maThongBao)
        {
            cbxMonHoc.Items.Clear();
            monHocBus.DocListMonHoc();
            thongBaoBUS.DocListThongBao();
            ThongBao tb = thongBaoBUS.GetThongBaoTheoMa(maThongBao);

            txtTitle.Text = tb.tenThongBao;
            txtNoiDung.Text = tb.noiDung;

            string tenMH = monHocBus.GetMonHoc(tb.maMonHoc);
            ArrayList dsmh = monHocBus.GetListMonHoc();

            cbxMonHoc.Items.Add("Chọn môn học");
            foreach (MonHoc mh in dsmh)
            {
                cbxMonHoc.Items.Add(mh.tenMonHoc);
            }
            for (int i = 0; i <  cbxMonHoc.Items.Count; i++)
            {
                if (cbxMonHoc.Items[i].ToString() == tenMH)
                {
                    cbxMonHoc.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadDataLenListBoxNhomHoc(string maMonHoc)
        {
            cklbxNhom.Items.Clear();
            ArrayList dsNhom = nhomBUS.GetListNhom(maMonHoc);
            cklbxNhom.Items.Add("Tất cả");
            foreach (Nhom n in dsNhom)
            {
                cklbxNhom.Items.Add(n.tenNhom);
            }
        }

        private void CbxMonHoc_Choose(object sender, EventArgs e)
        {
            string tenMonHoc = cbxMonHoc.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tenMonHoc) || tenMonHoc == "Chọn môn học")
                return;


            foreach (MonHoc mh in monHocBus.GetListMonHoc())
            {
                if (tenMonHoc.Equals(mh.tenMonHoc, StringComparison.OrdinalIgnoreCase))
                {
                    LoadDataLenListBoxNhomHoc(mh.maMonHoc);
                    return;
                }
            }
        }

        private void LoadDataLenListBoxNhomHocTheoMa()
        {
            cklbxNhom.Items.Clear();

            int maTB = Convert.ToInt32(maThongBaoDuocChon);
            ThongBao thongBao = thongBaoBUS.GetThongBaoTheoMa(maThongBaoDuocChon);
            ArrayList dsNhom = nhomBUS.GetListNhom(thongBao.maMonHoc);
            thongBao_NhomBUS.DocListThongBao_Nhom();
            ArrayList dsNhomDaChon = thongBao_NhomBUS.GetListThongBao_Nhom(maTB);

            cklbxNhom.Items.Add("Tất cả");

            foreach (Nhom n in dsNhom)
            {
                cklbxNhom.Items.Add(n.tenNhom);
            }
            if (dsNhomDaChon != null)
            {
                for (int i = 0; i < cklbxNhom.Items.Count; i++)
                {
                    foreach (ThongBao_Nhom tbn in dsNhomDaChon)
                    {
                        Nhom n = nhomBUS.GetNhom(tbn.maNhom);

                        if (n.tenNhom == cklbxNhom.Items[i].ToString())
                        {
                            cklbxNhom.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }


        private void CklbxNhom_Choose(object sender, EventArgs e)
        {
            string luaChon = cklbxNhom.SelectedItem?.ToString();
            if (luaChon == "Tất cả")
            {
                CheckTatCa(true);
            }
            else
            {
                CheckTatCa(false);
            }
        }

        private void CheckTatCa(bool check)
        {
            for (int i = 1; i < cklbxNhom.Items.Count; i++)
            {
                cklbxNhom.SetItemChecked(i, check);
            }
        }

        private List<string> GetDanhSachNhomDaChon()
        {
            List<string> dsNhom = new List<string>();

            foreach (var item in cklbxNhom.CheckedItems)
            {
                if (item.ToString() != "Tất cả")
                {
                    dsNhom.Add(item.ToString());
                }
            }
            return dsNhom;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            thongBao_NhomBUS.XoaThongBao_Nhom(maThongBaoDuocChon);
            bool flag1 = thongBaoBUS.SuaThongBao(maThongBaoDuocChon, txtTitle.Text, txtNoiDung.Text);
            if (flag1)
            {
                foreach (string i in GetDanhSachNhomDaChon())
                {
                    string maNhom = Convert.ToString(nhomBUS.GetNhom(i).maNhom);
                    if (!thongBao_NhomBUS.ThemThongBao_Nhom(maNhom, maThongBaoDuocChon))
                    {
                        MyDialog dlg = new MyDialog("Lỗi Sửa!", MyDialog.ERROR_DIALOG);
                        dlg.ShowDialog();
                        return;
                    }
                }
                Form parentForm = this.FindForm();
                if (parentForm != null)
                    parentForm.Close();
            }
        }
    }
}
