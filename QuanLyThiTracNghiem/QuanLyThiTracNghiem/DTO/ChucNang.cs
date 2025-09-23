using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class ChucNang
    {
        public int maChucNang {  get; set; }
        public string tenChucNang { get; set; }
        public ChucNang() { }
        public ChucNang(int maChucNang, string tenChucNang)
        {
            this.maChucNang = maChucNang;
            this.tenChucNang = tenChucNang;
        }
    }
}
