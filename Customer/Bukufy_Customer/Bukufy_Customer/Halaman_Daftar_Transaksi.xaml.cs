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

namespace Bukufy_Customer
{
    /// <summary>
    /// Interaction logic for Halaman_Daftar_Transaksi.xaml
    /// </summary>
    public partial class Halaman_Daftar_Transaksi : Window
    {
        public Halaman_Daftar_Transaksi()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnKeranjangHead_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Keranjang window = new Halaman_Keranjang();
            window.Show();
            this.Close();
        }

        private void btnAkun_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Profil window = new Halaman_Profil();
            window.Show();
            this.Close();
        }

        private void btnKembaliIcon_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Utama window = new Halaman_Utama();
            window.Show();
            this.Close();
        }

        private void btnKembali_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Detail_Transaksi window = new Halaman_Detail_Transaksi();
            window.Show();
            this.Close();
        }
    }
}
