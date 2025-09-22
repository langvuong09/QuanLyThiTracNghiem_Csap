using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class CTNhomQuyen
    {
        public string quyen {  get; set; }
        public string tenQuyen {  get; set; }
        public int xem {  get; set; }
        public int them { get; set; }
        public int capNhat {  get; set; }
        public int xoa { get; set; }

        public CTNhomQuyen() { }
        public CTNhomQuyen(string quyen, string tenQuyen, int xem, int them, int capNhat, int xoa)
        {
            this.quyen = quyen;
            this.tenQuyen = tenQuyen;
            this.xem = xem;
            this.them = them;
            this.capNhat = capNhat;
            this.xoa = xoa;
        }
    }
}
