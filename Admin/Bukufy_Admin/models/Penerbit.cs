using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Bukufy_Admin.models
{
    class Penerbit
    {
        public int id_penerbit;
        public string nama = "", alamat = "";
        private readonly MySqlConnection conn;

        public Penerbit()
        {
            Connection connection = new();
            conn = connection.doConnect();
        }

        public List<Penerbit> getAll()
        {
            string query = "SELECT * FROM penerbit";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Penerbit> penerbit = new();
            while (reader.Read())
            {
                Penerbit p = new Penerbit();
                p.id_penerbit = int.Parse(reader["id_penerbit"].ToString());
                p.nama = reader["nama"].ToString();
                p.alamat = reader["alamat"].ToString();
                penerbit.Add(p);
            }

            conn.Close();
            return penerbit;
        }

        public Penerbit getDataById(int id_penerbit)
        {
            string query = $"SELECT * FROM penerbit WHERE id_penerbit = {id_penerbit}";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            Penerbit penerbit = new();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    penerbit.id_penerbit = int.Parse(reader["id_penerbit"].ToString());
                    penerbit.nama = reader["nama"].ToString();
                    penerbit.alamat = reader["alamat"].ToString();
                }
            }
            conn.Close();

            return penerbit;
        }

        public bool insert(Penerbit penerbit)
        {

            string query = "INSERT INTO penerbit VALUES(" +
                $"'', '{penerbit.nama}', '{penerbit.alamat}')";
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

        public bool update(Penerbit penerbit, int id_penerbit)
        {
            string query = "UPDATE penerbit SET " +
                $"nama='{penerbit.nama}', " +
                $"alamat='{penerbit.alamat}' " +
                $"WHERE id_penerbit={id_penerbit}";
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

        public bool delete(int id_penerbit)
        {
            string query = "DELETE FROM penerbit " +
                $"WHERE id_penerbit={id_penerbit}";
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
