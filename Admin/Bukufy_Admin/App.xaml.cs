using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Bukufy_Admin.models;

namespace Bukufy_Admin
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            showLogin();
        }

        private void showLogin()
        {
            Login_Admin window = new Login_Admin();
            window.Show();
        }
    }
}
