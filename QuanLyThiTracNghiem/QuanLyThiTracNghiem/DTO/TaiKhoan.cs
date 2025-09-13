using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class TaiKhoan
    {
        public int Id { get; set; }
        public string password { get; set; }

        public TaiKhoan() { }
        public TaiKhoan(int Id, string password)
        {
            this.Id = Id;
            this.password = password;

        }
    }
}
