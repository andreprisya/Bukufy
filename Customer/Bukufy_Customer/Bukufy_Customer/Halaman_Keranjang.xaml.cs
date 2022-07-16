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
    /// Interaction logic for Halaman_Keranjang.xaml
    /// </summary>
    public partial class Halaman_Keranjang : Window
    {
        public Halaman_Keranjang()
        {
            InitializeComponent();
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
            Halaman_Utama window = new Halaman_Utama();
            window.Show();
            this.Close();
        }

        private void btnAturAkun_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Profil window = new Halaman_Profil();
            window.Show();
            this.Close();
        }
        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnKurang_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBeli_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Detail_Pembelian window = new Halaman_Detail_Pembelian();
            window.Show();
            this.Close();
        }
    }
}
