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
    /// Interaction logic for Halaman_Utama.xaml
    /// </summary>
    public partial class Halaman_Utama : Window
    {
        public Halaman_Utama()
        {
            InitializeComponent();
        }

        private void btnKeranjang_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBeli_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAkun_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Profil window = new Halaman_Profil();
            window.Show();
            this.Close();
        }

        private void btnKeranjangHead_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
