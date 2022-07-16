using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukufy_Admin
{
    class DataBuku
    {
        public int Nomor { get; set; }
        public int Id_buku { get; set; }
        public string Judul { get; set; }
        public string Penerbit { get; set; }
        public string Penulis { get; set; }
        public int Stok { get; set; }
        public int Harga { get; set; }

        public DataBuku() { }
    }
}
