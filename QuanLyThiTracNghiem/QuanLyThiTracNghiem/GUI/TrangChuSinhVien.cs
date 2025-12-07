using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;

using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System.Collections;
using System.Drawing.Drawing2D;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class TrangChuSinhVien : Form
    {
        private NhomQuyenBUS nhomQuyenBus = new NhomQuyenBUS();
        private CTNhomQuyenBUS cTNhomQuyenBUS = new CTNhomQuyenBUS();
        private NhomThamGiaBUS nhomThamGiaBUS = new NhomThamGiaBUS();
        private ThongBaoBUS thongBaoBUS = new ThongBaoBUS();

        public TrangChuSinhVien()
        {
            InitializeComponent();
            customFormTrangChuSinhVien_Load();
            this.Load += TrangChuSinhVien_Load;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += timer1_Tick;                       
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
        private Component_MonHocNguoiDung mhnd = new Component_MonHocNguoiDung();
        private Component_PhanCong pc = new Component_PhanCong();
        private Component_PhanQuyen pq = new Component_PhanQuyen();
        private Component_NguoiDung nd = new Component_NguoiDung();
        private Component_ThongKe tk = new Component_ThongKe();

        //Khai Báo Panel
        
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
            button_ThongTin.TextImageRelation = TextImageRelation.TextBeforeImage;
            button_ThongTin.ImageAlign = ContentAlignment.MiddleRight;
            button_ThongTin.TextAlign = ContentAlignment.MiddleLeft;
            button_ThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_ThongTin.AutoSize = true;
            button_ThongTin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_ThongTin.Padding = new Padding(10, 5, 10, 5);




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
            //BUTTON NGƯỜI DÙNG
            button_NguoiDung.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_NguoiDung.FlatStyle = FlatStyle.Flat;
            button_NguoiDung.FlatAppearance.BorderSize = 0;
            //BUTTON THỐNG KÊ
            button_ThongKe.BackColor = System.Drawing.ColorTranslator.FromHtml("#83A7EE");
            button_ThongKe.FlatStyle = FlatStyle.Flat;
            button_ThongKe.FlatAppearance.BorderSize = 0;

            //panel_Left.Controls.Add(button_HocPhan);
            //panel_Left.Controls.Add(button_DeThi);
            //panel_Left.Controls.Add(button_NhomHocPhan);
            //panel_Left.Controls.Add(button_DeKiemTra);
            //panel_Left.Controls.Add(button_CauHoi);
            //panel_Left.Controls.Add(button_ThongBaoAdmin);
            //panel_Left.Controls.Add(button_MonHoc);
            //panel_Left.Controls.Add(button_PhanCong);
            //panel_Left.Controls.Add(button_PhanQuyen);
            //panel_Left.Controls.Add(button_NguoiDung);

            panel_Left.Controls.Add(button_TrangChu);

            List<CTNhomQuyen> ctquyen = cTNhomQuyenBUS.FindByMaQuyen(UserSession.Quyen);

            foreach (CTNhomQuyen ctnq in ctquyen)
            {
                switch (ctnq.maChucNang)
                {
                    case 1:
                        panel_Left.Controls.Add(button_NguoiDung);
                        break;
                    case 2:
                        panel_Left.Controls.Add(button_HocPhan);
                        break;
                    case 3:
                        panel_Left.Controls.Add(button_CauHoi);
                        break;
                    case 4:
                        panel_Left.Controls.Add(button_MonHoc);
                        break;
                    case 5:
                        panel_Left.Controls.Add(button_PhanCong);
                        break;
                    case 6:
                        panel_Left.Controls.Add(button_DeThi);
                        break;
                    case 7:
                        panel_Left.Controls.Add(button_PhanQuyen);
                        break;
                    case 8:
                        panel_Left.Controls.Add(button_NhomHocPhan);
                        break;                        
                    case 9:
                        panel_Left.Controls.Add(button_DeKiemTra);
                        break;                        
                    case 10:
                        panel_Left.Controls.Add(button_ThongBaoAdmin);
                        break;
                    default:
                        break;
                }
                if(UserSession.Quyen == 1)
                {
                    panel_Left.Controls.Add(button_ThongKe);
                }
            }
            panel_Left.ResumeLayout();

			//ADD COMPONENT TRANG CHỦ VÀO PANEL MAIN
            hp.Dock = DockStyle.Fill;
            tc.Dock = DockStyle.Fill;
            dt.Dock = DockStyle.Fill;
            nhp.Dock = DockStyle.Fill;
            dkt.Dock = DockStyle.Fill;
            ch.Dock = DockStyle.Fill;
            tba.Dock = DockStyle.Fill;
            ArrayList ctpq = cTNhomQuyenBUS.GetListCTNhomQuyen(UserSession.Quyen);
            foreach (CTNhomQuyen pq in ctpq)
            {
                if (pq.maChucNang == 4)
                {
                    if (pq.xem == 0)
                    {
                        mhnd.Dock = DockStyle.Fill;
                        panel_Main.Controls.Add(mhnd);
                    }else
                    {
                        mh.Dock = DockStyle.Fill;
                        panel_Main.Controls.Add(mh);
                    }
                    
                }
            }            
            pc.Dock = DockStyle.Fill;
            pq.Dock = DockStyle.Fill;
            
            ttcn.Dock = DockStyle.Fill;
            nd.Dock = DockStyle.Fill;
            
            panel_Main.Controls.Add(tc);
            panel_Main.Controls.Add(hp);
            panel_Main.Controls.Add(dt);
            panel_Main.Controls.Add(nhp);
            panel_Main.Controls.Add(dkt);
            panel_Main.Controls.Add(ch);
            panel_Main.Controls.Add(tba);
            panel_Main.Controls.Add(mh);
            panel_Main.Controls.Add(pc);
            panel_Main.Controls.Add(pq);            
            panel_Main.Controls.Add(ttcn);
            panel_Main.Controls.Add(nd);
            if (UserSession.Quyen == 1)
            {
                tk.Dock = DockStyle.Fill;
                panel_Main.Controls.Add(tk);
            }
            button_ThongTin.Text = UserSession.username;

            tc.BringToFront(); // Hiển thị component Trang Chủ lên trên cùng khi load form

        }

        private void button_HocPhan_Click(object sender, EventArgs e)
        {
            HighlightButton(button_HocPhan);
            hp.BringToFront();
        }

        private void button_TrangChu_Click(object sender, EventArgs e)
        {
            HighlightButton(button_TrangChu);
            tc.BringToFront();
        }

        private void button_PhanQuyen_Click(object sender, EventArgs e)
        {
            HighlightButton(button_PhanQuyen);
            pq.BringToFront();
        }

        private void button_PhanCong_Click(object sender, EventArgs e)
        {
            HighlightButton(button_PhanCong);
            pc.BringToFront();
        }

        private void button_MonHoc_Click(object sender, EventArgs e)
        {
            HighlightButton(button_MonHoc);
            mh.BringToFront();
        }

        private void button_MonHocNguoiDung_Click(object sender, EventArgs e)
        {
            HighlightButton(button_MonHoc);
            mhnd.BringToFront();
        }

        private void button_ThongBaoAdmin_Click(object sender, EventArgs e)
        {
            HighlightButton(button_ThongBaoAdmin);
            tba.BringToFront();
        }

        private void button_CauHoi_Click(object sender, EventArgs e)
        {
            HighlightButton(button_CauHoi);
            ch.BringToFront();
        }

        private void button_DeKiemTra_Click(object sender, EventArgs e)
        {
            HighlightButton(button_DeKiemTra);
            dkt.BringToFront();
        }

        private void button_NhomHocPhan_Click(object sender, EventArgs e)
        {
            HighlightButton(button_NhomHocPhan);
            nhp.BringToFront();
        }

        private void button_DeThi_Click(object sender, EventArgs e)
        {
            HighlightButton(button_DeThi);
            dt.BringToFront();
        }

        private void button_ThongBao_Click(object sender, EventArgs e)
        {
            Component_ThongBao tb = new Component_ThongBao();
            tb.Dock = DockStyle.Fill;
            panel_Main.Controls.Add(tb);
            BtnNotice_None();
            HighlightButton(button_ThongBao);
            tb.LoadDataLenTableThongBao(UserSession.userId);
            tb.BringToFront();
        }

        private void button_ThongTin_Click(object sender, EventArgs e)
        {
            HighlightButton(button_ThongTin);
            ttcn.BringToFront();
        }

        private void button_NguoiDung_Click(object sender, EventArgs e)
        {
            HighlightButton(button_NguoiDung);
            nd.BringToFront();
        }

        private void button_ThongKe_Click(object sender, EventArgs e)
        {
            HighlightButton(button_ThongKe);
            tk.BringToFront();
        }

        private void ResetButtonColor()
        {
            Color defaultColor = ColorTranslator.FromHtml("#83A7EE");

            button_TrangChu.BackColor = defaultColor;
            button_HocPhan.BackColor = defaultColor;
            button_DeThi.BackColor = defaultColor;
            button_NhomHocPhan.BackColor = defaultColor;
            button_DeKiemTra.BackColor = defaultColor;
            button_CauHoi.BackColor = defaultColor;
            button_ThongBaoAdmin.BackColor = defaultColor;
            button_MonHoc.BackColor = defaultColor;
            button_PhanCong.BackColor = defaultColor;
            button_PhanQuyen.BackColor = defaultColor;
            button_NguoiDung.BackColor = defaultColor;
            button_ThongBao.BackColor = defaultColor;
            button_ThongTin.BackColor = defaultColor;
            button_ThongKe.BackColor = defaultColor;
        }

        private void HighlightButton(Button btn)
        {
            ResetButtonColor(); // Đặt tất cả về mặc định
            btn.BackColor = ColorTranslator.FromHtml("#1E90FF"); // Màu nổi bật, ví dụ xanh đậm
        }

        private void button_DangXuat_Click(object sender, EventArgs e)
        {
            // Hiển thị MessageBox xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đóng form hiện tại
                this.Close();

                // Mở lại form Login
                Login loginForm = new Login();
                loginForm.Show();
            }
        }

        // Các hành động thông báo có thông báo mới
        private void Form1_Load(object sender, EventArgs e)
        {
            MakeButtonCircle(btnNotice);
        }
        private void MakeButtonCircle(Button btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }

        public void BtnNotice_None()
        {
            btnNotice.Visible = false;
        }

        private int lastCount;
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        private void TrangChuSinhVien_Load(object sender, EventArgs e)
        {
            lastCount = thongBaoBUS.GetListThongBaoTheoMaSinhVien(UserSession.userId).Count;

            timer1.Interval = 1000; // kiểm tra mỗi 1 giây
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int newCount = thongBaoBUS.GetListThongBaoTheoMaSinhVien(UserSession.userId).Count;

            if (newCount > lastCount)
            {
                btnNotice.Visible = true;
                lastCount = newCount;
            }
        }
    }
}
