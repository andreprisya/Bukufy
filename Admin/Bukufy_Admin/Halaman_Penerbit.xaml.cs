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
    /// Interaction logic for Halaman_Penerbit.xaml
    /// </summary>
    public partial class Halaman_Penerbit : Window
    {
        public Halaman_Penerbit()
        {
            InitializeComponent();
            showDataPenerbit();
        }

        public void showDataPenerbit()
        {
            int i = 1;
            Penerbit penerbit = new();
            List<Penerbit> listPenerbit = penerbit.getAll();
            if (listPenerbit.Count == 0)
            {
                tableLabelStatus.Text = "Tidak ada data penerbit, silahkan tambahkan data\nmelalui menu tambah data!";
                tableLabelStatus.Visibility = Visibility.Visible;
                listDataPenerbit.Visibility = Visibility.Collapsed;
            }
            else
            {
                listDataPenerbit.Visibility = Visibility.Visible;
                tableLabelStatus.Visibility = Visibility.Collapsed;

                List<DataPenerbit> listItems = new();

                foreach (Penerbit? data in listPenerbit)
                {
                    listItems.Add(
                        new DataPenerbit()
                        {
                            Nomor = i,
                            Id_penerbit = data.id_penerbit,
                            Nama = data.nama,
                            Alamat = data.alamat
                        }
                    );
                    i++;
                }

                listDataPenerbit.ItemsSource = listItems;
            }
        }

        private void btnHalamanTambahPenerbit_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Tambah_Penerbit().Show();
            Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listDataPenerbit.SelectedItem != null)
            {
                int id = (listDataPenerbit.SelectedItem as DataPenerbit).Id_penerbit;
                if (id != null)
                {
                    Halaman_Edit_Penerbit window = new(id);
                    window.Show();
                    Close();
                }
            }
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            if (listDataPenerbit.SelectedItem != null)
            {
                int id = (listDataPenerbit.SelectedItem as DataPenerbit).Id_penerbit;
                if (id != null)
                {
                    Penerbit penerbit = new();
                    bool deleteAction;
                    Prompt prompt = new("Hapus Data Mitra Penerbit", "Apakah anda yakin untuk menghapus data ini?", "Ya, hapus data!", "Tidak, batalkan!");
                    if (prompt.ShowDialog() == false)
                    {
                        deleteAction = prompt.actionTaken;
                        if (deleteAction)
                        {
                            if (penerbit.delete(id))
                            {
                                Message message = new("Data Berhasil Dihapus", "Terimakasih telah menghapus data!", "Tutup");
                                message.Show();
                            }
                            else
                            {
                                Message message = new("Data Gagal Dihapus", "Mohon coba lagi dilain waktu!", "Tutup");
                                message.Show();
                            }
                        }
                    }
                }
            }
            showDataPenerbit();
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
