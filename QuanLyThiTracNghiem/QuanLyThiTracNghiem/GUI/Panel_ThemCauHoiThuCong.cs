using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
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
    public partial class Panel_ThemCauHoiThuCong : UserControl
    {
        private MonHocBUS monHocBUS = new MonHocBUS();
        private ChuongBUS chuongBUS = new ChuongBUS();

        private string is_MonHoc = "0";
        private int is_Chuong = 0;
        private int is_DoKho = 0;
        public Panel_ThemCauHoiThuCong()
        {
            InitializeComponent();
            LoadMonHoc(comboBox_MonHoc);
            LoadDoKho(comboBox_DoKho);
        }

        //===================Load Môn Học==========================
        private void LoadMonHoc(System.Windows.Forms.ComboBox combo)
        {
            //Load môn học từ BUS
            monHocBUS.LayListMonHoc(combo);
        }
        //=======================Load Độ Khó======================
        private void LoadDoKho(System.Windows.Forms.ComboBox combo)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            var dsDoKho = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int,string>(0, "Chọn Độ Khó"),
                    new KeyValuePair<int,string>(1, "Dễ"),
                    new KeyValuePair<int,string>(2, "Trung Bình"),
                    new KeyValuePair<int,string>(3, "Khó")
                };

            combo.DataSource = dsDoKho;
            combo.DisplayMember = "Value";
            combo.ValueMember = "Key";

            combo.SelectedIndex = 0;
        }

        //====================Load Chương=======================
        private void LoadChuong(System.Windows.Forms.ComboBox combo, string maMonHoc)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            chuongBUS.LayListChuong(combo, maMonHoc);
        }

        private void comboBox_MonHoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Nếu nhấn mục "Chọn Môn Học" thì load lại chương về 0
            if (comboBox_MonHoc.SelectedIndex <= 0)
            {
                LoadChuong(comboBox_Chuong, "0");
                return;
            }

            // Lấy object đang chọn
            var monHoc = comboBox_MonHoc.SelectedItem as MonHoc;
            if (monHoc == null) return;

            // Cập nhật ComboBox_Chuong
            LoadChuong(comboBox_Chuong, monHoc.maMonHoc);

            // Thực hiện điều kiện cho các mục khác
            MessageBox.Show($"Bạn đã chọn: {monHoc.tenMonHoc} (Mã: {monHoc.maMonHoc})");
        }

        private void comboBox_Chuong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Kiểm tra index
            if (comboBox_Chuong.SelectedIndex <= 0)
            {
                return;
            }

            // Lấy object đang chọn
            var chuong = comboBox_Chuong.SelectedItem as Chuong;
            if (chuong == null) return;

            // Thực hiện điều kiện cho các mục khác
            MessageBox.Show($"Bạn đã chọn: {chuong.tenChuong} (Mã: {chuong.maChuong})");
        }

        private void comboBox_DoKho_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_DoKho.SelectedIndex <= 0) return;

            var selectedPair = (KeyValuePair<int, string>)comboBox_DoKho.SelectedItem;
            int doKhoKey = selectedPair.Key;
            string doKhoText = selectedPair.Value;

            // Xử lý theo giá trị
            switch (doKhoKey)
            {
                case 1: MessageBox.Show("Bạn chọn Độ Khó: Dễ"); break;
                case 2: MessageBox.Show("Bạn chọn Độ Khó: Trung Bình"); break;
                case 3: MessageBox.Show("Bạn chọn Độ Khó: Khó"); break;
            }
        }

        private void button_Them_Click(object sender, EventArgs e)
        {

        }

        private void button_ThemCauTraLoi_Click(object sender, EventArgs e)
        {

        }
    }
}
