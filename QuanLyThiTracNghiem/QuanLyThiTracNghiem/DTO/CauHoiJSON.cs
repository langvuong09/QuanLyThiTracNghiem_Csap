using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class CauHoiJSON
    {
        public string NoiDung { get; set; } = "";
        public Dictionary<int, string > DapAn { get; set; } = new();
        public int DapAnDung { get; set; } = 0;

        public object ToJsonObject()
        {
            return new
            {
                question = NoiDung,
                answers = DapAn,
                correct = DapAnDung.ToString()
            };
        }
    }
}
