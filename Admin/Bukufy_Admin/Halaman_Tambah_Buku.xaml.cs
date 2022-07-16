using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Microsoft.Win32;

namespace Bukufy_Admin
{
    /// <summary>
    /// Interaction logic for Halaman_Tambah_Buku.xaml
    /// </summary>
    public partial class Halaman_Tambah_Buku : Window
    {
        private readonly List<Penerbit> listPenerbit;
        private int id_penerbit;
        private string fileName = "", targetDir = "";
        private OpenFileDialog openFile;
        public Halaman_Tambah_Buku()
        {
            InitializeComponent();
            Penerbit penerbit = new();
            listPenerbit = penerbit.getAll();
            List<DataPenerbit> listItems = new();

            foreach(var data in listPenerbit)
            {
                listItems.Add(new DataPenerbit()
                {
                    Id_penerbit = data.id_penerbit,
                    Nama = data.nama
                });
            }

            cmbPenerbit.ItemsSource = listItems;
        }

        private void btnKembali_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Utama window = new();
            window.Show();
            Close();
        }

        private void cmbPenerbit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataPenerbit selected = (DataPenerbit)(sender as ComboBox).SelectedItem;
            id_penerbit = selected.Id_penerbit;
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            uploadFile();

            Buku buku = new Buku();
            buku.judul = txtJudul.Text;
            buku.deskripsi = txtDeskripsi.Text;
            buku.penulis = txtPenulis.Text;
            buku.id_penerbit = id_penerbit;
            buku.stok = int.Parse(txtStok.Text);
            buku.harga = int.Parse(txtHarga.Text);
            buku.gambar = fileName;

            if (buku.insertData(buku))
            {
                Halaman_Utama window = new();
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
            new Halaman_Utama().Show();
            Close();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.Filter = "Image only. | *.jpg; *.jpeg; *.png; *.gif; *.png";

            if ((bool)openFile.ShowDialog())
            {
                fileName = System.IO.Path.GetFileName(openFile.FileName);
            }

            txtGambar.Text = fileName;
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

        private void uploadFile()
        {
            string appPath = System.IO.Directory.GetCurrentDirectory();

            System.IO.DirectoryInfo directoryInfo = System.IO.Directory.GetParent(appPath);
            directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);
            directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);

            targetDir = directoryInfo.FullName + "\\assets\\sampul\\";

            if (!System.IO.Directory.Exists(targetDir))
            {
                System.IO.Directory.CreateDirectory(targetDir);
            }

            DateTime time = new();
            time = DateTime.Now;
            string[] temp = fileName.Split('.');
            fileName = temp[0] + "_" + time.Hour + time.Minute + time.Second + "." + temp[1];
            System.IO.File.Copy(openFile.FileName, targetDir + fileName);
        }
    }
}
