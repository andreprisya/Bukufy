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
using Bukufy_Admin.models;

namespace Bukufy_Admin
{
    /// <summary>
    /// Interaction logic for Halaman_Tambah_Penerbit.xaml
    /// </summary>
    public partial class Halaman_Tambah_Penerbit : Window
    {
        
        public Halaman_Tambah_Penerbit()
        {
            InitializeComponent();
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            Penerbit penerbit = new();
            penerbit.nama = txtNama.Text;
            penerbit.alamat = txtAlamat.Text;

            if (penerbit.insert(penerbit)){
                Halaman_Penerbit window = new();
                Message message = new("Data Berhasil Disimpan", "Terimakasih telah menginputkan data", "Tutup");
                window.Show();
                message.Show();
                Close();
            }
            else
            {
                Message message = new("Data Gagal Disimpan", "Harap menginputkan data kembali", "Tutup");
                message.Show();
            }
        }

        private void btnBatal_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Penerbit().Show();
            Close();
        }

        private void btnKembali_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Penerbit().Show();
            Close();
        }

        private void btnHalProduk_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Utama().Show();
            Close();
        }

        private void btnHalTransaksi_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Transaksi().Show();
            Close();
        }

        private void btnHalEkspedisi_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Ekspedisi().Show();
            Close();
        }

        private void btnHalPenerbit_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Penerbit().Show();
            Close();
        }
    }
}
