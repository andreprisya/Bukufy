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
using Bukufy_Admin.models;

namespace Bukufy_Admin
{
    /// <summary>
    /// Interaction logic for Halaman_Transaksi.xaml
    /// </summary>
    public partial class Halaman_Transaksi : Window
    {
        public Halaman_Transaksi()
        {
            InitializeComponent();
            showHighlightedPoint();
            showDataTransaksi();
        }

        public void showDataTransaksi()
        {
            int i = 1;
            Transaksi transaksi = new();
            List<Transaksi> listTransaksi = transaksi.getAll();

            if (listTransaksi.Count == 0)
            {
                tableLabelStatus.Text = "Tidak ada data transaksi, belum ada yang membeli produk!";
                tableLabelStatus.Visibility = Visibility.Visible;
                listDataTransaksi.Visibility = Visibility.Collapsed;
            }
            else
            {
                listDataTransaksi.Visibility = Visibility.Visible;
                tableLabelStatus.Visibility = Visibility.Collapsed;

                List<DataTransaksi> listItems = new();

                foreach (Transaksi? data in listTransaksi)
                {
                    listItems.Add(
                        new DataTransaksi()
                        {
                            Nomor = i,
                            Id_transaksi = data.id_transaksi,
                            Username = data.username,
                            Judul_buku = data.judul_buku,
                            Nama_ekspedisi = data.nama_ekspedisi,
                            Methode_pembayaran = data.methode_pembayaran,
                            Ongkos_kirim = "Rp. " + data.ongkos_kirim,
                            Harga_buku = "Rp. " + data.harga_buku,
                            Quantity = data.quantity,
                            Total = "Rp. " + data.total
                        }
                    );
                    i++;
                }

                listDataTransaksi.ItemsSource = listItems;
            }
        }

        public void showHighlightedPoint()
        {
            Buku buku = new();
            buku.sisa_stok = buku.getSisaStok().sisa_stok;

            Transaksi transaksi = new();
            transaksi.jml_pendapatan = transaksi.getJmlPendapatan().jml_pendapatan;
            transaksi.jml_transaksi = transaksi.getJmlTransaksi().jml_transaksi;

            tbPendapatan.Text = "Rp. " + transaksi.jml_pendapatan;
            if (transaksi.jml_transaksi == 0)
            {
                tbTotalTransaksi.Text = "0";
            }
            else
            {
                if (transaksi.jml_transaksi < 10)
                {
                    tbTotalTransaksi.Text = "0" + transaksi.jml_transaksi;
                }
                else
                {
                    tbTotalTransaksi.Text = transaksi.jml_transaksi.ToString();
                }
            }
            tbStokBuku.Text = "Sisa " + buku.sisa_stok;
        }

        private void btnHalProduk_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Utama().Show();
            Close();
        }

        private void btnHalTransaksi_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Transaksi().Show();
            Close();
        }

        private void btnHalEkspedisi_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Ekspedisi().Show();
            Close();
        }

        private void btnHalPenerbit_Click(object sender, RoutedEventArgs e)
        {
            new Halaman_Penerbit().Show();
            Close();
        }
    }
}
