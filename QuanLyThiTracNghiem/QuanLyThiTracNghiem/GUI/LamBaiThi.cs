using QuanLyThiTracNghiem.MyCustom;
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
    public partial class LamBaiThi : Form
    {
        private int maDe;
        private DateTime thoiGianBatDauThucTe;
        private DateTime thoiGianCanhBaoThucTe;
        private TimeSpan tongThoiGian;

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();



        public LamBaiThi(int maDe, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, DateTime thoiGianCanhBao)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            // 1) Đặt form nằm giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
            // 2) Không cho resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //PANEL TOP
            panel_Top.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");

            //PANEL BOTTOM
            panel_Bottom.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            panel_Bottom.Visible = false;

            // FLOWLAYOUTPANEL_CAUHOI 
            flowLayoutPanel_CauHoi.AutoScroll = true;
            flowLayoutPanel_CauHoi.WrapContents = false;
            flowLayoutPanel_CauHoi.FlowDirection = FlowDirection.TopDown;

            //Hiện mã sinh viên làm bài thi
            label_MaSinhVien.Text = UserSession.userId;

            this.maDe = maDe;


            this.tongThoiGian = thoiGianKetThuc - thoiGianCanhBao;
            this.thoiGianCanhBaoThucTe = DateTime.Now + (thoiGianCanhBao - thoiGianBatDau);


            

            //for (int i = 0; i < 20; i++)
            //{
            //    flowLayoutPanel_CauHoi.Controls.Add(new Panel_ItemCauHoi());
            //}


        }


        private void LamBaiThi_Load(object sender, EventArgs e)
        {
            this.thoiGianBatDauThucTe = DateTime.Now;
            this.timer.Interval = 1000; // 1 giây
            this.timer.Tick += Timer_Tick;
            this.timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan daLam = DateTime.Now - thoiGianBatDauThucTe;
            TimeSpan conLai = tongThoiGian - daLam;

            label_DemThoiGian.Text = conLai.ToString(@"mm\:ss");

            if (conLai.TotalSeconds <= 0)
            {
                timer.Stop();
                MyDialog dialog = new MyDialog("Hết giờ, bài sẽ được nộp tự động!", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                NopBai();
            }
        }

        private void NopBai()
        {

        }



        // Event khi nhấn nút Trở về
        public event EventHandler TroVeClicked;
        private void button_Thoat_Click(object sender, EventArgs e)
        {
            TroVeClicked?.Invoke(this, EventArgs.Empty);
        }

        private void button_NopBai_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            if (now < thoiGianCanhBaoThucTe)
            {
                MyDialog dialog = new MyDialog($"Bạn chưa thể nộp bài sớm hơn thời gian cho phép!\n" +
                    $"Bạn chỉ được nộp sau {thoiGianCanhBaoThucTe:HH:mm:ss}.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();

                return;
            }

            // Nếu hợp lệ thì nộp bài
            NopBai();

        }
    }
}
