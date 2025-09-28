using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class ThongBao_Nhom
    {
        public int maNhom {  get; set; }
        public int maThongBao {  get; set; }

        public ThongBao_Nhom() { }
        public ThongBao_Nhom(int maNhom, int maThongBao)
        {
            this.maNhom = maNhom;
            this.maThongBao = maThongBao;
        }
    }
}
