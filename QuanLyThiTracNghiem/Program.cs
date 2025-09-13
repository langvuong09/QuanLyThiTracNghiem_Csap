using System;

using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI;

namespace QuanLyThiTracNghiem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Khởi tạo kết nối CSDL nếu cần
            MyConnect myConnect = new MyConnect();

            // Bật giao diện hệ thống (tương đương với Java Look and Feel)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Hiển thị form đăng nhập
            Login login = new Login();
            Application.Run(login);
        }
    }
}