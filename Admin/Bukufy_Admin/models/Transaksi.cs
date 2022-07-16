using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Bukufy_Admin.models
{
    class Transaksi
    {
        public int id_transaksi, ongkos_kirim, harga_buku, quantity, total, jml_transaksi, jml_pendapatan;
        public string username = "", judul_buku = "", nama_ekspedisi = "", methode_pembayaran = "";
        private MySqlConnection conn;

        public Transaksi()
        {
            Connection connection = new();
            conn = connection.doConnect();
        }

        public List<Transaksi> getAll()
        {
            string query = "SELECT t.id_transaksi, c.username, b.judul, e.nama, " +
                "t.metode_pembayaran, t.ongkos_kirim, b.harga, t.quantity, " +
                "(b.harga * t.quantity) as total " +
                "FROM transaksi t, customer c, buku b, ekspedisi e " +
                "WHERE t.id_customer = c.id_customer AND t.id_buku = b.id_buku AND t.id_ekspedisi = e.id_ekspedisi";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Transaksi> transaksis = new();
            while (reader.Read())
            {
                Transaksi transaksi = new();
                transaksi.id_transaksi = int.Parse(reader["id_transaksi"].ToString());
                transaksi.username = reader["username"].ToString();
                transaksi.judul_buku = reader["judul"].ToString();
                transaksi.nama_ekspedisi = reader["nama"].ToString();
                transaksi.methode_pembayaran = reader["metode_pembayaran"].ToString();
                transaksi.ongkos_kirim = int.Parse(reader["ongkos_kirim"].ToString());
                transaksi.harga_buku = int.Parse(reader["harga"].ToString());
                transaksi.quantity = int.Parse(reader["quantity"].ToString());
                transaksi.total = int.Parse(reader["total"].ToString());

                transaksis.Add(transaksi);
            }
            conn.Close();

            return transaksis;
        }

        public Transaksi getJmlTransaksi()
        {
            string query = "SELECT COUNT(id_transaksi) AS jml_transaksi FROM transaksi";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            Transaksi transaksi = new();
            while (reader.Read())
            {
                transaksi.jml_transaksi = int.Parse(reader["jml_transaksi"].ToString());
            }
            conn.Close();

            return transaksi;
        }

        public Transaksi getJmlPendapatan()
        {
            string query = "SELECT SUM(t.quantity * b.harga) AS pendapatan " + 
                           "FROM transaksi t, buku b " + 
                           "WHERE t.id_buku = b.id_buku";
            MySqlCommand command = new(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            Transaksi transaksi = new();
            while (reader.Read())
            {
                transaksi.jml_pendapatan = int.Parse(reader["pendapatan"].ToString());
            }
            conn.Close();

            return transaksi;
        }
    }
}
