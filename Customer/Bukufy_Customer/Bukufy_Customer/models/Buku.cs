using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bukufy_Customer;
using MySql.Data.MySqlClient;

namespace Bukufy_Admin.models 
{ 
    class Buku
    {
        public int id_buku, harga, stok, id_penerbit;
        public string judul = "", deskripsi = "", penulis = "", gambar = "", penerbit = "";
        MySqlConnection conn;

        public Buku()
        {
            Connection connection = new Connection();
            conn = connection.doConnect();
        }

        public List<Buku> getAll()
        {
            string query = "SELECT b.*, p.nama as penerbit " +
                            "FROM buku b, penerbit p " +
                            "WHERE b.id_penerbit = p.id_penerbit";
            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Buku> buku = new List<Buku>();
            while (reader.Read())
            {
                Buku b = new Buku();
                b.id_buku = int.Parse(reader["id_buku"].ToString());
                b.judul = reader["judul"].ToString();
                b.deskripsi = reader["deskripsi"].ToString();
                b.penulis = reader["penulis"].ToString();
                b.penerbit = reader["penerbit"].ToString();
                b.harga = int.Parse(reader["harga"].ToString());
                b.stok= int.Parse(reader["stok"].ToString());
                b.gambar = reader["gambar"].ToString();
                buku.Add(b);
            }

            return buku;
        }

        public List<Buku> getById(int id)
        {
            string query = "SELECT b.*, p.nama as penerbit " +
                            "FROM buku b, penerbit p" +
                            "WHERE b.id_penerbit = p.id_penerbit" +
                            $"AND b.id_buku = {id}";
            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Buku> buku = new List<Buku>();
            if (reader.HasRows)
            {
                Buku b = new Buku();
                b.id_buku = int.Parse(reader["id_buku"].ToString());
                b.judul = reader["judul"].ToString();
                b.deskripsi = reader["deskripsi"].ToString();
                b.penulis = reader["penulis"].ToString();
                b.penerbit = reader["penerbit"].ToString();
                b.harga = int.Parse(reader["harga"].ToString());
                b.stok = int.Parse(reader["stok"].ToString());
                b.gambar = reader["gambar"].ToString();
                buku.Add(b);
            }

            return buku;
        }

        public bool insertData(Buku dataBuku)
        {
            string query = $"INSERT INTO buku VALUES(" +
                $"'','{dataBuku.judul}','{dataBuku.deskripsi}','{dataBuku.penulis}',{dataBuku.id_penerbit},{dataBuku.harga},{dataBuku.stok},'{dataBuku.gambar}'" +
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

        public bool delete(int id)
        {
            string query = $"DELETE FROM buku WHERE id_buku={id}";
            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();
            if(command.ExecuteNonQuery() > 0)
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
