using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class NhomQuyen
    {
        public string quyen {  get; set; }

        public NhomQuyen() { }
        public NhomQuyen(string quyen)
        {
            this.quyen = quyen;
        }
    }
}
