using System;

using MySql.Data.MySqlClient;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    internal class MyConnect
    {
        private string server = "localhost";
        private string port = "3306";
        private string database = "quanlythitracnghiem";
        private string username = "qluser";
        //private string username = "root";
        private string password = "";
        public MySqlConnection GetConnection()
        {
            string connString = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password};SslMode=none;";
            return new MySqlConnection(connString);
        }

        public void TestConnection()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    Console.WriteLine("Connection successful!");
                    Console.WriteLine($"Server: {conn.DataSource}");
                    Console.WriteLine($"Database: {conn.Database}");
                    Console.WriteLine($"State: {conn.State}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
            }
        }

        internal void closeConnection()
        {
            throw new NotImplementedException();
        }

        internal void openConnection()
        {
            throw new NotImplementedException();
        }
    }
}
