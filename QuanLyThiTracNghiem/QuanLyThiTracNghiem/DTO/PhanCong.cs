using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class PhanCong
    {
        public int maPhanCong {  get; set; }
        public int maMonHoc { get; set; }
        public string maGiaoVien {  get; set; }

        public PhanCong() { }
        public PhanCong(int maPhanCong, int maMonHoc, string maGiaoVien)
        {
            this.maPhanCong = maPhanCong;
            this.maMonHoc = maMonHoc;
            this.maGiaoVien = maGiaoVien;
        }
    }
}
