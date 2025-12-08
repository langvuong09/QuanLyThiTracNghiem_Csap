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
        public int MaDapAnChon { get; private set; } = -1;
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

        /* private void Radio_CheckedChanged(object sender, EventArgs e)
         {
             if (DaNopBai) return;

             var r = sender as RadioButton;
             if (r != null && r.Checked)
             {
                 string key = r.Text;
                 if (mappingDapAn.ContainsKey(key))
                     MaDapAnChon = mappingDapAn[key];
                 MessageBox.Show("Đáp án đã chọn:",MaDapAnChon.ToString());
             }
         }*/
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (DaNopBai) return;

            var r = sender as RadioButton;
            if (r != null && r.Checked)
            {
                // đọc Tag (an toàn hơn so với Text)
                if (r.Tag != null && int.TryParse(r.Tag.ToString(), out int ma))
                {
                    MaDapAnChon = ma;
                }
                else
                {
                    // fallback: nếu bạn vẫn muốn dùng mapping theo chữ A/B/C/D
                    string key = r.Text.Length > 0 ? r.Text.Substring(0, 1) : "";
                    if (mappingDapAn.ContainsKey(key))
                        MaDapAnChon = mappingDapAn[key];
                }

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
            MaDapAnChon = -1;
            label_DapAnDung.Visible = false;

            // Gán text cho phần nội dung (nếu bạn muốn hiển thị nội dung trên RadioButton thì dùng Text)
            radioButton_A.Text = "A. " ;
            radioButton_A.Tag = dsDapAn[0].maDapAn;
            textBox_A.Text = dsDapAn[0].tenDapAn;

            radioButton_B.Text = "B. " ;
            radioButton_B.Tag = dsDapAn[1].maDapAn;
            textBox_B.Text = dsDapAn[1].tenDapAn;

            radioButton_C.Text = "C. " ;
            radioButton_C.Tag = dsDapAn[2].maDapAn;
            textBox_C.Text = dsDapAn[2].tenDapAn;

            radioButton_D.Text = "D. " ;
            radioButton_D.Tag = dsDapAn[3].maDapAn;
            textBox_D.Text = dsDapAn[3].tenDapAn;

            // giữ mapping nếu cần cho HienThiDapAnDung (không bắt buộc nếu dùng Tag)
            mappingDapAn.Clear();
            mappingDapAn["A"] = dsDapAn[0].maDapAn;
            mappingDapAn["B"] = dsDapAn[1].maDapAn;
            mappingDapAn["C"] = dsDapAn[2].maDapAn;
            mappingDapAn["D"] = dsDapAn[3].maDapAn;

            MaDapAnDung = dsDapAn.FirstOrDefault(x => x.dungSai == 1)?.maDapAn ?? -1;
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

  
    }
}
