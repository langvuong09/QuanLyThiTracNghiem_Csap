using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class SinhVien
    {
        public string maSinhVien {  get; set; }
        public string hoVaTen { get; set; }
        public string email {  get; set; }
        public string gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public string anhDaiDien { get; set; }
        public string quyen {  get; set; }

        public SinhVien() { }
        public SinhVien(string maSinhVien, string hoVaTen, string email, string gioiTinh, DateTime ngaySinh, string anhDaiDien, string quyen)
        {
            this.maSinhVien = maSinhVien;
            this.hoVaTen = hoVaTen;
            this.email = email;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.anhDaiDien = anhDaiDien;
            this.quyen = quyen;
        }
    }
}
