
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
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
    public partial class Panel_ItemDeThi : UserControl
    {
        private DeKTra_Mon_Nhom dekiemtra;

        public Panel_ItemDeThi(DeKTra_Mon_Nhom dekiemtra)
        {
            InitializeComponent();
            this.dekiemtra = dekiemtra;
            LoadData();
        }

        public void LoadData()
        {

            textBox_BaiKiemTra.Text = this.dekiemtra.DeKiemTra.maDe+" - "+ this.dekiemtra.DeKiemTra.tenDe;
            textBox_NhomHocPhan.Text = this.dekiemtra.MaNhom+" - "+ this.dekiemtra.TenNhom;
            textBox_MonHoc.Text = this.dekiemtra.MaMonHoc + " - " + this.dekiemtra.TenMonHoc;
            textBox_TGianBDau.Text = this.dekiemtra.DeKiemTra.thoiGianBatDau.ToString("dd/MM/yyyy HH:mm:ss");
            textBox_TGianKThuc.Text = this.dekiemtra.DeKiemTra.thoiGianKetThuc.ToString("dd/MM/yyyy HH:mm:ss");
        }
        // Khai báo event (callback)
        public event EventHandler XemChiTietClicked;


        private void button_XemChiTiet_Click(object sender, EventArgs e)
        {
            // Gọi event khi người dùng click
            XemChiTietClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
