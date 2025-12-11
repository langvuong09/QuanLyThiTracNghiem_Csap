using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI;
using System;
using System.Runtime.InteropServices;


namespace QuanLyThiTracNghiem
{
    internal static class Program
    {
        //[DllImport("kernel32.dll")]
        //private static extern bool AllocConsole();

        [STAThread]
        static void Main()
        {
            //AllocConsole(); // show a console window

            //var db = new QuanLyThiTracNghiem.DAO.MyConnect();
            //db.TestConnection();

            //Console.WriteLine("Press any key...");
            //Console.ReadKey();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            // Chạy ứng dụng với ApplicationContext tùy chỉnh
            Application.Run(new MyAppContext());
        }
    }

        /// <summary>
        /// ApplicationContext giúp quản lý form chính động,
        /// tự động thoát app khi tất cả form đóng.
        /// </summary>
        
        public class MyAppContext : ApplicationContext
    {
        public MyAppContext()
        {
            // Form đầu tiên bạn muốn mở 
            Form startForm = new Login();

            // Subscribe to FormClosed and Shown events for the initial form
            SubscribeToForm(startForm);

            startForm.Show();
        }

        private void SubscribeToForm(Form form)
        {
            if (form != null && !form.IsDisposed)
            {
                form.FormClosed -= OnFormClosed;
                form.FormClosed += OnFormClosed;
                
                form.Shown -= OnFormShown;
                form.Shown += OnFormShown;
            }
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            // When a form is shown, subscribe to it
            if (sender is Form form)
            {
                SubscribeToForm(form);
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            // Subscribe to any remaining forms that might have been opened
            foreach (Form form in Application.OpenForms)
            {
                SubscribeToForm(form);
            }

            // Check if there are any remaining open forms
            if (Application.OpenForms.Count == 0)
            {
                // Exit the application thread when no forms remain
                ExitThread();
            }
        }
    }
}