using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Bukufy_Admin
{
    class Connection
    {
        public MySqlConnection doConnect()
        {
            MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=bukufy";
            return conn;
        }
    }
}
