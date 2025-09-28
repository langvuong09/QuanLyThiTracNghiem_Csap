using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class Nhom
    {
        public int maNhom {  get; set; }
        public string tenNhom { get; set; }
        public string ghiChu { get; set; }
        public string maMonHoc { get; set; }
        public string maGiaoVien { get; set; }
        public int namHoc { get; set; }
        public int hocKy { get; set; }
        public int soLuong { get; set; }
    }
}
