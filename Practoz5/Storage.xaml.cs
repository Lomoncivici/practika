using Practoz5.conditerDataSetTableAdapters;
using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Practoz5
{
    public partial class Storage : Page
    {
        StorageTableAdapter Storagee = new StorageTableAdapter();
        ProviderrTableAdapter Providerr = new ProviderrTableAdapter();
        ProductsTableAdapter Products = new ProductsTableAdapter();
        public Storage()
        {
            InitializeComponent();

            StorageTable.ItemsSource = Storagee.GetaMain();

            ProviderCBX.ItemsSource = Providerr.GetData();
            ProviderCBX.DisplayMemberPath = "ProviderID";
        }
        private void WindDead(object sender, RoutedEventArgs e)
        {
            StorageTable.Columns[1].Visibility = Visibility.Collapsed;
            StorageTable.Columns[2].Visibility = Visibility.Collapsed;
            StorageTable.Columns[3].Visibility = Visibility.Collapsed;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (StorageTable.SelectedItem as DataRowView != null)
            {
                object id = (StorageTable.SelectedItem as DataRowView).Row[0];

                var allID = Products.GetData().Rows;

                for (int i = 0; i < allID.Count; i++)
                {
                    if (allID[i][1].ToString() == id.ToString())
                    {
                        Products.UpdateQueryStorage(1, i + 1);
                    }
                }
                Storagee.DeleteQuery(Convert.ToInt32(id));
                StorageTable.ItemsSource = Storagee.GetaMain();
                StorageTable.Columns[1].Visibility = Visibility.Collapsed;
                StorageTable.Columns[2].Visibility = Visibility.Collapsed;
                StorageTable.Columns[3].Visibility = Visibility.Collapsed;
            }
        }
    
        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(ID.Text) || string.IsNullOrWhiteSpace(Product.Text) || string.IsNullOrWhiteSpace(Quantity.Text) || ProviderCBX.SelectedItem == null)
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                ProviderCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                Quantity.BorderBrush = new SolidColorBrush(Colors.Red);
                Product.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (int.TryParse(ID.Text, out int numbr) && !Regex.IsMatch(Product.Text, @"\d"))
            {
                object Prov = (ProviderCBX.SelectedItem as DataRowView).Row[0];

                ID.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                ProviderCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Quantity.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Product.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));

                Storagee.InsertQuery(Convert.ToInt32(ID.Text), Product.Text, Convert.ToInt32(Quantity.Text), Convert.ToInt32(Prov));
                StorageTable.ItemsSource = Storagee.GetaMain();
                StorageTable.Columns[1].Visibility = Visibility.Collapsed;
                StorageTable.Columns[2].Visibility = Visibility.Collapsed;
                StorageTable.Columns[3].Visibility = Visibility.Collapsed;
            }
            else
            {
                ID.BorderBrush = new SolidColorBrush(Colors.Red);
                ProviderCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Quantity.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                Product.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (StorageTable.SelectedItem as DataRowView != null)
            {
                if (string.IsNullOrWhiteSpace(Product.Text) || string.IsNullOrWhiteSpace(Quantity.Text) || ProviderCBX.SelectedItem == null)
                {
                    ProviderCBX.BorderBrush = new SolidColorBrush(Colors.Red);
                    Quantity.BorderBrush = new SolidColorBrush(Colors.Red);
                    Product.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else if (!Regex.IsMatch(Product.Text, @"\d"))
                {
                    object buy = (ProviderCBX.SelectedItem as DataRowView).Row[0];

                    ProviderCBX.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Quantity.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    Product.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9a76"));
                    object id = (StorageTable.SelectedItem as DataRowView).Row[0];

                    Storagee.UpdateQuery(Product.Text, Convert.ToInt32(Quantity.Text), Convert.ToInt32(buy), Convert.ToInt32(id));
                    StorageTable.ItemsSource = Storagee.GetaMain();
                    StorageTable.Columns[1].Visibility = Visibility.Collapsed;
                    StorageTable.Columns[2].Visibility = Visibility.Collapsed;
                    StorageTable.Columns[3].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
