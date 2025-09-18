using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class DapAn
    {
        public int maCauHoi {  get; set; }
        public string tenDapAn {  get; set; }
        public int dungSai {  get; set; }

        public DapAn() { }
        public DapAn(int maCauHoi, string tenDapAn, int dungSai)
        {
            this.maCauHoi = maCauHoi;
            this.tenDapAn = tenDapAn;
            this.dungSai = dungSai;
        }
    }
}
