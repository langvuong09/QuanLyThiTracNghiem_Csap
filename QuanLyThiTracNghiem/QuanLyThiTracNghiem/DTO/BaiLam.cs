using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class BaiLam
    {
        public int maBaiLam {  get; set; }
        public string maSinhVien {  get; set; }
        public int maDe {  get; set; }
        public float tongDiem { get; set; }

        public BaiLam() { }
        public BaiLam(int maBaiLam, string maSinhVien, int maDe, float tongDiem)
        {
            this.maBaiLam = maBaiLam;
            this.maSinhVien = maSinhVien;
            this.maDe = maDe;
            this.tongDiem = tongDiem;
        }
    }
}
