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
using Bukufy_Admin.models;

namespace Bukufy_Admin
{
    /// <summary>
    /// Interaction logic for Halaman_Utama.xaml
    /// </summary>
    public partial class Halaman_Utama : Window
    {
        public Halaman_Utama()
        {
            InitializeComponent();
            showDataBuku();
        }

        public void showDataBuku()
        {
            int i = 1;
            Buku buku = new();
            List<Buku> listBuku = buku.getAll();
            
            if(listBuku.Count == 0)
            {
                tableLabelStatus.Text = "Tidak ada data buku, silahkan tambahkan data\nmelalui menu tambah data!";
                tableLabelStatus.Visibility = Visibility.Visible;
                listDataBuku.Visibility = Visibility.Collapsed;
            }
            else
            {
                listDataBuku.Visibility = Visibility.Visible;
                tableLabelStatus.Visibility = Visibility.Collapsed;

                List<DataBuku> listItems = new List<DataBuku>();

                foreach (Buku? data in listBuku)
                {
                    listItems.Add(
                        new DataBuku()
                        {
                            Nomor = i,
                            Id_buku = data.id_buku,
                            Judul = data.judul,
                            Penerbit = data.penerbit,
                            Penulis = data.penulis,
                            Stok = data.stok,
                            Harga = data.harga
                        }
                    );
                    i++;
                }

                listDataBuku.ItemsSource = listItems;
            }
        }

        private void btnHalamanTambah_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Tambah_Buku window = new();
            window.Show();
            Close();
        }

        private void btnDetailBuku_Click(object sender, RoutedEventArgs e)
        {
            if (listDataBuku.SelectedItem != null)
            {
                int id = (listDataBuku.SelectedItem as DataBuku).Id_buku;
                if (id != null)
                {
                    Halaman_Detail_Buku window = new(id);
                    window.Show();
                    Close();
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listDataBuku.SelectedItem != null)
            {
                int id = (listDataBuku.SelectedItem as DataBuku).Id_buku;
                if (id != null)
                {
                    Halaman_Edit_Buku window = new(id);
                    window.Show();
                    Close();
                }
            }
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            if (listDataBuku.SelectedItem != null)
            {
                int id = (listDataBuku.SelectedItem as DataBuku).Id_buku;
                if (id != null)
                {
                    Buku buku = new();
                    Buku targetDelete = buku.getById(id);
                    string imageName = targetDelete.gambar;
                    bool deleteAction;
                    Prompt prompt = new("Hapus Data Buku", "Apakah anda yakin untuk menghapus data ini?", "Ya, hapus data!", "Tidak, batalkan!");
                    if (prompt.ShowDialog() == false)
                    {
                        deleteAction = prompt.actionTaken;
                        if (deleteAction)
                        {
                            if (buku.delete(id))
                            {
                                string appPath = System.IO.Directory.GetCurrentDirectory();

                                System.IO.DirectoryInfo directoryInfo = System.IO.Directory.GetParent(appPath);
                                directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);
                                directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);

                                string targetDir = directoryInfo.FullName + "\\assets\\sampul\\";

                                if (System.IO.File.Exists(targetDir + imageName))
                                {
                                    System.IO.File.Delete(targetDir + imageName);
                                }
                                
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
            showDataBuku();
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
