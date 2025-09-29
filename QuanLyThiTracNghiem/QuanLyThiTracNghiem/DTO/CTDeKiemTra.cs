using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class CTDeKiemTra
    {
        public int maDe {  get; set; }
        public string maMonHoc {  get; set; }
        public int maChuong { get; set; }
        
        public CTDeKiemTra() { }
        public CTDeKiemTra(int maDe, string maMonHoc, int maChuong)
        {
            this.maDe = maDe;
            this.maMonHoc = maMonHoc;
            this.maChuong = maChuong;
        }
    }
}
