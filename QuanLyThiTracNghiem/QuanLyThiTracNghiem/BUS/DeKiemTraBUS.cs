using MySqlX.XDevAPI.Common;
using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * File: DeKiemTraBUS.cs
 * Mô tả: BUS cho bảng dekiemtra
 * Chức năng:
 *   - Tạo đề thi mới
 *   - Cập nhật đề thi
 *   - Xóa đề thi
 *   - Lấy danh sách đề thi
 */
namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class DeKiemTraBUS
    {

        private DeKiemTraDAO deKiemTraDAO = new DeKiemTraDAO();
        private BaiLamDAO SinhVien_DeKiemTraDAO = new BaiLamDAO();
        private DeKiemTra_NhomDAO deKiemTra_NhomDAO = new DeKiemTra_NhomDAO();
        public DeKiemTraBUS() { }
        
        /*
         Phương thức tạo đề thi
         Input: DeKiemTra deThi - Đề thi
         Output: bool
         Created by: Hoàng Quyên
         */
        public bool CreateDeThi(DeKiemTra deThi)
        {
            try
            {
                // Tạo mã đề thi tự động 
                int maDe = GetNextMaDe();

                return deKiemTraDAO.ThemDeKiemTra(
                    maDe,
                    deThi.tenDe,
                    deThi.thoiGianBatDau,
                    deThi.thoiGianKetThuc,
                    deThi.thoiGianCanhBao,
                    deThi.maMonHoc,
                    deThi.soCauDe,
                    deThi.soCauTrungBinh,
                    deThi.soCauKho
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo đề thi: {ex.Message}");
                return false;
            }
        }

    
        /*
         Phương thức cập nhật đề thi
         Input: DeKiemTra deThi - Đề thi
         Output: bool
         Created by: Hoàng Quyên
         */
        public bool UpdateDeThi(DeKiemTra deThi)
        {
            try
            {
                return deKiemTraDAO.SuaDeKiemTra(
                    deThi.maDe,
                    deThi.tenDe,
                    deThi.thoiGianBatDau,
                    deThi.thoiGianKetThuc,
                    deThi.thoiGianCanhBao,
                    deThi.maMonHoc,
                    deThi.soCauDe,
                    deThi.soCauTrungBinh,
                    deThi.soCauKho
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật đề thi: {ex.Message}");
                return false;
            }
        }
 
       
        /*
         Phương thức xóa đề thi
         Input: int maDe - Mã đề thi
         Output: bool
         Created by: Hoàng Quyên
         */
        public bool DeleteDeThi(int maDe)
        {
            try
            {
                return deKiemTraDAO.XoaDeKiemTra(maDe);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa đề thi: {ex.Message}");
                return false;
            }
        }

        // Lấy mã đề thi tiếp theo (max + 1)
        private int GetNextMaDe()
        {
            int maxMaDe = deKiemTraDAO.GetMaxMaDe();
            return maxMaDe + 1;
        }

        public int GetMaxMaDe()
        {
            return deKiemTraDAO.GetMaxMaDe();
        }

        /*
         Phương thức lấy danh sách đề thi
         Input: none
         Output: List<DeKiemTra>
         Created by: Hoàng Quyên
         */

        public List<DeKiemTra> GetListDeKiemTra()
        {
            try
            {
                ArrayList arrayList = deKiemTraDAO.GetListDeKiemTra();
                List<DeKiemTra> result = new List<DeKiemTra>();

                if (arrayList != null)
                {
                    foreach (DeKiemTra item in arrayList)
                    {
                        result.Add(item);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách đề thi: {ex.Message}");
                return new List<DeKiemTra>();
            }
        }

        

        /*
         Kiểm tra thòi gian để có mở form làm bài hay không
             Input: DeKTra_Mon_Nhom dekiemtra
             Output: bool
             Created by: Hoàng Quyên
         */
        public bool KiemTraBaiThi(DeKTra_Mon_Nhom dekiemtra)
        {
            // Kiểm tra bài làm đã kết thúc chưa
            if (dekiemtra.DeKiemTra.thoiGianKetThuc <= DateTime.Now)
            {
                Console.WriteLine("Bài kiểm tra đã kết thúc.");
                MyDialog dialog = new MyDialog("Bài kiểm tra đã kết thúc rồi.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return false;
            }
            else
            {
                // Thời điểm hiện tại
                DateTime thoiGianHienTai = DateTime.Now;

                // Cho phép vào muộn tối đa 5 phút
                DateTime thoiGianChoPhepVaoMuon = dekiemtra.DeKiemTra.thoiGianBatDau.AddMinutes(5);

                if (thoiGianHienTai < dekiemtra.DeKiemTra.thoiGianBatDau)
                {
                    // Chưa đến giờ làm bài
                    MyDialog dialog = new MyDialog("Chưa đến giờ làm bài. Vui lòng đợi đến khi bài kiểm tra bắt đầu.", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                    return false;
                }
                else if (thoiGianHienTai > thoiGianChoPhepVaoMuon)
                {
                    // Đã trễ quá 5 phút
                    MyDialog dialog = new MyDialog("Bạn đã đến trễ hơn 5 phút, không thể vào làm bài kiểm tra.", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                    return false;
                }
                else
                {
                    // Được phép làm bài (trong thời gian hợp lệ)
                    Console.WriteLine("Bắt đầu làm bài kiểm tra...");
                    return true;
                }
            }

            //Kiểm tra xem bài kiểm tra có phải là bài kiểm tra chính thức không <Nếu chính thức thì chỉ cho làm một lần thôi>
            if (dekiemtra.DeKiemTra.trangThai == 1) { //=>  nghĩa là đây là đề thi chính thức
                bool flag = SinhVien_DeKiemTraDAO.KiemTraTonTaiBaiLam(dekiemtra.DeKiemTra.maDe, UserSession.userId);
                if (flag==true){
                    MyDialog dialog = new MyDialog("Bạn đã làm bài kiểm tra này rồi. Không thể làm lại lần 2.", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                    return false;
                }
            
            }

        }
        /*
         Phương thức dùng để đổ dữ liệu item_DeThi danh sách bài kiểm tra vào panel
            Input :FlowLayoutPanel flowLayoutPanel_Main,ComboBox comboBox_LocTheoNhom, Form panel_TrangChu,string maSinhVien, int currentPage, int pageSize, ComboBox ComboBox_PhanTrang
            Output: int
            Created by: Đỗ Mai Anh
            Dùng trong : Component_DeThi
         */


        public int GetDeKTra_Mon_NhomPhanTrang(
            FlowLayoutPanel flowLayoutPanel_Main,
            ComboBox comboBox_LocTheoNhom,
            Form panel_TrangChu,
            string maSinhVien,
            int currentPage,
            int pageSize)
        {
            // Xóa hết các item cũ trước khi load lại
            flowLayoutPanel_Main.Controls.Clear();

            int? maNhom = null;

            if (comboBox_LocTheoNhom.SelectedItem is Nhom selectedNhom && selectedNhom.maNhom != 0)
            {
                maNhom = selectedNhom.maNhom;
            }

            // Lấy dữ liệu từ DAO
            var result = deKiemTraDAO.GetDeKTra_Mon_Nhom(maSinhVien, currentPage, pageSize, maNhom);

            if (result.Data == null || result.Data.Count == 0)
                return 0;

            List<DeKTra_Mon_Nhom> dsDeKiemTra = result.Data;

            foreach (var dekiemtra in dsDeKiemTra)
            {
                var item = new Panel_ItemDeThi(dekiemtra);

                item.XemChiTietClicked += (s, e2) =>
                {
                    using (Form formThongTin = new Form())
                    {
                        formThongTin.Text = "THÔNG TIN BÀI THI";
                        formThongTin.FormBorderStyle = FormBorderStyle.FixedDialog;
                        formThongTin.StartPosition = FormStartPosition.CenterParent;
                        formThongTin.ClientSize = new Size(824, 834);
                        formThongTin.AutoScroll = true;
                        formThongTin.ShowInTaskbar = false;

                        var dialog = new Dialog_BatDauLamBaiThi(dekiemtra)
                        {
                            Dock = DockStyle.Fill
                        };
                        // Kiểm tra thòi gian nếu là true thì mở formLamBaiThi

                        dialog.LamBaiClicked += (ss, ee) =>
                        {
                            if (KiemTraBaiThi(dekiemtra))
                            {
                                //int maDe, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, DateTime thoiGianCanhBao
                                using (LamBaiThi fLamBai = new LamBaiThi(dekiemtra.DeKiemTra.maDe, dekiemtra.DeKiemTra.thoiGianBatDau, dekiemtra.DeKiemTra.thoiGianKetThuc, dekiemtra.DeKiemTra.thoiGianCanhBao, dekiemtra.DeKiemTra.trangThai))
                                {
                                    fLamBai.TroVeClicked += (sss, eee) =>
                                    {
                                        fLamBai.Close();
                                        formThongTin.Show();
                                    };

                                    formThongTin.Hide();
                                    fLamBai.ShowDialog(formThongTin);
                                }
                            }
                        };

                        formThongTin.Controls.Add(dialog);
                        formThongTin.ShowDialog(panel_TrangChu);
                    }
                };

                flowLayoutPanel_Main.Controls.Add(item);
            }

            return result.TotalRows;
        }

        /*
         Phương thức dùng để tìm kiếm theo mã dê
            Input :FlowLayoutPanel flowLayoutPanel_Main, Form panel_TrangChu,string maSinhVien, string noiDungTimKiem
            Output: none
            Created by: Đỗ Mai Anh
            Dùng trong : Component_DeThi
         */

        public void TimKiemTheoMaDeHoacTen(FlowLayoutPanel flowLayoutPanel_Main, Form panel_TrangChu, string maSinhVien, string noiDungTimKiem)
        {
            // Xóa hết các item cũ trước khi load lại
            flowLayoutPanel_Main.Controls.Clear();
            List<DeKTra_Mon_Nhom> dsDeKiemTra = deKiemTraDAO.SearchDeKTra_Mon_Nhom(maSinhVien,noiDungTimKiem);

            foreach (var dekiemtra in dsDeKiemTra)
            {
                var item = new Panel_ItemDeThi(dekiemtra);

                item.XemChiTietClicked += (s, e2) =>
                {
                    using (Form formThongTin = new Form())
                    {
                        formThongTin.Text = "THÔNG TIN BÀI THI";
                        formThongTin.FormBorderStyle = FormBorderStyle.FixedDialog;
                        formThongTin.StartPosition = FormStartPosition.CenterParent;
                        formThongTin.ClientSize = new Size(824, 834);
                        formThongTin.AutoScroll = true;
                        formThongTin.ShowInTaskbar = false;

                        var dialog = new Dialog_BatDauLamBaiThi(dekiemtra)
                        {
                            Dock = DockStyle.Fill
                        };

                        // Kiểm tra thòi gian nếu là true thì mở formLamBaiThi
                        dialog.LamBaiClicked += (ss, ee) =>
                        {
                            if (KiemTraBaiThi(dekiemtra))
                            {
                                using (LamBaiThi fLamBai = new LamBaiThi(dekiemtra.DeKiemTra.maDe, dekiemtra.DeKiemTra.thoiGianBatDau, dekiemtra.DeKiemTra.thoiGianKetThuc, dekiemtra.DeKiemTra.thoiGianCanhBao, dekiemtra.DeKiemTra.trangThai))
                                {
                                    fLamBai.TroVeClicked += (sss, eee) =>
                                    {
                                        fLamBai.Close();
                                        formThongTin.Show();
                                    };

                                    formThongTin.Hide();
                                    fLamBai.ShowDialog(formThongTin);
                                }
                            }
                        };

                        formThongTin.Controls.Add(dialog);
                        formThongTin.ShowDialog(panel_TrangChu);
                    }
                };

                flowLayoutPanel_Main.Controls.Add(item);
            }
        }

        public ArrayList GetListDeKiemTraTheoMaNhom(int maNhom)
        {
            ArrayList dsdkt = deKiemTraDAO.GetListDeKiemTra();
            ArrayList dsdkt_n = deKiemTra_NhomDAO.GetListDKT_NhomByMaNhom(maNhom);
            ArrayList arrayList = new ArrayList();
            foreach (DeKiemTra dkt in dsdkt)
            {
                foreach (DeKiemTra_Nhom dkt_n in dsdkt_n)
                {
                    if (dkt.maDe == dkt_n.maDe)
                    {
                        arrayList.Add(dkt);
                    }
                }
            }
            return arrayList;
        }
    }
}
