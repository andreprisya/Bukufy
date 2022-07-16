using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Bukufy_Admin.models 
{ 
    class Buku
    {
        public int id_buku, harga, stok, id_penerbit, sisa_stok;
        public string judul = "", deskripsi = "", penulis = "", gambar = "", penerbit = "";
        private readonly MySqlConnection conn;

        public Buku()
        {
            Connection connection = new();
            conn = connection.doConnect();
        }

        public List<Buku> getAll()
        {
            string query = "SELECT b.*, p.nama as penerbit, p.id_penerbit " +
                            "FROM buku b, penerbit p " +
                            "WHERE b.id_penerbit = p.id_penerbit";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Buku> buku = new();
            while (reader.Read())
            {
                Buku b = new();
                b.id_buku = int.Parse(reader["id_buku"].ToString());
                b.judul = reader["judul"].ToString();
                b.deskripsi = reader["deskripsi"].ToString();
                b.penulis = reader["penulis"].ToString();
                b.id_penerbit = int.Parse(reader["id_penerbit"].ToString());
                b.penerbit = reader["penerbit"].ToString();
                b.harga = int.Parse(reader["harga"].ToString());
                b.stok= int.Parse(reader["stok"].ToString());
                b.gambar = reader["gambar"].ToString();
                buku.Add(b);
            }
            conn.Close();

            return buku;
        }

        public Buku getById(int id)
        {
            string query = "SELECT b.*, p.nama as penerbit, p.id_penerbit " +
                           "FROM buku b, penerbit p " +
                           "WHERE b.id_penerbit = p.id_penerbit AND " +
                           $"b.id_buku = {id}";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            Buku b = new();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    b.id_buku = int.Parse(reader["id_buku"].ToString());
                    b.judul = reader["judul"].ToString();
                    b.deskripsi = reader["deskripsi"].ToString();
                    b.penulis = reader["penulis"].ToString();
                    b.penerbit = reader["penerbit"].ToString();
                    b.id_penerbit = int.Parse(reader["id_penerbit"].ToString());
                    b.harga = int.Parse(reader["harga"].ToString());
                    b.stok = int.Parse(reader["stok"].ToString());
                    b.gambar = reader["gambar"].ToString();
                }
            }
            conn.Close();

            return b;
        }

        public Buku getSisaStok()
        {
            string query = "SELECT SUM(stok) AS sisa_stok FROM buku";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            Buku buku = new();
            while (reader.Read())
            {
                buku.sisa_stok = int.Parse(reader["sisa_stok"].ToString());
            }
            conn.Close();

            return buku;
        }

        public bool insertData(Buku dataBuku)
        {
            string query = $"INSERT INTO buku VALUES(" +
                $"'','{dataBuku.judul}','{dataBuku.deskripsi}','{dataBuku.penulis}',{dataBuku.id_penerbit},{dataBuku.harga},{dataBuku.stok},'{dataBuku.gambar}'" +
                $")";
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
                return false;
            }
        }

        public bool delete(int id)
        {
            string query = $"DELETE FROM buku WHERE id_buku={id}";
            MySqlCommand command = new(query, conn);
            conn.Open();
            if(command.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        public bool update(Buku buku, int id_buku)
        {
            string query = "UPDATE buku SET " + 
                $"judul='{buku.judul}', " + 
                $"deskripsi='{buku.deskripsi}', " + 
                $"penulis='{buku.penulis}', " + 
                $"id_penerbit={buku.id_penerbit}, " + 
                $"harga={buku.harga}, " + 
                $"stok={buku.stok}, " + 
                $"gambar='{buku.gambar}' " + 
                $"WHERE id_buku={id_buku}";
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
                return false;
            }
        }
    }
}
