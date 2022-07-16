using MySql.Data.MySqlClient;
using System;
using Microsoft.Win32;
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
    /// Interaction logic for Halaman_Detail_Buku.xaml
    /// </summary>
    public partial class Halaman_Detail_Buku : Window
    {
        int id_buku;
        string targetDir;
        Buku buku;
        Buku dataBuku;
        public Halaman_Detail_Buku(int id_buku)
        {
            buku = new Buku();
            this.id_buku = id_buku;
            getDetailBuku();

            InitializeComponent();

            string appPath = System.IO.Directory.GetCurrentDirectory();

            System.IO.DirectoryInfo directoryInfo = System.IO.Directory.GetParent(appPath);
            directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);
            directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);

            targetDir = directoryInfo.FullName + "\\assets\\sampul\\";

            showDetailBuku();
        }

        public void getDetailBuku()
        {
            dataBuku = buku.getById(id_buku);
        }

        public static ImageSource bitmapFromUri(Uri source)
        {
            BitmapImage bitmap = new();
            bitmap.BeginInit();
            bitmap.UriSource = source;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            return bitmap;
        }

        public void showDetailBuku()
        {
            if(dataBuku.judul != null)
            {
                imageContainer.Source = bitmapFromUri(new Uri(targetDir + dataBuku.gambar));
                txtHeadline.Text = dataBuku.judul;
                txtJudul.Text = dataBuku.judul;
                txtPenulis.Text = dataBuku.penulis;
                txtPenerbit.Text = dataBuku.penerbit;
                txtHarga.Text = dataBuku.harga.ToString();
                txtStok.Text = dataBuku.stok.ToString();
                txtDeskripsi.Text = dataBuku.deskripsi;
            }
        }

        private void btnKembali_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Utama().Show();
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
            Halaman_Edit_Buku window = new(id_buku);
            window.Show();
            Close();
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            Buku buku = new();
            Buku targetDelete = buku.getById(id_buku);
            string imageName = targetDelete.gambar;
            bool deleteAction;
            Prompt prompt = new("Hapus Data Buku", "Apakah anda yakin untuk menghapus data ini?", "Ya, hapus data!", "Tidak, batalkan!");
            if (prompt.ShowDialog() == false)
            {
                deleteAction = prompt.actionTaken;
                if (deleteAction)
                {
                    if (buku.delete(id_buku))
                    {
                        if (System.IO.File.Exists(targetDir + imageName))
                        {
                            imageContainer.Source = null;
                            System.IO.File.Delete(targetDir + imageName);
                        }

                        Halaman_Utama window = new();
                        Message message = new("Data Berhasil Dihapus", "Terimakasih telah menghapus data!", "Tutup");
                        window.Show();
                        message.Show();
                        Close();
                    }
                    else
                    {
                        Message message = new("Data Gagal Dihapus", "Mohon coba lagi dilain waktu!", "Tutup");
                        message.Show();
                    }
                }
            }
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
