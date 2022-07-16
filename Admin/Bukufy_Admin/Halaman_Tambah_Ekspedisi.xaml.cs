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
    /// Interaction logic for Halaman_Tambah_Ekspedisi.xaml
    /// </summary>
    public partial class Halaman_Tambah_Ekspedisi : Window
    {
        public Halaman_Tambah_Ekspedisi()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Tambah_Ekspedisi().Show();
            Close();
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == txtPasswordKonfirmasi.Password)
            {
                Ekspedisi ekspedisi = new();
                ekspedisi.username = txtUsername.Text;
                ekspedisi.password = txtPassword.Password;
                ekspedisi.nama = txtNama.Text;
                ekspedisi.alamat = txtAlamat.Text;

                if (ekspedisi.insert(ekspedisi))
                {
                    new Halaman_Ekspedisi().Show();
                    new Message("Data Berhasil Disimpan", "Terimakasih telah menginputkan data", "Tutup").Show();
                    Close();
                }
                else
                {
                    new Message("Data Gagal Disimpan", "Harap menginputkan data kembali", "Tutup").Show();
                }
            }
            else
            {
                new Message("Password Tidak Sama", "Mohon maaf, password yang anda masukkan tidak sama, mohon masukkan data ulang!", "Tutup").Show();
            }
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
            new Halaman_Tambah_Ekspedisi().Show();
            Close();
        }

        private void btnHalPenerbit_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Penerbit().Show();
            Close();
        }

        private void btnKembali_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Tambah_Ekspedisi().Show();
            Close();
        }
    }
}
