using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Panel_ItemCauHoi : UserControl
    {
        public int MaCauHoi { get; private set; }
        public int ?MaDapAnChon { get; private set; } = -1;
        public int MaDapAnDung { get; private set; }
        public bool DaNopBai { get; private set; } = false;
        public int MaBaiLam { get; private set; }

        private Dictionary<string, int> mappingDapAn = new(); // A,B,C,D -> MaDapAn

        public Panel_ItemCauHoi(int maBaiLam)
        {
            InitializeComponent();
            this.MaBaiLam = maBaiLam;
            label_DapAnDung.Visible = false;

            GanSuKienRadio(); // Gán sự kiện radio ngay từ đầu
        }

        public Panel_ItemCauHoi()
        {
            InitializeComponent();
            label_DapAnDung.Visible = false;

            GanSuKienRadio();
        }

        // Gán sự kiện RadioButton
        private void GanSuKienRadio()
        {
            radioButton_A.CheckedChanged += Radio_CheckedChanged;
            radioButton_B.CheckedChanged += Radio_CheckedChanged;
            radioButton_C.CheckedChanged += Radio_CheckedChanged;
            radioButton_D.CheckedChanged += Radio_CheckedChanged;
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (DaNopBai) return;

            var r = sender as RadioButton;
            if (r != null && r.Checked)
            {
                string key = r.Text;
                if (mappingDapAn.ContainsKey(key))
                    MaDapAnChon = mappingDapAn[key];
            }
        }

        // Khởi tạo câu hỏi mới
        public void KhoiTaoCauHoi(int stt, CauHoi cauHoi, List<DapAn> dsDapAn)
        {
            MaCauHoi = cauHoi.maCauHoi;
            label_STTCauHoi.Text = $"{stt}.";
            textBox_CauHoi.Text = cauHoi.noiDungCauHoi;

            // Reset trạng thái
            DaNopBai = false;
            MaDapAnChon = null;
            label_DapAnDung.Visible = false;

            radioButton_A.Checked = false;
            radioButton_B.Checked = false;
            radioButton_C.Checked = false;
            radioButton_D.Checked = false;

            // Mapping đáp án
            mappingDapAn.Clear();
            textBox_A.Text = dsDapAn[0].tenDapAn;
            mappingDapAn["A"] = dsDapAn[0].maDapAn;

            textBox_B.Text = dsDapAn[1].tenDapAn;
            mappingDapAn["B"] = dsDapAn[1].maDapAn;

            textBox_C.Text = dsDapAn[2].tenDapAn;
            mappingDapAn["C"] = dsDapAn[2].maDapAn;

            textBox_D.Text = dsDapAn[3].tenDapAn;
            mappingDapAn["D"] = dsDapAn[3].maDapAn;

            // Chỉ có 1 đáp án đúng
            MaDapAnDung = dsDapAn.FirstOrDefault(x => x.dungSai == 1)?.maDapAn ?? -1;
        }

        // Lấy chi tiết bài làm
        public ChiTietBaiLam LayChiTiet()
        {
            return new ChiTietBaiLam
            {
                maBaiLam = MaBaiLam,
                maCauHoi = MaCauHoi,
                maDapAnDuocChon = MaDapAnChon ?? -1
            };
        }

        // Hiển thị đáp án đúng
        public void HienThiDapAnDung()
        {
            DaNopBai = true;

            radioButton_A.Enabled = false;
            radioButton_B.Enabled = false;
            radioButton_C.Enabled = false;
            radioButton_D.Enabled = false;

            string chuCaiDung = mappingDapAn.FirstOrDefault(p => p.Value == MaDapAnDung).Key;
            label_DapAnDung.Text = chuCaiDung;
            label_DapAnDung.Visible = true;
        }

        // Lấy RadioButton theo mã đáp án
        private RadioButton LayRadioTheoMaDapAn(int ma)
        {
            string key = mappingDapAn.FirstOrDefault(p => p.Value == ma).Key;
            return key switch
            {
                "A" => radioButton_A,
                "B" => radioButton_B,
                "C" => radioButton_C,
                "D" => radioButton_D,
                _ => null
            };
        }
    }
}
