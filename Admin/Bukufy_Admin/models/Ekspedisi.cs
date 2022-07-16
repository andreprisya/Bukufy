using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Bukufy_Admin.models
{
    class Ekspedisi
    {
        public int id_ekspedisi;
        public string username = "", password = "", nama = "", alamat = "";
        private readonly MySqlConnection conn;

        public Ekspedisi()
        {
            Connection connection = new();
            conn = connection.doConnect();
        }

        public List<Ekspedisi> getAll()
        {
            string query = "SELECT * FROM ekspedisi";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Ekspedisi> ekspedisi= new();
            while (reader.Read())
            {
                Ekspedisi e = new();
                e.id_ekspedisi = int.Parse(reader["id_ekspedisi"].ToString());
                e.username= reader["username"].ToString();
                e.password = reader["password"].ToString();
                e.nama = reader["nama"].ToString();
                e.alamat = reader["alamat"].ToString();
                ekspedisi.Add(e);
            }

            conn.Close();
            return ekspedisi;
        }

        public Ekspedisi getDataById(int id_ekspedisi)
        {
            string query = $"SELECT * FROM ekspedisi WHERE id_ekspedisi= {id_ekspedisi}";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            Ekspedisi ekspedisi= new();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    ekspedisi.id_ekspedisi = int.Parse(reader["id_ekspedisi"].ToString());
                    ekspedisi.username = reader["username"].ToString();
                    ekspedisi.password = reader["password"].ToString();
                    ekspedisi.nama = reader["nama"].ToString();
                    ekspedisi.alamat = reader["alamat"].ToString();
                }
            }
            conn.Close();

            return ekspedisi;
        }

        public bool insert(Ekspedisi ekspedisi)
        {

            string query = "INSERT INTO ekspedisi VALUES(" +
                $"'', '{ekspedisi.username}', '{ekspedisi.password}', '{ekspedisi.nama}', '{ekspedisi.alamat}')";
            MySqlCommand command = new(query, conn);
            conn.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return true;
            }
        }

        public bool update(Ekspedisi ekspedisi, int id_ekspedisi)
        {
            string query = "UPDATE ekspedisi SET " +
                $"username='{ekspedisi.username}', " +
                $"password='{ekspedisi.password}', " +
                $"nama='{ekspedisi.nama}', " +
                $"alamat='{ekspedisi.alamat}' " +
                $"WHERE id_ekspedisi={id_ekspedisi}";
            MySqlCommand command = new(query, conn);
            conn.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return true;
            }
        }

        public bool delete(int id_ekspedisi)
        {
            string query = "DELETE FROM ekspedisi " +
                $"WHERE id_ekspedisi={id_ekspedisi}";
            MySqlCommand command = new(query, conn);
            conn.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return true;
            }
        }
    }
}
