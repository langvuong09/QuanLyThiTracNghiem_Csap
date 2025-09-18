using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class Quyen
    {
        public string quyen {  get; set; }
        public int thamGiaHoatDong {  get; set; }
        public int qlDeThi {  get; set; }
        public int qlSinhVien {  get; set; }
        public int qlGiaoVien {  get; set; }
        public int qlNhom {  get; set; }
        public int qlPhanCong { get; set; }
        public int qlMon {  get; set; }
        public int qlCauHoi { get; set; }
        public int qlThongBao {  get; set; }

        public Quyen() { }
        public Quyen(string quyen, int thamGiaHoatDong, int qlDeThi, int qlSinhVien, int qlGiaoVien, int qlNhom, int qlPhanCong, int qlMon, int qlCauHoi, int qlThongBao)
        {
            this.quyen = quyen;
            this.thamGiaHoatDong = thamGiaHoatDong;
            this.qlDeThi = qlDeThi;
            this.qlSinhVien = qlSinhVien;
            this.qlGiaoVien = qlGiaoVien;
            this.qlNhom = qlNhom;
            this.qlPhanCong = qlPhanCong;
            this.qlMon = qlMon;
            this.qlCauHoi = qlCauHoi;
            this.qlThongBao = qlThongBao;
        }
    }
}
