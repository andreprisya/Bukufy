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

namespace Bukufy_Admin
{
    /// <summary>
    /// Interaction logic for Prompt.xaml
    /// </summary>
    public partial class Prompt : Window
    {
        public bool actionTaken;
        public Prompt(string headline, string caption, string txtPrimary, string txtSecondary)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            txtHeadline.Text = headline;
            txtCaption.Text = caption;
            btnPrimary.Content = txtPrimary;
            btnSecondary.Content = txtSecondary;
        }

        private void btnSecondary_Click(object sender, RoutedEventArgs e)
        {
            actionTaken = false;
            Close();
        }

        private void btnPrimary_Click(object sender, RoutedEventArgs e)
        {
            actionTaken = true;
            Close();
        }
    }
}
