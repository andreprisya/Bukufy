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
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Window
    {
        public Profil()
        {
            InitializeComponent();
        }

        private void ChangePhotoIcon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void biodata_Click(object sender, RoutedEventArgs e)
        {
            Profil window = new Profil();
            window.Show();
            this.Close();
        }

        private void password_Click(object sender, RoutedEventArgs e)
        {
            Profil1 window = new Profil1();
            window.Show();
            this.Close();

        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Profil window = new Halaman_Profil();
            window.Show();
            this.Close();
        }

        private void btnKembali_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Profil window = new Halaman_Profil();
            window.Show();
            this.Close();
        }

        private void btnKembaliIcon_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Profil window = new Halaman_Profil();
            window.Show();
            this.Close();
        }

        private void btnKeranjangHead_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAkun_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Profil window = new Halaman_Profil();
            window.Show();
            this.Close();
        }
    }
}
