using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class ChiTietBaiLam
    {
        public int maBaiLam {  get; set; }
        public int maCauHoi { get; set; }
        public int? maDapAnDuocChon { get; set; }

        public ChiTietBaiLam() { }
        public ChiTietBaiLam(int maBaiLam, int maCauHoi, int maDapAnDuocChon)
        {
            this.maBaiLam = maBaiLam;
            this.maCauHoi = maCauHoi;
            this.maDapAnDuocChon = maDapAnDuocChon;
        }
    }
}
