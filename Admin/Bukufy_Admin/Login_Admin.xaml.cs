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
        MySqlConnection conn = null;
        public Login_Admin()
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
            }catch(Exception ex)
            {
                return false;
            }
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (connectToDb())
            {
                Admin admin = new Admin();
                List<Admin> admins = admin.getAll();

                foreach(var data in admins)
                {
                    if (data.Username == txtUsername.Text && data.Password == txtPassword.Password)
                    {
                        Session session = new Session();
                        session.create(data.Id, data.Username);
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
        }
    }
}
