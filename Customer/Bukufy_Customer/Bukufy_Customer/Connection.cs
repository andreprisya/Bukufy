using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Bukufy_Customer
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