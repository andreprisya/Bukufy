using System;
using System.Windows;
using Bukufy_Customer.models;

namespace Bukufy_Customer
{
    /// <summary>
    /// Interaction logic for Halaman_Register.xaml
    /// </summary>
    public partial class Halaman_Register : Window
    {
        public Halaman_Register()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.Username = txtUsername.Text;
            customer.Email = txtEmail.Text;
            customer.Password = txtPassword.Password;
            customer.Password2 = txtPassword2.Password;

            
            if (customer.Password == customer.Password2)
            {
                if (customer.insertData(customer))
                {
                    Login_Customer window = new Login_Customer();
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
            else
            {
                Message message = new Message("Password Salah!", "Harap menginputkan data kembali", "Tutup");
                message.Show();
            }



        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            Login_Customer window = new Login_Customer();
            window.Show();
            this.Close();
        }

    }
}
