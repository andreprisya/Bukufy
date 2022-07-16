using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Bukufy_Admin.models;
using Microsoft.Win32;

namespace Bukufy_Admin
{
    /// <summary>
    /// Interaction logic for Halaman_Edit_Buku.xaml
    /// </summary>
    public partial class Halaman_Edit_Buku : Window
    {
        List<Penerbit> listPenerbit;
        int id_penerbit;
        int id_buku;
        private Buku buku;
        private Buku dataBuku;
        private string fileName = "", targetDir = "";
        private OpenFileDialog openFile;
        private bool uploadCondition;
        public Halaman_Edit_Buku(int id_buku)
        {
            this.id_buku = id_buku;
            buku = new Buku();
            getDataBuku();
            InitializeComponent();
            Penerbit penerbit = new();
            listPenerbit = penerbit.getAll();
            List<DataPenerbit> listItems = new();

            foreach (Penerbit? data in listPenerbit)
            {
                listItems.Add(new DataPenerbit()
                {
                    Id_penerbit = data.id_penerbit,
                    Nama = data.nama
                });
            }

            cmbPenerbit.ItemsSource = listItems;
            showFormData();
        }

        private void btnKembali_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Utama().Show();
            Close();
        }

        private void getDataBuku()
        {
            dataBuku = buku.getById(id_buku);
        }

        private void showFormData()
        {
            txtJudul.Text = dataBuku.judul;
            txtJudul.Select(txtJudul.Text.Length, 0);

            txtDeskripsi.Text = dataBuku.deskripsi;
            txtDeskripsi.Select(txtDeskripsi.Text.Length, 0);

            cmbPenerbit.SelectedValue = new DataPenerbit(dataBuku.id_penerbit, dataBuku.penerbit).Id_penerbit;

            txtPenulis.Text = dataBuku.penulis;
            txtPenulis.Select(txtPenulis.Text.Length, 0);

            txtHarga.Text = dataBuku.harga.ToString();
            txtHarga.Select(txtHarga.Text.Length, 0);

            txtStok.Text = dataBuku.stok.ToString();
            txtStok.Select(txtStok.Text.Length, 0);

            txtGambar.Text = dataBuku.gambar;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            uploadCondition = true;

            openFile = new OpenFileDialog
            {
                Filter = "Image only. | *.jpg; *.jpeg; *.png; *.gif; *.png"
            };

            if ((bool)openFile.ShowDialog())
            {
                fileName = System.IO.Path.GetFileName(openFile.FileName);
                txtGambar.Text = this.fileName;
                DateTime time = new DateTime();
                time = DateTime.Now;
                string[] temp = fileName.Split('.');
                fileName = temp[0] + "_" + time.Hour + time.Minute + time.Second + "." + temp[1];
            }
            else
            {
                uploadCondition = false;
            }
        }

        public void uploadFile()
        {
            string appPath = System.IO.Directory.GetCurrentDirectory();

            System.IO.DirectoryInfo directoryInfo = System.IO.Directory.GetParent(appPath);
            directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);
            directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);

            targetDir = directoryInfo.FullName + "\\assets\\sampul\\";

            if (!System.IO.Directory.Exists(targetDir))
            {
                _ = System.IO.Directory.CreateDirectory(targetDir);
            }
            
            if(System.IO.File.Exists(targetDir + dataBuku.gambar))
            {
                System.IO.File.Delete(targetDir + dataBuku.gambar);
            }

            System.IO.File.Copy(openFile.FileName, targetDir + fileName);
        }

        private void cmbPenerbit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataPenerbit selected = (DataPenerbit)(sender as ComboBox).SelectedItem;
            id_penerbit = selected.Id_penerbit;
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
            new Halaman_Utama().Show();
            Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUbah_Click(object sender, RoutedEventArgs e)
        {
            Buku editBuku = new();

            editBuku.judul = txtJudul.Text;
            editBuku.deskripsi = txtDeskripsi.Text;
            editBuku.id_penerbit = id_penerbit;
            editBuku.penulis = txtPenulis.Text;
            editBuku.harga = int.Parse(txtHarga.Text);
            editBuku.stok = int.Parse(txtStok.Text);
            if (uploadCondition)
            {
                editBuku.gambar = fileName;
            }
            else
            {
                editBuku.gambar = txtGambar.Text;
            }

            if (editBuku.update(editBuku, id_buku))
            {
                if (uploadCondition)
                {
                    uploadFile();
                }

                Halaman_Utama window = new();
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
    }
}
