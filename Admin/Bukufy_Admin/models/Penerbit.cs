using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Bukufy_Admin.models
{
    class Penerbit
    {
        public int id_penerbit;
        public string nama = "", alamat = "";
        MySqlConnection conn;

        public Penerbit()
        {
            Connection connection = new Connection();
            conn = connection.doConnect();
        }

        public List<Penerbit> getAll()
        {
            string query = "SELECT * FROM penerbit";
            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Penerbit> penerbit = new List<Penerbit>();
            while (reader.Read())
            {
                Penerbit p = new Penerbit();
                p.id_penerbit = int.Parse(reader["id_penerbit"].ToString());
                p.nama = reader["nama"].ToString();
                p.alamat = reader["alamat"].ToString();
                penerbit.Add(p);
            }

            return penerbit;
        }
    }
}
