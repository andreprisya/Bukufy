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
    /// Interaction logic for Halaman_Edit_Ekspedisi.xaml
    /// </summary>
    public partial class Halaman_Edit_Ekspedisi : Window
    {
        private int id_ekspedisi;
        private Ekspedisi ekspedisi;
        public Halaman_Edit_Ekspedisi(int id_ekspedisi)
        {
            this.id_ekspedisi = id_ekspedisi;
            ekspedisi = new();
            getDataEkspedisi();
            InitializeComponent();
            showFormData();
        }

        public void getDataEkspedisi()
        {
            ekspedisi = ekspedisi.getDataById(id_ekspedisi);
        }

        public void showFormData()
        {
            txtNama.Text = ekspedisi.nama;
            txtAlamat.Text = ekspedisi.alamat;
            txtUsername.Text = ekspedisi.username;
        }

        private void btnKembali_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Ekspedisi().Show();
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

        private void btnBatal_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Ekspedisi().Show();
            Close();
        }

        private void btnUbah_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == txtPasswordKonfirmasi.Password)
            {
                ekspedisi.nama = txtNama.Text;
                ekspedisi.alamat = txtAlamat.Text;
                ekspedisi.username = txtUsername.Text;
                ekspedisi.password = txtPassword.Password;

                if (ekspedisi.update(ekspedisi, id_ekspedisi))
                {
                    new Halaman_Ekspedisi().Show();
                    new Message("Data Berhasil Diubah", "Terimakasih telah mengubah data", "Tutup").Show();
                    Close();
                }
                else
                {
                    new Message("Data Gagal Diubah", "Harap menginputkan data kembali", "Tutup").Show();
                }
            }
            else
            {
                new Message("Password Tidak Sama", "Mohon maaf, password yang anda masukkan tidak sama, mohon masukkan data ulang!", "Tutup").Show();
            }
        }
    }
}
