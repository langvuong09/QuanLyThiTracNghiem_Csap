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
    public partial class TrangChuSinhVien : Form
    {
        public TrangChuSinhVien()
        {
            InitializeComponent();
            customFormTrangChuSinhVien_Load();
        }
        // Kích thước màn hình chính (Primary Screen)
        private static readonly int SCREEN_WIDTH = 1920;
        private static readonly int SCREEN_HEIGHT = 1080;

        // Khai báo các component
        private Component_HocPhan hp = new Component_HocPhan();
        private Component_TrangChu tc = new Component_TrangChu();
        private Component_DeThi dt = new Component_DeThi();
        private Component_NhomHocPhan nhp = new Component_NhomHocPhan();
        private Component_DeKiemTra dkt = new Component_DeKiemTra();
        private Component_CauHoi ch = new Component_CauHoi();
        private Component_ThongBaoAdmin tba = new Component_ThongBaoAdmin();
        private Component_MonHoc mh = new Component_MonHoc();
        private Component_PhanCong pc = new Component_PhanCong();
        private Component_PhanQuyen pq = new Component_PhanQuyen();

        //Khai Báo Panel
        private Component_ThongBao tb = new Component_ThongBao();
        private Component_TTCaNhan ttcn = new Component_TTCaNhan();


        private void customFormTrangChuSinhVien_Load()
        {
            // 1) Đặt form nằm giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);

            // 2) Không cho resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false; // tắt nút maximize
            this.MinimizeBox = false; // tắt nút minimize

            //PANEL TOP
            panel_Top.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            panel_Top.Size = new Size(SCREEN_WIDTH, 100);
            panel_Top.Dock = DockStyle.Top;


            //PANEL LEFT
            panel_Left.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            panel_Left.Size = new Size(360, SCREEN_HEIGHT - panel_Top.Height);
            panel_Left.Dock = DockStyle.Left;
            panel_Left.FlowDirection = FlowDirection.TopDown;
            panel_Left.WrapContents = false;
            panel_Left.AutoScroll = true;

            //PANEL MAIN
            panel_Main.Size = new Size(SCREEN_WIDTH - panel_Left.Width, SCREEN_HEIGHT - panel_Top.Height);
            panel_Main.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            panel_Main.Dock = DockStyle.Fill;

            //BUTTON ĐĂNG XUẤT
            button_DangXuat.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_DangXuat.FlatStyle = FlatStyle.Flat;
            button_DangXuat.FlatAppearance.BorderSize = 0;

            //BUTTON THÔNG BÁO
            button_ThongBao.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_ThongBao.FlatStyle = FlatStyle.Flat;
            button_ThongBao.FlatAppearance.BorderSize = 0;

            //BUTTON THÔNG TIN
            button_ThongTin.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_ThongTin.FlatStyle = FlatStyle.Flat;
            button_ThongTin.FlatAppearance.BorderSize = 0;

            //BUTTON TRANG CHỦ
            button_TrangChu.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_TrangChu.FlatStyle = FlatStyle.Flat;
            button_TrangChu.FlatAppearance.BorderSize = 0;



            //BUTTON HỌC PHẦN
            button_HocPhan.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_HocPhan.FlatStyle = FlatStyle.Flat;
            button_HocPhan.FlatAppearance.BorderSize = 0;

            //BUTTON ĐỀ THI
            button_DeThi.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_DeThi.FlatStyle = FlatStyle.Flat;
            button_DeThi.FlatAppearance.BorderSize = 0;

            //BUTTON NHÓM HỌC PHẦN
            button_NhomHocPhan.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_NhomHocPhan.FlatStyle = FlatStyle.Flat;
            button_NhomHocPhan.FlatAppearance.BorderSize = 0;

            //BUTTON ĐỀ KIỂM TRA
            button_DeKiemTra.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_DeKiemTra.FlatStyle = FlatStyle.Flat;
            button_DeKiemTra.FlatAppearance.BorderSize = 0;

            //BUTTON CÂU HỎI
            button_CauHoi.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_CauHoi.FlatStyle = FlatStyle.Flat;
            button_CauHoi.FlatAppearance.BorderSize = 0;

            //BUTTON THÔNG BÁO ADMIN
            button_ThongBaoAdmin.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_ThongBaoAdmin.FlatStyle = FlatStyle.Flat;
            button_ThongBaoAdmin.FlatAppearance.BorderSize = 0;

            //BUTTON MÔN HỌC
            button_MonHoc.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_MonHoc.FlatStyle = FlatStyle.Flat;
            button_MonHoc.FlatAppearance.BorderSize = 0;

            //BUTTON PHÂN CÔNG
            button_PhanCong.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_PhanCong.FlatStyle = FlatStyle.Flat;
            button_PhanCong.FlatAppearance.BorderSize = 0;

            //BUTTON PHÂN QUYỀN
            button_PhanQuyen.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_PhanQuyen.FlatStyle = FlatStyle.Flat;
            button_PhanQuyen.FlatAppearance.BorderSize = 0;

            //ADD CÁC BUTTON VÔ PANEL LEFT
            panel_Left.Controls.Add(button_TrangChu);
            panel_Left.Controls.Add(button_HocPhan);
            panel_Left.Controls.Add(button_DeThi);
            panel_Left.Controls.Add(button_NhomHocPhan);
            panel_Left.Controls.Add(button_DeKiemTra);
            panel_Left.Controls.Add(button_CauHoi);
            panel_Left.Controls.Add(button_ThongBaoAdmin);
            panel_Left.Controls.Add(button_MonHoc);
            panel_Left.Controls.Add(button_PhanCong);
            panel_Left.Controls.Add(button_PhanQuyen);

            //ADD COMPONENT TRANG CHỦ VÀO PANEL MAIN
            hp.Dock = DockStyle.Fill;
            tc.Dock = DockStyle.Fill;
            dt.Dock = DockStyle.Fill;
            nhp.Dock = DockStyle.Fill;
            dkt.Dock = DockStyle.Fill;
            ch.Dock = DockStyle.Fill;
            tba.Dock = DockStyle.Fill;
            mh.Dock = DockStyle.Fill;
            pc.Dock = DockStyle.Fill;
            pq.Dock = DockStyle.Fill;
            tb.Dock = DockStyle.Fill;
            ttcn.Dock = DockStyle.Fill;



            panel_Main.Controls.Add(hp);
            panel_Main.Controls.Add(tc);
            panel_Main.Controls.Add(dt);
            panel_Main.Controls.Add(nhp);
            panel_Main.Controls.Add(dkt);
            panel_Main.Controls.Add(ch);
            panel_Main.Controls.Add(tba);
            panel_Main.Controls.Add(mh);
            panel_Main.Controls.Add(pc);
            panel_Main.Controls.Add(pq);
            panel_Main.Controls.Add(tb);
            panel_Main.Controls.Add(ttcn);



            tc.BringToFront(); // Hiển thị component Trang Chủ lên trên cùng khi load form

        }

        private void button_HocPhan_Click(object sender, EventArgs e)
        {
            hp.BringToFront();
        }

        private void button_TrangChu_Click(object sender, EventArgs e)
        {
            tc.BringToFront();
        }

        private void button_PhanQuyen_Click(object sender, EventArgs e)
        {
            pq.BringToFront();
        }

        private void button_PhanCong_Click(object sender, EventArgs e)
        {
            pc.BringToFront();
        }

        private void button_MonHoc_Click(object sender, EventArgs e)
        {
            mh.BringToFront();
        }

        private void button_ThongBaoAdmin_Click(object sender, EventArgs e)
        {
            tba.BringToFront();
        }

        private void button_CauHoi_Click(object sender, EventArgs e)
        {
            ch.BringToFront();
        }

        private void button_DeKiemTra_Click(object sender, EventArgs e)
        {
            dkt.BringToFront();
        }

        private void button_NhomHocPhan_Click(object sender, EventArgs e)
        {
            nhp.BringToFront();
        }

        private void button_DeThi_Click(object sender, EventArgs e)
        {
            dt.BringToFront();
        }

        private void button_ThongBao_Click(object sender, EventArgs e)
        {
            tb.BringToFront();
        }

        private void button_ThongTin_Click(object sender, EventArgs e)
        {
            ttcn.BringToFront();
        }
    }
}
