using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace Bukufy_Customer.models
{
    class Customer
    {
        private int id_customer;
        private string username = "", password = "", email = "", password2 = "", no_hp = "", no_rekening = "", nama_lengkap = "", alamat = "", kota = "", provinsi = "", foto_profil = "";
        MySqlConnection conn;

        public Customer()
        {
            Connection koneksi = new Connection();
            conn = koneksi.doConnect();
        }
        public int Id
        {
            get { return id_customer; }
            set { id_customer = value; }
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

        public string Password2
        {
            get { return password2; }
            set { password2 = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string No_hp
        {
            get { return no_hp; }
            set { no_hp = value; }
        }

        public string No_rekening
        {
            get { return no_rekening; }
            set { no_rekening = value; }
        }
        public string Nama_lengkap
        {
            get { return nama_lengkap; }
            set { nama_lengkap = value; }
        }
        public string Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }
        public string Kota
        {
            get { return kota; }
            set { kota = value; }
        }
        public string Provinsi
        {
            get { return provinsi; }
            set { provinsi = value; }
        }
        public string Foto_profil
        {
            get { return foto_profil; }
            set { foto_profil = value; }
        }
        public List<Customer> getAll()
        {
            String query = "SELECT * FROM Customer";
            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Customer> Customers = new List<Customer>();
            while (reader.Read())
            {
                Customer Customer = new Customer();
                Customer.id_customer = int.Parse(reader["id_customer"].ToString());
                Customer.username = reader["username"].ToString();
                Customer.password = reader["password"].ToString();
                Customers.Add(Customer);
            }

            return Customers;
        }

        public bool insertData(Customer dataCustomer)
        {
            string query = $"INSERT INTO customer VALUES(" +
                $"'','{dataCustomer.username}','{dataCustomer.email}','','{dataCustomer.password}','','','','','',''" +
                $")";
            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
