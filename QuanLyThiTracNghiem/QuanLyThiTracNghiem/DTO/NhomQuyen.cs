﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class NhomQuyen
    {
        public int maQuyen {  get; set; }
        public string tenQuyen {  get; set; }

        public NhomQuyen() { }
        public NhomQuyen(int maQuyen,string quyen)
        {
            this.maQuyen = maQuyen;
            this.tenQuyen = quyen;
        }
    }
}
