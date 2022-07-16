using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Bukufy_Customer;

namespace Bukufy_Transaksi.models
{
    class Transaksi
    {
        public int id_transaksi, id_Transaksi, id_buku, id_ekspedisi, ongkos_kirim, quantity, harga;
        public string metode_pembayaran, tgl_beli, tgl_kirim, tgl_selesai, judul, buku, penulis, gambar;
        MySqlConnection conn;

        public Transaksi()
        {
            Connection koneksi = new Connection();
            conn = koneksi.doConnect();

        }

        public string Id_buku { get; internal set; }

        public List<Transaksi> getTopData()
        {
            String query = "SELECT b.judul, b.penulis, b.gambar, b.harga, b.id_buku, COUNT(t.id_buku) as jml FROM transaksi t, buku b WHERE t.id_buku = b.id_buku GROUP BY t.id_buku ORDER BY jml DESC LIMIT 4;";
            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();

            List<Transaksi> Transaksis = new List<Transaksi>();
            while (reader.Read())
            {
                Transaksi transaksi = new Transaksi();
                transaksi.id_buku = int.Parse(reader["id_buku"].ToString());
                transaksi.harga = int.Parse(reader["harga"].ToString());
                transaksi.judul = reader["judul"].ToString();
                transaksi.penulis = reader["penulis"].ToString();
                transaksi.gambar = reader["gambar"].ToString();
                Transaksis.Add(transaksi);
            }

            return Transaksis;
        }
    }
}
