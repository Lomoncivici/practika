using Practoz5.conditerDataSetTableAdapters;
using System.Windows;

namespace Practoz5
{
    public partial class Kasir : Window
    {
        public Kasir()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void Order(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Orders();
        }

        private void Order_basket(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Orders_basket();
        }
        private void Checks(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Check();
        }
    }
}
