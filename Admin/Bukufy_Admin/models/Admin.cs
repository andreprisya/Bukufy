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
        private int id;
        private string username = "", password = "";
        MySqlConnection conn;

        public Admin(){
            Connection koneksi = new Connection();
            conn = koneksi.doConnect();
        }
        public int Id
        {
            get { return id;  }
            set { id = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public List<Admin> getAll()
        {
            String query = "SELECT * FROM admin";
            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Admin> admins = new List<Admin>();
            while (reader.Read())
            {
                Admin admin = new Admin();
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

            foreach(var admin in admins)
            {
                MessageBox.Show("username: " + admin.id);
            }
        }
    }
}
