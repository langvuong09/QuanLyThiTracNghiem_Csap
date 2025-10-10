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
    public partial class Panel_ThemCauHoiTuFile : UserControl
    {
        private TxtQuestionParser txtQuestionParser = new TxtQuestionParser();
        public Panel_ThemCauHoiTuFile()
        {
            InitializeComponent();
            LoadMonHoc(comboBox_MonHoc);
            LoadDoKho(comboBox_DoKho);
            LoadChuong(comboBox_Chuong, "0");
        }
        private MonHocBUS monHocBUS = new MonHocBUS();
        private ChuongBUS chuongBUS = new ChuongBUS();

        //=======================Load Môn Học======================
        private void LoadMonHoc(System.Windows.Forms.ComboBox combo)
        {
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
            if (comboBox_MonHoc.SelectedIndex <= 0)
            {
                LoadChuong(comboBox_Chuong, "0");
                return;
            }

            var monHoc = comboBox_MonHoc.SelectedItem as MonHoc;
            if (monHoc == null) return;

            LoadChuong(comboBox_Chuong, monHoc.maMonHoc);
        }

        private void button_Luu_Click(object sender, EventArgs e)
        {
            txtQuestionParser.LuuDanhSachCauHoiTuFileVaoCSDL(comboBox_MonHoc,comboBox_Chuong,comboBox_DoKho);
        }


        private void button_MauFileGoc_Click(object sender, EventArgs e)
        {
            txtQuestionParser.TaoVaMoFileMau();
        }
    }
}
