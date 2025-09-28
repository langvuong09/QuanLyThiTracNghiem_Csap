using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class Chuong
    {
        public int maChuong {  get; set; }
        public string maMonHoc { get; set; }
        public string tenChuong { get; set; }

        public Chuong() { }
        public Chuong(int maChuong, string maMonHoc, string tenChuong)
        {
            this.maChuong = maChuong;
            this.maMonHoc = maMonHoc;
            this.tenChuong = tenChuong;
        }
    }
}
