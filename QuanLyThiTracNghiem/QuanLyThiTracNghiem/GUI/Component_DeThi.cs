using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_DeThi : UserControl
    {
        public Component_DeThi()
        {
            InitializeComponent();
        }

        private void Component_DeThi_Load(object sender, EventArgs e)
        {
            // FLOWLAYOUTPANEL_MAIN 
            flowLayoutPanel_Main.AutoScroll = true;
            flowLayoutPanel_Main.WrapContents = false;
            flowLayoutPanel_Main.FlowDirection = FlowDirection.TopDown;

            // Style nút next/prev
            button_Next.BackColor = ColorTranslator.FromHtml("#9CC7FF");
            button_Prev.BackColor = ColorTranslator.FromHtml("#9CC7FF");

            //// Giả sử load 20 đề thi demo
            //for (int i = 0; i < 20; i++)
            //{
            //    Panel_ItemDeThi item = new Panel_ItemDeThi();

            //    // Đăng ký sự kiện XemChiTiet của mỗi Item
            //    item.XemChiTietClicked += (s, e2) =>
            //    {
            //        // Mở form chứa thông tin bài thi
            //        Form formThongTin = new Form();
            //        formThongTin.Text = "THÔNG TIN BÀI THI";
            //        formThongTin.FormBorderStyle = FormBorderStyle.FixedDialog;
            //        formThongTin.StartPosition = FormStartPosition.CenterParent;
            //        formThongTin.ClientSize = new Size(824, 589);
            //        formThongTin.AutoScroll = true;
            //        formThongTin.ShowInTaskbar = false;

            //        // UserControl hiển thị thông tin bài thi
            //        Dialog_BatDauLamBaiThi dialog = new Dialog_BatDauLamBaiThi();
            //        dialog.Dock = DockStyle.Fill;

            //        // Đăng ký event Làm Bài
            //        dialog.LamBaiClicked += (ss, ee) =>
            //        {
            //            // Khi nhấn nút Làm Bài → mở FormLamBai
            //            LamBaiThi fLamBai = new LamBaiThi();

            //            fLamBai.TroVeClicked += (sss, eee) =>
            //            {
            //                // Khi nhấn Trở về → đóng form làm bài, hiện lại form thông tin
            //                fLamBai.Close();
            //                formThongTin.Show();
            //            };

            //            formThongTin.Hide();  // Ẩn form thông tin
            //            fLamBai.ShowDialog(formThongTin);  // Mở form làm bài (modal, owner = formThongTin)
            //        };

            //        formThongTin.Controls.Add(dialog);
            //        formThongTin.ShowDialog(this); // Mở modal trên FormTrangChu
            //    };

            //    flowLayoutPanel_Main.Controls.Add(item);
            //}
        }
    }
}
