using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    internal class UserSession
    {
        public static string userId { get; set; }
        public static string password { get; set; }
        public static string username { get; set; }

        public static int Quyen { get; set; }
    }
}
