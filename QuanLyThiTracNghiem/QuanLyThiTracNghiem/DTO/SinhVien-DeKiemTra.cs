using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class SinhVien_DeKiemTra
    {
        public string maSinhVien {  get; set; }
        public int maDe {  get; set; }

        public SinhVien_DeKiemTra() { }
        public SinhVien_DeKiemTra(string maSinhVien, int maDe)
        {
            this.maSinhVien = maSinhVien;
            this.maDe = maDe;
        }
    }
}
