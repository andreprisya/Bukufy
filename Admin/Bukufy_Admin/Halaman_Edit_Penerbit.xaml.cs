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
    /// Interaction logic for Halaman_Edit_Penerbit.xaml
    /// </summary>
    public partial class Halaman_Edit_Penerbit : Window
    {
        private int id_penerbit;
        private Penerbit penerbit;
        public Halaman_Edit_Penerbit(int id_penerbit)
        {
            this.id_penerbit = id_penerbit;
            penerbit = new();
            getDataPenerbit();
            InitializeComponent();
            showFormData();
        }

        public void getDataPenerbit()
        {
            penerbit = penerbit.getDataById(id_penerbit);
        }

        public void showFormData()
        {
            txtNama.Text = penerbit.nama;
            txtAlamat.Text = penerbit.alamat;
        }

        private void btnBatal_Click(object sender, RoutedEventArgs e)
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

        private void btnUbah_Click(object sender, RoutedEventArgs e)
        {
            penerbit.nama = txtNama.Text;
            penerbit.alamat = txtAlamat.Text;
            if (penerbit.update(penerbit, id_penerbit))
            {
                Halaman_Penerbit window = new();
                Message message = new("Data Berhasil Diubah", "Terimakasih telah mengubah data", "Tutup");
                window.Show();
                message.Show();
                Close();
            }
            else
            {
                Message message = new("Data Gagal Diubah", "Harap menginputkan data kembali", "Tutup");
                message.Show();
            }
        }

        private void btnKembali_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Penerbit().Show();
            Close();
        }
    }
}
