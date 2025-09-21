using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class DeKiemTra
    {
        public int maDe {  get; set; }
        public string tenDe { get; set; }
        public DateTime thoiGianBatDau { get; set; }
        public DateTime thoiGianKetThuc { get; set; }
        public DateTime thoiGianCanhBao {  get; set; }
        public string maMonHoc {  get; set; }
        public int soCauDe { get; set; }
        public int soCauTrungBinh { get; set; }
        public int soCauKho {  get; set; }
        public int trangThai {  get; set; }

        public DeKiemTra() { }
        public DeKiemTra (int maDe, string tenDe, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, DateTime thoiGianCanhBao, string maMonHoc, int soCauDe, int soCauTrungBinh, int soCauKho, int trangThai)
        {
            this.maDe = maDe;
            this.tenDe = tenDe;
            this.thoiGianBatDau = thoiGianBatDau;
            this.thoiGianKetThuc = thoiGianKetThuc;
            this.thoiGianCanhBao = thoiGianCanhBao;
            this.maMonHoc = maMonHoc;
            this.soCauDe = soCauDe;
            this.soCauTrungBinh = soCauTrungBinh;
            this.soCauKho = soCauKho;
            this.trangThai = trangThai;
        }
    }
}
