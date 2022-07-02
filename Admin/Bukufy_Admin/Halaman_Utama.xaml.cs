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
        MySqlConnection conn;
        public Halaman_Utama()
        {
            InitializeComponent();
            Connection connection = new Connection();
            conn = connection.doConnect();

            showDataBuku();
        }

        public void showDataBuku()
        {
            int i = 1;
            Buku buku = new Buku();
            List<Buku> listBuku = buku.getAll();
            List<DataBuku> listItems = new List<DataBuku>();

            foreach(var data in listBuku)
            {
                listItems.Add(
                    new DataBuku()
                    {
                        nomor = i,
                        judul = data.judul,
                        penerbit = data.penerbit,
                        penulis = data.penulis,
                        stok = data.stok,
                        harga = data.harga
                    }
                );
                i++;
            }
            
            listDataBuku.ItemsSource = listItems;
        }

        private void btnHalamanTambah_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Tambah_Buku window = new Halaman_Tambah_Buku();
            window.Show();
            this.Close();
        }
    }

    public class DataBuku
    {
        public int nomor { get; set; }
        public string judul { get; set; }
        public string penerbit { get; set; }
        public string penulis { get; set; }
        public int stok { get; set; }
        public int harga { get; set; }
    }
}
