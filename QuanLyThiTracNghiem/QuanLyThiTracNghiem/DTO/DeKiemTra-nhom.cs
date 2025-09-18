using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class DeKiemTra_nhom
    {
        public int maDe {  get; set; }
        public int maNhom { get; set; }

        public DeKiemTra_nhom() { }
        public DeKiemTra_nhom(int maDe, int maNhom)
        {
            this.maDe = maDe;
            this.maNhom = maNhom;
        }
    }
}
