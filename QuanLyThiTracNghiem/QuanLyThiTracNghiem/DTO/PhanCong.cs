using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class PhanCong
    {
        public int maPhanCong {  get; set; }
        public string maMonHoc { get; set; }
        public string maGiaoVien {  get; set; }

        public PhanCong() { }
        public PhanCong(int maPhanCong, string maMonHoc, string maGiaoVien)
        {
            this.maPhanCong = maPhanCong;
            this.maMonHoc = maMonHoc;
            this.maGiaoVien = maGiaoVien;
        }
    }
}
