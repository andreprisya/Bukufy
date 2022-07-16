using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Bukufy_Transaksi.models;

namespace Bukufy_Customer
{
    /// <summary>
    /// Interaction logic for Halaman_Utama.xaml
    /// </summary>
    public partial class Halaman_Utama : Window
    {
        MySqlConnection conn = null;
        public Halaman_Utama()
        {
            InitializeComponent();

            if (connectToDb())
            {
                Transaksi Transaksi = new Transaksi();
                List<Transaksi> Transaksis = Transaksi.getTopData();

                foreach (var data in Transaksis)
                {
                    string Id_buku = data.id_buku.ToString();
                    string harga = data.harga.ToString();
                    string judul = data.judul;
                    string penulis = data.penulis;
                }

            }
        }

        private bool connectToDb()
        {
            Connection koneksi = new Connection();
            conn = koneksi.doConnect();
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }



        private void btnKeranjang_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Keranjang window = new Halaman_Keranjang();
            window.Show();
            this.Close();
        }

        private void btnBeli_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Detail_Pembelian window = new Halaman_Detail_Pembelian();
            window.Show();
            this.Close();
        }

        private void btnAkun_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Profil window = new Halaman_Profil();
            window.Show();
            this.Close();
        }

        private void btnKeranjangHead_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Keranjang window = new Halaman_Keranjang();
            window.Show();
            this.Close();
        }
    }
}
