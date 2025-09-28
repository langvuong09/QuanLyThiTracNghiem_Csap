using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class DapAn
    {
        public int maDapAn {  get; set; }
        public int maCauHoi {  get; set; }
        public string tenDapAn {  get; set; }
        public int dungSai {  get; set; }

        public DapAn() { }
        public DapAn(int maDapAn, int maCauHoi, string tenDapAn, int dungSai)
        {
            this.maDapAn = maDapAn;
            this.maCauHoi = maCauHoi;
            this.tenDapAn = tenDapAn;
            this.dungSai = dungSai;
        }
    }
}
