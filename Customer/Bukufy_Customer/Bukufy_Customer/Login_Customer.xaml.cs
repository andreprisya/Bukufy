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
using Bukufy_Customer.models;

namespace Bukufy_Customer
{
    /// <summary>
    /// Interaction logic for Login_Customer.xaml
    /// </summary>
    public partial class Login_Customer : Window
    {
        MySqlConnection conn = null;
        public Login_Customer()
        {
            InitializeComponent();
        }

        private bool connectToDb()
        {
            Connection koneksi = new Connection();
            conn = koneksi.doConnect();
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (connectToDb())
            {
                Customer Customer = new Customer();
                List<Customer> Customers = Customer.getAll();
                string status = null;

                foreach (var data in Customers)
                {
                    if (data.Username == txtUsername.Text && data.Password == txtPassword.Password)
                    {
                        status = "true";
                        break;
                    }
                    else
                    {
                        status = "false";
                    }
                    
                }

                if (status == "true")
                {
                    Session session = new Session();
                    session.create(Customer.Id, Customer.Username);
                    Halaman_Utama window = new Halaman_Utama();
                    window.Show();
                    this.Close();
                }

                else
                {
                    Message message = new Message("Maaf, Login Gagal", "Silahkan coba lagi!", "Tutup");
                    message.Show();
                }

            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            Halaman_Register window = new Halaman_Register();
            window.Show();
            this.Close();
        }
    }
}