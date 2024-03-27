using Practoz5.conditerDataSetTableAdapters;
using System.Windows;

namespace Practoz5
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void Acount(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Account();
        }

        private void Employe(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Employee();
        }

        private void Provider(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Provider();
        }

        private void Storag(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Storage();
        }


        private void Product(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Products();
        }

        private void Reviews(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Reviews();
        }

        private void Buyer(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Buyer();
        }

        private void Order(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Orders();
        }

        private void Order_basket(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Orders_basket();
        }

        private void Categories(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Categories();
        }

        private void Checks(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Check();
        }
    }
}