using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class GiaoVien
    {
        public string maGiaoVien {  get; set; }
        public string tenGiaoVien { get; set; }
        public string email { get; set; }
        public string SDT { get; set; }
        public string moTa { get; set; }
        public string quyen { get; set; }

        public GiaoVien() { }
        public GiaoVien(string maGiaoVien, string tenGiaoVien, string email, string sDT, string moTa, string quyen)
        {
            this.maGiaoVien = maGiaoVien;
            this.tenGiaoVien = tenGiaoVien;
            this.email = email;
            SDT = sDT;
            this.moTa = moTa;
            this.quyen = quyen;
        }
    }
}
