using QuanLyThiTracNghiem.MyCustom;
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
    public partial class LamBaiThi : Form
    {
        private CauHoi_DeKiemTraBUS cauHoi_DeKiemTraBUS = new CauHoi_DeKiemTraBUS();
        private BaiLamBUS baiLamBUS = new BaiLamBUS();

        private int maDe;
        private DateTime thoiGianBatDauThucTe;
        private DateTime thoiGianCanhBaoThucTe;
        private TimeSpan tongThoiGian;

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private List<Panel_ItemCauHoi> dsItem = new();

        private BaiLam bailamSinhVien = new BaiLam();


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
            panel_Top.Visible = false;

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

            bailamSinhVien.maDe = this.maDe;
            bailamSinhVien.maSinhVien = UserSession.userId;
            bailamSinhVien.maBaiLam = baiLamBUS.TaoMaBaiLamMoi();

            this.dsItem = cauHoi_DeKiemTraBUS.Display_ItemCauHoi_InPanel(flowLayoutPanel_CauHoi, this.maDe, bailamSinhVien.maBaiLam);
            flowLayoutPanel_CauHoi.SuspendLayout();
            flowLayoutPanel_CauHoi.ResumeLayout();
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
            int socau = 0;
            foreach (var item in dsItem)
            {
                item.HienThiDapAnDung();
                if (item.MaDapAnChon == item.MaDapAnDung)
                    socau++;
            }

            float sodiemtren1cau = 10 / this.dsItem.Count;
            float diem = socau*sodiemtren1cau;

            panel_Top.Visible = true;
            label_SoCauDung.Text = "Số Câu Đúng:\t" + socau.ToString();
            label_Diem.Text= "Tổng Điểm:\t"+diem.ToString();

        }



        // Event khi nhấn nút Trở về
        public event EventHandler TroVeClicked;
        private void button_Thoat_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime thoiGianKetThucThucTe = thoiGianBatDauThucTe + tongThoiGian;

            // Nếu đã qua thời gian kết thúc thì cho phép thoát luôn
            if (now >= thoiGianKetThucThucTe)
            {
                TroVeClicked?.Invoke(this, EventArgs.Empty);
                return;
            }

            // Nếu chưa hết thời gian thì hỏi xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không? Nếu thoát, bài làm sẽ không được lưu lại.",
                "Xác nhận thoát",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                TroVeClicked?.Invoke(this, EventArgs.Empty);
            }
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
