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
    public partial class Panel_ItemCauHoi : UserControl
    {
        public int MaCauHoi { get; private set; }
        public int? MaDapAnChon { get; private set; } = null;
        public int MaDapAnDung { get; private set; }
        public bool DaNopBai { get; private set; } = false;

        public int MaBaiLam { get; private set; }

        private Dictionary<string, int> mappingDapAn = new(); // A,B,C,D -> MaDapAn

        public Panel_ItemCauHoi(int maBaiLam)
        {

            InitializeComponent();
            this.MaBaiLam = maBaiLam;
        }

        public Panel_ItemCauHoi()
        {
        }

        //Sự kiện xử lí khi chọn đáp án
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
            if (r.Checked)
            {
                string key = r.Text; 
                if (mappingDapAn.ContainsKey(key))
                    MaDapAnChon = mappingDapAn[key];
            }
        }

        public void KhoiTaoCauHoi(
        int stt,
        CauHoi cauHoi,
        List<DapAn> dsDapAn)
        {
            MaCauHoi = cauHoi.maCauHoi;
            label_STTCauHoi.Text = $"{stt}.";
            textBox_CauHoi.Text = cauHoi.noiDungCauHoi;

            // Giả định luôn có đúng 4 đáp án
            mappingDapAn.Clear();

            textBox_A.Text = dsDapAn[0].tenDapAn;
            mappingDapAn["A"] = dsDapAn[0].maDapAn;

            textBox_B.Text = dsDapAn[1].tenDapAn;
            mappingDapAn["B"] = dsDapAn[1].maDapAn;

            textBox_C.Text = dsDapAn[2].tenDapAn;
            mappingDapAn["C"] = dsDapAn[2].maDapAn;

            textBox_D.Text = dsDapAn[3].tenDapAn;
            mappingDapAn["D"] = dsDapAn[3].maDapAn;

            MaDapAnDung = dsDapAn.First(x => x.dungSai==1).maDapAn;


         
        }

        public ChiTietBaiLam LayChiTiet()
        {
            return new ChiTietBaiLam
            {
                maBaiLam = this.MaBaiLam,
                maCauHoi = MaCauHoi,
                maDapAnDuocChon = MaDapAnChon ?? -1
            };
        }

        public void HienThiDapAnDung()
        {
            DaNopBai = true;
            radioButton_A.Enabled = false;
            radioButton_B.Enabled = false;
            radioButton_C.Enabled = false;
            radioButton_D.Enabled = false;

            
            string chuCaiDung = mappingDapAn.First(p => p.Value == MaDapAnDung).Key;
            

            ResetMauRadio();

            // Nếu chọn đáp án mà chọn sai
            if (MaDapAnChon.HasValue && MaDapAnChon.Value != MaDapAnDung)
            {
                LayRadioTheoMaDapAn(MaDapAnChon.Value).ForeColor = Color.Blue;
                LayRadioTheoMaDapAn(MaDapAnDung).ForeColor = Color.Red;
            }
            else if (!MaDapAnChon.HasValue)
            {
                LayRadioTheoMaDapAn(MaDapAnDung).ForeColor = Color.Red;
            }
        }

        private void ResetMauRadio()
        {
            radioButton_A.ForeColor = Color.Black;
            radioButton_B.ForeColor = Color.Black;
            radioButton_C.ForeColor = Color.Black;
            radioButton_D.ForeColor = Color.Black;
        }

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
