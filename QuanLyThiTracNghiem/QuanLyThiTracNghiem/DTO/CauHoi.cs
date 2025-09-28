using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class CauHoi
    {
        public int maCauHoi {  get; set; }
        public string maMonHoc { get; set; }
        public int maChuong {  get; set; }
        public string doKho {  get; set; }
        public string noiDungCauHoi { get; set; }

        public CauHoi() { }
        public CauHoi(int maCauHoi, string maMonHoc, int maChuong, string doKho, string noiDungCauHoi)
        {
            this.maCauHoi = maCauHoi;
            this.maMonHoc = maMonHoc;
            this.maChuong = maChuong;
            this.doKho = doKho;
            this.noiDungCauHoi = noiDungCauHoi;
        }
    }
}
