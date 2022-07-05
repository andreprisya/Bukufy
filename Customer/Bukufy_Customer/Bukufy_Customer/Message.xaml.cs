using System.Windows;

namespace Bukufy_Customer
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message(string headline, string caption, string primaryContent)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            txtHeadline.Text = headline;
            txtCaption.Text = caption;
            btnPrimary.Content = primaryContent;
        }

        private void btnPrimary_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
