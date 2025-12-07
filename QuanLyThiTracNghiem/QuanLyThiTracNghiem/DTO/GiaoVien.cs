using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class GiaoVien
    {
        public string maGiaoVien {  get; set; }
        public string tenGiaoVien { get; set; }
        public string email { get; set; }
        public string gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }

        public string anhDaiDien { get; set; }

        public int quyen { get; set; }

        public GiaoVien() { }
       
    }
}
