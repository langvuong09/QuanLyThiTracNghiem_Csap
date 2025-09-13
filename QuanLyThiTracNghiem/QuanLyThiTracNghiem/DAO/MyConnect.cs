using System;

using MySql.Data.MySqlClient;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    internal class MyConnect
    {
        private string server = "localhost";
        private string database = "quanlythitracnghiem";
        private string username = "root";
        private string password = "";

        public MySqlConnection GetConnection()
        {
            string connString = $"Server={server};Database={database};User ID={username};Password={password};";
            return new MySqlConnection(connString);
        }
    }
}
