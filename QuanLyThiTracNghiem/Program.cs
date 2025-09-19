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

            // Bật giao diện hệ thống
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy ứng dụng với ApplicationContext tùy chỉnh
            Application.Run(new MyAppContext());
        }
    }

    /// <summary>
    /// ApplicationContext giúp quản lý form chính động,
    /// không bị thoát app khi đóng form đầu tiên.
    /// </summary>
    public class MyAppContext : ApplicationContext
    {
        public MyAppContext()
        {
            // Form đầu tiên bạn muốn mở 
            Form startForm = new Login();

            // Khi form này đóng, kiểm tra còn form nào mở không
            startForm.FormClosed += (s, e) =>
            {
                if (Application.OpenForms.Count == 0)
                    // Thoát app khi không còn form nào
                    ExitThread(); 
            };

            startForm.Show();
        }
    }
}