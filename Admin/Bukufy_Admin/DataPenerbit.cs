using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukufy_Admin
{
    class DataPenerbit
    {
        public int Nomor { get; set; }
        public int Id_penerbit { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
       
        public DataPenerbit() { }
        public DataPenerbit(int id_penerbit, string nama)
        {
            Id_penerbit = id_penerbit;
            Nama = nama;
        }
    }
}
