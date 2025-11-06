using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;

using System;
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
    public partial class Dialog_ThemChuong : UserControl
    {
        private ChuongBUS chuongBUS = new ChuongBUS();
        public string MaMonHoc { get; set; }
        public Dialog_ThemChuong()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (chuongBUS.ThemChuong(txtMaChuong.Text, MaMonHoc, txtTenChuong.Text))
            {
                MyDialog dlg = new MyDialog("Thêm chương thành công!", MyDialog.SUCCESS_DIALOG);
                dlg.ShowDialog();
                Form parentForm = this.FindForm();
                if (parentForm != null)
                    parentForm.Close();
            }           
        }
    }
}
