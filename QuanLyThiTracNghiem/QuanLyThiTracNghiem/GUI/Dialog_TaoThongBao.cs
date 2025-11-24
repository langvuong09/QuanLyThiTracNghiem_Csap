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
    public partial class Dialog_TaoThongBao : UserControl
    {
        private MonHocBUS monHocBus = new MonHocBUS();
        private NhomBUS nhomBUS = new NhomBUS();
        private ThongBaoBUS thongBaoBUS = new ThongBaoBUS();
        private ThongBao_NhomBUS thongBao_NhomBUS = new ThongBao_NhomBUS();
        public Dialog_TaoThongBao()
        {
            InitializeComponent();
            AddEvents();
        }

        private void AddEvents()
        {
            LoadDataLenComboBoxMonHoc();
            cbxMonHoc.SelectedIndexChanged += CbxMonHoc_Choose;
            cklbxNhom.SelectedIndexChanged += CklbxNhom_Choose;
            btnThem.Click += btnThem_Click;
        }

        private void LoadDataLenComboBoxMonHoc()
        {
            cbxMonHoc.Items.Clear();
            ArrayList dsmh = monHocBus.GetListMonHoc();

            cbxMonHoc.Items.Add("Chọn môn học");    
            foreach (MonHoc mh in dsmh)
            {
                cbxMonHoc.Items.Add(mh.tenMonHoc);
            }
            cbxMonHoc.SelectedIndex = 0;
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

        private void LoadDataLenListBoxNhomHoc(string maMonHoc)
        {
            cklbxNhom.Items.Clear();
            ArrayList dsNhom = nhomBUS.GetListNhom(maMonHoc);
            cklbxNhom.Items.Add("Tất cả");
            foreach(Nhom n in dsNhom)
            {
                cklbxNhom.Items.Add(n.tenNhom);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenMonHoc = cbxMonHoc.SelectedItem?.ToString();
            string maMonHoc = monHocBus.GetMaMonHoc(tenMonHoc).maMonHoc;
            int maThongBao = thongBaoBUS.GetMaxMaThongBao() + 1;
            string maTB = Convert.ToString(maThongBao);
            bool flag1 = thongBaoBUS.ThemThongBao(maTB, txtTieuDe.Text, txtNoiDung.Text, maMonHoc);
            nhomBUS.DocListNhom();
            if(flag1 )
            {
                foreach(string i in GetDanhSachNhomDaChon())
                {
                    
                    string maNhom = Convert.ToString(nhomBUS.GetNhom(i).maNhom);
                    if (!thongBao_NhomBUS.ThemThongBao_Nhom(maNhom, maTB))
                    {
                        MyDialog dlg = new MyDialog("Lỗi thêm!", MyDialog.ERROR_DIALOG);
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
