using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class DeKiemTra_Nhom
    {
        public int maDe {  get; set; }
        public int maNhom { get; set; }

        public DeKiemTra_Nhom() { }
        public DeKiemTra_Nhom(int maDe, int maNhom)
        {
            this.maDe = maDe;
            this.maNhom = maNhom;
        }
    }
}
