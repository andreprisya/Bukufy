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
    /// Interaction logic for Login_Admin.xaml
    /// </summary>
    public partial class Login_Admin : Window
    {
        bool showPwd = false;
        public Login_Admin()
        {
            InitializeComponent();
            _ = txtUsername.Focus();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new();
            List<Admin> admins = admin.getAll();
            bool loginCondition = false;
            string adminName = "";

            foreach(var data in admins)
            {
                if (data.Username == txtUsername.Text && data.Password == txtPassword.Password)
                {
                    loginCondition = true;
                    adminName = data.Username;
                    break;
                }
                else
                {
                    loginCondition = false;
                }
            }

            if(loginCondition)
            {
                new Halaman_Utama().Show();
                new Message($"Hi {adminName}!", "Selamat datang di aplikasi Bukufy!", "Tutup").Show();
                Close();
            }
            else
            {
                new Message("Maaf, Login Gagal", "Silahkan coba lagi!", "Tutup").Show();
            }
        }

        private void btnRevealPwd_Click(object sender, RoutedEventArgs e)
        {
            if (showPwd)
            {
                txtPassword.Password = txtPasswordUnHide.Text;

                txtPassword.Visibility = Visibility.Visible;
                txtPasswordUnHide.Visibility = Visibility.Collapsed;
                showPwd = false;
            }
            else
            {
                txtPasswordUnHide.Text = txtPassword.Password;
                txtPasswordUnHide.CaretIndex = txtPasswordUnHide.Text.Length;

                txtPassword.Visibility = Visibility.Collapsed;
                txtPasswordUnHide.Visibility = Visibility.Visible;
                txtPasswordUnHide.Focus();
                showPwd = true;
            }
        }
    }
}
