using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukufy_Admin
{
    class Session
    {
        int id = 0;
        string username = null;

        public void destroy()
        {
            this.id = 0;
            this.username = null;
        }

        public void create(int id, string username)
        {
            this.id = id;
            this.username = username;
        }
    }
}
