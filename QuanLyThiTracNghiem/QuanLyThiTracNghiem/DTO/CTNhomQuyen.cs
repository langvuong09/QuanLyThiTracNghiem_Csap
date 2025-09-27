using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class CTNhomQuyen
    {
        public int maQuyen {  get; set; }
        public int maChucNang {  get; set; }
        public string tenChucNang { get; set; } = "";
        public int xem {  get; set; }
        public int them { get; set; }
        public int capNhat {  get; set; }
        public int xoa { get; set; }

        public CTNhomQuyen() { }
        public CTNhomQuyen(int maQuyen, int maChucNang, int xem, int them, int capNhat, int xoa)
        {
            this.maQuyen = maQuyen;
            this.maChucNang = maChucNang;
            this.xem = xem;
            this.them = them;
            this.capNhat = capNhat;
            this.xoa = xoa;
        }

        public CTNhomQuyen(int maQuyen, int maChucNang, string tenChucNang, int xem, int them, int capNhat, int xoa)
        {
            this.maQuyen = maQuyen;
            this.maChucNang = maChucNang;
            this.tenChucNang = tenChucNang;
            this.xem = xem;
            this.them = them;
            this.capNhat = capNhat;
            this.xoa = xoa;
        }
    }
}
