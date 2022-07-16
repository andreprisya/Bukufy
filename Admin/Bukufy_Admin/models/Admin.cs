using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Bukufy_Admin.models
{
    class Admin
    {
        public int id;
        public string username = "", password = "";
        private MySqlConnection conn;

        public Admin(){
            Connection koneksi = new();
            conn = koneksi.doConnect();
        }
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public List<Admin> getAll()
        {
            string query = "SELECT * FROM admin";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Admin> admins = new();
            while (reader.Read())
            {
                Admin admin = new();
                admin.id = int.Parse(reader["id"].ToString());
                admin.username = reader["username"].ToString();
                admin.password = reader["password"].ToString();
                admins.Add(admin);
            }
            
            return admins;
        }

        public void showData()
        {
            List<Admin> admins = getAll();

            foreach (Admin? admin in admins)
            {
                _ = MessageBox.Show("username: " + admin.id);
            }
        }
    }
}
