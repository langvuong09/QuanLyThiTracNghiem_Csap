using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class CauHoi_DeKiemTra
    {
        public int maDe {  get; set; }
        public int maCauHoi {  get; set; }

        public CauHoi_DeKiemTra() { }
        public CauHoi_DeKiemTra(int maDe, int maCauHoi)
        {
            this.maDe = maDe;
            this.maCauHoi = maCauHoi;
        }
    }
}
