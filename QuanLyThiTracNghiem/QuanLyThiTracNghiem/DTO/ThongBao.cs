using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class ThongBao
    {
        public int maThongBao {  get; set; }
        public string tenThongBao { get; set; }
        public string noiDung {  get; set; }
        
        public ThongBao() { }
        public ThongBao(int maThongBao, string tenThongBao, string noiDung)
        {
            this.maThongBao = maThongBao;
            this.tenThongBao = tenThongBao;
            this.noiDung = noiDung;
        }
    }
}
