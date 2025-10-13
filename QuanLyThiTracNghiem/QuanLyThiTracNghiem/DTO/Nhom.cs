using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class Nhom
    {
        public int maNhom {  get; set; }
        public string tenNhom { get; set; }
        public string ghiChu { get; set; }
        public string maMonHoc { get; set; }
        public string maGiaoVien { get; set; }
        public int namHoc { get; set; }
        public int hocKy { get; set; }
        public int soLuong { get; set; }

        public Nhom() { }
        public Nhom (int maNhom, string tenNhom, string ghiChu, string maMonHoc, string maGiaoVien, int namHoc, int hocKy, int soLuong)
        {
            this.maNhom = maNhom;
            this.tenNhom = tenNhom;
            this.ghiChu = ghiChu;
            this.maMonHoc = maMonHoc;
            this.maGiaoVien = maGiaoVien;
            this.namHoc = namHoc;
            this.hocKy = hocKy;
            this.soLuong = soLuong;
        }
        public Nhom(int maNhom, string tenNhom)
        {
            this.maNhom = maNhom;
            this.tenNhom = tenNhom;
            this.ghiChu = "";
            this.maMonHoc = "";
            this.maGiaoVien = "";
            this.namHoc = 0;
            this.hocKy = 0;
            this.soLuong = 0;
        }
    }
}
