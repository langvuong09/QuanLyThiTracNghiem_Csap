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
    public partial class Dialog_BatDauLamBaiThi : UserControl
    {
        private DeKTra_Mon_Nhom dekiemtra;
        public Dialog_BatDauLamBaiThi(DeKTra_Mon_Nhom dekiemtra)
        {
            InitializeComponent();
            this.dekiemtra = dekiemtra;
        }

        private void Dialog_BatDauLamBaiThi_Load(object sender, EventArgs e)
        {
            textBox_TGianLamBai.Text = dekiemtra.DeKiemTra.thoiGianBatDau.ToString("dd/MM/yyyy HH:mm:ss");
            textBox_TGianKetThuc.Text = dekiemtra.DeKiemTra.thoiGianKetThuc.ToString("dd/MM/yyyy HH:mm:ss");
            textBox_TGianCanhBao.Text = dekiemtra.DeKiemTra.thoiGianCanhBao.ToString("dd/MM/yyyy HH:mm:ss");

            textBox_SoCauDe.Text = dekiemtra.DeKiemTra.soCauDe.ToString();
            textBox_SoCauKho.Text = dekiemtra.DeKiemTra.soCauKho.ToString();
            textBox_SoCauTrungBinh.Text = dekiemtra.DeKiemTra.soCauTrungBinh.ToString();

            textBox_Nhom.Text= dekiemtra.MaNhom.ToString()+" - "+dekiemtra.TenNhom;
            textBox_MonHoc.Text = dekiemtra.MaMonHoc.ToString() + " - " + dekiemtra.TenMonHoc;
        }

        // Event khi nhấn nút Làm Bài
        public event EventHandler LamBaiClicked;

        private void button_LamBaiThi_Click(object sender, EventArgs e)
        {
            LamBaiClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
