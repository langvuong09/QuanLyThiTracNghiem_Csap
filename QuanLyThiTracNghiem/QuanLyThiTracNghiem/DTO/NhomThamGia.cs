using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class NhomThamGia
    {
        public int maNhom {  get; set; }
        public string maSinhVien {  get; set; }

        public NhomThamGia() { }
        public NhomThamGia(int maNhom, string maSinhVien)
        {
            this.maNhom = maNhom;
            this.maSinhVien = maSinhVien;
        }
    }
}
