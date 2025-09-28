using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class MonHoc
    {
        public string maMonHoc {  get; set; }
        public string tenMonHoc { get; set; }
        public int tinChi {  get; set; }
        public int soTietLyThuyet { get; set; }
        public int soTietThucHanh { get; set; }
        public int heSo {  get; set; }

        public MonHoc() { }
        public MonHoc(string maMonHoc, string tenMonHoc, int tinChi, int soTietLyThuyet, int soTietThucHanh, int heSo)
        {
            this.maMonHoc = maMonHoc;
            this.tenMonHoc = tenMonHoc;
            this.tinChi = tinChi;
            this.soTietLyThuyet = soTietLyThuyet;
            this.soTietThucHanh = soTietThucHanh;
            this.heSo = heSo;
        }

        public MonHoc(string v1, string v2)
        {
        }
    }
}
