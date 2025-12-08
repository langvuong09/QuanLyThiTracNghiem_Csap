using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class CauHoi_DeKiemTraBUS
    {
        private CauHoiDAO cauHoiDao=new CauHoiDAO();
        private DapAnDAO dapAnDao=new DapAnDAO();
        private CauHoi_DeKiemTraDAO cauHoi_DeKiemTraDAO = new CauHoi_DeKiemTraDAO();
        /*
         Phương thức xử lí thêm itemCauHoi vào Panel

         */
        public List<Panel_ItemCauHoi> Display_ItemCauHoi_InPanel(FlowLayoutPanel flowLayoutPanel_CauHoi, int maDe, int maBaiLam)
        {
            var dsItem = new List<Panel_ItemCauHoi>();
            var danhSachCauHoi = cauHoiDao.GetListCauHoiTheoMaDe(maDe);

            int sttCauHoi = 1;
            foreach (var cauHoi in danhSachCauHoi)
            {
                var dapAnList = dapAnDao.LayDSDapAnCoDaoCauTheoMaCauHoi(cauHoi.maCauHoi);
                var item = new Panel_ItemCauHoi(maBaiLam);
                item.KhoiTaoCauHoi(sttCauHoi++, cauHoi, dapAnList);
                dsItem.Add(item);
                flowLayoutPanel_CauHoi.Controls.Add(item);
            }

            return dsItem;
        }

        /// <summary>
        /// Tạo câu hỏi tự động cho đề thi dựa trên chương và số câu hỏi theo độ khó
        /// </summary>
        /// <param name="maDe">Mã đề thi</param>
        /// <param name="danhSachMaChuong">Danh sách mã chương</param>
        /// <param name="soCauDe">Số câu dễ</param>
        /// <param name="soCauTrungBinh">Số câu trung bình</param>
        /// <param name="soCauKho">Số câu khó</param>
        /// <returns>true nếu thành công, false nếu thất bại</returns>
        public bool TaoCauHoiTuDongChoDeThi(int maDe, List<int> danhSachMaChuong, int soCauDe, int soCauTrungBinh, int soCauKho)
        {
            try
            {
                Console.WriteLine($"=== Bắt đầu tạo câu hỏi cho đề thi {maDe} ===");
                Console.WriteLine($"Số chương: {danhSachMaChuong?.Count ?? 0}, Số câu dễ: {soCauDe}, TB: {soCauTrungBinh}, Khó: {soCauKho}");
                
                if (danhSachMaChuong == null || danhSachMaChuong.Count == 0)
                {
                    Console.WriteLine("LỖI: Danh sách chương rỗng, không thể tạo câu hỏi!");
                    return false;
                }

                // Xóa các câu hỏi cũ của đề thi (nếu có)
                Console.WriteLine($"Xóa câu hỏi cũ của đề thi {maDe}...");
                cauHoi_DeKiemTraDAO.XoaCH_DKT(maDe);

                List<int> danhSachMaCauHoi = new List<int>();

                // Lấy và chọn ngẫu nhiên câu hỏi dễ
                if (soCauDe > 0)
                {
                    Console.WriteLine($"Lấy câu hỏi dễ từ {danhSachMaChuong.Count} chương...");
                    List<CauHoi> cauHoiDe = cauHoiDao.GetCauHoiTheoChuongVaDoKho(danhSachMaChuong, "Dễ");
                    Console.WriteLine($"Tìm thấy {cauHoiDe.Count} câu hỏi dễ");
                    if (cauHoiDe.Count < soCauDe)
                    {
                        Console.WriteLine($"CẢNH BÁO: Chỉ có {cauHoiDe.Count} câu dễ, yêu cầu {soCauDe} câu!");
                    }
                    var cauHoiDeChon = cauHoiDe.OrderBy(x => Guid.NewGuid()).Take(Math.Min(soCauDe, cauHoiDe.Count)).ToList();
                    danhSachMaCauHoi.AddRange(cauHoiDeChon.Select(ch => ch.maCauHoi));
                    Console.WriteLine($"Đã chọn {cauHoiDeChon.Count} câu hỏi dễ");
                }

                // Lấy và chọn ngẫu nhiên câu hỏi trung bình
                if (soCauTrungBinh > 0)
                {
                    Console.WriteLine($"Lấy câu hỏi trung bình từ {danhSachMaChuong.Count} chương...");
                    List<CauHoi> cauHoiTB = cauHoiDao.GetCauHoiTheoChuongVaDoKho(danhSachMaChuong, "Trung Bình");
                    Console.WriteLine($"Tìm thấy {cauHoiTB.Count} câu hỏi trung bình");
                    if (cauHoiTB.Count < soCauTrungBinh)
                    {
                        Console.WriteLine($"CẢNH BÁO: Chỉ có {cauHoiTB.Count} câu trung bình, yêu cầu {soCauTrungBinh} câu!");
                    }
                    var cauHoiTBChon = cauHoiTB.OrderBy(x => Guid.NewGuid()).Take(Math.Min(soCauTrungBinh, cauHoiTB.Count)).ToList();
                    danhSachMaCauHoi.AddRange(cauHoiTBChon.Select(ch => ch.maCauHoi));
                    Console.WriteLine($"Đã chọn {cauHoiTBChon.Count} câu hỏi trung bình");
                }

                // Lấy và chọn ngẫu nhiên câu hỏi khó
                if (soCauKho > 0)
                {
                    Console.WriteLine($"Lấy câu hỏi khó từ {danhSachMaChuong.Count} chương...");
                    List<CauHoi> cauHoiKho = cauHoiDao.GetCauHoiTheoChuongVaDoKho(danhSachMaChuong, "Khó");
                    Console.WriteLine($"Tìm thấy {cauHoiKho.Count} câu hỏi khó");
                    if (cauHoiKho.Count < soCauKho)
                    {
                        Console.WriteLine($"CẢNH BÁO: Chỉ có {cauHoiKho.Count} câu khó, yêu cầu {soCauKho} câu!");
                    }
                    var cauHoiKhoChon = cauHoiKho.OrderBy(x => Guid.NewGuid()).Take(Math.Min(soCauKho, cauHoiKho.Count)).ToList();
                    danhSachMaCauHoi.AddRange(cauHoiKhoChon.Select(ch => ch.maCauHoi));
                    Console.WriteLine($"Đã chọn {cauHoiKhoChon.Count} câu hỏi khó");
                }

                Console.WriteLine($"Tổng cộng: {danhSachMaCauHoi.Count} câu hỏi được chọn");

                // Lưu các câu hỏi đã chọn vào bảng cauhoi-dekiemtra
                int successCount = 0;
                int failCount = 0;
                foreach (int maCauHoi in danhSachMaCauHoi)
                {
                    if (cauHoi_DeKiemTraDAO.ThemCH_DKT(maDe, maCauHoi))
                    {
                        successCount++;
                    }
                    else
                    {
                        failCount++;
                        Console.WriteLine($"Lỗi khi lưu câu hỏi {maCauHoi} vào đề thi {maDe}");
                    }
                }

                Console.WriteLine($"=== Kết quả: Đã lưu {successCount}/{danhSachMaCauHoi.Count} câu hỏi cho đề thi {maDe} ===");
                if (failCount > 0)
                {
                    Console.WriteLine($"Có {failCount} câu hỏi không thể lưu!");
                }
                
                return successCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LỖI KHI TẠO CÂU HỎI TỰ ĐỘNG CHO ĐỀ THI: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return false;
            }
        }

    }
}
