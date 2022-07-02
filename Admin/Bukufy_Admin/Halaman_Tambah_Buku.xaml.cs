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
        List<Penerbit> listPenerbit;
        int id_penerbit;
        string fileName = "", filePath = "", targetDir = "";
        OpenFileDialog openFile;
        public Halaman_Tambah_Buku()
        {
            InitializeComponent();
            Penerbit penerbit = new Penerbit();
            listPenerbit = penerbit.getAll();
            List<DataPenerbit> listItems = new List<DataPenerbit>();

            foreach(var data in listPenerbit)
            {
                listItems.Add(new DataPenerbit()
                {
                    id_penerbit = data.id_penerbit,
                    nama = data.nama
                });
            }

            cmbPenerbit.ItemsSource = listItems;
        }

        private void btnKembali_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Utama window = new Halaman_Utama();
            window.Show();
            this.Close();
        }

        private void cmbPenerbit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataPenerbit selected = (DataPenerbit)(sender as ComboBox).SelectedItem;
            this.id_penerbit = selected.id_penerbit;
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            uploadFile();

            Buku buku = new Buku();
            buku.judul = txtJudul.Text;
            buku.deskripsi = txtDeskripsi.Text;
            buku.penulis = txtPenulis.Text;
            buku.id_penerbit = this.id_penerbit;
            buku.stok = int.Parse(txtStok.Text);
            buku.harga = int.Parse(txtHarga.Text);
            buku.gambar = this.fileName;

            if (buku.insertData(buku))
            {
                Halaman_Utama window = new Halaman_Utama();
                Message message = new Message("Data Berhasil Disimpan", "Terimakasih telah menginputkan data", "Tutup");
                window.Show();
                message.Show();
                this.Close();
            }
            else
            {
                Message message = new Message("Data Gagal Disimpan", "Harap menginputkan data kembali", "Tutup");
                message.Show();
            }
        }

        private void btnBatal_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Utama window = new Halaman_Utama();
            window.Show();
            this.Close();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.Filter = "Image only. | *.jpg; *.jpeg; *.png; *.gif; *.png";

            if ((bool)openFile.ShowDialog())
            {
                this.fileName = System.IO.Path.GetFileName(openFile.FileName);
            }

            txtGambar.Text = this.fileName;
        }

        private void uploadFile()
        {
            string appPath = System.IO.Directory.GetCurrentDirectory();

            System.IO.DirectoryInfo directoryInfo = System.IO.Directory.GetParent(appPath);
            directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);
            directoryInfo = System.IO.Directory.GetParent(directoryInfo.FullName);

            this.targetDir = directoryInfo.FullName + "\\assets\\sampul\\";

            if (!System.IO.Directory.Exists(this.targetDir))
            {
                System.IO.Directory.CreateDirectory(this.targetDir);
            }

            if (!System.IO.File.Exists(this.targetDir + this.fileName))
            {
                System.IO.File.Copy(openFile.FileName, this.targetDir + this.fileName);
            }
            else
            {
                DateTime time = new DateTime();
                time = DateTime.Now;
                string[] temp = this.fileName.Split('.');
                this.fileName = temp[0] + time.Hour + time.Minute + time.Second + "." + temp[1];
                System.IO.File.Copy(openFile.FileName, this.targetDir + this.fileName);
            }
        }
    }

    public class DataPenerbit
    {
        public int id_penerbit { get; set; }
        public string nama { get; set; }
    }
}
