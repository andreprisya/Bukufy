using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukufy_Admin
{
    class DataTransaksi
    {
        public int Nomor { get; set; }
        public int Id_transaksi { get; set; }
        public string Username { get; set; }
        public string Judul_buku { get; set; }
        public string Nama_ekspedisi { get; set; }
        public string Methode_pembayaran { get; set; }
        public string Ongkos_kirim { get; set; }
        public string Harga_buku { get; set; }
        public int Quantity { get; set; }
        public string Total { get; set; }

        public DataTransaksi() { }
    }
}
