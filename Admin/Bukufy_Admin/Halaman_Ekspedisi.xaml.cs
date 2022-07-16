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
    /// Interaction logic for Halaman_Ekspedisi.xaml
    /// </summary>
    public partial class Halaman_Ekspedisi : Window
    {
        public Halaman_Ekspedisi()
        {
            InitializeComponent();
            showDataEkespedisi();
        }

        public void showDataEkespedisi()
        {
            int i = 1;
            Ekspedisi ekspedisi= new();
            List<Ekspedisi> listEkspedisi= ekspedisi.getAll();
            if (listEkspedisi.Count == 0)
            {
                tableLabelStatus.Text = "Tidak ada data ekspedisi, silahkan tambahkan data\nmelalui menu tambah data!";
                tableLabelStatus.Visibility = Visibility.Visible;
                listDataEkspedisi.Visibility = Visibility.Collapsed;
            }
            else
            {
                listDataEkspedisi.Visibility = Visibility.Visible;
                tableLabelStatus.Visibility = Visibility.Collapsed;

                List<DataEkspedisi> listItems = new();

                foreach (Ekspedisi? data in listEkspedisi)
                {
                    listItems.Add(
                        new DataEkspedisi()
                        {
                            Nomor = i,
                            Id_ekspedisi = data.id_ekspedisi,
                            Username = data.username,
                            Password = data.password,
                            Nama = data.nama,
                            Alamat = data.alamat
                        }
                    );
                    i++;
                }

                listDataEkspedisi.ItemsSource = listItems;
            }
        }

        private void btnHalamanTambahEkspedisi_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Tambah_Ekspedisi().Show();
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listDataEkspedisi.SelectedItem != null)
            {
                int id = (listDataEkspedisi.SelectedItem as DataEkspedisi).Id_ekspedisi;
                if (id != null)
                {
                    new Halaman_Edit_Ekspedisi(id).Show();
                    Close();
                }
            }
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Prompt prompt = new Prompt("Logout", "Apakah anda ingin logout dari aplikasi Bukufy?", "Ya, logout!", "Tidak, batalkan!");
            
            if (prompt.ShowDialog() == false)
            {
                if (prompt.actionTaken)
                {
                    new Login_Admin().Show();
                    new Message("Terima Kasih", "Gunakan aplikasi Bukufy lagi yah!", "Tutup").Show();
                    Close();
                }
            }
        }
    }
}
